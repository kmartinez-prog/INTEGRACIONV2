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
                string query = "SELECT  ccodrucemisor ,idventas"+
                ", ccod_empresa, ffechadoc, ffechaven, ccoddoc"+
                ", cserie, cnumero, ccodenti, cdesenti " +
                ", ctipdoc, ccodruc, crazsoc, nbase2, nbase1 " +
                ", nexo, nina, nisc, nigv1, nicbpers, nbase3 " +
                ", ntots, ntc, freffec, crefdoc, crefser, crefnum " +
                ", cmreg, ndolar, ffechaven2, ccond, ccodcos, ccodcos2 " +
                ", cctabase, cctaicbper, cctaotrib, cctatot, nresp " +
                ", nporre, nimpres, cserre, cnumre, ffecre, ccodpresu " +
                ", nigv, cglosa, ccodpago, nperdenre, nbaseres, cctaperc, " +
                " obserror " +
                "  FROM fin_ventas where es_con_migracion not in(0,1)";
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
                string query = "SELECT  ccodrucemisor ,idventas" +
                ", ccod_empresa, ffechadoc, ffechaven, ccoddoc" +
                ", cserie, cnumero, ccodenti, cdesenti " +
                ", ctipdoc, ccodruc, crazsoc, nbase2, nbase1 " +
                ", nexo, nina, nisc, nigv1, nicbpers, nbase3 " +
                ", ntots, ntc, freffec, crefdoc, crefser, crefnum " +
                ", cmreg, ndolar, ffechaven2, ccond, ccodcos, ccodcos2 " +
                ", cctabase, cctaicbper, cctaotrib, cctatot, nresp " +
                ", nporre, nimpres, cserre, cnumre, ffecre, ccodpresu " +
                ", nigv, cglosa, ccodpago, nperdenre, nbaseres, cctaperc, " +
                " obserror " +
                "  FROM fin_ventas ";
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
    }
}
