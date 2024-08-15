using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Contasis
{
    public class crearfinanciero
    {
        private string cadena;

        public string Cadena { get => cadena; set => cadena = value; }
        public void crearventas(string _cadena)
        {
            cadena = _cadena;
            String strfventas;
            SqlConnection conex = new SqlConnection(cadena);
            try
            {
                conex.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se establec la conexion : " + ex.Message, "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /** aca vamos a Verificar si Existe la tabla Contasis    **/
            string verifica = "SELECT  * FROM SYSDATABASES WHERE NAME='bdintegradorContasis'";
            SqlCommand comando = new SqlCommand(verifica, conex);
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comando);

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    strfventas = "CREATE TABLE [dbo].[Fin_Ventas](" +
                    "CCOD_EMPRESA char(3) NULL," +
                    "cper char(4) null,"+
                    "ffechadoc date   NULL," +
                    "ffechaven date   NULL," +
                    "ccoddoc nchar(2) NULL," +
                    "cserie nchar(20) NULL," +
                    "cnumero nchar(20) NULL," +
                    "codenti nchar(11) NULL," +
                    "cdesenti nchar(100) NULL," +
                    "ctipodoc nchar(1) NULL," +
                    "ccodruc nchar(15) NULL," +
                    "crazsoc nchar(100) NULL," +
                    "nbase2 numeric(15, 2) NULL," +
                    "nbase1 numeric(15, 2) NULL," +
                    "nexo numeric(15, 2) NULL," +
                    "nina numeric(15, 2) NULL," +
                    "nisc numeric(15, 2) NULL," +
                    "nigv1 numeric(15, 2) NULL," +
                    "nicbpers numeric(15, 2) NULL," +
                    "nbase3 numeric(15, 2) NULL," +
                    "ntots numeric(15, 2) NULL," +
                    "ntc numeric(10, 6) NULL," +
                    "freffec date   NULL," +
                    "crefdoc nchar(2) NULL," +
                    "crefser  char(6) NULL," +
                    "crefnum nchar(13) NULL," +
                    "cmreg nchar(1) NULL," +
                    "ndolar numeric(15, 2) NULL," +
                            "ffechaven2 date   NULL," +
                            "ccond nchar(3) NULL," +
                            "ccodcos nchar(9) NULL," +
                            "ccodcos2 nchar(9) NULL," +
                            "cctabase nchar(20) NULL," +
                            "cctaicbper nchar(20) NULL," +
                            "cctaotrib nchar(20) NULL," +
                            "cctatot nchar(20) NULL," +
                            "nresp numeric(1, 0) NULL," +
                            "nporre numeric(5, 2) NULL," +
                            "nimpres numeric(15, 2) NULL," +
                            "cserre nchar(6) NULL," +
                            "cnumre nchar(13) NULL," +
                            "ffecre date   NULL," +
                            "ccodpresu nchar(10) NULL," +
                            "nigv numeric(5, 2) NULL," +
                            "cglosa nchar(80) NULL," +
                            "ccodpago nchar(3) NULL," +
                            "nperdenre numeric(1, 0) NULL," +
                            "nbaseres numeric(15, 2) NULL," +
                            "cctaperc nchar(20) NULL," +
                            "created_at datetime   default getdate()," +
                            "updated_at datetime   NULL," +
                            "estado varchar(255)   NULL," +
                            "en_ambiente_de varchar(255)   NULL," +
                            "es_con_migracion numeric(1, 0) NULL," +
                            "ccodcos3 nchar(15)   NULL)";

                    SqlCommand myCommand = new SqlCommand(strfventas, conex);
                    try
                    {
                        myCommand.ExecuteNonQuery();
                        conex.Close();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp.en Ventas", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }

                }
            }
            

        }
        public void crearcompras(string _cadena)
        {
            cadena = _cadena;
            String strfcompras;
            SqlConnection conex1 = new SqlConnection(cadena);
            try
            {
                conex1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se establec la conexion : " + ex.Message, "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /** aca vamos a Verificar si Existe la tabla Contasis    **/
            string verifica = "SELECT  * FROM SYSDATABASES WHERE NAME='bdintegradorContasis'";
            SqlCommand comando1 = new SqlCommand(verifica, conex1);
            {
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(comando1);

                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {

                    strfcompras = "CREATE TABLE Fin_Compras(CCOD_EMPRESA char(3) NULL," +
                                    "cper char(4) null," +
                                    "ffechadoc date NULL,fechaven date   NULL," +
                                    "ccoddoc    nchar  (2) NULL,ccoddas    nchar  (3) NULL,cyeardas    nchar  (4) NULL," +
                                    "cserie    nchar  (20) NULL,cnumero    nchar  (20) NULL,ccodenti    nchar  (11) NULL,cdesenti    nchar  (100) NULL," +
                                    "ctipdoc    nchar  (1) NULL,ccodruc    nchar  (15) NULL,crazsoc    nchar  (100) NULL,ccodclas    nchar  (1) NULL," +
                                    "nbase1    numeric  (15,2) NULL,nigv1    numeric  (15,2) NULL,nbase2    numeric  (15,2) NULL,nigv2    numeric  (15,2) NULL," +
                                    "nbase3    numeric  (15,2) NULL,nigv3    numeric  (15,2) NULL,nina    numeric  (15,2) NULL,nisc    numeric  (15,2) NULL," +
                                    "nicbper    numeric  (15,2) NULL,nexo    numeric  (15,2) NULL,ntots    numeric  (15,2) NULL,cdocnodom    nchar  (20) NULL," +
                                    "cnumdere    nchar  (15) NULL,ffecre    date   NULL,ntc    numeric  (10,6) NULL,freffec    date   NULL,crefdoc    nchar  (2) NULL," +
                                    "crefser    nchar  (6) NULL,crefnum    nchar  (13) NULL,cmreg    nchar  (1) NULL,ndolar    numeric  (15,2) NULL," +
                                    "ffechaven2    date   NULL,ccond    nchar  (3) NULL,cctabase    nchar  (10) NULL,cctaicbper    nchar  (10) NULL," +
                                    "cctaotrib    nchar  (10) NULL,cctatot    nchar  (10) NULL,ccodcos    nchar  (9) NULL,ccodcos2    nchar  (9) NULL," +
                                    "nresp    numeric  (1,0) NULL,nporre    numeric  (5,2) NULL,nimpres    numeric  (15,2) NULL," +
                                    "cserre    nchar  (6) NULL,cnumre    nchar  (13) NULL,ffecre2    date   NULL,ccodpresu    nchar  (10) NULL," +
                                    "nigv    numeric  (5,2) NULL,cglosa    nchar  (50) NULL,nperdenre    numeric  (15,2) NULL,nbaseres    numeric  (15,2) NULL," +
                                    "cigvxacre    nchar  (1) NULL,created_at    datetime   default getdate()," +
                                    "updated_at    datetime   NULL,estado    varchar(255)   NULL,en_ambiente_de    varchar(255)   NULL," +
                                    "es_con_migracion   numeric(1,0) NULL,ccodcos3    nchar(15)   NULL)";

                    SqlCommand myCommand1 = new SqlCommand(strfcompras, conex1);
                    try
                    {
                        myCommand1.ExecuteNonQuery();
                        conex1.Close();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. compras", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                }
            }


        }
        public void crearadicional(string _cadena)
        {
            cadena = _cadena;
            String stremp;
            String strusuario;
            String sconfigura;
            String stmodulo;
            String strusuarioacceso;
            SqlConnection conex2 = new SqlConnection(cadena);
            try
            {
                conex2.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se establec la conexion : " + ex.Message, "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /** aca vamos a Verificar si Existe la tabla Contasis    **/
            string verifica2 = "SELECT  * FROM SYSDATABASES WHERE NAME='bdintegradorContasis'";
            SqlCommand comando2 = new SqlCommand(verifica2, conex2);
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(comando2);

                da2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {

                    stremp = "CREATE TABLE CG_EMPRESA(CCOD_EMPRESA character(3),NOMEMPRESA CHARACTER(50))";

                    SqlCommand myCommand2 = new SqlCommand(stremp, conex2);
                    try
                    {
                        myCommand2.ExecuteNonQuery();
                        
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. Empresa", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                    strusuario= "CREATE TABLE CG_usuario(ccodusu character(20) NOT NULL DEFAULT ''," +
                                "CDESUSU character(60) NOT NULL DEFAULT ''," +
                                "PASSORD character(30) NOT NULL DEFAULT ''," +
                                "FEC_ULTACCESO DATETIME DEFAULT GETDATE())";

                    SqlCommand myCommand3 = new SqlCommand(strusuario, conex2);
                    try
                    {
                        myCommand3.ExecuteNonQuery();

                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. Usuario", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                    sconfigura = "CREATE TABLE configuracion(CCOD_EMPRESA Char(3) null," +
                                "cper char(4) null,"+
                                "crazemp char(100) null,"+
                                "crucemp char(15) null,"+
                                "csub1_vta char(3) null," +
                                "clreg1_vta char(20) null," +
                                "csub2_vta char(3) null," +
                                "clreg2_vta  char(20) null,cconts_vta  char(20) null,ccontd_vta  char(20) null," +
                                "cfefec_vta char(4),ctares_vta numeric(1,0),ctaimp_vta numeric(1,0) ,Ctaact_vta numeric(1,0)," +
                                "csub1_com char(3) null," +
                                "clreg1_com char(20) null," +
                                "csub2_com char(3) null," +
                                "clreg2_com  char(20) null,cconts_com  char(20) null,ccontd_com  char(20) null," +
                                "cfefec_com char(4),ctares_com numeric(1,0),ctaimp_com numeric(1,0) ,Ctapas_com numeric(1,0), cTipo char(2) null)";

                    SqlCommand myCommand4 = new SqlCommand(sconfigura, conex2);
                    try
                    {
                        myCommand4.ExecuteNonQuery();

                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. configuracion ctas.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                    stmodulo = "CREATE TABLE CG_MODULOS(CCODMOD character(10),CDESMOD character(100))";
                    SqlCommand myCommand5 = new SqlCommand(stmodulo, conex2);
                    try
                    {
                        myCommand5.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. Modulo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }

                    strusuarioacceso = "CREATE TABLE CG_usuario_acceso(ccodusu character(20) not null DEFAULT ''," +
                             "CCODMOD character(10) not null DEFAULT ''," +
                             "FLGACCESO NUMERIC(1,0) default 0)" ;

                    SqlCommand myCommand6 = new SqlCommand(strusuarioacceso, conex2);
                    try
                    {
                        myCommand6.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. Usuario con Acceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    conex2.Close();
                }
            }
        }
        public void crearindex(string _cadena)
        {
            cadena = _cadena;
            String strindex;
            SqlConnection conex2 = new SqlConnection(cadena);
            try
            {
                conex2.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se establec la conexion : " + ex.Message, "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /** aca vamos a Verificar si Existe la tabla Contasis    **/
            string verifica2 = "SELECT  * FROM SYSDATABASES WHERE NAME='bdintegradorContasis'";
            SqlCommand comando2 = new SqlCommand(verifica2, conex2);
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(comando2);

                da2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    strindex = " CREATE UNIQUE INDEX claveEmpresa ON CG_EMPRESA (CCOD_EMPRESA ASC) ";
                    SqlCommand myCommand20 = new SqlCommand(strindex, conex2);
                    try
                    {
                        myCommand20.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. Index Empresa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    strindex = " CREATE  INDEX ClaveConfig ON configuracion (CCOD_EMPRESA ASC, cper ASC) ";
                    SqlCommand myCommand21 = new SqlCommand(strindex, conex2);
                    try
                    {
                        myCommand21.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. Index configuracion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    strindex = "CREATE  INDEX claveCompras ON Fin_Compras (CCOD_EMPRESA ASC, cper ASC) " ;
                    SqlCommand myCommand22 = new SqlCommand(strindex, conex2);
                    try
                    {
                        myCommand22.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. Index compras", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    strindex = "CREATE  INDEX claveVentas ON Fin_Ventas (CCOD_EMPRESA ASC, cper ASC) ";
                    SqlCommand myCommand23 = new SqlCommand(strindex, conex2);
                    try
                    {
                        myCommand23.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. Index ventas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    strindex = "CREATE  INDEX claveUsuario ON CG_usuario (ccodusu ASC) ";
                    SqlCommand myCommand24 = new SqlCommand(strindex, conex2);
                    try
                    {
                        myCommand24.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. Index Usuario", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    strindex = "CREATE  INDEX claveUsuario ON CG_usuario_acceso (ccodusu ASC) ";
                    SqlCommand myCommand25 = new SqlCommand(strindex, conex2);
                    try
                    {
                        myCommand25.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. Index Usuario acceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    strindex = "CREATE  INDEX claveUsuario ON CG_MODULOS (CCODMOD ASC) ";
                    SqlCommand myCommand26 = new SqlCommand(strindex, conex2);
                    try
                    {
                        myCommand26.ExecuteNonQuery();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Contasis Corp. Index Usuario Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    conex2.Close();
                }
            }
        }
    }
}
        

