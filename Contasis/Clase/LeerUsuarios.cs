using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using Npgsql;

namespace Contasis.Clase
{
    class LeerUsuarios
    {
        public string validaUsuario()
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {

                string query0 = "SELECT  * FROM SYSDATABASES WHERE NAME='bdintegradorContasis'";
                cone = ConexionSql.Instancial().Establecerconexion();
                SqlCommand commando = new SqlCommand(query0, cone);
                DataTable dt = new DataTable();
                cone.Open();
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cadena = "1";
                }
                else
                {
                    Properties.Settings.Default.cadenaSql = "";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    Properties.Settings.Default.cadenaPost = "";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    Properties.Settings.Default.cadenaPostPrincipal = "";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    cadena = "0";
                }
            }
            catch 
            {
               
                
            }
            finally
            {
                if (cone.State == ConnectionState.Open)
                {
                    cone.Close();
                }

            }
            return cadena;

        }

        public string existeusuario()
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {

                string query0 = "SELECT  * FROM CG_USUARIO";
                cone = ConexionSql.Instancial().Establecerconexion();
                SqlCommand commando = new SqlCommand(query0, cone);
                DataTable dt = new DataTable();
                cone.Open();
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cadena = "11";
                }
                else
                {
                    Properties.Settings.Default.cadenaSql = "";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    Properties.Settings.Default.cadenaPost = "";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    Properties.Settings.Default.cadenaPostPrincipal = "";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    cadena = "00";
                }
            }
            catch 
            {


            }
            finally
            {
                if (cone.State == ConnectionState.Open)
                {
                    cone.Close();
                }

            }
            return cadena;

        }

        public string validaUsuario2()
        {
            string cadena = "";
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            { }
            else
            { 
            DataTable Tabla = new DataTable();
            NpgsqlConnection conexionNew = new NpgsqlConnection();
            conexionNew.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexionNew.Open();
                try
                {
                    string text03 = "select distinct datname from pg_database where datname='bdintegradorcontasis'";
                    NpgsqlCommand cmdp3 = new NpgsqlCommand(text03, conexionNew);
                    DataTable dt1 = new DataTable();
                    NpgsqlDataAdapter data1 = new NpgsqlDataAdapter(cmdp3);
                    data1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        cadena = "1";
                    }
                    else
                    {
                        Properties.Settings.Default.cadenaSql = "";
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();

                        Properties.Settings.Default.cadenaPost = "";
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();

                        Properties.Settings.Default.cadenaPostPrincipal = "";
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();


                        cadena = "0";
                    }
                }
                catch 
                {


                }
                finally
                {
                    if (conexionNew.State == ConnectionState.Open)
                    {
                        conexionNew.Close();
                    }
                }
            }
            return cadena;

        }
        public string existeusuario2()
        {
            string cadena = "";
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            { }
            else
            { 
               DataTable Tabla = new DataTable();
            NpgsqlConnection conexionNew = new NpgsqlConnection();
            conexionNew.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexionNew.Open();

                try
                {

                    string query0 = "select * from cg_usuario";
                    NpgsqlCommand cmdp3 = new NpgsqlCommand(query0, conexionNew);
                    DataTable dt = new DataTable();
                    NpgsqlDataAdapter data1 = new NpgsqlDataAdapter(cmdp3);
                    data1.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        cadena = "11";
                    }
                    else
                    {
                        Properties.Settings.Default.cadenaSql = "";
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();

                        Properties.Settings.Default.cadenaPost = "";
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();

                        Properties.Settings.Default.cadenaPostPrincipal = "";
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();

                        cadena = "00";
                    }
                }
                catch 
                {


                }
                finally
                {
                    if (conexionNew.State == ConnectionState.Open)
                    {
                        conexionNew.Close();
                    }
                }
            }
            return cadena;

        }


    }
}
