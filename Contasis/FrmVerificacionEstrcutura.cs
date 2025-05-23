﻿using System;
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
        /////string Fechaejecucion;
        int progreso = 0;
        string respuesta = "";
        
        public FrmVerificacionEstrcutura()
        {
            InitializeComponent();

        }

        private void FrmVerificacionEstrcutura_Load(object sender, EventArgs e)
        {
            ////MessageBox.Show(Properties.Settings.Default.TipModulo.ToString());

            


            if (Properties.Settings.Default.TipModulo == "")
            {
                this.Text = "Verificación de estructura en Financiero";
            }

            if (Properties.Settings.Default.TipModulo=="1")
            {
                this.Text = "Verificación de estructura en Financiero";
            }
            if (Properties.Settings.Default.TipModulo == "2")
            {
                this.Text = "Verificación de estructura en Comercial";
            }



            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                this.Proceso_sql();
            }
            else
            {
                this.Proceso_postgresl();
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
        private void Btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void Barraprogreso(string texto)
        {
            Timer1.Start();
        //    this.txtMensaje.Text = "" + texto;
          ///  this.txtMensaje.Refresh();
        }
        private void Proceso_sql()
        {
            Clase.Estructura_SQL obj = new Clase.Estructura_SQL();
            //Area para crear la estructura de las Tablas inicia para el integrador con contable ////
            #region ruc_emisor

            NombreTable = "cg_empemisor";
            Query = "create table cg_empemisor(" +
            "ccodrucemisor char(15) NOT NULL, " +
                        "cdesrucemisor char(200) NULL," +
                        "flgActivo bit NULL, " +
                        "nventaflg numeric(1,0)  NULL, "+
                        "ncompraflg numeric(1,0)  NULL,"+
                        "ncobranzaflg numeric(1,0)   NULL,"+
	                    "npagoflg numeric(1,0)   NULL,"+
                        "ncomproductoflg numeric(1,0)   NULL," +
                        "ncomcompraflg numeric(1,0)   NULL," +
                        "ncomventaflg numeric(1,0)   NULL," +
                        "PRIMARY KEY CLUSTERED " +
                        " (ccodrucemisor  ASC))";

            respuesta = obj.Crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);

            #endregion
            #region empresa

            NombreTable = "cg_empresa";
            Query = "CREATE TABLE cg_empresa(ccodrucemisor character(15), " +
                    "ccod_empresa character(3),nomempresa character(80))  ";
            respuesta = obj.Crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region usuarios

            NombreTable = "cg_usuario";
            Query = "CREATE TABLE cg_usuario(ccodusu character(10) NOT NULL DEFAULT ''," +
                   "cdesusu character(60) NOT NULL DEFAULT ''," +
                   "password character(250) NOT NULL DEFAULT ''," +
                   "fec_ultacceso datetime default getdate(),PRIMARY KEY CLUSTERED(ccodusu  ASC) )";
            respuesta = obj.Crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region modulos

            NombreTable = "cg_modulos";
            Query = "CREATE TABLE cg_modulos(ccodmod character(10),cdesmod character(100))";
            respuesta = obj.Crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region acceso_usuario

            NombreTable = "cg_usuario_acceso";
            Query = "CREATE TABLE cg_usuario_acceso(ccodusu character(10) not null DEFAULT ''," +
                    "ccodmod  character(10) not null DEFAULT ''," +
                    "flgacceso NUMERIC(1,0) default 0)";
            respuesta = obj.Crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region version

            NombreTable = "cg_version";
            Query = "create table cg_version (" +
                    " cversion varchar(15) not null, " +
                    " cfecha datetime2 default GETDATE() not null,);";
            respuesta = obj.Crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region log

            NombreTable = "cg_log";
            Query = "CREATE TABLE cg_log(id INT IDENTITY(1,1)," +
                    "tipo_error TEXT NULL," +
                    "error_mensaje TEXT NULL," +
                    "fechahora datetime default Getdate()," +
                    "PRIMARY KEY CLUSTERED(id  ASC) )";
            respuesta = obj.Crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_para_configuracion
            NombreTable = "configuracion";
            Nombrecampo = "ffecha_inicioproceso";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  date null ";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion

            #region cg_moduloconfigura
            NombreTable = "cg_moduloconfigura";
            Query = "CREATE TABLE IF NOT EXISTS public.cg_moduloconfigura  \n" +
                    "(  \n" +
                    "id bigint default 0 ),\n" +
                    "cmodulo character(20)  \n" +
                    ");";
            respuesta = obj.Crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion



            #region configuracion2
            NombreTable = "configuracion2";
            Query = "CREATE TABLE configuracion2( " +
                    "id int IDENTITY(1,1) NOT NULL, " +
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
                    "Prodanula char(15) NULL) ";
            respuesta = obj.Crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_para_configuracion2
            NombreTable = "configuracion2";
            Nombrecampo = "ffecha_inicioproceso";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  date null ";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion

            //* comercial *//
            #region campos_para_configuracion2
            NombreTable = "configuracion2";
            Nombrecampo = "ccodoripago";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  char(3) null ";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion

            #region campos_para_configuracion2
            NombreTable = "configuracion2";
            Nombrecampo = "clibropago";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  char(2) null ";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion

            #region campos_para_configuracion2
            NombreTable = "configuracion2";
            Nombrecampo = "ccodflupago";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  char(4) null ";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion

            NombreTable = "cg_empemisor";
            Nombrecampo = "ncobranzacomercial";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + "   Numeric(1,0) default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);




            #region campos_para_rucemiso
            NombreTable = "cg_empemisor";
            Nombrecampo = "nventaflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);

            Nombrecampo = "ncomFondom";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);



            Nombrecampo = "ncompraflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);

            Nombrecampo = "ncobranzaflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);

            Nombrecampo = "npagoflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);

            Nombrecampo = "ncomproductoflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);

            Nombrecampo = "ncomcompraflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);

            Nombrecampo = "ncomventaflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);


            #endregion
            #region campos_para_conexiones
            NombreTable = "conexiones";
            Nombrecampo = "nModulo";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);


            Nombrecampo = "ncompraflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);

            Nombrecampo = "ncobranzaflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);

            Nombrecampo = "npagoflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
            respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);


            #endregion
            //Area para crear la estructura de las Tablas Types////
            #region tp_resultado

            NombreTable = "tp_resultado";
            Query = "CREATE TYPE dbo.tp_resultado AS TABLE (" +
                    "id INT," +
                    "obserror NVARCHAR(MAX)," +
                    "es_con_migracion INT," +
                    "resultado_migracion INT);";
            respuesta = obj.Crear_types(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region tp_id

            NombreTable = "tp_id";
            Query = "CREATE TYPE tp_id AS TABLE(" +
                    " id int ) ";
            respuesta = obj.Crear_types(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            if (Properties.Settings.Default.TipModulo == "1")
            {
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
                string respuesta = "";
                respuesta = obj.Crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion
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
                
                
                respuesta = obj.Crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);

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
                "es_con_migracion   numeric(1,0) DEFAULT 0," +
                "ccodcos3 nchar(15)   NULL," +
                "obserror text NULL,PRIMARY KEY CLUSTERED (idcompras  ASC) )";

                respuesta = obj.Crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);

                #endregion
                #region fin_cobranza

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
                "obserror text NULL,"+
                "es_anticipo_automatico numeric(1,0) not null default 0 )";
                respuesta = obj.Crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);

                #endregion
                //Area para Agregar Nuevos Campos a la tabla////
                #region campos_para_ventas

                NombreTable = "fin_ventas";
                Nombrecampo = "cubigeo";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " nchar(6) not null default '';";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region campos_para_compras

                NombreTable = "fin_comparas";
                Nombrecampo = "cubigeo";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " nchar(6) not null default '';";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region campos_para_configuracion
                NombreTable = "configuracion";
                Nombrecampo = "ffecha_inicioproceso";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  date null ";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region campos_para_rucemiso
                NombreTable = "cg_empemisor";
                Nombrecampo = "nventaflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncomFondom";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);


                Nombrecampo = "ncompraflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncobranzaflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "npagoflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncomproductoflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncomcompraflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncomventaflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);


                #endregion


                NombreTable = "cg_empemisor";
                Nombrecampo = "ncobranzacomercial";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + "   Numeric(1,0) default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                #region campos_para_configuracion2
                NombreTable = "configuracion2";
                Nombrecampo = "ffecha_inicioproceso";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  date null ";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
                #endregion

                //Area para Agregar Nuevas funciones////
                #region fn_cobranzapago_envio

                NombreSP = "fn_cobranzapago_envio";
                Query = " CREATE FUNCTION fn_cobranzapago_envio(  \n" +
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
                respuesta = obj.Crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_compras_envio

                NombreSP = "fn_compras_envio";
                Query = " CREATE FUNCTION fn_compras_envio (  \n" +
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
                respuesta = obj.Crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_ventas_envio

                NombreSP = "fn_ventas_envio";
                Query = "CREATE FUNCTION fn_ventas_envio (  \n" +
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
                        "		and configuracion.ctipo = '01'    ); ";
                respuesta = obj.Crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                //Area para crear o actualizar Store Procedure == Todo de empezar con create porque primero se borrar y se vuelve a crear  ////
                #region version

                NombreSP = "sp_select_version";
                Query = "create procedure sp_select_version as \n" +
                                        " begin  \n" +
                                        " select cversion   \n" +
                                        " From dbo.cg_version   \n" +
                                        " end; ";
                respuesta = obj.Crear_procedimiento(NombreSP, Query);
                this.Barraprogreso(respuesta);
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
                respuesta = obj.Crear_procedimiento(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region ventas_envio_resultado

                NombreSP = "sp_ventas_envio_resultado";
                Query = "CREATE PROCEDURE dbo.sp_ventas_envio_resultado   \n" +
                "	@resultado dbo.tp_resultado READONLY   \n" +
                "   AS    \n" +
                "	BEGIN  \n" +
                "	UPDATE t  \n" +
                "	SET   \n" +
                "		t.es_con_migracion = r.resultado_migracion, \n" +
                "		t.obserror = r.obserror \n" +
                "	FROM fin_ventas t \n" +
                "	JOIN @resultado r \n" +
                "	ON t.idventas = r.id and t.es_con_migracion = r.es_con_migracion; \n" +
                "	END ;";
                respuesta = obj.Crear_procedimiento(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion

                #region envio_ventas

                NombreSP = "sp_ventas_envio";
                Query = "CREATE PROCEDURE sp_ventas_envio    \n" +
                "	@prucEmisor char(15),  \n" +
                "	@empresa char(3)   \n" +
                "   AS   \n" +
                "   BEGIN    \n" +
                "	select top 1000    \n" +
                "   idventas, fin_ventas.ccod_empresa,fin_ventas.cper,cmes,       \n" +
                "   ltrim(rtrim(configuracion.csub1_vta)) AS ccodori,    \n" +
                "    ltrim(rtrim(configuracion.clreg1_vta)) AS ccodsu,    \n" +
                "    ltrim(rtrim(configuracion.csub2_vta)) AS ccodori_p,    \n" +
                "    ltrim(rtrim(configuracion.clreg2_vta)) AS ccodsu_p,    \n" +
                "        ltrim(rtrim(configuracion.cconts_vta)) AS ccodcue_ps,    \n" +
                "        ltrim(rtrim(configuracion.ccontd_vta)) AS ccodcue_pd,   \n" +
                "        ltrim(rtrim(configuracion.cfefec_vta)) AS ccodflu,    \n" +
                "        ltrim(rtrim(configuracion.ctares_vta)) AS flgctares,    \n" +
                "        ltrim(rtrim(configuracion.ctaimp_vta)) AS flgctaimp,   \n" +
                "        ltrim(rtrim(configuracion.Ctaact_vta)) AS flgctaact,   \n" +
                "        ltrim(rtrim(configuracion.asientos_vta)) AS flggencomp,   \n" +
                "        ltrim(rtrim(configuracion.cEntidad)) AS ccodtipent,    \n" +
                "        ltrim(rtrim(Convert(char(10), ffechadoc, 112))) as ffechadoc,    \n" +
                "        ltrim(rtrim(Convert(char(10), ffechaven, 112))) as ffechaven,    \n" +
                "        ltrim(rtrim(ccoddoc)) as ccoddoc,   \n" +
                "        ltrim(rtrim(cserie)) as cserie,   \n" +
                "        ltrim(rtrim(cnumero)) as cnumero,   \n" +
                "        ltrim(rtrim(ccodenti)) as ccodenti,   \n" +
                "        ltrim(rtrim(cdesenti)) as cdesenti,  \n" +
                "        ltrim(rtrim(ctipdoc)) as ctipdoc,   \n" +
                "        ltrim(rtrim(ccodruc)) as ccodruc,   \n" +
                "        ltrim(rtrim(crazsoc)) as crazsoc,   \n" +
                "        Isnull(nbase2, 0.00) as nbase2,    \n" +
                "        Isnull(nbase1, 0.00) as nbase1,   \n" +
                "        Isnull(nexo, 0.00) as nexo,   \n" +
                "        Isnull(nina, 0.00) as nina,    \n" +
                "        Isnull(nisc, 0.00) as nisc,  \n" +
                "        Isnull(nigv1, 0.00) as nigv1,  \n" +
                "        Isnull(nicbpers, 0.00) as nicbpers,  \n" +
                "        Isnull(nbase3, 0.00) as nbase3,   \n" +
                "        Isnull(ntots, 0.00) as ntots,   \n" +
                "        Isnull(ntc, 0.00) as ntc,   \n" +
                "        ltrim(rtrim(Isnull(Convert(char(10), freffec, 112), ' '))) as freffec ,   \n" +
                "        case when ltrim(rtrim(isnull(crefdoc,''))) = '' then ' ' else ltrim(rtrim(crefdoc))  end as crefdoc,   \n" +
                "        case when ltrim(rtrim(isnull(crefser,''))) = '' then ' ' else ltrim(rtrim(crefser))  end as crefser,   \n" +
                "        case when ltrim(rtrim(isnull(crefnum,''))) = '' then ' ' else ltrim(rtrim(crefnum))  end as crefnum,  \n" +
                "        case when ltrim(rtrim(isnull(cmreg,''))) = '' then ' ' else ltrim(rtrim(cmreg))  end as cmreg,   \n" +
                "        Isnull(ndolar, 0.00) as ndolar,    \n" +
                "        ltrim(rtrim(Isnull(Convert(char(10), ffechaven2, 112), ' '))) as ffechaven2,    \n" +
                "        case when ltrim(rtrim(isnull(ccond,''))) = '' then ' ' else ltrim(rtrim(ccond))  end as ccond,    \n" +
                "        case when ltrim(rtrim(isnull(convert(char(9),substring(ccodcos,1,9)),''))) = '' then ' ' else ltrim(rtrim(convert(char(9),substring(ccodcos,1,9))))  end as ccodcos,   \n" +
                "        case when ltrim(rtrim(isnull(convert(char(9),substring(ccodcos2,1,9)),''))) = '' then ' ' else ltrim(rtrim(convert(char(9),substring(ccodcos2,1,9))))  end as ccodcos2,    \n" +
                "        case when ltrim(rtrim(isnull(cctabase,''))) = '' then ' ' else ltrim(rtrim(cctabase))  end as cctabase,    \n" +
                "        case when ltrim(rtrim(isnull(cctaicbper,''))) = '' then ' ' else ltrim(rtrim(cctaicbper))  end as cctaicbper,    \n" +
                "        case when ltrim(rtrim(isnull(cctaotrib,''))) = '' then ' ' else ltrim(rtrim(cctaotrib))  end as cctaotrib,    \n" +
                "        case when ltrim(rtrim(isnull(cctatot,''))) = '' then ' ' else ltrim(rtrim(cctatot))  end as cctatot,    \n" +
                "        Isnull(nresp, 0.00) as nresp,    \n" +
                "        Isnull(nporre, 0.00) as nporre,    \n" +
                "        Isnull(nimpres, 0.00) as nimpres,    \n" +
                "        case when ltrim(rtrim(isnull(cserre,''))) = '' then ' ' else ltrim(rtrim(cserre))  end as cserre,    \n" +
                "        case when ltrim(rtrim(isnull(cnumre,''))) = '' then ' ' else ltrim(rtrim(cnumre))  end as cnumre,    \n" +
                "        ltrim(rtrim(Isnull(Convert(char(10), ffecre, 112), ' '))) as ffecre,    \n" +
                "        case when ltrim(rtrim(isnull(ccodpresu,''))) = '' then ' ' else ltrim(rtrim(ccodpresu))  end as ccodpresu,    \n" +
                "        Isnull(nigv, 0.00) as nigv,    \n" +
                "        case when ltrim(rtrim(isnull(convert(char(80),substring(cglosa,1,80)) ,''))) = '' then ' ' else ltrim(rtrim(convert(char(80),substring(cglosa,1,80)) ))  end as cglosa,    \n" +
                "        case when ltrim(rtrim(isnull(ccodpago,''))) = '' then ' ' else ltrim(rtrim(ccodpago))  end as ccodpago,    \n" +
                "        Isnull(nperdenre, 0.00) as nperdenre,    \n" +
                "        Isnull(nbaseres, 0.00) as nbaseres,    \n" +
                "        case when ltrim(rtrim(isnull(cctaperc,''))) = '' then ' ' else ltrim(rtrim(cctaperc))  end as cctaperc,   \n" +
                "        case when ltrim(rtrim(isnull(estado,''))) = '' then ' ' else ltrim(rtrim(estado))  end as estado,    \n" +
                "        case when ltrim(rtrim(isnull(en_ambiente_de,''))) = '' then ' ' else ltrim(rtrim(en_ambiente_de))  end as en_ambiente_de,    \n" +
                "        es_con_migracion,    \n" +
                "        case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then ' ' else ltrim(rtrim(ccodcos3))  end as ccodcos3,    \n" +
                "        case when es_con_migracion=3  then  ltrim(rtrim(configuracion.cEnt_anula))  else '' end  as ccodrucanula \n" +
                "	     from fin_ventas   \n" +
                "	     inner join configuracion on fin_ventas.ccod_empresa = configuracion.ccod_empresa and fin_ventas.cper = configuracion.cper \n" +
                "	     inner join cg_empresa emp on fin_ventas.ccodrucemisor = emp.ccodrucemisor and fin_ventas.ccod_empresa = emp.ccod_empresa  \n" +
                "	     inner join cg_empemisor empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1   \n" +
                "	     where fin_ventas.ccodrucemisor = @prucEmisor \n" +
                "		 and fin_ventas.ccod_empresa = @empresa \n" +
                "		 and es_con_migracion in (0, 3) \n" +
                "		 and configuracion.ctipo = '01' \n" +
                " 	     and  fin_ventas.ffechadoc >=  configuracion.ffecha_inicioproceso \n" +
                "        END   ";
                respuesta = obj.Crear_procedimiento(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region compras_envio_resultado

                NombreSP = "sp_compras_envio_resultado";
                Query = " CREATE PROCEDURE sp_compras_envio_resultado \n" +
                        " @resultado dbo.tp_resultado READONLY \n" +
                        " AS \n" +
                        " BEGIN \n" +
                        "  \n" +
                        " UPDATE t \n" +
                        " \n" +
                        " SET \n" +
                        " t.es_con_migracion = r.resultado_migracion, \n" +
                        " t.obserror = r.obserror \n" +
                        "  \n" +
                        " FROM fin_compras t \n" +
                        " JOIN @resultado r \n" +
                        "  \n" +
                        " ON t.idcompras = r.id and t.es_con_migracion = r.es_con_migracion; \n" +
                        " END; ";
                respuesta = obj.Crear_procedimiento(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region envio_compras

                NombreSP = "sp_compras_envio";
                Query = "CREATE PROCEDURE dbo.sp_compras_envio    \n" +
                        "	@prucEmisor char(15),  \n" +
                        "	@empresa char(3)    \n" +
                        "	AS     \n" +
                        "	BEGIN \n" +
                        "	select \n" +
                        "       idcompras, fin_compras.ccod_empresa, fin_compras.cper, cmes, \n" +
                        "        ltrim(rtrim(configuracion.csub1_com)) AS ccodori, \n" +
                        "       ltrim(rtrim(configuracion.clreg1_com)) AS ccodsu, \n" +
                        "        ltrim(rtrim(configuracion.csub2_com)) AS ccodori_p, \n" +
                        "        ltrim(rtrim(configuracion.clreg2_com)) AS ccodsu_p, \n" +
                        "        ltrim(rtrim(configuracion.cconts_com)) AS ccodcue_ps, \n" +
                        "        ltrim(rtrim(configuracion.ccontd_com)) AS ccodcue_pd, \n" +
                        "        ltrim(rtrim(configuracion.cfefec_com)) AS  ccodflu, \n" +
                        "        ltrim(rtrim(configuracion.ctares_com)) AS flgctares, \n" +
                        "        ltrim(rtrim(configuracion.ctaimp_com)) AS flgctaimp, \n" +
                        "        ltrim(rtrim(configuracion.Ctapas_com)) AS flgctaact, \n" +
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
                        "        case when ltrim(rtrim(isnull(cctaicbper,''))) = '' then '' else ltrim(rtrim(cctaicbper))  end  as cctaicbper, \n" +
                        "        case when ltrim(rtrim(isnull(cctaotrib,''))) = '' then '' else ltrim(rtrim(cctaotrib))  end  as cctaotrib,     \n" +
                        "        case when ltrim(rtrim(isnull(cctatot,''))) = '' then '' else ltrim(rtrim(cctatot))  end  as cctatot,     \n" +
                        "        case when ltrim(rtrim(isnull(ccodcos,''))) = '' then '' else ltrim(rtrim(ccodcos))  end  as ccodcos,     \n" +
                        "        isnull(nimpres,0.00) as nimpres,     \n" +
                        "        case when ltrim(rtrim(isnull(cserre,''))) = '' then '' else ltrim(rtrim(cserre))  end  as cserre,    \n" +
                        "        case when ltrim(rtrim(isnull(cnumre,''))) = '' then '' else ltrim(rtrim(cnumre))  end  as cnumre,     \n" +
                        "        ltrim(rtrim(isnull(Convert(char(10), ffecre2, 112),''))) as ffecre2 ,     \n" +
                        "        case when ltrim(rtrim(isnull(ccodpresu,''))) = '' then '' else ltrim(rtrim(cnumre))  end  as ccodpresu,     \n" +
                        "        nigv, \n" +
                        "        case when ltrim(rtrim(isnull(cglosa,''))) = '' then '' else ltrim(rtrim(cglosa))  end  as cglosa, \n" +
                        "        isnull(nperdenre,0.00) nperdenre, \n" +
                        "        isnull(nbaseres,0.00) as nbaseres, \n" +
                        "        case when ltrim(rtrim(isnull(cigvxacre,''))) = '' then '' else ltrim(rtrim(cigvxacre)) end as cigvxacre, \n" +
                        "        case when ltrim(rtrim(isnull(estado,''))) = '' then '' else ltrim(rtrim(estado))  end  as estado, \n" +
                        "        isnull(en_ambiente_de,'!') as en_ambiente_de, \n" +
                        "        isnull(es_con_migracion,0)as es_con_migracion,    \n" +
                        "        case when ltrim(rtrim(isnull(ccodcos3,''))) = '' then '' else ltrim(rtrim(ccodcos3))  end as ccodcos3, \n" +
                        "        case when es_con_migracion=3 then ltrim(rtrim(configuracion.cEnt_anula))  else '' end as ccodrucanula \n" +
                        "    	 from fin_compras \n" +
                        "	inner join configuracion on fin_compras.ccod_empresa = configuracion.ccod_empresa and fin_compras.cper = configuracion.cper   \n" +
                        "	inner join cg_empresa emp on fin_compras.ccodrucemisor = emp.ccodrucemisor and fin_compras.ccod_empresa = emp.ccod_empresa  \n" +
                        "	inner join cg_empemisor empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1   \n" +
                        "	where fin_compras.ccodrucemisor = @prucEmisor  \n" +
                        "		and fin_compras.ccod_empresa = @empresa \n" +
                        "		and es_con_migracion in (0, 3)  and fin_compras.ffechadoc >= configuracion.ffecha_inicioproceso \n" + 
                        "		and configuracion.CTIPO = '02'; \n" +
                        "END; ";
                respuesta = obj.Crear_procedimiento(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region cobranzapago_envio

                NombreSP = "sp_cobranzapago_envio";
                Query = "CREATE PROCEDURE sp_cobranzapago_envio    \n" +
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
                "		and CONFIGURACION.CTIPO = '03'  and fin_cobranzapago.ffechadoc >= configuracion.ffecha_inicioproceso \n" +
                "END";
                respuesta = obj.Crear_procedimiento(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region cobranzapagos_envio_resultado

                NombreSP = "sp_cobranzapago_envio_resultado";
                Query = "CREATE PROCEDURE dbo.sp_cobranzapago_envio_resultado   \n" +
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
                        " END;  ";
                respuesta = obj.Crear_procedimiento(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
            }

            if (Properties.Settings.Default.TipModulo == "2")
            {
                string respuesta = "";
                //Area para crear la estructura de las Tablas inicia para el integrador solo comercial ////
                #region modulo_comercial
                NombreTable = "modulo_comercial";
                Query = "create table modulo_comercial( " +
                       "ccodmudulo Char(6) null, " +
                       "cdesmodulo char(50) null)";
                
                respuesta = obj.Crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                obj.Insertar_datos_fijos();
                #endregion
                #region campos_para_rucemiso
                NombreTable = "cg_empemisor";
                Nombrecampo = "nventaflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                
                
                Nombrecampo = "ncomFondom";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);



                Nombrecampo = "ncompraflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncobranzaflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "npagoflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncomproductoflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncomcompraflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncomventaflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                /// AGREGAR CAMPOS NUEVOS 28/03/2025//
                NombreTable = "com_documento";
                Nombrecampo = "ccond";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " char(3)  null ;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                NombreTable = "com_documento";
                Nombrecampo = "ccuecan";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " char(20) null ;";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);


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
                
                respuesta = obj.Crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion



                #region configuracion2

                NombreTable = "configuracion2";
                Query = "CREATE TABLE configuracion2( " +
                        "id int IDENTITY(1,1) NOT NULL, " +
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
                        "Prodanula char(15) NULL) ";
                respuesta = obj.Crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region com_documento
                NombreTable = "com_documento";
                 Query = "CREATE TABLE com_documento (\n" +
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
                        "	obserror text NULL ,   \n" +
                        "   ccond char(3) NULL,    \n" +
                        "   ccuecan char(20) NULL ) ";
                respuesta = obj.Crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region com_detalledocumento
                NombreTable = "com_detalledocumento";
                Query = "CREATE TABLE com_detalledocumento( \n" +
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
                        "   ) ";
                respuesta = obj.Crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion

             /*   #region index_1_com_detalledocumento
                NombreTable = "com_detalledocumento";
                Query = "ALTER TABLE com_detalledocumento  WITH CHECK ADD  CONSTRAINT [fk_detalle_documento] FOREIGN KEY([iddocumento]) \n" +
                        " REFERENCES.com_documento(iddocumento)";
                respuesta = obj.Crear_tablas_index(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion
             
                #region index_2_com_detalledocumento
                NombreTable = "com_detalledocumento";
                Query = "ALTER TABLE com_detalledocumento CHECK CONSTRAINT fk_detalle_documento";
                respuesta = obj.Crear_tablas_index(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion

                */

                #region com_producto
                NombreTable = "com_producto";
                Query = "CREATE TABLE com_producto( \n" +
                        "   idproducto int identity(1,1) primary key not null,\n" +
                        "   ccodrucemisor char(15),\n" +
                        "   ccod_empresa char(3),\n" +
                        "   ccodmodulo character(6),\n" +
                        "	ccodfamg char(20) NULL,\n" +
                        "	cdesfamg char(50) NULL,\n" +
                        "	ccodfamf char(20) NULL,\n" +
                        "	cdesfamf char(50) NULL,\n" +
                        "	ccodprod char(20) NULL,\n" +
                        "	cdesprod char(150) NULL,\n" +
                        "	cdesprodGen varchar(500) NULL,\n" +
                        "	ccodtes char(2) NULL,\n" +
                        "	cdesmar char(80) NULL,\n" +
                        "	ccodmed char(15) NULL,\n" +
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
                respuesta = obj.Crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region sp_documento_envio_resultado

                NombreSP = "sp_documento_envio_resultado";
                Query = "CREATE PROCEDURE sp_documento_envio_resultado  \n" +
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
                respuesta = obj.Crear_procedimiento(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region sp_producto_envio_resultado

                NombreSP = "sp_producto_envio_resultado";
                Query = "CREATE PROCEDURE dbo.sp_producto_envio_resultado   \n" +
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
                respuesta = obj.Crear_procedimiento(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                //Area para Agregar Nuevas funciones comercial////
                #region fn_documento_envio

                NombreSP = "fn_documento_envio";
                Query = "CREATE FUNCTION fn_documento_envio(   \n" +
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
                                 "		  case when ltrim(rtrim(isnull(d.estado, ''))) = '' then '' else ltrim(rtrim(d.estado))  end as estado,  \n" +
                                 "		  case when ltrim(rtrim(isnull(d.ccodcos3,''))) = '' then '' else ltrim(rtrim(d.ccodcos3))  end as ccodcos3, \n" +
                                 "		  case when d.es_con_migracion = 3 then ltrim(rtrim(c.Ent_anula))  else '' end as ccodrucanula, \n" +
                                 "		  case when d.es_con_migracion = 3 then 1 else 0 end as nflgexisteanular, \n" +
                                 "        ltrim(rtrim(isnull(d.ccond, ''))) as ccond, \n" +
                                 "        ltrim(rtrim(isnull(d.ccuecan, ''))) as ccuecan \n" +
                                 "        from com_documento d \n" +
                                 "        inner \n" +
                                 "        join configuracion2 c \n" +
                                 "        on d.ccod_empresa = c.ccod_empresa and d.ccodrucemisor = crucemp \n" +
                                 "        and d.ccodmodulo = c.Tipo \n" +
                                 "        and d.ccodmov = c.ccodmov \n" +
                                 "        and( \n" +
                                 "            (@tipo = 'VENTA' and right((replicate('0', 20) + ltrim(rtrim(d.cserie))), 20) = right((replicate('0', 20) + ltrim(rtrim(c.cserie))), 20)) \n" +
                                 "            or(@tipo <> 'VENTA') \n" +
                                 "        )	where d.es_con_migracion in (0, 3) \n" +
                                 "        and d.ccodrucemisor = @prucEmisor \n" +
                                 "        and d.ccod_empresa = @empresa \n" +
                                 "        and d.ccodmodulo = @tipo);";
                respuesta = obj.Crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_detalledocumento_envio
                NombreSP = "fn_detalledocumento_envio";
                Query = "CREATE FUNCTION fn_detalledocumento_envio(  \n" +
                            " @iddocumentos dbo.tp_id READONLY  \n" +
                            ") RETURNS TABLE \n" +
                            " AS \n" +
                            " RETURN( \n" +
                            " select * \n" +
                            " from com_detalledocumento d \n" +
                            " inner join @iddocumentos ids on d.iddocumento = ids.id);";
                respuesta = obj.Crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_productos_envio
                NombreSP = "fn_productos_envio";
                Query = "CREATE FUNCTION fn_productos_envio(  \n" +
                                "  @prucEmisor char(15),      \n" +
                                " @empresa char(3)  \n" +
                                ") RETURNS TABLE  \n" +
                                " AS  \n" +
                                " RETURN(  \n" +
                                "  \n" +
                                " select top 1000  \n" +
                                "    p.idproducto,  \n" +
                                "    p.ccod_empresa, \n" +
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
                respuesta = obj.Crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region campos_para_configuracion2
                NombreTable = "configuracion2";
                Nombrecampo = "ffecha_inicioproceso";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  date null ";
                respuesta = obj.Crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
                #endregion
            }
        }
        private void Proceso_postgresl()
        {
            Clase.Estructura_postgres obj = new Clase.Estructura_postgres();
            
            #region ruc_emisor
            NombreTable = "cg_empemisor";
            Query = "CREATE TABLE cg_empemisor(" +
            " ccodrucemisor char(15) NOT NULL, " +
            " cdesrucemisor char(200) NULL, " +
            " flgActivo bit NULL," +
            " PRIMARY KEY(ccodrucemisor) ); ";
            respuesta = obj.crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region empresa
            NombreTable = "cg_empresa";
            Query = "CREATE TABLE cg_empresa(" +
            "  ccodrucemisor char(15) NULL," +
            "  ccod_empresa char(3) NULL, " +
            "  nomempresa char(80) NULL, " +
            "  PRIMARY KEY(ccodrucemisor, ccod_empresa) );";
            respuesta = obj.crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region usuarios
            NombreTable = "cg_usuario";
            Query = "CREATE TABLE cg_usuario(  " +
                    " ccodusu char(10) NOT NULL," +
                    " cdesusu char(60) NOT NULL," +
                    " password char(250) NOT NULL," +
                    " fec_ultacceso date NULL," +
                    " PRIMARY KEY(ccodusu));";
            respuesta = obj.crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region modulos
            NombreTable = "cg_modulos";
            Query = "CREATE TABLE cg_modulos( " +
                    " ccodmod char(10) NULL," +
                    " cdesmod char(100) NULL) ;";
            respuesta = obj.crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region acceso_usuario

            #region cg_moduloconfigura
            NombreTable = "cg_moduloconfigura";
            Query = "CREATE TABLE IF NOT EXISTS public.cg_moduloconfigura  \n" +
                    "(  \n" +
                    "id bigint default 0 ),\n" +
                    "cmodulo character(20)  \n" +
                    ");";
            respuesta = obj.crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion


            NombreTable = " CREATE TABLE cg_usuario_acceso( "+
            " ccodusu char(10) NOT NULL,"+
            " ccodmod char(10) NOT NULL,"+
            " flgacceso numeric(1, 0) NULL);";
            respuesta = obj.crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
           /* #region version
            
            NombreTable = "cg_version";
            Query = txtversion.Text;

            respuesta = obj.crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion*/

            #region log
            NombreTable = "cg_log";
            Query = "create sequence sec_id_log minvalue 1 maxvalue 9999999999 increment by 1 ;" +
            " CREATE TABLE cg_log( " +
            " id int DEFAULT nextval('sec_id_log'::regclass)," +
            " tipo_error text NULL," +
            " error_mensaje text NULL," +
            " fechahora date NULL," +
            " PRIMARY KEY(id));"; 
            respuesta = obj.crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_para_configuracion2
            NombreTable = "configuracion2";
            Nombrecampo = "ffecha_inicioproceso";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  date null ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion
            
            #region campos_cg_empemisor_modulo
            NombreTable = "cg_empemisor";
            Nombrecampo = "ntipomodulo";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  Numeric(1) default 1 ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion

            #region campos_cg_empresa_modulo
            NombreTable = "cg_empresa";
            Nombrecampo = "ntipomodulo";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  Numeric(1) default 1 ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion



            //* comercial *//
            #region campos_cg_empemisor_comercial_venta
            NombreTable = "cg_empemisor";
            Nombrecampo = "NCOMVENTAFLG";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  Numeric(1) default 0 ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_cg_empemisor_comercial_compra
            NombreTable = "cg_empemisor";
            Nombrecampo = "NCOMCOMPRAFLG";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  Numeric(1) default 0 ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_cg_empemisor_comercial_pago
            NombreTable = "cg_empemisor";
            Nombrecampo = "npagoflg";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  Numeric(1) default 0 ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_cg_empemisor_comercial_cobranza
            NombreTable = "cg_empemisor";
            Nombrecampo = "ncobranzacomercial";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  Numeric(1) default 0 ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_para_configuracion2
            NombreTable = "configuracion2";
            Nombrecampo = "ccodoripago";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  char(3) null ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_para_configuracion2
            NombreTable = "configuracion2";
            Nombrecampo = "clibropago";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  char(2) null ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_para_configuracion2
            NombreTable = "configuracion2";
            Nombrecampo = "ccodflupago";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  char(4) null ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_para_configuracion2
            NombreTable = "configuracion2";
            Nombrecampo = "ctipo";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  char(2) null ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_para_conexiones
            NombreTable = "conexiones";
            Nombrecampo = "nModulo";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + " int Integer;";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_para_configuracion
            NombreTable = "configuracion";
            Nombrecampo = "csub_anticipo";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  character(3) null ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion
            #region campos_para_configuracion
            NombreTable = "configuracion";
            Nombrecampo = "nactiva_anticipo";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  integer default 0 ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion

            #region campos_para_configuracion
            NombreTable = "configuracion";
            Nombrecampo = "clreg1vta_anticipo";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  character(3) null ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion


            NombreTable = "cg_empemisor";
            Nombrecampo = "ncobranzacomercial";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + "   Numeric(1,0) default 0;";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #region fn_actualizar_version

            #region campos_para_configuracion
            NombreTable = "configuracion";
            Nombrecampo = "ffecha_inicioproceso";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  date null ";
            respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
            this.Barraprogreso(respuesta);
            #endregion

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
            this.Barraprogreso(respuesta);
            #endregion

            #region cg_moduloconfigura
            NombreTable = "cg_moduloconfigura";
            Query = "CREATE TABLE IF NOT EXISTS cg_moduloconfigura  \n" +
                    "(id bigint default 0 ,\n" +
                    " cmodulo character(20) );";
            respuesta = obj.crear_tablas(NombreTable, Query);
            this.Barraprogreso(respuesta);
            #endregion

            #region cg_moduloconfiguradelete
            NombreSP = "cg_moduloconfigura";
            Query = "delete from  cg_moduloconfigura;";
            respuesta = obj.ejecutar_comando("", NombreSP, Query);
            this.Barraprogreso(respuesta);
            #endregion

            #region cg_moduloconfigura11
            NombreSP = "cg_moduloconfigura";
            Query = "INSERT INTO cg_moduloconfigura(id,cmodulo) values(1,'Modulo Contable');";
            respuesta = obj.ejecutar_comando("", NombreSP, Query);
            this.Barraprogreso(respuesta);
            #endregion

            #region cg_moduloconfigura22
            NombreSP = "cg_moduloconfigura";
            Query = "INSERT INTO cg_moduloconfigura(id,cmodulo) values(2,'Modulo Comercial');";
            respuesta = obj.ejecutar_comando("", NombreSP, Query);
            this.Barraprogreso(respuesta);
            #endregion


            if (Properties.Settings.Default.TipModulo == "1") //// Modulo Financiero
            {
                #region configuracion

                NombreTable = "configuracion";
                Query = "CREATE TABLE configuracion( " +
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
                " cfefec_vta char(4) NULL, " +
                " ctares_vta numeric(1, 0) NULL, " +
                " ctaimp_vta numeric(1, 0) NULL," +
                " Ctaact_vta numeric(1, 0) NULL," +
                " asientos_vta numeric(1, 0) NULL," +
                " csub1_com char(3) NULL," +
                " clreg1_com char(20) NULL," +
                " csub2_com char(3) NULL," +
                " clreg2_com char(20) NULL," +
                " cconts_com char(20) NULL," +
                " ccontd_com char(20) NULL," +
                " cfefec_com char(4) NULL," +
                " ctares_com numeric(1, 0) NULL," +
                " ctaimp_com numeric(1, 0) NULL," +
                " Ctapas_com numeric(1, 0) NULL," +
                " asientos_com numeric(1, 0) NULL," +
                " cTipo char(2) NULL," +
                " cEnt_anula char(15) NULL);";
                string respuesta = "";
                respuesta = obj.crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fin_ventas

                NombreTable = "fin_ventas";
                Query = "create sequence sec_id_ventas minvalue 1 maxvalue 9999999999 increment by 1 " +
                 " CREATE TABLE fin_ventas( " +
                 " idventas      int   DEFAULT nextval('sec_id_ventas'::regclass), " +
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
                 " cmreg    nchar(1) NULL, " +
                 " ndolar   numeric(15, 2) NULL, " +
                 " ffechaven2  date  NULL, " +
                 " ccond       char(3) NULL, " +
                 " ccodcos     nchar(15) NULL, " +
                 " ccodcos2    nchar(15) NULL, " +
                 " cctabase    nchar(20) NULL, " +
                 " cctaicbper  nchar(20) NULL, " +
                 " cctaotrib   nchar(20) NULL, " +
                 " cctatot     nchar(20) NULL, " +
                 " nresp   numeric(1, 0) NULL, " +
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

                
                respuesta = obj.crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);

                #endregion
                #region fin_compras

                NombreTable = "fin_compras";
                Query = " create sequence sec_id_compras minvalue 1 maxvalue 9999999999 increment by 1 ;" +
                        " CREATE TABLE fin_compras(" +
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
                this.Barraprogreso(respuesta);

                #endregion
                #region fin_cobranzapago

                NombreTable = "fin_cobranzapago";
                Query = "drop sequence if exists sec_idcobranzas; " +
                " create sequence sec_idcobranzas minvalue 1 maxvalue 9999999999 increment by 1; " +
                " create table fin_cobranzapago(" +
                " idcobranzas numeric(20, 0), " +
                " ccodrucemisor character(15) NOT NULL DEFAULT ''::bpchar, " +
                " ccod_empresa character(3), " +
                " cper character(4), " +
                " cmes character(2), " +
                " ntipocobpag numeric(1, 0), " +
                " ffechacan date, " +
                " cdoccan character(2) NOT NULL DEFAULT ''::bpchar, " +
                " csercan character(20) NOT NULL DEFAULT ''::bpchar, " +
                " cnumcan character(20) NOT NULL DEFAULT ''::bpchar, " +
                " ccuecan character(20) NOT NULL DEFAULT ''::bpchar, " +
                " cmoncan character(1) NOT NULL DEFAULT ''::bpchar, " +
                " nimporcan numeric(15, 2) NOT NULL DEFAULT 0, " +
                " ntipcam numeric(10, 6) NOT NULL DEFAULT 0, " +
                " ccodpago character(3) NOT NULL DEFAULT ''::bpchar, " +
                " ccoddoc character(2) NOT NULL DEFAULT ''::bpchar, " +
                " cserie character(20) NOT NULL DEFAULT ''::bpchar, " +
                " cnumero character(20) NOT NULL DEFAULT ''::bpchar, " +
                " ffechadoc date, " +
                " ffechaven date, " +
                " ccodenti character(11) NOT NULL DEFAULT ''::bpchar, " +
                " ccodruc character(15) NOT NULL DEFAULT ''::bpchar, " +
                " crazsoc character(150) NOT NULL DEFAULT ''::bpchar, " +
                " nimportes numeric(15, 2) NOT NULL DEFAULT 0, " +
                " nimported numeric(15, 2) NOT NULL DEFAULT 0, " +
                " ccodcue character(20) NOT NULL DEFAULT ''::bpchar, " +
                " cglosa text, " +
                " ccodcos character(15) NOT NULL DEFAULT ''::bpchar, " +
                " ccodcos2 character(15) NOT NULL DEFAULT ''::bpchar, " +
                " nporre numeric(5, 2) NOT NULL DEFAULT 0, " +
                " nimpperc numeric(15, 2) NOT NULL DEFAULT 0, " +
                " nperdenre numeric(1, 0) NOT NULL DEFAULT 0, " +
                " cserre character(6) NOT NULL DEFAULT ''::bpchar, " +
                " cnumre character(13) NOT NULL DEFAULT ''::bpchar, " +
                " ffecre date, " +
                " obserror text, " +
                " resultado_migracion numeric(1, 0), " +
                " created_at date, " +
                " updated_at date, " +
                " estado character(255) NOT NULL DEFAULT ''::bpchar, " +
                " en_ambiente_de character(255) NOT NULL DEFAULT ''::bpchar, " +
                " es_con_migracion numeric(1, 0) NULL, " +
                " ccodcos3 character(15) NOT NULL DEFAULT ''::bpchar, " +
                " es_anticipo_automatico numeric(1, 0) NULL DEFAULT 0, " +
                " primary key(idcobranzas)); ";
                respuesta = obj.crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);

                #endregion
                #region fin_cobranzafm

                NombreTable = "fin_cobranzafm";
                Query = " create table fin_cobranzafm(" +
                " idcobranzasfm numeric(20, 0), " +
                " ccodrucemisor character(15) NOT NULL DEFAULT ''::bpchar, " +
                " ccod_empresa character(3), " +
                " cper character(4), " +
                " cmes character(2), " +
                " ntipocobpag numeric(1, 0), " +
                " ffechacan date, " +
                " cdoccan character(2) NOT NULL DEFAULT ''::bpchar, " +
                " csercan character(20) NOT NULL DEFAULT ''::bpchar, " +
                " cnumcan character(20) NOT NULL DEFAULT ''::bpchar, " +
                " ccuecan character(20) NOT NULL DEFAULT ''::bpchar, " +
                " cmoncan character(1) NOT NULL DEFAULT ''::bpchar, " +
                " nimporcan numeric(15, 2) NOT NULL DEFAULT 0, " +
                " ntipcam numeric(10, 6) NOT NULL DEFAULT 0, " +
                " ccodpago character(3) NOT NULL DEFAULT ''::bpchar, " +
                " ccoddoc character(2) NOT NULL DEFAULT ''::bpchar, " +
                " cserie character(20) NOT NULL DEFAULT ''::bpchar, " +
                " cnumero character(20) NOT NULL DEFAULT ''::bpchar, " +
                " ffechadoc date, " +
                " ffechaven date, " +
                " ccodenti character(11) NOT NULL DEFAULT ''::bpchar, " +
                " ccodruc character(15) NOT NULL DEFAULT ''::bpchar, " +
                " crazsoc character(150) NOT NULL DEFAULT ''::bpchar, " +
                " nimportes numeric(15, 2) NOT NULL DEFAULT 0, " +
                " nimported numeric(15, 2) NOT NULL DEFAULT 0, " +
                " ccodcue character(20) NOT NULL DEFAULT ''::bpchar, " +
                " cglosa text, " +
                " ccodcos character(15) NOT NULL DEFAULT ''::bpchar, " +
                " ccodcos2 character(15) NOT NULL DEFAULT ''::bpchar, " +
                " nporre numeric(5, 2) NOT NULL DEFAULT 0, " +
                " nimpperc numeric(15, 2) NOT NULL DEFAULT 0, " +
                " nperdenre numeric(1, 0) NOT NULL DEFAULT 0, " +
                " cserre character(6) NOT NULL DEFAULT ''::bpchar, " +
                " cnumre character(13) NOT NULL DEFAULT ''::bpchar, " +
                " ffecre date, " +
                " obserror text, " +
                " resultado_migracion numeric(1, 0), " +
                " created_at date, " +
                " updated_at date, " +
                " estado character(255) NOT NULL DEFAULT ''::bpchar, " +
                " en_ambiente_de character(255) NOT NULL DEFAULT ''::bpchar, " +
                " es_con_migracion numeric(1, 0) NULL, " +
                " ccodcos3 character(15) NOT NULL DEFAULT ''::bpchar, " +
                " comprobante_item_id character(40) NOT NULL DEFAULT ''::bpchar, "+
                " es_anticipo_automatico numeric(1, 0) NULL DEFAULT 0 " +
                " )); ";
                respuesta = obj.crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);

                #endregion
                //Area para Agregar Nuevos Campos a la tabla////
                #region campos_para_ventas

                NombreTable = "fin_ventas";
                Nombrecampo = "cubigeo";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " nchar(6) not null default '';";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region campos_para_compras

                NombreTable = "fin_compras";
                Nombrecampo = "cubigeo";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " nchar(6) not null default '';";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region campos_para_combranza

                NombreTable = "fin_cobranzapago";
                Nombrecampo = "es_anticipo_automatico";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " numeric(1,0) not null default 0;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region campos_para_rucemiso

                NombreTable = "cg_empemisor";
                Nombrecampo = "nventaflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + "  add column  " + Nombrecampo.Trim().ToLower() + "  int Integer;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncomFondom";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                respuesta = obj.crear_Campos_nuevos_en_tablas (NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);


                Nombrecampo = "ncompraflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + "  int Integer;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                txtMensaje.Refresh();
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncobranzaflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + "  int Integer;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "npagoflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + " int Integer;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                NombreTable = "cg_empemisor";
                Nombrecampo = "ncobranzacomercial";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + "   Numeric(1,0) default 0;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);


                #endregion
                #region configuracion2

                NombreTable = "configuracion2";
                Query = "drop sequence if exists sec_id;" +
                "create sequence sec_id minvalue 1 maxvalue 99999999999 increment by 1; " +
                "CREATE TABLE configuracion2( " +
                 "   id numeric(20, 0), " +
                 "   ccod_empresa char(3) NULL, " +
                 "   cper char(4) NULL, " +
                 "   crazemp char(100) NULL, " +
                 "   crucemp char(15) NULL, " +
                 "   Entidad char(3) NULL, " +
                 "   Tipo char(5) NULL, " +
                 "   codtipdocu char(4) NULL, " +
                 "   cserie char(20) NULL, " +
                 "   ccodmov char(10) NULL, " +
                 "   ccodpag char(5) NULL, " +
                 "   ccodvend char(10) NULL, " +
                 "   ccodalma char(10) NULL, " +
                 "   Ent_anula char(15) NULL, " +
                 "   ctipo char(2) NULL, " +
                 "   Prodanula char(15) NULL); ";
                respuesta = obj.crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_cobranzaspago_envio

                NombreSP = "fn_cobranzaspago_envio";
                Query = "-- FUNCTION: public.fn_cobranzaspago_envio(character, character, integer)   \n" +
                        "-- DROP FUNCTION IF EXISTS public.fn_cobranzaspago_envio(character, character, integer);  \n" +
                        " CREATE OR REPLACE FUNCTION public.fn_cobranzaspago_envio(   \n" +
                        " OUT resultado text,  \n" +
                        " p_ruc_emisor character,  \n" +
                        " p_empresa character,  \n" +
                        " p_tipo integer)  \n" +
                        " RETURNS text   \n" +
                        " --- es_anticipo_automatico campo nuevo para colegio contadores 24/02/2025 \n" +
                        " --- modificacion formulario PDI-277 \n" +
                        "  \n" +
                        " AS $BODY$   \n" +
                        "   \n" +
                        " BEGIN   \n" +
                        " select json_agg(to_json(t))::text  \n" +
                        " from(  \n" +
                        " select  \n" +
                        " idcobranzas as idcobranzapago, fin_cobranzapago.ccod_empresa, fin_cobranzapago.cper, cmes,  \n" +
                        " case when es_anticipo_automatico=1 then trim(configuracion.CSUB_ANTICIPO) else trim(configuracion.csub1_vta) end AS ccodori,  \n" +
                        " case when es_anticipo_automatico = 1 then trim(configuracion.clreg1vta_anticipo) else trim(configuracion.clreg1_vta) end AS ccodsu,\n" +
                        " trim(configuracion.cfefec_vta) AS ccodflu,  \n" +
                        " fin_cobranzapago.ntipocobpag as ntipocobpag,  \n" +
                        " to_char(ffechacan, 'YYYY-MM-DD') AS ffechacan,  \n" +
                        " trim(coalesce(cdoccan, '')) as cdoccan,        \n" +
                        " case when trim(coalesce(csercan,'')) = '' then ' ' else lpad(trim(csercan),20,'0')  end as csercan,     \n" +
                        " case when trim(coalesce(cnumcan,'')) = '' then ' ' else lpad(trim(cnumcan),20,'0')  end as cnumcan,     \n" +
                        " coalesce(ccuecan, '') as ccuecan,          \n" +
                        " coalesce(cmoncan, '') as cmoncan,            \n" +
                        " coalesce(nimporcan, 0.00) as nimporcan,       \n" +
                        " coalesce(ntipcam, 0.00) as ntipcam ,      \n" +
                        " coalesce(ccodpago, '') as ccodpago,       \n" +
                        " coalesce(ccoddoc, '') as ccoddoc,      \n" +
                        " case when trim(coalesce(cserie,'')) = '' then ' ' else lpad(trim(cserie),20,'0')  end as cserie,     \n" +
                        " case when trim(coalesce(cnumero,'')) = '' then ' ' else lpad(trim(cnumero),20,'0')  end as cnumero,     \n" +
                        " to_char(ffechadoc, 'YYYY-MM-DD')as ffechadoc,        \n" +
                        " to_char(ffechaven, 'YYYY-MM-DD')as ffechaven,        \n" +
                        " coalesce(ccodenti, '01') as ccodenti,      \n" +
                        " trim(coalesce(ccodruc, '')) as ccodruc,      \n" +
                        " trim(coalesce(crazsoc, '')) as crazsoc,      \n" +
                        " coalesce(nimportes, 0.00) as nimportes,      \n" +
                        " coalesce(nimported, 0.00) as nimported ,       \n" +
                        " trim(coalesce(ccodcue, '')) as ccodcue,      \n" +
                        " trim(coalesce(cglosa, '')) as cglosa,       \n" +
                        " trim(coalesce(ccodcos, '')) as ccodcos,       \n" +
                        " trim(coalesce(ccodcos2, '')) as ccodcos2,       \n" +
                        " coalesce(nporre, 0.00) as nporre,       \n" +
                        " coalesce(nimpperc, 0.00) as nimpperc,       \n" +
                        " coalesce(nperdenre, 0.00) as nperdenre,    \n" +
                        " trim(coalesce(cserre, '')) as cserre,       \n" +
                        " trim(coalesce(cnumre, '')) as cnumre,       \n" +
                        " to_char(ffecre, 'YYYY-MM-DD')as ffecre,     \n" +
                        " case when coalesce(estado,'') = '' then '' else coalesce(trim(estado))  end as estado ,          \n" +
                        " coalesce(en_ambiente_de, '') as en_ambiente_de,          \n" +
                        " coalesce(es_con_migracion, 0) as es_con_migracion,         \n" +
                        " coalesce(ccodcos3)   as ccodcos3,        \n" +
                        " case when es_con_migracion = 3  then configuracion.cEnt_anula  else '' end as ccodrucanula,  \n" +
                        " coalesce(es_anticipo_automatico,0) as es_anticipo_automatico \n" +
                        " from fin_cobranzapago  \n" +
                        " join configuracion ON fin_cobranzapago.CCOD_EMPRESA = configuracion.CCOD_EMPRESA and fin_cobranzapago.CPER = configuracion.CPER  \n" +
                        " join CG_EMPRESA emp on fin_cobranzapago.ccodrucemisor = emp.ccodrucemisor and fin_cobranzapago.ccod_empresa = emp.CCOD_EMPRESA  \n" +
                        " join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1::bit  \n" +
                        " where fin_cobranzapago.ccodrucemisor = p_ruc_emisor::character(15)  \n" +
                        " and fin_cobranzapago.ccod_empresa = p_empresa::character(3)  and fin_cobranzapago.ntipocobpag = p_tipo::Numeric(1)  \n" +
                        " and es_con_migracion in (0, 3)  \n" +
                        " and configuracion.ctipo = '03'::  character(2)  )   \n" +
                        " as t  \n" +
                        " into resultado;      \n" +
                        " end;   \n" +
                        " $BODY$  \n" +
                        " LANGUAGE 'plpgsql' VOLATILE  \n" +
                        " COST 100;  ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_cobranzaspagoFM_envio

                NombreSP = "fn_cobranzaspagoFM_envio";
                Query = "-- FUNCTION: public.fn_cobranzaspagoFM_envio(character, character, integer)   \n" +
                        "-- DROP FUNCTION IF EXISTS public.fn_cobranzaspagoFM_envio(character, character, integer);  \n" +
                        " CREATE OR REPLACE FUNCTION public.fn_cobranzaspagoFM_envio(   \n" +
                        " OUT resultado text,  \n" +
                        " p_ruc_emisor character,  \n" +
                        " p_empresa character,  \n" +
                        " p_tipo integer)  \n" +
                        " RETURNS text   \n" +
                        "  \n" +
                        " AS $BODY$   \n" +
                        "   \n" +
                        " BEGIN   \n" +
                        " select json_agg(to_json(t))::text  \n" +
                        " from(  \n" +
                        " select  \n" +
                        " idcobranzasfm as idcobranzapago, fin_cobranzafm.ccod_empresa, fin_cobranzafm.cper, cmes,  \n" +
                        " trim(configuracion.csub1_com)  AS ccodori,  \n" +
                        " trim(configuracion.clreg1_com)  AS ccodsu,\n" +
                        " trim(configuracion.cfefec_com) AS ccodflu,  \n" +
                        " fin_cobranzafm.ntipocobpag as ntipocobpag,  \n" +
                        " to_char(ffechacan, 'YYYY-MM-DD') AS ffechacan,  \n" +
                        " trim(coalesce(cdoccan, '')) as cdoccan,        \n" +
                        " case when trim(coalesce(csercan,'')) = '' then ' ' else lpad(trim(csercan),20,'0')  end as csercan,     \n" +
                        " case when trim(coalesce(cnumcan,'')) = '' then ' ' else lpad(trim(cnumcan),20,'0')  end as cnumcan,     \n" +
                        " coalesce(ccuecan, '') as ccuecan,          \n" +
                        " coalesce(cmoncan, '') as cmoncan,            \n" +
                        " coalesce(nimporcan, 0.00) as nimporcan,       \n" +
                        " coalesce(ntipcam, 0.00) as ntipcam ,      \n" +
                        " coalesce(ccodpago, '') as ccodpago,       \n" +
                        " coalesce(ccoddoc, '') as ccoddoc,      \n" +
                        " case when trim(coalesce(cserie,'')) = '' then ' ' else lpad(trim(cserie),20,'0')  end as cserie,     \n" +
                        " case when trim(coalesce(cnumero,'')) = '' then ' ' else lpad(trim(cnumero),20,'0')  end as cnumero,     \n" +
                        " to_char(ffechadoc, 'YYYY-MM-DD')as ffechadoc,        \n" +
                        " to_char(ffechaven, 'YYYY-MM-DD')as ffechaven,        \n" +
                        " coalesce(ccodenti, '01') as ccodenti,      \n" +
                        " trim(coalesce(ccodruc, '')) as ccodruc,      \n" +
                        " trim(coalesce(crazsoc, '')) as crazsoc,      \n" +
                        " coalesce(nimportes, 0.00) as nimportes,      \n" +
                        " coalesce(nimported, 0.00) as nimported ,       \n" +
                        " trim(coalesce(ccodcue, '')) as ccodcue,      \n" +
                        " trim(coalesce(cglosa, '')) as cglosa,       \n" +
                        " trim(coalesce(ccodcos, '')) as ccodcos,       \n" +
                        " trim(coalesce(ccodcos2, '')) as ccodcos2,       \n" +
                        " coalesce(nporre, 0.00) as nporre,       \n" +
                        " coalesce(nimpperc, 0.00) as nimpperc,       \n" +
                        " coalesce(nperdenre, 0.00) as nperdenre,    \n" +
                        " trim(coalesce(cserre, '')) as cserre,       \n" +
                        " trim(coalesce(cnumre, '')) as cnumre,       \n" +
                        " to_char(ffecre, 'YYYY-MM-DD')as ffecre,     \n" +
                        " case when coalesce(estado,'') = '' then '' else coalesce(trim(estado))  end as estado ,          \n" +
                        " coalesce(en_ambiente_de, '') as en_ambiente_de,          \n" +
                        " coalesce(es_con_migracion, 0) as es_con_migracion,         \n" +
                        " coalesce(ccodcos3)   as ccodcos3,        \n" +
                        " case when es_con_migracion = 3  then configuracion.cEnt_anula  else '' end as ccodrucanula,  \n" +
                        " coalesce(es_anticipo_automatico,0) as es_anticipo_automatico \n" +
                        " from fin_cobranzafm  \n" +
                        " join configuracion ON fin_cobranzafm.CCOD_EMPRESA = configuracion.CCOD_EMPRESA and fin_cobranzafm.CPER = configuracion.CPER  \n" +
                        " join CG_EMPRESA emp on fin_cobranzafm.ccodrucemisor = emp.ccodrucemisor and fin_cobranzafm.ccod_empresa = emp.CCOD_EMPRESA  \n" +
                        " join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1::bit  \n" +
                        " where fin_cobranzafm.ccodrucemisor = p_ruc_emisor::character(15)  \n" +
                        " and fin_cobranzafm.ccod_empresa = p_empresa::character(3)  and fin_cobranzafm.ntipocobpag = p_tipo::Numeric(1)  \n" +
                        " and es_con_migracion in (0, 3)  \n" +
                        " and configuracion.ctipo = '05'::  character(2)  order by fin_cobranzafm.ccod_empresa  )   \n" +
                        " as t  \n" +
                        " into resultado;      \n" +
                        " end;   \n" +
                        " $BODY$  \n" +
                        " LANGUAGE 'plpgsql' VOLATILE  \n" +
                        " COST 100;  ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_ventas_envio_resultado

                NombreSP = "fn_ventas_envio_resultado";
                Query = "CREATE OR REPLACE FUNCTION public.fn_ventas_envio_resultado(  \n" +
                    "   \n" +
                    "p_datos text)  \n" +
                    "RETURNS void   \n" +
                    "AS $BODY$   \n" +
                    "  \n" +
                    "DECLARE  \n" +
                    "v_data json;  \n" +
                    "        BEGIN  \n" +
                    "   \n" +
                    "  v_data:= p_datos::json;    \n" +
                    "  UPDATE fin_ventas t  \n" +
                    "  SET es_con_migracion =  coalesce(r.resultado_migracion,0),      \n" +
                    "  obserror = r.obserror    \n" +
                    " from json_to_recordset(v_data) as r (idventas integer, obserror text, es_con_migracion integer, resultado_migracion integer) \n" +
                    " where t.idventas = r.idventas and t.es_con_migracion = r.es_con_migracion;    \n" +
                    "    \n" +
                    " END;    \n" +
                     "$BODY$  \n" +
                     "LANGUAGE 'plpgsql' VOLATILE \n" +
                     " COST 100; ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_cobranzaspago_envio_resultado
                NombreSP = "fn_cobranzaspago_envio_resultado";
                Query = "CREATE OR REPLACE FUNCTION public.fn_cobranzaspago_envio_resultado(   \n" +
                    "   \n" +
                    "p_datos text)  \n" +
                    "RETURNS void   \n" +
                    "AS $BODY$   \n" +
                    "  \n" +
                    "DECLARE  \n" +
                    "v_data json;  \n" +
                    "        BEGIN  \n" +
                    "   \n" +
                    "  v_data:= p_datos::json;    \n" +
                    "  UPDATE fin_cobranzapago t  \n" +
                    "  SET es_con_migracion =  coalesce(r.resultado_migracion,0),      \n" +
                    "  obserror = r.obserror    \n" +
                    "  \n" +
                    " from json_to_recordset(v_data) as r (idcobranzapago integer, obserror text, es_con_migracion integer, resultado_migracion integer)  \n" +
                    " where t.idcobranzas = r.idcobranzapago and t.es_con_migracion = r.es_con_migracion;    \n" +
                    "    \n" +
                    " END;    \n" +
                     "$BODY$  \n" +
                     "LANGUAGE 'plpgsql' VOLATILE \n" +
                     " COST 100; ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_cobranzasFM_envio_resultado
                NombreSP = "fn_cobranzasFM_envio_resultado";
                Query = "CREATE OR REPLACE FUNCTION public.fn_cobranzasFM_envio_resultado(   \n" +
                    "   \n" +
                    "p_datos text)  \n" +
                    "RETURNS void   \n" +
                    "AS $BODY$   \n" +
                    "  \n" +
                    "DECLARE  \n" +
                    "v_data json;  \n" +
                    "        BEGIN  \n" +
                    "   \n" +
                    "  v_data:= p_datos::json;    \n" +
                    "  UPDATE fin_cobranzafm t  \n" +
                    "  SET es_con_migracion = coalesce(r.resultado_migracion,0),      \n" +
                    "  obserror = r.obserror    \n" +
                    "  \n" +
                    " from json_to_recordset(v_data) as r (idcobranzapago integer, obserror text, es_con_migracion integer, resultado_migracion integer)  \n" +
                    " where t.idcobranzasfm = r.idcobranzapago and t.es_con_migracion = r.es_con_migracion;    \n" +
                    "    \n" +
                    " END;    \n" +
                     "$BODY$  \n" +
                     "LANGUAGE 'plpgsql' VOLATILE \n" +
                     " COST 100; ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_compras_envio
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
                        " and to_char(fin_compras.ffechadoc, 'YYYY-MM-DD')>=to_char(configuracion.ffechainicioproceso, 'YYYY-MM-DD') \n" +
                        " ) t   \n" +
                        "    \n" +
                        " into resultado;  \n" +
                        "    \n" +
                        " END; \n" +
                        " $BODY$   \n" +
                        " LANGUAGE plpgsql VOLATILE  \n" +
                        " COST 100; ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_compras_envio_resultado
                NombreSP = "fn_compras_envio_resultado";
                Query = "CREATE OR REPLACE FUNCTION fn_compras_envio_resultado(p_datos text)  \n" +
                        " RETURNS void AS  \n" +
                        " $BODY$   \n" +
                        " DECLARE  \n" +
                        " v_data json;  \n" +
                        " BEGIN  \n" +
                        "           \n" +
                        " v_data:= p_datos::json; \n" +
                        " UPDATE fin_compras t \n" +
                        " SET es_con_migracion = coalesce(r.resultado_migracion,0), \n" +
                        " obserror = r.obserror \n" +
                        " from json_to_recordset(v_data) as r (idcompras integer, obserror text, es_con_migracion integer, resultado_migracion integer) \n" +
                        " where t.idcompras = r.idcompras and t.es_con_migracion = r.es_con_migracion; \n" +
                        "  \n" +
                        " END; \n" +
                        " $BODY$   \n" +
                        " LANGUAGE plpgsql VOLATILE  \n" +
                        " COST 100; ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_integracion_ventas_importar

                NombreSP = "fn_compras_envio_resultado";
                Query = "CREATE OR REPLACE FUNCTION public.fn_integracion_ventas_importar( \n" +
                " OUT resultado text,  \n" +
                " p_datos text, \n" +
                " p_cod_emp text) \n" +
                " RETURNS text \n" +
                "   \n" +
                "   \n" +
                "   AS $BODY$ \n" +
                "   \n" +
                " DECLARE \n" +
                " v_data json; \n" +
                " BEGIN \n" +
                "     \n" +
                "    v_data:= p_datos::json; \n" +
                " p_datos = null; \n" +
                "--nuevos \n" +
            " INSERT INTO fin_ventas( \n" +
            " idventas, ccodrucemisor,\n" +
            " ccod_empresa, cper, cmes, --generados\n" +
            " ffechadoc, ffechaven, ccoddoc, cserie, cnumero, ccodenti, cdesenti, ctipdoc,\n" +
            " ccodruc, crazsoc, nbase2, nbase1, nexo, nina, nisc, nigv1, nicbpers,\n" +
            " nbase3, ntots, ntc, freffec, crefdoc, crefser, crefnum, cmreg,\n" +
            " ndolar, ffechaven2, ccond, ccodcos, ccodcos2, cctabase, cctaicbper,\n" +
            " cctaotrib, cctatot, nresp, nporre, nimpres, cserre, cnumre, ffecre,\n" +
            " ccodpresu, nigv, cglosa, ccodpago, nperdenre, nbaseres, cctaperc,\n" +
            " created_at, updated_at, estado, en_ambiente_de, es_con_migracion,\n" +
            " ccodcos3\n" +
            " )\n" +
            " SELECT  \n" +
            " t.idventas, t.ccodrucemisor, p_cod_emp,\n" +
            " extract(year from to_date(t.ffechadoc, 'DD/MM/YYYY'))::text, lpad(extract(month from to_date(t.ffechadoc, 'DD/MM/YYYY'))::text, 2, '0'), \n" +
            " to_date(t.ffechadoc, 'DD/MM/YYYY'), case when coalesce(t.ffechaven, '')= '' then null else to_date(t.ffechaven, 'DD/MM/YYYY') end, \n" +
            " trim(t.ccoddoc) as ccoddoc, \n" +
            " trim(t.cserie) as cserie, \n" +
            " trim(t.cnumero) as cnumero,\n" +
            " trim(t.ccodenti) as ccodenti,\n" +
            " trim(t.cdesenti) as cdesenti,  \n" +
            " trim(t.ctipdoc) as ctipdoc,  \n" +
            " trim(t.ccodruc) as ccodruc, \n" +
            " trim(t.crazsoc) as razsoc, \n" +
            " case when trim(coalesce(t.nbase2, '')) = '' then null else t.nbase2::numeric end as nbase2, \n" +
            " case when trim(coalesce(t.nbase1, '')) = '' then null else t.nbase1::numeric end as nbase1, \n" +
            " case when trim(coalesce(t.nexo, '')) = '' then null else t.nexo::numeric end as nexo, \n" +
            " case when trim(coalesce(t.nina, '')) = '' then null else t.nina::numeric end as nina, \n" +
            " case when trim(coalesce(t.nisc, '')) = '' then null else t.nisc::numeric end as nisc, \n" +
            " case when trim(coalesce(t.nigv1, '')) = '' then null else t.nigv1::numeric end as nigv1, \n" +
            " case when trim(coalesce(t.nicbpers, '')) = '' then null else t.nicbpers::numeric end as nicbpers, \n" +
            " case when trim(coalesce(t.nbase3, '')) = '' then null else t.nbase3::numeric end as nbase3, \n" +
            " case when trim(coalesce(t.ntots, '')) = '' then null else t.ntots::numeric end as ntots, \n" +
            " case when trim(coalesce(t.ntc, '')) = '' then null else t.ntc::numeric end as ntc, \n" +
            " case when coalesce(t.freffec, '')= '' then null else to_date(t.freffec, 'DD/MM/YYYY') end,  \n" +
            " trim(t.crefdoc) as crefdoc,  \n" +
            " trim(t.crefser) as crefser, \n" +
            " trim(t.crefnum) as crefnum, \n" +
            " trim(t.cmreg) as cmreg, \n" +
            " case when trim(coalesce(t.ndolar, '')) = '' then null else t.ndolar::numeric end as ndolar, \n" +
            " case when coalesce(t.ffechaven2, '')= '' then null else to_date(t.ffechaven2, 'DD/MM/YYYY') end, \n" +
            " trim(t.ccond) as ccond, \n" +
            " trim(t.ccodcos) as codcos, \n" +
            " trim(t.ccodcos2) as codcos2, \n" +
            " trim(t.cctabase) as cctabase, \n" +
            " trim(t.cctaicbper) as cctaicbper, \n" +
            " trim(t.cctaotrib) as cctaotrib, \n" +
            " trim(t.cctatot) as cctatot, \n" +
            " case when trim(coalesce(t.nresp, '')) = '' then null else t.nresp::numeric end as nresp, \n" +
            " case when trim(coalesce(t.nporre, '')) = '' then null else t.nporre::numeric end as nporre,\n" +
            " case when trim(coalesce(t.nimpres, '')) = '' then null else t.nimpres::numeric end as nimpres,\n" +
            " trim(t.cserre), trim(t.cnumre),\n" +
            " case when coalesce(t.ffecre, '')= '' then null else to_date(t.ffecre, 'DD/MM/YYYY') end,\n" +
            " trim(t.ccodpresu), case when trim(coalesce(t.nigv, '')) = '' then null else t.nigv::numeric end as nigv,\n" +
            " trim(t.cglosa), trim(t.ccodpago),\n" +
            " case when trim(coalesce(t.nperdenre, '')) = '' then null else t.nperdenre::numeric end as nperdenre,\n" +
            " case when trim(coalesce(t.nbaseres, '')) = '' then null else t.nbaseres::numeric end as nbaseres,\n" +
            " trim(t.cctaperc),\n" +
            " t.created_at::date, t.updated_at::date,\n" +
            " trim(t.estado),\n" +
            " trim(t.en_ambiente_de),\n" +
            " case when t.estado = 'ACEPTADO' then 0 else 3 end, trim(t.ccodcos3)\n" +
            " FROM json_to_recordset(v_data)\n" +
            " as t(\n" +
            " idventas integer,\n" +
            " ccodrucemisor character varying(30),\n" +
            " ffechadoc character varying(30),\n" +
            " ffechaven character varying(30),\n" +
            " ccoddoc character varying(15),\n" +
            " cserie character varying(20),\n" +
            " cnumero character varying(20),\n" +
            " ccodenti character varying(15),\n" +
            " cdesenti character varying(100),\n" +
            " ctipdoc character varying(15),\n" +
            " ccodruc character varying(20),\n" +
            " crazsoc text,\n" +
            " nbase2 character varying(50),\n" +
            " nbase1 character varying(50),\n" +
            " nexo character varying(50),\n" +
            " nina character varying(50),\n" +
            " nisc character varying(50),\n" +
            " nigv1 character varying(50),\n" +
            " nicbpers character varying(50),\n" +
            " nbase3 character varying(50),\n" +
            " ntots character varying(50),\n" +
            " ntc character varying(50),\n" +
            " freffec character varying(30),\n" +
            " crefdoc character varying(50),\n" +
            " crefser character varying(20),\n" +
            " crefnum character varying(20),\n" +
            " cmreg character varying(10),\n" +
            " ndolar character varying(50),\n" +
            " ffechaven2 character varying(30),\n" +
            " ccond character varying(15),\n" +
            " ccodcos character varying(15),\n" +
            " ccodcos2 character varying(15),\n" +
            " cctabase text,\n" +
            " cctaicbper text,\n" +
            " cctaotrib text,\n" +
            " cctatot text,\n" +
            " nresp text,\n" +
            " nporre text,\n" +
            " nimpres text,\n" +
            " cserre text,\n" +
            " cnumre text,\n" +
            " ffecre text,\n" +
            " ccodpresu character varying(20),\n" +
            " nigv character varying(20),\n" +
            " cglosa text,\n" +
            " ccodpago character varying(20),\n" +
            " nperdenre character varying(20),\n" +
            " nbaseres character varying(20),\n" +
            " cctaperc character varying(20),\n" +
            " created_at timestamp, updated_at timestamp,\n" +
            " estado character varying(255),\n" +
            " en_ambiente_de character varying(255),\n" +
            " es_con_migracion boolean,\n" +
            " ccodcos3 character varying(15) \n" +
            " )\n" +
            " left join fin_ventas v on t.idventas = v.idventas \n" +
            " where v.idventas is null;  \n" +
            "     --update(solo campo migracion)  \n" +
            " update fin_ventas v  \n" +
            " set es_con_migracion =case when t.estado = 'ACEPTADO' then 0 else 3 end,  \n" +
            " estado = t.estado  \n" +
            " from json_to_recordset(v_data)  \n" +
            " as t (idventas integer, estado character varying(255), es_con_migracion boolean )      \n" +
            " where v.idventas = t.idventas;  \n" +
            "         --resultado de confirmacion.  \n" +
            " select json_agg(json_build_object('idventas', idventas, 'es_con_migracion', es_con_migracion))::text  \n" +
            " from json_to_recordset(v_data)  \n" +
            " as t (idventas integer, es_con_migracion boolean)  \n" +
            " into resultado;  \n" +
            " end;  \n" +
            " $BODY$  \n" +
            " LANGUAGE plpgsql VOLATILE  \n" +
            " COST 100;  ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_integracion_cobranza_importar
                NombreSP = "fn_integracion_cobranza_importar";
                Query = "CREATE OR REPLACE FUNCTION public.fn_integracion_cobranza_importar( \n" +
                        " \n" +
                        " OUT resultado text, \n" +
                        " p_datos text, \n" +
                        " p_cod_emp text) \n" +
                        " RETURNS text  \n" +
                        " AS $BODY$  \n" +
                        " \n" +
                        "-----Fecha: 16/04/2025 \n" + 
                        " DECLARE  \n" +
                        " v_data json;  \n" +
                        " BEGIN \n" +
                        " v_data:= p_datos::json; \n" +
                        " p_datos = null; \n" +
                        " \n" +
                        " INSERT INTO fin_cobranzapago( \n" +
                        " idcobranzas, ccodrucemisor, ccod_empresa, cper, cmes, ntipocobpag, ffechacan, \n" +
                        " cdoccan, csercan, cnumcan, ccuecan, cmoncan, \n" +
                        " nimporcan, ntipcam, ccodpago, \n" +
                        " ccoddoc, cserie, cnumero, ffechadoc, ffechaven, ccodenti, ccodruc, crazsoc, nimportes, \n" +
                        " nimported, ccodcue, cglosa, ccodcos, ccodcos2, nporre, nimpperc, nperdenre, \n" +
                        " cserre, cnumre, ffecre, created_at, updated_at, estado, en_ambiente_de, \n" +
                        " es_con_migracion, ccodcos3,es_anticipo_automatico) \n" +
                        " SELECT \n" +
                        " t.id, t.numero_documento_emisor, p_cod_emp, extract(year from to_date(t.ffechadoccobra, 'DD/MM/YYYY'))::text,    \n" +
                        " lpad(extract(month from to_date(t.ffechadoccobra, 'DD/MM/YYYY'))::text, 2, '0'), 1,   \n" +
                        " case when coalesce(t.ffechadoccobra, '')= '' then null else to_date(t.ffechadoccobra, 'DD/MM/YYYY') end, --1 \n" +
                        " trim(coalesce(t.cdoccan, '')) as cdoccan,    \n" +
                               " trim(coalesce(t.csercan, '')) as csercan,    \n" +
                        " trim(coalesce(t.cnumcan, '')) as cnumcan,    \n" +
                        " trim(coalesce(t.ccuecan, '')) as ccuecan,    \n" +
                        " trim(coalesce(t.cmoncan, '')) as cmoncan, --2 \n" +
                        " case when trim(coalesce(t.nimporcan, '')) = '' then 0 else t.nimporcan::numeric end as nimporcan,    \n" +
                        " case when trim(coalesce(t.ntipcam, '')) = '' then 0 else t.ntipcam::numeric end as ntipcam,    \n" +
                        " coalesce(trim(t.ccodpago), '') as ccodpago, --3 \n" +
                        " coalesce(trim(t.ccoddoc), '') as ccoddoc,    \n" +
                        " coalesce(trim(t.cserie), '') as cserie,    \n" +
                        " coalesce(trim(t.cnumero), '') as cnumero,    \n" +
                        " case when coalesce(t.ffechadoc, '')= '' then null else to_date(t.ffechadoc, 'DD/MM/YYYY') end as ffechadoc,    \n" +
                        " case when coalesce(t.ffechaven, '')= '' then null else to_date(t.ffechaven, 'DD/MM/YYYY') end as ffechaven,    \n" +
                        " '' as ccodenti , trim(coalesce(t.ccodruc, '')) as ccodruc, trim(coalesce(t.crazsoc, '')),  \n" +
                        " case when trim(coalesce(t.nimportes, '')) = '' then 0 else t.nimportes::numeric end as nimportes, --4 \n" +
                        " case when trim(coalesce(t.nimported, '')) = '' then 0 else t.nimported::numeric end as nimported,    \n" +
                        " trim(coalesce(t.ccodcue, '')) as ccodcue,    \n" +
                        " trim(coalesce(t.cglosa, '')) as cglosa,     \n" +
                        " trim(coalesce(t.ccodcos, '')) as ccodcos,    \n" +
                        " trim(coalesce(t.ccodcos2, '')) as ccodcos2,    \n" +
                        " case when trim(coalesce(t.nporre, '')) = '' then 0 else t.nporre::numeric end as nporre,    \n" +
                        " case when trim(coalesce(t.nimpperc, '')) = '' then 0 else t.nimpperc::numeric end as nimpperc,    \n" +
                        " case when trim(coalesce(t.nperdenre, '')) = '' then 0 else t.nperdenre::numeric end as nperdenre, --5 \n" +
                        " coalesce(trim(t.cserre), '') as cserre, coalesce(trim(t.cnumre), '') as cnumre,    \n" +
                        " case when coalesce(t.ffecre, '')= '' then null else to_date(t.ffecre, 'DD/MM/YYYY') end as ffecre,    \n" +
                        " t.created_at::date, t.updated_at::date,    \n" +
                        " coalesce(trim(t.estado), ''),    \n" +
                        " coalesce(trim(t.en_ambiente_de), ''),  \n" +  
                        " case when  trim(t.estado) = 'CANCELADO' then 0 else 3 end, '', \n" +
                        " coalesce(cast(t.es_anticipo_automatico as integer) ,0) as es_anticipo_automatico \n" +
                        " FROM json_to_recordset(v_data)  \n" +
                        " as t( \n" +
                        " id integer, \n" +
                        " numero_documento_emisor character varying(20),    \n" +
                        " ffechadoccobra character varying(20),    \n" +
                        " cdoccan character varying(5),    \n" +
                        " csercan character varying(50),    \n" +
                        " cnumcan character varying(50),    \n" +
                        " ccuecan character varying(50),    \n" +
                        " cmoncan character varying(50),    \n" +
                        " nimporcan character varying(50),    \n" +
                        " ntipcam character varying(50),    \n" +
                        " ccodpago character varying(50),    \n" +
                        " ccoddoc character varying(20),    \n" +
                        " cserie character varying(50),    \n" +
                        " cnumero character varying(50),    \n" +
                        " ffechadoc character varying(50),    \n" +
                        " ffechaven character varying(50),  \n" +
                        " ccodenti character varying(50),  \n" +
                        " ccodruc character varying(50),  \n" +
                        " crazsoc text, \n" +
                        " nimportes character varying(50),    \n" +
                        "  nimported character varying(50),    \n" +
                        "  ccodcue character varying(50),    \n" +
                        "  cglosa text, \n" +
                        "  ccodcos character varying(50),    \n" +
                        "  ccodcos2 character varying(50),    \n" +
                        "  nporre character varying(50),    \n" +
                        "  nimpperc character varying(50),    \n" +
                        "  nperdenre character varying(50),    \n" +
                        "  cserre character varying(50),    \n" +
                        " cnumre character varying(50),    \n" +
                        " ffecre character varying(50),    \n" +
                        "  created_at timestamp without time zone,    \n" +
                        "   updated_at timestamp without time zone,    \n" +
                        "   estado character varying(50),    \n" +
                        "     en_ambiente_de character varying(255),    \n" +
                        "         es_con_migracion boolean, \n" +
                        "         es_anticipo_automatico boolean   )\n" +
                        "     left join fin_cobranzapago v on t.id = v.idcobranzas \n" +
                        "     where v.idcobranzas is null; \n" +
                        "                 --Modificados \n" +
                        "     update fin_cobranzapago v \n" +
                        "     set es_con_migracion =case when trim(t.estado) = 'CANCELADO' then 0 else 3 end,    \n" +
                        "     estado = trim(t.estado) \n" +
                        "     from json_to_recordset(v_data) \n" +
                        " as t (id integer, estado character varying(255), es_con_migracion boolean )        \n" +
                        " where v.idcobranzas = t.id; \n" +
                        "                 --resultado de confirmacion.    \n" +
                        " select json_agg(json_build_object('idcobranzas', id, 'es_con_migracion', es_con_migracion))::text \n" +
                        " from json_to_recordset(v_data) \n" +
                        " as t (id integer, es_con_migracion boolean) \n" +
                        " into resultado; \n" +
                        "   end;    \n" +
                        " \n" +
                        " $BODY$  \n" +
                        " LANGUAGE 'plpgsql'; ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
               
                #region fn_ventas_envio
                NombreSP = "fn_ventas_envio";
                Query = " CREATE OR REPLACE FUNCTION public.fn_ventas_envio( \n" +
                        " 	OUT resultado text, \n" +
                        " 	p_ruc_emisor character, \n" +
                        " 	p_empresa character) \n" +
                        "     RETURNS text \n" +
                        " AS $BODY$ \n" +
                        " BEGIN  \n" +
                        "        select json_agg(to_json(t))::text \n" +
                        "     from ( \n" +
                        "         select \n" +
                        "             idventas, fin_ventas.ccod_empresa,fin_ventas.cper,cmes,     \n" +
                        "             trim(configuracion.csub1_vta) AS ccodori,    \n" +
                        "             trim(configuracion.clreg1_vta) AS ccodsu,    \n" +
                        "             trim(configuracion.csub2_vta) AS ccodori_p,    \n" +
                        "             trim(configuracion.clreg2_vta) AS ccodsu_p,    \n" +
                        "             trim(configuracion.cconts_vta) AS ccodcue_ps,    \n" +
                        "             trim(configuracion.ccontd_vta) AS ccodcue_pd,   \n" +
                        "             trim(configuracion.cfefec_vta) AS ccodflu,    \n" +
                        "             configuracion.ctares_vta AS flgctares,    \n" +
                        "             configuracion.ctaimp_vta AS flgctaimp,   \n" +
                        "             configuracion.Ctaact_vta AS flgctaact,   \n" +
                        "             configuracion.asientos_vta AS flggencomp,   \n" +
                        "             trim(configuracion.cEntidad) AS ccodtipent,    \n" +
                        "             to_char(ffechadoc, 'YYYY-MM-DD') AS ffechadoc, -- trim(Convert(char(10), ffechadoc, 112)) AS ffechadoc,    \n" +
                        "             to_char(ffechaven, 'YYYY-MM-DD') AS ffechaven, -- trim(Convert(char(10), ffechaven, 112)) AS ffechaven,    \n" +
                        "             trim(ccoddoc) AS ccoddoc,   \n" +
                        "             trim(cserie) AS cserie,   \n" +
                        "             trim(cnumero) AS cnumero,   \n" +
                        "             trim(ccodenti) AS ccodenti,   \n" +
                        "             trim(cdesenti) AS cdesenti,  \n" +
                        "             trim(ctipdoc) AS ctipdoc,   \n" +
                        "             trim(ccodruc) AS ccodruc,   \n" +
                        "             trim(crazsoc) AS crazsoc,   \n" +
                        "             coalesce(nbase2, 0.00) as nbase2, \n" +
                        "             coalesce(nbase1, 0.00) as nbase1,   \n" +
                        "             coalesce(nexo, 0.00) as nexo,   \n" +
                        "             coalesce(nina, 0.00) as nina,    \n" +
                        "             coalesce(nisc, 0.00) as nisc,  \n" +
                        "             coalesce(nigv1, 0.00) as nigv1,  \n" +
                        "             coalesce(nicbpers, 0.00) as nicbpers,  \n" +
                        "             coalesce(nbase3, 0.00) as nbase3,   \n" +
                        "             coalesce(ntots, 0.00) as ntots,   \n" +
                        "             coalesce(ntc, 0.00) as ntc,   \n" +
                        "             to_char(freffec, 'YYYY-MM-DD') AS freffec, --trim(coalesce(Convert(char(10), freffec, 112), ' ')) AS freffec, \n" +
                        "             case when trim(coalesce(crefdoc,'')) = '' then ' ' else trim(crefdoc)  end as crefdoc,   \n" +
                        "             case when trim(coalesce(crefser,'')) = '' then ' ' else trim(crefser)  end as crefser,   \n" +
                        "             case when trim(coalesce(crefnum,'')) = '' then ' ' else trim(crefnum)  end as crefnum,  \n" +
                        "             case when trim(coalesce(cmreg,'')) = '' then ' ' else trim(cmreg)  end as cmreg,   \n" +
                        "             coalesce(ndolar, 0.00) as ndolar,    \n" +
                        "             to_char(ffechaven2, 'YYYY-MM-DD') AS ffechaven2, --trim(coalesce(Convert(char(10), ffechaven2, 112), ' ') AS ffechaven2,    \n" +
                        "             case when trim(coalesce(ccond,'')) = '' then ' ' else trim(ccond)  end as ccond,    \n" +
                        "             case when trim(coalesce(substring(ccodcos,1,9),'')) = '' then ' ' else trim(substring(ccodcos,1,9))  end as ccodcos, \n" +
                        "             case when trim(coalesce(substring(ccodcos2,1,9),'')) = '' then ' ' else trim(substring(ccodcos2,1,9))  end as ccodcos2, \n" +
                        "             case when trim(coalesce(cctabase,'')) = '' then ' ' else trim(cctabase)  end as cctabase,    \n" +
                        "             case when trim(coalesce(cctaicbper,'')) = '' then ' ' else trim(cctaicbper)  end as cctaicbper,    \n" +
                        "             case when trim(coalesce(cctaotrib,'')) = '' then ' ' else trim(cctaotrib)  end as cctaotrib,    \n" +
                        "             case when trim(coalesce(cctatot,'')) = '' then ' ' else trim(cctatot)  end as cctatot,    \n" +
                        "             coalesce(nresp, 0.00) as nresp,    \n" +
                        "             coalesce(nporre, 0.00) as nporre,    \n" +
                        "             coalesce(nimpres, 0.00) as nimpres,    \n" +
                        "             case when trim(coalesce(cserre,'')) = '' then ' ' else trim(cserre)  end as cserre,    \n" +
                        "             case when trim(coalesce(cnumre,'')) = '' then ' ' else trim(cnumre)  end as cnumre,    \n" +
                        "             to_char(ffecre, 'YYYY-MM-DD') AS ffecre, -- trim(coalesce(Convert(char(10), ffecre, 112), ' ') AS ffecre, \n" +
                        "             case when trim(coalesce(ccodpresu,'')) = '' then ' ' else trim(ccodpresu)  end as ccodpresu,    \n" +
                        "             coalesce(nigv, 0.00) as nigv,    \n" +
                        "             case when trim(coalesce(substring(cglosa,1,80),'')) = '' then ' ' else trim(substring(cglosa,1,80))  end::character(80) as cglosa,   \n" +
                        "             case when trim(coalesce(ccodpago,'')) = '' then ' ' else trim(ccodpago)  end as ccodpago,    \n" +
                        "             coalesce(nperdenre, 0.00) as nperdenre,    \n" +
                        "             coalesce(nbaseres, 0.00) as nbaseres,    \n" +
                        "             case when trim(coalesce(cctaperc,'')) = '' then ' ' else trim(cctaperc)  end as cctaperc,   \n" +
                        "             case when trim(coalesce(estado,'')) = '' then ' ' else trim(estado)  end as estado,    \n" +
                        "             case when trim(coalesce(en_ambiente_de,'')) = '' then ' ' else trim(en_ambiente_de)  end as en_ambiente_de,    \n" +
                        "             es_con_migracion,    \n" +
                        "             case when trim(coalesce(ccodcos3,'')) = '' then ' ' else trim(ccodcos3)  end as ccodcos3,    \n" +
                        "             case when es_con_migracion=3  then  trim(configuracion.cEnt_anula)  else '' end  as ccodrucanula   \n" +
                        "         from fin_ventas \n" +
                        "         join configuracion ON fin_ventas.CCOD_EMPRESA = configuracion.CCOD_EMPRESA and fin_ventas.CPER = configuracion.CPER   \n" +
                        "         join CG_EMPRESA emp on fin_ventas.ccodrucemisor = emp.ccodrucemisor and fin_ventas.ccod_empresa = emp.CCOD_EMPRESA  \n" +
                        "         join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1::bit     \n" +
                        "         where    trim(fin_ventas.ccodrucemisor)= trim(p_ruc_emisor)::character(15) \n" +
                        "             and fin_ventas.ccod_empresa = p_empresa::character(3) \n" +
                        "             and es_con_migracion in (0, 3) \n" +
                        "             and configuracion.ctipo = '01'  \n" +
                        " 			  and to_char(fin_ventas.ffechadoc, 'YYYY-MM-DD')>=to_char(configuracion.ffecha_inicioproceso, 'YYYY-MM-DD') \n" +
                        "    ) t \n" +
                        "     into resultado; \n" +
                        " END; \n" +
                        " $BODY$  \n" +
                        " LANGUAGE 'plpgsql'; ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion

                


            }

            if (Properties.Settings.Default.TipModulo == "2")   /// comercial en Postgres
            {
                // Area para tablas comerciales //
                NombreTable = "cg_empemisor";
                Nombrecampo = "nventaflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + "  add column  " + Nombrecampo.Trim().ToLower() + "  Numeric(1,0) default 0;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                Nombrecampo = "ncomFondom";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "   Numeric(1,0) default 0;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                NombreTable = "cg_empemisor";
                Nombrecampo = "ncompraflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + "    Numeric(1,0) default 0;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                txtMensaje.Refresh();
                this.Barraprogreso(respuesta);
                
                
                
                NombreTable = "cg_empemisor";
                Nombrecampo = "ncobranzaflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + "    Numeric(1,0) default 0;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
                
                NombreTable = "cg_empemisor";
                Nombrecampo = "npagoflg";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + "   Numeric(1,0) default 0;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                NombreTable = "cg_empemisor";
                Nombrecampo = "ncobranzacomercial";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + "   Numeric(1,0) default 0;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);


                #region modulo_comercial
                NombreTable = "modulo_comercial";
                Query = "create table modulo_comercial( " +
                       "ccodmudulo Char(6) null, " +
                       "cdesmodulo char(50) null)";
                respuesta = obj.crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion

                #region configuracion2
                NombreTable = "configuracion2";
                Query = "drop sequence if exists sec_id;" +
                " create sequence sec_id minvalue 1 maxvalue 99999999999 increment by 1; " +
                " CREATE TABLE configuracion2( " +
                 "    id bigint not null, " +
                 "   ccod_empresa char(3) NULL, " +
                 "   cper char(4) NULL, " +
                 "   crazemp char(100) NULL, " +
                 "   crucemp char(15) NULL, " +
                 "   Entidad char(3) NULL, " +
                 "   Tipo char(5) NULL, " +
                 "   cTipo char(2) NULL, " +
                 "   codtipdocu char(4) NULL, " +
                 "   cserie char(20) NULL, " +
                 "   ccodmov char(10) NULL, " +
                 "   ccodpag char(5) NULL, " +
                 "   ccodvend char(10) NULL, " +
                 "   ccodalma char(10) NULL, " +
                 "   Ent_anula char(15) NULL, " +
                 "   Prodanula char(15) NULL, " +
                 "   ffecha_inicioproceso date, " +
                 "   ccodoripago character(3), " +
                 "   clibropago character(2), " +
                 "   ccodflupago character(4), " +
                 "   constraint uk_configuracion2 UNIQUE(cper,crucemp,tipo,codtipdocu,cserie));";
                respuesta = obj.crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion

                #region campos_para_configuracion2
                NombreTable = "configuracion2";
                Nombrecampo = "ffecha_inicioproceso";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  date null ";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region campos_para_configuracion2_ctipo
                NombreTable = "configuracion2";
                Nombrecampo = "ctipo";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  char(2) null ";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
                #endregion

                #region campos_para_configuracion2_ctipo
                NombreTable = "configuracion2";
                Nombrecampo = "cserie";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  char(20) null ";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);


                #endregion
                #region com_producto
                NombreTable = "com_producto";
                Query = "CREATE TABLE IF NOT EXISTS public.com_producto\n" +
                "(\n" +
                "    idproducto numeric(20,0) NOT NULL,\n" +
                "    ccodrucemisor character(15)  NULL,\n" +
                "    ccod_empresa character(3)  NULL,\n" +
                "    ccodfamg character(20) NULL,\n" +
                "    cdesfamg character(50) NULL,\n" +
                "    ccodfamf character(20) NULL,\n" +
                "    cdesfamf character(50) NULL,\n" +
                "    ccodprod character(20)  NULL,\n" +
                "    cdesprod character(150) NULL,\n" +
                "    cdesprodgen character varying(500) NULL,\n" +
                "    ccodtes character(2) COLLATE NULL,\n" +
                "    ccodmar character(4) NULL,\n" +
                "    cdesmar character(80) NULL,\n" +
                "    ccodmed character(15) NULL,\n" +
                "    ccodums character(3) NULL,\n" +
                "    ccodcatbs character(16) NULL,\n" +
                "    cdescatbs character(250) NULL,\n" +
                "    ntipoprod character(8) NULL,\n" +
                "    nunidsec character(2) NULL,\n" +
                "    npesoprod numeric(10,4),\n" +
                "    ccodbarras character(15) NULL,\n" +
                "    ninprod character(2) NULL,\n" +
                "    nanuprod character(2) NULL,\n" +
                "    nlote character(2) NULL,\n" +
                "    nseruni character(2) NULL,\n" +
                "    nicbper character(2) NULL,\n" +
                "    nprodanti character(2) NULL,\n" +
                "    ngasrela character(2) NULL,\n" +
                "    nprodsafniif character(2) NULL,\n" +
                "    ccomcue character(20) NULL,\n" +
                "    cvencue character(20) NULL,\n" +
                "    cdebicue character(20) NULL,\n" +
                "    ccredcue character(20) NULL,\n" +
                "    cdebicuei character(20) NULL,\n" +
                "    ccredcuei character(20) NULL,\n" +
                "    ccodcos character(9) NULL,\n" +
                "    ccodcos2 character(9) NULL,\n" +
                "    ccodpresu character(10) NULL,\n" +
                "    ccomprod character(1) NULL,\n" +
                "    cvenprod character(1) NULL,\n" +
                "    ccodisc character(5) NULL,\n" +
                "    cmoneda character(1) NULL,\n" +
                "    npreunit1 numeric(15,4),\n" +
                "    npreunit2 numeric(15,4),\n" +
                "    npreunit3 numeric(15,4),\n" +
                "    npreunit4 numeric(15,4),\n" +
                "    npreunit5 numeric(15,4),\n" +
                "    npreunit6 numeric(15,4),\n" +
                "    npreunit7 numeric(15,4),\n" +
                "    npreunit8 numeric(15,4),\n" +
                "    npreunit9 numeric(15,4),\n" +
                "    npreunit10 numeric(15,4),\n" +
                "    npreunit11 numeric(15,4),\n" +
                "    npreunit12 numeric(15,4),\n" +
                "    npreunit13 numeric(15,4),\n" +
                "    npreunit14 numeric(15,4),\n" +
                "    npreunit15 numeric(15,4),\n" +
                "    nstockmin numeric(15,4),\n" +
                "    nstockmax numeric(15,4),\n" +
                "    nrango1 numeric(15,0),\n" +
                "    nrango2 numeric(15,0),\n" +
                "    nresp numeric(1,0),\n" +
                "    ccodpps character(2) ,\n" +
                "    ccodpds character(5) ,\n" +
                "    nagemonmin numeric(15,2),\n" +
                "    ccodlabora character(4) ,\n" +
                "    cdeslabora character(60) NULL,\n" +
                "    estado character varying(255) NULL,\n" +
                "    en_ambiente_de character varying(255) NULL,\n" +
                "    es_con_migracion numeric(1,0),\n" +
                "    ccodcos3 character(15) NULL,\n" +
                "    obserror text NULL,\n" +
                "    resultado_migracion numeric(1,0),\n" +
                "    CONSTRAINT pk_prducto PRIMARY KEY (ccodrucemisor, ccod_empresa, ccodprod));";
                respuesta = obj.crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region com_documento
                NombreTable = "com_documento";
                Query = "CREATE TABLE IF NOT EXISTS public.com_documento \n" +
                        "(  iddocumento integer NOT NULL,\n" +
                        "    ccodrucemisor character(15) Null,\n" +
                        "    ccod_empresa character(3) Null,\n" +
                        "    cper character(4) Null,\n" +
                        "    cmes character(2) Null,\n" +
                        "    ccodmodulo character(6) Null,\n" +
                        "    ccodmov character(5) Null,\n" +
                        "    ccoddoc character(2) Null,\n" +
                        "    cserie character(20) Null,\n" +
                        "    cnumero character(20) Null,\n" +
                        "    ccodenti character(11) Null,\n" +
                        "    cdesenti character(100) Null,\n" +
                        "    ccodtipent character(3) Null,\n" +
                        "    ccodruc character(15) Null,\n" +
                        "    crazsoc character(150) Null,\n" +
                        "    cdirecc character(250) Null,\n" +
                        "    ccodubi character(6) Null,\n" +
                        "    ccodcontac character(3) Null,\n" +
                        "    cdescontacto character(150) Null,\n" +
                        "    ffecha date,\n" +
                        "    ffechaven date,\n" +
                        "    ffechaalm date,\n" +
                        "    ccodpag character(2) Null,\n" +
                        "    cmoneda character(1) Null,\n" +
                        "    ntcigv numeric(10,6),\n" +
                        "    cguiaser character(7) Null,\n" +
                        "    cguianum character(13) Null,\n" +
                        "    mdsc text Null,\n" +
                        "    ccodvend character(4) Null,\n" +
                        "    ccodclas character(1) Null,\n" +
                        "    ccodocon character(4) Null,\n" +
                        "    cnumordc character(20) Null,\n" +
                        "    crefdoc character(2) Null,\n" +
                        "    freffec date,\n" +
                        "    crefser character(10) Null,\n" +
                        "    crefnum character(13) Null,\n" +
                        "    ccat09 character(2) Null,\n" +
                        "    cmotinc character(50) Null,\n" +
                        "    nresp numeric(1,0),\n" +
                        "    ccodpds character(5) Null,\n" +
                        "    nporre numeric(5,2),\n" +
                        "    ffecre date,\n" +
                        "    cnumdere character(15) Null,\n" +
                        "    ccodpps character(2) Null,\n" +
                        "    nporre2 numeric(5,2),\n" +
                        "    nperdenre numeric(1,0),\n" +
                        "    nbase1 numeric(15,2),\n" +
                        "    nigv1 numeric(15,2),\n" +
                        "    nbase2 numeric(15,2),\n" +
                        "    nigv2 numeric(15,2),\n" +
                        "    nbase3 numeric(15,2),\n" +
                        "    nigv3 numeric(15,2),\n" +
                        "    nimpicbper numeric(15,2),\n" +
                        "    nina numeric(15,2),\n" +
                        "    nexo numeric(15,2),\n" +
                        "    nisc numeric(15,2),\n" +
                        "    nivabase numeric(15,2),\n" +
                        "    nivaimp numeric(15,2),\n" +
                        "    nimpant numeric(15,2),\n" +
                        "    ntot numeric(15,2),\n" +
                        "    created_at date,\n" +
                        "    updated_at date,\n" +
                        "    estado character(255) Null,\n" +
                        "    en_ambiente_de character(255) Null,\n" +
                        "    es_con_migracion numeric(1,0) DEFAULT '0'::numeric,\n" +
                        "    ccodcos3 character(15) Null,\n" +
                        "    obserror text Null,\n" +
                        "    ccond character(3) Null,\n" +
                        "    ccuecan character(20) Null,\n" +
                        "    cdoccan character(2) Null,\n" +
                        "    csercan character(20) Null,\n" +
                        "    cnumcan character(20) Null,\n" +
                        "    cnumcam character(20) Null,\n" +
                        "    obserrorcan text Null,\n" +
                        "    resultadocan_migracion numeric(1,0) DEFAULT 0,\n" +
                        "    ccodpago character(3) Null,\n" +
                        "    resultado_migracion text Null,\n" +
                        "    CONSTRAINT com_documento_pkey PRIMARY KEY (iddocumento),\n" +
                        "    CONSTRAINT uk_documento UNIQUE (ccodrucemisor, ccod_empresa, ccoddoc, cserie, cnumero, ccodruc));";
                respuesta = obj.crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region com_detalledocumento
                NombreTable ="com_detalledocumento";
                Query = "   CREATE TABLE com_detalledocumento( \n" +
                        " 	iddetalledocumento int NOT NULL, \n" +
                        " 	iddocumento int NOT NULL, \n" +
                        " 	ccodalma char(3) NULL, \n" +
                        " 	ccodprod char(20) NULL, \n" +
                        " 	ccodmed char(15) NULL, \n" +
                        " 	ccodlote char(20) NULL, \n" +
                        "   ffecfablote date NULL,\n" +
                        "   ffecvenlote date NULL,\n" +
                        " 	nuniori numeric(20, 10) NULL, \n" +
                        " 	nvvori numeric(20, 10) NULL, \n" +
                        " 	npvori numeric(20, 10) NULL, \n" +
                        " 	nvalor numeric(15, 2) NULL, \n" +
                        " 	nigvtot numeric(15, 2) NULL, \n" +
                        " 	ntotori numeric(15, 2) NULL, \n" +
                        " 	npigv numeric(5, 2) NULL, \n" +
                        "   nconvnum numeric(9,2) NULL, \n" +
                        "   nconvden numeric(9,2) NULL, \n" +
                        "   clibprod char(1) null,\n" +
                        " 	ccodcos char(9) NULL, \n" +
                        "   ccodcos2 char(9) NULL, \n" +
                        "   ccodpresu char(10) NULL, \n" +
                        "   cctaprod char(20) NULL, \n" +
                        "   npordscu numeric(15, 2) NULL, \n" +
                        "   ndsctos numeric(15, 2) NULL, \n" +
                        "   ccodisc char(5) NULL, \n" +
                        "   nporisc numeric(5, 2) NULL, \n" +
                        "   nisc numeric(15, 2) NULL, \n" +
                        "   tipo_isc numeric(1, 0) NULL, \n" +
                        "   mdscl text NULL,	CONSTRAINT com_detalledocumento_pkey PRIMARY KEY (iddetalledocumento)); ";
                respuesta = obj.crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion

                #region cg_moduloconfigura
                NombreTable = "cg_moduloconfigura";
                Query = "CREATE TABLE IF NOT EXISTS public.cg_moduloconfigura  \n" +
                        "(  \n" +
                        "id bigint default 0 ),\n" +
                        "cmodulo character(20)  \n" +
                        ");";
                respuesta = obj.crear_tablas(NombreTable, Query);
                this.Barraprogreso(respuesta);
                #endregion

                #region cg_moduloconfigura
                NombreSP = "cg_moduloconfigura";
                Query = "delete from  cg_moduloconfigura;";
                respuesta = obj.ejecutar_comando("", NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion



                #region cg_moduloconfigura
                NombreSP = "cg_moduloconfigura";
                Query = "INSERT INTO cg_moduloconfigura(id,cmodulo) values(1,'Modulo Contable');";
                respuesta = obj.ejecutar_comando("", NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion

                #region cg_moduloconfigura2
                NombreSP = "cg_moduloconfigura";
                Query = "INSERT INTO cg_moduloconfigura(id,cmodulo) values(2,'Modulo Comercial');";
                respuesta = obj.ejecutar_comando("", NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion















                #region com_detalledocumento2
                NombreTable = "com_detalledocumento";
                Nombrecampo = "nconvnum";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  numeric(9,2) default 0 ";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                NombreTable = "com_detalledocumento";
                Nombrecampo = "nconvden";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  numeric(9,2) default 0 ";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);
               

                NombreTable = "com_detalledocumento";
                Nombrecampo = "clibprod";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  character(1) default '' ";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);





                NombreTable = "com_documento";
                Nombrecampo = "cdoccan";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  character(2) default '' ";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                NombreTable = "com_documento";
                Nombrecampo = "csercan";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  character(20) default '' ";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                NombreTable = "com_documento";
                Nombrecampo = "cnumcan";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + "  character(20) default '' ";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                this.Barraprogreso(respuesta);

                NombreTable = "com_documento";
                Nombrecampo = "obserrorcan";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " text default '';";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);

                NombreTable = "com_documento";
                Nombrecampo = "resultadocan_migracion";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " Numeric(1,0) default 0;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);


                NombreTable = "configuracion2";
                Nombrecampo = "cserie";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " character(20) default '';";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);

                NombreTable = "com_documento";
                Nombrecampo = "ccodrucemisor";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add  " + Nombrecampo.Trim().ToLower() + "  character(15);";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);



                NombreTable = "com_documento";
                Nombrecampo = "ccodpago";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add  " + Nombrecampo.Trim().ToLower() + "  character(3);";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);


                NombreTable = "com_detalledocumento";
                Nombrecampo = "es_con_migracion";
                Query = "alter table " + NombreTable.Trim().ToLower() + " add  " + Nombrecampo.Trim().ToLower() + "  Numeric(1) default 0;";
                respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                #endregion

                /**NombreTable = "com_detalledocumento";
                Nombrecampo = "es_con_migracion";
                Query = "drop sequence if exists sec_id;" +
                " create sequence sec_id minvalue 1 maxvalue 99999999999 increment by 1; "; 
                 respuesta = obj.ejecutar_comando(NombreTable, Nombrecampo, Query);**/




                //// FUNCIONES MODIFICADAS PARA COMERCIAL DARWIN ////

                #region fn_integracion_productos_importar

                NombreSP = "fn_integracion_productos_importar";
                Query = "CREATE OR REPLACE FUNCTION fn_integracion_productos_importar( \n" +
                        "	OUT resultado text, \n" +
                        "	p_datos text, \n" +
                        "	p_cod_emp text) \n" +
                        "    RETURNS text   \n" +
                        " ----------Fecha: 01/04/2025   \n" +
                        "AS  \n" +
                        "$BODY$  \n" +
                        "    \n" +
                        " DECLARE  \n" +
                        " v_data json;  \n" +
                        " BEGIN  \n" +
                        "       \n" +
                        "    v_data:= p_datos::json;  \n" +
                        " 	p_datos = null;  \n" +
                        " \n" +
                        "	--nuevos  \n" +
                        "--ccodmar  \n" +
                        "--trim(t.ccodmar) as ccodmar,    \n" +
                        "-- - ccodums  \n" +
                        "-- - trim(t.ccodums) as ccodums,   \n" +
                        "----- ccodpds  \n" +
                        "---- - cdeslabora  \n" +
                        "----t.cdeslabora,    \n" +
                        "	 INSERT INTO com_producto (  \n" +
                        "	 	idproducto, ccodrucemisor, ccod_empresa,  ccodfamg, cdesfamg, ccodfamf, cdesfamf, ccodprod, cdesprod, cdesprodgen,  \n" +
                        "		ccodtes,  cdesmar, ccodmed, ccodcatbs, cdescatbs, ntipoprod, nunidsec, npesoprod, ccodbarras, ninprod, nanuprod,  \n" +
                        "		nlote, nseruni, nicbper, nprodanti, ngasrela, nprodsafniif, ccomcue, cvencue, cdebicue, ccredcue, cdebicuei, ccredcuei,  \n" +
                        "		ccodcos, ccodcos2, ccodpresu, ccomprod, cvenprod, ccodisc, cmoneda, npreunit1, npreunit2, npreunit3, npreunit4, npreunit5,  \n" +
                        "		npreunit6, npreunit7, npreunit8, npreunit9, npreunit10, npreunit11, npreunit12, npreunit13, npreunit14, npreunit15,  \n" +
                        "		nstockmin, nstockmax, nrango1, nrango2, nresp, ccodpps,  nagemonmin, ccodlabora,  estado,  \n" +
                        "	    ccodcos3 \n" +
                        "	 ) \n" +
                        "	SELECT   \n" +
                        "			 t.idproducto,  \n" +
                        "			 t.ccodrucemisor, \n" +
                        "			 p_cod_emp, \n" +
                        "			 trim(t.ccodfamg) as ccodfamg,  \n" +
                        "			 trim(t.cdesfamg) as cdesfamg,  \n" +
                        "			 trim(t.ccodfamf) as ccodfamf,  \n" +
                        "			 trim(t.cdesfamf) as cdesfamf, \n" +
                        "			 trim(t.ccodprod) as ccodprod,  \n" +
                        "			 trim(t.cdesprod) as cdesprod,  \n" +
                        "			 trim(t.cdesprodgen) as cdesprodgen,  \n" +
                        "			 trim(t.ccodtes) as ccodtes,  \n" +
                        "			 trim(t.cdesmar) as cdesmar,  \n" +
                        "			 trim(t.ccodmed) as ccodmed,  \n" +
                        "			 trim(t.ccodcatbs) as ccodcatbs,  \n" +
                        "			 trim(t.cdescatbs) as cdescatbs,  \n" +
                        "			 trim(t.ntipoprod) as ntipoprod,  \n" +
                        "			 t.nunidsec,  \n" +
                        "			 t.npesoprod,  \n" +
                        "			 trim(t.ccodbarras) as ccodbarras,  \n" +
                        "			 t.ninprod,  \n" +
                        "			 t.nanuprod,  \n" +
                        "			 t.nlote,  \n" +
                        "			 t.nseruni,  \n" +
                        "			 t.nicbper,  \n" +
                        "			 t.nprodanti,  \n" +
                        "			 t.ngasrela,  \n" +
                        "			 t.nprodsafniif,  \n" +
                        "			 trim(t.ccomcue) as ccomcue,  \n" +
                        "			 trim(t.cvencue) as cvencue,  \n" +
                        "			 trim(t.cdebicue) as cdebicue,  \n" +
                        "			 trim(t.ccredcue) as ccredcue,  \n" +
                        "			 trim(t.cdebicuei) as cdebicuei,  \n" +
                        "			 trim(t.ccredcuei) as ccredcuei,  \n" +
                        "			 trim(t.ccodcos) as ccodcos,  \n" +
                        "			 trim(t.ccodcos2) as ccodcos2,  \n" +
                        "			 trim(t.ccodpresu) as ccodpresu,  \n" +
                        "			 trim(t.ccomprod) as ccomprod,  \n" +
                        "			 trim(t.cvenprod) as cvenprod,  \n" +
                        "			 t.ccodisc,  \n" +
                        "			 trim(t.cmoneda) as cmoneda,  \n" +
                        "			 t.npreunit1,  \n" +
                        "			 t.npreunit2,  \n" +
                        "			 t.npreunit3,  \n" +
                        "			 t.npreunit4,  \n" +
                        "			 t.npreunit5,  \n" +
                        "			 t.npreunit6,  \n" +
                        "			 t.npreunit7,  \n" +
                        "			 t.npreunit8,  \n" +
                        "			 t.npreunit9,  \n" +
                        "			 t.npreunit10,  \n" +
                        "			 t.npreunit11,  \n" +
                        "			 t.npreunit12,  \n" +
                        "			 t.npreunit13,  \n" +
                        "			 t.npreunit14,  \n" +
                        "			 t.npreunit15,  \n" +
                        "			 t.nstockmin,  \n" +
                        "			 t.nstockmax,  \n" +
                        "			 t.nrango1,  \n" +
                        "			 t.nrango2,  \n" +
                        "			 t.nresp,  \n" +
                        "			 t.ccodpps,  \n" +
                        "			 t.nagemonmin,  \n" +
                        "			 t.ccodlabora,  \n" +
                        "			 trim(t.estado) as estado,  \n" +
                        "			 trim(t.ccodcos3) as ccodcos3  \n" +
                        "		  \n" +
                        "	 FROM json_to_recordset(v_data) \n" +
                        "	 as t( idproducto integer, \n" +
                        "		    ccodrucemisor character(15), \n" +
                        "		    ccod_empresa character(3), \n" +
                        "		    ccodfamg character(20), \n" +
                        "		    cdesfamg character(50), \n" +
                        "		    ccodfamf character(20), \n" +
                        "		    cdesfamf character(50), \n" +
                        "		    ccodprod character(20), \n" +
                        "		    cdesprod character(150), \n" +
                        "		    cdesprodgen character varying(500), \n" +
                        "		    ccodtes character(2), \n" +
                        "		    cdesmar character(80), \n" +
                        "		    ccodmed character(15), \n" +
                        "		    ccodcatbs character(8), \n" +
                        "		    cdescatbs character(100), \n" +
                        "		    ntipoprod character(8), \n" +
                        "		    nunidsec character(2), \n" +
                        "		    npesoprod numeric(10,4), \n" +
                        "		    ccodbarras character(15), \n" +
                        "		    ninprod character(2), \n" +
                        "		    nanuprod character(2), \n" +
                        "		    nlote character(2), \n" +
                        "		    nseruni character(2), \n" +
                        "		    nicbper character(2), \n" +
                        "		    nprodanti character(2), \n" +
                        "		    ngasrela character(2), \n" +
                        "		    nprodsafniif character(2), \n" +
                        "		    ccomcue character(20), \n" +
                        "		    cvencue character(20), \n" +
                        "		    cdebicue character(20), \n" +
                        "		    ccredcue character(20), \n" +
                        "		    cdebicuei character(20), \n" +
                        "		    ccredcuei character(20), \n" +
                        "		    ccodcos character(9), \n" +
                        "		    ccodcos2 character(9), \n" +
                        "		    ccodpresu character(10), \n" +
                        "		    ccomprod character(1), \n" +
                        "		    cvenprod character(1), \n" +
                        "		    ccodisc character(5), \n" +
                        "		    cmoneda character(1), \n" +
                        "		    npreunit1 numeric(15,4), \n" +
                        "		    npreunit2 numeric(15,4), \n" +
                        "		    npreunit3 numeric(15,4), \n" +
                        "		    npreunit4 numeric(15,4), \n" +
                        "		    npreunit5 numeric(15,4), \n" +
                        "		    npreunit6 numeric(15,4), \n" +
                        "		    npreunit7 numeric(15,4), \n" +
                        "		    npreunit8 numeric(15,4), \n" +
                        "		    npreunit9 numeric(15,4), \n" +
                        "		    npreunit10 numeric(15,4), \n" +
                        "		    npreunit11 numeric(15,4), \n" +
                        "		    npreunit12 numeric(15,4), \n" +
                        "		    npreunit13 numeric(15,4), \n" +
                        "		    npreunit14 numeric(15,4), \n" +
                        "		    npreunit15 numeric(15,4), \n" +
                        "		    nstockmin numeric(15,4), \n" +
                        "		    nstockmax numeric(15,4), \n" +
                        "		    nrango1 numeric(15,0), \n" +
                        "		    nrango2 numeric(15,0), \n" +
                        "		    nresp numeric(1,0), \n" +
                        "		    ccodpps character(2), \n" +
                        "		    ccodppd character(5), \n" +
                        "		    nagemonmin numeric(15,2), \n" +
                        "		    ccodlabora character(4), \n" +
                        "		    estado character(40), \n" +
                        "		    ccodcos3 character(15) \n" +
                        "	 ) \n" +
                        "	 left join com_producto v on t.idproducto = v.idproducto  \n" +
                        "	 where v.idproducto is null;   \n" +
                        "	  \n" +
                        "     \n" +
                        "update com_producto set ccomcue=b.ccomcue,cvencue=b.cvencue,es_con_migracion=0  \n" +
                        " from(SELECT t.idproducto, t.ccodrucemisor,t.ccod_empresa,trim(t.ccomcue) as ccomcue, \n" +
                        " trim(t.cvencue) as cvencue  FROM json_to_recordset(v_data) \n" +
                        " as t(idproducto integer,  ccodrucemisor character(15),  ccod_empresa character(3),\n" +
                        " ccomcue character(20),cvencue character(20)) \n" +
                        " inner join com_producto v on t.idproducto = v.idproducto \n" +
                        " where v.idproducto is not null) as b where com_producto.idproducto = b.idproducto and  \n" +
                        " com_producto.ccodrucemisor = b.ccodrucemisor and com_producto.ccod_empresa = b.ccod_empresa; \n" +
                        "   \n" +
                        "	 update com_producto v   \n" +
                        "	 set es_con_migracion = 0   \n" +
                        "	 from json_to_recordset(v_data)   \n" +
                        "	 as t (idproducto integer, estado character varying(255), es_con_migracion boolean )       \n" +
                        "	 where v.idproducto = t.idproducto;   \n" +
                        "  \n" +
                        "	 --resultado de confirmacion.   \n" +
                        "	 select json_agg(json_build_object('idproducto', idproducto, 'es_con_migracion', es_con_migracion))::text   \n" +
                        "	 from json_to_recordset(v_data)   \n" +
                        "	 	as t (idproducto integer, es_con_migracion boolean)   \n" +
                        "	 	into resultado;   \n" +
                        " end;   \n" +
                        "  \n" +
                        "$BODY$  \n" +
                        "	LANGUAGE 'plpgsql' VOLATILE  \n";

                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_integracion_documentos_importar
                NombreSP = "fn_integracion_documentos_importar";
                Query = "CREATE OR REPLACE FUNCTION fn_integracion_documentos_importar(\n" +
                        "	OUT resultado text,\n" +
                        "	p_datos text,\n" +
                        "	p_cod_emp text)\n" +
                        "    RETURNS text     \n" +
                        "AS \n" +
                        "$BODY$ \n" +
                        "------ fecha: 01/04/2025   \n" +
                        " DECLARE \n" +
                        " v_data json; \n" +
                        " BEGIN \n" +
                        "\n" +
                        "    v_data:= p_datos::json; \n" +
                        " 	p_datos = null; \n" +
                        "\n" +
                        "	--nuevos \n" +
                        "   INSERT INTO com_documento (  \n" +
                        "   iddocumento,ccodrucemisor,ccod_empresa,cper,cmes,ccodmodulo,ccodmov,ccoddoc,cserie,cnumero,ccodenti,cdesenti,ccodtipent,ccodruc, \n" +
                        "   crazsoc,cdirecc,ccodubi,ccodcontac,cdescontacto,ffecha,ffechaven,ffechaalm,ccodpag,ccond, \n" +
                        "   ccuecan,cmoneda,ntcigv,cguiaser,cguianum, \n" +
                        "   mdsc,ccodvend,ccodclas,cnumordc,crefdoc,freffec,crefser,crefnum,ccat09,cmotinc,nresp,ccodpds,nporre,ffecre,cnumdere,ccodpps, \n" +
                        "   nporre2,nperdenre,nbase1,nigv1,nbase2,nigv2,nbase3,nigv3,nina,nexo,nisc,nivabase,nivaimp,nimpant,ntot, \n" +
                        "   nimpicbper,estado,cdoccan,csercan,cnumcan,ccodpago) \n" +
                        "   SELECT  \n" +
                        "   t.iddocumento,  \n" +
                        "           t.ccodrucemisor, \n" +
                        "           p_cod_emp,  \n" +
                        "			trim(t.cper) as cper,   \n" +
                        "			trim(t.cmes) as cmes,   \n" +
                        "			trim(t.ccodmodulo) as ccodmodulo,  \n" +
                        "			trim(t.ccodmov) as ccodmov,  \n" +
                        "			trim(t.ccoddoc) as ccoddoc,  \n" +
                        "			trim(t.cserie) as cserie,  \n" +
                        "			trim(t.cnumero) as cnumero,  \n" +
                        "			trim(t.ccodenti) as ccodenti,  \n" +
                        "			trim(t.cdesenti) as cdesenti,  \n" +
                        "			trim(t.ccodtipent) as ccodtipent,  \n" +
                        "			trim(t.ccodruc) as ccodruc,  \n" +
                        "			trim(t.crazsoc) as crazsoc,  \n" +
                        "			trim(t.cdirecc) as cdirecc,  \n" +
                        "			trim(t.ccodubi) as ccodubi,  \n" +
                        "			trim(t.ccodcontac) as ccodcontac,  \n" +
                        "			trim(t.cdescontacto) as cdescontacto,  \n" +
                        "			t.ffecha as ffecha ,  \n" +
                        "			t.ffechaven as ffechaven,  \n" +
                        "			t.ffechaalm as ffechaalm,  \n" +
                        "			trim(t.ccodpag) as ccodpag,  \n" +
                        "			trim(t.ccond) as ccond,  \n" +
                        "			trim(t.ccuencan) as ccuencan,  \n" +
                        "			trim(t.cmoneda) as cmoneda,  \n" +
                        "			t.ntcigv,  \n" +
                        "			trim(t.cguiaser) as cguiaser,  \n" +
                        "			trim(t.cguianum) as cguianum,  \n" +
                        "			trim(t.mdsc) as mdsc,  \n" +
                        "			trim(t.ccodvend) as ccodvend,  \n" +
                        "			trim(t.ccodclas) as ccodclas,  \n" +
                        "			trim(t.cnumordc) as cnumordc,  \n" +
                        "			trim(t.crefdoc) as crefdoc,  \n" +
                        "			t.freffec,  \n" +
                        "			trim(t.crefser) as crefser,  \n" +
                        "			trim(t.crefnum) as crefnum,  \n" +
                        "			trim(t.ccat09) as ccat09,  \n" +
                        "			trim(t.cmotinc) as cmotinc,  \n" +
                        "			t.nresp,  \n" +
                        "			trim(t.ccodpds) as ccodpds,  \n" +
                        "			t.nporre,  \n" +
                        "			t.ffecre,  \n" +
                        "			trim(t.cnumdere) as cnumdere,  \n" +
                        "			trim(t.ccodpps) as ccodpps,  \n" +
                        "			t.nporre2,  \n" +
                        "			t.nperdenre as nperdenre,  \n" +
                        "			t.nbase1,  \n" +
                        "			t.nigv1,  \n" +
                        "			t.nbase2,  \n" +
                        "			t.nigv2,  \n" +
                        "			t.nbase3,  \n" +
                        "			t.nigv3,  \n" +
                        "			t.nina,  \n" +
                        "			t.nexo,  \n" +
                        "			t.nisc,  \n" +
                        "			t.nivabase,  \n" +
                        "			t.nivaimp,  \n" +
                        "			t.nimpant,  \n" +
                        "			t.ntot,  \n" +
                        "			t.nimpicbper,  \n" +
                        "			trim(t.estado) as estado,  \n" +
                        "		 	t.cdoccan,  \n" +
                        "		    t.csercan,  \n" +
                        "		    t.cnumcan,  \n" +
                        "		    t.ccodpago  \n" +
                        "     FROM json_to_recordset(v_data)  \n" +
                        "   as t(iddocumento integer,  \n" +
                        "           ccodrucemisor character(15),  \n" +
                        "		    ccod_empresa character(3),  \n" +
                        "		    cper character(4),  \n" +
                        "		    cmes character(2),  \n" +
                        "		    ccodmodulo character(6),  \n" +
                        "		    ccodmov character(5),  \n" +
                        "		    ccoddoc character(2),  \n" +
                        "		    cserie character(20),  \n" +
                        "		    cnumero character(20),  \n" +
                        "		    ccodenti character(11),  \n" +
                        "		    cdesenti character varying(100),  \n" +
                        "		    ccodtipent character(3),  \n" +
                        "		    ccodruc character(15),  \n" +
                        "		    crazsoc character(150),  \n" +
                        "		    cdirecc character(250),  \n" +
                        "		    ccodubi character(6),  \n" +
                        "		    ccodcontac character(3),  \n" +
                        "		    cdescontacto character(150),  \n" +
                        "		    ffecha date,  \n" +
                        "           ffechaven date,  \n" +
                        "		    ffechaalm date,  \n" +
                        "           ccodpag character(2),  \n" +
                        "		    ccond character(3),  \n" +
                        "		    ccuencan character(20),  \n" +
                        "		    cmoneda character(1),  \n" +
                        "		    ntcigv numeric(10,6),  \n" +
                        "		    cguiaser character(4),  \n" +
                        "		    cguianum character(13),  \n" +
                        "		    mdsc text,  \n" +
                        "           ccodvend character(4),  \n" +
                        "		    ccodclas character(1),  \n" +
                        "		    cnumordc character(20),  \n" +
                        "		    crefdoc character(2),  \n" +
                        "		    freffec date,  \n" +
                        "           crefser character(10),  \n" +
                        "		    crefnum character(13),  \n" +
                        "		    ccat09 character(2),  \n" +
                        "		    cmotinc character(50),  \n" +
                        "		    nresp numeric(1,0),  \n" +
                        "		    ccodpds character(5),  \n" +
                        "		    nporre numeric(5,2),  \n" +
                        "		    ffecre date,  \n" +
                        "           cnumdere character(15),  \n" +
                        "		    ccodpps character(5),  \n" +
                        "		    nporre2 numeric(5,2),  \n" +
                        "          nperdenre numeric(15,2),  \n" +
                        "		    nbase1 numeric(15,2),  \n" +
                        "		    nigv1 numeric(15,2),  \n" +
                        "		    nbase2 numeric(15,2),  \n" +
                        "		    nigv2 numeric(15,2),  \n" +
                        "		    nbase3 numeric(15,2),  \n" +
                        "		    nigv3 numeric(15,2),  \n" +
                        "		    nina numeric(15,2),  \n" +
                        "		    nexo numeric(15,2),  \n" +
                        "		    nisc numeric(15,2),  \n" +
                        "		    nivabase numeric(15,2),  \n" +
                        "		    nivaimp numeric(15,2),  \n" +
                        "		    nimpant numeric(15,2),  \n" +
                        "		    ntot numeric(15,2),  \n" +
                        "		    nimpicbper numeric(15,2),  \n" +
                        "		    estado character varying(255),  \n" +
                        "		 	cdoccan character varying(255),  \n" +
                        "		    csercan character varying(255),  \n" +
                        "		     cnumcan character varying(255),  \n" +
                        "		    ccodpago character(3)   \n" +
                        "	 )\n" +
                        "	 left join com_documento v on t.iddocumento = v.iddocumento \n" +
                        "	 where v.iddocumento is null;  \n" +
                        "	 \n" +
                        "\n" +
                        "	 update com_documento v    \n" +
                        "	 set es_con_migracion = case when  trim(t.estado)= 'ANULADO' then 3 else 0 end, estado = trim(t.estado)    \n" +
                        "	 from json_to_recordset(v_data)  \n" +
                        "	 as t (iddocumento integer, estado character varying(255), es_con_migracion boolean )     \n" +
                        "	 where v.iddocumento = t.iddocumento;    \n" +
                        "\n" +
                        "	 --resultado de confirmacion.  \n" +
                        "	 select json_agg(json_build_object('iddocumento', iddocumento, 'es_con_migracion', es_con_migracion))::text    \n" +
                        "	 from json_to_recordset(v_data)  \n" +
                        "	 as t (iddocumento integer, es_con_migracion boolean)    \n" +
                        "	 	into resultado;  \n" +
                        " end;  \n" +
                        " \n" +
                        "$BODY$\n" +
                        "	LANGUAGE 'plpgsql' VOLATILE ";
                

                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_integracion_detalledocumento_importar
                NombreSP = "fn_integracion_detalledocumento_importar";
                Query = "CREATE OR REPLACE FUNCTION public.fn_integracion_detalledocumento_importar( \n" +
                        "	OUT resultado text, \n" +
                        "	p_datos text, \n" +
                        "	p_cod_emp text) \n" +
                        "   RETURNS text \n" +
                        "  AS $BODY$ \n" +
                        "  \n" +
                        "   ---fecha: 01/04/2025 \n" +
                        " DECLARE  \n" +
                        " v_data json;  \n" +
                        " BEGIN  \n" +
                        "        \n" +
                        "    v_data:= p_datos::json;  \n" +
                        " 	p_datos = null;  \n" +
                        " \n" +
                        "	--nuevos  \n" +
                        "	 INSERT INTO com_detalledocumento (  \n" +
                        "	 		iddetalledocumento,iddocumento,ccodalma,ccodprod,ccodmed,ccodlote,nuniori,nvvori,npvori,nvalor,nigvtot,ntotori,npigv,nconvnum, \n" +
                        "			nconvden,clibprod,ccodcos,ccodcos2,ccodpresu,cctaprod,npordscu,ndsctos,ccodisc,nporisc,nisc,tipo_isc,mdscl ) \n" +
                        "	SELECT  t.iddetalledocumento, \n" +
                        "			t.iddocumento, \n" +
                        "			trim(t.ccodalma) as ccodalma, \n" +
                        "			trim(t.ccodprod) as ccodprod, \n" +
                        "           trim(t.ccodmed) as ccodmed, \n" +
                        "			trim(t.ccodlote) as ccodlote, \n" +
                        "			t.nuniori, \n" +
                        "			t.nvvori, \n" +
                        "			t.npvori, \n" +
                        "			t.nvalor, \n" +
                        "			t.nigvtot, \n" +
                        "			t.ntotori, \n" +
                        "			t.npigv, \n" +
                        "			t.nconvnum, \n" +
                        "			t.nconvden, \n" +
                        "			trim(t.clibprod) as clibprod, \n" +
                        "			trim(t.ccodcos) as ccodcos, \n" +
                        "			trim(t.ccodcos2) as ccodcos2, \n" +
                        "			trim(t.ccodpresu) as ccodpresu, \n" +
                        "			t.cctaprod, \n" +
                        "			t.npordscu, \n" +
                        "			t.ndsctos, \n" +
                        "			trim(t.ccodisc) as ccodisc, \n" +
                        "			t.nporisc, \n" +
                        "			t.nisc, \n" +
                        "			t.tipo_isc, \n" +
                        "			trim(t.mdscl) as mdscl \n" +
                        "		  \n" +
                        "	 FROM json_to_recordset(v_data) \n" +
                        "	 as t( iddetalledocumento integer, \n" +
                        "			iddocumento integer, \n" +
                        "			ccodalma character(3), \n" +
                        "			ccodprod character(20), \n" +
                        "			ccodmed character(15), \n" +
                        "			ccodlote character(20), \n" +
                        "			nuniori numeric(20,10), \n" +
                        "			nvvori numeric(20,10), \n" +
                        "			npvori numeric(20,10), \n" +
                        "			nvalor numeric(15,2), \n" +
                        "			nigvtot numeric(15,2), \n" +
                        "			ntotori numeric(15,2), \n" +
                        "			npigv numeric(5,2), \n" +
                        "			nconvnum numeric(9,2), \n" +
                        "			nconvden numeric(9,2), \n" +
                        "			clibprod character(1), \n" +
                        "			ccodcos character(9), \n" +
                        "			ccodcos2 character(9), \n" +
                        "			ccodpresu character(10), \n" +
                        "			cctaprod character(20), \n" +
                        "			npordscu numeric(15,2), \n" +
                        "			ndsctos numeric(15,2), \n" +
                        "			ccodisc character(5), \n" +
                        "			nporisc numeric(5,2), \n" +
                        "			nisc numeric(15,2), \n" +
                        "			tipo_isc numeric(1,0), \n" +
                        "			mdscl text \n" +
                        "	 ) \n" +
                        "	 inner join com_documento doc on t.iddocumento = doc.iddocumento  -- KMM - 25-04-2025 - LSQL-51 \n" +
                        "	 left join com_detalledocumento v on t.iddetalledocumento = v.iddetalledocumento  \n" +
                        "	 where v.iddetalledocumento is null;   \n" +
                        "	  \n" +
                        "	 /* \n" +
                        "	 update com_detalledocumento v     \n" +
                        "	 set es_con_migracion = 0   \n" +
                        "	 from json_to_recordset(v_data)  \n" +
                        "	 as t (iddocumento integer, es_con_migracion boolean )      \n" +
                        "	 where v.iddocumento = t.iddocumento;   \n" +
                        "	*/ \n" +
                        "	 --resultado de confirmacion.   \n" +
                        "	 select json_agg(json_build_object('iddetalledocumento', iddetalledocumento, 'es_con_migracion', es_con_migracion))::text   \n" +
                        "	 from json_to_recordset(v_data)   \n" +
                        "	 	as t (iddetalledocumento integer, es_con_migracion boolean)   \n" +
                        "	 	into resultado;   \n" +
                        " end;   \n" +
                        "  \n" +
                        "$BODY$ \n" +
                        "  LANGUAGE plpgsql VOLATILE \n" +
                        "  COST 100;";


                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_productos_envio_comercial
                NombreSP = "fn_productos_envio_comercial";
                Query = "CREATE OR REPLACE FUNCTION public.fn_productos_envio_comercial(\n" +
                    "	OUT resultado text,\n" +
                    "	p_ruc_emisor character,\n" +
                    "	p_empresa character)\n" +
                    "   RETURNS text\n" +
                    "    \n" +
                    "   AS $BODY$\n" +
                    "   \n" +
                    "   \n" +
                    "   BEGIN  \n" +
                    "   select json_agg(to_json(t))::text  \n" +
                    "   from(  \n" +
                    "SELECT com_producto.idproducto,   \n" +
                    "trim(coalesce(com_producto.ccodrucemisor, '')) as ccodrucemisor,   \n" +
                    "trim(coalesce(com_producto.ccod_empresa, '')) as ccod_empresa,   \n" +
                    "trim(coalesce(ccodfamg, '')) as ccodfamg,trim(coalesce(cdesfamg, '')) as cdesfamg, 	  \n" +
                    "trim(coalesce(ccodfamf, '')) as ccodfamf,trim(coalesce(cdesfamf, '')) as cdesfamf, 	  \n" +
                    "trim(coalesce(ccodprod, '')) as ccodprod,trim(coalesce(cdesprod, '')) as cdesprod, 	  \n" +
                    "trim(coalesce(cdesprodgen, '')) as cdesprodgen,trim(coalesce(ccodtes, '')) as ccodtes, 	  \n" +
                    "trim(coalesce(ccodmar, '')) as ccodmar,trim(coalesce(cdesmar, '')) as cdesmar, 	  \n" +
                    "trim(coalesce(ccodmed, '')) as ccodmed,trim(coalesce(ccodums, '')) as ccodums,	  \n" +
                    "trim(coalesce(ccodcatbs, '')) as ccodcatbs,trim(coalesce(cdescatbs, '')) as cdescatbs,  \n" +
                    "coalesce(ntipoprod, '') as ntipoprod,coalesce(nunidsec, '') as nunidsec,		  \n" +
                    "coalesce(npesoprod, 0) as npesoprod,trim(coalesce(ccodbarras, '')) as ccodbarras,	  \n" +
                    "coalesce(ninprod, '') as ninprod,coalesce(nanuprod,'') as nanuprod,		  \n" +
                    "coalesce(nlote, '') as nlote,coalesce(nseruni, '') as nseruni,coalesce(nicbper, '') as nicbper,  \n" +
                    "coalesce(nprodanti, '') as nprodanti,coalesce(ngasrela, '') as ngasrela,coalesce(nprodsafniif, '') as nprodsafniif,  \n" +
                    "trim(coalesce(cdescatbs, '')) as cdescatbs,trim(coalesce(ccomcue, '')) as ccomcue,trim(coalesce(cdescatbs, '')) as cdescatbs,  \n" +
                    "trim(coalesce(cvencue, '')) as cvencue,trim(coalesce(cdebicue, '')) as cdebicue,trim(coalesce(ccredcue, '')) as ccredcue,  \n" +
                    "trim(coalesce(cdescatbs, '')) as cdescatbs,trim(coalesce(cdebicuei, '')) as cdebicuei,		  \n" +
                    "trim(coalesce(ccodcos, '')) as ccodcos,trim(coalesce(ccodcos2, '')) as ccodcos2,trim(coalesce(ccodpresu, '')) as ccodpresu,  \n" +
                    "trim(coalesce(ccomprod, '')) as ccomprod,trim(coalesce(cvenprod, '')) as cvenprod,trim(coalesce(ccodisc, '')) as ccodisc,	  \n" +
                    "trim(coalesce(cmoneda, '')) as cmoneda,coalesce(npreunit1, 00000.00) as npreunit1,coalesce(npreunit2, 00000.00) as npreunit2,  \n" +
                    "coalesce(npreunit3, 00000.00) as npreunit3,coalesce(npreunit4, 00000.00) as npreunit4,coalesce(npreunit5, 00000.00) as npreunit5,  \n" +
                    "coalesce(npreunit6, 00000.00) as npreunit6,coalesce(npreunit7, 00000.00) as npreunit7,coalesce(npreunit8, 00000.00) as npreunit8,  \n" +
                    "coalesce(npreunit9, 00000.00) as npreunit9,coalesce(npreunit10, 00000.00) as npreunit10,coalesce(npreunit11, 00000.00) as npreunit11,  \n" +
                    "coalesce(npreunit12, 00000.00) as npreunit12,coalesce(npreunit13, 00000.00) as npreunit13,coalesce(npreunit14, 00000.00) as npreunit14,  \n" +
                    "coalesce(npreunit15, 00000.00) as npreunit15,coalesce(nstockmin, 00000.00) as nstockmin,coalesce(nstockmax, 00000.00) as nstockmax,coalesce(nrango1, 00000.00) as nrango1,  \n" +
                    "coalesce(nrango2, 0) as nrango2,coalesce(nresp, 0) as nresp,	  \n" +
                    "trim(coalesce(ccodpps, '')) as ccodpps,	  \n" +
                    "trim(coalesce(ccodpds, '')) as ccodpds,  \n" +
                    "coalesce(nagemonmin, 0) as nagemonmin,	  \n" +
                    "trim(coalesce(ccodlabora, '')) as ccodlabora,  \n" +
                    "trim(coalesce(cdeslabora, '')) as cdeslabora,	  \n" +
                    "trim(coalesce(cdeslabora, '')) as cdeslabora,	  \n" +
                    "trim(coalesce(estado, '')) as estado,  \n" +
                    "es_con_migracion,   \n" +
                    "ccodcos3	FROM com_producto   \n" +
                    "-----inner join configuracion2 ON com_producto.CCOD_EMPRESA = configuracion2.CCOD_EMPRESA ----and com_producto.CPER = configuracion2.CPER    \n" +
                    " join CG_EMPRESA emp on com_producto.ccodrucemisor = emp.ccodrucemisor and com_producto.ccod_empresa = emp.CCOD_EMPRESA    \n" +
                    " join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1::bit    \n" +
                    " where com_producto.ccodrucemisor = p_ruc_emisor::character(15)    \n" +
                    " and com_producto.ccod_empresa = p_empresa::character(3)    \n" +
                    " and es_con_migracion in (0, 3)   )     \n" +
                    " as t    \n" +
                    " into resultado;    \n" +
                    " end;     \n" +
                    " \n" +
                    "$BODY$\n" +
                    "LANGUAGE 'plpgsql' VOLATILE ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_productos_envio_resultado
                NombreSP = "fn_productos_envio_resultado";
                Query = "CREATE OR REPLACE FUNCTION public.fn_productos_envio_resultado(\n" +
                        "	p_datos text)\n" +
                        "    RETURNS void\n" +
                        "AS $BODY$\n" +
                        " \n" +
                        "DECLARE  \n" +
                        "v_data json;  \n" +
                        "  BEGIN  \n" +
                        "   \n" +
                        "  v_data:= p_datos::json;    \n" +
                        "  UPDATE com_producto t  \n" +
                        "  SET es_con_migracion =  r.resultado_migracion,\n" +
                        "  obserror = r.obserror    \n" +
                        "  from json_to_recordset(v_data) as r (id integer, obserror text, es_con_migracion integer, resultado_migracion integer)    \n" +
                        "  where t.idproducto = r.id;    \n" +
                        "    \n" +
                        " END;    \n" +
                        "$BODY$\n" +
                        "LANGUAGE 'plpgsql' VOLATILE ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_documento_envio_resultado
                NombreSP = "fn_documento_envio_resultado";
                Query = "CREATE OR REPLACE FUNCTION public.fn_documento_envio_resultado(\n" +
                        "	p_datos text)\n" +
                        "    RETURNS void\n" +
                        "AS $BODY$\n" +
                        "DECLARE  \n" +
                        "v_data json;  \n" +
                        "        BEGIN  \n" +
                        "  v_data:= p_datos::json;  \n" +
                        "  UPDATE com_documento t \n" +
                        "  SET es_con_migracion =  coalesce(r.resultado_migracion,0),\n" +
                        "   obserror = r.obserror   \n" +
                        "   from json_to_recordset(v_data) as r (iddocumento integer, obserror text, es_con_migracion integer, resultado_migracion integer)  \n" +
                        "   where t.iddocumento = r.iddocumento and coalesce(t.es_con_migracion,0) = coalesce(r.es_con_migracion,0);   \n" +
                        "   \n" +
                        " END;   \n" +
                        " $BODY$\n" +
                        " LANGUAGE 'plpgsql';";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_documento_envio_comercial
                NombreSP = "fn_documento_envio_comercial";
                Query = "CREATE OR REPLACE FUNCTION public.fn_documento_envio_comercial(\n" +
                        "	OUT resultado text,\n" +
                        "	p_ruc_emisor character,\n" +
                        "	p_empresa character)\n" +
                        "   RETURNS text\n" +
                        "AS $BODY$\n" +
                        "BEGIN  \n" +
                        "	\n" +
                        "Select json_agg(to_json(t))::text  \n" +
                        "   From(  \n" +
                        "		SELECT  com_documento.iddocumento, \n" +
                        "		trim(configuracion2.ccod_empresa) as ccod_empresa, \n" +
                        "		com_documento.cper, \n" +
                        "		com_documento.cmes, \n" +
                        "		com_documento.ccodmodulo, \n" +
                        "		configuracion2.ccodmov, \n" +
                        "		com_documento.ccoddoc, \n" +
                        "		lpad(trim(com_documento.cserie),20,'0')::character(20) as cserie, \n" +
                        "		lpad(trim(com_documento.cnumero),20,'0')::character(20) as cnumero, \n" +
                        "		com_documento.ccodenti, \n" +
                        "		com_documento.cdesenti, \n" +
                        "		com_documento.ccodtipent, \n" +
                        "		trim(com_documento.ccodruc) as ccodruc, \n" +
                        "		trim(com_documento.crazsoc) as crazsoc, \n" +
                        "		trim(com_documento.cdirecc) as cdirecc, \n" +
                        "		trim(com_documento.ccodubi) as ccodubi, \n" +
                        "		trim(com_documento.ccodcontac) as ccodcontac,\n" +
                        "		trim(com_documento.cdescontacto) as cdescontacto, \n" +
                        "		com_documento.ffecha, \n" +
                        "		com_documento.ffechaven, \n" +
                        "		com_documento.ffechaalm, \n" +
                        "		com_documento.ccodpag, \n" +
                        "		com_documento.cmoneda, \n" +
                        "		com_documento.ntcigv, \n" +
                        "		com_documento.cguiaser, \n" +
                        "		com_documento.cguianum, \n" +
                        "		com_documento.mdsc, \n" +
                        "		com_documento.ccodvend, \n" +
                        "		com_documento.ccodclas, ccodocon, cnumordc, crefdoc, \n" +
                        "		com_documento.freffec, crefser, crefnum, ccat09, cmotinc, nresp, ccodpds, nporre, ffecre, cnumdere, ccodpps, nporre2, \n" +
                        "		nperdenre, nbase1, nigv1, nbase2, nigv2, nbase3, nigv3, nimpicbper, nina, nexo, nisc, nivabase, nivaimp, nimpant, ntot, \n" +
                        "		trim(com_documento.estado) as estado, \n" +
                        "		es_con_migracion,\n" +
                        "		configuracion2.ent_anula as ccodrucanula, 0 as nflgexisteanular, 	\n" +
                        "	    configuracion2.prodanula as prodanula,\n" +
                        "		trim(com_documento.ccond)  as ccond, \n" +
                        "		trim(com_documento.ccuecan) as ccuecan,\n" +
                        "		trim(com_documento.cdoccan) as cdoccan, \n" +
                        "		trim(com_documento.csercan) as csercan, \n" +
                        "		trim(com_documento.cnumcan) as cnumcan, \n" +
                        "		trim(configuracion2.ccodoripago) as ccodorican,\n" +
                        "		trim(configuracion2.clibropago) as ccodsucan,\n" +
                        "		trim(configuracion2.ccodflupago) as ccodflucan,\n" +
                        "		com_documento.ccodpago	\n" +
                        "FROM com_documento	\n" +
                        "inner join configuracion2 ON com_documento.ccodrucemisor=configuracion2.crucemp and com_documento.CPER = configuracion2.CPER    \n" +
                        "	and  configuracion2.codtipdocu=com_documento.ccoddoc and lpad(trim(com_documento.cserie),20,'0')::character(20)=trim(configuracion2.cserie)\n" +
                        " join CG_EMPRESA emp on com_documento.ccodrucemisor = emp.ccodrucemisor and com_documento.ccod_empresa = emp.CCOD_EMPRESA  \n" +
                        " join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1::bit  \n" +
                        " where com_documento.ccodrucemisor = p_ruc_emisor::character(15)\n" +
                        " and com_documento.ccod_empresa = p_empresa::character(3)  \n" +
                        " and es_con_migracion in (0, 3)   )   \n" +
                        " as t  \n" +
                        " into resultado;      \n" +
                        "end;\n" +
                        "$BODY$ \n" +
                        "    LANGUAGE 'plpgsql';";

                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_detalledocumento_envio_comercial
                NombreSP = "fn_detalledocumento_envio_comercial";
                Query = "CREATE OR REPLACE FUNCTION public.fn_detalledocumento_envio_comercial(\n" +
                        "	OUT resultado text,\n" +
                        "	p_ruc_emisor character,\n" +
                        "	p_empresa character)\n" +
                        "    RETURNS text\n" +
                        "AS $BODY$\n" +
                        "BEGIN  \n" +
                        "Select json_agg(to_json(t))::text  \n" +
                        "	From(	\n" +
                        " SELECT  com_detalledocumento.iddetalledocumento, \n" +
                        "	com_detalledocumento.ccodalma, \n" +
                        "	com_detalledocumento.ccodprod, \n" +
                        "	com_detalledocumento.ccodmed, \n" +
                        "	com_detalledocumento.ccodlote, \n" +
                        "	com_detalledocumento.nuniori, \n" +
                        "	com_detalledocumento.nvvori,\n" +
                        "	com_detalledocumento.npvori, \n" +
                        "	com_detalledocumento.nvalor, \n" +
                        "   com_detalledocumento.nigvtot, \n" +
                        "	com_detalledocumento.ntotori, \n" +
                        "	com_detalledocumento.npigv, \n" +
                        "	com_detalledocumento.ccodcos, \n" +
                        "	com_detalledocumento.ccodcos2, \n" +
                        "	com_detalledocumento.ccodpresu, \n" +
                        "	com_detalledocumento.cctaprod, \n" +
                        "	com_detalledocumento.npordscu, \n" +
                        "	com_detalledocumento.ndsctos, \n" +
                        "	com_detalledocumento.ccodisc, \n" +
                        "	com_detalledocumento.nporisc, \n" +
                        "	com_detalledocumento.nisc, \n" +
                        "	com_detalledocumento.tipo_isc, \n" +
                        "	com_detalledocumento.mdscl, \n" +
                        "	com_detalledocumento.iddocumento,\n" +
                        "	com_detalledocumento.ffecfablote, com_detalledocumento.ffecvenlote \n" +
                        "	FROM com_detalledocumento inner join com_documento on\n" +
                        "	com_detalledocumento.iddocumento=com_documento.iddocumento\n" +
                        "	inner join configuracion2 ON com_documento.ccodrucemisor=configuracion2.crucemp and com_documento.CPER = configuracion2.CPER    \n" +
                        "	and configuracion2.tipo=com_documento.ccodmodulo AND configuracion2.codtipdocu=com_documento.ccoddoc\n" +
                        "	and lpad(trim(com_documento.cserie),20,'0')::character(20)=trim(configuracion2.cserie)\n" +
                        " join CG_EMPRESA emp on com_documento.ccodrucemisor = emp.ccodrucemisor and com_documento.ccod_empresa = emp.CCOD_EMPRESA  \n" +
                        " join CG_EMPEMISOR empemi on emp.ccodrucemisor = empemi.ccodrucemisor and flgactivo = 1::bit  \n" +
                        " where com_documento.ccodrucemisor = p_ruc_emisor::character(15)  \n" +
                        " and com_documento.ccod_empresa = p_empresa::character(3)  \n" +
                        " and com_documento.es_con_migracion in (0, 3)   )   \n" +
                        " as t  \n" +
                        " into resultado;      \n" +
                        " end;   \n" +
                        "$BODY$\n" +
                        "LANGUAGE 'plpgsql'";

                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_detalledocumento_envio_resultado
                NombreSP = "fn_detalledocumento_envio_resultado";
                Query = "CREATE OR REPLACE FUNCTION public.fn_detalledocumento_envio_resultado(\n" +
                        "	p_datos text)\n" +
                        "    RETURNS void\n" +
                        "AS $BODY$\n" +
                        "DECLARE  \n" +
                        "v_data json;  \n" +
                        "        BEGIN  \n" +
                        "  v_data:= p_datos::json;  \n" +
                        "  ---UPDATE com_documento t \n" +
                        "  ---SET es_con_migracion =  coalesce(r.resultado_migracion,0),\n" +
                        "   ----obserror = r.obserror   \n" +
                        "   ---from json_to_recordset(v_data) as r (iddocumento integer, obserror text, es_con_migracion integer, resultado_migracion integer)  \n" +
                        " -----where t.iddocumento = r.iddocumento and coalesce(t.es_con_migracion,0) = coalesce(r.es_con_migracion,0);  \n" +
                        " END;   \n" +
                        "$BODY$\n" +
                        "    LANGUAGE 'plpgsql' ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_documento_envio_resultadofinal
                NombreSP = "fn_documento_envio_resultadofinal";
                Query = "CREATE OR REPLACE FUNCTION public.fn_documento_envio_resultadofinal(\n" +
                        "	p_datos text)\n" +
                        "    RETURNS void\n" +
                        "AS $BODY$\n" +
                        "DECLARE  \n" +
                        "v_data json;  \n" +
                        "        BEGIN  \n" +
                        "  v_data:= p_datos::json;  \n" +
                        "  UPDATE com_documento \n" +
                        "  SET es_con_migracion =  r.resultado_migracion,\n" +
                        "    	obserror = r.obserror,    \n" +
                        "		obserrorcan = r.obserrorcan,  \n" +
                        "	  	resultado_migracion = r.resultado_migracion,\n" +
                        "		resultadocan_migracion=r.resultadocan_migracion  \n" +
                        "   from json_to_recordset(v_data) as r (id integer, \n" +
                        "	  										obserror text,\n" +
                        "	  										es_con_migracion integer, \n" +
                        "	  										resultado_migracion integer,\n" +
                        "	  										obserrorcan text, \n" +
                        "	  										resultadocan_migracion integer)  \n" +
                        " where com_documento.iddocumento = r.id;\n" +
                        " END;   \n" +
                        " \n" +
                        "$BODY$\n" +
                        "LANGUAGE 'plpgsql';";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_productos_envio_resultado
                NombreSP = "fn_productos_envio_resultado";
                Query = "CREATE OR REPLACE FUNCTION public.fn_productos_envio_resultado(\n" +
                        "	p_datos text)\n" +
                        "    RETURNS void\n" +
                        "AS $BODY$\n" +
                        " \n" +
                        "DECLARE  \n" +
                        "v_data json;  \n" +
                        "  BEGIN  \n" +
                        "   \n" +
                        "  v_data:= p_datos::json;    \n" +
                        "  UPDATE com_producto t  \n" +
                        "  SET es_con_migracion =  r.resultado_migracion,\n" +
                        "  obserror = r.obserror    \n" +
                        "  from json_to_recordset(v_data) as r (id integer, obserror text, es_con_migracion integer, resultado_migracion integer)    \n" +
                        "  where t.idproducto = r.id;    \n" +
                        "    \n" +
                        " END;    \n" +
                        "$BODY$\n" +
                        "LANGUAGE 'plpgsql' VOLATILE ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
                #region fn_integracion_cobranza_importar
                NombreSP = "fn_integracion_cobranza_importar";
                Query = "CREATE OR REPLACE FUNCTION public.fn_integracion_cobranza_importar( \n" +
                        " \n" +
                        " OUT resultado text, \n" +
                        " p_datos text, \n" +
                        " p_cod_emp text) \n" +
                        " RETURNS text  \n" +
                        " AS $BODY$  \n" +
                        " \n" +
                        "-----Fecha: 16/04/2025 \n" +
                        " DECLARE  \n" +
                        " v_data json;  \n" +
                        " BEGIN \n" +
                        " v_data:= p_datos::json; \n" +
                        " p_datos = null; \n" +
                        " \n" +
                        " INSERT INTO fin_cobranzapago( \n" +
       " idcobranzas, ccodrucemisor, ccod_empresa, cper, cmes, ntipocobpag, ffechacan, \n" +
       " cdoccan, csercan, cnumcan, ccuecan, cmoncan, \n" +
       " nimporcan, ntipcam, ccodpago, \n" +
       " ccoddoc, cserie, cnumero, ffechadoc, ffechaven, ccodenti, ccodruc, crazsoc, nimportes, \n" +
       " nimported, ccodcue, cglosa, ccodcos, ccodcos2, nporre, nimpperc, nperdenre, \n" +
       " cserre, cnumre, ffecre, created_at, updated_at, estado, en_ambiente_de, \n" +
       " es_con_migracion, ccodcos3,es_anticipo_automatico) \n" +
    " SELECT \n" +
    " t.id, t.numero_documento_emisor, p_cod_emp, extract(year from to_date(t.ffechadoccobra, 'DD/MM/YYYY'))::text,    \n" +
    " lpad(extract(month from to_date(t.ffechadoccobra, 'DD/MM/YYYY'))::text, 2, '0'), 1,   \n" +
    " case when coalesce(t.ffechadoccobra, '')= '' then null else to_date(t.ffechadoccobra, 'DD/MM/YYYY') end, --1 \n" +
    " trim(coalesce(t.cdoccan, '')) as cdoccan,    \n" +
           " trim(coalesce(t.csercan, '')) as csercan,    \n" +
    " trim(coalesce(t.cnumcan, '')) as cnumcan,    \n" +
    " trim(coalesce(t.ccuecan, '')) as ccuecan,    \n" +
    " trim(coalesce(t.cmoncan, '')) as cmoncan, --2 \n" +
    " case when trim(coalesce(t.nimporcan, '')) = '' then 0 else t.nimporcan::numeric end as nimporcan,    \n" +
    " case when trim(coalesce(t.ntipcam, '')) = '' then 0 else t.ntipcam::numeric end as ntipcam,    \n" +
    " coalesce(trim(t.ccodpago), '') as ccodpago, --3 \n" +
    " coalesce(trim(t.ccoddoc), '') as ccoddoc,    \n" +
    " coalesce(trim(t.cserie), '') as cserie,    \n" +
    " coalesce(trim(t.cnumero), '') as cnumero,    \n" +
    " case when coalesce(t.ffechadoc, '')= '' then null else to_date(t.ffechadoc, 'DD/MM/YYYY') end as ffechadoc,    \n" +
    " case when coalesce(t.ffechaven, '')= '' then null else to_date(t.ffechaven, 'DD/MM/YYYY') end as ffechaven,    \n" +
    " '' as ccodenti , trim(coalesce(t.ccodruc, '')) as ccodruc, trim(coalesce(t.crazsoc, '')),  \n" +
    " case when trim(coalesce(t.nimportes, '')) = '' then 0 else t.nimportes::numeric end as nimportes, --4 \n" +
    " case when trim(coalesce(t.nimported, '')) = '' then 0 else t.nimported::numeric end as nimported,    \n" +
    " trim(coalesce(t.ccodcue, '')) as ccodcue,    \n" +
    " trim(coalesce(t.cglosa, '')) as cglosa,     \n" +
    " trim(coalesce(t.ccodcos, '')) as ccodcos,    \n" +
    " trim(coalesce(t.ccodcos2, '')) as ccodcos2,    \n" +
    " case when trim(coalesce(t.nporre, '')) = '' then 0 else t.nporre::numeric end as nporre,    \n" +
    " case when trim(coalesce(t.nimpperc, '')) = '' then 0 else t.nimpperc::numeric end as nimpperc,    \n" +
    " case when trim(coalesce(t.nperdenre, '')) = '' then 0 else t.nperdenre::numeric end as nperdenre, --5 \n" +
    " coalesce(trim(t.cserre), '') as cserre, coalesce(trim(t.cnumre), '') as cnumre,    \n" +
    " case when coalesce(t.ffecre, '')= '' then null else to_date(t.ffecre, 'DD/MM/YYYY') end as ffecre,    \n" +
    " t.created_at::date, t.updated_at::date,    \n" +
    " coalesce(trim(t.estado), ''),    \n" +
    " coalesce(trim(t.en_ambiente_de), ''),  \n" +
    " case when  trim(t.estado) = 'CANCELADO' then 0 else 3 end, '', \n" +
    " coalesce(cast(t.es_anticipo_automatico as integer) ,0) as es_anticipo_automatico \n" +
    " FROM json_to_recordset(v_data)  \n" +
    " as t( \n" +
    " id integer, \n" +
    " numero_documento_emisor character varying(20),    \n" +
    " ffechadoccobra character varying(20),    \n" +
    " cdoccan character varying(5),    \n" +
    " csercan character varying(50),    \n" +
    " cnumcan character varying(50),    \n" +
    " ccuecan character varying(50),    \n" +
    " cmoncan character varying(50),    \n" +
    " nimporcan character varying(50),    \n" +
    " ntipcam character varying(50),    \n" +
    " ccodpago character varying(50),    \n" +
    " ccoddoc character varying(20),    \n" +
    " cserie character varying(50),    \n" +
    " cnumero character varying(50),    \n" +
    " ffechadoc character varying(50),    \n" +
    " ffechaven character varying(50),  \n" +
    " ccodenti character varying(50),  \n" +
    " ccodruc character varying(50),  \n" +
    " crazsoc text, \n" +
    " nimportes character varying(50),    \n" +
    "  nimported character varying(50),    \n" +
    "  ccodcue character varying(50),    \n" +
    "  cglosa text, \n" +
    "  ccodcos character varying(50),    \n" +
    "  ccodcos2 character varying(50),    \n" +
    "  nporre character varying(50),    \n" +
    "  nimpperc character varying(50),    \n" +
    "  nperdenre character varying(50),    \n" +
    "  cserre character varying(50),    \n" +
    " cnumre character varying(50),    \n" +
    " ffecre character varying(50),    \n" +
    "  created_at timestamp without time zone,    \n" +
    "   updated_at timestamp without time zone,    \n" +
    "   estado character varying(50),    \n" +
    "     en_ambiente_de character varying(255),    \n" +
    "         es_con_migracion boolean, \n" +
    "         es_anticipo_automatico boolean   )\n" +
    "     left join fin_cobranzapago v on t.id = v.idcobranzas \n" +
    "     where v.idcobranzas is null; \n" +
    "                 --Modificados \n" +
    "     update fin_cobranzapago v \n" +
    "     set es_con_migracion =case when trim(t.estado) = 'CANCELADO' then 0 else 3 end,    \n" +
    "     estado = trim(t.estado) \n" +
    "     from json_to_recordset(v_data) \n" +
    " as t (id integer, estado character varying(255), es_con_migracion boolean )        \n" +
    " where v.idcobranzas = t.id; \n" +
    "                 --resultado de confirmacion.    \n" +
    " select json_agg(json_build_object('idcobranzas', id, 'es_con_migracion', es_con_migracion))::text \n" +
    " from json_to_recordset(v_data) \n" +
    " as t (id integer, es_con_migracion boolean) \n" +
    " into resultado; \n" +
    "   end;    \n" +
    " \n" +
    " $BODY$  \n" +
    " LANGUAGE 'plpgsql'; ";
                respuesta = obj.crear_funcion(NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion

                #region cg_moduloconfigura
                NombreSP = "cg_moduloconfigura";
                Query = "delete from  cg_moduloconfigura;";
                respuesta = obj.ejecutar_comando("",NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion



                #region cg_moduloconfigura
                NombreSP = "cg_moduloconfigura";
                Query = "INSERT INTO cg_moduloconfigura(id,cmodulo) values(1,'Modulo Contable');";
                respuesta = obj.ejecutar_comando("",NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion

                #region cg_moduloconfigura2
                NombreSP = "cg_moduloconfigura";
                Query = "INSERT INTO cg_moduloconfigura(id,cmodulo) values(2,'Modulo Comercial');";
                respuesta = obj.ejecutar_comando("",NombreSP, Query);
                this.Barraprogreso(respuesta);
                #endregion
            }
        }
        /*********************************************************************************************************************/
        private void Timer1_Tick(object sender, EventArgs e)
        {
            pBarra.Value = progreso;
            progreso += 1;
            this.label1.Text = (progreso-1).ToString() + "%";
            if (progreso > pBarra.Maximum)
            {
                Timer1.Stop();
                progreso = 0;
                this.Refresh();
                txtMensaje.Text = "Proceso terminado.";
                MessageBox.Show("Proceso Terminado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                this.Hide();

            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMensaje_TextChanged(object sender, EventArgs e)
        {

        }
        /*********************************************************************************************************************/
    }
}
