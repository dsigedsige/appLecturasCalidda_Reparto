﻿using DSIGE.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaliddaReparto.Web.Controllers
{
    public class CambioEstado_MasivoController : Controller
    {
        //
        // GET: /CambioEstado/

        public ActionResult IndexCambioEstado_Masivo()
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
        public string ListandoServicios()
        {
            object loDatos;
            try
            {
                CambioEstado_Masivo_BL obj_negocio = new CambioEstado_Masivo_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaServicios();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }

        }

        [HttpPost]
        public string ListandoLocal()
        {
            object loDatos;
            try
            {
                CambioEstado_Masivo_BL obj_negocio = new CambioEstado_Masivo_BL();
                loDatos = obj_negocio.Capa_Negocio_Get_ListaLocales();
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }

        
        [HttpPost]
        public string GenerarCambioEstado_Masivo(int local, int servicio, int operario,  string fecha_Asigna)
        {
            object loDatos;
            loDatos = null;
            try
            {
                CambioEstado_Masivo_BL obj_negocio = new CambioEstado_Masivo_BL();
                loDatos = obj_negocio.Capa_Negocio_get_CambioEstado_Masivo(local, servicio, operario, fecha_Asigna, ((Sesion)Session["Session_Usuario_Acceso"]).usuario.usu_id);
                return _Serialize(loDatos, true);
            }
            catch (Exception ex)
            {
                return _Serialize(ex.Message, true);
            }
        }


    }
}
