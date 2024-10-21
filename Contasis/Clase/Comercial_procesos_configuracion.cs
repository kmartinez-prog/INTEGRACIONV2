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
    class Comercial_procesos_configuracion
    {
    //*************Procesos de configuracion de comercial *************************//
        public string comer_insert(Clase.Configuracion_comercial Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();
            
            try
            {
                string query = "INSERT INTO configuracion2(ccod_empresa " +
                ", cper, crazemp, crucemp, Entidad, Tipo, codtipdocu, cserie, ccodmov, ccodpag, ccodvend, "+
                "ccodalma, Ent_anula, Prodanula) " +
                "VALUES('" + Objet.Ccod_empresa + "', " +
                    "'" + Objet.Cper + "','" + Objet.Crazemp + "','" + Objet.Crucemp + "','" + Objet.Entidad + "','" + Objet.Tipo + "','" + Objet.Codtipdocu + "'," +
                    "'" + Objet.Cserie + "','" + Objet.Ccodmov + "','" + Objet.Ccodpag + "','" + Objet.Ccodvend + "','" + Objet.Ccodalma + "','" + Objet.Ent_anula + "'," +
                    "'" + Objet.Prodanula + "')";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando1 = new SqlCommand(query, cone);
                cone.Open();
                cadena = commando1.ExecuteNonQuery() > 0 ? "Grabado" : "No se grabo";
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());

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
        public string comer_insert_postgres(Clase.Configuracion_comercial Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "INSERT INTO configuracion2(ccod_empresa " +
                ", cper, crazemp, crucemp, Entidad, Tipo, codtipdocu, cserie, ccodmov, ccodpag, ccodvend, " +
                "ccodalma, Ent_anula, Prodanula) " +
                "VALUES('" + Objet.Ccod_empresa + "', " +
                    "'" + Objet.Cper + "','" + Objet.Crazemp + "','" + Objet.Crucemp + "','" + Objet.Entidad + "','" + Objet.Tipo + "','" + Objet.Codtipdocu + "'," +
                    "'" + Objet.Cserie + "','" + Objet.Ccodmov + "','" + Objet.Ccodpag + "','" + Objet.Ccodvend + "','" + Objet.Ccodalma + "','" + Objet.Ent_anula + "'," +
                    "'" + Objet.Prodanula + "')";
                NpgsqlCommand cmdp = new NpgsqlCommand(query, conexion);
                cadena = cmdp.ExecuteNonQuery() > 0 ? "Grabado" : "No se grabo";
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());

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
        public DataTable Cargar(string periodo,string empresa,string modulo)
        {
            SqlDataReader carga;
            DataTable Grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "Select ID,TIPO AS TIPO_OPERACION,Entidad AS CODIGO_ENTIDAD,Ent_anula AS CODIGO_ANULACION,codtipdocu AS TIPO_DOCUMENTO,cserie AS SERIES," +
                               "ccodpag AS CODIGO_PAGO,ccodmov AS TIPO_MOVIMIENTO,ccodvend AS CODIGO_VENDEDOR,ccodalma AS CODIGO_ALMACEN, Prodanula AS CODIGO_ANULACION_PRODUCTO " +
                               "From configuracion2 " +
                               " where ccod_empresa = '"+empresa.ToString()+"' and cper='"+periodo+ "' and TIPO='"+modulo+"'";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(query, cone);
                DataTable dt = new DataTable();
                cone.Open();
                carga = commando.ExecuteReader();
                Grilla.Load(carga);
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                }
                else
                {
                    MessageBox.Show("No existe configuración para el periodo que ha seleccionado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
        public DataTable Cargarpostgres(string periodo, string empresa,string modulo)
        {
            NpgsqlDataReader carga;
            DataTable Grilla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "Select ID,TIPO AS TIPO_OPERACION,Entidad AS CODIGO_ENTIDAD,Ent_anula AS CODIGO_ANULACION,codtipdocu AS TIPO_DOCUMENTO,cserie AS SERIES," +
                               "ccodpag AS CODIGO_PAGO,ccodmov AS TIPO_MOVIMIENTO,ccodvend AS CODIGO_VENDEDOR,ccodalma AS CODIGO_ALMACEN, Prodanula AS CODIGO_ANULACION_PRODUCTO " +
                               "From configuracion2 " +
                               " where ccod_empresa = '" + empresa.ToString() + "' and cper='" + periodo + "' and TIPO='" + modulo + "'";
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
        //*********************************************************************************************//
        public string verifica_movimientosql(string movimiento,string tipo,string periodo)
        {
            string aviso;
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "Select * From configuracion2 " +
                               "  where ccodmov='" + movimiento.ToString() + "' and tipo='" + tipo.ToString() + "' and cper='" + periodo.ToString() + "'";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(query, cone);
                DataTable dt = new DataTable();
                cone.Open();
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0){
                    aviso= "1";
                }
                else {
                    ////MessageBox.Show("No existe configuración para el periodo que ha seleccionado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    aviso = "0";
                }
                return aviso;

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
        public string verifica_movimientopossql(string movimiento, string tipo, string periodo)
        {
            string aviso;
                      
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "Select * From configuracion2 " +
                       "  where ccodmov='" + movimiento.ToString() + "' and tipo='" + tipo.ToString() + "' and cper='" + periodo.ToString() + "'";
                NpgsqlCommand cmdp = new NpgsqlCommand(query, conexion);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    aviso = "1";
                }
                else
                {
                  ///  MessageBox.Show("No existe configuración para el periodo que ha seleccionado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    aviso = "0";
                }
                return aviso;
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

        //*********************************************************************************************//
        public string eliminar_movimientosql(string id)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "delete From configuracion2 " +
                               "  where id=" + id + "";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando1 = new SqlCommand(query, cone);
                cone.Open();
                cadena = commando1.ExecuteNonQuery() > 0 ? "Eliminado" : "No se elimino";
               
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());

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
        public string eliminar_movimientopossql(string id)
        {
            string cadena = "";

            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "delete From configuracion2 " +
                               "  where id=" + id + "";
                NpgsqlCommand cmdp = new NpgsqlCommand(query, conexion);
                cadena = cmdp.ExecuteNonQuery() > 0 ? "Eliminado" : "No se elimino";
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());

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
        //********************************************************************************************//
        public string comer_actualizar(Clase.Configuracion_comercial Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string query = "update configuracion2 set Entidad='" + Objet.Entidad.Trim() + "'," +
                               "Tipo ='" + Objet.Tipo.Trim() + "'," +
                               "codtipdocu ='" + Objet.Codtipdocu.Trim() + "'," +
                               "cserie ='" + Objet.Cserie.Trim() + "'," +
                               "ccodpag ='" + Objet.Ccodpag.Trim() + "'," +
                               "ccodvend ='" + Objet.Ccodvend.Trim() + "'," +
                               "ccodalma ='" + Objet.Ccodalma.Trim() + "'," +
                               "Ent_anula ='" + Objet.Ent_anula.Trim() + "'," +
                               "Prodanula ='" + Objet.Prodanula.Trim() + "' where ccod_empresa ='" + Objet.Ccod_empresa.Trim() + "' and crucemp='" +
                               Objet.Crucemp.Trim() + "' and cper ='" + Objet.Cper.Trim() + "' and ccodmov ='" + Objet.Ccodmov.Trim() + "';";
                cone = ConexionSql.Instancial().establecerconexion();
               //// MessageBox.Show(query);
                SqlCommand commando1 = new SqlCommand(query, cone);
                cone.Open();
                cadena = commando1.ExecuteNonQuery() > 0 ? "Actualizado" : "No se actualizo";
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());

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
        public string comer_actualizarpostgres(Clase.Configuracion_comercial Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update configuracion2 set Entidad='" + Objet.Entidad.Trim() + "'," +
                                "Tipo ='" + Objet.Tipo.Trim() + "'," +
                                "codtipdocu ='" + Objet.Codtipdocu.Trim() + "'," +
                                "cserie ='" + Objet.Cserie.Trim() + "'," +
                                "ccodpag ='" + Objet.Ccodpag.Trim() + "'," +
                                "ccodvend ='" + Objet.Ccodvend.Trim() + "'," +
                                "ccodalma ='" + Objet.Ccodalma.Trim() + "'," +
                                "Ent_anula ='" + Objet.Ent_anula.Trim() + "'," +
                                "Prodanula ='" + Objet.Prodanula.Trim() + "' where ccod_empresa ='" + Objet.Ccod_empresa.Trim() + "' and crucemp='" +
                                Objet.Crucemp.Trim() + "' and cper ='" + Objet.Cper.Trim() + "' and ccodmov ='" + Objet.Ccodmov.Trim() + "';";
                NpgsqlCommand cmdp = new NpgsqlCommand(query, conexion);
                cadena = cmdp.ExecuteNonQuery() > 0 ? "Actualizado" : "No se actualizo";
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());

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
