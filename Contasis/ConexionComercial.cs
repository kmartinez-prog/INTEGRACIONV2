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
    public class crearcomercial
    {
        private string cadena;
        public string Cadena { get => cadena; set => cadena = value; }
        public void crearcabeceracomercial(string _cadena)
        {
            cadena = _cadena;
            String cabeceracomercial;
            if (cadena == "")
            {
                MessageBox.Show("No se realizo la conexión, ingrese las credenciales ", "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                SqlConnection conex = new SqlConnection(cadena);
                try
                {
                    conex.Open();
                }
                catch
                {
                    MessageBox.Show("No se establece la conexión : ", "Contasis Corp. error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                /** aca vamos a Verificar si Existe la tabla Contasis    **/
                string verifica = "SELECT* FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'com_documento'";
                SqlCommand comando = new SqlCommand(verifica, conex);
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(comando);

                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                    cabeceracomercial = "CREATE TABLE com_documento (\n" +
                    "iddocumento int identity(1,1) primary key not null,\n" +
                    "ccodrucemisor char(15) NULL,   \n" +
                    "	ccod_empresa char(3) NULL, " +
                    "	cper char(4) NULL, " +
                    "	cmes char(2) NULL, " +
                    "	ccodmodulo char(6) NULL, " +
                    "	ccodmov char(5) NULL, " +
                    "	ccoddoc char(2) NULL, " +
                    "	cserie char(20) NULL, " +
                    "	cnumero char(20) NULL, " +
                    "	ccodenti char(11) NULL, " +
                    "	cdesenti varchar(100) NULL, " +
                    "	ccodtipent char(3) NULL, " +
                    "	ccodruc char(15) NULL, " +
                    "	crazsoc char(150) NULL, " +
                    "	cdirecc varchar(250) NULL, " +
                    "	ccodubi char(6) NULL, " +
                    "	ccodcontac char(3) NULL, " +
                    "	cdescontacto char(150) NULL, " +
                    "	ffecha date NULL, " +
                    "	ffechaven date NULL, " +
                    "	ffechaalm date NULL, " +
                    "	ccodpag char(2) NULL, " +
                    "	cmoneda char(1) NULL, " +
                    "	ntcigv numeric(10, 6) NULL, " +
                    "	cguiaser char(7) NULL, " +
                    "	cguianum char(13) NULL, " +
                    "	mdsc text NULL, " +
                    "	ccodvend char(4) NULL, " +
                    "	ccodclas char(1) NULL, " +
                    "	ccodocon char(4) NULL, " +
                    "	cnumordc char(20) NULL, " +
                    "	crefdoc char(2) NULL, " +
                    "	freffec date NULL, " +
                    "	crefser char(10) NULL, " +
                    "	crefnum char(13) NULL, " +
                    "	ccat09 char(2) NULL, " +
                    "	cmotinc char(50) NULL, " +
                    "	nresp numeric(1, 0) NULL, " +
                    "	ccodpds char(5) NULL, " +
                    "	nporre numeric(5, 2) NULL, " +
                    "	ffecre date NULL, " +
                    "	cnumdere char(15) NULL, " +
                    "	ccodpps char(2) NULL, " +
                    "	nporre2 numeric(5, 2) NULL, " +
                    "	nperdenre numeric(1, 0) NULL, " +
                    "	nbase1 numeric(15, 2) NULL, " +
                    "	nigv1 numeric(15, 2) NULL, " +
                    "	nbase2 numeric(15, 2) NULL, " +
                    "	nigv2 numeric(15, 2) NULL, " +
                    "	nbase3 numeric(15, 2) NULL, " +
                    "	nigv3 numeric(15, 2) NULL, " +
                    "	nimpicbper numeric(15, 2) NULL, " +
                    "	nina numeric(15, 2) NULL,   \n" +
                    "	nexo numeric(15, 2) NULL,   \n" +
                    "	nisc numeric(15, 2) NULL,   \n" +
                    "	nivabase numeric(15, 2) NULL,   \n" +
                    "	nivaimp numeric(15, 2) NULL,   \n" +
                    "	nimpant numeric(15, 2) NULL,   \n" +
                    "	ntot numeric(15, 2) NULL,   \n" +
                    "   created_at datetime DEFAULT getdate(),      \n" +
                    "	updated_at datetime NULL,   \n" +
                    "	estado varchar(255) NULL,   \n" +
                    "	en_ambiente_de varchar(255) NULL,   \n" +
                    "	es_con_migracion numeric(1, 0)  DEFAULT (0),\n" +
                    "	ccodcos3 nchar(15) NULL,   \n" +
                    "	obserror text DEFAULT '') ";
                        SqlCommand myCommand = new SqlCommand(cabeceracomercial, conex);
                        try
                        {
                            myCommand.ExecuteNonQuery();
                            FrmCrearTablas.instance.timer1.Enabled = true;
                            conex.Close();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp.en Comercial Cabecera", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Ya existe la tabla.", "Contasis Corp.en Ventas", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        FrmCrearTablas.instance.timer1.Enabled = false;
                    }
                }
            }

        }
        public void creardetallecomercial(string _cadena)
        {
            cadena = _cadena;
            if (cadena == "")
            {
                MessageBox.Show("No se establece la conexión, ingrese las credenciales.", "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                String strdetallecomercial;
                SqlConnection conex1 = new SqlConnection(cadena);
                try
                {
                    conex1.Open();
                }
                catch
                {
                    MessageBox.Show("No se establece la conexión revise  usuario y clave ", "Contasis Corp. error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /** aca vamos a Verificar si Existe la tabla Contasis    **/
                string verifica = "SELECT* FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'com_detalledocumento'";
                SqlCommand comando1 = new SqlCommand(verifica, conex1);
                {
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(comando1);

                    da1.Fill(dt1);
                    if (dt1.Rows.Count == 0)
                    {

                        strdetallecomercial = "CREATE TABLE com_detalledocumento( \n" +
                    "	iddetalledocumento int identity(1,1) primary key not null, \n" +
                    "	ccodalma char(3) NULL, \n" +
                    "	ccodprod char(20) NULL, \n" +
                    "	ccodmed char(15) NULL, \n" +
                    "	ccodlote char(20) NULL, \n" +
                    "   ffecfablote date NULL,\n" +
                    "   ffecvenlote date NULL,\n" +
                    "	nuniori numeric(20, 10) NULL, \n" +
                    "	nvvori numeric(20, 10) NULL, \n" +
                    "	npvori numeric(20, 10) NULL, \n" +
                    "	nvalor numeric(15, 2) NULL, \n" +
                    "	nigvtot numeric(15, 2) NULL, \n" +
                    "	ntotori numeric(15, 2) NULL, \n" +
                    "	npigv numeric(5, 2) NULL, \n" +
                    "	ccodcos char(9) NULL, \n" +
                    "	ccodcos2 char(9) NULL, \n" +
                    "	ccodpresu char(10) NULL, \n" +
                    "	cctaprod char(20) NULL, \n" +
                    "	npordscu numeric(15, 2) NULL, \n" +
                    "	ndsctos numeric(15, 2) NULL, \n" +
                    "	ccodisc char(5) NULL, \n" +
                    "	nporisc numeric(5, 2) NULL, \n" +
                    "	nisc numeric(15, 2) NULL, \n" +
                    "	tipo_isc numeric(1, 0) NULL, \n" +
                    "	mdscl text NULL, \n" +
                    "	iddocumento int NOT NULL \n" +
                    "   constraint fk_detalle_documento FOREIGN KEY (iddocumento) references com_documento(iddocumento) ) ";
                        SqlCommand myCommand1 = new SqlCommand(strdetallecomercial, conex1);
                        try
                        {
                            myCommand1.ExecuteNonQuery();
                            FrmCrearTablas.instance.timer2.Enabled = true;
                            conex1.Close();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. detalle comercial", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe la tabla.", "Contasis Corp. comercial", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        FrmCrearTablas.instance.timer2.Enabled = false;
                    }
                }
            }

        }
        public void crearproductocomercial(string _cadena)
        {
            cadena = _cadena;
            if (cadena == "")
            {
                MessageBox.Show("No se establece la conexión, ingrese las credenciales ", "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                
                String strproducto;
                SqlConnection conex2 = new SqlConnection(cadena);
                try
                {
                    conex2.Open();
                }
                catch
                {
                    MessageBox.Show("No se establece la conexión revise sus credenciales ", "Contasis Corp. error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                /** aca vamos a Verificar si Existe la tabla Contasis    **/
                string verifica2 = "SELECT* FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'com_producto'";
                SqlCommand comando2 = new SqlCommand(verifica2, conex2);
                {
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(comando2);

                    da2.Fill(dt2);
                    if (dt2.Rows.Count == 0)
                    {
                        try
                        {

                            /*****/
                    strproducto = "CREATE TABLE com_producto( \n" +
                    "   idproducto int identity(1,1) primary key not null,\n" +
                    "   ccodrucemisor char(15),\n" +
                    "   ccod_empresa char(3),\n" +
                    "   cper char(4),\n" +
                    "   cmes char(2),\n" +
                    "	ccodfamg char(20) NULL,\n" +
                    "	cdesfamg char(50) NULL,\n" +
                    "	ccodfamf char(20) NULL,\n" +
                    "	cdesfamf char(50) NULL,\n" +
                    "	ccodprod char(20) NULL,\n" +
                    "	cdesprod char(150) NULL,\n" +
                    "	cdesprodGen varchar(500) NULL,\n" +
                    "	ccodtes char(2) NULL,\n" +
                    "   ccodmar character(4) NULL, \n"+
                    "	cdesmar char(80) NULL,\n" +
                    "	ccodmed char(15) NULL,\n" +
                    "   ccodums char(3) NULL,\n"+
                    "	ccodcatbs char(8) NULL,\n" +
                    "	cdescatbs char(100) NULL,\n" +
                    "	ntipoprod char(8) NULL,\n" +
                    "	nunidsec char(2) NULL,\n" +
                    "	npesoprod numeric(10, 4) NULL,\n" +
                    "	ccodbarras char(15) NULL,\n" +
                    "	ninprod char(2) NULL,\n" +
                    "	nanuprod char(2) NULL,\n" +
                    "	nlote char(2) NULL,\n" +
                    "	nseruni char(2) NULL,\n" +
                    "	nicbper char(2) NULL,\n" +
                    "	nprodanti char(2) NULL,\n" +
                    "	ngasrela char(2) NULL,\n" +
                    "	nprodsafniif char(2) NULL,\n" +
                    "	ccomcue char(20) NULL,\n" +
                    "	cvencue char(20) NULL,\n" +
                    "	cdebicue char(20) NULL,\n" +
                    "	ccredcue char(20) NULL,\n" +
                    "	cdebicuei char(20) NULL,\n" +
                    "	ccredcuei char(20) NULL,\n" +
                    "	ccodcos char(9) NULL,\n" +
                    "	ccodcos2 char(9) NULL,\n" +
                    "	ccodpresu char(10) NULL,\n" +
                    "	ccomprod char(1) NULL,\n" +
                    "	cvenprod char(1) NULL,\n" +
                    "	ccodisc char(5) NULL,\n" +
                    "	cmoneda char(1) NULL,\n" +
                    "	npreunit1 numeric(15, 4) NULL,\n" +
                    "	npreunit2 numeric(15, 4) NULL,\n" +
                    "	npreunit3 numeric(15, 4) NULL,\n" +
                    "	npreunit4 numeric(15, 4) NULL,\n" +
                    "	npreunit5 numeric(15, 4) NULL,\n" +
                    "	npreunit6 numeric(15, 4) NULL,\n" +
                    "	npreunit7 numeric(15, 4) NULL,\n" +
                    "	npreunit8 numeric(15, 4) NULL,\n" +
                    "	npreunit9 numeric(15, 4) NULL,\n" +
                    "	npreunit10 numeric(15, 4) NULL,\n" +
                    "	npreunit11 numeric(15, 4) NULL,\n" +
                    "	npreunit12 numeric(15, 4) NULL,\n" +
                    "	npreunit13 numeric(15, 4) NULL,\n" +
                    "	npreunit14 numeric(15, 4) NULL,\n" +
                    "	npreunit15 numeric(15, 4) NULL,\n" +
                    "	nstockmin numeric(15, 4) NULL,\n" +
                    "	nstockmax numeric(15, 4) NULL,\n" +
                    "	nrango1 numeric(15, 0) NULL,\n" +
                    "	nrango2 numeric(15, 0) NULL,\n" +
                    "	nresp numeric(1, 0) NULL,\n" +
                    "	ccodpps char(2) NULL,\n" +
                    "	ccodpds char(5) NULL,\n" +
                    "	nagemonmin numeric(15, 2) NULL,\n" +
                    "	ccodlabora char(4) NULL,\n" +
                    "	cdeslabora char(60) NULL,\n" +
                    "	created_at datetime NULL,\n" +
                    "	updated_at datetime NULL,\n" +
                    "	estado varchar(255) NULL,\n" +
                    "	en_ambiente_de varchar(255) NULL,\n" +
                    "	es_con_migracion numeric(1, 0) NULL,\n" +
                    "	ccodcos3 nchar(15) NULL,\n" +
                    "	obserror text )   ";
                            SqlCommand myCommand31 = new SqlCommand(strproducto, conex2);
                        myCommand31.ExecuteNonQuery();
                        FrmCrearTablas.instance.timer6.Enabled = true;
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. producto comercial.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        /** linea final para despues de crear todo**/
                        conex2.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe las tablas de comercial", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        FrmCrearTablas.instance.timer6.Enabled = false;
                    }
                }

            }
        }
        public void creartablasdelsistema(string _cadena)
        {
            cadena = _cadena;
            if (cadena == "")
            {
                MessageBox.Show("No se establece la conexión, ingrese las credenciales ", "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                string stremp;
                string strusuario;
                string sconfigura;
                string stmodulo;
                string strusuarioacceso;
                string strlog;
                string funcion1;
                string funcion2;
                string funcion3;
                SqlConnection conex2 = new SqlConnection(cadena);
                try
                {
                    conex2.Open();
                }
                catch
                {
                    MessageBox.Show("No se establece la conexión revise sus credenciales ", "Contasis Corp. error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                /** aca vamos a Verificar si Existe la tabla Contasis    **/
                string verifica2 = "SELECT* FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'CG_EMPRESA'";
                SqlCommand comando2 = new SqlCommand(verifica2, conex2);
                {
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter da2 = new SqlDataAdapter(comando2);

                    da2.Fill(dt2);
                    if (dt2.Rows.Count == 0)
                    {
                        /*****/
                        strlog = "CREATE TABLE cg_log(id INT IDENTITY(1,1)," +
                        "tipo_error TEXT NULL," +
                        "error_mensaje TEXT NULL," +
                        "fechahora datetime default Getdate()," +
                        "PRIMARY KEY CLUSTERED(id  ASC) )";

                        SqlCommand myCommand31 = new SqlCommand(strlog, conex2);
                        try
                        {
                            myCommand31.ExecuteNonQuery();
                            FrmCrearTablas.instance.timer4.Enabled = true;

                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. LOG de Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }

                        /******/

                        stremp = "CREATE TABLE cg_empresa(ccodrucemisor character(15)," +
                            "ccod_empresa character(3),nomempresa character(80))  ";

                        SqlCommand myCommand2 = new SqlCommand(stremp, conex2);
                        try
                        {
                            myCommand2.ExecuteNonQuery();
                            

                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. Empresa", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        strusuario = "CREATE TABLE cg_usuario(ccodusu character(10) NOT NULL DEFAULT ''," +
                                    "cdesusu character(60) NOT NULL DEFAULT ''," +
                                    "password character(250) NOT NULL DEFAULT ''," +
                                    "fec_ultacceso datetime default getdate(),PRIMARY KEY CLUSTERED(ccodusu  ASC) )";

                        SqlCommand myCommand3 = new SqlCommand(strusuario, conex2);
                        try
                        {
                            myCommand3.ExecuteNonQuery();

                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. Usuario", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        /***************************************************************/
                        sconfigura = "CREATE TABLE configuracion(ccod_empresa Char(3) null," +
                        "cper char(4) null," +
                        "crazemp char(100) null," +
                        "crucemp char(15) null," +
                        "cEntidad char(3) null," +
                        "csub1_vta char(3) null," +
                        "clreg1_vta char(20) null," +
                        "csub2_vta char(3) null," +
                        "clreg2_vta  char(20) null,cconts_vta  char(20) null,ccontd_vta  char(20) null," +
                        "cfefec_vta char(4),ctares_vta numeric(1,0),ctaimp_vta numeric(1,0) ,Ctaact_vta numeric(1,0)," +
                        "asientos_vta numeric(1,0)," +
                        "csub1_com char(3) null," +
                        "clreg1_com char(20) null," +
                        "csub2_com char(3) null," +
                        "clreg2_com  char(20) null,cconts_com  char(20) null,ccontd_com  char(20) null," +
                        "cfefec_com char(4),ctares_com numeric(1,0),ctaimp_com numeric(1,0) ,Ctapas_com numeric(1,0), asientos_com numeric(1,0)," +
                        "cTipo char(2) null,cEnt_anula char(15) null)";
                        SqlCommand myCommand4 = new SqlCommand(sconfigura, conex2);
                        try
                        {
                            myCommand4.ExecuteNonQuery();

                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. configuracion ctas.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }

                        /*****************************************************************************************************/
                        sconfigura = " CREATE TABLE configuracion2( " +
                                     "id int identity(1,1), " +
                                    "ccod_empresa char(3) NULL, " +
                                    "cper char(4) NULL, " +
                                    "crazemp char(100) NULL, " +
                                    "crucemp char(15) NULL, " +
                                    "Entidad char(3) NULL, " +
                                    "Tipo char(5) NULL, " +
                                    "codtipdocu char(4) NULL, " +
                                    "cserie char(20) NULL, " +
                                    "ccodmov char(10) NULL, " +
                                    "ccodpag char(5) NULL, " +
                                    "ccodvend char(10) NULL, " +
                                    "ccodalma char(10) NULL, " +
                                    "Ent_anula char(15) NULL, " +
                                    "Prodanula char(15) NULL)";
                       SqlCommand myCommand41 = new SqlCommand(sconfigura, conex2);
                        try
                        {
                            myCommand41.ExecuteNonQuery();

                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. configuracion ctas.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        stmodulo = "CREATE TABLE cg_modulos(ccodmod character(10),cdesmod character(100))";
                        SqlCommand myCommand5 = new SqlCommand(stmodulo, conex2);
                        try
                        {
                            myCommand5.ExecuteNonQuery();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. Modulo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }

                        /*****************************************************************************************************/
                        string modulocomer = "create table modulo_comercial( " +
                        "ccodmudulo Char(6) null, " +
                        "cdesmodulo char(50) null)";
                        SqlCommand myCommand041 = new SqlCommand(modulocomer, conex2);
                        try
                        {
                            myCommand041.ExecuteNonQuery();

                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. configuracion ctas.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        /*****************************************************************************************************/
                        sconfigura = "create table cg_empemisor(" +
                        "ccodrucemisor char(15) NOT NULL, " +
                        "cdesrucemisor char(200) NULL," +
                        "flgActivo bit NULL, nventaflg  int NOT NULL,ncompraflg int NOT NULL, " +
                        "ncobranzaflg int NOT NULL,npagoflg int NOT NULL," +
                        "ncomproductoflg int NOT NULL,ncomcompraflg  int NOT NULL," +
                        "ncomventaflg  int NOT NULL," +
                        "PRIMARY KEY CLUSTERED " +
                        " (ccodrucemisor  ASC))";
                        SqlCommand myCommand04 = new SqlCommand(sconfigura, conex2);
                        try
                        {
                            myCommand04.ExecuteNonQuery();

                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. configuracion  .", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        /*********************************************************************************************/

                        stmodulo = "INSERT INTO cg_modulos(CCODMOD,CDESMOD) VALUES('00001','EMPRESAS');" +
                        "INSERT INTO CG_MODULOS(CCODMOD, CDESMOD) VALUES('00002', 'ACCESO A USUARIOS');" +
                        "INSERT INTO CG_MODULOS(CCODMOD, CDESMOD) VALUES('00003', 'ORIGEN DE DATOS'); " +
                        "INSERT INTO CG_MODULOS(CCODMOD, CDESMOD) VALUES('00004', 'ESTRUCTURA DE DATOS'); " +
                        "INSERT INTO CG_MODULOS(CCODMOD, CDESMOD) VALUES('00005', 'INTEGRADO CONTABLE'); " +
                        "INSERT INTO CG_MODULOS(CCODMOD, CDESMOD) VALUES('00006', 'FINANCIERO'); " +
                        "INSERT INTO CG_MODULOS(CCODMOD, CDESMOD) VALUES('00007', 'INTEGRADO COMERCIAL SQL'); " +
                        "INSERT INTO CG_MODULOS(CCODMOD, CDESMOD) VALUES('00008', 'ACCESO A PERMISOS');" +
                        "INSERT INTO CG_MODULOS(CCODMOD, CDESMOD) VALUES('00009', 'ACCESO A RUC EMISOR');" +
                        "INSERT INTO CG_MODULOS(CCODMOD, CDESMOD) VALUES('00010', 'DESTINO DE DATOS');" +
                        "INSERT INTO CG_MODULOS(CCODMOD, CDESMOD) VALUES('00011', 'NUBE - NEGOCIOS ONLINE');";



                        SqlCommand myCommand51 = new SqlCommand(stmodulo, conex2);
                        try
                        {
                            myCommand51.ExecuteNonQuery();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. Modulo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        strusuarioacceso = "CREATE TABLE cg_usuario_acceso(ccodusu character(10) not null DEFAULT ''," +
                                 "ccodmod  character(10) not null DEFAULT ''," +
                                 "flgacceso NUMERIC(1,0) default 0)";

                        SqlCommand myCommand6 = new SqlCommand(strusuarioacceso, conex2);
                        try
                        {
                            myCommand6.ExecuteNonQuery();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. Usuario con Acceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        stmodulo = "CREATE TRIGGER INSER_USUARIO_ACCESOS " +
                                    " ON CG_USUARIO " +
                                    " AFTER INSERT " +
                                    " AS " +
                                    " BEGIN " +
                                    " DECLARE @USUARIO AS CHAR(10) " +
                                    " SET @USUARIO = (SELECT MAX(CCODUSU) FROM CG_usuario) " +
                                    " IF EXISTS(SELECT* FROM CG_USUARIO_ACCESO WHERE CCODUSU= @USUARIO) " +
                                    " RETURN; " +
                                    " ELSE " +
                                    "  INSERT CG_USUARIO_ACCESO(ccodusu, CCODMOD, FLGACCESO) " +
                                    " SELECT @USUARIO, CCODMOD,0 AS FLGACCESO FROM CG_MODULOS " +
                                    " END ";


                        SqlCommand myCommand52 = new SqlCommand(stmodulo, conex2);
                        try
                        {
                            myCommand52.ExecuteNonQuery();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. Creacion de  Trigger", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }

                        /********************************************************************/
                        string tabletype = "CREATE TYPE dbo.tp_resultado AS TABLE (" +
                                   "id INT," +
                                   "obserror NVARCHAR(MAX)," +
                                   "es_con_migracion INT," +
                                   "resultado_migracion INT);";
                        SqlCommand myCommand440 = new SqlCommand(tabletype, conex2);
                        try
                        {
                            myCommand440.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe el tp_resultado.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        /**************************************************/
                        string tabletype2 = "CREATE TYPE tp_id AS TABLE(  \n" +
                        " id int )";
                        SqlCommand myCommand430 = new SqlCommand(tabletype2, conex2);
                        try
                        {
                            myCommand430.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe el tp_resultado.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }


                        /****************************************************************/
                        funcion1 = "CREATE FUNCTION fn_documento_envio(   \n" +
                                    "    @prucEmisor char(15), \n" +
                                    "    @empresa char(3), \n" +
                                    "    @tipo char(5) \n" +
                                    ") RETURNS TABLE \n" +
                                    "AS \n" +
                                    "RETURN( \n" +
                                    "    select \n" +
                                    "        top 500-- los detalles elevaran el numero de filas devueltas \n" +
                                    "        d.iddocumento, \n" +
                                    "        d.ccod_empresa, \n" +
                                    "        d.cper, \n" +
                                    "        d.cmes, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodmodulo, ''))) as ccodmodulo, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodmov, ''))) as ccodmov, \n" +
                                    "        ltrim(rtrim(isnull(d.ccoddoc, ''))) as ccoddoc, \n" +
                                    "        ltrim(rtrim(isnull(d.cserie, ''))) as cserie, \n" +
                                    "        ltrim(rtrim(isnull(d.cnumero, ''))) as cnumero, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodenti, ''))) as ccodenti, \n" +
                                    "        ltrim(rtrim(isnull(d.cdesenti, ''))) as cdesenti, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodtipent, ''))) as ccodtipent, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodruc, ''))) as ccodruc, \n" +
                                    "        ltrim(rtrim(isnull(d.crazsoc, ''))) as crazsoc, \n" +
                                    "        ltrim(rtrim(isnull(d.cdirecc, ''))) as cdirecc, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodubi, ''))) as ccodubi, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodcontac, ''))) as ccodcontac, \n" +
                                    "        ltrim(rtrim(isnull(d.cdescontacto, ''))) as cdescontacto, \n" +
                                    "        d.ffecha, \n" +
                                    "        d.ffechaven, \n" +
                                    "        d.ffechaalm, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodpag, ''))) as ccodpag, \n" +
                                    "        ltrim(rtrim(isnull(d.cmoneda, ''))) as cmoneda, \n" +
                                    "        isnull(d.ntcigv, 0.00) as ntcigv, \n" +
                                    "        ltrim(rtrim(isnull(d.cguiaser, ''))) as cguiaser, \n" +
                                    "        ltrim(rtrim(isnull(d.cguianum, ''))) as cguianum, \n" +
                                    "        ltrim(rtrim(isnull(cast(d.mdsc as varchar(max)), ''))) as mdsc, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodvend, ''))) as ccodvend, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodclas, ''))) as ccodclas, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodocon, ''))) as ccodocon, \n" +
                                    "        ltrim(rtrim(isnull(d.cnumordc, ''))) as cnumordc, \n" +
                                    "        ltrim(rtrim(isnull(d.crefdoc, ''))) as crefdoc, \n" +
                                    "        d.freffec, \n" +
                                    "        ltrim(rtrim(isnull(d.crefser, ''))) as crefser, \n" +
                                    "        ltrim(rtrim(isnull(d.crefnum, ''))) as crefnum, \n" +
                                    "        ltrim(rtrim(isnull(d.ccat09, ''))) as ccat09, \n" +
                                    "        ltrim(rtrim(isnull(d.cmotinc, ''))) as cmotinc, \n" +
                                    "        isnull(d.nresp, 0.00) as nresp, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodpds, ''))) as ccodpds, \n" +
                                    "        isnull(d.nporre, 0.00) as nporre, \n" +
                                    "        d.ffecre, \n" +
                                    "        ltrim(rtrim(isnull(d.cnumdere, ''))) as cnumdere, \n" +
                                    "        ltrim(rtrim(isnull(d.ccodpps, ''))) as ccodpps, \n" +
                                    "        isnull(d.nporre2, 0.00) as nporre2, \n" +
                                    "        isnull(d.nperdenre, 0.00) as nperdenre,  \n" +
                                    "        isnull(d.nbase1, 0.00) as nbase1, \n" +
                                    "        isnull(d.nigv1, 0.00) as nigv1, \n" +
                                    "        isnull(d.nbase2, 0.00) as nbase2, \n" +
                                    "        isnull(d.nigv2, 0.00) as nigv2, \n" +
                                    "        isnull(d.nbase3, 0.00) as nbase3, \n" +
                                    "        isnull(d.nigv3, 0.00) as nigv3, \n" +
                                    "        isnull(d.nimpicbper, 0.00) as nimpicbper, \n" +
                                    "        isnull(d.nina, 0.00) as nina, \n" +
                                    "        isnull(d.nexo, 0.00) as nexo, \n" +
                                    "        isnull(d.nisc, 0.00) as nisc, \n" +
                                    "        isnull(d.nivabase, 0.00) as nivabase, \n" +
                                    "        isnull(d.nivaimp, 0.00) as nivaimp, \n" +
                                    "        isnull(d.nimpant, 0.00) as nimpant, \n" +
                                    "        isnull(d.ntot, 0.00) as ntot, \n" +
                                    "        isnull(d.en_ambiente_de, '!') as en_ambiente_de, \n" +
                                    "        isnull(d.es_con_migracion, 0) as es_con_migracion, \n" +
                                    "		case when ltrim(rtrim(isnull(d.estado, ''))) = '' then '' else ltrim(rtrim(d.estado))  end as estado,  \n" +
                                    "		case when ltrim(rtrim(isnull(d.ccodcos3,''))) = '' then '' else ltrim(rtrim(d.ccodcos3))  end as ccodcos3, \n" +
                                    "		case when d.es_con_migracion = 3 then ltrim(rtrim(c.Ent_anula))  else '' end as ccodrucanula, \n" +
                                    "		case when d.es_con_migracion = 3 then 1 else 0 end as nflgexisteanular \n" +
                                    "    from com_documento d \n" +
                                    "    inner \n" +
                                    "    join configuracion2 c \n" +
                                    "    on d.ccod_empresa = c.ccod_empresa and d.ccodrucemisor = crucemp \n" +
                                    "        and d.ccodmodulo = c.Tipo \n" +
                                    "        and d.ccodmov = c.ccodmov \n" +
                                    "        and( \n" +
                                    "            (@tipo = 'VENTA' and right((replicate('0', 20) + ltrim(rtrim(d.cserie))), 20) = right((replicate('0', 20) + ltrim(rtrim(c.cserie))), 20)) \n" +
                                    "            or(@tipo <> 'VENTA') \n" +
                                    "        )	where d.es_con_migracion in (0, 3) \n" +
                                    "        and d.ccodrucemisor = @prucEmisor \n" +
                                    "        and d.ccod_empresa = @empresa \n" +
                                    "        and d.ccodmodulo = @tipo);";
                        SqlCommand myCommand520 = new SqlCommand(funcion1, conex2);
                        try
                        {
                            myCommand520.ExecuteNonQuery();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. Creacion de  FUNCTION fn_documento_envio", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        /****************************************************************/
                        funcion2 = "CREATE FUNCTION fn_detalledocumento_envio(  \n" +
                        " @iddocumentos dbo.tp_id READONLY  \n" +
                        ") RETURNS TABLE \n" +
                        " AS \n" +
                        " RETURN( \n" +
                        " select * \n" +
                        " from com_detalledocumento d \n" +
                        " inner join @iddocumentos ids on d.iddocumento = ids.id);";
                        SqlCommand myCommand521 = new SqlCommand(funcion2, conex2);
                        try
                        {
                            myCommand521.ExecuteNonQuery();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. Creacion de  FUNCTION fn_detalledocumento_envio", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        funcion3 = "CREATE FUNCTION fn_productos_envio(  \n" +
                                "  @prucEmisor char(15),      \n" +
                                " @empresa char(3)  \n" +
                                ") RETURNS TABLE  \n" +
                                " AS  \n" +
                                " RETURN(  \n" +
                                "  \n" +
                                " select top 1000  \n" +
                                "    p.idproducto,  \n" +
                                "    p.ccod_empresa, p.cper, p.cmes,  \n" +
                                "    ltrim(rtrim(p.ccodfamg)) as ccodfamg,  \n" +
                                "    ltrim(rtrim(p.cdesfamg)) as cdesfamg,  \n" +
                                "    ltrim(rtrim(p.ccodfamf)) as ccodfamf,  \n" +
                                "    ltrim(rtrim(p.cdesfamf)) as cdesfamf,  \n" +
                                "    ltrim(rtrim(p.ccodprod)) as ccodprod,  \n" +
                                "    ltrim(rtrim(p.cdesprod)) as cdesprod,  \n" +
                                "    ltrim(rtrim(p.ccodtes)) as ccodtes,  \n" +
                                "    ltrim(rtrim(p.ccodmar)) as ccodmar,  \n" +
                                "    ltrim(rtrim(p.cdesmar)) as cdesmar,  \n" +
                                "    ltrim(rtrim(p.ccodmed)) as ccodmed,  \n" +
                                "    ltrim(rtrim(p.ccodums)) as ccodums,  \n" +
                                "    ltrim(rtrim(p.ccodcatbs)) as ccodcatbs,  \n" +
                                "    ltrim(rtrim(p.cdescatbs)) as cdescatbs,  \n" +
                                "    ltrim(rtrim(p.ntipoprod)) as ntipoprod,  \n" +
                                "    ltrim(rtrim(p.nunidsec)) as nunidsec,  \n" +
                                "    isnull(p.npesoprod, 0.0) as npesoprod,  \n" +
                                "    ltrim(rtrim(p.ccodbarras)) as ccodbarras,  \n" +
                                "    ltrim(rtrim(p.ninprod)) as ninprod,  \n" +
                                "    ltrim(rtrim(p.nanuprod)) as nanuprod,  \n" +
                                "    ltrim(rtrim(p.nlote)) as nlote,  \n" +
                                "    ltrim(rtrim(p.nseruni)) as nseruni,  \n" +
                                "    ltrim(rtrim(p.nicbper)) as nicbper,  \n" +
                                "    ltrim(rtrim(p.nprodanti)) as nprodanti,  \n" +
                                "    ltrim(rtrim(p.ngasrela)) as ngasrela,  \n" +
                                "    ltrim(rtrim(p.nprodsafniif)) as nprodsafniif,  \n" +
                                "    ltrim(rtrim(p.ccomcue)) as ccomcue,  \n" +
                                "    ltrim(rtrim(p.cvencue)) as cvencue,  \n" +
                                "    ltrim(rtrim(p.cdebicue)) as cdebicue,  \n" +
                                "    ltrim(rtrim(p.ccredcue)) as ccredcue,  \n" +
                                "    ltrim(rtrim(p.cdebicuei)) as cdebicuei,  \n" +
                                "    ltrim(rtrim(p.ccredcuei)) as ccredcuei,  \n" +
                                "    ltrim(rtrim(p.ccodcos)) as ccodcos,  \n" +
                                "    ltrim(rtrim(p.ccodcos2)) as ccodcos2,  \n" +
                                "    ltrim(rtrim(p.ccodpresu)) as ccodpresu,  \n" +
                                "    ltrim(rtrim(p.ccomprod)) as ccomprod,  \n" +
                                "    ltrim(rtrim(p.cvenprod)) as cvenprod,  \n" +
                                "    ltrim(rtrim(p.ccodisc)) as ccodisc,  \n" +
                                "    ltrim(rtrim(p.cmoneda)) as cmoneda,  \n" +
                                "    isnull(p.npreunit1, 0.0) as npreunit1,  \n" +
                                "    isnull(p.npreunit2, 0.0) as npreunit2,  \n" +
                                "    isnull(p.npreunit3, 0.0) as npreunit3,  \n" +
                                "    isnull(p.npreunit4, 0.0) as npreunit4,  \n" +
                                "    isnull(p.npreunit5, 0.0) as npreunit5,  \n" +
                                "    isnull(p.npreunit6, 0.0) as npreunit6,  \n" +
                                "    isnull(p.npreunit7, 0.0) as npreunit7,  \n" +
                                "    isnull(p.npreunit8, 0.0) as npreunit8,  \n" +
                                "    isnull(p.npreunit9, 0.0) as npreunit9,  \n" +
                                "    isnull(p.npreunit10, 0.0) as npreunit10,  \n" +
                                "    isnull(p.npreunit11, 0.0) as npreunit11,  \n" +
                                "    isnull(p.npreunit12, 0.0) as npreunit12,  \n" +
                                "    isnull(p.npreunit13, 0.0) as npreunit13,  \n" +
                                "    isnull(p.npreunit14, 0.0) as npreunit14,  \n" +
                                "    isnull(p.npreunit15, 0.0) as npreunit15,  \n" +
                                "    isnull(p.nstockmin, 0.0) as nstockmin,  \n" +
                                "    isnull(p.nstockmax, 0.0) as nstockmax,  \n" +
                                "    isnull(p.nrango1, 0.0) as nrango1,  \n" +
                                "    isnull(p.nrango2, 0.0) as nrango2,  \n" +
                                "    isnull(p.nresp, 0.0) as nresp,  \n" +
                                "    ltrim(rtrim(p.ccodpps)) as ccodpps,  \n" +
                                "    ltrim(rtrim(p.ccodpds)) as ccodpds,  \n" +
                                "    isnull(p.nagemonmin, 0.0) as nagemonmin,  \n" +
                                "    ltrim(rtrim(p.ccodlabora)) as ccodlabora,  \n" +
                                "    ltrim(rtrim(p.cdeslabora)) as cdeslabora,  \n" +
                                "    ----  \n" +
                                "    isnull(en_ambiente_de, '!') as en_ambiente_de,  \n" +
                                "    isnull(es_con_migracion, 0) as es_con_migracion,  \n" +
                                "	case when ltrim(rtrim(isnull(estado, ''))) = '' then '' else ltrim(rtrim(estado))  end as estado,  \n" +
                                "	case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then '' else ltrim(rtrim(ccodcos3))  end as ccodcos3  \n" +
                                "                     \n" +
                                "  --case when es_con_migracion = 3  then ltrim(rtrim(c.cEnt_anula))  else '' end as ccodrucanula  \n" +
                                " from com_producto p  \n" +
                                " where p.ccodrucemisor = @prucEmisor   \n" +
                                " and p.ccod_empresa = @empresa   \n" +
                                " and p.es_con_migracion in (0, 3)); ";
                        SqlCommand myCommand522 = new SqlCommand(funcion3, conex2);
                        try
                        {
                            myCommand522.ExecuteNonQuery();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. Creacion de  FUNCTION fn_productos_envio", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }

                        /** linea final para despues de crear todo**/
                        conex2.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe las tablas de Proceso", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        FrmCrearTablas.instance.timer4.Enabled = false;
                    }
                }

            }
        }
        public void crearotros(string _cadena)
         {
             cadena = _cadena;
             if (cadena == "")
             {
                 MessageBox.Show("No se establece la conexión, ingrese las credenciales ", "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }
             else
             {
                 string strindex;
                 string version01;
                 string version02;
                 string version03;
                 string version04;
                 string sp_producto_envio_resultado;
                 string sp_documento_envio_resultado;

                 SqlConnection conex2 = new SqlConnection(cadena);
                 try
                 {
                     conex2.Open();
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("No se establece la conexión : " + ex.Message, "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 string verifica2 = "SELECT * FROM SYSindexes where name='claveEmpresa'";
                 SqlCommand comando2 = new SqlCommand(verifica2, conex2);
                 {
                     DataTable dt2 = new DataTable();
                     SqlDataAdapter da2 = new SqlDataAdapter(comando2);

                     da2.Fill(dt2);
                     if (dt2.Rows.Count == 0)
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
                         strindex = " CREATE  INDEX ClaveConfig ON configuracion (ccod_empresa ASC, cper ASC) ";
                         SqlCommand myCommand21 = new SqlCommand(strindex, conex2);
                         try
                         {
                             myCommand21.ExecuteNonQuery();
                         }
                         catch (System.Exception ex)
                         {
                             MessageBox.Show(ex.ToString(), "Contasis Corp. Index configuracion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                         version01 = "create table cg_version (" +
                                     " cversion varchar(15) not null, " +
                                     " cfecha datetime2 default GETDATE() not null,);";
                         SqlCommand myCommand40 = new SqlCommand(version01, conex2);
                         try
                         {
                             myCommand40.ExecuteNonQuery();
                            FrmCrearTablas.instance.timer3.Enabled = true;
                        }
                         catch
                         {
                             MessageBox.Show("Ya existe la tabla de versión.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                         }
                         version02 = "create procedure sp_select_version as \n" +
                                     " begin  \n" +
                                     " select cversion   \n" +
                                     " From dbo.cg_version   \n" +
                                     " end; ";

                         SqlCommand myCommand41 = new SqlCommand(version02, conex2);
                         try
                         {
                             myCommand41.ExecuteNonQuery();
                         }
                         catch
                         {
                             MessageBox.Show("Ya existe el sp_select_version.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                         }
                         version03 = "create procedure dbo.sp_actualizar_version  \n" +
                                     " @p_version varchar(15)  \n" +
                                     " as  \n" +
                                     " begin  \n" +
                                     " if exists(select 1 from cg_version)  \n" +
                                     " begin  \n" +
                                     " update cg_version  \n" +
                                     " set cversion = @p_version, cfecha = GETDATE();  \n" +
                                     " end  \n" +
                                     " else  \n" +
                                     " begin  \n" +
                                     " insert into cg_version(cversion)  \n" +
                                     " values(@p_version); \n" +
                                     " end  \n" +
                                     "  end; ";
                         SqlCommand myCommand42 = new SqlCommand(version03, conex2);
                         try
                         {
                             myCommand42.ExecuteNonQuery();
                         }
                         catch
                         {
                             MessageBox.Show("Ya existe el sp_actualizar_version.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                         }
                         version04 = "CREATE TABLE test( \n" +
                                     "  test_id int NOT NULL, \n" +
                                     " test_nombre char(50) NOT NULL)";
                         SqlCommand myCommand43 = new SqlCommand(version04, conex2);
                         try
                         {
                             myCommand43.ExecuteNonQuery();
                         }
                         catch
                         {
                             MessageBox.Show("Ya existe el sp_actualizar_version.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                         }
                         string version05 = " INSERT INTO test (test_id,test_nombre) VALUES(1,'Test 1');" +
                                            " INSERT INTO test (test_id, test_nombre)  VALUES(2, 'Test 2 - actualizado'); ";
                         SqlCommand myCommand44 = new SqlCommand(version05, conex2);
                         try
                         {
                             myCommand44.ExecuteNonQuery();
                         }
                         catch
                         {
                             MessageBox.Show("Ya existe el sp_actualizar_version.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                         }

                        sp_documento_envio_resultado = "CREATE PROCEDURE sp_documento_envio_resultado  \n" +
                                                    "  @resultado dbo.tp_resultado READONLY   \n" +
                                                    "  AS    \n" +
                                                    "  BEGIN   \n" +
                                                    " UPDATE t    \n" +
                                                    " SET   \n" +
                                                    " t.es_con_migracion = r.resultado_migracion,   \n" +
                                                    " t.obserror = r.obserror   \n" +
                                                    " FROM com_documento t   \n" +
                                                    " JOIN @resultado r   \n" +
                                                    "  ON t.iddocumento = r.id and t.es_con_migracion = r.es_con_migracion;   \n" +
                                                    "  END; ";
                        SqlCommand myCommand45 = new SqlCommand(sp_documento_envio_resultado, conex2);
                        try
                        {
                            myCommand45.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe el sp_producto_envio_resultado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        sp_producto_envio_resultado = "CREATE PROCEDURE dbo.sp_producto_envio_resultado   \n" +
                                                " @resultado dbo.tp_resultado READONLY   \n" +
                                                " AS   \n" +
                                                " BEGIN   \n" +
                                                " UPDATE t    \n" +
                                                " SET    \n" +
                                                " t.es_con_migracion = r.resultado_migracion,   \n" +
                                                " t.obserror = r.obserror   \n" +
                                                " FROM com_producto t   \n" +
                                                " JOIN @resultado r   \n" +
                                                " ON t.idproducto = r.id and t.es_con_migracion = r.es_con_migracion;   \n" +
                                                " END; ";
                        SqlCommand myCommand46 = new SqlCommand(sp_producto_envio_resultado, conex2);
                        try
                        {
                            myCommand46.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe el sp_producto_envio_resultado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        /*****************************************************************************/
                        string cmodulo = "update conexiones set nmodulo=2";
                        SqlCommand myCommand461 = new SqlCommand(cmodulo, conex2);
                        try
                        {
                            myCommand461.ExecuteNonQuery();
                            Properties.Settings.Default.TipModulo = "2";
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Reload();
                        }
                        catch
                        {
                            MessageBox.Show("Actualizado el Modulo a Comercial", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        /*****************************************************************************/
                        conex2.Close();
                     }
                     else
                     //{
                         MessageBox.Show("Los Index ya existen", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                         FrmCrearTablas.instance.timer3.Enabled = false;
                     }

                 }
             }
        public void activartime()
        {
            FrmCrearTablas.instance.timer5.Enabled = true;
        }
    }
}
