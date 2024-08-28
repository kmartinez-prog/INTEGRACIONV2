using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace Contasis.Clase
{
     class Empresas
    {
        public DataTable Cargar_empresa(Clase.empresaPropiedades Objet)
        {
            SqlDataReader carga;
            DataTable Grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT CCOD_EMPRESA,NOMEMPRESA AS NOMBRE_DE_EMPRESAS FROM CG_EMPRESA WHERE ccodrucemisor='"+Objet.ruc.Trim()+"'";
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
        public DataTable Cargar_empresacodigo(string codigo)
        {
            SqlDataReader carga;
            DataTable Grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT CCOD_EMPRESA,NOMEMPRESA AS NOMBRE_DE_EMPRESAS FROM CG_EMPRESA where CCOD_EMPRESA like'%"+codigo+"%'";
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
        public DataTable Cargar_empresadescri(string empresa)
        {
            SqlDataReader carga;
            DataTable Grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT CCOD_EMPRESA,NOMEMPRESA AS NOMBRE_DE_EMPRESAS FROM CG_EMPRESA where NOMEMPRESA like '%"+empresa+"'%";
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
        public string obtenerempresa(Clase.empresaPropiedades Objet)
    {
        string cadena1 = "";
        string cadena = "";
        DataTable Tabla = new DataTable();
        SqlConnection cone = new SqlConnection();

        try
        {
                string query = "Insert into CG_EMPRESA(ccodrucemisor,CCOD_EMPRESA,NOMEMPRESA) values(" +
                    "'" + Objet.ruc + "', " +
                    "'" + Objet.codempresa + "', " +
                    "'" + Objet.empresa + "')";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando1 = new SqlCommand(query, cone);
                cone.Open();
                cadena = commando1.ExecuteNonQuery() == 1 ? "Grabado" : "No se grabo";
            

        }
        catch (Exception ex1)
        {
               cadena1 = ex1.Message;
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
        public string actualizaremp(Clase.empresaPropiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string cadena1 = "update cg_empresa set nomempresa='" + Objet.empresa + "' where ccod_empresa='" + Objet.codempresa + "'";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(cadena1, cone);
                cone.Open();
                cadena = commando.ExecuteNonQuery() == 1 ? "Actualizado" : "No se pudo actualizar";
            }
            catch (Exception ex1)
            {
                //MessageBox.Show(ex1.ToString());
                cadena = ex1.Message;
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
        public string eliminaremp(Clase.empresaPropiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string cadena1 = "Delete from cg_empresa  where ccod_empresa='" + Objet.codempresa + "'";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(cadena1, cone);
                cone.Open();
                cadena = commando.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";
            }
            catch (Exception ex1)
            {
                ///MessageBox.Show(ex1.ToString());
                cadena = ex1.Message;
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
        public DataTable Cargar_empresa_postgres(Clase.empresaPropiedades Objet)
        {
            
            NpgsqlDataReader carga;
            DataTable Grilla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "select ccod_empresa,nomempresa as nombre_de_empresas from cg_empresa  WHERE ccodrucemisor='" + Objet.ruc.Trim() + "'";
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
        public DataTable Cargar_empresacodigo_postgres(string codigo)
        {
            NpgsqlDataReader carga;
            DataTable Grilla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "SELECT CCOD_EMPRESA,NOMEMPRESA AS NOMBRE_DE_EMPRESAS FROM CG_EMPRESA where CCOD_EMPRESA like'%" + codigo + "%'";
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
        public DataTable Cargar_empresadescri_postgres(string empresa)
        {
            NpgsqlDataReader carga;
            DataTable Grilla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "SELECT CCOD_EMPRESA,NOMEMPRESA AS NOMBRE_DE_EMPRESAS FROM CG_EMPRESA where NOMEMPRESA like '%" + empresa + "'%";
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
        public string obtenerempresa_postgres(Clase.empresaPropiedades Objet)
        {
            string cadena1 = "";
            string cadena = "";
            DataTable Tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            try
            {
                string query = "Insert into CG_EMPRESA(ccodrucemisor,CCOD_EMPRESA,NOMEMPRESA) values(" +
                                    "'" + Objet.ruc + "', " +
                                    "'" + Objet.codempresa + "', " +
                                    "'" + Objet.empresa + "')";
                NpgsqlCommand cmdp = new NpgsqlCommand(query, conexion);
                cadena = cmdp.ExecuteNonQuery() == 1 ? "Grabado" : "No se grabo";


            }
            catch (Exception ex1)
            {
                cadena1 = ex1.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
            return cadena;
        }
        public string actualizaremp_postgres(Clase.empresaPropiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            try
            {
                string cadena1 = "update cg_empresa set nomempresa='" + Objet.empresa + "' where ccod_empresa='" + Objet.codempresa + "'";
                NpgsqlCommand cmdp = new NpgsqlCommand(cadena1, conexion);
                cadena = cmdp.ExecuteNonQuery() == 1 ? "Actualizado" : "No se pudo actualizar";
            }
            catch (Exception ex1)
            {
                //MessageBox.Show(ex1.ToString());
                cadena = ex1.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
            return cadena;
        }
        public string eliminaremp_postgres(Clase.empresaPropiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            try
            {
                string cadena1 = "Delete from cg_empresa  where ccod_empresa='" + Objet.codempresa + "'";
                NpgsqlCommand cmdp = new NpgsqlCommand(cadena1, conexion);
                cadena = cmdp.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";
            }
            catch (Exception ex1)
            {
                ///MessageBox.Show(ex1.ToString());
                cadena = ex1.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
            return cadena;
        }

    }

}
