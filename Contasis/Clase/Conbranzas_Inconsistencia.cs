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
    class Conbranzas_Inconsistencia
    {
        /*******************************************************************************************************/
        public DataTable listassql(Clase.Cobranzas_propiedades Objet)
        {

            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {


                string query = "SELECT idcobranzapago  as idcobranzas" +
                ", ccod_empresa, convert(varchar(10), ffechacan, 103) as ffechacan, "+
                " isnull(cdoccan, '') as cdoccan,isnull(csercan, '') as csercan, "+
                " isnull(cnumcan, '') as cnumcan,isnull(ccuecan, '') as ccuecan, "+
                " isnull(cmoncan, '') as cmoncan,isnull(nimporcan, 0.00) as nimporcan, "+
                " isnull(ntipcam, 0.00) as ntipcam,isnull(ccodpago, '') as ccodpago, "+
                " isnull(ccoddoc, '') as ccoddoc, isnull(cserie, '') as cserie, "+
                " isnull(cnumero, '') as cnumero,convert(varchar(10), ffechadoc, 103) as ffechadoc, "+
                " convert(varchar, ffechaven, 103) as ffechaven,isnull(ccodenti, '') as ccodenti "+
                ",isnull(ccodruc, '') as ccodruc,isnull(crazsoc, '') as crazsoc, "+
                "isnull(nimportes, 0.00) as nimportes,isnull(nimported, 0.00) as nimported,isnull(ccodcue, '') as ccodcue, "+
                "isnull(cglosa, '') as cglosa "+
                ",isnull(ccodcos, '') as ccodcos,isnull(ccodcos2, '') as ccodcos2,isnull(nporre, 0.00) as nporre, "+
                "isnull(nimpperc, 0.00) as nimpperc,isnull(nperdenre, 0.00) as nperdenre,isnull(cserre, '') as cserre "+
                ",isnull(cnumre, '') as cnumre,convert(varchar, ffecre, 103) as ffecre,obserror "+
                "FROM fin_cobranzapago with(nolock) where ntipocobpag= 1 and  "+
                "es_con_migracion = 2  and ccodrucemisor='" + Objet.Ruc.Trim() + "' and ccod_empresa='" + Objet.Empresa.Trim() + "'";
                cone = ConexionSql.Instancial().establecerconexion();
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
        public DataTable listaspos(Clase.Cobranzas_propiedades Objet)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            NpgsqlDataReader carga;
            DataTable grilla = new DataTable();
            ;
            try
            {
                string query = "select  " +
    "idcobranzas,  ccod_empresa,   " +
    "to_char(ffechacan,'dd/mm/yyyy')::char(10) as ffechacan,  " +
    "cdoccan, csercan, cnumcan, ccuecan, cmoncan, nimporcan, ntipcam, ccodpago, ccoddoc, cserie,   " +
    "cnumero, ffechadoc, ffechaven, ccodenti, ccodruc, crazsoc, nimportes, nimported, ccodcue,   " +
    "cglosa, ccodcos, ccodcos2, nporre, nimpperc, nperdenre, cserre, cnumre, ffecre, obserror  " +
    "from fin_cobranzapago  " +
    "where es_con_migracion =2 and ccodrucemisor='" + Objet.Ruc.Trim() + "' and ccod_empresa='" + Objet.Empresa.Trim() + "'";
                NpgsqlCommand commando = new NpgsqlCommand(query, conexion);
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
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
        }
        public string eliminarsql(Clase.Cobranzas_propiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string cadena1 = "Delete from fin_cobranzapago  where idcobranzapago=" + Objet.Idcobranzas + "";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(cadena1, cone);
                cone.Open();
                cadena = commando.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";
            }
            catch (Exception ex1)
            {
                ///MessageBox.Show(ex1.ToString());
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
        public string eliminarpos(Clase.Cobranzas_propiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            try
            {
                string cadena1 = "Delete from fin_cobranzapago  where idcobranzas=" + Objet.Idcobranzas + "";
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
        public string Actualizarsql(Clase.Cobranzas_propiedades Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update  fin_cobranzapago  SET Ccuecan='" + Objet.Ccuecan.Trim() + "',Ccodcue='" + Objet.Ccodcue.Trim() + "'," +
                                  "Nimportes=" + Objet.Nimportes + ",Nimported=" + Objet.Nimported + ",ccodcos='" + Objet.Ccodcos.Trim() + "'," +
                                  "ccodcos2='" + Objet.Ccodcos2.Trim() + "',obserror='',es_con_migracion=0 where idcobranzapago=" + Objet.Idcobranzas + "";
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
        public string Actualizarpos(Clase.Cobranzas_propiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update  fin_cobranzapago  SET Ccuecan='" + Objet.Ccuecan.Trim() + "',Ccodcue='" + Objet.Ccodcue.Trim() + "'," +
                                  "Nimportes=" + Objet.Nimportes + ",Nimported=" + Objet.Nimported + ",ccodcos='" + Objet.Ccodcos.Trim() + "'," +
                                  "ccodcos2='" + Objet.Ccodcos2.Trim() + "',obserror='',es_con_migracion=0 where idcobranzas=" + Objet.Idcobranzas + "";
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
        /*******************************************************************************************************/
        public DataTable listascombosql(Clase.Cobranzas_propiedades Objet)
        {
            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT idcobranzapago  "+
                ", ccod_empresa, convert(varchar(10), ffechacan, 103) as ffechacan,  "+
                "isnull(cdoccan, '') as cdoccan,isnull(csercan, '') as csercan,  " +
                "isnull(cnumcan, '') as cnumcan,isnull(ccuecan, '') as ccuecan,  " +
                "isnull(cmoncan, '') as cmoncan,isnull(nimporcan, 0.00) as nimporcan,  " +
                "isnull(ntipcam, 0.00) as ntipcam,isnull(ccodpago, '') as ccodpago,  " +
                "isnull(ccoddoc, '') as ccoddoc, isnull(cserie, '') as cserie,  " +
                "isnull(cnumero, '') as cnumero,convert(varchar(10), ffechadoc, 103) as ffechadoc,  " +
                "convert(varchar, ffechaven, 103) as ffechaven,isnull(ccodenti, '') as ccodenti  " +
                ",isnull(ccodruc, '') as ccodruc,isnull(crazsoc, '') as crazsoc,  " +
                "isnull(nimportes, 0.00) as nimportes,isnull(nimported, 0.00) as nimported,isnull(ccodcue, '') as ccodcue,  " +
                "isnull(cglosa, '') as cglosa  " +
                ",isnull(ccodcos, '') as ccodcos,isnull(ccodcos2, '') as ccodcos2,isnull(nporre, 0.00) as nporre,  " +
                "isnull(nimpperc, 0.00) as nimpperc,isnull(nperdenre, 0.00) as nperdenre,isnull(cserre, '') as cserre  " +
                ",isnull(cnumre, '') as cnumre,convert(varchar, ffecre, 103) as ffecre,resultado_migracion,convert(varchar(900), obserror) as obserror " +
                "FROM fin_cobranzapago with(nolock) where ntipocobpag= 1 and " +
                "es_con_migracion =2 and " +
                "ccodrucemisor='" + Objet.Ruc.Trim() + "' and ccod_empresa='" + Objet.Empresa.Trim() + "' and convert(varchar(900),obserror) ='" + Objet.Estado.Trim() + "'";
                cone = ConexionSql.Instancial().establecerconexion();
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
        public DataTable listascombopos(Clase.Cobranzas_propiedades Objet)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            NpgsqlDataReader carga;
            DataTable grilla = new DataTable();
            ;
            try
            {
                string query = "select  " +
    "idcobranzas,  ccod_empresa,   " +
    "to_char(ffechacan,'dd/mm/yyyy')::char(10) as ffechacan,  " +
    "cdoccan, csercan, cnumcan, ccuecan, cmoncan, nimporcan, ntipcam, ccodpago, ccoddoc, cserie,   " +
    "cnumero, ffechadoc, ffechaven, ccodenti, ccodruc, crazsoc, nimportes, nimported, ccodcue,   " +
    "cglosa, ccodcos, ccodcos2, nporre, nimpperc, nperdenre, cserre, cnumre, ffecre, obserror  " +
    "from fin_cobranzapago  " +
    "where es_con_migracion =2 "+
      " ccodrucemisor='" + Objet.Ruc.Trim() + "' and ccod_empresa='" + Objet.Empresa.Trim() + "' and obserror='" + Objet.Estado.Trim() + "'";
                NpgsqlCommand commando = new NpgsqlCommand(query, conexion);
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
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
        }
        /*******************************************************************************************************/
        public string Actualizarmasivosql(Clase.Cobranzas_propiedades Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update  fin_cobranzapago  SET obserror='',es_con_migracion=0 where idcobranzapago=" + Objet.Idcobranzas + "";
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
        public string Actualizarmasivopos(Clase.Cobranzas_propiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update  fin_cobranzapago  SET obserror='',es_con_migracion=0 where idcobranzas=" + Objet.Idcobranzas + "";
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
        /*******************************************************************************************************/
        public void ActualizaEstadoSQL(Clase.Cobranzas_propiedades Objet)
        {
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update  fin_cobranzapago  SET es_con_migracion=2  " +
                               "where  es_con_migracion=0 and  convert(char(900),obserror)<>''  and  " + 
                               " ccodrucemisor = '" + Objet.Ruc.Trim() + "' and ccod_empresa = '" + Objet.Empresa.Trim() + "'";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando1 = new SqlCommand(query, cone);
                cone.Open();
                commando1.ExecuteNonQuery();
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

        }
        public void ActualizaEstadoPOS(Clase.Cobranzas_propiedades Objet)
        {

            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update  fin_cobranzapago  SET es_con_migracion=2  where es_con_migracion=0 and obserror<>''  and  ccodrucemisor = '" + Objet.Ruc.Trim() + "' and ccod_empresa = '" + Objet.Empresa.Trim() + "'";
                NpgsqlCommand command3 = new NpgsqlCommand(query, conexion);
                command3.ExecuteNonQuery();

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
        }
        /***********************************************************************************************************/



    }
}
