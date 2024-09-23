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
        public string crear_tablas(string NombreTable,string Estructura)
        {
            string cadena = "";
            int cadena1 = 0;

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
                {
                    cadena = "Tabla " + NombreTable.Trim().ToLower().ToString() + " ya existe.";
                    
                }
                else
                {
                    SqlCommand myCommand = new SqlCommand(Estructura, coneconexionsql);
                    try
                    {
                        cadena1 = myCommand.ExecuteNonQuery();
                        if (cadena1 < 0)
                        {
                            cadena = "Tabla "+ NombreTable+ " creada.";

                        }
                        else
                        {
                            cadena = "No se puedo crear la tabla : " + NombreTable;
                        }
                       //// FrmCrearTablas.instance.timer1.Enabled = true;
                        coneconexionsql.Close();
                    }
                    catch 
                    {
                        //// (System.Exception ex)MessageBox.Show(ex.ToString(), "Contasis Corp.en Ventas", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
        public string crear_types(string NombreTable, string Estructura)
        {
            string cadena = "";
            int cadena1 = 0;

            DataTable Tabla = new DataTable();
            SqlConnection coneconexionsql = new SqlConnection();

            try
            {
                string query0 = "Select * from sys.Types where name = '" + NombreTable.Trim().ToLower() + "'";
                coneconexionsql = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(query0, coneconexionsql);
                coneconexionsql.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cadena = "Tabla Types  " + NombreTable.Trim().ToLower().ToString() + " ya existe.";

                }
                else
                {
                    SqlCommand myCommand = new SqlCommand(Estructura, coneconexionsql);
                    try
                    {
                        cadena1 = myCommand.ExecuteNonQuery();
                        if (cadena1 < 0)
                        {
                            cadena = "Tabla  Types" + NombreTable + " creada.";

                        }
                        else
                        {
                            cadena = "No se puedo crear la tabla  Types: " + NombreTable;
                        }
                        //// FrmCrearTablas.instance.timer1.Enabled = true;
                        coneconexionsql.Close();
                    }
                    catch
                    {
                        //// (System.Exception ex)MessageBox.Show(ex.ToString(), "Contasis Corp.en Ventas", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
        public string crear_procedimiento(string NombreSp, string EstructuraSp)
        {
            string cadena = "";
            int cadena1 = 0;

            DataTable Tabla = new DataTable();
            SqlConnection coneconexionsql = new SqlConnection();

            try
            {
                string query0 = "Select NAME  From Sys.objects where type='P' and  lower(NAME) = '" + NombreSp.Trim().ToLower() + "'";
                coneconexionsql = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(query0, coneconexionsql);
                coneconexionsql.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //// aca primero elimino el SP ///
                    string consulta;
                    consulta = "Drop Procedure " + NombreSp.Trim().ToLower().ToString();
                    SqlCommand myCommand = new SqlCommand(consulta, coneconexionsql);
                    myCommand.ExecuteNonQuery();
                    //// aca luego se vuelve a crear con los nuevos Cambios ///
                    SqlCommand myCommand1 = new SqlCommand(EstructuraSp, coneconexionsql);
                    myCommand1.ExecuteNonQuery();
                    cadena = "Procedimiento " + NombreSp.Trim().ToLower().ToString() + " ha sido actualizado.";
                }
                else
                {
                    SqlCommand myCommand2 = new SqlCommand(EstructuraSp, coneconexionsql);
                    try
                    {
                        cadena1 = myCommand2.ExecuteNonQuery();
                        if (cadena1 < 0)
                        {
                            cadena = "Procedimiento " + NombreSp.Trim().ToLower().ToString() + " ha sido creado.";
                        }
                        else
                        {
                            cadena = "No se puedo crear este procedimiento : " + NombreSp;
                        }
                        //// FrmCrearTablas.instance.timer1.Enabled = true;
                        coneconexionsql.Close();
                    }
                    catch 
                    {
                        ////(System.Exception ex) MessageBox.Show(ex.ToString(), "Contasis Corp.en Ventas", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
        public string crear_Campos_nuevos_en_tablas(string NombreTable,string Nombrecampo ,string campolargo)
        {
            string cadena = "";
            int cadena1 = 0;

            DataTable Tabla = new DataTable();
            SqlConnection coneconexionsql = new SqlConnection();

            try
            {
                string query0 = "SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS " +
                                " where TABLE_NAME ='" + NombreTable.Trim().ToLower() + "' AND COLUMN_NAME = '" + Nombrecampo.Trim().ToLower() + "'";
                coneconexionsql = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(query0, coneconexionsql);
                coneconexionsql.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {   }
                else
                {
                    SqlCommand myCommand = new SqlCommand(campolargo, coneconexionsql);
                    try
                    {
                        cadena1 = myCommand.ExecuteNonQuery();
                        if (cadena1 < 0)
                        {
                            cadena = "se adicional en la tabla " + NombreTable + " el campo " + Nombrecampo;

                        }
                        else
                        {
                            cadena = "No se puedo adicional el campo";
                        }
                        //// FrmCrearTablas.instance.timer1.Enabled = true;
                        coneconexionsql.Close();
                    }
                    catch 
                    {
                        ////(System.Exception ex) MessageBox.Show(ex.ToString(), "Contasis Corp.en Ventas", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
