using DSIGE.Modelo;
using DSIGE.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaliddaReparto.Web.Controllers
{
    public class Actualizar_RepartoController : Controller
    {
        //
        // GET: /Actualizar_Reparto/

        public ActionResult Inicio()
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
        public string ListadoReparto(int servicio, string fecha)
        {

            object loDatos;
            try
            {
                NCorte Objeto_Negocio = new NCorte();

                loDatos = Objeto_Negocio.Capa_Negocio_Listar_Reparto_Agrupado(servicio, fecha, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);

                //loDatos = objeto_negocio.Capa_Negocio_Listado_Servicios(); ;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Serialize(loDatos, true);
        }



        [HttpPost]
        public string ActualizarReparto(int id_operario, string unidad_lectura, int id_servicio, string fechaAsignatura, int id_operario_cambiar)
        {

            object loDatos;
            try
            {
                NCorte Objeto_Negocio = new NCorte();
                loDatos = Objeto_Negocio.Capa_Negocio_Validar_Operario(id_operario_cambiar);
                if (loDatos == "no_existe")
                {
                    return _Serialize(loDatos,true);
                }
                loDatos = Objeto_Negocio.Capa_Negocio_Actualizar_Reparto_Agrupado(id_operario, unidad_lectura, id_servicio, fechaAsignatura, id_operario_cambiar);

                //loDatos = objeto_negocio.Capa_Negocio_Listado_Servicios(); ;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Serialize(loDatos, true);
        }


        [HttpPost]
        public string GetReporteReparto(string fecha)
        {
            object loDatos;
            try
            {
                NCorte Objeto_Negocio = new NCorte();

                loDatos = Objeto_Negocio.Capa_Negocio_Listar_Reparto_Reporte(fecha);

                //loDatos = objeto_negocio.Capa_Negocio_Listado_Servicios(); ;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Serialize(loDatos, true);
        }

        [HttpPost]
        public string Generando_Compartir_lecturas(int id_servicio , string fecha, string cod_unidad, int  id_operario)
        {
            object loDatos;
            try
            {
                NCorte Objeto_Negocio = new NCorte();
                loDatos = Objeto_Negocio.Capa_negocio_Generando_Compartir_lecturas(id_servicio, fecha, cod_unidad, id_operario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _Serialize(loDatos, true);
        }


        //--- reparto enel 


        [HttpPost]
        public string ListadoReparto_enel(int servicio, string fecha)
        {
            object loDatos;
            try
            {
                NCorte Objeto_Negocio = new NCorte();
                loDatos = Objeto_Negocio.Capa_Negocio_Listar_Reparto_Enel_Agrupado(servicio, fecha, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _Serialize(loDatos, true);
        }

        [HttpPost]
        public string ActualizarReparto_enel(int id_operario, string unidad_lectura, int id_servicio, string fechaAsignatura, int id_operario_cambiar)
        {

            object loDatos;
            try
            {
                NCorte Objeto_Negocio = new NCorte();
                loDatos = Objeto_Negocio.Capa_Negocio_Validar_Operario(id_operario_cambiar);

                if (loDatos == "no_existe")
                {
                    return _Serialize(loDatos, true);
                }
                loDatos = Objeto_Negocio.Capa_Negocio_Actualizar_Reparto_Agrupado_enel(id_operario, unidad_lectura, id_servicio, fechaAsignatura, id_operario_cambiar);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _Serialize(loDatos, true);
        }


        [HttpPost]
        public string Generando_Compartir_lecturas_enel(int id_servicio, string fecha, string cod_unidad, int id_operario)
        {
            object loDatos;
            try
            {
                NCorte Objeto_Negocio = new NCorte();
                loDatos = Objeto_Negocio.Capa_negocio_Generando_Compartir_lecturas_enel(id_servicio, fecha, cod_unidad, id_operario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _Serialize(loDatos, true);
        }



    }
}
