using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Common;
using System.Data;
using AgenciaAutos.Comun;

namespace AgenciaAutos.Datos
{
    public class DatoAuto
    {
        public DatoAuto()
        {

        }

        public static string constr
        {
            get { return ConfigurationManager.ConnectionStrings["conn"].ConnectionString; }
        }

        public static string Provider
        {
            get { return ConfigurationManager.ConnectionStrings["conn"].ProviderName; }
        }

        public static DbProviderFactory dpf
        {
            get
            {
                return DbProviderFactories.GetFactory(Provider);
            }
        }

        private static int ejecutaNonQuery(string StoredProcedure, List<DbParameter> parametros)
        {
            int Id = 0;
            try
            {
                using (DbConnection con = dpf.CreateConnection())
                {
                    con.ConnectionString = constr;

                    using (DbCommand cmd = dpf.CreateCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = StoredProcedure;
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach(DbParameter param in parametros)
                        {
                            cmd.Parameters.Add(param);
                        }

                        con.Open();
                        Id = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return Id;
        }

        public int InsertarAuto(string Marca, decimal Precio)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = dpf.CreateParameter();
            param.Value = Marca;
            param.ParameterName = "Marca";
            parametros.Add(param);

            DbParameter param1 = dpf.CreateParameter();
            param1.Value = Precio;
            param1.ParameterName = "Precio";
            parametros.Add(param1);

            return ejecutaNonQuery("AltasAuto", parametros);
        }

        public int ActualizarAuto(int AutoId, string Marca, decimal Precio)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = dpf.CreateParameter();
            param.Value = AutoId;
            param.ParameterName = "AutoId";
            parametros.Add(param);

            DbParameter param1 = dpf.CreateParameter();
            param1.Value = Marca;
            param1.ParameterName = "Marca";
            parametros.Add(param1);

            DbParameter param2 = dpf.CreateParameter();
            param2.Value = Precio;
            param2.ParameterName = "Precio";
            parametros.Add(param2);

            return ejecutaNonQuery("ActualizarAuto", parametros);
        }

        public int EliminarAuto(int AutoId)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            DbParameter param = dpf.CreateParameter();
            param.Value = AutoId;
            param.ParameterName = "AutoId";
            parametros.Add(param);

            return ejecutaNonQuery("BorrarAuto", parametros);
        }

        public List<Autos> select_All_Autos()
        {
            List<Autos> lstAutos = new List<Autos>();

            string StoredProcedure = "ObtenerAutos";

            using (DbConnection con = dpf.CreateConnection())
            {
                con.ConnectionString = constr;

                using (DbCommand cmd = dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            lstAutos.Add(
                                    new Autos((int)dr["AutoId"], 
                                            (string)dr["Marca"], 
                                            (decimal)dr["Precio"])
                                );
                        }
                    }
                }

            }

            return lstAutos;
        }

        public Autos select_AutosById(int AutoId)
        {
            Autos objAuto = new Autos();
            string StoredProcedure = "ObtenerAutoById";

            using (DbConnection con = dpf.CreateConnection())
            {
                con.ConnectionString = constr;

                using (DbCommand cmd = dpf.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;

                    DbParameter param = cmd.CreateParameter();
                    param.DbType = DbType.Int32;
                    param.ParameterName = "AutoId";
                    param.Value = AutoId;
                    cmd.Parameters.Add(param);
                    con.Open();

                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr.Read())
                        {
                            objAuto = new Autos(
                                    AutoId,
                                    (string)dr["Marca"],
                                    (decimal)dr["Precio"]
                                );
                        }
                    }
                }
            }

            return objAuto;
        }
    }
}