using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;

namespace Contasis
{
    public class Establecerconexion
    {
        private string cadena;
        public string Cadena { get => cadena; set => cadena = value; }
        public void crearCadena(string _cadena)
        {
            cadena = _cadena;
            String str;

            SqlConnection conex = new SqlConnection(cadena);
            try
            {
                conex.Open();
                

                MessageBox.Show("Validando Conexión para Crear Base de Datos y guardar las credenciales.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                /**** ***/
                string rutas = "SELECT top 1 replace(filename,NAME+'.mdf','') as ruta  FROM SYSDATABASES";
                SqlCommand cmd1 = new SqlCommand(rutas, conex);
                {
                    String ruta = (String)cmd1.ExecuteScalar();
                    /***                MessageBox.Show(ruta); **////

                    //**DataTable dt0 = new DataTable();
                    //**SqlDataAdapter da1 = new SqlDataAdapter(cmd1); *//


                    /** aca vamos a Verificar si Existe la tabla Contasis    **/
                    string verifica = "SELECT  * FROM SYSDATABASES WHERE NAME='bdintegradorContasis'";
                    SqlCommand comando = new SqlCommand(verifica, conex);
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(comando);

                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Ya Existe la base de datos <<bdintegradorContasis>>", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;

                        }
                        else
                        {
                            MessageBox.Show("base de datos <<bdintegradorContasis>> sera creada", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            {
                                str = "CREATE DATABASE [bdintegradorContasis] ON PRIMARY " +
                                      " (NAME = N'bdintegradorContasis', " +
                                      " FILENAME = N'" + ruta + "bdintegradorContasisDATA.mdf'," +
                                      "  SIZE = 8192KB, MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB) " +
                                      "  LOG ON(NAME = N'bdintegradorContasis_Log', " +
                                      "  FILENAME = N'" + ruta + "bdintegradorContasisLog.ldf'," +
                                      "  SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )";

                                SqlCommand myCommand = new SqlCommand(str, conex);
                                try
                                {
                                    myCommand.ExecuteNonQuery();
                                    MessageBox.Show("Base de datos ha sido creado <<bdintegradorContasis>>", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    conex.Close();
                                }
                                catch (System.Exception ex)
                                {
                                    MessageBox.Show("No se puede realizar la creación de la base de datos, posible permisos de usuario que se ha logeado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se establecio la conexión por error de credenciales" , "Contasis Corp. error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
}
}

           
        

    
