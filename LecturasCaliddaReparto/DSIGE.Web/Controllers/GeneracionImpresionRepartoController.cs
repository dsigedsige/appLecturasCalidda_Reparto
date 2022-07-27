﻿using DSIGE.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaliddaReparto.Web.Controllers
{
    public class GeneracionImpresionRepartoController : Controller
    {
        //
        // GET: /GeneracionImpresionReparto/

        public ActionResult GeneracionReparto_index()
        {
            return View();
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
        public string insert_file_excel(HttpPostedFileBase file)
        {
            DataTable dt_excel = new DataTable();
            object loDatos;
            try
            {
                string extension =  String.Format("{0:ddMMyyyy_hhmmss}.xlsx", DateTime.Now);
                string nomExcel = "Importar_excel_" + ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id + extension;
                string fileLocation = Server.MapPath("~/Upload") + "\\" + nomExcel;
                file.SaveAs(fileLocation);
  
                string sql = "SELECT * FROM [Importar$]";

                OleDbDataAdapter da = new OleDbDataAdapter(sql, ConectarExcel(fileLocation));
                da.SelectCommand.CommandType = CommandType.Text;
                da.Fill(dt_excel);
                loDatos = dt_excel;
                da.Dispose();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        OleDbConnection cn;

        private OleDbConnection ConectarExcel(string nomExcel)
        {
            cn = new OleDbConnection();
            try
            {
                cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + nomExcel + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                cn.Open();
                return cn;
            }
            catch (Exception)
            {
                cn.Close();
                throw;
            }
        }


    }
}
