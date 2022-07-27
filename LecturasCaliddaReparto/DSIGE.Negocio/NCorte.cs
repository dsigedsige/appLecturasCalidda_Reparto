﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DSIGE;
using DSIGE.Modelo;
using DSIGE.Dato;

namespace DSIGE.Negocio
{
    public class NCorte
    {
        /// <summary>
        /// Autor: jlucero
        /// Fecha: 2015-07-17
        /// </summary>
        public NCorte() { }

        /// <summary>
        /// Autor: jlucero
        /// Fecha: 2015-07-17
        /// </summary>
        /// <param name="oRq"></param>
        /// <returns></returns>
        public int NBulkInfo(List<Corte> oRq)
        {
            try
            {
                return new DCorte().DBulkInfo(oRq);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Autor: jlucero
        /// Fecha: 2015-07-17
        /// </summary>
        /// <param name="oRq"></param>
        /// <returns></returns>
        public List<Corte> NListaValidado(Request_Corte_Validacion oRq)
        {
            try
            {
                return new DCorte().DListaValidado(oRq);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Autor: jlucero
        /// Fecha: 2015-07-17
        /// </summary>
        /// <param name="oRq"></param>
        /// <returns></returns>
        public int NInsertaMasivo(Request_Corte_Inserta_Masivo oRq)
        {
            try
            {
                return new DCorte().DInsertaMasivo(oRq);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public object Capa_Negocio_get_grandesClientes_Agrupado(string fechaAsignacion, int cod_usuario)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Listar_grandesClientes_agrupado(fechaAsignacion, cod_usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Capa_Negocio_Actualizar_grandesClientes_Agrupado(int id_operario, string distrito, string fechaAsignatura, int id_operario_cambiar)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Actualizar_GrandesClientes(id_operario, distrito, fechaAsignatura, id_operario_cambiar);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public object Capa_Negocio_get_grandesClientes_Agrupado_detallado(string fechaAsignacion, string distrito, int id_operario, string forma)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_get_grandesClientes_Detallado(fechaAsignacion, distrito, id_operario, forma);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string Capa_Negocio_Generando_EnvioMovil_grandesClientes_Detallado(List<GrandesClientesDetalle> ListaGrandesClientes, string FechaAsigna, string FechaMovil, int id_usuario, string Forma)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Generando_EnvioMovil_grandesClientes_Detallado(ListaGrandesClientes, FechaAsigna, FechaMovil, id_usuario, Forma);
            }
            catch (Exception e)
            {
                throw e;
            }
        }




        public bool Capa_Negocio_Actualizar_Reparto_Agrupado(int id_operario, string unidad_lectura, int id_servicio, string fechaAsignatura, int id_operario_cambiar)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Actualizar_Reparto(id_operario, unidad_lectura, id_servicio,  fechaAsignatura, id_operario_cambiar);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool Capa_Negocio_Actualizar_Reparto_Agrupado_enel(int id_operario, string unidad_lectura, int id_servicio, string fechaAsignatura, int id_operario_cambiar)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Actualizar_Reparto_enel(id_operario, unidad_lectura, id_servicio, fechaAsignatura, id_operario_cambiar);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public string Capa_Negocio_Validar_Operario(int id_operario)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Validar_Operario(id_operario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Reparto> Capa_Negocio_Listar_Reparto_Reporte(string fechaAsignacion)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Listar_Reparto_Reporte(fechaAsignacion);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public string Capa_negocio_Generando_Compartir_lecturas(int id_servicio , string fecha, string cod_unidad, int id_operario)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_dato_Generando_Compartir_lecturas(id_servicio, fecha, cod_unidad, id_operario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Capa_negocio_Generando_Compartir_lecturas_enel(int id_servicio, string fecha, string cod_unidad, int id_operario)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_dato_Generando_Compartir_lecturas_enel(id_servicio, fecha, cod_unidad, id_operario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<Reparto> Capa_Negocio_Listar_Reparto_Agrupado(int servicio, string fechaAsignacion, int cod_usuario)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Listar_Reparto(servicio, fechaAsignacion, cod_usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public  object  Capa_Negocio_Listar_Reparto_Enel_Agrupado(int servicio, string fechaAsignacion, int cod_usuario)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Listar_Reparto_Enel(servicio, fechaAsignacion, cod_usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public bool Capa_Negocio_ListaExcel(string fileLocation, int usuario, int idlocal, string idfechaAsignacion)
        {
            try
            {
                DCorte Objeto_Corte = new DCorte();
                return Objeto_Corte.Capa_Dato_ListaExcelcorte(fileLocation, usuario, idlocal, idfechaAsignacion);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        /// <summary>
        /// reconexiones
        /// </summary>
        /// <param name="fileLocation"></param>
        /// <param name="usuario"></param>
        /// <param name="idlocal"></param>
        /// <param name="idfechaAsignacion"></param>
        /// <returns></returns>
        public bool Capa_Negocio_ListaExcelReconexiones(string fileLocation, int usuario, int idlocal, string idfechaAsignacion)
        {
            try
            {
                DCorte Objeto_Corte = new DCorte();
                return Objeto_Corte.Capa_Dato_ListaExcelreconexiones(fileLocation, usuario, idlocal, idfechaAsignacion);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public object Capa_Negocio_ListaExcelReparto(string fileLocation, int usuario, int idlocal, string idfechaAsignacion)
        {
            try
            {
                DCorte Objeto_Corte = new DCorte();
                return Objeto_Corte.Capa_Dato_ListaExcelReparto_new(fileLocation, usuario, idlocal, idfechaAsignacion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object Capa_Negocio_ListaExcel_enel(string fileLocation, int usuario, int idlocal, string idfechaAsignacion, int anio, int mes)
        {
            try
            {
                DCorte Objeto_Corte = new DCorte();
                return Objeto_Corte.Capa_Dato_ListaExcel_Enel(fileLocation, usuario, idlocal, idfechaAsignacion, anio, mes);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public List<CorteTemporalCorte> Capa_Negocio_Listar_Temporal_Cortes_Agrupado(string fechaAsignacion, int cod_usuario, int idServicio)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Listar_Temporal_cortes_Agrupado(fechaAsignacion, cod_usuario, idServicio);
            }
            catch (Exception e)
            {

                throw e;
            }


        }
        /// <summary>
        ///lista datos reconexiones
        /// </summary>
        /// <param name="cod_usuario"></param>
        /// <returns></returns>
        public List<CorteTemporalCorte> Capa_Negocio_Listar_Temporal_Reconexiones_Agrupado(string fechaAsignacion, int cod_usuario, int idServicio)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Listar_Temporal_reconexiones_Agrupado(fechaAsignacion, cod_usuario, idServicio);
            }
            catch (Exception e)
            {

                throw e;
            }


        }


        public object Capa_Negocio_Listar_Temporal_Reparto_Agrupado(string fechaAsignacion, int cod_usuario, int idServicio)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Listar_Temporal_Reparto_Agrupado_new(fechaAsignacion, cod_usuario, idServicio);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public object  Capa_Negocio_Listar_Temporal_enel_Agrupado(string fechaAsignacion, int cod_usuario, int idServicio)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Listar_Temporal_Enel_Agrupado(fechaAsignacion, cod_usuario, idServicio);
            }
            catch (Exception e)
            {

                throw e;
            }
        }



        public string Capa_Negocio_MigracionTablaTemporalCorte(string fechaAsignacion, int id_servicio, string nombre_archivo, int usuario)
        {
            DCorte oCorte = new DCorte();
            return oCorte.Capa_Dato_Guardar_InformacionCorte(fechaAsignacion, id_servicio, nombre_archivo, usuario); 
        }
        /// <summary>
        /// Reconexiones
        /// </summary>
        /// <param name="fechaAsignacion"></param>
        /// <param name="id_servicio"></param>
        /// <param name="nombre_archivo"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public string Capa_Negocio_MigracionTablaTemporalReconexiones(string fechaAsignacion, int id_servicio, string nombre_archivo, int usuario)
        {
            DCorte OoCorte = new DCorte();
            return  OoCorte.Capa_Dato_Guardar_InformacionReconexiones(fechaAsignacion, id_servicio, nombre_archivo, usuario);
        }


        public bool Capa_Negocio_MigracionTablaTemporalReparto(string fechaAsignacion, int id_servicio, string nombre_archivo, int usuario)
        {
            try
            {
                bool valor = true;
                DCorte OoCorte = new DCorte();
                valor = OoCorte.Capa_Dato_Guardar_InformacionReparto(fechaAsignacion, id_servicio, nombre_archivo, usuario);
                return valor;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public object Capa_Negocio_set_grabarDatos_excelEnel(string fechaAsignacion, int id_servicio, string nombre_archivo, int usuario)
        {
            try
            {
                DCorte OoCorte = new DCorte();
                return OoCorte.Capa_Dato_Guardar_Informacion_ExcelEnel(fechaAsignacion, id_servicio, nombre_archivo, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<CorteTemporalCorte> Capa_Negocio_Listar_TemporalCorte(int cod_usuario, int idtecnico, string distrito)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Listar_TemporalCorteReconexiones(cod_usuario, idtecnico, distrito);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<CorteTemporalCorte> Capa_Negocio_Listar_TemporalReconexion(int cod_usuario, int idtecnico, string distrito)
        {
            try
            {
                DCorte oCorte = new DCorte();
                return oCorte.Capa_Dato_Listar_TemporalReconexiones(cod_usuario, idtecnico, distrito);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public List<corteSumnistro> NlistaNoCorte(int id_tiposervicio, string fecha_asignacion, string suministro)
        {
            try
            {
                DCorte oCorte = new DCorte();
                List<corteSumnistro> corttes = new List<corteSumnistro>();
                corttes = oCorte.DCorteListaSuministro(id_tiposervicio, fecha_asignacion, suministro);
                return corttes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool NCambioEstadoCorte(int id_tiposervicio, string fecha_asignacion, string suministro)
        {
            try
            {
                DCorte oCorte = new DCorte();


                return oCorte.Capa_Dato_Cambio_Estado_Corte(id_tiposervicio, fecha_asignacion, suministro); ;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public object Capa_Negocio_get_datosCargo(int anio, int mes, string sector, int tipoCargo, int usuario)
        {
            try
            {
                DCorte OoCorte = new DCorte();
                return OoCorte.Capa_Dato_get_datosCargo(anio , mes, sector, tipoCargo, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public object Capa_Negocio_get_datosCargoPDF(string idscargo, int tipoCargo, int usuario)
        {
            try
            {
                DCorte OoCorte = new DCorte();
                return OoCorte.Capa_Dato_get_datosCargoPDF(idscargo,tipoCargo, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
