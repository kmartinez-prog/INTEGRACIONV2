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
                " isnull(a.freffec, '') AS FEC_DOC_REFERENCIA, isnull(a.crefser, '') AS SERIE_DOC_REFERENCIA, isnull(a.crefnum, '') AS NUMERO_REFERENCIA,"+
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






        public string eliminarsql(Clase.Comercial_productos_propiedades Objet)
        {
            string cadena = "";

            DataTable Tabla = new DataTable();
            SqlConnection cone = new SqlConnection();

            try
            {
                string cadena1 = "Delete from com_producto  where idproducto=" + Objet.Id + "";
                cone = ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(cadena1, cone);
                cone.Open();
                cadena = commando.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";
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
        public string eliminarpos(Clase.Comercial_productos_propiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string cadena1 = "Delete from com_producto  where idproducto=" + Objet.Id + "";
                NpgsqlCommand command3 = new NpgsqlCommand(cadena1, conexion);
                cadena = command3.ExecuteNonQuery() == 1 ? "Eliminar" : "No se pudo eliminar";
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
        public string Actualizarsql(Clase.Comercial_productos_propiedades Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "UPDATE com_producto SET ccodfamg ='" + Objet.Cod_grupo.Trim() + "',cdesfamg = '" + Objet.Descripcion_grupo.Trim() + "'" +
                ",ccodfamf = '" + Objet.Cod_familia.Trim() + "',cdesfamf = '" + Objet.Desc_familia.Trim() + "',ccodprod = '" + Objet.Cod_producto.Trim() + "'" +
                ",cdesprod = '" + Objet.Descripcion_producto.Trim() + "',cdesprodGen =  '" + Objet.Descripcion_general.Trim() + "',ccodtes =  '" + Objet.Existencia.Trim() + "'" +
                ",cdesmar =  '" + Objet.Marca.Trim() + "',ccodmed =  '" + Objet.Unidad_medida.Trim() + "',ccodcatbs =  '" + Objet.Cod_osce.Trim() + "'" +
                ",cdescatbs ='" + Objet.Descrip_osce.Trim() + "',ntipoprod ='" + Objet.Tipo.Trim() + "',nunidsec ='" + Objet.Unid_secundaria.Trim() + "',npesoprod =  '" + Objet.Peso.Trim() + "'" +
                ",ccodbarras ='" + Objet.Cod_barra.Trim() + "',ninprod =  '" + Objet.Inhabilitar_prod.Trim() + "',nanuprod ='" + Objet.Para_anular.Trim() + "',nlote =  '" + Objet.Lote.Trim() + "'" +
                ",nseruni =  '" + Objet.Serie_unica.Trim() + "',nicbper =  '" + Objet.Icbper.Trim() + "',nprodanti =  '" + Objet.Prod_anticipo.Trim() + "'" +
                ",ngasrela = '" + Objet.Gasto_relacionado.Trim() + "',nprodsafniif =  '" + Objet.Prod_safnif.Trim() + "'" +
                ",ccomcue =  '" + Objet.Cuenta_compras.Trim() + "',cvencue =  '" + Objet.Cuenta_ventas.Trim() + "'" +
                ",cdebicue = '" + Objet.Costo_debito_salida.Trim() + "',ccredcue =  '" + Objet.Costos_credito_salida.Trim() + "'" +
                ",cdebicuei ='" + Objet.Debito_costo_ingresos.Trim() + "',ccredcuei =  '" + Objet.Credito_costo_ingresos.Trim() + "'" +
                ",ccodcos =  '" + Objet.Ccostos.Trim() + "',ccodcos2 =  '" + Objet.Ccostos2.Trim() + "',ccodpresu =  '" + Objet.Presupuesto.Trim() + "'" +
                ",ccomprod = '" + Objet.Reg_compras.Trim() + "',cvenprod =  '" + Objet.Reg_ventas.Trim() + "',ccodisc =  '" + Objet.Afecto_isc.Trim() + "'" +
                ",cmoneda =  '" + Objet.Moneda.Trim() + "',npreunit1 =  '" + Objet.Precio1.Trim() + "',npreunit2 =  '" + Objet.Precio2.Trim() + "'" +
                ",npreunit3 ='" + Objet.Precio3.Trim() + "',npreunit4 =  '" + Objet.Precio4.Trim() + "',npreunit5 =  '" + Objet.Precio5.Trim() + "'" +
                ",npreunit6 ='" + Objet.Precio6.Trim() + "',npreunit7 =  '" + Objet.Precio7.Trim() + "',npreunit8 =  '" + Objet.Precio8.Trim() + "'" +
                ",npreunit9 ='" + Objet.Precio9.Trim() + "',npreunit10 =  '" + Objet.Precio10.Trim() + "',npreunit11 =  '" + Objet.Precio11.Trim() + "'" +
                ",npreunit12 =  '" + Objet.Precio12.Trim() + "',npreunit13 =  '" + Objet.Precio13.Trim() + "',npreunit14 =  '" + Objet.Precio14.Trim() + "'" +
                ",npreunit15 =  '" + Objet.Precio15.Trim() + "',nstockmin =  '" + Objet.Stock_minimo.Trim() + "',nstockmax =  '" + Objet.Stock_maximo.Trim() + "'" +
                ",nrango1 =  '" + Objet.Limite_inferior_precio.Trim() + "',nrango2 =  '" + Objet.Limite_superior_precio.Trim() + "'" +
                ",nresp =  '" + Objet.Regimen_especial.Trim() + "',ccodpps =  '" + Objet.Codigo_percepcion.Trim() + "',ccodpds =  '" + Objet.Codigo_detraccion.Trim() + "'" +
                ",nagemonmin =  '" + Objet.Monto_minimo.Trim() + "',ccodlabora =  '" + Objet.Codigo_laboratorio.Trim() + "'" +
                ",cdeslabora =  '" + Objet.Descripcion_laboratorio.Trim() + "',es_con_migracion =0 " +
                ",obserror ='' WHERE idproducto=" + Objet.Id + "";
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
        public string Actualizarpos(Clase.Comercial_productos_propiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {


                string query = "UPDATE com_producto SET ccodfamg ='" + Objet.Cod_grupo + "',cdesfamg = '" + Objet.Descripcion_grupo + "'" +
                ",ccodfamf = '" + Objet.Cod_familia + "',cdesfamf = '" + Objet.Desc_familia + "',ccodprod = '" + Objet.Cod_producto + "'" +
                ",cdesprod = '" + Objet.Descripcion_producto + "',cdesprodGen =  '" + Objet.Descripcion_general + "',ccodtes =  '" + Objet.Existencia + "'" +
                ",cdesmar =  '" + Objet.Marca + "',ccodmed =  '" + Objet.Unidad_medida + "',ccodcatbs =  '" + Objet.Cod_osce + "'" +
                ",cdescatbs ='" + Objet.Descrip_osce + "',ntipoprod ='" + Objet.Tipo + "',nunidsec ='" + Objet.Unid_secundaria + "',npesoprod =  '" + Objet.Peso + "'" +
                ",ccodbarras ='" + Objet.Cod_barra + "',ninprod =  '" + Objet.Inhabilitar_prod + "',nanuprod ='" + Objet.Para_anular + "',nlote =  '" + Objet.Lote + "'" +
                ",nseruni =  '" + Objet.Serie_unica + "',nicbper =  '" + Objet.Icbper + "',nprodanti =  '" + Objet.Prod_anticipo + "'" +
                ",ngasrela = '" + Objet.Gasto_relacionado + "',nprodsafniif =  '" + Objet.Prod_safnif + "'" +
                ",ccomcue =  '" + Objet.Cuenta_compras + "',cvencue =  '" + Objet.Cuenta_ventas + "'" +
                ",cdebicue = '" + Objet.Costo_debito_salida + "',ccredcue =  '" + Objet.Costos_credito_salida + "'" +
                ",cdebicuei ='" + Objet.Debito_costo_ingresos + "',ccredcuei =  '" + Objet.Credito_costo_ingresos + "'" +
                ",ccodcos =  '" + Objet.Ccostos + "',ccodcos2 =  '" + Objet.Ccostos2 + "',ccodpresu =  '" + Objet.Presupuesto + "'" +
                ",ccomprod = '" + Objet.Reg_compras + "',cvenprod =  '" + Objet.Reg_ventas + "',ccodisc =  '" + Objet.Afecto_isc + "'" +
                ",cmoneda =  '" + Objet.Moneda + "',npreunit1 =  '" + Objet.Precio1 + "',npreunit2 =  '" + Objet.Precio2 + "'" +
                ",npreunit3 ='" + Objet.Precio3 + "',npreunit4 =  '" + Objet.Precio4 + "',npreunit5 =  '" + Objet.Precio5 + "'" +
                ",npreunit6 ='" + Objet.Precio6 + "',npreunit7 =  '" + Objet.Precio7 + "',npreunit8 =  '" + Objet.Precio8 + "'" +
                ",npreunit9 ='" + Objet.Precio9 + "',npreunit10 =  '" + Objet.Precio10 + "',npreunit11 =  '" + Objet.Precio11 + "'" +
                ",npreunit12 =  '" + Objet.Precio12 + "',npreunit13 =  '" + Objet.Precio13 + "',npreunit14 =  '" + Objet.Precio14 + "'" +
                ",npreunit15 =  '" + Objet.Precio15 + "',nstockmin =  '" + Objet.Stock_minimo + "',nstockmax =  '" + Objet.Stock_maximo + "'" +
                ",nrango1 =  '" + Objet.Limite_inferior_precio + "',nrango2 =  '" + Objet.Limite_superior_precio + "'" +
                ",nresp =  '" + Objet.Regimen_especial + "',ccodpps =  '" + Objet.Codigo_percepcion + "',ccodpds =  '" + Objet.Codigo_detraccion + "'" +
                ",nagemonmin =  '" + Objet.Monto_minimo + "',ccodlabora =  '" + Objet.Codigo_laboratorio + "'" +
                ",cdeslabora =  '" + Objet.Descripcion_laboratorio + "',es_con_migracion =0 " +
                ",obserror ='' WHERE idproducto=" + Objet.Id + "";
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
               " where es_con_migracion =2 and " +
               " ccodrucemisor='" + Objet.Ruc.Trim() + "' and ccod_empresa='" + Objet.Empresa.Trim() + "' and convert(varchar(900),obserror) ='" + Objet.Estado.Trim() + "'";
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

