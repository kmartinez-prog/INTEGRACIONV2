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
    class Compras_inconsistencias
    {
        /*******************************************************************************************************/
        public DataTable listassql(Clase.Compras_propiedadescs Objet)
        {
            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT idcompras,  ccod_empresa, "+
                "convert(varchar, ffechadoc, 103) as ffechadoc, " +
                "convert(varchar, fechaven, 103) as fechaven, " +
                "ccoddoc, ccoddas, cyeardas, cserie, cnumero,   " +
                "ctipdoc, ccodruc, crazsoc, ccodclas, nbase1, " +
                "nigv1,  nbase2, nigv2, nbase3, nigv3, nina,  " +
                "nisc, nicbper, nexo, ntots,  " +
                "cdocnodom, cnumdere,  " +
                "convert(varchar, ffecre, 103) as ffecre, " +
                "ntc,convert(varchar, freffec, 103) as freffec, " +
                "crefdoc, crefser,crefnum, cmreg, ndolar,  " +
                "convert(varchar, ffechaven2, 103) as ffechaven2, " +
                "ccond, cctabase, cctaicbper,cctaotrib, cctatot, ccodcos, ccodcos2,  " +
                "nresp, nporre, nimpres,cserre, cnumre,  " +
                "convert(varchar, ffecre2, 103) as ffecre2, " +
                "ccodpresu, nigv,  nperdenre,  " +
                "nbaseres, cigvxacre, obserror " +
                "  FROM fin_compras where es_con_migracion=2 and ccodrucemisor='" + Objet.ruc.Trim() + "' and ccod_empresa='" + Objet.empresa.Trim() + "'";
                cone = ConexionSql.Instancial().Establecerconexion();
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
        public DataTable listaspos(Clase.Compras_propiedadescs Objet)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            NpgsqlDataReader carga;
            DataTable grilla = new DataTable();
            ;
            try
            {
                string query = "SELECT idcompras,  ccod_empresa, to_char(ffechadoc,'dd/mm/yyyy')::char(10) as ffechadoc, " +
                "to_char(fechaven, 'dd/mm/yyyy')::char(10) as fechaven, " +
                "ccoddoc, ccoddas, cyeardas, cserie, cnumero,   " +
                "ctipdoc, ccodruc, crazsoc, ccodclas, nbase1, " +
                "nigv1,  nbase2, nigv2, nbase3, nigv3, nina,  " +
                "nisc, nicbper, nexo, ntots,  " +
                "cdocnodom, cnumdere,  " +
                "to_char(ffecre, 'dd/mm/yyyy')::char(10) as ffecre, " +
                "ntc,to_char(freffec, 'dd/mm/yyyy')::char(10) as freffec, " +
                "crefdoc, crefser,crefnum, cmreg, ndolar,  " +
                "to_char(ffechaven2, 'dd/mm/yyyy')::char(10) as ffechaven2, " +
                "ccond, cctabase, cctaicbper,cctaotrib, cctatot, ccodcos, ccodcos2,  " +
                "nresp, nporre, nimpres,cserre, cnumre,  " +
                "to_char(ffecre2, 'dd/mm/yyyy')::char(10) as ffecre2, " +
                "ccodpresu, nigv,  nperdenre,  " +
                "nbaseres, cigvxacre, obserror  " +
                "  FROM fin_compras where es_con_migracion=2 and ccodrucemisor='" + Objet.ruc.Trim() + "' and ccod_empresa='" + Objet.empresa.Trim() + "'";
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
        public string eliminarsql(Clase.Compras_propiedadescs Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();

            try
            {
                string cadena1 = "Delete from FIN_COMPRAS  where idcompras=" + Objet.idcompras + "";
                cone = ConexionSql.Instancial().Establecerconexion();
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
        public string eliminarpos(Clase.Compras_propiedadescs Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            try
            {
                string cadena1 = "Delete from fin_compras  where idcompras=" + Objet.idcompras + "";
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
        /*******************************************************************************************************/
        public string Actualizarsql(Clase.Compras_propiedadescs Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update  fin_compras  SET cmreg='" + Objet.cmreg.Trim() + "',ccond='" + Objet.ccond.ToUpper().Trim() + "'," +
                                   "cctabase='"   + Objet.cctabase.Trim() + "',cctatot ='" + Objet.cctatot.Trim() +
                                   "',ccodcos='"  + Objet.ccodcos.Trim() + "',ccodcos2='" + Objet.ccodcos2.Trim() + 
                                   "',ccodpresu='" + Objet.ccodpresu.Trim() + "',obserror='', es_con_migracion = 0  where idcompras=" + Objet.idcompras + "";
                cone = ConexionSql.Instancial().Establecerconexion();
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
        public string Actualizarpos(Clase.Compras_propiedadescs Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update  fin_compras  SET cmreg='" + Objet.cmreg.Trim() + "',ccond='" + Objet.ccond.ToUpper().Trim() + "'," +
                                   "cctabase='" + Objet.cctabase.Trim() + "',cctatot ='" + Objet.cctatot.Trim() +
                                   "',ccodcos='" + Objet.ccodcos.Trim() + "',ccodcos2='" + Objet.ccodcos2.Trim() +
                                   "',ccodpresu='" + Objet.ccodpresu.Trim() + "',obserror='', es_con_migracion = 0  where idcompras=" + Objet.idcompras + "";
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
        public DataTable listascombosql(Clase.Compras_propiedadescs Objet)
        {
            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT idcompras,  ccod_empresa, " +
                 "convert(varchar, ffechadoc, 103) as ffechadoc, " +
                 "convert(varchar, fechaven, 103) as fechaven, " +
                 "ccoddoc, ccoddas, cyeardas, cserie, cnumero,   " +
                 "ctipdoc, ccodruc, crazsoc, ccodclas, nbase1, " +
                 "nigv1,  nbase2, nigv2, nbase3, nigv3, nina,  " +
                 "nisc, nicbper, nexo, ntots,  " +
                 "cdocnodom, cnumdere,  " +
                 "convert(varchar, ffecre, 103) as ffecre, " +
                 "ntc,convert(varchar, freffec, 103) as freffec, " +
                 "crefdoc, crefser,crefnum, cmreg, ndolar,  " +
                 "convert(varchar, ffechaven2, 103) as ffechaven2, " +
                 "ccond, cctabase, cctaicbper,cctaotrib, cctatot, ccodcos, ccodcos2,  " +
                 "nresp, nporre, nimpres,cserre, cnumre,  " +
                 "convert(varchar, ffecre2, 103) as ffecre2, " +
                 "ccodpresu, nigv,  nperdenre,  " +
                 "nbaseres, cigvxacre, obserror " +
                 "FROM fin_compras  " +
                 " Where es_con_migracion=2 and " +
                 "  ccodrucemisor='" + Objet.ruc.Trim() + "' and ccod_empresa='" + Objet.empresa.Trim() + "' and obserror='" + Objet.estado.Trim() + "'";
                cone = ConexionSql.Instancial().Establecerconexion();
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
        public DataTable listascombopos(Clase.Compras_propiedadescs Objet)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            NpgsqlDataReader carga;
            DataTable grilla = new DataTable();
            ;
            try
            {
                string query = "SELECT idcompras,  ccod_empresa, to_char(ffechadoc, 'dd/mm/yyyy')::char(10) as ffechadoc," +
                "to_char(fechaven, 'dd/mm/yyyy')::char(10) as fechaven," +
                "ccoddoc, ccoddas, cyeardas, cserie, cnumero,  " +
                "ctipdoc, ccodruc, crazsoc, ccodclas, nbase1," +
                "nigv1,  nbase2, nigv2, nbase3, nigv3, nina, " +
                "nisc, nicbper, nexo, ntots, " +
                "cdocnodom, cnumdere, " +
                "to_char(ffecre, 'dd/mm/yyyy')::char(10) as ffecre," +
                "ntc,to_char(freffec, 'dd/mm/yyyy')::char(10) as freffec," +
                "crefdoc, crefser,crefnum, cmreg, ndolar, " +
                "to_char(ffechaven2, 'dd/mm/yyyy')::char(10) as ffechaven2," +
                "ccond, cctabase, cctaicbper,cctaotrib, cctatot, ccodcos, ccodcos2, " +
                "nresp, nporre, nimpres,cserre, cnumre, " +
                "to_char(ffecre2, 'dd/mm/yyyy')::char(10) as ffecre2," +
                "ccodpresu, nigv,  nperdenre, " +
                "nbaseres, cigvxacre, obserror" +
                " FROM fin_compras "+
                " where es_con_migracion=2 and " +
                "  ccodrucemisor='" + Objet.ruc.Trim() + "' and ccod_empresa='" + Objet.empresa.Trim() + "' and obserror='" + Objet.estado.Trim() + "'";
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
        public string Actualizarmasivosql(Clase.Compras_propiedadescs Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update  fin_compras  SET obserror='',es_con_migracion=0 where idcompras=" + Objet.vidcompras + "";
                cone = ConexionSql.Instancial().Establecerconexion();
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
        public string Actualizarmasivopos(Clase.Compras_propiedadescs Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update  fin_compras  SET obserror='',es_con_migracion=0 where idcompras=" + Objet.vidcompras + "";
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
        public void ActualizaEstadoSQL(Clase.Compras_propiedadescs Objet)
        {

            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update fin_compras  SET es_con_migracion=2  where  obserror like '%-error-%' and  convert(char(900),obserror)<>''  and  ccodrucemisor = '" + Objet.ruc.Trim() + "' and ccod_empresa = '" + Objet.empresa.Trim() + "'";
                cone = ConexionSql.Instancial().Establecerconexion();
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
        public void ActualizaEstadoPOS(Clase.Compras_propiedadescs Objet)
        {

            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update  fin_compras  SET es_con_migracion=2  where  obserror like '%-error-%' and  obserror<>''  and  ccodrucemisor = '" + Objet.ruc.Trim() + "' and ccod_empresa = '" + Objet.empresa.Trim() + "'";
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



    }
}
