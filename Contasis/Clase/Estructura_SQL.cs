using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Contasis.Clase
{
    class Estructura_SQL
    {
        public string crear_tablas(string NombreTable,string EstrucutraTable)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection coneconexionsql = new SqlConnection();

            try
            {
                string query0 = "SELECT* FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = '"+ NombreTable.Trim().ToLower() + "'";
                coneconexionsql = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(query0, coneconexionsql);
                coneconexionsql.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                { }
                else
                {
                    SqlCommand myCommand = new SqlCommand(EstrucutraTable, coneconexionsql);
                    try
                    {
                        
                        cadena = myCommand.ExecuteNonQuery()> 0 ? "Tabla "+ NombreTable+ " creada." : "No se pudo crear dicha tabla.";
                        FrmCrearTablas.instance.timer1.Enabled = true;
                        coneconexionsql.Close();
                    }
                    catch (System.Exception ex)
                    {
                       //// MessageBox.Show(ex.ToString(), "Contasis Corp.en Ventas", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                }


            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
                cadena = ex1.Message;
            }
            finally
            {
                if (coneconexionsql.State == ConnectionState.Open)
                {
                    coneconexionsql.Close();
                }

            }
            return cadena;
        }
    }
}
