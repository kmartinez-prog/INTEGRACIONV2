using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contasis
{
    public partial class FrmVerificacionEstrcutura : Form
    {
        string NombreTable;
        string NombreSP;
        string Query;
        string Nombrecampo;
        public FrmVerificacionEstrcutura()
        {
            InitializeComponent();

        }

        private void FrmVerificacionEstrcutura_Load(object sender, EventArgs e)
        {
            this.proceso_sql();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void proceso_sql()
        {
            Clase.Estructura_SQL obj = new Clase.Estructura_SQL();
            //Area para crear la estructura de las Tablas ////
            #region fin_ventas

            NombreTable = "fin_ventas";
            Query = "CREATE TABLE fin_ventas(" +
                       "idventas int  identity(1,1)," +
                       "ccodrucemisor char(15) null," +
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
                       "ccodcos3 nchar(15)   NULL," +
                       "obserror text NULL,PRIMARY KEY CLUSTERED (idventas  ASC) )";


            string respuesta = "";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;
        
        #endregion
            #region fin_compras

            NombreTable = "fin_compras";
            Query = "CREATE TABLE fin_compras(idcompras int identity(1,1),ccodrucemisor char(15) null, ccod_empresa char(3) NULL," +
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
            "cctaotrib    nchar  (10) NULL,cctatot    nchar  (10) NULL,ccodcos    nchar  (9) NULL,ccodcos2    nchar  (9) NULL," +
            "nresp    numeric  (1,0) NULL,nporre    numeric  (5,2) NULL,nimpres    numeric  (15,2) NULL," +
            "cserre    nchar  (6) NULL,cnumre    nchar  (13) NULL,ffecre2    date   NULL,ccodpresu    nchar  (10) NULL," +
            "nigv    numeric  (5,2) NULL,cglosa    nchar  (50) NULL,nperdenre    numeric  (15,2) NULL,nbaseres    numeric  (15,2) NULL," +
            "cigvxacre    nchar  (1) NULL,created_at    datetime   default getdate()," +
            "updated_at    datetime   NULL,estado    varchar(255)   NULL,en_ambiente_de    varchar(255)   NULL," +
            "es_con_migracion   numeric(1,0) DEFAULT 0,"+
            "ccodcos3 nchar(15)   NULL," +
            "obserror text NULL,PRIMARY KEY CLUSTERED (idcompras  ASC) )";
            
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;

            #endregion
            #region fin_cobranza

            NombreTable = "fin_cobranza";
            Query = "CREATE TABLE fin_cobranza(idcobranza int IDENTITY(1,1) NOT NULL,"+
            "ccodrucemisor char(15) NULL," +
            "ccod_empresa char(3) NULL," +
            "cper char(4) NULL," +
            "cmes char(2) NULL," +
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
            "cglosa Char(80) NULL,"+
            "ccodcos Char(9) NULL,"+
            "ccodcos2 Char(9) NULL,"+
            "nporre Numeric(5,2) NULL,"+
            "nimpperc Numeric(15,2) NULL,"+
            "nperdenre Numeric(1) NULL,"+
            "cserre Char(6) NULL,"+
            "cnumre char(13) NULL,"+
            "ffecre date NULL,"+
            "created_at datetime NULL,"+
	        "updated_at datetime NULL,"+
	        "estado varchar(255) NULL,"+
	        "en_ambiente_de varchar(255) NULL,"+
	        "es_con_migracion numeric(1, 0) NULL,"+
	        "ccodcos3 nchar(15) NULL,"+
            "obserror text NULL) ";

            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;

            #endregion   
            #region fin_pagos

            NombreTable = "fin_pagos";
            Query = "CREATE TABLE fin_pagos(idpagos int IDENTITY(1,1) NOT NULL," +
            "ccodrucemisor char(15) NULL," +
            "ccod_empresa char(3) NULL," +
            "cper char(4) NULL," +
            "cmes char(2) NULL," +
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
            "obserror text NULL) ";

            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;

            #endregion
            #region ruc_emisor

            NombreTable = "cg_empemisor";
            Query = "create table cg_empemisor(" +
            "ccodrucemisor char(15) NOT NULL, " +
                        "cdesrucemisor char(200) NULL," +
                        "flgActivo bit NULL, " +
                        "PRIMARY KEY CLUSTERED " +
                        " (ccodrucemisor  ASC))";

            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;

            #endregion
            #region empresa

            NombreTable = "cg_empresa";
            Query = "CREATE TABLE cg_empresa(ccodrucemisor character(15), " +
                    "ccod_empresa character(3),nomempresa character(80))  ";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region usuarios
            NombreTable = "cg_usuario";
            Query= "CREATE TABLE cg_usuario(ccodusu character(10) NOT NULL DEFAULT ''," +
                   "cdesusu character(60) NOT NULL DEFAULT ''," +
                   "password character(250) NOT NULL DEFAULT ''," +
                   "fec_ultacceso datetime default getdate(),PRIMARY KEY CLUSTERED(ccodusu  ASC) )";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region configuracion
            NombreTable = "configuracion";
            Query = "CREATE TABLE configuracion(ccod_empresa Char(3) null," +
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
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region modulos
            NombreTable = "cg_modulos";
            Query = "CREATE TABLE cg_modulos(ccodmod character(10),cdesmod character(100))";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region acceso_usuario
            NombreTable = "cg_usuario_acceso";
            Query = "CREATE TABLE cg_usuario_acceso(ccodusu character(10) not null DEFAULT ''," +
                    "ccodmod  character(10) not null DEFAULT ''," +
                    "flgacceso NUMERIC(1,0) default 0)";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region version
            NombreTable = "cg_version";
            Query = "create table cg_version (" +
                    " cversion varchar(15) not null, " +
                    " cfecha datetime2 default GETDATE() not null,);";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region log
            NombreTable = "cg_log";
            Query = "CREATE TABLE cg_log(id INT IDENTITY(1,1)," +
                    "tipo_error TEXT NULL," +
                    "error_mensaje TEXT NULL," +
                    "fechahora datetime default Getdate()," +
                    "PRIMARY KEY CLUSTERED(id  ASC) )";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            //Area para Agregar Nuevos Campos a la tabla////
            #region campos_para_ventas
                NombreTable = "fin_ventas";
                Nombrecampo = "cubigeo";
                Query = "alter table "+ NombreTable.Trim().ToLower() + " add "+ Nombrecampo.Trim().ToLower()  +" nchar(6) not null default '';";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                txtMensaje.Text = "" + respuesta;
            #endregion
            #region campos_para_compras
                NombreTable = "fin_comparas";
                Nombrecampo = "cubigeo";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " nchar(6) not null default '';";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                txtMensaje.Text = "" + respuesta;
            #endregion


            //Area para crear o actualizar Store Procedure == Todo de empezar con create porque primero se borrar y se vuelve a crear  ////
            #region version
            NombreSP = "sp_select_version";
            Query = "create procedure sp_select_version as \n" +
                                    " begin  \n" +
                                    " select cversion   \n" +
                                    " From dbo.cg_version   \n" +
                                    " end; ";
            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region version_actualiza
            NombreSP = "sp_actualizar_version";
            Query = "create procedure sp_actualizar_version  \n" +
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
            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region compras_envio_resultado
            NombreSP = "sp_compras_envio_resultado";
            Query = "CREATE PROCEDURE sp_compras_envio_resultado \n" +
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
            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region envio_compras
            NombreSP = "sp_compras_envio";
            Query = " CREATE PROCEDURE sp_compras_envio  \n" +
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
            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region ventas_envio_resultado
            NombreSP = "sp_ventas_envio_resultado";
            Query = "CREATE PROCEDURE sp_ventas_envio_resultado\n" +
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
            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region envio_ventas
            NombreSP = "sp_ventas_envio";
            Query = " CREATE PROCEDURE sp_ventas_envio  \n" +
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
                                "		 case when ltrim(rtrim(isnull(convert(char(9),ccodcos2),''))) = '' then ' ' else ltrim(rtrim(convert(char(9),ccodcos2)))  end as ccodcos2,   \n" +
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
            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region envio_cobranza
            NombreSP = "sp_cobranza_envio";
            Query = " CREATE PROCEDURE sp_cobranza_envio  \n" +
                                " @prucEmisor char(15), \n" +
                                "  @empresa char(3)  \n" +
                                "  AS  \n" +
                                "  BEGIN  \n" +
                                "    Select  idcobranza,fin_cobranza.ccod_empresa,fin_cobranza.cper,cmes, \n" +
                                "    ltrim(rtrim(CONFIGURACION.csub1_com)) AS ccodori,\n" +
                                "    ltrim(rtrim(CONFIGURACION.clreg1_com)) AS ccodsu,\n" +
                                "    ltrim(rtrim(CONFIGURACION.cfefec_com)) AS ccodflu,\n" +
                                "    ltrim(rtrim(Convert(char(10), ffechacan, 112))) as ffechacan,    \n" +
                                "    ltrim(rtrim(isnull(cdoccan, ''))) as cdoccan,  \n" + 
                                "    ltrim(rtrim(isnull(csercan, ''))) as csercan,  \n" + 
                                "    ltrim(rtrim(isnull(cnumcan, ''))) as cdoccan,    \n" + 
                                "    ltrim(rtrim(isnull(ccuecan, ''))) as ccuecan,    \n" +
                                "    ltrim(rtrim(isnull(cmoncan, ''))) as cmoncan,      \n" +
                                "    isnull(nimporcan, 0.00) as nimporcan, \n" +
                                "    isnull(ntipcam, 0.00) as ntipcam ,\n" +
                                "    ltrim(rtrim(isnull(ccodpago, ''))) as ccodpago, \n" +
                                "    ltrim(rtrim(isnull(ccoddoc, ''))) as ccoddoc,\n" +
                                "    ltrim(rtrim(isnull(cserie, ''))) as cserie,\n" +
                                "    ltrim(rtrim(isnull(cnumero, ''))) as cnumero,\n" +
                                "    ltrim(rtrim(Convert(char(10), ffechadoc, 112))) as ffechadoc,  \n" +
                                "    ltrim(rtrim(Convert(char(10), ffechaven, 112))) as ffechaven,  \n" +
                                "    ltrim(rtrim(isnull(ccodenti, ''))) as ccodenti,\n" +
                                "    ltrim(rtrim(isnull(ccodruc, ''))) as ccodruc,\n" +
                                "    ltrim(rtrim(isnull(crazsoc, ''))) as crazsoc,\n" +
                                "    isnull(nimportes, 0.00) as nimportes, \n" +
                                "    isnull(nimported, 0.00) as nimported , \n" +
                                "    ltrim(rtrim(isnull(ccodcue, ''))) as ccodcue,\n" +
                                "    ltrim(rtrim(isnull(cglosa, ''))) as cglosa, \n" +
                                "    ltrim(rtrim(isnull(ccodcos, ''))) as ccodcos, \n" +
                                "    ltrim(rtrim(isnull(ccodcos2, ''))) as ccodcos2, \n" +
                                "    isnull(nporre, 0.00) as nporre, \n" +
                                "    isnull(nimpperc, 0.00) as nimpperc, \n" +
                                "    isnull(nperdenre, 0.00) as nperdenre, \n" +
                                "    ltrim(rtrim(isnull(cserre, ''))) as cserre, \n" +
                                "    ltrim(rtrim(isnull(cnumre, ''))) as cnumre, \n" +
                                "    ltrim(rtrim(Convert(char(10), ffecre, 112))) as ffecre,  \n" +
	                            "    case when ltrim(rtrim(isnull(estado,''))) = '' then '' else ltrim(rtrim(estado))  end as estado ,    \n" +
                                "    isnull(en_ambiente_de, '!') as en_ambiente_de,    \n" +
                                "    isnull(es_con_migracion, 0) as es_con_migracion,   \n" +
                                "    case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then '' else ltrim(rtrim(ccodcos3))  end as ccodcos3,  \n" +
		                        "    case when es_con_migracion = 3  then ltrim(rtrim(configuracion.cEnt_anula))  else '' end as ccodrucanula \n" +
                                "    From fin_cobranza \n" +
                                "    INNER JOIN configuracion ON fin_cobranza.CCOD_EMPRESA = CONFIGURACION.CCOD_EMPRESA AND fin_cobranza.CPER = configuracion.CPER \n" +
                                "    inner join CG_EMPRESA emp on fin_cobranza.ccodrucemisor = emp.ccodrucemisor and fin_cobranza.ccod_empresa = emp.CCOD_EMPRESA \n" +
                                "    inner join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1 \n" +
                                "    Where fin_cobranza.ccodrucemisor = @prucEmisor  and fin_cobranza.CCOD_EMPRESA = @empresa and es_con_migracion in (0, 3) AND CONFIGURACION.CTIPO = '03' \n"+
                                "    for json path \n" +
                                "    END   ";
            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region envio_pagos
            NombreSP = "sp_pagos_envio";
            Query = " CREATE PROCEDURE sp_pagos_envio  \n" +
                                " @prucEmisor char(15), \n" +
                                "  @empresa char(3)  \n" +
                                "  AS  \n" +
                                "  BEGIN  \n" +
                                "    Select  idpagos,fin_pagos.ccod_empresa,fin_pagos.cper,cmes, \n" +
                                "    ltrim(rtrim(CONFIGURACION.csub1_com)) AS ccodori,\n" +
                                "    ltrim(rtrim(CONFIGURACION.clreg1_com)) AS ccodsu,\n" +
                                "    ltrim(rtrim(CONFIGURACION.cfefec_com)) AS ccodflu,\n" +
                                "    ltrim(rtrim(Convert(char(10), ffechacan, 112))) as ffechacan,    \n" +
                                "    ltrim(rtrim(isnull(cdoccan, ''))) as cdoccan,  \n" +
                                "    ltrim(rtrim(isnull(csercan, ''))) as csercan,  \n" +
                                "    ltrim(rtrim(isnull(cnumcan, ''))) as cdoccan,    \n" +
                                "    ltrim(rtrim(isnull(ccuecan, ''))) as ccuecan,    \n" +
                                "    ltrim(rtrim(isnull(cmoncan, ''))) as cmoncan,      \n" +
                                "    isnull(nimporcan, 0.00) as nimporcan, \n" +
                                "    isnull(ntipcam, 0.00) as ntipcam ,\n" +
                                "    ltrim(rtrim(isnull(ccodpago, ''))) as ccodpago, \n" +
                                "    ltrim(rtrim(isnull(ccoddoc, ''))) as ccoddoc,\n" +
                                "    ltrim(rtrim(isnull(cserie, ''))) as cserie,\n" +
                                "    ltrim(rtrim(isnull(cnumero, ''))) as cnumero,\n" +
                                "    ltrim(rtrim(Convert(char(10), ffechadoc, 112))) as ffechadoc,  \n" +
                                "    ltrim(rtrim(Convert(char(10), ffechaven, 112))) as ffechaven,  \n" +
                                "    ltrim(rtrim(isnull(ccodenti, ''))) as ccodenti,\n" +
                                "    ltrim(rtrim(isnull(ccodruc, ''))) as ccodruc,\n" +
                                "    ltrim(rtrim(isnull(crazsoc, ''))) as crazsoc,\n" +
                                "    isnull(nimportes, 0.00) as nimportes, \n" +
                                "    isnull(nimported, 0.00) as nimported , \n" +
                                "    ltrim(rtrim(isnull(ccodcue, ''))) as ccodcue,\n" +
                                "    ltrim(rtrim(isnull(cglosa, ''))) as cglosa, \n" +
                                "    ltrim(rtrim(isnull(ccodcos, ''))) as ccodcos, \n" +
                                "    ltrim(rtrim(isnull(ccodcos2, ''))) as ccodcos2, \n" +
                                "    isnull(nporre, 0.00) as nporre, \n" +
                                "    isnull(nimpperc, 0.00) as nimpperc, \n" +
                                "    isnull(nperdenre, 0.00) as nperdenre, \n" +
                                "    ltrim(rtrim(isnull(cserre, ''))) as cserre, \n" +
                                "    ltrim(rtrim(isnull(cnumre, ''))) as cnumre, \n" +
                                "    ltrim(rtrim(Convert(char(10), ffecre, 112))) as ffecre,  \n" +
                                "    case when ltrim(rtrim(isnull(estado,''))) = '' then '' else ltrim(rtrim(estado))  end as estado ,    \n" +
                                "    isnull(en_ambiente_de, '!') as en_ambiente_de,    \n" +
                                "    isnull(es_con_migracion, 0) as es_con_migracion,   \n" +
                                "    case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then '' else ltrim(rtrim(ccodcos3))  end as ccodcos3,  \n" +
                                "    case when es_con_migracion = 3  then ltrim(rtrim(configuracion.cEnt_anula))  else '' end as ccodrucanula \n" +
                                "    From fin_pagos \n" +
                                "    INNER JOIN configuracion ON fin_pagos.CCOD_EMPRESA = CONFIGURACION.CCOD_EMPRESA AND fin_pagos.CPER = configuracion.CPER \n" +
                                "    inner join CG_EMPRESA emp on fin_pagos.ccodrucemisor = emp.ccodrucemisor and fin_pagos.ccod_empresa = emp.CCOD_EMPRESA \n" +
                                "    inner join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1 \n" +
                                "    Where fin_pagos.ccodrucemisor = @prucEmisor  and fin_pagos.CCOD_EMPRESA = @empresa and es_con_migracion in (0, 3) AND CONFIGURACION.CTIPO = '03' \n" +
                                "    for json path \n" +
                                "    END   ";
            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region cobranza_envio_resultado
            NombreSP = "sp_cobranza_envio_resultado";
            Query = "CREATE PROCEDURE sp_cobranza_envio_resultado  \n" +
                        " @resultado NVARCHAR(MAX) \n" +
                        " AS \n" +
                        " BEGIN \n" +
                        " UPDATE t \n" +
                        "        \n" +
                        "SET  \n" +
                        " t.es_con_migracion = r.resultado_migracion,	\n" +
                        " t.obserror = r.obserror  \n" +
                        " FROM fin_cobranza t \n" +
                        " JOIN OPENJSON(@resultado) \n" +
                        "            \n" +
                        "WITH(    \n" +
                        "idcobranza INT,  \n" +
                        "obserror NVARCHAR(MAX),  \n" +
                        "es_con_migracion INT,  \n" +
                        "resultado_migracion INT  \n" +
                        ") AS r  \n" +
                        "ON t.idcobranza = r.idcobranza and t.es_con_migracion = r.es_con_migracion;   \n" +
                        "END   ";

            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region pagos_envio_resultado
            NombreSP = "sp_pagos_envio_resultado";
            Query = "CREATE PROCEDURE sp_pagos_envio_resultado  \n" +
                        " @resultado NVARCHAR(MAX) \n" +
                        " AS \n" +
                        " BEGIN \n" +
                        " UPDATE t \n" +
                        "        \n" +
                        "SET  \n" +
                        " t.es_con_migracion = r.resultado_migracion,	\n" +
                        " t.obserror = r.obserror  \n" +
                        " FROM fin_pagos t \n" +
                        " JOIN OPENJSON(@resultado) \n" +
                        "            \n" +
                        "WITH(    \n" +
                        "idpagos INT,  \n" +
                        "obserror NVARCHAR(MAX),  \n" +
                        "es_con_migracion INT,  \n" +
                        "resultado_migracion INT  \n" +
                        ") AS r  \n" +
                        "ON t.idpagos = r.idpagos and t.es_con_migracion = r.es_con_migracion;   \n" +
                        "END   ";

            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion

        }
        /*********************************************************************************************************************/
        private void proceso_postgresl()
        {




        }
        /*********************************************************************************************************************/

    }
}
