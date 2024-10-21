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
    class Documentos_comercial_Inconsistencias
    {
        /*******************************************************************************************************/
        public DataTable listarsql(Clase.Comercial_documentoPropiedades Objet)
        {

            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT a.iddocumento AS ID,a.ccodmodulo AS MODULO,b.ccodmov AS COD_MOVIMIENTO,a.ccoddoc AS COD_DOCUMENTO,b.cserie AS SERIE"+
                ", a.cnumero AS NUMERO,b.Entidad AS COD_ENTIEDAD,a.cdesenti AS NOMBRE_ENTIDAD,a.ccodtipent AS TIPO_DOC_ENTIDAD,a.ccodruc AS RUC"+
                ",a.crazsoc AS RAZON_SOCIAL,isnull(a.cdirecc, '') AS DIREC_CLIENTE, isnull(a.ccodubi, '') AS UBIGEO, isnull(a.ccodcontac, '') AS CONTACTO"+
                ", a.cdescontacto AS NOMB_CONTACTO,"+
                " convert(varchar, a.ffecha, 103) AS FEC_DOCUMENTO,"+
                " convert(varchar, a.ffechaven, 103)  AS FEC_VENCIMIENTO,"+
                " convert(varchar, a.ffechaalm, 103)  AS FEC_ALMACEN, isnull(a.ccodpag, b.ccodpag) AS CONDICION_PAGO, isnull(a.cmoneda, '') AS MONEDA"+
                ", a.ntcigv AS TIPO_CAMBIO,a.cguiaser AS SERIE_GUIA,a.cguianum AS NUMERO_GUIA,a.mdsc AS INF_ADICIONAL_DOC,b.ccodvend AS COD_VENDEDOR,a.ccodclas AS COD_CLASI_BBSS"+
                ",isnull(a.ccodocon, '') AS OTROS_CONCEPTOS, isnull(a.cnumordc, '') AS ORDEN_COMPRA, isnull(a.crefdoc, '') AS TIP_REFERENCIA,"+
                "convert(varchar, a.freffec, 103)  AS FEC_DOC_REFERENCIA, isnull(a.crefser, '') AS SERIE_DOC_REFERENCIA, isnull(a.crefnum, '') AS NUMERO_REFERENCIA," +
                " isnull(a.ccat09, '') AS COD_MOTIVO_NOTACREDITO, isnull(a.cmotinc, '') AS MOTIVO_NOTACREDITO, isnull(a.nresp, 0) AS REG_ESPECIAL, isnull(a.ccodpds, '') AS COD_DETRACCION"+
                ", isnull(a.nporre, 0.00) AS PORCENTAJE_DETRACCION,"+
                " convert(varchar, a.ffecre, 103) AS FEC_DEPOSITO"+
                " , a.cnumdere AS CONTANCIA_DEPOSITO,isnull(a.ccodpps, '') AS COD_PERCEPCION, isnull(a.nporre2, 0.00) AS PORCENTAJE_PERCEPCION"+
                ", isnull(a.nperdenre, 0.00) AS DOCUMENTO_DENTROFUERA, isnull(a.nbase1, 0.00) AS BASE_IMP1, isnull(a.nigv1, 0.00) AS IGV1, isnull(nbase2, 0.00) AS BASE_IMP2,"+
                " isnull(nigv2, 0.00) AS IGV2, isnull(nbase3, 0.00) AS BASE_IMP3, isnull(nigv3, 00) AS IGV3"+
                ",isnull(a.nimpicbper, 0.00) AS IMP_ICBPER, isnull(a.nina, 0.00) AS IMP_INAFECTO, Isnull(a.nexo, 0.00) AS IMP_EXONERADO, Isnull(a.nisc, 0.00) AS IMP_ISC,"+
                " isnull(a.nivabase, 0.00) AS BASE_IVAP,"+
                " isnull(a.nivaimp, 0.00) AS IGV_IVAP, isnull(a.nimpant, 0.00) AS IMP_ANTICIPO"+
                ",isnull(a.ntot, 0.00) AS TOTAL,"+
                " isnull(a.obserror, '') as OBSERVACION " +
                " FROM com_documento a with(nolock) inner join configuracion2 b on  "+ 
                " ltrim(a.ccodmodulo) = ltrim(b.Tipo) and  "+
                " ltrim(a.ccoddoc) = ltrim(b.codtipdocu) and  "+
                " ltrim(a.cserie) = ltrim(b.cserie)  "+
                " where a.es_con_migracion = 2  and a.ccodrucemisor='" + Objet.Ruc.Trim() + "' and a.ccod_empresa='" + Objet.Empresa.Trim() + "'";
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
        public DataTable listarpostgres(Clase.Comercial_documentoPropiedades Objet)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            NpgsqlDataReader carga;
            DataTable grilla = new DataTable();
            try
            {
                string query = "SELECT a.iddocumento AS ID,a.ccodmodulo AS MODULO,b.ccodmov AS COD_MOVIMIENTO,a.ccoddoc AS COD_DOCUMENTO,b.cserie AS SERIE "+
                ", a.cnumero AS NUMERO,b.Entidad AS COD_ENTIEDAD,a.cdesenti AS NOMBRE_ENTIDAD,a.ccodtipent AS TIPO_DOC_ENTIDAD,a.ccodruc AS RUC "+
                ",a.crazsoc AS RAZON_SOCIAL,coalesce(a.cdirecc, '') AS DIREC_CLIENTE, coalesce(a.ccodubi, '') AS UBIGEO, coalesce(a.ccodcontac, '') AS CONTACTO "+
                ", a.cdescontacto AS NOMB_CONTACTO, "+
                "to_char(a.ffecha, 'yyyymmdd') AS FEC_DOCUMENTO, "+
                "to_char(a.ffechaven, 'yyyymmdd')  AS FEC_VENCIMIENTO, "+
                "to_char(a.ffechaalm, 'yyyymmdd')  AS FEC_ALMACEN, coalesce(a.ccodpag, b.ccodpag) AS CONDICION_PAGO, coalesce(a.cmoneda, '') AS MONEDA "+
                " a.ntcigv AS TIPO_CAMBIO,a.cguiaser AS SERIE_GUIA,a.cguianum AS NUMERO_GUIA,a.mdsc AS INF_ADICIONAL_DOC,b.ccodvend AS COD_VENDEDOR,a.ccodclas AS COD_CLASI_BBSS "+
                ",coalesce(a.ccodocon, '') AS OTROS_CONCEPTOS, coalesce(a.cnumordc, '') AS ORDEN_COMPRA, coalesce(a.crefdoc, '') AS TIP_REFERENCIA, " +
                "to_char(a.freffec, 'yyyymmdd') AS FEC_DOC_REFERENCIA, coalesce(a.crefser, '') AS SERIE_DOC_REFERENCIA, coalesce(a.crefnum, '') AS NUMERO_REFERENCIA, "+
                "coalesce(a.ccat09, '') AS COD_MOTIVO_NOTACREDITO, coalesce(a.cmotinc, '') AS MOTIVO_NOTACREDITO, coalesce(a.nresp, 0) AS REG_ESPECIAL, coalesce(a.ccodpds, '') AS COD_DETRACCION "+
                ", coalesce(a.nporre, 0.00) AS PORCENTAJE_DETRACCION, "+
                " to_char(a.ffecre, 'yyyymmdd') AS FEC_DEPOSITO "+
                ", a.cnumdere AS CONTANCIA_DEPOSITO,coalesce(a.ccodpps, '') AS COD_PERCEPCION, coalesce(a.nporre2, 0.00) AS PORCENTAJE_PERCEPCION "+
                ", coalesce(a.nperdenre, 0.00) AS DOCUMENTO_DENTROFUERA, coalesce(a.nbase1, 0.00) AS BASE_IMP1, coalesce(a.nigv1, 0.00) AS IGV1, coalesce(nbase2, 0.00) AS BASE_IMP2, "+
                " coalesce(nigv2, 0.00) AS IGV2, coalesce(nbase3, 0.00) AS BASE_IMP3, coalesce(nigv3, 00) AS IGV3 "+
                ", coalesce(a.nimpicbper, 0.00) AS IMP_ICBPER, coalesce(a.nina, 0.00) AS IMP_INAFECTO, coalesce(a.nexo, 0.00) AS IMP_EXONERADO, coalesce(a.nisc, 0.00) AS IMP_ISC, "+
                " coalesce(a.nivabase, 0.00) AS BASE_IVAP, "+
                " coalesce(a.nivaimp, 0.00) AS IGV_IVAP, coalesce(a.nimpant, 0.00) AS IMP_ANTICIPO "+
                ", coalesce(a.ntot, 0.00) AS TOTAL, "+
                "  coalesce(a.obserror, '') as OBSERVACION  "+
                " FROM com_documento a inner join configuracion2 b on  " +
                " ltrim(a.ccodmodulo) = ltrim(b.Tipo) and  " +
                " ltrim(a.ccoddoc) = ltrim(b.codtipdocu) and  " +
                " ltrim(a.cserie) = ltrim(b.cserie)  "+
                " where es_con_migracion = 2  and ccodrucemisor='" + Objet.Ruc.Trim() + "' and ccod_empresa='" + Objet.Empresa.Trim() + "'";
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

        public DataTable listar_detalle_sql(Clase.Comercial_documentoPropiedades Objet)
        {

            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT ccodalma as COD_ALMACEN,ccodprod AS COD_PROD ,ccodmed as COD_MEDIDA" +
                               ", ccodlote as COD_LOTE,nuniori as CANTIDAD  ,nvvori AS VALOR_VENTA  ,npvori AS PRECIO_VENTA  ,nvalor AS VALOR" +
                               ", nigvtot AS VALOR_IMPUESTO,ntotori AS  TOTAL,npigv as IGV ,ccodcos AS COD_CENTROCOSTO ,ccodcos2 AS COD_CENTROCOSTO2" +
                               ",ccodpresu AS COD_PRESUPUESTO ,cctaprod AS CUENTA_PRODUCTO,npordscu AS PORS_DESCUENTO,ndsctos AS MONTO_DESCUENTO,ccodisc AS COD_ISC" +
                               ",nporisc AS PORCISC,nisc AS MONTO_ISC,tipo_isc AS TIPO_ISC,mdscl AS DESCRIP_ADICIONAL ,convert(varchar, ffecfablote, 103)  AS FECHA_FABLOTE" +
                               ", convert(varchar, ffecvenlote, 103)  AS FECHA_VENLOTE,iddetalledocumento AS IDUNICO" +
                               " FROM com_detalledocumento where iddocumento ='" + Objet.Id.Trim() + "'";
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
        public DataTable listar_detalle_postgres(Clase.Comercial_documentoPropiedades Objet)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            NpgsqlDataReader carga;
            DataTable grilla = new DataTable();
            try
            {

                string query = "SELECT ccodalma as COD_ALMACEN,ccodprod AS COD_PROD ,ccodmed as COD_MEDIDA" +
                               ", ccodlote as COD_LOTE,nuniori as CANTIDAD  ,nvvori AS VALOR_VENTA  ,npvori AS PRECIO_VENTA  ,nvalor AS VALOR" +
                               ", nigvtot AS VALOR_IMPUESTO,ntotori AS  TOTAL,npigv as IGV ,ccodcos AS COD_CENTROCOSTO ,ccodcos2 AS COD_CENTROCOSTO2" +
                               ",ccodpresu AS COD_PRESUPUESTO ,cctaprod AS CUENTA_PRODUCTO,npordscu AS PORS_DESCUENTO,ndsctos AS MONTO_DESCUENTO,ccodisc AS COD_ISC" +
                               ",nporisc AS PORCISC,nisc AS MONTO_ISC,tipo_isc AS TIPO_ISC,mdscl AS DESCRIP_ADICIONAL ," +
                               "to_char(ffecfablote, 'yyyymmdd')    AS FECHA_FABLOTE," +
                               "to_char(ffecvenlote, 'yyyymmdd')    AS FECHA_VENLOTE,iddetalledocumento AS IDUNICO" +
                               " FROM com_detalledocumento where iddocumento ='" + Objet.Id.Trim() + "'";
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







        public string eliminarsql(Clase.Comercial_documentoPropiedades Objet)
        {
            string cadena = "";
            string cadena2 = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string cadena1 = "Delete from com_detalledocumento  where iddocumento=" + Objet.Id + "";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(cadena1, cone);
                cone.Open();
                cadena = commando.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";

                string cadena3 = "Delete from com_documento  where iddocumento=" + Objet.Id + "";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando2 = new SqlCommand(cadena3, cone);
                cone.Open();
                cadena2 = commando2.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";

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
        public string eliminarpos(Clase.Comercial_documentoPropiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string cadena1 = "Delete from com_detalledocumento  where iddocumento=" + Objet.Id + "";
                NpgsqlCommand command3 = new NpgsqlCommand(cadena1, conexion);
                cadena = command3.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";

                string cadena2 = "Delete from com_documento  where iddocumento=" + Objet.Id + "";
                NpgsqlCommand command4 = new NpgsqlCommand(cadena1, conexion);
                cadena = command4.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";

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
        public string Actualizarsql(Clase.Comercial_documentoPropiedades Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query= "UPDATE com_documento SET ccodmov ='" + Objet.Cod_movimiento.Trim() + "'" +
                ", ccoddoc ='" + Objet.Cod_documento.Trim() + "'" +
                ",cserie ='" + Objet.Serie.Trim() + "'" +
                ", cnumero = '" + Objet.Numero.Trim() + "'" +
                ",ccodenti ='" + Objet.Cod_entiedad.Trim() + "'" +
                ",cdesenti ='" + Objet.Nombre_entidad.Trim() + "'" +
                ",ccodtipent ='" + Objet.Tipo_doc_entidad.Trim() + "'" +
                ",ccodruc ='" + Objet.Ruc_rz.Trim() + "'" +
                ",crazsoc ='" + Objet.Razon_social.Trim() + "'" +
                ",cdirecc ='" + Objet.Direc_cliente.Trim() + "'" +
                ",ccodubi ='" + Objet.Ubigeo.Trim() + "'" +
                ",ccodcontac ='" + Objet.Contacto.Trim() + "'" +
                ",cdescontacto ='" + Objet.Nomb_contacto.Trim() + "'" +
                ",ffecha ='" + Objet.Fec_documento.Trim() +"'" +
                ",ffechaven = '" + Objet.Fec_vencimiento.Trim() + "'" +
                ",ffechaalm = '" + Objet.Fec_almacen.Trim()+ "'" +
                ",ccodpag =  '" + Objet.Condicion_pago.Trim() + "'" +
                ",cmoneda =  '" + Objet.Moneda.Trim() + "'" +
                ",ntcigv =  '" + Objet.Tipo_cambio.Trim() + "'" +
                ",cguiaser =  '" + Objet.Serie_guia.Trim() + "'" +
                ",cguianum =  '" + Objet.Numero_guia.Trim() + "'" +
                ",mdsc =  '" + Objet.Inf_adicional_doc.Trim() + "'" +
                ",ccodvend =  '" + Objet.Cod_vendedor.Trim() + "'" +
                ",ccodclas =  '" + Objet.Cod_clasi_bbss.Trim() + "'" +
                ",ccodocon =  '" + Objet.Otros_conceptos.Trim() + "'" +
                ",cnumordc =  '" + Objet.Orden_compra.Trim() + "'" +
                ",crefdoc =  '" + Objet.Tip_referencia.Trim() + "'" +
                ",freffec =  '" + Objet.Fec_doc_referencia.Trim() + "'" +
                ",crefser =  '" + Objet.Serie_doc_referencia.Trim() + "'" +
                ",crefnum =  '" + Objet.Numero_referencia.Trim() + "'" +
                ",ccat09 =  '" + Objet.Cod_motivo_notacredito.Trim() + "'" +
                ",cmotinc =  '" + Objet.Motivo_notacredito.Trim() + "'" +
                ",nresp =  '" + Objet.Reg_especial.Trim() + "'" +
                ",ccodpds =  '" + Objet.Cod_detraccion.Trim() + "'" +
                ",nporre =  '" + Objet.Porcentaje_detraccion.Trim() + "'" +
                ",ffecre =  '" + Objet.Fec_deposito.Trim() + "'" +
                ",cnumdere =  '" + Objet.Contancia_deposito.Trim() + "'" +
                ",ccodpps =  '" + Objet.Cod_percepcion.Trim() + "'" +
                ",nporre2 =  '" + Objet.Porcentaje_percepcion.Trim() + "'" +
                ",nperdenre =  '" + Objet.Documento_dentrofuera.Trim() + "'" +
                ",nbase1 =  '" + Objet.Base_imp1.Trim() + "'" +
                ",nigv1 =  '" + Objet.Igv1.Trim() + "'" +
                ",nbase2 =  '" + Objet.Base_imp2.Trim() + "'" +
                ",nigv2 =  '" + Objet.Igv2.Trim() + "'" +
                ",nbase3 =  '" + Objet.Base_imp3.Trim() + "'" +
                ",nigv3 =  '" + Objet.Igv3.Trim() + "'" +
                ",nimpicbper =  '" + Objet.Imp_icbper.Trim() + "'" +
                ",nina =  '" + Objet.Imp_inafecto.Trim() + "'" +
                ",nexo =  '" + Objet.Imp_exonerado.Trim() + "'" +
                ",nisc =  '" + Objet.Imp_isc.Trim() + "'" +
                ",nivabase =  '" + Objet.Base_ivap.Trim() + "'" +
                ",nivaimp =  '" + Objet.Igv_ivap.Trim() + "'" +
                ",nimpant =  '" + Objet.Imp_anticipo.Trim() + "'" +
                ",ntot =  '" + Objet.Total.Trim() + "'" +
                ", es_con_migracion = 0,obserror = '' WHERE iddocumento ='" + Objet.Id.Trim()+"'";
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
        public string Actualizarpos(Clase.Comercial_documentoPropiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "UPDATE com_documento SET ccodmov ='" + Objet.Cod_movimiento.Trim() + "'" +
               ", ccoddoc ='" + Objet.Cod_documento.Trim() + "'" +
               ",cserie ='" + Objet.Serie.Trim() + "'" +
               ", cnumero = '" + Objet.Numero.Trim() + "'" +
               ",ccodenti ='" + Objet.Cod_entiedad.Trim() + "'" +
               ",cdesenti ='" + Objet.Nombre_entidad.Trim() + "'" +
               ",ccodtipent ='" + Objet.Tipo_doc_entidad.Trim() + "'" +
               ",ccodruc ='" + Objet.Ruc_rz.Trim() + "'" +
               ",crazsoc ='" + Objet.Razon_social.Trim() + "'" +
               ",cdirecc ='" + Objet.Direc_cliente.Trim() + "'" +
               ",ccodubi ='" + Objet.Ubigeo.Trim() + "'" +
               ",ccodcontac ='" + Objet.Contacto.Trim() + "'" +
               ",cdescontacto ='" + Objet.Nomb_contacto.Trim() + "'" +
               ",ffecha ='" + Objet.Fec_documento.Trim() + "'" +
               ",ffechaven = '" + Objet.Fec_vencimiento.Trim() + "'" +
               ",ffechaalm = '" + Objet.Fec_almacen.Trim() + "'" +
               ",ccodpag =  '" + Objet.Condicion_pago.Trim() + "'" +
               ",cmoneda =  '" + Objet.Moneda.Trim() + "'" +
               ",ntcigv =  '" + Objet.Tipo_cambio.Trim() + "'" +
               ",cguiaser =  '" + Objet.Serie_guia.Trim() + "'" +
               ",cguianum =  '" + Objet.Numero_guia.Trim() + "'" +
               ",mdsc =  '" + Objet.Inf_adicional_doc.Trim() + "'" +
               ",ccodvend =  '" + Objet.Cod_vendedor.Trim() + "'" +
               ",ccodclas =  '" + Objet.Cod_clasi_bbss.Trim() + "'" +
               ",ccodocon =  '" + Objet.Otros_conceptos.Trim() + "'" +
               ",cnumordc =  '" + Objet.Orden_compra.Trim() + "'" +
               ",crefdoc =  '" + Objet.Tip_referencia.Trim() + "'" +
               ",freffec =  '" + Objet.Fec_doc_referencia.Trim() + "'" +
               ",crefser =  '" + Objet.Serie_doc_referencia.Trim() + "'" +
               ",crefnum =  '" + Objet.Numero_referencia.Trim() + "'" +
               ",ccat09 =  '" + Objet.Cod_motivo_notacredito.Trim() + "'" +
               ",cmotinc =  '" + Objet.Motivo_notacredito.Trim() + "'" +
               ",nresp =  '" + Objet.Reg_especial.Trim() + "'" +
               ",ccodpds =  '" + Objet.Cod_detraccion.Trim() + "'" +
               ",nporre =  '" + Objet.Porcentaje_detraccion.Trim() + "'" +
               ",ffecre =  '" + Objet.Fec_deposito.Trim() + "'" +
               ",cnumdere =  '" + Objet.Contancia_deposito.Trim() + "'" +
               ",ccodpps =  '" + Objet.Cod_percepcion.Trim() + "'" +
               ",nporre2 =  '" + Objet.Porcentaje_percepcion.Trim() + "'" +
               ",nperdenre =  '" + Objet.Documento_dentrofuera.Trim() + "'" +
               ",nbase1 =  '" + Objet.Base_imp1.Trim() + "'" +
               ",nigv1 =  '" + Objet.Igv1.Trim() + "'" +
               ",nbase2 =  '" + Objet.Base_imp2.Trim() + "'" +
               ",nigv2 =  '" + Objet.Igv2.Trim() + "'" +
               ",nbase3 =  '" + Objet.Base_imp3.Trim() + "'" +
               ",nigv3 =  '" + Objet.Igv3.Trim() + "'" +
               ",nimpicbper =  '" + Objet.Imp_icbper.Trim() + "'" +
               ",nina =  '" + Objet.Imp_inafecto.Trim() + "'" +
               ",nexo =  '" + Objet.Imp_exonerado.Trim() + "'" +
               ",nisc =  '" + Objet.Imp_isc.Trim() + "'" +
               ",nivabase =  '" + Objet.Base_ivap.Trim() + "'" +
               ",nivaimp =  '" + Objet.Igv_ivap.Trim() + "'" +
               ",nimpant =  '" + Objet.Imp_anticipo.Trim() + "'" +
               ",ntot =  '" + Objet.Total.Trim() + "'" +
               ", es_con_migracion = 0,obserror = '' WHERE iddocumento ='" + Objet.Id.Trim() + "'";
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
        public DataTable listascombosql(Clase.Comercial_documentoPropiedades Objet)
        {
            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT a.iddocumento AS ID,a.ccodmodulo AS MODULO,b.ccodmov AS COD_MOVIMIENTO,a.ccoddoc AS COD_DOCUMENTO,b.cserie AS SERIE" +
                ", a.cnumero AS NUMERO,b.Entidad AS COD_ENTIEDAD,a.cdesenti AS NOMBRE_ENTIDAD,a.ccodtipent AS TIPO_DOC_ENTIDAD,a.ccodruc AS RUC" +
                ",a.crazsoc AS RAZON_SOCIAL,isnull(a.cdirecc, '') AS DIREC_CLIENTE, isnull(a.ccodubi, '') AS UBIGEO, isnull(a.ccodcontac, '') AS CONTACTO" +
                ", a.cdescontacto AS NOMB_CONTACTO," +
                " convert(varchar, a.ffecha, 103) AS FEC_DOCUMENTO," +
                " convert(varchar, a.ffechaven, 103)  AS FEC_VENCIMIENTO," +
                " convert(varchar, a.ffechaalm, 103)  AS FEC_ALMACEN, isnull(a.ccodpag, b.ccodpag) AS CONDICION_PAGO, isnull(a.cmoneda, '') AS MONEDA" +
                ", a.ntcigv AS TIPO_CAMBIO,a.cguiaser AS SERIE_GUIA,a.cguianum AS NUMERO_GUIA,a.mdsc AS INF_ADICIONAL_DOC,b.ccodvend AS COD_VENDEDOR,a.ccodclas AS COD_CLASI_BBSS" +
                ",isnull(a.ccodocon, '') AS OTROS_CONCEPTOS, isnull(a.cnumordc, '') AS ORDEN_COMPRA, isnull(a.crefdoc, '') AS TIP_REFERENCIA," +
                " isnull(a.freffec, '') AS FEC_DOC_REFERENCIA, isnull(a.crefser, '') AS SERIE_DOC_REFERENCIA, isnull(a.crefnum, '') AS NUMERO_REFERENCIA," +
                " isnull(a.ccat09, '') AS COD_MOTIVO_NOTACREDITO, isnull(a.cmotinc, '') AS MOTIVO_NOTACREDITO, isnull(a.nresp, 0) AS REG_ESPECIAL, isnull(a.ccodpds, '') AS COD_DETRACCION" +
                ", isnull(a.nporre, 0.00) AS PORCENTAJE_DETRACCION," +
                " convert(varchar, a.ffecre, 103) AS FEC_DEPOSITO" +
                " , a.cnumdere AS CONTANCIA_DEPOSITO,isnull(a.ccodpps, '') AS COD_PERCEPCION, isnull(a.nporre2, 0.00) AS PORCENTAJE_PERCEPCION" +
                ", isnull(a.nperdenre, 0.00) AS DOCUMENTO_DENTROFUERA, isnull(a.nbase1, 0.00) AS BASE_IMP1, isnull(a.nigv1, 0.00) AS IGV1, isnull(nbase2, 0.00) AS BASE_IMP2," +
                " isnull(nigv2, 0.00) AS IGV2, isnull(nbase3, 0.00) AS BASE_IMP3, isnull(nigv3, 00) AS IGV3" +
                ",isnull(a.nimpicbper, 0.00) AS IMP_ICBPER, isnull(a.nina, 0.00) AS IMP_INAFECTO, Isnull(a.nexo, 0.00) AS IMP_EXONERADO, Isnull(a.nisc, 0.00) AS IMP_ISC," +
                " isnull(a.nivabase, 0.00) AS BASE_IVAP," +
                " isnull(a.nivaimp, 0.00) AS IGV_IVAP, isnull(a.nimpant, 0.00) AS IMP_ANTICIPO" +
                ",isnull(a.ntot, 0.00) AS TOTAL," +
                " isnull(a.obserror, '') as OBSERVACION " +
                " FROM com_documento a with(nolock) inner join configuracion2 b on  " +
                " ltrim(a.ccodmodulo) = ltrim(b.Tipo) and  " +
                " ltrim(a.ccoddoc) = ltrim(b.codtipdocu) and  " +
                " ltrim(a.cserie) = ltrim(b.cserie)  " +
                " where a.es_con_migracion = 2  and a.ccodrucemisor='" + Objet.Ruc.Trim() + "' and a.ccod_empresa='" + Objet.Empresa.Trim() + "' and convert(varchar(900),obserror) like '%" + Objet.Estado.Trim() + "%'";


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
        public DataTable listascombopos(Clase.Comercial_documentoPropiedades Objet)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            NpgsqlDataReader carga;
            DataTable grilla = new DataTable();
            ;
            try
            {
                string query = "SELECT a.iddocumento AS ID,a.ccodmodulo AS MODULO,b.ccodmov AS COD_MOVIMIENTO,a.ccoddoc AS COD_DOCUMENTO,b.cserie AS SERIE " +
               ", a.cnumero AS NUMERO,b.Entidad AS COD_ENTIEDAD,a.cdesenti AS NOMBRE_ENTIDAD,a.ccodtipent AS TIPO_DOC_ENTIDAD,a.ccodruc AS RUC " +
               ",a.crazsoc AS RAZON_SOCIAL,coalesce(a.cdirecc, '') AS DIREC_CLIENTE, coalesce(a.ccodubi, '') AS UBIGEO, coalesce(a.ccodcontac, '') AS CONTACTO " +
               ", a.cdescontacto AS NOMB_CONTACTO, " +
               "to_char(a.ffecha, 'yyyymmdd') AS FEC_DOCUMENTO, " +
               "to_char(a.ffechaven, 'yyyymmdd')  AS FEC_VENCIMIENTO, " +
               "to_char(a.ffechaalm, 'yyyymmdd')  AS FEC_ALMACEN, coalesce(a.ccodpag, b.ccodpag) AS CONDICION_PAGO, coalesce(a.cmoneda, '') AS MONEDA " +
               " a.ntcigv AS TIPO_CAMBIO,a.cguiaser AS SERIE_GUIA,a.cguianum AS NUMERO_GUIA,a.mdsc AS INF_ADICIONAL_DOC,b.ccodvend AS COD_VENDEDOR,a.ccodclas AS COD_CLASI_BBSS " +
               ",coalesce(a.ccodocon, '') AS OTROS_CONCEPTOS, coalesce(a.cnumordc, '') AS ORDEN_COMPRA, coalesce(a.crefdoc, '') AS TIP_REFERENCIA, " +
               "to_char(a.freffec, 'yyyymmdd') AS FEC_DOC_REFERENCIA, coalesce(a.crefser, '') AS SERIE_DOC_REFERENCIA, coalesce(a.crefnum, '') AS NUMERO_REFERENCIA, " +
               "coalesce(a.ccat09, '') AS COD_MOTIVO_NOTACREDITO, coalesce(a.cmotinc, '') AS MOTIVO_NOTACREDITO, coalesce(a.nresp, 0) AS REG_ESPECIAL, coalesce(a.ccodpds, '') AS COD_DETRACCION " +
               ", coalesce(a.nporre, 0.00) AS PORCENTAJE_DETRACCION, " +
               " to_char(a.ffecre, 'yyyymmdd') AS FEC_DEPOSITO " +
               ", a.cnumdere AS CONTANCIA_DEPOSITO,coalesce(a.ccodpps, '') AS COD_PERCEPCION, coalesce(a.nporre2, 0.00) AS PORCENTAJE_PERCEPCION " +
               ", coalesce(a.nperdenre, 0.00) AS DOCUMENTO_DENTROFUERA, coalesce(a.nbase1, 0.00) AS BASE_IMP1, coalesce(a.nigv1, 0.00) AS IGV1, coalesce(nbase2, 0.00) AS BASE_IMP2, " +
               " coalesce(nigv2, 0.00) AS IGV2, coalesce(nbase3, 0.00) AS BASE_IMP3, coalesce(nigv3, 00) AS IGV3 " +
               ", coalesce(a.nimpicbper, 0.00) AS IMP_ICBPER, coalesce(a.nina, 0.00) AS IMP_INAFECTO, coalesce(a.nexo, 0.00) AS IMP_EXONERADO, coalesce(a.nisc, 0.00) AS IMP_ISC, " +
               " coalesce(a.nivabase, 0.00) AS BASE_IVAP, " +
               " coalesce(a.nivaimp, 0.00) AS IGV_IVAP, coalesce(a.nimpant, 0.00) AS IMP_ANTICIPO " +
               ", coalesce(a.ntot, 0.00) AS TOTAL, " +
               "  coalesce(a.obserror, '') as OBSERVACION  " +
               " FROM com_documento a inner join configuracion2 b on  " +
               " ltrim(a.ccodmodulo) = ltrim(b.Tipo) and  " +
               " ltrim(a.ccoddoc) = ltrim(b.codtipdocu) and  " +
               " ltrim(a.cserie) = ltrim(b.cserie)  " +
               " where es_con_migracion =2 AND " +
               " ccodrucemisor='" + Objet.Ruc.Trim() + "' and ccod_empresa='" + Objet.Empresa.Trim() + "' and obserror='" + Objet.Estado.Trim() + "'";
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
        public string Actualizarmasivosql(Clase.Comercial_documentoPropiedades Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update com_documento  SET obserror='',es_con_migracion= 0 where iddocumento=" + Objet.Id + "";
                MessageBox.Show(query);
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
        public string Actualizarmasivopos(Clase.Comercial_documentoPropiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update  com_documento  SET obserror='',es_con_migracion=0 where iddocumento=" + Objet.Id + "";
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
        public void ActualizaEstadoSQL(Clase.Comercial_documentoPropiedades Objet)
        {
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update  com_documento  SET es_con_migracion=2  " +
                               "where  es_con_migracion=0 and  convert(char(900),obserror)<>''  and  " +
                               " ccodrucemisor = '" + Objet.Ruc.Trim() + "' and ccod_empresa = '" + Objet.Empresa.Trim() + "'";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando1 = new SqlCommand(query, cone);
                cone.Open();
                commando1.ExecuteNonQuery();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
            finally
            {
                if (cone.State == ConnectionState.Open)
                {
                    cone.Close();
                }

            }

        }
        public void ActualizaEstadoPOS(Clase.Comercial_documentoPropiedades Objet)
        {

            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update  com_documento  SET es_con_migracion=2  where es_con_migracion=0 and obserror<>''  and  ccodrucemisor = '" + Objet.Ruc.Trim() + "' and ccod_empresa = '" + Objet.Empresa.Trim() + "'";
                NpgsqlCommand command3 = new NpgsqlCommand(query, conexion);
                command3.ExecuteNonQuery();

            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }
        }
        /***********************************************************************************************************/

    }
}

