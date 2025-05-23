﻿using System;
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
                    MessageBox.Show("No se establece la conexión : " , "Contasis Corp. error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                /** aca vamos a Verificar si Existe la tabla Contasis    **/
                string verifica = "SELECT* FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Fin_Ventas'";
                SqlCommand comando = new SqlCommand(verifica, conex);
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(comando);

                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {

                        strfventas = "CREATE TABLE fin_ventas(" +
                        "idventas int  identity(1,1),"+
                        "ccodrucemisor char(15) null,"+
                        "ccod_empresa  char(3) NULL," +
                        "cper char(4) null," +
                        "cmes char(2) null," +
                        "ffechadoc date   NULL," +
                        "ffechaven date   NULL," +
                        "ccoddoc nchar(2) NULL," +
                        "cserie nchar(20) NULL," +
                        "cnumero nchar(20) NULL," +
                        "ccodenti nchar(11) NULL," +
                        "cdesenti nchar(100) NULL," +
                        "ctipdoc nchar(1) NULL," +
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
                        "ccodcos nchar(15) NULL," +
                        "ccodcos2 nchar(15) NULL," +
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
                        "cglosa text NULL," +
                        "ccodpago nchar(3) NULL," +
                        "nperdenre numeric(1, 0) NULL," +
                        "nbaseres numeric(15, 2) NULL," +
                        "cctaperc nchar(20) NULL," +
                        "created_at datetime   default getdate()," +
                        "updated_at datetime   NULL," +
                        "estado varchar(255)   NULL," +
                        "en_ambiente_de varchar(255)   NULL," +
                        "es_con_migracion numeric(1, 0) DEFAULT 0," +
                        "ccodcos3 nchar(15)   NULL,"+
                        "obserror text NULL,PRIMARY KEY CLUSTERED (idventas  ASC) )";
                        SqlCommand myCommand = new SqlCommand(strfventas, conex);
                        try
                        {
                            myCommand.ExecuteNonQuery();
                            FrmCrearTablas.instance.timer1.Enabled = true;
                            conex.Close();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp.en Ventas", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
        public void crearcompras(string _cadena)
        {
            cadena = _cadena;
            if (cadena == "")
            {
                MessageBox.Show("No se establece la conexión, ingrese las credenciales.", "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                String strfcompras;
                SqlConnection conex1 = new SqlConnection(cadena);
                try
                {
                    conex1.Open();
                }
                catch 
                {
                    MessageBox.Show("No se establece la conexión revise  usuario y clave " , "Contasis Corp. error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /** aca vamos a Verificar si Existe la tabla Contasis    **/
                string verifica = "SELECT* FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'Fin_Compras'";
                SqlCommand comando1 = new SqlCommand(verifica, conex1);
                {
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(comando1);

                    da1.Fill(dt1);
                    if (dt1.Rows.Count == 0)
                    {

                        strfcompras = "CREATE TABLE fin_compras(idcompras int identity(1,1),ccodrucemisor char(15) null, ccod_empresa char(3) NULL," +
                                        "cper char(4) null," +
                                        "cmes char(2) null," +
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
                                        "cctaotrib    nchar  (10) NULL,cctatot    nchar  (10) NULL,ccodcos    nchar  (15) NULL,ccodcos2    nchar  (15) NULL," +
                                        "nresp    numeric  (1,0) NULL,nporre    numeric  (5,2) NULL,nimpres    numeric  (15,2) NULL," +
                                        "cserre    nchar  (6) NULL,cnumre    nchar  (13) NULL,ffecre2    date   NULL,ccodpresu    nchar  (10) NULL," +
                                        "nigv    numeric  (5,2) NULL,cglosa    nchar  (250) NULL,nperdenre    numeric  (15,2) NULL,nbaseres    numeric  (15,2) NULL," +
                                        "cigvxacre    nchar  (1) NULL,created_at    datetime   default getdate()," +
                                        "updated_at    datetime   NULL,estado    varchar(255)   NULL,en_ambiente_de    varchar(255)   NULL," +
                                        "es_con_migracion   numeric(1,0) DEFAULT 0,"+
                                        "ccodcos3 nchar(15)   NULL," +
                                        "obserror text NULL,PRIMARY KEY CLUSTERED (idcompras  ASC) )";

                        SqlCommand myCommand1 = new SqlCommand(strfcompras, conex1);
                        try
                        {
                            myCommand1.ExecuteNonQuery();
                            FrmCrearTablas.instance.timer2.Enabled = true;
                            conex1.Close();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. compras", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe la tabla.", "Contasis Corp. compras", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        FrmCrearTablas.instance.timer2.Enabled = false;
                    }
                }
            }

        }
        public void crearadicional(string _cadena)
        {
            cadena = _cadena;
            if (cadena == "")
            {
                MessageBox.Show("No se establece la conexión, ingrese las credenciales ", "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

            String stremp;
            String strusuario;
            String sconfigura;
            String stmodulo;
            String strusuarioacceso;
            String strlog;
            String strcobranzas;
                SqlConnection conex2 = new SqlConnection(cadena);
            try
            {
                conex2.Open();
            }
            catch 
            {
                MessageBox.Show("No se establece la conexión revise sus credenciales " , "Contasis Corp. error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                         strlog = "CREATE TABLE cg_log(id INT IDENTITY(1,1),"+
                         "tipo_error TEXT NULL,"+
                         "error_mensaje TEXT NULL,"+
                         "fechahora datetime default Getdate()," +
                         "PRIMARY KEY CLUSTERED(id  ASC) )"; 

                        SqlCommand myCommand31 = new SqlCommand(strlog, conex2);
                        try
                        {
                            myCommand31.ExecuteNonQuery();

                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. LOG de Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }

                        /******/

                        stremp = "CREATE TABLE cg_empresa(ccodrucemisor character(15),"+
                            "ccod_empresa character(3),nomempresa character(80))  ";

                        SqlCommand myCommand2 = new SqlCommand(stremp, conex2);
                        try
                        {
                            myCommand2.ExecuteNonQuery();
                            FrmCrearTablas.instance.timer3.Enabled = true;

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
                                    "asientos_vta numeric(1,0),"+
                                    "csub1_com char(3) null," +
                                    "clreg1_com char(20) null," +
                                    "csub2_com char(3) null," +
                                    "clreg2_com  char(20) null,cconts_com  char(20) null,ccontd_com  char(20) null," +
                                    "cfefec_com char(4),ctares_com numeric(1,0),ctaimp_com numeric(1,0) ,Ctapas_com numeric(1,0), asientos_com numeric(1,0),"+
                                    "cTipo char(2) null,cEnt_anula char(15) null,ffecha_inicioproceso date null)";

                        SqlCommand myCommand4 = new SqlCommand(sconfigura, conex2);
                        try
                        {
                            myCommand4.ExecuteNonQuery();

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
                        sconfigura = "create table cg_empemisor("+
                        "ccodrucemisor char(15) NOT NULL, "+
                        "cdesrucemisor char(200) NULL,"+
                        "flgActivo bit NULL, nventaflg  int NOT NULL,ncompraflg int NOT NULL, " +
                        "ncobranzaflg int NOT NULL,npagoflg int NOT NULL,"+
                        "ncomproductoflg int NOT NULL," +
                        "ncomcompraflg int NOT NULL," +
                        "ncomventaflg int NOT NULL," +
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
                        /**
                        sconfigura = "create table cg_moduloconfigura(" +
                       "id int , " +
                       "cdesrucemisor char(200) NULL," +
                       "flgActivo bit NULL, nventaflg  int NOT NULL,ncompraflg int NOT NULL, " +
                       "ncobranzaflg int NOT NULL,npagoflg int NOT NULL," +
                       "ncomproductoflg int NOT NULL," +
                       "ncomcompraflg int NOT NULL," +
                       "ncomventaflg int NOT NULL," +
                       "PRIMARY KEY CLUSTERED " +
                       " (ccodrucemisor  ASC))";

                        SqlCommand myCommand104 = new SqlCommand(sconfigura, conex2);
                        try
                        {
                            myCommand104.ExecuteNonQuery();

                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. configuracion  .", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        */
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

                        stmodulo = "CREATE TRIGGER INSER_USUARIO_ACCESOS "+
                                    " ON CG_USUARIO "+
                                    " AFTER INSERT "+
                                    " AS "+
                                    " BEGIN "+
                                    " DECLARE @USUARIO AS CHAR(10) "+
                                    " SET @USUARIO = (SELECT MAX(CCODUSU) FROM CG_usuario) "+
                                    " IF EXISTS(SELECT* FROM CG_USUARIO_ACCESO WHERE CCODUSU= @USUARIO) "+
                                    " RETURN; "+
                                    " ELSE "+
                                    "  INSERT CG_USUARIO_ACCESO(ccodusu, CCODMOD, FLGACCESO) "+
                                    " SELECT @USUARIO, CCODMOD,0 AS FLGACCESO FROM CG_MODULOS "+
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
                        //***************************************************************************************************************************************//
                        strcobranzas = "CREATE TABLE fin_cobranzapago(idcobranzapago int IDENTITY(1,1) NOT NULL," +
                        "ccodrucemisor char(15) NULL," +
                        "ccod_empresa char(3) NULL," +
                        "cper char(4) NULL," +
                        "cmes char(2) NULL," +
                        "ntipocobpag Numeric(1) ," +
                        "ffechacan date NULL," +
                        "cdoccan char(2) NULL," +
                        "csercan char(20)  NULL," +
                        "cnumcan char(20)  NULL," +
                        "ccuecan char(20)  NULL," +
                        "cmoncan char(1)  NULL," +
                        "nimporcan Numeric(15,2)  NULL," +
                        "ntipcam Numeric(10,6)  NULL," +
                        "ccodpago Char(3) NULL," +
                        "ccoddoc Char(2) NULL," +
                        "cserie Char(20) NULL," +
                        "cnumero Char(20) NULL," +
                        "ffechadoc date  NULL," +
                        "ffechaven date  NULL," +
                        "ccodenti Char(11) NULL," +
                        "ccodruc Char(15) NULL," +
                        "crazsoc Char(100) NULL," +
                        "nimportes Numeric(15,2) NULL," +
                        "nimported Numeric(15,2) NULL," +
                        "ccodcue Char(20) NULL," +
                        "cglosa Char(80) NULL," +
                        "ccodcos Char(9) NULL," +
                        "ccodcos2 Char(9) NULL," +
                        "nporre Numeric(5,2) NULL," +
                        "nimpperc Numeric(15,2) NULL," +
                        "nperdenre Numeric(1) NULL," +
                        "cserre Char(6) NULL," +
                        "cnumre char(13) NULL," +
                        "ffecre date NULL," +
                        "created_at datetime NULL," +
                        "updated_at datetime NULL," +
                        "estado varchar(255) NULL," +
                        "en_ambiente_de varchar(255) NULL," +
                        "es_con_migracion numeric(1, 0) NULL," +
                        "ccodcos3 nchar(15) NULL," +
                        "resultado_migracion numeric(1,0) NULL," +
                        "obserror text NULL) ";
                        SqlCommand myCommand521 = new SqlCommand(strcobranzas, conex2);
                        try
                        {
                            myCommand521.ExecuteNonQuery();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Contasis Corp. Creacion de  Cobranzaspagos", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        }
                        /*****************************************************************************/
                        string cmodulo = "update conexiones set nmodulo=1";
                        SqlCommand myCommand461 = new SqlCommand(cmodulo, conex2);
                        try
                        {
                            myCommand461.ExecuteNonQuery();
                            Properties.Settings.Default.TipModulo = "1";
                            Properties.Settings.Default.Save();
                            Properties.Settings.Default.Reload();
                        }
                        catch
                        {
                            MessageBox.Show("Actualizado el Modulo a Financiero.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        /*****************************************************************************/
                        conex2.Close();




                        /** linea final para despues de crear todo**/
                        conex2.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe las tablas de Proceso", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        FrmCrearTablas.instance.timer3.Enabled = false;
                    }
                }

            }
        }
        public void Crearindex(string _cadena)
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
              //  string strventasfecha;
              //  string strcomprasfecha;
                string strsp_compras;
                string strsp_ventas;
                string version01;
                string version02;
                string version03;
                string version04;
                string tabletype;
                string tabletype2;
                string procedureCobra1;
                string procedureCobra2;
                string funcion01;
                string funcion02;
                string funcion03;
                SqlConnection conex2 = new SqlConnection(cadena);
                try
                {
                    conex2.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se establece la conexión : " + ex.Message, "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                /** aca vamos a Verificar si Existe la tabla Contasis    **/
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
                            FrmCrearTablas.instance.timer4.Enabled = true;
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

                        strindex = "CREATE  INDEX claveCompras ON Fin_Compras (CCOD_EMPRESA ASC, cper ASC) ";
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


                        strsp_compras = " CREATE PROCEDURE sp_compras_envio  \n" +
                            "      @prucEmisor char(15), \n" +
                            "      @empresa char(3)   \n" +
                            "        AS    \n" +
                            "        BEGIN    \n" +
                            "        Select  idcompras,fin_compras.ccod_empresa,fin_compras.cper,cmes, \n" +
                            "        ltrim(rtrim(CONFIGURACION.csub1_com)) AS ccodori,   \n" +
                            "        ltrim(rtrim(CONFIGURACION.clreg1_com)) AS ccodsu,   \n" +
                            "        ltrim(rtrim(CONFIGURACION.csub2_com)) AS ccodori_p,   \n" +
                            "        ltrim(rtrim(CONFIGURACION.clreg2_com)) AS ccodsu_p,     \n" +
                            "        ltrim(rtrim(CONFIGURACION.cconts_com)) AS ccodcue_ps,    \n" +
                            "        ltrim(rtrim(CONFIGURACION.ccontd_com)) AS ccodcue_pd,    \n" +
                            "        ltrim(rtrim(CONFIGURACION.cfefec_com)) AS  ccodflu,    \n" +
                            "        ltrim(rtrim(CONFIGURACION.ctares_com)) AS flgctares,    \n" +
                            "        ltrim(rtrim(CONFIGURACION.ctaimp_com)) AS flgctaimp,     \n" +
                            "        ltrim(rtrim(CONFIGURACION.Ctapas_com)) AS flgctaact,     \n" +
                            "        ltrim(rtrim(CONFIGURACION.asientos_com)) AS flggencomp,    \n" +
                            "        ltrim(rtrim(CONFIGURACION.cEntidad)) AS ccodtipent,     \n" +
                            "        ltrim(rtrim(Convert(char(10), ffechadoc, 112))) as ffechadoc,    \n" +
                            "        ltrim(rtrim(Convert(char(10), fechaven, 112))) as fechaven,    \n" +
                            "        ltrim(rtrim(ccoddoc))as ccoddoc,   \n" +
                            "        ltrim(rtrim(isnull(ccoddas,''))) as ccoddas,    \n" +
                            "        ltrim(rtrim(isnull(cyeardas,''))) as cyeardas,   \n" +
                            "        ltrim(rtrim(cserie)) as cserie,    \n" +
                            "        ltrim(rtrim(cnumero)) as cnumero,   \n" +
                            "        ltrim(rtrim(fin_compras.ccodenti)) AS ccodenti,    \n" +
                             "       ltrim(rtrim(cdesenti)) as cdesenti,   \n" +
                              "      ltrim(rtrim(ctipdoc)) as ctipdoc,    \n" +
                              "      ltrim(rtrim(ccodruc)) as ccodruc,    \n" +
                               "     ltrim(rtrim(crazsoc)) as crazsoc,    \n" +
                               "     ltrim(rtrim(isnull(ccodclas,''))) as ccodclas,   \n" +
                                "    nbase1,nigv1, \n" +
                                "    isnull(nbase2,0.00) as nbase2, \n" +
                                "    isnull(nigv2,0.00) as nigv2 , \n" +
                                "    isnull(nbase3,0.00) as nbase3, \n" +
                                "    isnull(nigv3,0.00) as nigv3 ,   \n" +
                                "    isnull(nina,0.00) as nina,    \n" +
                                "    isnull(nisc,0.00) as nisc,    \n" +
                                "    isnull(nicbper,0.00) as nicbper,    \n" +
                                 "   isnull(nexo,0.00) as nexo,    \n" +
                                 "   isnull(ntots,0.00) as ntots,   \n" +
                                 "   case when ltrim(rtrim(isnull(cdocnodom,''))) = '' then '' else ltrim(rtrim(cdocnodom))  end  as cdocnodom,   \n" +
                                 "   case when ltrim(rtrim(isnull(cnumdere,''))) = '' then '' else ltrim(rtrim(cnumdere))  end  as cnumdere,    \n" +
                                 "   ltrim(rtrim(isnull(Convert(char(10), ffecre, 112),'')))  as ffecre,    \n" +
                                 "   ntc,    \n" +
                                 "   ltrim(rtrim(isnull(Convert(char(10), freffec, 112),''))) as freffec,      \n" +
                                 "   case when ltrim(rtrim(isnull(crefdoc,''))) = '' then '' else ltrim(rtrim(crefdoc))  end  as crefdoc,    \n" +
                                 "   case when ltrim(rtrim(isnull(crefser,''))) = '' then '' else ltrim(rtrim(crefser))  end  as crefser,    \n" +
                                 "   case when ltrim(rtrim(isnull(crefnum,''))) = '' then '' else ltrim(rtrim(crefnum))  end  as crefnum,    \n" +
                                 "   case when ltrim(rtrim(isnull(cmreg,''))) = '' then '' else ltrim(rtrim(cmreg))  end  as cmreg,    \n" +
                                 "   isnull(ndolar,0.00) as ndolar ,    \n" +
                                 "   ltrim(rtrim(isnull(Convert(char(10), ffechaven2, 112),''))) as ffechaven2,    \n" +
                                 "   case when ltrim(rtrim(isnull(ccond,''))) = '' then '' else ltrim(rtrim(ccond))  end  as ccond,    \n" +
                                 "   case when ltrim(rtrim(isnull(cctabase,''))) = '' then '' else ltrim(rtrim(cctabase))  end  as cctabase,    \n" +
                                 "   case when ltrim(rtrim(isnull(cctaicbper,''))) = '' then '' else ltrim(rtrim(cctaicbper))  end  as cctaicbper,    \n" +
                                 "   case when ltrim(rtrim(isnull(cctaotrib,''))) = '' then '' else ltrim(rtrim(cctaotrib))  end  as cctaotrib,    \n" +
                                 "   case when ltrim(rtrim(isnull(cctatot,''))) = '' then '' else ltrim(rtrim(cctatot))  end  as cctatot,    \n" +
                                 "   case when ltrim(rtrim(isnull(ccodcos,''))) = '' then '' else ltrim(rtrim(ccodcos))  end  as ccodcos,    \n" +
                                 "   case when ltrim(rtrim(isnull(ccodcos2,''))) = '' then '' else ltrim(rtrim(ccodcos2))  end  as ccodcos2,    \n" +
                                 "   isnull(nresp,0.00)   as nresp,    \n" +
                                 "   isnull(nporre,0.00) as nporre,   \n" +
                                 "   isnull(nimpres,0.00) as nimpres,    \n" +
                                 "   case when ltrim(rtrim(isnull(cserre,''))) = '' then '' else ltrim(rtrim(cserre))  end  as cserre,   \n" +
                                 "   case when ltrim(rtrim(isnull(cnumre,''))) = '' then '' else ltrim(rtrim(cnumre))  end  as cnumre,    \n" +
                                 "   ltrim(rtrim(isnull(Convert(char(10), ffecre2, 112),''))) as ffecre2 ,    \n" +
                                 "   case when ltrim(rtrim(isnull(ccodpresu,''))) = '' then '' else ltrim(rtrim(cnumre))  end  as ccodpresu,    \n" +
                                 "   nigv,    \n" +
                                 "   case when ltrim(rtrim(isnull(cglosa,''))) = '' then '' else ltrim(rtrim(cglosa))  end  as cglosa,   \n" +
                                 "   isnull(nperdenre,0.00) nperdenre,   \n" +
                                 "   isnull(nbaseres,0.00) as nbaseres,    \n" +
                                 "   case when ltrim(rtrim(isnull(cigvxacre,''))) = '' then '' else ltrim(rtrim(cigvxacre))  end  as cigvxacre,    \n" +
                                 "   case when ltrim(rtrim(isnull(estado,''))) = '' then '' else ltrim(rtrim(estado))  end  as estado ,    \n" +
                                 "   isnull(en_ambiente_de,'!') as en_ambiente_de,    \n" +
                                 "   isnull(es_con_migracion,0)as es_con_migracion,   \n" +
                                 "   case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then '' else ltrim(rtrim(ccodcos3))  end  as ccodcos3,   \n" +
                                 "   case when  es_con_migracion=3  then  ltrim(rtrim(configuracion.cEnt_anula))  else '' end  as ccodrucanula      \n" +
                                 "   From FIN_COMPRAS     \n" +
                                 "   INNER JOIN configuracion ON fin_compras.CCOD_EMPRESA = CONFIGURACION.CCOD_EMPRESA AND FIN_COMPRAS.CPER = configuracion.CPER  \n" +
                                 "   inner join CG_EMPRESA emp on FIN_COMPRAS.ccodrucemisor = emp.ccodrucemisor and FIN_COMPRAS.ccod_empresa = emp.CCOD_EMPRESA \n" +
                                 "   inner join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1  \n" +
                                 "   Where FIN_COMPRAS.ccodrucemisor = @prucEmisor  and fin_compras.CCOD_EMPRESA = @empresa and es_con_migracion in (0, 3) AND CONFIGURACION.CTIPO = '02'  \n" +
                                 "   for json path  \n" +
                                 "   END ";

                        SqlCommand myCommand29 = new SqlCommand(strsp_compras, conex2);
                        try
                        {
                            myCommand29.ExecuteNonQuery();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("Ya existe el procedimiento de compras"+ ex, "Contasis Corp. Index Usuario Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        strsp_ventas = " CREATE PROCEDURE sp_ventas_envio  \n" +
                                " @prucEmisor char(15), \n" +
                                "  @empresa char(3)  \n" +
                                "  AS  \n" +
                                "  BEGIN  \n" +
                                "  SELECT idventas, fin_ventas.ccod_empresa,fin_ventas.cper,cmes,    \n" +
                                " 	 	 ltrim(rtrim(configuracion.csub1_vta)) AS ccodori,   \n" +
                                "        ltrim(rtrim(configuracion.clreg1_vta)) AS ccodsu,   \n" +
                                "        ltrim(rtrim(configuracion.csub2_vta)) AS ccodori_p,   \n" +
                                "        ltrim(rtrim(configuracion.clreg2_vta)) AS ccodsu_p,   \n" +
                                "        ltrim(rtrim(configuracion.cconts_vta)) AS ccodcue_ps,   \n" +
                                "        ltrim(rtrim(configuracion.ccontd_vta)) AS ccodcue_pd,  \n" +
                                "        ltrim(rtrim(configuracion.cfefec_vta)) AS ccodflu,   \n" +
                                "        ltrim(rtrim(configuracion.ctares_vta)) AS flgctares,   \n" +
                                "        ltrim(rtrim(configuracion.ctaimp_vta)) AS flgctaimp,  \n" +
                                "        ltrim(rtrim(configuracion.Ctaact_vta)) AS flgctaact,  \n" +
                                "        ltrim(rtrim(configuracion.asientos_vta)) AS flggencomp,  \n" +
                                "        ltrim(rtrim(configuracion.cEntidad)) AS ccodtipent,   \n" +
                                "        ltrim(rtrim(Convert(char(10), ffechadoc, 112))) as ffechadoc,   \n" +
                                "		 ltrim(rtrim(Convert(char(10), ffechaven, 112))) as ffechaven,   \n" +
                                "		 ltrim(rtrim(ccoddoc)) as ccoddoc,  \n" +
                                "		 ltrim(rtrim(cserie)) as cserie,  \n" +
                                "		 ltrim(rtrim(cnumero)) as cnumero,  \n" +
                                "		 ltrim(rtrim(ccodenti)) as ccodenti,  \n" +
                                "		 ltrim(rtrim(cdesenti)) as cdesenti, \n " +
                                "		 ltrim(rtrim(ctipdoc)) as ctipdoc,  \n" +
                                "		 ltrim(rtrim(ccodruc)) as ccodruc,  \n" +
                                "		 ltrim(rtrim(crazsoc)) as crazsoc,  \n" +
                                "		 Isnull(nbase2, 0.00) as nbase2,   \n" +
                                "		 Isnull(nbase1, 0.00) as nbase1,  \n" +
                                "		 Isnull(nexo, 0.00) as nexo,  \n" +
                                "		 Isnull(nina, 0.00) as nina,   \n" +
                                "		 Isnull(nisc, 0.00) as nisc, \n" +
                                "		 Isnull(nigv1, 0.00) as nigv1, \n" +
                                "		 Isnull(nicbpers, 0.00) as nicbpers,  \n" +
                                "		 Isnull(nbase3, 0.00) as nbase3,  \n" +
                                "		 Isnull(ntots, 0.00) as ntots,  \n" +
                                "		 Isnull(ntc, 0.00) as ntc,  \n" +
                                "		 ltrim(rtrim(Isnull(Convert(char(10), freffec, 112), ' '))) as freffec ,  \n" +
                                "		 case when ltrim(rtrim(isnull(crefdoc,''))) = '' then ' ' else ltrim(rtrim(crefdoc))  end as crefdoc,  \n" +
                                "		 case when ltrim(rtrim(isnull(crefser,''))) = '' then ' ' else ltrim(rtrim(crefser))  end as crefser,  \n" +
                                "		 case when ltrim(rtrim(isnull(crefnum,''))) = '' then ' ' else ltrim(rtrim(crefnum))  end as crefnum, \n" +
                                "		 case when ltrim(rtrim(isnull(cmreg,''))) = '' then ' ' else ltrim(rtrim(cmreg))  end as cmreg,  \n" +
                                "		 Isnull(ndolar, 0.00) as ndolar,   \n" +
                                "		 ltrim(rtrim(Isnull(Convert(char(10), ffechaven2, 112), ' '))) as ffechaven2,   \n" +
                                "		 case when ltrim(rtrim(isnull(ccond,''))) = '' then ' ' else ltrim(rtrim(ccond))  end as ccond,   \n" +
                                "		 case when ltrim(rtrim(isnull(convert(char(9),ccodcos),''))) = '' then ' ' else ltrim(rtrim(convert(char(9),ccodcos)))  end as ccodcos,  \n" +
                                "		 case when ltrim(rtrim(isnull(convert(char(9),ccodcos2),''))) = '' then ' ' else ltrim(rtrim(ccodcos2))  end as ccodcos2,   \n" +
                                "		 case when ltrim(rtrim(isnull(cctabase,''))) = '' then ' ' else ltrim(rtrim(cctabase))  end as cctabase,   \n" +
                                "		 case when ltrim(rtrim(isnull(cctaicbper,''))) = '' then ' ' else ltrim(rtrim(cctaicbper))  end as cctaicbper,   \n" +
                                "		 case when ltrim(rtrim(isnull(cctaotrib,''))) = '' then ' ' else ltrim(rtrim(cctaotrib))  end as cctaotrib,   \n" +
                                "		 case when ltrim(rtrim(isnull(cctatot,''))) = '' then ' ' else ltrim(rtrim(cctatot))  end as cctatot,   \n" +
                                "		 Isnull(nresp, 0.00) as nresp,   \n" +
                                "		 Isnull(nporre, 0.00) as nporre,   \n" +
                                "		Isnull(nimpres, 0.00) as nimpres,   \n" +
                                "		case when ltrim(rtrim(isnull(cserre,''))) = '' then ' ' else ltrim(rtrim(cserre))  end as cserre,   \n" +
                                "		case when ltrim(rtrim(isnull(cnumre,''))) = '' then ' ' else ltrim(rtrim(cnumre))  end as cnumre,   \n" +
                                "		ltrim(rtrim(Isnull(Convert(char(10), ffecre, 112), ' '))) as ffecre,   \n" +
                                "		case when ltrim(rtrim(isnull(ccodpresu,''))) = '' then ' ' else ltrim(rtrim(ccodpresu))  end as ccodpresu,   \n" +
                                "		Isnull(nigv, 0.00) as nigv,   \n" +
                                "		case when ltrim(rtrim(isnull(convert(char(80),cglosa) ,''))) = '' then ' ' else ltrim(rtrim(convert(char(80),cglosa) ))  end as cglosa,   \n" +
                                "		case when ltrim(rtrim(isnull(ccodpago,''))) = '' then ' ' else ltrim(rtrim(ccodpago))  end as ccodpago,   \n" +
                                "		Isnull(nperdenre, 0.00) as nperdenre,   \n" +
                                "		Isnull(nbaseres, 0.00) as nbaseres,   \n" +
                                "		case when ltrim(rtrim(isnull(cctaperc,''))) = '' then ' ' else ltrim(rtrim(cctaperc))  end as cctaperc,  \n" +
                                "		case when ltrim(rtrim(isnull(estado,''))) = '' then ' ' else ltrim(rtrim(estado))  end as estado,   \n" +
                                "		case when ltrim(rtrim(isnull(en_ambiente_de,''))) = '' then ' ' else ltrim(rtrim(en_ambiente_de))  end as en_ambiente_de,   \n" +
                                "		es_con_migracion,   \n" +
                                "		case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then ' ' else ltrim(rtrim(ccodcos3))  end as ccodcos3,   \n" +
                                "		case when  es_con_migracion=3  then  ltrim(rtrim(configuracion.cEnt_anula))  else '' end  as ccodrucanula       \n" +
                                "       FROM FIN_VENTAS  \n" +
                                "       INNER JOIN configuracion ON FIN_VENTAS.CCOD_EMPRESA = configuracion.CCOD_EMPRESA  AND  \n" +
                                "       FIN_VENTAS.CPER = configuracion.CPER  \n" +
                                "       inner join CG_EMPRESA emp on FIN_VENTAS.ccodrucemisor = emp.ccodrucemisor and FIN_VENTAS.ccod_empresa = emp.CCOD_EMPRESA \n" +
                                "       inner join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1  \n" +
                                "       where FIN_VENTAS.ccod_empresa = @empresa and es_con_migracion in (0, 3)  AND \n" +
                                "       configuracion.ctipo = '01'  \n" +
                                "       for json path \n" +
                                "       END   ";
                        SqlCommand myCommand30 = new SqlCommand(strsp_ventas, conex2);
                        try
                        {
                            myCommand30.ExecuteNonQuery();
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("Ya existe el procedimiento de ventas"+ex, "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        /**************************************************/
                        string ENVIORESULTADOVENTAS = "CREATE PROCEDURE sp_ventas_envio_resultado\n" +
                        " @resultado NVARCHAR(MAX) \n" +
                        " AS \n" +
                        " BEGIN \n" +
                        " UPDATE t \n" +
                        "        \n" +
                        "SET  \n" +
                        " t.es_con_migracion = r.resultado_migracion,	\n" +
                        " t.obserror = r.obserror  \n" +
                        " FROM fin_ventas t \n" +
                        " JOIN OPENJSON(@resultado) \n" +
                        "            \n" +
                        "WITH(    \n" +
                        "idventas INT,  \n" +
                        "obserror NVARCHAR(MAX),  \n" +
                        "es_con_migracion INT,  \n" +
                        "resultado_migracion INT  \n" +
                        ") AS r  \n" +
                        "ON t.idventas = r.idventas and t.es_con_migracion = r.es_con_migracion;   \n" +
                        "END   ";

                        SqlCommand myCommand33 = new SqlCommand(ENVIORESULTADOVENTAS, conex2);
                        try
                        {
                            myCommand33.ExecuteNonQuery();
                        }
                        catch 
                        {
                            MessageBox.Show("Ya existe el procedimiento de envio resultados de  ventas", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }


                        string ENVIORESULTADOCOMPRAS = "CREATE PROCEDURE sp_compras_envio_resultado \n" +
                           " @resultado NVARCHAR(MAX) \n" +
                           " AS \n" +
                           " BEGIN \n" +
                           "     UPDATE t \n" +
                           "      \n " +
                           "    SET   \n" +
                           "       \n" +
                           "         t.es_con_migracion = r.resultado_migracion  ,	 \n" +
                           "         -- #donde se actualiza el resultado   \n " +
                           "         t.obserror = r.obserror \n" +
                           "         \n" +
                           "    FROM fin_compras t  \n" +
                           "     JOIN OPENJSON(@resultado)    \n " +
                           "       \n " +
                           "     WITH( \n" +
                           "         idcompras INT, \n" +
                           "         obserror NVARCHAR(MAX), \n" +
                           "         es_con_migracion INT, \n" +
                           "         resultado_migracion INT    \n" +
                           "     ) AS r   \n" +
                           "     \n " +
                           "     ON t.idcompras = r.idcompras and t.es_con_migracion = r.es_con_migracion;\n " +
                           " END; ";

                        SqlCommand myCommand34 = new SqlCommand(ENVIORESULTADOCOMPRAS, conex2);
                        try
                        {
                            myCommand34.ExecuteNonQuery();
                        }
                        catch 
                        {
                            MessageBox.Show("Ya existe el procedimiento de envio resultados de  compras", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        /**************************************************/
                        version01 = "create table cg_version (" +
                                    " cversion varchar(15) not null, " +
                                    " cfecha datetime2 default GETDATE() not null,);";
                        SqlCommand myCommand40 = new SqlCommand(version01, conex2);
                        try
                        {
                            myCommand40.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe la tabla de versión.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        /**************************************************/
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

                        /**************************************************/
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

                        /**************************************************/
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

                        /**************************************************/
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
                        /*************************************************/
                        tabletype= "CREATE TYPE dbo.tp_resultado AS TABLE (" +
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
                        tabletype2 = "CREATE TYPE [dbo].[tp_id] AS TABLE(  \n" +
                        " [id][int] NULL )";
                        SqlCommand myCommand430 = new SqlCommand(tabletype2, conex2);
                        try
                        {
                            myCommand430.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe el tp_resultado.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }



                        /*************************************************/
                        procedureCobra1 = "CREATE PROCEDURE sp_cobranzapago_envio    \n" +
            "	@prucEmisor char(15),      \n" +
            "	@empresa char(3),     \n" +
            "	@tipo int  \n" +
            "AS     \n" +
            "BEGIN     \n" +
            "	select top 1000  \n" +
            "		idcobranzapago,fin_cobranzapago.ccod_empresa,fin_cobranzapago.cper,fin_cobranzapago.cmes,      \n" +
            "		ltrim(rtrim(CONFIGURACION.csub1_vta)) AS ccodori,     \n" +
            "		ltrim(rtrim(CONFIGURACION.clreg1_vta)) AS ccodsu,     \n" +
            "		ltrim(rtrim(CONFIGURACION.cfefec_vta)) AS ccodflu,  \n" +
            "		cast(fin_cobranzapago.ntipocobpag as integer) as ntipocobpag,   \n" +
            "		ltrim(rtrim(Convert(char(10), ffechacan, 112))) as ffechacan,         \n" +
            "		ltrim(rtrim(isnull(cdoccan, ''))) as cdoccan,       \n" +
            "		ltrim(rtrim(isnull(csercan, ''))) as csercan,       \n" +
            "		ltrim(rtrim(isnull(cnumcan, ''))) as cnumcan,         \n" +
            "		ltrim(rtrim(isnull(ccuecan, ''))) as ccuecan,         \n" +
            "		ltrim(rtrim(isnull(cmoncan, ''))) as cmoncan,     \n" +
            "		isnull(nimporcan, 0.00) as nimporcan,      \n" +
            "		isnull(ntipcam, 0.00) as ntipcam ,     \n" +
            "		ltrim(rtrim(isnull(ccodpago, ''))) as ccodpago,      \n" +
            "		ltrim(rtrim(isnull(ccoddoc, ''))) as ccoddoc,     \n" +
            "		ltrim(rtrim(isnull(cserie, ''))) as cserie,     \n" +
            "		ltrim(rtrim(isnull(cnumero, ''))) as cnumero,     \n" +
            "		ltrim(rtrim(Convert(char(10), ffechadoc, 112))) as ffechadoc,       \n" +
            "		ltrim(rtrim(Convert(char(10), ffechaven, 112))) as ffechaven,       \n" +
            "		ltrim(rtrim(isnull(ccodenti, ''))) as ccodenti,     \n" +
            "		ltrim(rtrim(isnull(ccodruc, ''))) as ccodruc,     \n" +
            "		ltrim(rtrim(isnull(crazsoc, ''))) as crazsoc,     \n" +
            "		isnull(nimportes, 0.00) as nimportes,      \n" +
            "		isnull(nimported, 0.00) as nimported ,      \n" +
            "		ltrim(rtrim(isnull(ccodcue, ''))) as ccodcue,     \n" +
            "		ltrim(rtrim(isnull(substring(cglosa,1,80), '')))    as cglosa,        \n" +
            "		ltrim(rtrim(isnull(substring(ccodcos,1,9), ''))) as ccodcos,      \n" +
            "		ltrim(rtrim(isnull(substring(ccodcos2,1,9), ''))) as ccodcos2,      \n" +
            "		isnull(nporre, 0.00) as nporre,      \n" +
            "		isnull(nimpperc, 0.00) as nimpperc,      \n" +
            "		isnull(nperdenre, 0.00) as nperdenre,      \n" +
            "		ltrim(rtrim(isnull(cserre, ''))) as cserre,      \n" +
            "		ltrim(rtrim(isnull(cnumre, ''))) as cnumre,      \n" +
            "		ltrim(rtrim(Convert(char(10), ffecre, 112))) as ffecre,       \n" +
            "		case when ltrim(rtrim(isnull(estado,''))) = '' then '' else ltrim(rtrim(estado))  end as estado ,         \n" +
            "		isnull(en_ambiente_de, '!') as en_ambiente_de,         \n" +
            "		isnull(es_con_migracion, 0) as es_con_migracion,        \n" +
            "		case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then '' else ltrim(rtrim(ccodcos3))  end as ccodcos3,       \n" +
            "		case when es_con_migracion = 3  then ltrim(rtrim(configuracion.cEnt_anula))  else '' end as ccodrucanula     \n" +
            "	from fin_cobranzapago     \n" +
            "	INNER JOIN configuracion ON fin_cobranzapago.CCOD_EMPRESA = CONFIGURACION.CCOD_EMPRESA AND fin_cobranzapago.CPER = configuracion.CPER     \n" +
            "	inner join CG_EMPRESA emp on fin_cobranzapago.ccodrucemisor = emp.ccodrucemisor and fin_cobranzapago.ccod_empresa = emp.CCOD_EMPRESA     \n" +
            "	inner join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1      \n" +
            "		and fin_cobranzapago.CCOD_EMPRESA = @empresa  \n" +
            "		and es_con_migracion in (0, 3)     \n" +
            "		and CONFIGURACION.CTIPO = '03'  \n" +
            "END";
                        SqlCommand myCommand421 = new SqlCommand(procedureCobra1, conex2);
                        try
                        {
                            myCommand421.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe el sp_cobranzapago_envio.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        /****************************************************/
                        procedureCobra2 = "CREATE PROCEDURE sp_cobranzapago_envio_resultado   \n" +
                                        " @resultado dbo.tp_resultado READONLY   \n" +
                                        " AS   \n" +
                                        " BEGIN   \n" +
                                        "   \n" +
                                        "  UPDATE t   \n" +
                                        "      \n" +
                                        " SET   \n" +
                                        "     \n" +
                                        " t.es_con_migracion = r.resultado_migracion,   \n" +
                                        " t.obserror = r.obserror   \n" +
                                        "   \n" +
                                        " FROM fin_cobranzapago t   \n" +
                                        " JOIN @resultado r   \n" +
                                        "     \n" +
                                        " ON t.idcobranzapago = r.id and t.es_con_migracion = r.es_con_migracion;   \n" +
                                        " END  ";
                        SqlCommand myCommand422 = new SqlCommand(procedureCobra2, conex2);
                        try
                        {
                            myCommand422.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe el sp_cobranzapago_envio_resultado.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        /**************************************************/
                        funcion01 = " CREATE FUNCTION fn_cobranzapago_envio(  \n" +
                                    " 	@prucEmisor char(15), \n" +
                                    " 	@empresa char(3), \n" +
                                    " 	@tipo int \n" +
                                    " ) RETURNS TABLE \n" +
                                    " AS    \n" +
                                    " RETURN ( \n" +
                                    " 	select top 1000 \n" +
                                    " 		idcobranzapago,fin_cobranzapago.ccod_empresa,fin_cobranzapago.cper,fin_cobranzapago.cmes,     \n" +
                                    " 		ltrim(rtrim(CONFIGURACION.csub1_vta)) AS ccodori,    \n" +
                                    " 		ltrim(rtrim(CONFIGURACION.clreg1_vta)) AS ccodsu,    \n" +
                                    " 		ltrim(rtrim(CONFIGURACION.cfefec_vta)) AS ccodflu, \n" +
                                    " 		cast(fin_cobranzapago.ntipocobpag as integer) as ntipocobpag,  \n" +
                                    " 		ltrim(rtrim(Convert(char(10), ffechacan, 112))) as ffechacan,        \n" +
                                    " 		ltrim(rtrim(isnull(cdoccan, ''))) as cdoccan,      \n" +
                                    " 		ltrim(rtrim(isnull(csercan, ''))) as csercan,      \n" +
                                    " 		ltrim(rtrim(isnull(cnumcan, ''))) as cnumcan,        \n" +
                                    " 		ltrim(rtrim(isnull(ccuecan, ''))) as ccuecan,        \n" +
                                    " 		ltrim(rtrim(isnull(cmoncan, ''))) as cmoncan,          \n" +
                                    " 		isnull(nimporcan, 0.00) as nimporcan,     \n" +
                                    " 		isnull(ntipcam, 0.00) as ntipcam ,    \n" +
                                    " 		ltrim(rtrim(isnull(ccodpago, ''))) as ccodpago,     \n" +
                                    " 		ltrim(rtrim(isnull(ccoddoc, ''))) as ccoddoc,    \n" +
                                    " 		ltrim(rtrim(isnull(cserie, ''))) as cserie,    \n" +
                                    " 		ltrim(rtrim(isnull(cnumero, ''))) as cnumero,    \n" +
                                    " 		ltrim(rtrim(Convert(char(10), ffechadoc, 112))) as ffechadoc,      \n" +
                                    " 		ltrim(rtrim(Convert(char(10), ffechaven, 112))) as ffechaven,      \n" +
                                    " 		ltrim(rtrim(isnull(ccodenti, ''))) as ccodenti,    \n" +
                                    " 		ltrim(rtrim(isnull(ccodruc, ''))) as ccodruc,    \n" +
                                    " 		ltrim(rtrim(isnull(crazsoc, ''))) as crazsoc,    \n" +
                                    " 		isnull(nimportes, 0.00) as nimportes,     \n" +
                                    " 		isnull(nimported, 0.00) as nimported ,     \n" +
                                    " 		ltrim(rtrim(isnull(ccodcue, ''))) as ccodcue,    \n" +
                                    " 		ltrim(rtrim(isnull(cglosa, ''))) as cglosa,     \n" +
                                    " 		ltrim(rtrim(isnull(ccodcos, ''))) as ccodcos,     \n" +
                                    " 		ltrim(rtrim(isnull(ccodcos2, ''))) as ccodcos2,     \n" +
                                    " 		isnull(nporre, 0.00) as nporre,     \n" +
                                    " 		isnull(nimpperc, 0.00) as nimpperc,     \n" +
                                    " 		isnull(nperdenre, 0.00) as nperdenre,     \n" +
                                    " 		ltrim(rtrim(isnull(cserre, ''))) as cserre,     \n" +
                                    " 		ltrim(rtrim(isnull(cnumre, ''))) as cnumre,     \n" +
                                    " 		ltrim(rtrim(Convert(char(10), ffecre, 112))) as ffecre,      \n" +
                                    " 		case when ltrim(rtrim(isnull(estado,''))) = '' then '' else ltrim(rtrim(estado))  end as estado ,        \n" +
                                    " 		isnull(en_ambiente_de, '!') as en_ambiente_de,        \n" +
                                    " 		isnull(es_con_migracion, 0) as es_con_migracion,       \n" +
                                    " 		case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then '' else ltrim(rtrim(ccodcos3))  end as ccodcos3,      \n" +
                                    " 		case when es_con_migracion = 3  then ltrim(rtrim(configuracion.cEnt_anula))  else '' end as ccodrucanula    \n" +
                                    " 	from fin_cobranzapago    \n" +
                                    " 	INNER JOIN configuracion ON fin_cobranzapago.CCOD_EMPRESA = CONFIGURACION.CCOD_EMPRESA AND fin_cobranzapago.CPER = configuracion.CPER    \n" +
                                    " 	inner join CG_EMPRESA emp on fin_cobranzapago.ccodrucemisor = emp.ccodrucemisor and fin_cobranzapago.ccod_empresa = emp.CCOD_EMPRESA    \n" +
                                    " 	inner join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1     \n" +
                                    " 	where fin_cobranzapago.ccodrucemisor = @prucEmisor \n" +
                                    " 		and fin_cobranzapago.CCOD_EMPRESA = @empresa \n" +
                                    " 		and es_con_migracion in (0, 3)    \n" +
                                    " 		and CONFIGURACION.CTIPO = '03' \n" +
                                    " 		and cast(fin_cobranzapago.ntipocobpag as int) = @tipo); ";
                        SqlCommand myCommand423 = new SqlCommand(funcion01, conex2);
                        try
                        {
                            myCommand423.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe el sp_cobranzapago_envio_resultado.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                        funcion02 = " CREATE FUNCTION fn_compras_envio (  \n" +
                                    " 	@prucEmisor char(15),  \n" +
                                    " 	@empresa char(3) \n" +
                                    " ) RETURNS TABLE \n" +
                                    " AS    \n" +
                                    " RETURN ( \n" +
                                    " 	select top 1000 \n" +
                                    "         idcompras, fin_compras.ccod_empresa, fin_compras.cper, cmes, \n" +
                                    "         ltrim(rtrim(configuracion.csub1_com)) AS ccodori, \n" +
                                    "         ltrim(rtrim(configuracion.clreg1_com)) AS ccodsu, \n" +
                                    "         ltrim(rtrim(configuracion.csub2_com)) AS ccodori_p, \n" +
                                    "         ltrim(rtrim(configuracion.clreg2_com)) AS ccodsu_p, \n" +
                                    "         ltrim(rtrim(configuracion.cconts_com)) AS ccodcue_ps, \n" +
                                    "         ltrim(rtrim(configuracion.ccontd_com)) AS ccodcue_pd, \n" +
                                    "         ltrim(rtrim(configuracion.cfefec_com)) AS  ccodflu, \n" +
                                    "         ltrim(rtrim(configuracion.ctares_com)) AS flgctares, \n" +
                                    "         ltrim(rtrim(configuracion.ctaimp_com)) AS flgctaimp, \n" +
                                    "         ltrim(rtrim(configuracion.Ctapas_com)) AS flgctaact, \n" +
                                    "        ltrim(rtrim(configuracion.asientos_com)) AS flggencomp, \n" +
                                    "        ltrim(rtrim(configuracion.cEntidad)) AS ccodtipent, \n" +
                                    "        ltrim(rtrim(Convert(char(10), ffechadoc, 112))) as ffechadoc, \n" +
                                    "        ltrim(rtrim(Convert(char(10), fechaven, 112))) as fechaven, \n" +
                                    "        ltrim(rtrim(ccoddoc))as ccoddoc, \n" +
                                    "        ltrim(rtrim(isnull(ccoddas,''))) as ccoddas, \n" +
                                    "        ltrim(rtrim(isnull(cyeardas,''))) as cyeardas, \n" +
                                    "        ltrim(rtrim(cserie)) as cserie, \n" +
                                    "        ltrim(rtrim(cnumero)) as cnumero, \n" +
                                    "        ltrim(rtrim(fin_compras.ccodenti)) AS ccodenti, \n" +
                                    "        ltrim(rtrim(cdesenti)) as cdesenti, \n" +
                                    "        ltrim(rtrim(ctipdoc)) as ctipdoc, \n" +
                                    "        ltrim(rtrim(ccodruc)) as ccodruc, \n" +
                                    "        ltrim(rtrim(crazsoc)) as crazsoc, \n" +
                                    "        ltrim(rtrim(isnull(ccodclas,''))) as ccodclas, \n" +
                                    "        nbase1,nigv1, \n" +
                                    "        isnull(nbase2,0.00) as nbase2, \n" +
                                    "        isnull(nigv2,0.00) as nigv2, \n" +
                                    "        isnull(nbase3,0.00) as nbase3, \n" +
                                    "        isnull(nigv3,0.00) as nigv3, \n" +
                                    "        isnull(nina,0.00) as nina, \n" +
                                    "        isnull(nisc,0.00) as nisc, \n" +
                                    "        isnull(nicbper,0.00) as nicbper, \n" +
                                    "        isnull(nexo,0.00) as nexo, \n" +
                                    "        isnull(ntots,0.00) as ntots, \n" +
                                    "        case when ltrim(rtrim(isnull(cdocnodom,''))) = '' then '' else ltrim(rtrim(cdocnodom))  end  as cdocnodom, \n" +
                                    "        case when ltrim(rtrim(isnull(cnumdere,''))) = '' then '' else ltrim(rtrim(cnumdere))  end  as cnumdere, \n" +
                                    "        ltrim(rtrim(isnull(Convert(char(10), ffecre, 112),'')))  as ffecre, \n" +
                                    "        ntc, \n" +
                                    "        ltrim(rtrim(isnull(Convert(char(10), freffec, 112),''))) as freffec, \n" +
                                    "        case when ltrim(rtrim(isnull(crefdoc,''))) = '' then '' else ltrim(rtrim(crefdoc))  end  as crefdoc, \n" +
                                    "        case when ltrim(rtrim(isnull(crefser,''))) = '' then '' else ltrim(rtrim(crefser))  end  as crefser, \n" +
                                    "        case when ltrim(rtrim(isnull(crefnum,''))) = '' then '' else ltrim(rtrim(crefnum))  end  as crefnum, \n" +
                                    "        case when ltrim(rtrim(isnull(cmreg,''))) = '' then '' else ltrim(rtrim(cmreg))  end  as cmreg, \n" +
                                    "        isnull(ndolar,0.00) as ndolar, \n" +
                                    "        ltrim(rtrim(isnull(Convert(char(10), ffechaven2, 112),''))) as ffechaven2, \n" +
                                    "        case when ltrim(rtrim(isnull(ccond,''))) = '' then '' else ltrim(rtrim(ccond))  end  as ccond, \n" +
                                    "        case when ltrim(rtrim(isnull(cctabase,''))) = '' then '' else ltrim(rtrim(cctabase))  end  as cctabase, \n" +
                                    "        case when ltrim(rtrim(isnull(cctaicbper,''))) = '' then '' else ltrim(rtrim(cctaicbper))  end  as cctaicbper,     \n" +
                                    "        case when ltrim(rtrim(isnull(cctaotrib,''))) = '' then '' else ltrim(rtrim(cctaotrib))  end  as cctaotrib,     \n" +
                                    "        case when ltrim(rtrim(isnull(cctatot,''))) = '' then '' else ltrim(rtrim(cctatot))  end  as cctatot,     \n" +
                                    "        case when ltrim(rtrim(isnull(ccodcos,''))) = '' then '' else ltrim(rtrim(ccodcos))  end  as ccodcos,     \n" +
                                    "        case when ltrim(rtrim(isnull(ccodcos2,''))) = '' then '' else ltrim(rtrim(ccodcos2))  end  as ccodcos2,     \n" +
                                    "        isnull(nresp,0.00) as nresp,     \n" +
                                    "        isnull(nporre,0.00) as nporre,    \n" +
                                    "        isnull(nimpres,0.00) as nimpres,     \n" +
                                    "        case when ltrim(rtrim(isnull(cserre,''))) = '' then '' else ltrim(rtrim(cserre))  end  as cserre,    \n" +
                                    "        case when ltrim(rtrim(isnull(cnumre,''))) = '' then '' else ltrim(rtrim(cnumre))  end  as cnumre,     \n" +
                                    "       ltrim(rtrim(isnull(Convert(char(10), ffecre2, 112),''))) as ffecre2 ,     \n" +
                                    "       case when ltrim(rtrim(isnull(ccodpresu,''))) = '' then '' else ltrim(rtrim(cnumre))  end  as ccodpresu,     \n" +
                                    "        nigv, \n" +
                                    "        case when ltrim(rtrim(isnull(cglosa,''))) = '' then '' else ltrim(rtrim(cglosa))  end  as cglosa, \n" +
                                    "        isnull(nperdenre,0.00) nperdenre, \n" +
                                    "        isnull(nbaseres,0.00) as nbaseres, \n" +
                                    "        case when ltrim(rtrim(isnull(cigvxacre,''))) = '' then '' else ltrim(rtrim(cigvxacre)) end as cigvxacre, \n" +
                                    "        case when ltrim(rtrim(isnull(estado,''))) = '' then '' else ltrim(rtrim(estado))  end  as estado, \n" +
                                    "        isnull(en_ambiente_de,'!') as en_ambiente_de, \n" +
                                    "        isnull(es_con_migracion,0)as es_con_migracion,    \n" +
                                    "        case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then '' else ltrim(rtrim(ccodcos3))  end as ccodcos3, \n" +
                                    "       case when es_con_migracion=3 then ltrim(rtrim(configuracion.cEnt_anula))  else '' end as ccodrucanula \n" +
                                    "	from fin_compras \n" +
                                    "	inner join configuracion on fin_compras.ccod_empresa = configuracion.ccod_empresa and fin_compras.cper = configuracion.cper   \n" +
                                    "	inner join cg_empresa emp on fin_compras.ccodrucemisor = emp.ccodrucemisor and fin_compras.ccod_empresa = emp.ccod_empresa  \n" +
                                    "	inner join cg_empemisor empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1   \n" +
                                    "	where fin_compras.ccodrucemisor = @prucEmisor  \n" +
                                    "		and fin_compras.ccod_empresa = @empresa \n" +
                                    "		and es_con_migracion in (0, 3) \n" +
                                    "		and configuracion.CTIPO = '02');";
                        SqlCommand myCommand424 = new SqlCommand(funcion02, conex2);
                        try
                        {
                            myCommand424.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe el fn_compras_envio.", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        funcion03 = "CREATE FUNCTION fn_ventas_envio (  \n" +
                                    "	@prucEmisor char(15),   \n" +
                                    "	@empresa char(3)    \n" +
                                    ") RETURNS TABLE  \n" +
                                    "AS     \n" +
                                    "RETURN (  \n" +
                                    "	select top 1000  \n" +
                                    "         idventas, fin_ventas.ccod_empresa,fin_ventas.cper,cmes,      \n" +
                                    "         ltrim(rtrim(configuracion.csub1_vta)) AS ccodori,     \n" +
                                    "         ltrim(rtrim(configuracion.clreg1_vta)) AS ccodsu,     \n" +
                                    "         ltrim(rtrim(configuracion.csub2_vta)) AS ccodori_p,     \n" +
                                    "         ltrim(rtrim(configuracion.clreg2_vta)) AS ccodsu_p,     \n" +
                                    "         ltrim(rtrim(configuracion.cconts_vta)) AS ccodcue_ps,     \n" +
                                    "         ltrim(rtrim(configuracion.ccontd_vta)) AS ccodcue_pd,    \n" +
                                    "         ltrim(rtrim(configuracion.cfefec_vta)) AS ccodflu,     \n" +
                                    "         ltrim(rtrim(configuracion.ctares_vta)) AS flgctares,     \n" +
                                    "        ltrim(rtrim(configuracion.ctaimp_vta)) AS flgctaimp,    \n" +
                                    "        ltrim(rtrim(configuracion.Ctaact_vta)) AS flgctaact,    \n" +
                                    "        ltrim(rtrim(configuracion.asientos_vta)) AS flggencomp,    \n" +
                                    "        ltrim(rtrim(configuracion.cEntidad)) AS ccodtipent,     \n" +
                                    "        ltrim(rtrim(Convert(char(10), ffechadoc, 112))) as ffechadoc,  \n" +
                                    "        ltrim(rtrim(Convert(char(10), ffechaven, 112))) as ffechaven,     \n" +
                                    "        ltrim(rtrim(ccoddoc)) as ccoddoc,    \n" +
                                    "        ltrim(rtrim(cserie)) as cserie,    \n" +
                                    "        ltrim(rtrim(cnumero)) as cnumero,    \n" +
                                    "        ltrim(rtrim(ccodenti)) as ccodenti,    \n" +
                                    "        ltrim(rtrim(cdesenti)) as cdesenti,   \n" +
                                    "        ltrim(rtrim(ctipdoc)) as ctipdoc,    \n" +
                                    "        ltrim(rtrim(ccodruc)) as ccodruc,    \n" +
                                    "        ltrim(rtrim(crazsoc)) as crazsoc,    \n" +
                                    "        Isnull(nbase2, 0.00) as nbase2,     \n" +
                                    "        Isnull(nbase1, 0.00) as nbase1,    \n" +
                                    "        Isnull(nexo, 0.00) as nexo,    \n" +
                                    "        Isnull(nina, 0.00) as nina,     \n" +
                                    "        Isnull(nisc, 0.00) as nisc,   \n" +
                                    "        Isnull(nigv1, 0.00) as nigv1,   \n" +
                                    "        Isnull(nicbpers, 0.00) as nicbpers,    \n" +
                                    "        Isnull(nbase3, 0.00) as nbase3,    \n" +
                                    "        Isnull(ntots, 0.00) as ntots,    \n" +
                                    "        Isnull(ntc, 0.00) as ntc,    \n" +
                                    "        ltrim(rtrim(Isnull(Convert(char(10), freffec, 112), ' '))) as freffec ,    \n" +
                                    "        case when ltrim(rtrim(isnull(crefdoc,''))) = '' then ' ' else ltrim(rtrim(crefdoc))  end as crefdoc,    \n" +
                                    "        case when ltrim(rtrim(isnull(crefser,''))) = '' then ' ' else ltrim(rtrim(crefser))  end as crefser,    \n" +
                                    "        case when ltrim(rtrim(isnull(crefnum,''))) = '' then ' ' else ltrim(rtrim(crefnum))  end as crefnum,   \n" +
                                    "        case when ltrim(rtrim(isnull(cmreg,''))) = '' then ' ' else ltrim(rtrim(cmreg))  end as cmreg,    \n" +
                                    "        Isnull(ndolar, 0.00) as ndolar,     \n" +
                                    "        ltrim(rtrim(Isnull(Convert(char(10), ffechaven2, 112), ' '))) as ffechaven2,     \n" +
                                    "        case when ltrim(rtrim(isnull(ccond,''))) = '' then ' ' else ltrim(rtrim(ccond))  end as ccond,     \n" +
                                    "        case when ltrim(rtrim(isnull(convert(char(9),ccodcos),''))) = '' then ' ' else ltrim(rtrim(convert(char(9),ccodcos)))  end as ccodcos,    \n" +
                                    "        case when ltrim(rtrim(isnull(convert(char(9),ccodcos2),''))) = '' then ' ' else ltrim(rtrim(convert(char(9),ccodcos2)))  end as ccodcos2,     \n" +
                                    "        case when ltrim(rtrim(isnull(cctabase,''))) = '' then ' ' else ltrim(rtrim(cctabase))  end as cctabase,     \n" +
                                    "        case when ltrim(rtrim(isnull(cctaicbper,''))) = '' then ' ' else ltrim(rtrim(cctaicbper))  end as cctaicbper,     \n" +
                                    "        case when ltrim(rtrim(isnull(cctaotrib,''))) = '' then ' ' else ltrim(rtrim(cctaotrib))  end as cctaotrib,     \n" +
                                    "        case when ltrim(rtrim(isnull(cctatot,''))) = '' then ' ' else ltrim(rtrim(cctatot))  end as cctatot,     \n" +
                                    "        Isnull(nresp, 0.00) as nresp,     \n" +
                                    "        Isnull(nporre, 0.00) as nporre,     \n" +
                                    "        Isnull(nimpres, 0.00) as nimpres,     \n" +
                                    "        case when ltrim(rtrim(isnull(cserre,''))) = '' then ' ' else ltrim(rtrim(cserre))  end as cserre,     \n" +
                                    "        case when ltrim(rtrim(isnull(cnumre,''))) = '' then ' ' else ltrim(rtrim(cnumre))  end as cnumre,     \n" +
                                    "        ltrim(rtrim(Isnull(Convert(char(10), ffecre, 112), ' '))) as ffecre,     \n" +
                                    "        case when ltrim(rtrim(isnull(ccodpresu,''))) = '' then ' ' else ltrim(rtrim(ccodpresu))  end as ccodpresu,     \n" +
                                    "        Isnull(nigv, 0.00) as nigv,     \n" +
                                    "        case when ltrim(rtrim(isnull(convert(char(80),cglosa) ,''))) = '' then ' ' else ltrim(rtrim(convert(char(80),cglosa) ))  end as cglosa,     \n" +
                                    "        case when ltrim(rtrim(isnull(ccodpago,''))) = '' then ' ' else ltrim(rtrim(ccodpago))  end as ccodpago,     \n" +
                                    "        Isnull(nperdenre, 0.00) as nperdenre,     \n" +
                                    "        Isnull(nbaseres, 0.00) as nbaseres,     \n" +
                                    "        case when ltrim(rtrim(isnull(cctaperc,''))) = '' then ' ' else ltrim(rtrim(cctaperc))  end as cctaperc,    \n" +
                                    "        case when ltrim(rtrim(isnull(estado,''))) = '' then ' ' else ltrim(rtrim(estado))  end as estado,     \n" +
                                    "        case when ltrim(rtrim(isnull(en_ambiente_de,''))) = '' then ' ' else ltrim(rtrim(en_ambiente_de))  end as en_ambiente_de,     \n" +
                                    "        es_con_migracion,     \n" +
                                    "        case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then ' ' else ltrim(rtrim(ccodcos3))  end as ccodcos3,     \n" +
                                    "        case when es_con_migracion=3  then  ltrim(rtrim(configuracion.cEnt_anula))  else '' end  as ccodrucanula  \n" +
                                    "	from fin_ventas    \n" +
                                    "	inner join configuracion on fin_ventas.ccod_empresa = configuracion.ccod_empresa and fin_ventas.cper = configuracion.cper  \n" +
                                    "	inner join cg_empresa emp on fin_ventas.ccodrucemisor = emp.ccodrucemisor and fin_ventas.ccod_empresa = emp.ccod_empresa   \n" +
                                    "	inner join cg_empemisor empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1    \n" +
                                    "		where fin_ventas.ccodrucemisor = @prucEmisor   \n" +
                                    "		and fin_ventas.ccod_empresa = @empresa  \n" +
                                    "		and es_con_migracion in (0, 3)  \n" +
                                    "		and configuracion.ctipo = '01'); ";
                        SqlCommand myCommand425 = new SqlCommand(funcion03, conex2);
                        try
                        {
                            myCommand425.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Ya existe el fn_ventas_envio.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }



                        /**************************************************/
                        conex2.Close();
                    }
                    else
                    {
                        MessageBox.Show("Los procedimientos y funciones existen", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        FrmCrearTablas.instance.timer4.Enabled = false;
                    }

                }
            }
        }
        public void Activartime()
        {
            FrmCrearTablas.instance.timer5.Enabled = true;
        }
    }
}
        

