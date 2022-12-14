using DSIGE.Modelo;
using DSIGE.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Excel = OfficeOpenXml;
using Style = OfficeOpenXml.Style;

namespace CaliddaReparto.Web.Controllers
{
    public class Listado_Lecturas_TomadasController : Controller
    {
        //
        // GET: /Listado_Lecturas_Tomadas/

        public ActionResult Inicio()
        {
            return View();
        }
  
        /// <summary>
        /// Autor: rcontreras
        /// Fecha: 29-11-2015
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult JsonListaFotosMasiva()
        {
       
            return new ContentResult
            {
                Content = MvcApplication._Serialize(
                        new NLectura().NListaFotosMasivo(
                    //new Request_Lectura_Tomadas()
                    //{
                    //    local = Convert.ToInt32(__a),
                    //    tipo = Convert.ToInt32(__b),
                    //    f_ini = Convert.ToString(__c),
                    //    f_fin = Convert.ToString(__d),
                    //    suministro = Convert.ToString(__e),
                    //    medidor = Convert.ToString(__f)
                    //}
                        )
                    , true),
                ContentType = "application/json"
            };
        }

        public static string _Serialize(object value, bool ignore = false)
        {
            var SerializerSettings = new JsonSerializerSettings()
            {
                MaxDepth = Int32.MaxValue,
                NullValueHandling = (ignore == true ? NullValueHandling.Ignore : NullValueHandling.Include)
            };

            return JsonConvert.SerializeObject(value, Formatting.Indented, SerializerSettings);
        }

        [HttpPost]
        public JsonResult DescargaArchivo(string foto, string suministro, string medidor)
        {
            string _filePath = "";
            string _fileServer = "";
            string _fileFormatServer = "";

            _fileServer = String.Format(suministro + "_" + medidor + "_{0:ddMMyyyy_hhmmss}", DateTime.Now);
            //_fileFormatServer = System.IO.Path.Combine(Server.MapPath("/Content/foto"), foto);
            _fileFormatServer = System.IO.Path.Combine(Server.MapPath("/Calidda/Content/foto/foto"), foto);
            //_filePath = System.IO.Path.Combine(Server.MapPath("/Content/foto/temporal"), _fileServer);
            _filePath = System.IO.Path.Combine(Server.MapPath("/Calidda/Content/foto/temporal"), _fileServer);

            /*copia formato y lo ubica en carpeta temporal*/
            //System.IO.File.Copy(_fileFormatServer, _filePath + ".jpg", true);

            FileInfo _file = new FileInfo(_filePath);
            if (_file.Exists)
            {
                _file.Delete();
                _file = new FileInfo(_filePath);
            }

            try
            {
                using (Image oImg = Image.FromFile(_fileFormatServer))
                {

                    oImg.Save(ConfigurationManager.AppSettings["Rutafoto"] + @"" + _fileServer + ".jpg", ImageFormat.Jpeg);
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }



            return Json(new { Archivo = _fileServer });
        }

        [HttpPost]
        public ActionResult JsonListaLecturasTomadas(string __a, string __g, string __c, string __d, string __e, string __f, int __o)
        {
            List<string> listaVar = new List<string>();
            listaVar = new List<string>();
            listaVar.Add(__a);
            listaVar.Add(__g);
            listaVar.Add(__c);
            listaVar.Add(__d);
            listaVar.Add(__e);
            listaVar.Add(__f);
            listaVar.Add(Convert.ToString(__o));

            Session["listaVal"] = listaVar;

            return new ContentResult
            {
                Content = MvcApplication._Serialize(
                        new NLectura().NListaLecturasTomadas(
                            new Request_Lectura_Tomadas()
                            {
                                local = Convert.ToInt32(__a),
                                lista = Convert.ToString(__g),
                                f_ini = Convert.ToString(__c),
                                f_fin = Convert.ToString(__d),
                                suministro = Convert.ToString(__e),
                                medidor = Convert.ToString(__f),
                                operario = Convert.ToInt32(__o)
                            }
                        )
                    , true),
                ContentType = "application/json"
            };
        }


        [HttpPost]
        public string Descarga_Excel(string __a, string __g, string __c, string __d, string __e, string __f, int __o, string sector, string zona)
        {
            Int32 _fila = 2;
            string _servidor;
            String _ruta;
            string resultado = "";
            string nombreServicio = "";
            string FileExcel = "";
            try
            {

                List<string> listaVar = new List<string>();
                listaVar = new List<string>();
                listaVar.Add(__a);
                listaVar.Add(__g);
                listaVar.Add(__c);
                listaVar.Add(__d);
                listaVar.Add(__e);
                listaVar.Add(__f);
                listaVar.Add(Convert.ToString(__o));

                Session["listaVal"] = listaVar;


                List<Lecturas_Tomadas> _lista = new List<Lecturas_Tomadas>();

                NLectura obj_negocio = new DSIGE.Negocio.NLectura();
                _lista = obj_negocio.NListaLecturasTomadas(
                            new Request_Lectura_Tomadas()
                            {
                                local = Convert.ToInt32(__a),
                                lista = Convert.ToString(__g),
                                f_ini = Convert.ToString(__c),
                                f_fin = Convert.ToString(__d),
                                suministro = Convert.ToString(__e),
                                medidor = Convert.ToString(__f),
                                operario = Convert.ToInt32(__o)
                            }
                        );

                if (_lista.Count == 0)
                {
                    return _Serialize("0|No hay informacion para mostrar.", true);
                }

                nombreServicio = "";
                if (Convert.ToInt32(__g) == 1)
                {
                    nombreServicio = "LECTURAS_";
                }
                else if (Convert.ToInt32(__g) == 2)
                {
                    nombreServicio = "RELECTURA_";
                }


                _servidor = String.Format("{0:ddMMyyyy_hhmmss}.xlsx", DateTime.Now);
                _ruta = Path.Combine(Server.MapPath("~/Temp/") + "\\" + nombreServicio + _servidor);

                string rutaServer = ConfigurationManager.AppSettings["Archivos"];
                FileExcel = rutaServer + nombreServicio + _servidor;

                FileInfo _file = new FileInfo(_ruta);
                if (_file.Exists)
                {
                    _file.Delete();
                    _file = new FileInfo(_ruta);
                }

                using (Excel.ExcelPackage oEx = new Excel.ExcelPackage(_file))
                {
                    Excel.ExcelWorksheet oWs = oEx.Workbook.Worksheets.Add("Lecturas_tomadas");
                    oWs.Cells.Style.Font.SetFromFont(new Font("Tahoma", 9));

                    //marco detalle CABECERA
                    for (int i = 1; i <= 10; i++)
                    {
                        oWs.Cells[1, i].Style.Font.Bold = true;
                        oWs.Cells[1, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);    //marco
                        oWs.Cells[1, i].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    }

                    oWs.Cells[1, 1].Value = "SUMINISTRO";
                    oWs.Cells[1, 2].Value = "MEDIDOR";
                    oWs.Cells[1, 3].Value = "LECTURA ACTUAL";
                    oWs.Cells[1, 4].Value = "LECTURA ANTERIOR";
                    oWs.Cells[1, 5].Value = "PROMEDIO DE CONSUMO";

                    oWs.Cells[1, 6].Value = "LECTURISTA";
                    oWs.Cells[1, 7].Value = "COD. OBSERVACION";
                    oWs.Cells[1, 8].Value = "DESC. OBSERVACION";
                    oWs.Cells[1, 9].Value = "FECHA LECTURA";
                    oWs.Cells[1, 10].Value = "TIENE FOTO";

                    int acu = 0;

                    foreach (Lecturas_Tomadas oBj in _lista)
                    {
                        //marco detalle   
                        for (int i = 1; i <= 10; i++)
                        {
                            oWs.Cells[_fila, i].Style.Font.Size = 8;
                            oWs.Cells[_fila, i].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);    //marco  
                        }

                        oWs.Cells[_fila, 1].Value = oBj.Suministro_lectura;
                        oWs.Cells[_fila, 2].Value = oBj.Medidor_lectura;
                        oWs.Cells[_fila, 3].Value = oBj.Confirmacion_lectura;
                        oWs.Cells[_fila, 3].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        oWs.Cells[_fila, 3].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear tex

                        oWs.Cells[_fila, 4].Value = oBj.lectura_Anterior;
                        oWs.Cells[_fila, 4].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        oWs.Cells[_fila, 4].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear tex

                        oWs.Cells[_fila, 5].Value = oBj.promedioConsumo_Lectura;
                        oWs.Cells[_fila, 5].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        oWs.Cells[_fila, 5].Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Right; // alinear tex

                        oWs.Cells[_fila, 6].Value = oBj.Operario;
                        oWs.Cells[_fila, 7].Value = oBj.observacion_lectura;
                        oWs.Cells[_fila, 8].Value = oBj.descripcion_observacion;
                        oWs.Cells[_fila, 9].Value = oBj.fechaLecturaMovil_Lectura;
                        oWs.Cells[_fila, 10].Value = oBj.tieneFoto_lectura;
                        _fila++;
                    }

                    oWs.Row(1).Style.Font.Bold = true;
                    oWs.Row(1).Style.HorizontalAlignment = Style.ExcelHorizontalAlignment.Center;
                    oWs.Row(1).Style.VerticalAlignment = Style.ExcelVerticalAlignment.Center;

                    oWs.Column(1).Style.Font.Bold = true;

                    for (int i = 1; i <= 10; i++)
                    {
                        oWs.Column(i).AutoFit();
                    }

                    oEx.Save();
                }


                return _Serialize("1|" + FileExcel, true);


            }
            catch (Exception ex)
            {

                return _Serialize("0|" + ex.Message, true);
            }

        }


    }
}
