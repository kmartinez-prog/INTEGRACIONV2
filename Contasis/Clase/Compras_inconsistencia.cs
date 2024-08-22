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
    class Compras_inconsistencia
    {  /*******************************************************************************************************/
        public DataTable listassql(Clase.ventas_propiedades Objet)
        {
            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT  ccodrucemisor ,idventas" +
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
                "  FROM fin_compras where es_con_migracion not in(0,1,4)";
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
                ", ccod_empresa, to_char(ffechadoc,'dd/mm/yyyy')::char(10) as ffechadoc," +
                " to_char(ffechaven,'dd/mm/yyyy')::char(10) as ffechaven, ccoddoc" +
                ", cserie, cnumero, ccodenti, cdesenti " +
                ", ctipdoc, ccodruc, crazsoc, nbase2, nbase1 " +
                ", nexo, nina, nisc, nigv1, nicbpers, nbase3 " +
                ", ntots, ntc, to_char(freffec,'dd/mm/yyyy')::char(10) as freffec, crefdoc, crefser, crefnum " +
                ", cmreg, ndolar, to_char(ffechaven2,'dd/mm/yyyy')::char(10) as ffechaven2, ccond, ccodcos, ccodcos2 " +
                ", cctabase, cctaicbper, cctaotrib, cctatot, nresp " +
                ", nporre, nimpres, cserre, cnumre, to_char(ffecre,'dd/mm/yyyy')::char(10) as ffecre, ccodpresu " +
                ", nigv, cglosa, ccodpago, nperdenre, nbaseres, cctaperc, " +
                " obserror " +
                "  FROM fin_compras where resultado_migracion not in(0,1,4)";
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
