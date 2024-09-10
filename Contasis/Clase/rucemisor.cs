using System;
using System.Data;
using System.Data.SqlClient;
using Npgsql;


namespace Contasis.Clase
{
    class rucemisor
    {
        public DataTable Cargar()
        {
            SqlDataReader carga;
            DataTable Grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "select ccodrucemisor,cdesrucemisor,flgactivo,nventaflg,ncompraflg,ncobranzaflg,npagoflg  from cg_empemisor ";
                cone = ConexionSql.Instancial().establecerconexion();
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
                string query = "select ccodrucemisor,cdesrucemisor,flgactivo::char(1) as flgactivo,nventaflg,ncompraflg,ncobranzaflg,npagoflg  from cg_empemisor ";
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
