using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgenciaAutos.Comun;
using AgenciaAutos.Datos;


namespace AgenciaAutos.Negocio
{
    public class NegocioAutos
    {
        public NegocioAutos()
        {

        }

        /// <summary>
        /// Insertar un nuevo auto
        /// </summary>
        /// <returns></returns>
        public int AltaAuto(string Marca, decimal Precio)
        {
            DatoAuto datAuto = new DatoAuto();
            return datAuto.InsertarAuto(Marca, Precio);
        }

        /// <summary>
        /// Actualiza los datos de un auto
        /// </summary>
        /// <param name="AutoId"></param>
        /// <param name="Marca"></param>
        /// <param name="Precio"></param>
        /// <returns></returns>
        public int ActualizarAuto(int AutoId, string Marca, decimal Precio)
        {
            DatoAuto datAuto = new DatoAuto();
            return datAuto.ActualizarAuto(AutoId, Marca, Precio);
        }

        /// <summary>
        /// Devuelve toda la lista de autos
        /// </summary>
        /// <returns></returns>
        public List<Autos> ObtenerAutos()
        {
            DatoAuto datAuto = new DatoAuto();
            return datAuto.select_All_Autos();
        }

        public Autos ObtenerAutosById(int AutoId)
        {
            DatoAuto datAuto = new DatoAuto();
            return datAuto.select_AutosById(AutoId);
        }

        public int EliminarAuto(int AutoId)
        {
            DatoAuto datAuto = new DatoAuto();
            return datAuto.EliminarAuto(AutoId);
        }
    }
}