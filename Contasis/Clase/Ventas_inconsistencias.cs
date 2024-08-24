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
    class Ventas_inconsistencias
    {
        
        /*******************************************************************************************************/
        public DataTable listassql(Clase.ventas_propiedades Objet)
        {
            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT  0 as MARCA ,idventas"+
                ", ccod_empresa, convert(varchar,ffechadoc,103) as ffechadoc, convert(varchar,[ffechaven],103) as ffechaven, ccoddoc" +
                ", cserie, cnumero, ccodenti, cdesenti " +
                ", ctipdoc, ccodruc, crazsoc, nbase2, nbase1 " +
                ", nexo, nina, nisc, nigv1, nicbpers, nbase3 " +
                ", ntots, ntc, convert(varchar,freffec,103) as freffec, crefdoc, crefser, crefnum " +
                ", cmreg, ndolar, convert(varchar,ffechaven2,103) as ffechaven2, ccond, ccodcos, ccodcos2 " +
                ", cctabase, cctaicbper, cctaotrib, cctatot, nresp " +
                ", nporre, nimpres, cserre, cnumre, convert(varchar,ffecre,103) as ffecre, ccodpresu " +
                ", nigv,  ccodpago, nperdenre, nbaseres, cctaperc, " +
                " obserror " +
                "  FROM fin_ventas where es_con_migracion not in(0,1,4) and ccodrucemisor='"+ Objet.ruc.Trim()+ "' and ccod_empresa='"+ Objet.empresa.Trim()+"'";
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
        public DataTable listaspos(Clase.ventas_propiedades Objet)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            NpgsqlDataReader carga;
            DataTable grilla = new DataTable();
            ;            
            try
            {
                string query = "SELECT  0 as MARCA  ,idventas" +
                ", ccod_empresa, to_char(ffechadoc,'dd/mm/yyyy')::char(10) as ffechadoc,"+
                " to_char(ffechaven,'dd/mm/yyyy')::char(10) as ffechaven, ccoddoc" +
                ", cserie, cnumero, ccodenti, cdesenti " +
                ", ctipdoc, ccodruc, crazsoc, nbase2, nbase1 " +
                ", nexo, nina, nisc, nigv1, nicbpers, nbase3 " +
                ", ntots, ntc, to_char(freffec,'dd/mm/yyyy')::char(10) as freffec, crefdoc, crefser, crefnum " +
                ", cmreg, ndolar, to_char(ffechaven2,'dd/mm/yyyy')::char(10) as ffechaven2, ccond, ccodcos, ccodcos2 " +
                ", cctabase, cctaicbper, cctaotrib, cctatot, nresp " +
                ", nporre, nimpres, cserre, cnumre, to_char(ffecre,'dd/mm/yyyy')::char(10) as ffecre, ccodpresu " +
                ", nigv,  ccodpago, nperdenre, nbaseres, cctaperc, " +
                " obserror " +
                "  FROM fin_ventas where es_con_migracion not in(0,1,4) and ccodrucemisor='" + Objet.ruc.Trim() + "' and ccod_empresa='" + Objet.empresa.Trim() + "'";
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
        public string eliminarsql(Clase.ventas_propiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string cadena1 = "Delete from fin_ventas  where idventas=" + Objet.idventas + "";
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
        public string eliminarpos(Clase.ventas_propiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            try
                {
                    string cadena1 = "Delete from fin_ventas  where idventas=" + Objet.idventas + "";
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
        public string Actualizarsql(Clase.ventas_propiedades Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update  fin_ventas  SET cmreg='" + Objet.cmreg.Trim() + "',ccond='" + Objet.ccond.ToUpper().Trim() + "'," +
                                   "cctabase='" + Objet.cctabase.Trim() + "',cctatot='" + Objet.cctatot.Trim() + "',ccodcos='" + Objet.ccodcos.Trim() + "'," +
                                   "ccodcos2='" + Objet.ccodcos2.Trim() + "',obserror='',es_con_migracion=0  where idventas=" + Objet.idventas + "";
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
        public string Actualizarpos(Clase.ventas_propiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update  fin_ventas  SET cmreg='"+Objet.cmreg.Trim()+"',ccond='"+Objet.ccond.ToUpper().Trim()+"',"+
                                  "cctabase='"+Objet.cctabase.Trim()+ "',cctatot='"+Objet.cctatot.Trim()+ "',ccodcos='"+Objet.ccodcos.Trim()+"',"+
                                  "ccodcos2='"+Objet.ccodcos2.Trim()+ "',obserror='',es_con_migracion=0 where idventas=" + Objet.idventas + "";
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
    }
}
