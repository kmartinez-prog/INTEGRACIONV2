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
        int progreso = 0;
        public FrmVerificacionEstrcutura()
        {
            InitializeComponent();

        }

        private void FrmVerificacionEstrcutura_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                this.proceso_sql();
                
            }
            else
            {
                this.proceso_postgresl();
            }
           
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
        private void barraprogreso()
        {
            timer1.Start();
        }

        private void proceso_sql()
        {
            Clase.Estructura_SQL obj = new Clase.Estructura_SQL();
            //Area para crear la estructura de las Tablas ////
            #region fin_ventas
            this.barraprogreso();
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
                        txtMensaje.Refresh();
                        txtMensaje.Text = "" + respuesta;


            #endregion
            #region fin_compras
            this.barraprogreso();
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
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;

            #endregion
            #region fin_cobranza
            this.barraprogreso();
            NombreTable = "fin_cobranzapago";
            Query = "CREATE TABLE fin_cobranzapago(idcobranzapago int IDENTITY(1,1) NOT NULL," +
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
            "resultado_migracion numeric(1,0) NULL,"+
            "obserror text NULL) ";

            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;

            #endregion
            /*         #region fin_pagos

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

                     #endregion */
            #region ruc_emisor
            this.barraprogreso();
            NombreTable = "cg_empemisor";
            Query = "create table cg_empemisor(" +
            "ccodrucemisor char(15) NOT NULL, " +
                        "cdesrucemisor char(200) NULL," +
                        "flgActivo bit NULL, " +
                        "PRIMARY KEY CLUSTERED " +
                        " (ccodrucemisor  ASC))";

            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;

            #endregion
            #region empresa
            this.barraprogreso();
            NombreTable = "cg_empresa";
            Query = "CREATE TABLE cg_empresa(ccodrucemisor character(15), " +
                    "ccod_empresa character(3),nomempresa character(80))  ";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region usuarios
            this.barraprogreso();
            NombreTable = "cg_usuario";
            Query= "CREATE TABLE cg_usuario(ccodusu character(10) NOT NULL DEFAULT ''," +
                   "cdesusu character(60) NOT NULL DEFAULT ''," +
                   "password character(250) NOT NULL DEFAULT ''," +
                   "fec_ultacceso datetime default getdate(),PRIMARY KEY CLUSTERED(ccodusu  ASC) )";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region configuracion
            this.barraprogreso();
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
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region modulos
            this.barraprogreso();
            NombreTable = "cg_modulos";
            Query = "CREATE TABLE cg_modulos(ccodmod character(10),cdesmod character(100))";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region acceso_usuario
            this.barraprogreso();
            NombreTable = "cg_usuario_acceso";
            Query = "CREATE TABLE cg_usuario_acceso(ccodusu character(10) not null DEFAULT ''," +
                    "ccodmod  character(10) not null DEFAULT ''," +
                    "flgacceso NUMERIC(1,0) default 0)";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region version
            this.barraprogreso();
            NombreTable = "cg_version";
            Query = "create table cg_version (" +
                    " cversion varchar(15) not null, " +
                    " cfecha datetime2 default GETDATE() not null,);";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region log
            this.barraprogreso();
            NombreTable = "cg_log";
            Query = "CREATE TABLE cg_log(id INT IDENTITY(1,1)," +
                    "tipo_error TEXT NULL," +
                    "error_mensaje TEXT NULL," +
                    "fechahora datetime default Getdate()," +
                    "PRIMARY KEY CLUSTERED(id  ASC) )";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            //Area para Agregar Nuevos Campos a la tabla////
            #region campos_para_ventas
            this.barraprogreso();
                NombreTable = "fin_ventas";
                Nombrecampo = "cubigeo";
                Query = "alter table "+ NombreTable.Trim().ToLower() + " add "+ Nombrecampo.Trim().ToLower()  +" nchar(6) not null default '';";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region campos_para_compras
            this.barraprogreso();
            NombreTable = "fin_comparas";
                Nombrecampo = "cubigeo";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " nchar(6) not null default '';";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region campos_para_rucemiso
            this.barraprogreso();
            NombreTable = "cg_empemisor";
            Nombrecampo = "nventaflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;

            
            Nombrecampo = "ncompraflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;

            Nombrecampo = "ncobranzaflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;

            Nombrecampo = "npagoflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;


            #endregion


            //Area para crear o actualizar Store Procedure == Todo de empezar con create porque primero se borrar y se vuelve a crear  ////
            #region version
            this.barraprogreso();
            NombreSP = "sp_select_version";
            Query = "create procedure sp_select_version as \n" +
                                    " begin  \n" +
                                    " select cversion   \n" +
                                    " From dbo.cg_version   \n" +
                                    " end; ";
            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region version_actualiza
            this.barraprogreso();
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
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region compras_envio_resultado
            this.barraprogreso();
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
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region envio_compras
            this.barraprogreso();
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
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region ventas_envio_resultado
            this.barraprogreso();
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
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region envio_ventas
            this.barraprogreso();
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
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region cobranzapago_envio
            this.barraprogreso();
            NombreSP = "sp_cobranzapago_envio";
            Query = "CREATE PROCEDURE sp_cobranzapago_envio   \n" +
            " @prucEmisor char(15),    \n" +
            " @empresa char(3),   \n" +
            " @tipo int   \n" +
            "   AS   \n" +
            "   BEGIN   \n" +
            " Select  idcobranzapago,fin_cobranzapago.ccod_empresa,fin_cobranzapago.cper,fin_cobranzapago.cmes,    \n" +
            " ltrim(rtrim(CONFIGURACION.csub1_vta)) AS ccodori,   \n" +
            " ltrim(rtrim(CONFIGURACION.clreg1_vta)) AS ccodsu,   \n" +
            " ltrim(rtrim(CONFIGURACION.cfefec_vta)) AS ccodflu,   \n" +
            " fin_cobranzapago.ntipocobpag as ntipocobpag,   \n" +
            " ltrim(rtrim(Convert(char(10), ffechacan, 112))) as ffechacan,       \n" +
            " ltrim(rtrim(isnull(cdoccan, ''))) as cdoccan,     \n" +
            " ltrim(rtrim(isnull(csercan, ''))) as csercan,     \n" +
            " ltrim(rtrim(isnull(cnumcan, ''))) as cnumcan,       \n" +
            " ltrim(rtrim(isnull(ccuecan, ''))) as ccuecan,       \n" +
            " ltrim(rtrim(isnull(cmoncan, ''))) as cmoncan,         \n" +
            " isnull(nimporcan, 0.00) as nimporcan,    \n" +
            " isnull(ntipcam, 0.00) as ntipcam ,   \n" +
            " ltrim(rtrim(isnull(ccodpago, ''))) as ccodpago,    \n" +
            " ltrim(rtrim(isnull(ccoddoc, ''))) as ccoddoc,   \n" +
            " ltrim(rtrim(isnull(cserie, ''))) as cserie,   \n" +
            " ltrim(rtrim(isnull(cnumero, ''))) as cnumero,   \n" +
            " ltrim(rtrim(Convert(char(10), ffechadoc, 112))) as ffechadoc,     \n" +
            " ltrim(rtrim(Convert(char(10), ffechaven, 112))) as ffechaven,     \n" +
            " ltrim(rtrim(isnull(ccodenti, ''))) as ccodenti,   \n" +
            " ltrim(rtrim(isnull(ccodruc, ''))) as ccodruc,   \n" +
            " ltrim(rtrim(isnull(crazsoc, ''))) as crazsoc,   \n" +
            " isnull(nimportes, 0.00) as nimportes,    \n" +
            " isnull(nimported, 0.00) as nimported ,    \n" +
            " ltrim(rtrim(isnull(ccodcue, ''))) as ccodcue,   \n" +
            " ltrim(rtrim(isnull(cglosa, ''))) as cglosa,    \n" +
            " ltrim(rtrim(isnull(ccodcos, ''))) as ccodcos,    \n" +
            " ltrim(rtrim(isnull(ccodcos2, ''))) as ccodcos2,    \n" +
            " isnull(nporre, 0.00) as nporre,    \n" +
            " isnull(nimpperc, 0.00) as nimpperc,    \n" +
            " isnull(nperdenre, 0.00) as nperdenre,    \n" +
            " ltrim(rtrim(isnull(cserre, ''))) as cserre,    \n" +
            " ltrim(rtrim(isnull(cnumre, ''))) as cnumre,    \n" +
            " ltrim(rtrim(Convert(char(10), ffecre, 112))) as ffecre,     \n" +
            " case when ltrim(rtrim(isnull(estado,''))) = '' then '' else ltrim(rtrim(estado))  end as estado ,       \n" +
            " isnull(en_ambiente_de, '!') as en_ambiente_de,       \n" +
            " isnull(es_con_migracion, 0) as es_con_migracion,      \n" +
            " case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then '' else ltrim(rtrim(ccodcos3))  end as ccodcos3,     \n" +
            " case when es_con_migracion = 3  then ltrim(rtrim(configuracion.cEnt_anula))  else '' end as ccodrucanula   \n" +
            " From fin_cobranzapago   \n" +
            " INNER JOIN configuracion ON fin_cobranzapago.CCOD_EMPRESA = CONFIGURACION.CCOD_EMPRESA AND fin_cobranzapago.CPER = configuracion.CPER   \n" +
            " inner join CG_EMPRESA emp on fin_cobranzapago.ccodrucemisor = emp.ccodrucemisor and fin_cobranzapago.ccod_empresa = emp.CCOD_EMPRESA   \n" +
            " inner join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1    \n" +
            " Where fin_cobranzapago.ccodrucemisor = @prucEmisor and fin_cobranzapago.CCOD_EMPRESA = @empresa and es_con_migracion in (0, 3)   \n" +
            " AND CONFIGURACION.CTIPO = '03' and fin_cobranzapago.ntipocobpag = @tipo    \n" +
            " for json path    \n" +
            " END   ";
            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region cobranzapagos_envio_resultado
            this.barraprogreso();
            NombreSP = "sp_cobranzapago_envio_resultado";
            Query = "CREATE PROCEDURE sp_cobranzapago_envio_resultado  \n" +
                        " @resultado NVARCHAR(MAX) \n" +
                        " AS \n" +
                        " BEGIN \n" +
                        " UPDATE t \n" +
                        "        \n" +
                        "SET  \n" +
                        " t.es_con_migracion = r.resultado_migracion,	\n" +
                        " t.obserror = r.obserror  \n" +
                        " FROM fin_cobranzapago t \n" +
                        " JOIN OPENJSON(@resultado) \n" +
                        "            \n" +
                        "WITH(    \n" +
                        "idcobranzapago INT,  \n" +
                        "obserror NVARCHAR(MAX),  \n" +
                        "es_con_migracion INT,  \n" +
                        "resultado_migracion INT  \n" +
                        ") AS r  \n" +
                        "ON t.idcobranzapago = r.idcobranzapago and t.es_con_migracion = r.es_con_migracion;   \n" +
                        "END   ";

            respuesta = obj.crear_procedimiento(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion



            /*   #region envio_pagos
               NombreSP = "sp_pagos_envio";
               Query = " CREATE PROCEDURE sp_pagos_envio 
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
               #endregion */

            /* #region pagos_envio_resultado
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
             #endregion */

            

        }
        /*********************************************************************************************************************/
        private void proceso_postgresl()
        {
            Clase.Estructura_postgres obj = new Clase.Estructura_postgres();
            #region fin_ventas
            this.barraprogreso();
            NombreTable = "fin_ventas";
            Query = "create sequence sec_id_ventas minvalue 1 maxvalue 9999999999 increment by 1 "+
             " CREATE TABLE fin_ventas( "+
             " idventas      int   DEFAULT nextval('sec_id_ventas'::regclass), "+
             " ccodrucemisor char(15) NULL, " +
             " ccod_empresa  char(3) NULL, " +
             " cper   char(4) NULL, " +
             " cmes   char(2) NULL, " +
             " ffechadoc   date  NULL, " +
             " ffechaven   date  NULL, " +
             " ccoddoc  nchar(2) NULL, " +
             " cserie   nchar(20) NULL, " +
             " cnumero  nchar(20) NULL, " +
             " ccodenti nchar(11) NULL, " +
             " cdesenti nchar(100) NULL, " +
             " ctipdoc  nchar(1) NULL, " +
             " ccodruc  nchar(15) NULL, " +
             " crazsoc  nchar(100) NULL, " +
             " nbase2   numeric(15, 2) NULL, " +
             " nbase1   numeric(15, 2) NULL, " +
             " nexo     numeric(15, 2) NULL, " +
             " nina     numeric(15, 2) NULL, " +
             " nisc     numeric(15, 2) NULL, " +
             " nigv1    numeric(15, 2) NULL, " +
             " nicbpers numeric(15, 2) NULL, " +
             " nbase3   numeric(15, 2) NULL, " +
             " ntots    numeric(15, 2) NULL, " +
             " ntc      numeric(10, 6) NULL, " +
             " freffec  date  NULL, " +
             " crefdoc  nchar(2) NULL, " +
             " crefser  nchar(6) NULL, " +
             " crefnum  nchar(13) NULL, " +
             " cmreg    nchar(1) NULL, "+
             " ndolar   numeric(15, 2) NULL, "+
             " ffechaven2  date  NULL, " +
             " ccond       char(3) NULL, " +
             " ccodcos     nchar(15) NULL, " +
             " ccodcos2    nchar(15) NULL, " +
             " cctabase    nchar(20) NULL, " +
             " cctaicbper  nchar(20) NULL, " +
             " cctaotrib   nchar(20) NULL, "+
             " cctatot     nchar(20) NULL, " +
             " nresp   numeric(1, 0) NULL, "+
             " nporre  numeric(5, 2) NULL, " +
             " nimpres numeric(15, 2) NULL, " +
             " cserre   nchar(6) NULL, " +
             " cnumre   nchar(13) NULL, " +
             " ffecre   date  NULL, " +
             " ccodpresu  nchar(10) NULL, " +
             " nigv       numeric(5, 2) NULL, " +
             " cglosa     text NULL, " +
             " ccodpago   nchar(3) NULL, " +
             " nperdenre  numeric(1, 0) NULL, " +
             " nbaseres   numeric(15, 2) NULL, " +
             " cctaperc   nchar(20) NULL, " +
             " created_at date  NULL, " +
             " updated_at date  NULL, " +
             " estado     varchar(255) NULL, " +
             " en_ambiente_de   varchar(255) NULL, " +
             " es_con_migracion   numeric(1, 0) NULL, " +
             " ccodcos3   nchar(15) NULL, " +
             " obserror   text  NULL, " +
             " PRIMARY KEY(idventas)); ";

            string respuesta = "";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;

            #endregion
            #region fin_compras
            this.barraprogreso();
            NombreTable = "fin_compras";
            Query = " create sequence sec_id_compras minvalue 1 maxvalue 9999999999 increment by 1 ;"+
                    " CREATE TABLE fin_compras("+
                    " idcompras   int  DEFAULT nextval('sec_id_compras'::regclass)," +
                    " ccodrucemisor  char(15) NULL," +
                    " ccod_empresa   char(3) NULL," +
                    " cper   char(4) NULL," +
                    " cmes   char(2) NULL," +
                    " ffechadoc  date  NULL," +
                    " fechaven   date  NULL," +
                    " ccoddoc    nchar(2) NULL," +
                    " ccoddas    nchar(3) NULL," +
                    " cyeardas   nchar(4) NULL," +
                    " cserie     nchar(20) NULL," +
                    " cnumero    nchar(20) NULL," +
                    " ccodenti   nchar(11) NULL," +
                    " cdesenti   nchar(100) NULL," +
                    " ctipdoc    nchar(1) NULL," +
                    " ccodruc    nchar(15) NULL," +
                    " crazsoc    nchar(100) NULL," +
                    " ccodclas   nchar(1) NULL," +
                    " nbase1     numeric(15, 2) NULL," +
                    " nigv1      numeric(15, 2) NULL," +
                    " nbase2     numeric(15, 2) NULL," +
                    " nigv2      numeric(15, 2) NULL," +
                    " nbase3     numeric(15, 2) NULL," +
                    " nigv3   numeric(15, 2) NULL," +
                    " nina   numeric(15, 2) NULL," +
                    " nisc   numeric(15, 2) NULL," +
                    " nicbper   numeric(15, 2) NULL," +
                    " nexo   numeric(15, 2) NULL," +
                    " ntots   numeric(15, 2) NULL," +
                    " cdocnodom   nchar(20) NULL," +
                    " cnumdere   nchar(15) NULL," +
                    " ffecre   date  NULL," +
                    " ntc   numeric(10, 6) NULL," +
                    " freffec   date  NULL," +
                    " crefdoc   nchar(2) NULL," +
                    " crefser   nchar(6) NULL," +
                    " crefnum   nchar(13) NULL," +
                    " cmreg   nchar(1) NULL," +
                    " ndolar   numeric(15, 2) NULL," +
                    " ffechaven2   date  NULL," +
                    " ccond   nchar(3) NULL," +
                    " cctabase   nchar(10) NULL," +
                    " cctaicbper   nchar(10) NULL," +
                    " cctaotrib   nchar(10) NULL," +
                    " cctatot   nchar(10) NULL," +
                    " ccodcos   nchar(9) NULL," +
                    " ccodcos2   nchar(9) NULL," +
                    " nresp   numeric(1, 0) NULL," +
                    " nporre   numeric(5, 2) NULL," +
                    " nimpres   numeric(15, 2) NULL," +
                    " cserre   nchar(6) NULL," +
                    " cnumre   nchar(13) NULL," +
                    " ffecre2   date  NULL," +
                    " ccodpresu   nchar(10) NULL," +
                    " nigv   numeric(5, 2) NULL," +
                    " cglosa   nchar(50) NULL," +
                    " nperdenre   numeric(15, 2) NULL," +
                    " nbaseres   numeric(15, 2) NULL," +
                    " cigvxacre   nchar(1) NULL," +
                    " created_at   date  NULL," +
                    " updated_at   date  NULL," +
                    " estado   varchar(255) NULL," +
                    " en_ambiente_de   varchar(255) NULL," +
                    " es_con_migracion   numeric(1, 0) NULL," +
                    " ccodcos3   nchar(15) NULL," +
                    " obserror   text  NULL," +
                    " PRIMARY KEY(idcompras)); ";

            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;

            #endregion
            #region fin_cobranzas
            this.barraprogreso();
            NombreTable = "create sequence sec_idcobranzas minvalue 1 maxvalue 9999999999 increment by 1 " +
            "  CREATE TABLE fin_cobranzas( " +
            "  idcobranzas numeric(20,0), " +
            "  ccodrucemisor character(15) NOT NULL DEFAULT ''::bpchar, " +
            "  ccod_empresa character(3), " +
            "  cper character(4), " +
            "  cmes character(2), " +
            "  cdoccan character(2) NOT NULL DEFAULT ''::bpchar, " +
            "  csercan character(20) NOT NULL DEFAULT ''::bpchar, " +
            "  cnumcan character(20) NOT NULL DEFAULT ''::bpchar, " +
            "  ccuecan character(20) NOT NULL DEFAULT ''::bpchar, " +
            "  cmoncan character(1) NOT NULL DEFAULT ''::bpchar, " +
            "  nimporcan numeric(15,2) NOT NULL DEFAULT 0, " +
            "  ntipcam numeric(10,6) NOT NULL DEFAULT 0, " +
            "  ccodpago character(3) NOT NULL DEFAULT ''::bpchar, " +
            "  ccoddoc character(2) NOT NULL DEFAULT ''::bpchar, " +
            "  cserie character(20) NOT NULL DEFAULT ''::bpchar, " +
            "  cnumero character(20) NOT NULL DEFAULT ''::bpchar, " +
            "  ffechadoc date, " +
            "  ffechaven date, " +
            "  ccodruc character(15) NOT NULL DEFAULT ''::bpchar, " +
            "  crazsoc character(150) NOT NULL DEFAULT ''::bpchar, " +
            "  nimportes numeric(15,2) NOT NULL DEFAULT 0, " +
            "  nimported numeric(15,2) NOT NULL DEFAULT 0, " +
            "  ccodcue character(20) NOT NULL DEFAULT ''::bpchar, " +
            "  cglosa text, " +
            "  ccodcos character(15) NOT NULL DEFAULT ''::bpchar, " +
            "  ccodcos2 character(15) NOT NULL DEFAULT ''::bpchar, " +
            "  nporre numeric(5,2) NOT NULL DEFAULT 0, " +
            "  nimpperc numeric(15,2) NOT NULL DEFAULT 0, " +
            "  nperdenre numeric(1,0) NOT NULL DEFAULT 0, " +
            "  cserre character(6) NOT NULL DEFAULT ''::bpchar, " +
            "  cnumre character(13) NOT NULL DEFAULT ''::bpchar, " +
            "  ffecre date, " +
            "  obserror text, " +
            "  resultado_migracion numeric(1,0), " +
            "  created_at date, " +
            "  updated_at date , " +
            "  estado character(255) NOT NULL DEFAULT ''::bpchar, " +
            "  en_ambiente_de character(255) NOT NULL DEFAULT ''::bpchar, " +
            "  es_con_migracion numeric(1, 0) NULL, " +
            "  ccodcos3 character(15) NOT NULL DEFAULT ''::bpchar )";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;

            #endregion
            /*   #region fin_pagos

               NombreTable = "fin_pagos";
               Query = "create sequence sec_idpagos minvalue 1 maxvalue 9999999999 increment by 1 " +
               "  CREATE TABLE fin_pagos( " +
               "  idpagos numeric(20,0), " +
               "  ccodrucemisor character(15) NOT NULL DEFAULT ''::bpchar, " +
               "  ccod_empresa character(3), " +
               "  cper character(4), " +
               "  cmes character(2), " +
               "  cdoccan character(2) NOT NULL DEFAULT ''::bpchar, " +
               "  csercan character(20) NOT NULL DEFAULT ''::bpchar, " +
               "  cnumcan character(20) NOT NULL DEFAULT ''::bpchar, " +
               "  ccuecan character(20) NOT NULL DEFAULT ''::bpchar, " +
               "  cmoncan character(1) NOT NULL DEFAULT ''::bpchar, " +
               "  nimporcan numeric(15,2) NOT NULL DEFAULT 0, " +
               "  ntipcam numeric(10,6) NOT NULL DEFAULT 0, " +
               "  ccodpago character(3) NOT NULL DEFAULT ''::bpchar, " +
               "  ccoddoc character(2) NOT NULL DEFAULT ''::bpchar, " +
               "  cserie character(20) NOT NULL DEFAULT ''::bpchar, " +
               "  cnumero character(20) NOT NULL DEFAULT ''::bpchar, " +
               "  ffechadoc date, " +
               "  ffechaven date, " +
               "  ccodruc character(15) NOT NULL DEFAULT ''::bpchar, " +
               "  crazsoc character(150) NOT NULL DEFAULT ''::bpchar, " +
               "  nimportes numeric(15,2) NOT NULL DEFAULT 0, " +
               "  nimported numeric(15,2) NOT NULL DEFAULT 0, " +
               "  ccodcue character(20) NOT NULL DEFAULT ''::bpchar, " +
               "  cglosa text, " +
               "  ccodcos character(15) NOT NULL DEFAULT ''::bpchar, " +
               "  ccodcos2 character(15) NOT NULL DEFAULT ''::bpchar, " +
               "  nporre numeric(5,2) NOT NULL DEFAULT 0, " +
               "  nimpperc numeric(15,2) NOT NULL DEFAULT 0, " +
               "  nperdenre numeric(1,0) NOT NULL DEFAULT 0, " +
               "  cserre character(6) NOT NULL DEFAULT ''::bpchar, " +
               "  cnumre character(13) NOT NULL DEFAULT ''::bpchar, " +
               "  ffecre date, " +
               "  obserror text, " +
               "  resultado_migracion numeric(1,0), " +
               "  created_at date, " +
               "  updated_at date , " +
               "  estado character(255) NOT NULL DEFAULT ''::bpchar, " +
               "  en_ambiente_de character(255) NOT NULL DEFAULT ''::bpchar, " +
               "  es_con_migracion numeric(1, 0) NULL, " +
               "  ccodcos3 character(15) NOT NULL DEFAULT ''::bpchar )";

               respuesta = obj.crear_tablas(NombreTable, Query);
               txtMensaje.Text = "" + respuesta;

               #endregion */

            #region ruc_emisor
            this.barraprogreso();
            NombreTable = "cg_empemisor";
            Query = "CREATE TABLE cg_empemisor(" +
            " ccodrucemisor char(15) NOT NULL, " +
            " cdesrucemisor char(200) NULL, " +
            " flgActivo bit NULL," +
            " PRIMARY KEY(ccodrucemisor) ); ";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;

            #endregion
            #region empresa
            this.barraprogreso();
            NombreTable = "cg_empresa";
            Query = "CREATE TABLE cg_empresa(" +
            "  ccodrucemisor char(15) NULL," +
            "  ccod_empresa char(3) NULL, " +
            "  nomempresa char(80) NULL, " +
            "  PRIMARY KEY(ccodrucemisor, ccod_empresa) );";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region usuarios
            this.barraprogreso();
            NombreTable = "cg_usuario";
            Query = "CREATE TABLE cg_usuario(  " +
                    " ccodusu char(10) NOT NULL," +
                    " cdesusu char(60) NOT NULL," +
                    " password char(250) NOT NULL," +
                    " fec_ultacceso date NULL," +
                    " PRIMARY KEY(ccodusu));";

            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region configuracion
            this.barraprogreso();
            NombreTable = "configuracion";
            Query = "CREATE TABLE configuracion( "+
            " ccod_empresa char(3) NULL, " +
            " cper char(4) NULL, " +
            " crazemp char(100) NULL, " +
            " crucemp char(15) NULL, " +
            " cEntidad char(3) NULL, " +
            " csub1_vta char(3) NULL, " +
            " clreg1_vta char(20) NULL, " +
            " csub2_vta char(3) NULL, " +
            " clreg2_vta char(20) NULL, " +
            " cconts_vta char(20) NULL, " +
            " ccontd_vta char(20) NULL, " +
            " cfefec_vta char(4) NULL, "+
            " ctares_vta numeric(1, 0) NULL, "+
            " ctaimp_vta numeric(1, 0) NULL,"+
	        " Ctaact_vta numeric(1, 0) NULL,"+
	        " asientos_vta numeric(1, 0) NULL,"+
	        " csub1_com char(3) NULL,"+
	        " clreg1_com char(20) NULL,"+
	        " csub2_com char(3) NULL,"+
	        " clreg2_com char(20) NULL,"+
	        " cconts_com char(20) NULL,"+
	        " ccontd_com char(20) NULL,"+
	        " cfefec_com char(4) NULL,"+
	        " ctares_com numeric(1, 0) NULL,"+
	        " ctaimp_com numeric(1, 0) NULL,"+
	        " Ctapas_com numeric(1, 0) NULL,"+
	        " asientos_com numeric(1, 0) NULL,"+
	        " cTipo char(2) NULL,"+
            " cEnt_anula char(15) NULL);";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region modulos
            this.barraprogreso();
            NombreTable = "cg_modulos";
            Query = "CREATE TABLE cg_modulos( " +
                    " ccodmod char(10) NULL," +
                    " cdesmod char(100) NULL) ;";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region acceso_usuario
            this.barraprogreso();
            NombreTable = " CREATE TABLE cg_usuario_acceso( "+
            " ccodusu char(10) NOT NULL,"+
            " ccodmod char(10) NOT NULL,"+
            " flgacceso numeric(1, 0) NULL);";
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region version
            this.barraprogreso();
            NombreTable = "cg_version";
            Query = txtversion.Text;

            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region log
            this.barraprogreso();
            NombreTable = "cg_log";
            Query = "create sequence sec_id_log minvalue 1 maxvalue 9999999999 increment by 1 ;" +
            " CREATE TABLE cg_log( " +
            " id int DEFAULT nextval('sec_id_log'::regclass)," +
            " tipo_error text NULL," +
            " error_mensaje text NULL," +
            " fechahora date NULL," +
            " PRIMARY KEY(id));"; 
            respuesta = obj.crear_tablas(NombreTable, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion

            //Area para Agregar Nuevos Campos a la tabla////
            #region campos_para_ventas
            this.barraprogreso();
            NombreTable = "fin_ventas";
            Nombrecampo = "cubigeo";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " nchar(6) not null default '';";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region campos_para_compras
            this.barraprogreso();
            NombreTable = "fin_comparas";
            Nombrecampo = "cubigeo";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " nchar(6) not null default '';";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region campos_para_rucemiso
            this.barraprogreso();
            NombreTable = "cg_empemisor";
            Nombrecampo = "nventaflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;

            this.barraprogreso();
            Nombrecampo = "ncompraflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            this.barraprogreso();
            Nombrecampo = "ncobranzaflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            this.barraprogreso();
            Nombrecampo = "npagoflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;


            #endregion


            //Area para crear o actualizar function en postgresql == Todo de empezar con create porque primero se borrar y se vuelve a crear  ////
            #region version
            this.barraprogreso();
            NombreSP = "fn_select_version";
            Query = " CREATE OR REPLACE FUNCTION fn_select_version() \n" +
                    " ETURNS table(cversion character) AS  \n" +
                    " $BODY$  \n" +
                    " BEGIN  \n" +
                    " return query select t.cversion from cg_version t; \n" +
                    " end;  \n" +
                    " $BODY$  \n" +
                    " LANGUAGE plpgsql VOLATILE  \n" +
                    " COST 100; ";
            respuesta = obj.crear_funcion(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region version_actualiza
            this.barraprogreso();
            NombreSP = "fn_actualizar_version";
            Query = "CREATE OR REPLACE FUNCTION fn_actualizar_version(in p_version character(15))  \n" +
                    " RETURNS void AS  \n" +
                    " $BODY$  \n" +
                    " BEGIN  \n" +
                    " if ((select true from cg_version limit 1) is null) then   \n" +
                    " insert into cg_version(cversion) values(p_version);  \n" +
                    " else  \n" +
                    " update cg_version set cversion = p_version, cfecha = now();  \n" +
                    " end if;  \n" +
                    "    \n" +
                    " end;  \n" +
                    " $BODY$  \n" +
                    " LANGUAGE plpgsql VOLATILE  \n" +
                    " COST 100;  ";
            respuesta = obj.crear_funcion(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region compras_envio_resultado
            this.barraprogreso();
            NombreSP = "fn_compras_envio_resultado";
            Query =  "CREATE OR REPLACE FUNCTION fn_compras_envio_resultado(p_datos text)  \n" +
                    " RETURNS void AS  \n" +
                    " $BODY$   \n" +
                    " DECLARE  \n" +
                    " v_data json;  \n" +
                    " BEGIN  \n" +
                    "           \n" +
                    " v_data:= p_datos::json; \n" +
                    " UPDATE fin_compras t \n" +
                    " SET es_con_migracion = r.resultado_migracion, \n" +
                    " obserror = r.obserror \n" +
                    " from json_to_recordset(v_data) as r (idcompras integer, obserror text, es_con_migracion integer, resultado_migracion integer) \n" +
                    " where t.idcompras = r.idcompras and t.es_con_migracion = r.es_con_migracion; \n" +
                    "  \n" +
                    " END; \n" +
                    " $BODY$   \n" +
                    " LANGUAGE plpgsql VOLATILE  \n" +
                    " COST 100; ";
            respuesta = obj.crear_funcion(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region envio_compras
            this.barraprogreso();
            NombreSP = "fn_compras_envio";
            Query = "CREATE OR REPLACE FUNCTION fn_compras_envio( \n" +
                    " OUT resultado text,   \n" +
                    " IN p_ruc_emisor character,  \n" +
                    " IN p_empresa character)   \n" +
                    " RETURNS text AS  \n" +
                    " $BODY$  \n" +
                    " BEGIN  \n" +
                    "        \n" +
                    " select json_agg(to_json(t))::text  \n" +
                    " from(     \n" +
                    " select   \n" +
                    " idcompras, fin_compras.ccod_empresa, fin_compras.cper, cmes,    \n" +
                    " trim(configuracion.csub1_com) as ccodori,   \n" +
                    " trim(configuracion.clreg1_com) as ccodsu,   \n" +
                    " trim(configuracion.csub2_com) as ccodori_p,   \n" +
                    " trim(configuracion.clreg2_com) as ccodsu_p,   \n" +
                    " trim(configuracion.cconts_com) as ccodcue_ps,   \n" +
                    " trim(configuracion.ccontd_com) as ccodcue_pd,   \n" +
                    " trim(configuracion.cfefec_com) as ccodflu,   \n" +
                    " configuracion.ctares_com as flgctares,   \n" +
                    " configuracion.ctaimp_com as flgctaimp,   \n" +
                    " configuracion.ctapas_com as flgctaact,  \n" +
                    " configuracion.asientos_com as flggencomp,  \n" +
                    " trim(configuracion.cEntidad) as ccodtipent,  \n" +
                    " to_char(ffechadoc, 'YYYY-MM-DD') as ffechadoc, --trim(Convert(char(10), ffechadoc, 112)) as ffechadoc,  \n" +
                    " to_char(fechaven, 'YYYY-MM-DD') as fechaven, --trim(Convert(char(10), fechaven, 112)) as fechaven,  \n" +
                    " trim(ccoddoc) as ccoddoc, \n" +
                    " trim(coalesce(ccoddas, '')) as ccoddas,  \n" +
                    " trim(coalesce(cyeardas, '')) as cyeardas,  \n" +
                    " trim(cserie) as cserie,  \n" +
                    " trim(cnumero) as cnumero,  \n" +
                    " trim(fin_compras.ccodenti) as ccodenti,  \n" +
                    " trim(cdesenti) as cdesenti, \n" +
                    " trim(ctipdoc) as ctipdoc, \n" +
                    " trim(ccodruc) as ccodruc, \n" +
                    " trim(crazsoc) as crazsoc, \n" +
                    " trim(coalesce(ccodclas, '')) as ccodclas, \n" +
                    " nbase1, nigv1, \n" +
                    " coalesce(nbase2, 0.00) as nbase2, \n" +
                    " coalesce(nigv2, 0.00) as nigv2, \n" +
                    " coalesce(nbase3, 0.00) as nbase3, \n" +
                    " coalesce(nigv3, 0.00) as nigv3, \n" +
                    " coalesce(nina, 0.00) as nina, \n" +
                    " coalesce(nisc, 0.00) as nisc, \n" +
                    " coalesce(nicbper, 0.00) as nicbper, \n" +
                    " coalesce(nexo, 0.00) as nexo, \n" +
                    " coalesce(ntots, 0.00) as ntots, \n" +
                    " case when trim(coalesce(cdocnodom, '')) = '' then '' else trim(cdocnodom)  end as cdocnodom,    \n" +
                    " case when trim(coalesce(cnumdere,'')) = '' then '' else trim(cnumdere)  end as cnumdere,     \n" +
                    " to_char(ffecre, 'YYYY-MM-DD') as ffecre, --trim(coalesce(Convert(char(10), ffecre, 112), '')) as ffecre,     \n" +
                    " ntc, \n" +
                    " to_char(freffec, 'YYYY-MM-DD') as freffec, --trim(coalesce(Convert(char(10), freffec, 112), '')) as freffec, \n" +
                    "  case when trim(coalesce(crefdoc,'')) = '' then '' else trim(crefdoc)  end as crefdoc,     \n" +
                    " case when trim(coalesce(crefser,'')) = '' then '' else trim(crefser)  end as crefser,     \n" +
                    " case when trim(coalesce(crefnum,'')) = '' then '' else trim(crefnum)  end as crefnum,     \n" +
                    " case when trim(coalesce(cmreg,'')) = '' then '' else trim(cmreg)  end as cmreg,     \n" +
                    " coalesce(ndolar, 0.00) as ndolar, \n" +
                    " to_char(ffechaven2, 'YYYY-MM-DD') as ffechaven2, --trim(coalesce(Convert(char(10), ffechaven2, 112), '')) as ffechaven2, \n" +
                    " case when trim(coalesce(ccond,'')) = '' then '' else trim(ccond)  end as ccond,     \n" +
                    " case when trim(coalesce(cctabase,'')) = '' then '' else trim(cctabase)  end as cctabase,  \n" +
                    " case when trim(coalesce(cctaicbper,'')) = '' then '' else trim(cctaicbper)  end as cctaicbper,  \n" +
                    " case when trim(coalesce(cctaotrib,'')) = '' then '' else trim(cctaotrib)  end as cctaotrib,     \n" +
                    " case when trim(coalesce(cctatot,'')) = '' then '' else trim(cctatot)  end as cctatot,     \n" +
                    " case when trim(coalesce(ccodcos,'')) = '' then '' else trim(ccodcos)  end as ccodcos,     \n" +
                    " case when trim(coalesce(ccodcos2,'')) = '' then '' else trim(ccodcos2)  end as ccodcos2,     \n" +
                    " coalesce(nresp, 0.00) as nresp,     \n" +
                    " coalesce(nporre, 0.00) as nporre,    \n" +
                    " coalesce(nimpres, 0.00) as nimpres,     \n" +
                    " case when trim(coalesce(cserre,'')) = '' then'' else trim(cserre)  end as cserre,    \n" +
                    " case when trim(coalesce(cnumre,'')) = '' then '' else trim(cnumre)  end as cnumre,     \n" +
                    " to_char(ffecre2, 'YYYY-MM-DD') as ffecre2, --trim(coalesce(Convert(char(10), ffecre2, 112), '')) as ffecre2 ,     \n" +
                    " case when trim(coalesce(ccodpresu,'')) = '' then '' else trim(cnumre)  end as ccodpresu,     \n" +
                    " nigv,     \n" +
                    " case when trim(coalesce(cglosa,'')) = '' then '' else trim(cglosa)  end as cglosa,    \n" +
                    " coalesce(nperdenre, 0.00) nperdenre,    \n" +
                    " coalesce(nbaseres, 0.00) as nbaseres,     \n" +
                    " case when trim(coalesce(cigvxacre,'')) = '' then '' else trim(cigvxacre)  end as cigvxacre,     \n" +
                    " case when trim(coalesce(estado,'')) = '' then '' else trim(estado)  end as estado ,     \n" +
                    " coalesce(en_ambiente_de, '!') as en_ambiente_de,     \n" +
                    " coalesce(es_con_migracion, 0) as es_con_migracion,    \n" +
                    " case when trim(coalesce(ccodcos3,'')) = '' then '' else trim(ccodcos3)  end as ccodcos3,    \n" +
                    " case when es_con_migracion = 3  then trim(configuracion.cent_anula)  else '' end as ccodrucanula \n" +
                    " from fin_compras \n" +
                    " join configuracion ON fin_compras.CCOD_EMPRESA = configuracion.CCOD_EMPRESA AND FIN_COMPRAS.CPER = configuracion.CPER \n" +
                    " join CG_EMPRESA emp on FIN_COMPRAS.ccodrucemisor = emp.ccodrucemisor and FIN_COMPRAS.ccod_empresa = emp.CCOD_EMPRESA \n" +
                    " join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1::bit   \n" +
                    "  where fin_compras.ccodrucemisor = p_ruc_emisor::character(15)  \n" +
                    " and fin_compras.ccod_empresa = p_empresa::character(3)  \n" +
                    " and es_con_migracion in (0, 3)  \n" +
                    " and configuracion.CTIPO = '02'  \n" +
                    " ) t   \n" +
                    "    \n" +
                    " into resultado;  \n" +
                    "    \n" +
                    " END; \n" +
                    " $BODY$ \n" +
                    " LANGUAGE plpgsql VOLATILE  \n" +
                    " COST 100;  \n" +
                    " ALTER FUNCTION fn_compras_envio(character, character)  \n" +
                    " OWNER TO postgres;  ";
            respuesta = obj.crear_funcion(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region ventas_envio_resultado
            this.barraprogreso();
            NombreSP = "fn_ventas_envio_resultado";
            Query = " CREATE OR REPLACE FUNCTION fn_ventas_envio_resultado(p_datos text) \n" +
                    " RETURNS void AS \n" +
                    " $BODY$ \n" +
                    " DECLARE \n" +
                    " v_data json; \n" +
                    " BEGIN \n" +
                    "    \n" +
                    " v_data:= p_datos::json;  \n" +
                    " UPDATE fin_ventas t   \n" +
                    " SET es_con_migracion = r.resultado_migracion,  \n" +
                    " obserror = r.obserror   \n" +
                    " from json_to_recordset(v_data) as r (idventas integer, obserror text, es_con_migracion integer, resultado_migracion integer)  \n" +
                    " where t.idventas = r.idventas and t.es_con_migracion = r.es_con_migracion;  \n" +
                    "   \n" +
                    " END;  \n" +
                    " $BODY$   \n" +
                    " LANGUAGE plpgsql VOLATILE   \n" +
                    " COST 100;   \n" +
                    " ALTER FUNCTION fn_ventas_envio_resultado(text)  \n" +
                    " OWNER TO postgres; ";
            respuesta = obj.crear_funcion(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region envio_ventas
            this.barraprogreso();
            NombreSP = "fn_ventas_envio";
            Query = " CREATE OR REPLACE FUNCTION fn_ventas_envio(  \n" +
                    "    OUT resultado text,  \n" +
                    "    IN p_ruc_emisor character,  \n" +
                    "    IN p_empresa character)  \n" +
                    "    RETURNS text AS  \n" +
                    "    $BODY$  \n" +
                    "    BEGIN  \n" +
                    "     \n" +
                    " select json_agg(to_json(t))::text  \n" +
                    " from(  \n" +
                    " select  \n" +
            " idventas, fin_ventas.ccod_empresa, fin_ventas.cper, cmes,  \n" +
            " trim(configuracion.csub1_vta) AS ccodori,  \n" +
            " trim(configuracion.clreg1_vta) AS ccodsu,  \n" +
            " trim(configuracion.csub2_vta) AS ccodori_p,  \n" +
            " trim(configuracion.clreg2_vta) AS ccodsu_p,  \n" +
            " trim(configuracion.cconts_vta) AS ccodcue_ps,  \n" +
            " trim(configuracion.ccontd_vta) AS ccodcue_pd,  \n" +
            " trim(configuracion.cfefec_vta) AS ccodflu,  \n" +
            " configuracion.ctares_vta AS flgctares,  \n" +
            " configuracion.ctaimp_vta AS flgctaimp,   \n" +
            " configuracion.Ctaact_vta AS flgctaact,  \n" +
            " configuracion.asientos_vta AS flggencomp,  \n" +
            " trim(configuracion.cEntidad) AS ccodtipent,  \n" +
            " to_char(ffechadoc, 'YYYY-MM-DD') AS ffechadoc, --trim(Convert(char(10), ffechadoc, 112)) AS ffechadoc,  \n" +
            " to_char(ffechaven, 'YYYY-MM-DD') AS ffechaven, --trim(Convert(char(10), ffechaven, 112)) AS ffechaven,  \n" +
            " trim(ccoddoc) AS ccoddoc,  \n" +
            " trim(cserie) AS cserie,  \n" +
            " trim(cnumero) AS cnumero,  \n" +
            " trim(ccodenti) AS ccodenti,  \n" +
            " trim(cdesenti) AS cdesenti,  \n" +
            " trim(ctipdoc) AS ctipdoc,  \n" +
            " trim(ccodruc) AS ccodruc,  \n" +
            " trim(crazsoc) AS crazsoc,  \n" +  
            " coalesce(nbase2, 0.00) as nbase2,  \n" +
            " coalesce(nbase1, 0.00) as nbase1,   \n" +
            " coalesce(nexo, 0.00) as nexo,   \n" +
            " coalesce(nina, 0.00) as nina,   \n" +
            " coalesce(nisc, 0.00) as nisc,   \n" +
            " coalesce(nigv1, 0.00) as nigv1,    \n" +
            " coalesce(nicbpers, 0.00) as nicbpers,   \n" +
            " coalesce(nbase3, 0.00) as nbase3,   \n" +
            " coalesce(ntots, 0.00) as ntots,   \n" +
            " coalesce(ntc, 0.00) as ntc,  \n" +
            " to_char(freffec, 'YYYY-MM-DD') AS freffec, --trim(coalesce(Convert(char(10), freffec, 112), ' ')) AS freffec,  \n" +
            " case when trim(coalesce(crefdoc, '')) = '' then ' ' else trim(crefdoc)  end as crefdoc,    \n" +
            " case when trim(coalesce(crefser,'')) = '' then ' ' else trim(crefser)  end as crefser,    \n" +
            " case when trim(coalesce(crefnum,'')) = '' then ' ' else trim(crefnum)  end as crefnum,   \n" +
            " case when trim(coalesce(cmreg,'')) = '' then ' ' else trim(cmreg)  end as cmreg,    \n" +
            " coalesce(ndolar, 0.00) as ndolar,     \n" +
            " to_char(ffechaven2, 'YYYY-MM-DD') AS ffechaven2, --trim(coalesce(Convert(char(10), ffechaven2, 112), ' ') AS ffechaven2,  \n" +
            " case when trim(coalesce(ccond, '')) = '' then ' ' else trim(ccond)  end as ccond,     \n" +
            " case when trim(coalesce(substring(ccodcos,1,9),'')) = '' then ' ' else trim(substring(ccodcos, 1, 9))  end as ccodcos,  \n" +
            " case when trim(coalesce(substring(ccodcos2,1,9),'')) = '' then ' ' else trim(substring(ccodcos2, 1, 9))  end as ccodcos2,  \n" +
            " case when trim(coalesce(cctabase,'')) = '' then ' ' else trim(cctabase)  end as cctabase,     \n" +
            " case when trim(coalesce(cctaicbper,'')) = '' then ' ' else trim(cctaicbper)  end as cctaicbper,     \n" +
            " case when trim(coalesce(cctaotrib,'')) = '' then ' ' else trim(cctaotrib)  end as cctaotrib,     \n" +
            " case when trim(coalesce(cctatot,'')) = '' then ' ' else trim(cctatot)  end as cctatot,     \n" +
            " coalesce(nresp, 0.00) as nresp,     \n" +
            " coalesce(nporre, 0.00) as nporre,     \n" +
            " coalesce(nimpres, 0.00) as nimpres,     \n" +
            " case when trim(coalesce(cserre,'')) = '' then ' ' else trim(cserre)  end as cserre,     \n" +
            " case when trim(coalesce(cnumre,'')) = '' then ' ' else trim(cnumre)  end as cnumre,     \n" +
            " to_char(ffecre, 'YYYY-MM-DD') AS ffecre, --trim(coalesce(Convert(char(10), ffecre, 112), ' ') AS ffecre,  \n" +
            " case when trim(coalesce(ccodpresu, '')) = '' then ' ' else trim(ccodpresu)  end as ccodpresu,     \n" +
            " coalesce(nigv, 0.00) as nigv,     \n" +
            " case when trim(coalesce(substring(cglosa,1,80),'')) = '' then ' ' else trim(substring(cglosa, 1, 80))  end::character(80) as cglosa,    \n" +
            " case when trim(coalesce(ccodpago,'')) = '' then ' ' else trim(ccodpago)  end as ccodpago,     \n" +
            " coalesce(nperdenre, 0.00) as nperdenre,     \n" +
            " coalesce(nbaseres, 0.00) as nbaseres,     \n" +
            " case when trim(coalesce(cctaperc,'')) = '' then ' ' else trim(cctaperc)  end as cctaperc,    \n" +
            " case when trim(coalesce(estado,'')) = '' then ' ' else trim(estado)  end as estado,     \n" +
            " case when trim(coalesce(en_ambiente_de,'')) = '' then ' ' else trim(en_ambiente_de)  end as en_ambiente_de,     \n" +
            " es_con_migracion,     \n" +
            " case when trim(coalesce(ccodcos3,'')) = '' then ' ' else trim(ccodcos3)  end as ccodcos3,     \n" +
            " case when es_con_migracion = 3  then trim(configuracion.cEnt_anula)  else '' end as ccodrucanula  \n" +
            " from fin_ventas  \n" +
            " join configuracion ON fin_ventas.CCOD_EMPRESA = configuracion.CCOD_EMPRESA and fin_ventas.CPER = configuracion.CPER  \n" +
            " join CG_EMPRESA emp on fin_ventas.ccodrucemisor = emp.ccodrucemisor and fin_ventas.ccod_empresa = emp.CCOD_EMPRESA  \n" +
            " join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1::bit  \n" +
            " where fin_ventas.ccodrucemisor = p_ruc_emisor::character(15)  \n" +
            " and fin_ventas.ccod_empresa = p_empresa::character(3)  \n" +
            " and es_con_migracion in (0, 3)  \n" +
            " and configuracion.ctipo = '01'   \n" +
            " ) t   \n" +
            " into resultado;   \n" +
            "   \n" +
            " END;  \n" +
            " $BODY$   \n" +
            " LANGUAGE plpgsql VOLATILE   \n" +
            " COST 100;   \n" +
            "    ALTER FUNCTION fn_ventas_envio(character, character)   \n" +
            " OWNER TO postgres; ";
            respuesta = obj.crear_funcion(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region envio_cobranza
            this.barraprogreso();
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
                                "    Where fin_cobranza.ccodrucemisor = @prucEmisor  and fin_cobranza.CCOD_EMPRESA = @empresa and es_con_migracion in (0, 3) AND CONFIGURACION.CTIPO = '03' \n" +
                                "    for json path \n" +
                                "    END   ";
            respuesta = obj.crear_funcion(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region cobranza_envio_resultado
            this.barraprogreso();
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

            respuesta = obj.crear_funcion(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region envio_cobranza
            this.barraprogreso();
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
                                "    Where fin_cobranza.ccodrucemisor = @prucEmisor  and fin_cobranza.CCOD_EMPRESA = @empresa and es_con_migracion in (0, 3) AND CONFIGURACION.CTIPO = '03' \n" +
                                "    for json path \n" +
                                "    END   ";
            respuesta = obj.crear_funcion(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion
            #region cobranza_envio_resultado
            this.barraprogreso();
            NombreSP = "fn_cobranzas_envio_resultado";
            Query = " CREATE OR REPLACE FUNCTION fn_cobranzas_envio_resultado(p_datos text) \n" +
                    " RETURNS void AS  \n" +
                    " $BODY$  \n" +
                    " DECLARE  \n" +
                    " v_data json;  \n" +
                    " BEGIN  \n" +
                    "   \n" +
                    " v_data:= p_datos::json;  \n" +
                    " UPDATE fin_cobranzas t  \n" +
                    " SET es_con_migracion = r.resultado_migracion,  \n" +
                    " obserror = r.obserror  \n" +
                    " from json_to_recordset(v_data) as r (idcobranzas integer, obserror text, es_con_migracion integer, resultado_migracion integer)  \n" +
                    " where t.idcobranzas = r.idcobranzas and t.es_con_migracion = r.es_con_migracion;  \n" +
                    "  \n" +
                    " END;  \n" +
                    " $BODY$  \n" +
                    " LANGUAGE plpgsql VOLATILE  \n" +
                    " COST 100;  \n" +
                    " ALTER FUNCTION fn_cobranzas_envio_resultado(text)  \n" +
                    " OWNER TO postgres;  ";
            respuesta = obj.crear_funcion(NombreSP, Query);
            txtMensaje.Refresh();
            txtMensaje.Text = "" + respuesta;
            #endregion


            /*    #region envio_pagos
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
                respuesta = obj.crear_funcion(NombreSP, Query);
                txtMensaje.Text = "" + respuesta;
                #endregion */


            /*#region pagos_envio_resultado
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

            respuesta = obj.crear_funcion(NombreSP, Query);
            txtMensaje.Text = "" + respuesta;
            #endregion */
            /*  #region envio_pagos
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
              respuesta = obj.crear_funcion(NombreSP, Query);
              txtMensaje.Text = "" + respuesta;
              #endregion */
            /*    #region pagos_envio_resultado
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

                respuesta = obj.crear_funcion(NombreSP, Query);
                txtMensaje.Text = "" + respuesta;
                #endregion */
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pBarra.Value = progreso;
            progreso += 1;
            this.label1.Text = (progreso-1).ToString() + "%";
            if (progreso > pBarra.Maximum)
            {
                timer1.Stop();
                progreso = 0;
                this.Refresh();
                txtMensaje.Text = "Proceso terminado.";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /*********************************************************************************************************************/

    }
}
