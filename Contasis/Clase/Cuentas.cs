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
    class Cuentas
    {

        public string Insertar(Clase.CuentasPropiedad Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                
                string query0 = "SELECT CPER FROM CONFIGURACION WHERE CPER='" + Objet.PERIODO + "' AND CCOD_EMPRESA='"+ Objet.EMPRESA + "' and CTIPO='" + Objet.CTIPO + "'";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(query0, cone);
                DataTable dt = new DataTable();
                cone.Open();
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);

                if (Objet.CTIPO == "01")
                {
                    /**solo ventas**/

                    if (dt.Rows.Count > 0)
                    {

                        string query1 = "UPDATE CONFIGURACION  " +
                        "SET crazemp ='" + Objet.RAZONSOCIAL + "', " +
                        " crucemp ='" + Objet.RUC + "', " +
                        " cEntidad ='" + Objet.ENTIDAD + "', " +
                        " csub1_vta ='" + Objet.CSUB1_vta + "', " +
                          " clreg1_vta =' " + Objet.CLREG1_vta + "', " +
                          " csub2_vta ='" + Objet.CSUB2_vta + "', " +
                          " clreg2_vta ='" + Objet.CLREG2_vta + "', " +
                          " cconts_vta ='" + Objet.CCONTS_vta + "', " +
                          " ccontd_vta ='" + Objet.CCONTD_vta + "', " +
                          " cfefec_vta ='" + Objet.CFEFEC_vta + "', " +
                          " ctares_vta =" + Objet.CTARES_vta + "," +
                          " ctaimp_vta =" + Objet.CTAIMP_vta + "," +
                          " Ctaact_vta =" + Objet.CTAACT_Vta + "," +
                          " asientos_vta =" + Objet.ASIENTOS_vta + "," +
                          " cEnt_anula ='" + Objet.CENT_ANULA + "' " +
                          " where CPER='" + Objet.PERIODO + "' AND CCOD_EMPRESA='" + Objet.EMPRESA + "' and CTIPO='" + Objet.CTIPO + "'";
                        cone = ConexionSql.Instancial().establecerconexion();
                        SqlCommand commando2 = new SqlCommand(query1, cone);
                        cone.Open();
                        cadena = commando2.ExecuteNonQuery() == 1 ? "Actualizado" : "No se actualizo";

                    }

                    else
                    {
                        string query = "INSERT INTO CONFIGURACION(CCOD_EMPRESA, cper, crazemp, crucemp, cEntidad," +
                           "csub1_vta, clreg1_vta, csub2_vta, clreg2_vta, cconts_vta," +
                           "ccontd_vta, cfefec_vta, ctares_vta, ctaimp_vta, Ctaact_vta, asientos_vta," +
                           "cTipo,cEnt_anula) values(" +
                           "'" + Objet.EMPRESA + "', " +
                           "'" + Objet.PERIODO + "', " +
                           "'" + Objet.RAZONSOCIAL + "', " +
                           "'" + Objet.RUC + "', " +
                           "'" + Objet.ENTIDAD + "', " +
                           "'" + Objet.CSUB1_vta + "', " +
                           "'" + Objet.CLREG1_vta + "', " +
                           "'" + Objet.CSUB2_vta + "', " +
                           "'" + Objet.CLREG2_vta + "', " +
                           "'" + Objet.CCONTS_vta + "', " +
                           "'" + Objet.CCONTD_vta + "', " +
                           "'" + Objet.CFEFEC_vta + "', " +
                           "" + Objet.CTARES_vta + "," +
                           "" + Objet.CTAIMP_vta + "," +
                           "" + Objet.CTAACT_Vta + "," +
                           "" + Objet.ASIENTOS_vta + "," +
                           "'" + Objet.CTIPO + "',"+
                           "'" + Objet.CENT_ANULA + "')";
                        cone = ConexionSql.Instancial().establecerconexion();
                        SqlCommand commando1 = new SqlCommand(query, cone);
                        cone.Open();
                        cadena = commando1.ExecuteNonQuery() > 0 ? "Grabado" : "No se grabo";

                    }
                }

                if (Objet.CTIPO == "02")
                {
                    /**solo compras**/

                    if (dt.Rows.Count > 0)
                    {

                        string query1 = "UPDATE CONFIGURACION  " +
                        "SET crazemp ='" + Objet.RAZONSOCIAL + "', " +
                        " crucemp ='" + Objet.RUC + "', " +
                        " cEntidad ='" + Objet.ENTIDAD + "', " +
                        " csub1_com ='" + Objet.CSUB1_com + "', " +
                          " clreg1_com =' " + Objet.CLREG1_com + "', " +
                          " csub2_com ='" + Objet.CSUB2_com + "', " +
                          " clreg2_com ='" + Objet.CLREG2_com + "', " +
                          " cconts_com ='" + Objet.CCONTS_com + "', " +
                          " ccontd_com ='" + Objet.CCONTD_com + "', " +
                          " cfefec_com ='" + Objet.CFEFEC_com + "', " +
                          " ctares_com =" + Objet.CTARES_com + "," +
                          " ctaimp_com =" + Objet.CTAIMP_com + "," +
                          " Ctapas_com =" + Objet.CTAPAS_com + "," +
                          " asientos_com =" + Objet.ASIENTOS_com + "," +
                          " cEnt_anula ='" + Objet.CENT_ANULA + "' " +
                          " where CPER='" + Objet.PERIODO + "' AND CCOD_EMPRESA='" + Objet.EMPRESA + "' and CTIPO='" + Objet.CTIPO + "'";
                        cone = ConexionSql.Instancial().establecerconexion();
                        SqlCommand commando2 = new SqlCommand(query1, cone);
                        cone.Open();
                        cadena = commando2.ExecuteNonQuery() == 1 ? "Actualizado" : "No se actualizo";

                    }

                    else
                    {
                        string query = "INSERT INTO CONFIGURACION(CCOD_EMPRESA, cper, crazemp, crucemp, cEntidad," +
                          "csub1_com, clreg1_com, csub2_com, clreg2_com, cconts_com," +
                           "ccontd_com, cfefec_com, ctares_com, ctaimp_com, Ctapas_com, asientos_com," +
                           "cTipo,cEnt_anula) values(" +
                           "'" + Objet.EMPRESA + "', " +
                           "'" + Objet.PERIODO + "', " +
                           "'" + Objet.RAZONSOCIAL + "', " +
                           "'" + Objet.RUC + "', " +
                           "'" + Objet.ENTIDAD + "', " +
                           "'" + Objet.CSUB1_com + "', " +
                           "'" + Objet.CLREG1_com + "', " +
                           "'" + Objet.CSUB2_com + "', " +
                           "'" + Objet.CLREG2_com + "', " +
                           "'" + Objet.CCONTS_com + "', " +
                           "'" + Objet.CCONTD_com + "', " +
                           "'" + Objet.CFEFEC_com + "', " +
                           "" + Objet.CTARES_com + "," +
                           "" + Objet.CTAIMP_com + "," +
                           "" + Objet.CTAPAS_com + "," +
                           "" + Objet.ASIENTOS_com + "," +
                           "'" + Objet.CTIPO + "'," +
                           "'" + Objet.CENT_ANULA + "')";
                           cone = ConexionSql.Instancial().establecerconexion();
                        SqlCommand commando1 = new SqlCommand(query, cone);
                        cone.Open();
                        cadena = commando1.ExecuteNonQuery() > 0 ? "Grabado" : "No se grabo";

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
                if (cone.State == ConnectionState.Open)
                {
                    cone.Close();
                }

            }
            return cadena;
        }
        public DataTable Cargar_ventas(string mEmpresa, string mPeriodo)
        {
            string xempresa = mEmpresa;
            string xPeriodo = mPeriodo;

            SqlDataReader carga;
            DataTable Grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT CCOD_EMPRESA as EMPRESA,cper AS PERIODO,crazemp AS RAZON,crucemp AS RUC,"+
                "cEntidad AS ENTIDAD_VENTA ,csub1_vta,clreg1_vta,csub2_vta,clreg2_vta,cconts_vta,ccontd_vta,cfefec_vta"+
                ",ctares_vta AS RESULTADO,ctaimp_vta AS IMPUESTOS,Ctaact_vta ACTIVO_VTA, asientos_vta AS ASIENTO_VTA, cTipo AS TIPO,cEnt_anula as ENT_ANULADO " +
                "FROM CONFIGURACION where CCOD_EMPRESA='"+xempresa+"' and cper='"+xPeriodo+"' and   ctipo = '01' order by cper desc";
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
        public DataTable Cargar_compras(string mEmpresa, string mPeriodo)
        {

            string xempresa = mEmpresa;
            string xPeriodo = mPeriodo;

            SqlDataReader carga;
            DataTable Grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT CCOD_EMPRESA as EMPRESA,cper AS PERIODO,crazemp AS RAZON,crucemp AS RUC,"+
                "cEntidad AS ENTIDAD_COMPRA,csub1_com,clreg1_com,csub2_com ,clreg2_com,cconts_com,ccontd_com"+
                ",cfefec_com,ctares_com AS RESULTADO_COM,ctaimp_com AS IMPUESTOS_COM ,Ctapas_com AS ACTIVO_COM ,asientos_com as ASIENTO_COM,"+
                "cTipo AS TIPO,cEnt_anula as ENT_ANULADO  FROM CONFIGURACION where  CCOD_EMPRESA='" + xempresa + "' and cper='" + xPeriodo + "' and    ctipo = '02' order by cper desc";
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


        public string Insertar_postgres(Clase.CuentasPropiedad Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            try
            {

                string query0 = "SELECT CPER FROM CONFIGURACION WHERE CPER='" + Objet.PERIODO + "' AND CCOD_EMPRESA='" + Objet.EMPRESA + "' and CTIPO='" + Objet.CTIPO + "'";
                NpgsqlCommand cmdp = new NpgsqlCommand(query0, conexion);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
                
                data.Fill(dt);

                if (Objet.CTIPO == "01")
                {
                    /**solo ventas**/

                    if (dt.Rows.Count > 0)
                    {

                        string query1 = "UPDATE CONFIGURACION  " +
                        "SET crazemp ='" + Objet.RAZONSOCIAL + "', " +
                        " crucemp ='" + Objet.RUC + "', " +
                        " cEntidad ='" + Objet.ENTIDAD + "', " +
                        " csub1_vta ='" + Objet.CSUB1_vta + "', " +
                          " clreg1_vta =' " + Objet.CLREG1_vta + "', " +
                          " csub2_vta ='" + Objet.CSUB2_vta + "', " +
                          " clreg2_vta ='" + Objet.CLREG2_vta + "', " +
                          " cconts_vta ='" + Objet.CCONTS_vta + "', " +
                          " ccontd_vta ='" + Objet.CCONTD_vta + "', " +
                          " cfefec_vta ='" + Objet.CFEFEC_vta + "', " +
                          " ctares_vta =" + Objet.CTARES_vta + "," +
                          " ctaimp_vta =" + Objet.CTAIMP_vta + "," +
                          " Ctaact_vta =" + Objet.CTAACT_Vta + "," +
                          " asientos_vta =" + Objet.ASIENTOS_vta + "," +
                          " cEnt_anula ='" + Objet.CENT_ANULA + "' " +
                          " where CPER='" + Objet.PERIODO + "' AND CCOD_EMPRESA='" + Objet.EMPRESA + "' and CTIPO='" + Objet.CTIPO + "'";
                        NpgsqlCommand cmdp1 = new NpgsqlCommand(query1, conexion);
                        cadena = cmdp1.ExecuteNonQuery() == 1 ? "Actualizado" : "No se actualizo";

                    }

                    else
                    {
                        string query = "INSERT INTO CONFIGURACION(CCOD_EMPRESA, cper, crazemp, crucemp, cEntidad," +
                           "csub1_vta, clreg1_vta, csub2_vta, clreg2_vta, cconts_vta," +
                           "ccontd_vta, cfefec_vta, ctares_vta, ctaimp_vta, Ctaact_vta, asientos_vta," +
                           "cTipo,cEnt_anula) values(" +
                           "'" + Objet.EMPRESA + "', " +
                           "'" + Objet.PERIODO + "', " +
                           "'" + Objet.RAZONSOCIAL + "', " +
                           "'" + Objet.RUC + "', " +
                           "'" + Objet.ENTIDAD + "', " +
                           "'" + Objet.CSUB1_vta + "', " +
                           "'" + Objet.CLREG1_vta + "', " +
                           "'" + Objet.CSUB2_vta + "', " +
                           "'" + Objet.CLREG2_vta + "', " +
                           "'" + Objet.CCONTS_vta + "', " +
                           "'" + Objet.CCONTD_vta + "', " +
                           "'" + Objet.CFEFEC_vta + "', " +
                           "" + Objet.CTARES_vta + "," +
                           "" + Objet.CTAIMP_vta + "," +
                           "" + Objet.CTAACT_Vta + "," +
                           "" + Objet.ASIENTOS_vta + "," +
                           "'" + Objet.CTIPO + "'," +
                           "'" + Objet.CENT_ANULA + "')";
                        NpgsqlCommand cmdp1 = new NpgsqlCommand(query, conexion);
                        cadena = cmdp1.ExecuteNonQuery() > 0 ? "Grabado" : "No se grabo";

                    }
                }

                if (Objet.CTIPO == "02")
                {
                    /**solo compras**/

                    if (dt.Rows.Count > 0)
                    {

                        string query1 = "UPDATE CONFIGURACION  " +
                        "SET crazemp ='" + Objet.RAZONSOCIAL + "', " +
                        " crucemp ='" + Objet.RUC + "', " +
                        " cEntidad ='" + Objet.ENTIDAD + "', " +
                        " csub1_com ='" + Objet.CSUB1_com + "', " +
                          " clreg1_com =' " + Objet.CLREG1_com + "', " +
                          " csub2_com ='" + Objet.CSUB2_com + "', " +
                          " clreg2_com ='" + Objet.CLREG2_com + "', " +
                          " cconts_com ='" + Objet.CCONTS_com + "', " +
                          " ccontd_com ='" + Objet.CCONTD_com + "', " +
                          " cfefec_com ='" + Objet.CFEFEC_com + "', " +
                          " ctares_com =" + Objet.CTARES_com + "," +
                          " ctaimp_com =" + Objet.CTAIMP_com + "," +
                          " Ctapas_com =" + Objet.CTAPAS_com + "," +
                          " asientos_com =" + Objet.ASIENTOS_com + "," +
                          " cEnt_anula ='" + Objet.CENT_ANULA + "' " +
                          " where CPER='" + Objet.PERIODO + "' AND CCOD_EMPRESA='" + Objet.EMPRESA + "' and CTIPO='" + Objet.CTIPO + "'";
                        NpgsqlCommand cmdp1 = new NpgsqlCommand(query1, conexion);
                        cadena = cmdp1.ExecuteNonQuery() == 1 ? "Actualizado" : "No se actualizo";

                    }

                    else
                    {
                        string query = "INSERT INTO CONFIGURACION(CCOD_EMPRESA, cper, crazemp, crucemp, cEntidad," +
                          "csub1_com, clreg1_com, csub2_com, clreg2_com, cconts_com," +
                           "ccontd_com, cfefec_com, ctares_com, ctaimp_com, Ctapas_com, asientos_com," +
                           "cTipo,cEnt_anula) values(" +
                           "'" + Objet.EMPRESA + "', " +
                           "'" + Objet.PERIODO + "', " +
                           "'" + Objet.RAZONSOCIAL + "', " +
                           "'" + Objet.RUC + "', " +
                           "'" + Objet.ENTIDAD + "', " +
                           "'" + Objet.CSUB1_com + "', " +
                           "'" + Objet.CLREG1_com + "', " +
                           "'" + Objet.CSUB2_com + "', " +
                           "'" + Objet.CLREG2_com + "', " +
                           "'" + Objet.CCONTS_com + "', " +
                           "'" + Objet.CCONTD_com + "', " +
                           "'" + Objet.CFEFEC_com + "', " +
                           "" + Objet.CTARES_com + "," +
                           "" + Objet.CTAIMP_com + "," +
                           "" + Objet.CTAPAS_com + "," +
                           "" + Objet.ASIENTOS_com + "," +
                           "'" + Objet.CTIPO + "'," +
                           "'" + Objet.CENT_ANULA + "')";
                        NpgsqlCommand cmdp1 = new NpgsqlCommand(query, conexion);
                        cadena = cmdp1.ExecuteNonQuery() > 0 ? "Grabado" : "No se grabo";

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
        public DataTable Cargar_ventas_postgres(string mEmpresa, string mPeriodo)
        {
            string xempresa = mEmpresa;
            string xPeriodo = mPeriodo;
            NpgsqlDataReader carga;
            DataTable Grilla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();

            try
            {
                string query = "SELECT CCOD_EMPRESA as EMPRESA,cper AS PERIODO,crazemp AS RAZON,crucemp AS RUC," +
                "cEntidad AS ENTIDAD_VENTA ,csub1_vta,clreg1_vta,csub2_vta,clreg2_vta,cconts_vta,ccontd_vta,cfefec_vta" +
                ",ctares_vta AS RESULTADO,ctaimp_vta AS IMPUESTOS,Ctaact_vta ACTIVO_VTA, asientos_vta AS ASIENTO_VTA, cTipo AS TIPO,cEnt_anula as ENT_ANULADO " +
                "FROM CONFIGURACION where CCOD_EMPRESA='" + xempresa + "' and cper='" + xPeriodo + "' and   ctipo = '01' order by cper desc";
                NpgsqlCommand cmdp1 = new NpgsqlCommand(query, conexion);
                carga = cmdp1.ExecuteReader();
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
        public DataTable Cargar_compras_postgres(string mEmpresa, string mPeriodo)
        {

            string xempresa = mEmpresa;
            string xPeriodo = mPeriodo;

            NpgsqlDataReader carga;
            DataTable Grilla = new DataTable();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "SELECT CCOD_EMPRESA as EMPRESA,cper AS PERIODO,crazemp AS RAZON,crucemp AS RUC," +
                "cEntidad AS ENTIDAD_COMPRA,csub1_com,clreg1_com,csub2_com ,clreg2_com,cconts_com,ccontd_com" +
                ",cfefec_com,ctares_com AS RESULTADO_COM,ctaimp_com AS IMPUESTOS_COM ,Ctapas_com AS ACTIVO_COM ,asientos_com as ASIENTO_COM," +
                "cTipo AS TIPO,cEnt_anula as ENT_ANULADO  FROM CONFIGURACION where  CCOD_EMPRESA='" + xempresa + "' and cper='" + xPeriodo + "' and    ctipo = '02' order by cper desc";
                NpgsqlCommand cmdp1 = new NpgsqlCommand(query, conexion);
                carga = cmdp1.ExecuteReader();
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

    }
}
