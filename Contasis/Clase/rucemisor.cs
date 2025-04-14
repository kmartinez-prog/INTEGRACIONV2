using System;
using System.Data;
using System.Data.SqlClient;
using Npgsql;


namespace Contasis.Clase
{
    class rucemisor
    {
        string query;
        public DataTable Cargar()
        {
            SqlDataReader carga;
            DataTable Grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            
            try
            {
                if (Properties.Settings.Default.TipModulo == "1")
                {
                     query = "select ccodrucemisor,cdesrucemisor,flgactivo,nventaflg,ncompraflg,ncobranzaflg,npagoflg,ncomfondom  from cg_empemisor ";
                }
                if (Properties.Settings.Default.TipModulo == "2")
                {
                    query = "select ccodrucemisor,cdesrucemisor,flgactivo,ncomproductoflg,ncomcompraflg,ncomventaflg,ncobranzacomercial  from cg_empemisor ";
                }


                cone = ConexionSql.Instancial().Establecerconexion();
                SqlCommand commando = new SqlCommand(query, cone);
                cone.Open();
                carga = commando.ExecuteReader();
                Grilla.Load(carga);
                return Grilla;
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
            finally
            {
                if (cone.State == ConnectionState.Open)
                {
                    cone.Close();
                }

            }
        }
        public DataTable Cargarpostgres()
        {
            NpgsqlDataReader carga;
            DataTable Grilla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {

                if (Properties.Settings.Default.TipModulo == "1")
                {
                    query = "select ccodrucemisor,cdesrucemisor,flgactivo::char(1) as flgactivo,nventaflg,ncompraflg,ncobranzaflg,npagoflg,ncomfondom  from cg_empemisor ";
                }
                if (Properties.Settings.Default.TipModulo == "2")
                {
                    query = "select ccodrucemisor,cdesrucemisor,flgactivo::char(1) as flgactivo,ncomproductoflg::char(1) as ncomproductoflg,ncomcompraflg::char(1) as ncomcompraflg ,ncomventaflg::char(1) as ncomventaflg,ncobranzacomercial as cobranza  from cg_empemisor "; //,ncomfondom//
                }


                NpgsqlCommand cmdp = new NpgsqlCommand(query, conexion);

                carga = cmdp.ExecuteReader();
                Grilla.Load(carga);
                return Grilla;
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
        }

    }
}
