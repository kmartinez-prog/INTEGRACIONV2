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
    class ruc
    {
        public string Insertar(Clase.rucpropiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string query0 = "select ccodrucemisor as  ruc  from cg_empemisor  where ccodrucemisor='" + Objet.ruc + "'";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(query0, cone);
                cone.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                { }
                else
                    {

                        string query = "Insert into cg_empemisor(ccodrucemisor,cdesrucemisor,flgactivo) values(" +
                            "'" + Objet.ruc + "', " +
                            "'" + Objet.empresa + "', " +
                            "'" + Objet.estado + "')";
                        cone = ConexionSql.Instancial().establecerconexion();
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
        public string Actualizar(Clase.rucpropiedades Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update  cg_empemisor SET cdesrucemisor='" + Objet.empresa + "'," +
                "flgactivo='" + Objet.estado + "' where ccodrucemisor='" + Objet.ruc + "'";
                cone = ConexionSql.Instancial().establecerconexion();
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
        public string Eliminar(Clase.rucpropiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string cadena1 = "Delete from cg_empemisor  where ccodrucemisor='" + Objet.ruc + "'";
                cone = ConexionSql.Instancial().establecerconexion();
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
    }
}
