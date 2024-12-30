using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;

namespace Contasis.Clase
{
    class usuario
    {
        
    
    
        public string Insertar(Clase.usuarioPropiedad Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string query0 = "select top 1 right('00000'+ltrim(cast(max(cast(ccodusu as int))+1 as varchar)),5) as codigo from CG_usuario";
                cone = ConexionSql.Instancial().Establecerconexion();
                SqlCommand commando = new SqlCommand(query0, cone);
                cone.Open();
                SqlDataReader leer = commando.ExecuteReader();
                if (leer.Read())
                {
                    if (Convert.ToString(leer["codigo"]) == "")
                    {
                        Objet.codigo = "00001";
                    }
                    else
                    {
                        Objet.codigo = Convert.ToString(leer["codigo"]);
                    }
                    string query = "Insert into CG_usuario(ccodusu,CDESUSU,PASSWORD) values(" +
                        "'" + Objet.codigo + "', " +
                        "'" + Objet.nombre + "', " +
                        "'" + Objet.password + "')";
                    cone = ConexionSql.Instancial().Establecerconexion();
                    SqlCommand commando1 = new SqlCommand(query, cone);
                    cone.Open();
                    cadena = commando1.ExecuteNonQuery() > 0 ? "Grabado" : "No se grabo";
                }

            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
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
        public string Actualizar(Clase.usuarioPropiedad Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "UPDATE CG_usuario SET CDESUSU='" + Objet.nombre + "'," +
                "PASSWORD='" + Objet.password + "' where ccodusu='" + Objet.codigo + "'";
                cone = ConexionSql.Instancial().Establecerconexion();
                SqlCommand commando1 = new SqlCommand(query, cone);
                cone.Open();
                cadena = commando1.ExecuteNonQuery() == 1 ? "Actualizado" : "No se actualizo";
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
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
        public string Eliminar(Clase.usuarioPropiedad Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string cadena1 = "Delete from cg_usuario  where ccodusu='" + Objet.codigo + "'";
                cone = ConexionSql.Instancial().Establecerconexion();
                SqlCommand commando = new SqlCommand(cadena1, cone);
                cone.Open();
                cadena = commando.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
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
        public DataTable accesos(Clase.usuarioPropiedad Objet)
        {
            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT A.CCODMOD as CODIGO,B.CDESMOD AS OPCION,A.FLGACCESO  AS ACCESO FROM CG_USUARIO_ACCESO A " +
                                " INNER JOIN CG_MODULOS B ON A.CCODMOD = B.CCODMOD WHERE ccodusu = '" + Objet.codigo.Trim() + "'";
                cone = ConexionSql.Instancial().Establecerconexion();
                SqlCommand commando = new SqlCommand(query, cone);
                cone.Open();
                carga = commando.ExecuteReader();
                grilla.Load(carga);
                return grilla;
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
    }



    }

