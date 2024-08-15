using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace Contasis
{
    class usuario_postgres
    {
        public string Insertar(Clase.usuarioPropiedad Objet)
        {
            string cadena = "";

            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();


            try
            {
                string query0 = "select lpad((sum(coalesce(ccodusu::int)+1))::character(5),5,'0')::character(5) as codigo  from CG_usuario";
                NpgsqlCommand cmdp = new NpgsqlCommand(query0, conexion);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
                NpgsqlDataReader leer = cmdp.ExecuteReader();
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
                    leer.Close();
                }
                    string query = "Insert into cg_usuario(ccodusu,cdesusu,password) values(" +
                        "'" + Objet.codigo + "', " +
                        "'" + Objet.nombre + "', " +
                        "'" + Objet.password + "')";
                    NpgsqlCommand ejecutor = new NpgsqlCommand(query, conexion);
                   // ejecutor.ExecuteNonQuery();
                   // cadena = "Grabado" ;
                    cadena = ejecutor.ExecuteNonQuery() > 0 ? "Grabado" : "No se grabo";

                    //                    cadena = command3.ExecuteNonQuery().ToString();
                    ///                  MessageBox.Show(cadena);


                    ///0 ? "Grabado" : "No se grabo";
                

            }
            catch (Exception ex1)
            {
               //// cadena = "No se grabo";
                MessageBox.Show("existe un error en los datos que va a grabar.",ex1.ToString()+"Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
        public string Actualizar(Clase.usuarioPropiedad Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "UPDATE CG_usuario SET CDESUSU='" + Objet.nombre + "'," +
                "PASSWORD='" + Objet.password + "' where ccodusu='" + Objet.codigo + "'";
                NpgsqlCommand command3 = new NpgsqlCommand(query, conexion);
                cadena = command3.ExecuteNonQuery() == 1 ? "Actualizado" : "No se actualizo";
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
        public string Eliminar(Clase.usuarioPropiedad Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            try
            {
                string cadena1 = "Delete from cg_usuario  where ccodusu='" + Objet.codigo + "'";
                NpgsqlCommand command3 = new NpgsqlCommand(cadena1, conexion);
                cadena = command3.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";
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
        public DataTable accesos(Clase.usuarioPropiedad Objet)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            NpgsqlDataReader  carga;
            DataTable grilla = new DataTable();


            try
            {
                string query = "SELECT A.CCODMOD as CODIGO,B.CDESMOD AS OPCION,A.FLGACCESO  AS ACCESO FROM CG_USUARIO_ACCESO A " +
                                " INNER JOIN CG_MODULOS B ON A.CCODMOD = B.CCODMOD WHERE ccodusu = '" + Objet.codigo.Trim() + "'";
                NpgsqlCommand cmdp = new NpgsqlCommand(query, conexion);


                carga = cmdp.ExecuteReader();
                grilla.Load(carga);
                return grilla;
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

