using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Contasis.Clase
{
    class Inicio
    {
        public string validarbase()
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

                    cadena = "0";
                }
            }
            catch 
            {
                /// MessageBox.Show("No existe la base de datos bdintegradorContasis...", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
