using DSIGE.Dato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSIGE.Negocio
{
    public class GeneracionActas_BL
    {
        public object Capa_Negocio_Servicio()
        {
            GeneracionActas_DAO Objeto_Dato = new GeneracionActas_DAO();
            return Objeto_Dato.Capa_Dato_Servicios();
        }
        public object Capa_Negocio_Servicio_all()
        {
            GeneracionActas_DAO Objeto_Dato = new GeneracionActas_DAO();
            return Objeto_Dato.Capa_Dato_Servicios_all();
        }


        public object Capa_Negocio_getAreas()
        {
            GeneracionActas_DAO Objeto_Dato = new GeneracionActas_DAO();
            return Objeto_Dato.Capa_Dato_getAreas();
        }


        public object Capa_Negocio_Mostrando_informacion_general(int servicio, int operario, string fecha)
        {
            GeneracionActas_DAO Objeto_Dato = new GeneracionActas_DAO();
            return Objeto_Dato.Capa_Dato_Mostrando_informacion_general(servicio, operario, fecha);
        }



        public object Capa_Negocio_Mostrando_informacion_actas_masivas(int servicio, int operario, string fecha, string id_fecha_final)
        {
            GeneracionActas_DAO Objeto_Dato = new GeneracionActas_DAO();
            return Objeto_Dato.Capa_Dato_Mostrando_informacion_Actas_masivas(servicio, operario, fecha, id_fecha_final);
        }

        public object Capa_Negocio_Mostrando_informacion_Inspecciones(int servicio, int operario, string fecha, int tipoReporte)
        {
            GeneracionActas_DAO Objeto_Dato = new GeneracionActas_DAO();
            return Objeto_Dato.Capa_Dato_Mostrando_informacion_Inspecciones(servicio, operario, fecha, tipoReporte);
        }


        public object Capa_Negocio_Mostrando_informacion_InspeccionesMasivas(int servicio, int operario, string fecha, string fechaFinal, int tipoReporte)
        {
            GeneracionActas_DAO Objeto_Dato = new GeneracionActas_DAO();
            return Objeto_Dato.Capa_Dato_Mostrando_informacion_InspeccionesMasivas(servicio, operario, fecha, fechaFinal, tipoReporte);
        }

        public object Capa_negocio_get_generacionPdf_inspecciones(int id_inspeccion, int  tipoReporte)
        {
            GeneracionActas_DAO Objeto_Dato = new GeneracionActas_DAO();
            return Objeto_Dato.Capa_dato_get_generacionPdf_inspecciones(id_inspeccion, tipoReporte);
        }
        

        public object Capa_negocio_get_generacionPdf_checkList(int id_inspeccion, int tipoReporte)
        {
            GeneracionActas_DAO Objeto_Dato = new GeneracionActas_DAO();
            return Objeto_Dato.Capa_dato_get_generacionPdf_checkList(id_inspeccion, tipoReporte);
        }
        


    }
}
