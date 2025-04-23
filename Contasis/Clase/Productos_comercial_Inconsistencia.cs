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
    class Productos_comercial_Inconsistencia
    {
        /*******************************************************************************************************/
        public DataTable listarsql(Clase.Comercial_productos_propiedades Objet)
        {

            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT idproducto as ID,'' AS MODULO,ccodfamg AS COD_GRUPO,cdesfamg AS DESCRIPCION_GRUPO,ccodfamf AS COD_FAMILIA,cdesfamf AS DESC_FAMILIA,"+
                               "ccodprod AS COD_PRODUCTO,cdesprod AS DESCRIPCION_PRODUCTO,cdesprodGen AS DESCRIPCION_GENERAL,ccodtes AS EXISTENCIA,cdesmar AS MARCA,"+	
                               "ccodmed AS UNIDAD_MEDIDA,ccodcatbs AS COD_OSCE,cdescatbs AS DESCRIP_OSCE,ntipoprod AS TIPO,nunidsec AS UNID_SECUNDARIA,npesoprod AS PESO ,"+
                               "ccodbarras AS COD_BARRA,ninprod AS INHABILITAR_PROD,nanuprod AS PARA_ANULAR,nlote AS LOTE,nseruni AS SERIE_UNICA,nicbper AS ICBPER,"+
                               "nprodanti AS PROD_ANTICIPO,ngasrela AS GASTO_RELACIONADO,nprodsafniif AS PROD_SAFNIF,ccomcue AS CUENTA_COMPRAS,cvencue AS CUENTA_VENTAS,"+
                               "cdebicue AS COSTO_DEBITO_SALIDA,ccredcue AS COSTOS_CREDITO_SALIDA,cdebicuei AS DEBITO_COSTO_INGRESOS,ccredcuei AS CREDITO_COSTO_INGRESOS,"+
                               "ccodcos AS CCostos,ccodcos2 AS CCostos2,ccodpresu AS PRESUPUESTO,ccomprod AS REG_COMPRAS,cvenprod AS REG_VENTAS,ccodisc AS AFECTO_ISC,cmoneda AS MONEDA,"+
                               "npreunit1 AS PRECIO1,npreunit2 AS PRECIO2,npreunit3 AS PRECIO3,npreunit4 AS PRECIO4,npreunit5 AS PRECIO5,npreunit6 AS PRECIO6,npreunit7 AS PRECIO7,npreunit8 AS PRECIO8,"+
                               "npreunit9 AS PRECIO9,npreunit10 AS PRECIO10,npreunit11 AS PRECIO11,npreunit12 AS PRECIO12,npreunit13 AS PRECIO13,npreunit14 AS PRECIO14,npreunit15 AS PRECIO15,"+
                               "nstockmin AS STOCK_MINIMO,nstockmax AS STOCK_MAXIMO,nrango1 AS LIMITE_INFERIOR_PRECIO,nrango2 AS LIMITE_SUPERIOR_PRECIO,"+
                               "nresp AS REGIMEN_ESPECIAL,ccodpps AS CODIGO_PERCEPCION,ccodpds AS CODIGO_DETRACCION,nagemonmin AS MONTO_MINIMO,ccodlabora AS CODIGO_LABORATORIO,"+
                               "cdeslabora AS DESCRIPCION_LABORATORIO,es_con_migracion AS ESTADO,obserror AS OBSERVACION "+
                               " FROM com_producto with(nolock) "+
                               "where es_con_migracion = 2  and ccodrucemisor='" + Objet.Ruc.Trim() + "' and ccod_empresa='" + Objet.Empresa.Trim() + "'";
                cone = ConexionSql.Instancial().Establecerconexion();
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
        public DataTable listarpostgres(Clase.Comercial_productos_propiedades Objet)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            NpgsqlDataReader carga;
            DataTable grilla = new DataTable();
            try
            {
                string query = "SELECT idproducto as ID,'' AS MODULO,ccodfamg AS COD_GRUPO,cdesfamg AS DESCRIPCION_GRUPO,ccodfamf AS COD_FAMILIA,cdesfamf AS DESC_FAMILIA," +
                              "ccodprod AS COD_PRODUCTO,cdesprod AS DESCRIPCION_PRODUCTO,cdesprodGen AS DESCRIPCION_GENERAL,ccodtes AS EXISTENCIA,cdesmar AS MARCA," +
                              "ccodmed AS UNIDAD_MEDIDA,ccodcatbs AS COD_OSCE,cdescatbs AS DESCRIP_OSCE,ntipoprod AS TIPO,nunidsec AS UNID_SECUNDARIA,npesoprod AS PESO ," +
                              "ccodbarras AS COD_BARRA,ninprod AS INHABILITAR_PROD,nanuprod AS PARA_ANULAR,nlote AS LOTE,nseruni AS SERIE_UNICA,nicbper AS ICBPER," +
                              "nprodanti AS PROD_ANTICIPO,ngasrela AS GASTO_RELACIONADO,nprodsafniif AS PROD_SAFNIF,ccomcue AS CUENTA_COMPRAS,cvencue AS CUENTA_VENTAS," +
                              "cdebicue AS COSTO_DEBITO_SALIDA,ccredcue AS COSTOS_CREDITO_SALIDA,cdebicuei AS DEBITO_COSTO_INGRESOS,ccredcuei AS CREDITO_COSTO_INGRESOS," +
                              "ccodcos AS CCostos,ccodcos2 AS CCostos2,ccodpresu AS PRESUPUESTO,ccomprod AS REG_COMPRAS,cvenprod AS REG_VENTAS,ccodisc AS AFECTO_ISC,cmoneda AS MONEDA," +
                              "npreunit1 AS PRECIO1,npreunit2 AS PRECIO2,npreunit3 AS PRECIO3,npreunit4 AS PRECIO4,npreunit5 AS PRECIO5,npreunit6 AS PRECIO6,npreunit7 AS PRECIO7,npreunit8 AS PRECIO8," +
                              "npreunit9 AS PRECIO9,npreunit10 AS PRECIO10,npreunit11 AS PRECIO11,npreunit12 AS PRECIO12,npreunit13 AS PRECIO13,npreunit14 AS PRECIO14,npreunit15 AS PRECIO15," +
                              "nstockmin AS STOCK_MINIMO,nstockmax AS STOCK_MAXIMO,nrango1 AS LIMITE_INFERIOR_PRECIO,nrango2 AS LIMITE_SUPERIOR_PRECIO," +
                              "nresp AS REGIMEN_ESPECIAL,ccodpps AS CODIGO_PERCEPCION,ccodpds AS CODIGO_DETRACCION,nagemonmin AS MONTO_MINIMO,ccodlabora AS CODIGO_LABORATORIO," +
                              "cdeslabora AS DESCRIPCION_LABORATORIO,es_con_migracion AS ESTADO,obserror AS OBSERVACION" +
                              " FROM com_producto  " +
                              "where es_con_migracion = 2  and ccodrucemisor='" + Objet.Ruc.Trim() + "' and ccod_empresa='" + Objet.Empresa.Trim() + "'";
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
                cone = ConexionSql.Instancial().Establecerconexion();
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
                ",obserror ='' WHERE idproducto=" + Objet.Id +"";
                cone = ConexionSql.Instancial().Establecerconexion();
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
                

                string query =  "UPDATE com_producto SET ccodfamg ='" + Objet.Cod_grupo + "',cdesfamg = '" + Objet.Descripcion_grupo + "'" +
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
        public DataTable listascombosql(Clase.Comercial_productos_propiedades Objet)
        {
            SqlDataReader carga;
            DataTable grilla = new DataTable();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "SELECT idproducto as ID,'' AS MODULO,ccodfamg AS COD_GRUPO,cdesfamg AS DESCRIPCION_GRUPO,ccodfamf AS COD_FAMILIA,cdesfamf AS DESC_FAMILIA," +
                              "ccodprod AS COD_PRODUCTO,cdesprod AS DESCRIPCION_PRODUCTO,cdesprodGen AS DESCRIPCION_GENERAL,ccodtes AS EXISTENCIA,cdesmar AS MARCA," +
                              "ccodmed AS UNIDAD_MEDIDA,ccodcatbs AS COD_OSCE,cdescatbs AS DESCRIP_OSCE,ntipoprod AS TIPO,nunidsec AS UNID_SECUNDARIA,npesoprod AS PESO ," +
                              "ccodbarras AS COD_BARRA,ninprod AS INHABILITAR_PROD,nanuprod AS PARA_ANULAR,nlote AS LOTE,nseruni AS SERIE_UNICA,nicbper AS ICBPER," +
                              "nprodanti AS PROD_ANTICIPO,ngasrela AS GASTO_RELACIONADO,nprodsafniif AS PROD_SAFNIF,ccomcue AS CUENTA_COMPRAS,cvencue AS CUENTA_VENTAS," +
                              "cdebicue AS COSTO_DEBITO_SALIDA,ccredcue AS COSTOS_CREDITO_SALIDA,cdebicuei AS DEBITO_COSTO_INGRESOS,ccredcuei AS CREDITO_COSTO_INGRESOS," +
                              "ccodcos AS CCostos,ccodcos2 AS CCostos2,ccodpresu AS PRESUPUESTO,ccomprod AS REG_COMPRAS,cvenprod AS REG_VENTAS,ccodisc AS AFECTO_ISC,cmoneda AS MONEDA," +
                              "npreunit1 AS PRECIO1,npreunit2 AS PRECIO2,npreunit3 AS PRECIO3,npreunit4 AS PRECIO4,npreunit5 AS PRECIO5,npreunit6 AS PRECIO6,npreunit7 AS PRECIO7,npreunit8 AS PRECIO8," +
                              "npreunit9 AS PRECIO9,npreunit10 AS PRECIO10,npreunit11 AS PRECIO11,npreunit12 AS PRECIO12,npreunit13 AS PRECIO13,npreunit14 AS PRECIO14,npreunit15 AS PRECIO15," +
                              "nstockmin AS STOCK_MINIMO,nstockmax AS STOCK_MAXIMO,nrango1 AS LIMITE_INFERIOR_PRECIO,nrango2 AS LIMITE_SUPERIOR_PRECIO," +
                              "nresp AS REGIMEN_ESPECIAL,ccodpps AS CODIGO_PERCEPCION,ccodpds AS CODIGO_DETRACCION,nagemonmin AS MONTO_MINIMO,ccodlabora AS CODIGO_LABORATORIO," +
                              "cdeslabora AS DESCRIPCION_LABORATORIO,es_con_migracion AS ESTADO,obserror AS OBSERVACION " +
                              " FROM com_producto with(nolock) " +
                              "where es_con_migracion =2 and " +
                               "ccodrucemisor='" + Objet.Ruc.Trim() + "' and ccod_empresa='" + Objet.Empresa.Trim() + "' and convert(varchar(900),obserror) ='" + Objet.Estado.Trim() + "'";
                cone = ConexionSql.Instancial().Establecerconexion();
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
        public DataTable listascombopos(Clase.Comercial_productos_propiedades Objet)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            NpgsqlDataReader carga;
            DataTable grilla = new DataTable();
            ;
            try
            {
                string query  = "SELECT idproducto as ID,'' AS MODULO,ccodfamg AS COD_GRUPO,cdesfamg AS DESCRIPCION_GRUPO,ccodfamf AS COD_FAMILIA,cdesfamf AS DESC_FAMILIA," +
                              "ccodprod AS COD_PRODUCTO,cdesprod AS DESCRIPCION_PRODUCTO,cdesprodGen AS DESCRIPCION_GENERAL,ccodtes AS EXISTENCIA,cdesmar AS MARCA," +
                              "ccodmed AS UNIDAD_MEDIDA,ccodcatbs AS COD_OSCE,cdescatbs AS DESCRIP_OSCE,ntipoprod AS TIPO,nunidsec AS UNID_SECUNDARIA,npesoprod AS PESO ," +
                              "ccodbarras AS COD_BARRA,ninprod AS INHABILITAR_PROD,nanuprod AS PARA_ANULAR,nlote AS LOTE,nseruni AS SERIE_UNICA,nicbper AS ICBPER," +
                              "nprodanti AS PROD_ANTICIPO,ngasrela AS GASTO_RELACIONADO,nprodsafniif AS PROD_SAFNIF,ccomcue AS CUENTA_COMPRAS,cvencue AS CUENTA_VENTAS," +
                              "cdebicue AS COSTO_DEBITO_SALIDA,ccredcue AS COSTOS_CREDITO_SALIDA,cdebicuei AS DEBITO_COSTO_INGRESOS,ccredcuei AS CREDITO_COSTO_INGRESOS," +
                              "ccodcos AS CCostos,ccodcos2 AS CCostos2,ccodpresu AS PRESUPUESTO,ccomprod AS REG_COMPRAS,cvenprod AS REG_VENTAS,ccodisc AS AFECTO_ISC,cmoneda AS MONEDA," +
                              "npreunit1 AS PRECIO1,npreunit2 AS PRECIO2,npreunit3 AS PRECIO3,npreunit4 AS PRECIO4,npreunit5 AS PRECIO5,npreunit6 AS PRECIO6,npreunit7 AS PRECIO7,npreunit8 AS PRECIO8," +
                              "npreunit9 AS PRECIO9,npreunit10 AS PRECIO10,npreunit11 AS PRECIO11,npreunit12 AS PRECIO12,npreunit13 AS PRECIO13,npreunit14 AS PRECIO14,npreunit15 AS PRECIO15," +
                              "nstockmin AS STOCK_MINIMO,nstockmax AS STOCK_MAXIMO,nrango1 AS LIMITE_INFERIOR_PRECIO,nrango2 AS LIMITE_SUPERIOR_PRECIO," +
                              "nresp AS REGIMEN_ESPECIAL,ccodpps AS CODIGO_PERCEPCION,ccodpds AS CODIGO_DETRACCION,nagemonmin AS MONTO_MINIMO,ccodlabora AS CODIGO_LABORATORIO," +
                              "cdeslabora AS DESCRIPCION_LABORATORIO,es_con_migracion AS ESTADO,obserror AS OBSERVACION " +
                               "FROM com_producto " +
                               "where es_con_migracion =2 AND " +
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
        public string Actualizarmasivosql(Clase.Comercial_productos_propiedades Objet)
        {
            string cadena = "";
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update  com_producto  SET obserror='',es_con_migracion=0 where idproducto=" + Objet.Id + "";
                cone = ConexionSql.Instancial().Establecerconexion();
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
        public string Actualizarmasivopos(Clase.Comercial_productos_propiedades Objet)
        {
            string cadena = "";
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update  com_producto  SET obserror='',es_con_migracion=0 where idproducto=" + Objet.Id + "";
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
        public void ActualizaEstadoSQL(Clase.Comercial_productos_propiedades Objet)
        {
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "update  com_producto  SET es_con_migracion=2  " +
                               "where  es_con_migracion=0 and  convert(char(900),obserror)<>''  and  " +
                               " ccodrucemisor = '" + Objet.Ruc.Trim() + "' and ccod_empresa = '" + Objet.Empresa.Trim() + "'";
                cone = ConexionSql.Instancial().Establecerconexion();
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
        public void ActualizaEstadoPOS(Clase.Comercial_productos_propiedades Objet)
        {

            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();
            try
            {
                string query = "update  com_producto  SET es_con_migracion=2  where es_con_migracion=0 and obserror<>''  and  ccodrucemisor = '" + Objet.Ruc.Trim() + "' and ccod_empresa = '" + Objet.Empresa.Trim() + "'";
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
