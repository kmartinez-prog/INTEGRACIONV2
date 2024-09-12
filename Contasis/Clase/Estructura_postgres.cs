using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Npgsql;


namespace Contasis.Clase
{
    class Estructura_postgres
    {
        public string crear_tablas(string NombreTable, string Estructura)
        {
            string cadena = "";
            int cadena1 = 0;

            DataTable Tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();


            try
            {
                string query = "SELECT * FROM INFORMATION_SCHEMA.columns where TABLE_NAME = '" + NombreTable.Trim().ToLower() + "'";
                NpgsqlCommand commando = new NpgsqlCommand(query, conexion);
               

                DataTable dt = new DataTable();
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cadena = "Tabla " + NombreTable.Trim().ToLower().ToString() + " ya existe.";
                }
                else
                {
                    NpgsqlCommand myCommand = new NpgsqlCommand(Estructura, conexion);
                    try
                    {
                        cadena1 = myCommand.ExecuteNonQuery();
                        if (cadena1 < 0)
                        {
                            cadena = "Tabla " + NombreTable + " creada.";

                        }
                        else
                        {
                            cadena = "No se puedo crear la tabla : " + NombreTable;
                        }
                        //// FrmCrearTablas.instance.timer1.Enabled = true;
                        conexion.Close();
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
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
            return cadena;
        }

        public string crear_funcion(string NombreSp, string EstructuraSp)
        {
            string cadena = "";
            int cadena1 = 0;

            DataTable Tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            try
            {
                string query = "SELECT routine_name  FROM information_schema.routines where routine_type='FUNCTION' and specific_schema ='public' and routine_name='" + NombreSp.Trim().ToLower() + "'";
                NpgsqlCommand commando = new NpgsqlCommand(query, conexion);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //// aca primero elimino el SP ///
                    string consulta;
                    consulta = "Drop function " + NombreSp.Trim().ToLower().ToString()+";";
                    NpgsqlCommand commando1 = new NpgsqlCommand(query, conexion);
                    commando1.ExecuteNonQuery();
                    //// aca luego se vuelve a crear con los nuevos Cambios ///

                    NpgsqlCommand commando2 = new NpgsqlCommand(EstructuraSp, conexion);

                    commando2.ExecuteNonQuery();
                    cadena = "Función " + NombreSp.Trim().ToLower().ToString() + " ha sido actualizado.";
                }
                else
                {
                    NpgsqlCommand commando2 = new NpgsqlCommand(EstructuraSp, conexion);
                    try
                    {
                        cadena1 = commando2.ExecuteNonQuery();
                        if (cadena1 < 0)
                        {
                            cadena = "Funcóon " + NombreSp.Trim().ToLower().ToString() + " ha sido creado.";
                        }
                        else
                        {
                            cadena = "No se puedo crear esta función : " + NombreSp;
                        }
                        //// FrmCrearTablas.instance.timer1.Enabled = true;
                        conexion.Close();
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
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
            return cadena;
        }

        public string crear_Campos_nuevos_en_tablas(string NombreTable, string Nombrecampo, string campolargo)
        {
            string cadena = "";
            int cadena1 = 0;

            DataTable Tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();


            try
            {
                string query = "select *  from information_schema.columns where table_schema='public' and table_name='" + NombreTable.Trim().ToLower() + "' and column_name='" + Nombrecampo.Trim().ToLower() + "';";
                NpgsqlCommand commando = new NpgsqlCommand(query, conexion);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                { }
                else
                {
                    NpgsqlCommand myCommand = new NpgsqlCommand(campolargo, conexion);
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
                        conexion.Close();
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
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
            return cadena;
        }

    }
}
