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
    public partial class Frm_com_productosEditor : Form
    {
        public Frm_com_productosEditor(Clase.Comercial_productos_propiedades ojbtexto)
        {
            InitializeComponent();
            txtId.Text = ojbtexto.Id;
            txtModulo.Text = ojbtexto.Modulo;
            txtCod_grupo.Text = ojbtexto.Cod_grupo;
            txtDescripcion_grupo.Text = ojbtexto.Descripcion_grupo;
            txtCod_familia.Text = ojbtexto.Cod_familia;
            txtDesc_familia.Text = ojbtexto.Desc_familia;
            txtCod_producto.Text = ojbtexto.Cod_producto;
            txtDescripcion_producto.Text = ojbtexto.Descripcion_producto;
            txtDescripcion_general.Text = ojbtexto.Descripcion_general;
            txtExistencia.Text = ojbtexto.Existencia;
            txtMarca.Text = ojbtexto.Marca;
            txtUnidad_medida.Text = ojbtexto.Unidad_medida;
            txtCod_osce.Text = ojbtexto.Cod_osce;
            txtDescrip_osce.Text = ojbtexto.Descrip_osce;
            txtTipo.Text = ojbtexto.Tipo;
            txtUnid_secundaria.Text = ojbtexto.Unid_secundaria;
            txtPeso.Text = ojbtexto.Peso;
            txtCod_barra.Text = ojbtexto.Cod_barra;
            txtInhabilitar_prod.Text = ojbtexto.Inhabilitar_prod;
            txtPara_anular.Text = ojbtexto.Para_anular;
            txtLote.Text = ojbtexto.Lote;
            txtSerie_unica.Text = ojbtexto.Serie_unica;
            txtIcbper.Text = ojbtexto.Icbper;
            txtProd_anticipo.Text = ojbtexto.Prod_anticipo;
            txtGasto_relacionado.Text = ojbtexto.Gasto_relacionado;
            txtProd_safnif.Text = ojbtexto.Prod_safnif;
            txtCuenta_compras.Text = ojbtexto.Cuenta_compras;
            txtCuenta_ventas.Text = ojbtexto.Cuenta_ventas;
            txtCosto_debito_salida.Text = ojbtexto.Costo_debito_salida;
            txtCostos_credito_salida.Text = ojbtexto.Costos_credito_salida;
            txtDebito_costo_ingresos.Text = ojbtexto.Debito_costo_ingresos;
            txtCredito_costo_ingresos.Text = ojbtexto.Credito_costo_ingresos;
            txtCcostos.Text = ojbtexto.Ccostos;
            txtCcostos2.Text = ojbtexto.Ccostos2;
            txtPresupuesto.Text = ojbtexto.Presupuesto;
            txtReg_compras.Text = ojbtexto.Reg_compras;
            txtReg_ventas.Text = ojbtexto.Reg_ventas;
            txtAfecto_isc.Text = ojbtexto.Afecto_isc;
            txtMoneda.Text = ojbtexto.Moneda;
            txtPrecio1.Text = ojbtexto.Precio1;
            txtPrecio2.Text = ojbtexto.Precio2;
            txtPrecio3.Text = ojbtexto.Precio3;
            txtPrecio4.Text = ojbtexto.Precio4;
            txtPrecio5.Text = ojbtexto.Precio5;
            txtPrecio6.Text = ojbtexto.Precio6;
            txtPrecio7.Text = ojbtexto.Precio7;
            txtPrecio8.Text = ojbtexto.Precio8;
            txtPrecio9.Text = ojbtexto.Precio9;
            txtPrecio10.Text = ojbtexto.Precio10;
            txtPrecio11.Text = ojbtexto.Precio11;
            txtPrecio12.Text = ojbtexto.Precio12;
            txtPrecio13.Text = ojbtexto.Precio13;
            txtPrecio14.Text = ojbtexto.Precio14;
            txtPrecio15.Text = ojbtexto.Precio15;
            txtStock_minimo.Text = ojbtexto.Stock_minimo;
            txtStock_maximo.Text = ojbtexto.Stock_maximo;
            txtLimite_inferior_precio.Text = ojbtexto.Limite_inferior_precio;
            txtLimite_superior_precio.Text = ojbtexto.Limite_superior_precio;
            txtRegimen_especial.Text = ojbtexto.Regimen_especial;
            txtCodigo_percepcion.Text = ojbtexto.Codigo_percepcion;
            txtCodigo_detraccion.Text = ojbtexto.Codigo_detraccion;
            txtMonto_minimo.Text = ojbtexto.Monto_minimo;
            txtCodigo_laboratorio.Text = ojbtexto.Codigo_laboratorio;
            txtDescripcion_laboratorio.Text = ojbtexto.Descripcion_laboratorio;
            txtObservacion.Text = ojbtexto.Observacion;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    string respuesta = "";
                    Clase.Comercial_productos_propiedades obe = new Clase.Comercial_productos_propiedades();
                    obe.Id = txtId.Text;
                    Clase.Productos_comercial_Inconsistencia registro = new Clase.Productos_comercial_Inconsistencia();
                    
                    //respuesta = registro.eliminarsql(obe);
                    if (respuesta.Equals("Eliminar"))
                    {
                        MessageBox.Show("registro fue eliminado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencia_productos_comercial.instance.llenar_grilla();
                        
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar este registro de producto.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                try
                {
                    string respuesta = "";
                    Clase.Compras_propiedadescs obe = new Clase.Compras_propiedadescs();

                    obe.idcompras = txtId.Text;
                    Clase.Compras_inconsistencias ds = new Clase.Compras_inconsistencias();

                    respuesta = ds.eliminarpos(obe);
                    if (respuesta.Equals("Eliminar"))
                    {

                        MessageBox.Show("registro fue eliminado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistenciasCompras.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar este registro de producto.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            Clase.Comercial_productos_propiedades obe = new Clase.Comercial_productos_propiedades();
            Clase.Productos_comercial_Inconsistencia ds = new Clase.Productos_comercial_Inconsistencia();

            obe.Id= txtId.Text.Trim();
            obe.Cod_grupo= txtCod_grupo.Text.Trim();
            obe.Descripcion_grupo= txtDescripcion_grupo.Text.Trim();
            obe.Cod_familia= txtCod_familia.Text.Trim();
            obe.Desc_familia= txtDesc_familia.Text.Trim();
            obe.Cod_producto = txtCod_producto.Text.Trim();
            obe.Descripcion_producto= txtDescripcion_producto.Text.Trim();
            obe.Descripcion_general=txtDescripcion_general.Text.Trim();
            obe.Existencia= txtExistencia.Text.Trim();
            obe.Marca= txtMarca.Text.Trim();
            obe.Unidad_medida= txtUnidad_medida.Text.Trim();
            obe.Cod_osce=txtCod_osce.Text.Trim();
            obe.Descrip_osce= txtDescrip_osce.Text.Trim();
            obe.Tipo = txtTipo.Text.Trim();
            obe.Unid_secundaria= txtUnid_secundaria.Text.Trim();
            obe.Peso = txtPeso.Text.Trim();
            obe.Cod_barra= txtCod_barra.Text.Trim();
            obe.Inhabilitar_prod= txtInhabilitar_prod.Text.Trim();
            obe.Para_anular= txtPara_anular.Text.Trim();
            obe.Lote = txtLote.Text.Trim();
            obe.Serie_unica = txtSerie_unica.Text.Trim();
            obe.Icbper = txtIcbper.Text.Trim();
            obe.Prod_anticipo = txtProd_anticipo.Text.Trim();
            obe.Gasto_relacionado = txtGasto_relacionado.Text.Trim();
            obe.Prod_safnif = txtProd_safnif.Text.Trim();
            obe.Cuenta_compras = txtCuenta_compras.Text.Trim();
            obe.Cuenta_ventas = txtCuenta_ventas.Text.Trim();
            obe.Costo_debito_salida = txtCosto_debito_salida.Text.Trim();
            obe.Costos_credito_salida = txtCostos_credito_salida.Text.Trim();
            obe.Debito_costo_ingresos = txtDebito_costo_ingresos.Text.Trim();
            obe.Credito_costo_ingresos = txtCredito_costo_ingresos.Text.Trim();
            obe.Ccostos = txtCcostos.Text.Trim();
            obe.Ccostos2 = txtCcostos2.Text.Trim();
            obe.Presupuesto = txtPresupuesto.Text.Trim();
            obe.Reg_compras = txtReg_compras.Text.Trim();
            obe.Reg_ventas = txtReg_ventas.Text.Trim();
            obe.Afecto_isc = txtAfecto_isc.Text.Trim();
            obe.Moneda= txtMoneda.Text.Trim();
            obe.Precio1= txtPrecio1.Text.Trim();
            obe.Precio2 = txtPrecio2.Text.Trim();
            obe.Precio3 = txtPrecio3.Text.Trim();
            obe.Precio4 = txtPrecio4.Text.Trim();
            obe.Precio5 = txtPrecio5.Text.Trim();
            obe.Precio6 = txtPrecio6.Text.Trim();
            obe.Precio7 = txtPrecio7.Text.Trim();
            obe.Precio8 = txtPrecio8.Text.Trim();
            obe.Precio9 = txtPrecio9.Text.Trim();
            obe.Precio10 = txtPrecio10.Text.Trim();
            obe.Precio11 = txtPrecio11.Text.Trim();
            obe.Precio12 = txtPrecio12.Text.Trim();
            obe.Precio13 = txtPrecio13.Text.Trim();
            obe.Precio14 = txtPrecio14.Text.Trim();
            obe.Precio15 = txtPrecio15.Text.Trim();
            obe.Stock_minimo = txtStock_minimo.Text.Trim();
            obe.Stock_maximo= txtStock_maximo.Text.Trim();
            obe.Limite_inferior_precio = txtLimite_inferior_precio.Text.Trim();
            obe.Limite_superior_precio = txtLimite_superior_precio.Text.Trim();
            obe.Regimen_especial = txtRegimen_especial.Text.Trim();
            obe.Codigo_percepcion = txtCodigo_percepcion.Text.Trim();
            obe.Codigo_detraccion = txtCodigo_detraccion.Text.Trim();
            obe.Monto_minimo= txtMonto_minimo.Text.Trim();
            obe.Codigo_laboratorio = txtCodigo_laboratorio.Text.Trim();
            obe.Descripcion_laboratorio = txtDescripcion_laboratorio.Text.Trim();

            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    respuesta = ds.Actualizarsql(obe);
                    if (respuesta.Equals("Actualizado"))
                    {

                        MessageBox.Show("producto fue actualizado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencia_productos_comercial.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar este producto.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                try
                {
                    respuesta = ds.Actualizarpos(obe);
                    if (respuesta.Equals("Actualizado"))
                    {

                        MessageBox.Show("producto fue actualizad0.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencia_productos_comercial.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizada este producto.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }
    }
}
