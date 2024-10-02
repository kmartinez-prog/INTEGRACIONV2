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
    //*********************************************************************************************//
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


        public DataTable Cargar(string periodo,string empresa)
        {
            SqlDataReader carga;
            DataTable Grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "Select ID,TIPO AS TIPO_MODULO,Entidad AS ENTIDAD,Ent_anula AS ANULACION_DOC,codtipdocu AS TIP_DOCUMENTO," +
                "cserie AS SERIE,ccodpag AS COD_PAGO,ccodmov AS MOVIMIENTO,ccodvend AS VENDEDOR,ccodalma AS ALMACEN, Prodanula ANULACION_PROD "+
                "From configuracion2 where ccod_empresa = '"+empresa.ToString()+"' and cper='"+periodo+"'";
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
        public DataTable Cargarpostgres(string periodo, string empresa)
        {
            NpgsqlDataReader carga;
            DataTable Grilla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "Select  ID,TIPO AS TIPO_MODULO,Entidad AS ENTIDAD,Ent_anula AS ANULACION_DOC,codtipdocu AS TIP_DOCUMENTO," +
                "cserie AS SERIE,ccodpag AS COD_PAGO,ccodmov AS MOVIMIENTO,ccodvend AS VENDEDOR,ccodalma AS ALMACEN, Prodanula ANULACION_PROD " +
                "From configuracion2 where ccod_empresa = '" + empresa.ToString() + "' and cper='" + periodo + "'";
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
    }
}
