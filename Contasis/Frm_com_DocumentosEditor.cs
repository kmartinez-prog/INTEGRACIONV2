using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace Contasis
{
    public partial class Frm_com_DocumentosEditor : Form
    {
        public Frm_com_DocumentosEditor(string Id, string Modulo, string Cod_movimiento,
                string Cod_documento, string Serie, string Numero, string Cod_entiedad, string Nombre_entidad, string Tipo_doc_entidad,
                string Ruc_rz, string Razon_social, string Direc_cliente, string Ubigeo, string Contacto, string Nomb_contacto,
                string Fec_documento, string Fec_vencimiento, string Fec_almacen, string Condicion_pago, string Moneda, string Tipo_cambio,
                string Serie_guia, string Numero_guia, string Inf_adicional_doc, string Cod_vendedor, string Cod_clasi_bbss,
                string Otros_conceptos, string Orden_compra, string Tip_referencia, string Fec_doc_referencia, string Serie_doc_referencia,
                string Numero_referencia, string Cod_motivo_notacredito, string Motivo_notacredito, string Reg_especial, string Cod_detraccion,
                string Porcentaje_detraccion, string Fec_deposito, string Contancia_deposito, string Cod_percepcion, string Porcentaje_percepcion,
                string Documento_dentrofuera, string Base_imp1, string Igv1, string Base_imp2, string Igv2, string Base_imp3,
                string Igv3, string Imp_icbper, string Imp_inafecto, string Imp_exonerado, string Imp_isc, string Base_ivap, string Igv_ivap,
                string Imp_anticipo, string Total, string Observacion)
        {
            InitializeComponent();
            txtId.Text = Id.Trim();
            txtModulo.Text = Modulo.Trim();
            txtCod_movimiento.Text = Cod_movimiento.Trim();
            txtCod_documento.Text = Cod_documento.Trim();
            txtSerie.Text = Serie.Trim();
            txtNumero.Text = Numero.Trim();
            txtCod_entiedad.Text = Cod_entiedad.Trim();
            txtNombre_entidad.Text = Nombre_entidad.Trim();
            txtTipo_doc_entidad.Text = Tipo_doc_entidad.Trim();
            txtRuc_rz.Text = Ruc_rz.Trim();
            txtRazon_social.Text = Razon_social.Trim();
            txtDirec_cliente.Text =Direc_cliente.Trim();
            txtUbigeo.Text = Ubigeo.Trim();
            txtContacto.Text = Contacto.Trim();
            txtNomb_contacto.Text = Nomb_contacto.Trim();
            txtFec_documento.Text = Fec_documento.Trim();
            txtFec_vencimiento.Text = Fec_vencimiento;
            txtFec_almacen.Text = Fec_almacen;
            txtCondicion_pago.Text = Condicion_pago.Trim();
            txtMoneda.Text = Moneda.Trim();
            txtTipo_cambio.Text = Tipo_cambio;
            txtSerie_guia.Text = Serie_guia;
            txtNumero_guia.Text =Numero_guia;
            txtInf_adicional_doc.Text = Inf_adicional_doc;
            txtCod_vendedor.Text = Cod_vendedor.Trim();
            txtCod_clasi_bbss.Text = Cod_clasi_bbss;
            txtOtros_conceptos.Text = Otros_conceptos;
            txtOrden_compra.Text = Orden_compra;
            txtTip_referencia.Text = Tip_referencia;
            txtFec_doc_referencia.Text = Fec_doc_referencia;
            txtSerie_doc_referencia.Text = Serie_doc_referencia;
            txtNumero_referencia.Text = Numero_referencia;
            txtCod_motivo_notacredito.Text = Cod_motivo_notacredito;
            txtMotivo_notacredito.Text = Motivo_notacredito;
            txtReg_especial.Text = Reg_especial;
            txtCod_detraccion.Text = Cod_detraccion;
            txtPorcentaje_detra.Text = Porcentaje_detraccion;
            txtFec_deposito.Text = Fec_deposito;
            txtContancia_deposito.Text = Contancia_deposito;
            txtCod_percepcion.Text = Cod_percepcion;
            txtPorcentaje_percepcion.Text = Porcentaje_percepcion;
            txtDocumento_dentrofuera.Text = Documento_dentrofuera;
            txtBase_imp1.Text = Base_imp1;
            txtIgv1.Text = Igv1;
            txtBase_imp2.Text = Base_imp2;
            txtIgv2.Text = Igv2;
            txtBase_imp3.Text = Base_imp3;
            txtIgv3.Text = Igv3;
            txtImp_icbper.Text = Imp_icbper;
            txtImp_inafecto.Text = Imp_inafecto;
            txtImp_exonerado.Text = Imp_exonerado;
            txtImp_isc.Text = Imp_isc;
            txtBase_ivap.Text = Base_ivap;
            txtIgv_ivap.Text = Igv_ivap;
            txtImp_anticipo.Text = Imp_anticipo;
            txtTotal.Text = Total;
            txtObservacion.Text = Observacion;
          
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }

    
        private void Frm_com_DocumentosEditor_Load(object sender, EventArgs e)
        {
            this.llenar_grilla();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    string respuesta = "";
                    Clase.Comercial_documentoPropiedades obe = new Clase.Comercial_documentoPropiedades();
                    obe.Id = txtId.Text;
                    Clase.Documentos_comercial_Inconsistencias registro = new Clase.Documentos_comercial_Inconsistencias();

                    respuesta = registro.eliminarsql(obe);
                    if (respuesta.Equals("Eliminar"))
                    {
                        MessageBox.Show("registro fue eliminado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencias_comercial.instance.llenar_grilla();

                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar este registro comercial.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Clase.Comercial_documentoPropiedades obe = new Clase.Comercial_documentoPropiedades();

                    obe.Id = txtId.Text;
                    Clase.Documentos_comercial_Inconsistencias ds = new Clase.Documentos_comercial_Inconsistencias();

                    respuesta = ds.eliminarpos(obe);
                    if (respuesta.Equals("Eliminar"))
                    {

                        MessageBox.Show("registro fue eliminado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencias_comercial.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar este registro  comercial.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();

            
            }
            
        }
        public void llenar_grilla()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {

                    Clase.Comercial_documentoPropiedades obj = new Clase.Comercial_documentoPropiedades();
                    Clase.Documentos_comercial_Inconsistencias verlista = new Clase.Documentos_comercial_Inconsistencias();
                    Clase.Documentos_comercial_Inconsistencias actuasql = new Clase.Documentos_comercial_Inconsistencias();

                    obj.Id = txtId.Text;

                    
                    this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    this.dataGridView2.Refresh();

                    dataGridView2.DataSource = verlista.listar_detalle_sql(obj);
                    dataGridView2.AllowUserToAddRows = false;
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    ////  dataGridView2.ReadOnly = true;
                    if (dataGridView2.IsCurrentCellDirty)
                    {
                        dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }
                    if (dataGridView2.Rows.Count > 0)
                    {
                        this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                        this.dataGridView2.Refresh();
                        
                        
                    }
                    else
                    {

                        MessageBox.Show("No Existe datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dataGridView2.Refresh();
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                }
                catch
                {
                    ////(Exception ex)  MessageBox.Show(ex.ToString(), "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                try
                {

                    Clase.Comercial_documentoPropiedades obj = new Clase.Comercial_documentoPropiedades();
                    Clase.Documentos_comercial_Inconsistencias listapos = new Clase.Documentos_comercial_Inconsistencias();
                    Clase.Documentos_comercial_Inconsistencias actuapos = new Clase.Documentos_comercial_Inconsistencias();

                    obj.Id = txtId.Text;

                    dataGridView2.Refresh();
                    dataGridView2.DataSource = listapos.listar_detalle_postgres(obj);
                    dataGridView2.AllowUserToAddRows = false;
                    this.dataGridView2.Refresh();

                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    /////dataGridView2.ReadOnly = true;
                    if (dataGridView2.IsCurrentCellDirty)
                    {
                        dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }


                    if (dataGridView2.Rows.Count > 0)
                    {
                        this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                        this.dataGridView2.Refresh();
                        
                    }
                    else
                    {
                    }
                    this.dataGridView2.Refresh();
                    this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                    dataGridView2.FirstDisplayedScrollingRowIndex = 1;
                    dataGridView2.HorizontalScrollingOffset = 1;

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            Clase.Comercial_documentoPropiedades obe = new Clase.Comercial_documentoPropiedades();
            Clase.Documentos_comercial_Inconsistencias ds = new Clase.Documentos_comercial_Inconsistencias();

            obe.Id= txtId.Text.Trim();
            obe.Cod_movimiento = txtCod_movimiento.Text.Trim();
            obe.Cod_documento = txtCod_documento.Text.Trim();
            obe.Serie = txtSerie.Text.Trim();
            obe.Numero = txtNumero.Text.Trim();
            obe.Cod_entiedad = txtCod_entiedad.Text.Trim();
            obe.Nombre_entidad = txtNombre_entidad.Text.Trim();
            obe.Tipo_doc_entidad = txtTipo_doc_entidad.Text.Trim();
            obe.Ruc_rz = txtRuc_rz.Text.Trim();
            obe.Razon_social = txtRazon_social.Text.Trim();
            obe.Direc_cliente = txtDirec_cliente.Text.Trim();
            obe.Ubigeo = txtUbigeo.Text.Trim();
            obe.Contacto = txtContacto.Text.Trim();
            obe.Nomb_contacto = txtNomb_contacto.Text.Trim();
            obe.Fec_documento = txtFec_documento.Text.Trim();
            obe.Fec_vencimiento = txtFec_vencimiento.Text.Trim();
            obe.Fec_almacen = txtFec_almacen.Text.Trim();
            obe.Condicion_pago = txtCondicion_pago.Text.Trim();
            obe.Moneda = txtMoneda.Text.Trim();
            obe.Tipo_cambio = txtTipo_cambio.Text.Trim();
            obe.Serie_guia = txtSerie_guia.Text.Trim();
            obe.Numero_guia = txtNumero_guia.Text.Trim();
            obe.Inf_adicional_doc = txtInf_adicional_doc.Text.Trim();
            obe.Cod_vendedor = txtCod_vendedor.Text.Trim();
            obe.Cod_clasi_bbss = txtCod_clasi_bbss.Text.Trim();
            obe.Otros_conceptos = txtOtros_conceptos.Text.Trim();
            obe.Orden_compra = txtOrden_compra.Text.Trim();
            obe.Tip_referencia = txtTip_referencia.Text.Trim();
            obe.Fec_doc_referencia = txtFec_doc_referencia.Text.Trim();
            obe.Serie_doc_referencia = txtSerie_doc_referencia.Text.Trim();
            obe.Numero_referencia = txtNumero_referencia.Text.Trim();
            obe.Cod_motivo_notacredito = txtCod_motivo_notacredito.Text.Trim();
            obe.Motivo_notacredito = txtMotivo_notacredito.Text.Trim();
            obe.Reg_especial = txtReg_especial.Text.Trim();
            obe.Cod_detraccion = txtCod_detraccion.Text.Trim();
            obe.Porcentaje_detraccion = txtPorcentaje_detra.Text.Trim();
            obe.Fec_deposito = txtFec_deposito.Text.Trim();
            obe.Contancia_deposito = txtContancia_deposito.Text.Trim();
            obe.Cod_percepcion = txtCod_percepcion.Text.Trim();
            obe.Porcentaje_percepcion = txtPorcentaje_percepcion.Text.Trim();
            obe.Documento_dentrofuera = txtDocumento_dentrofuera.Text.Trim();
            obe.Base_imp1 = txtBase_imp1.Text.Trim();
            obe.Igv1 = txtIgv1.Text.Trim();
            obe.Base_imp2 = txtBase_imp2.Text.Trim();
            obe.Igv2 = txtIgv2.Text.Trim();
            obe.Base_imp3 = txtBase_imp3.Text.Trim();
            obe.Igv3 = txtIgv3.Text.Trim();
            obe.Imp_icbper = txtImp_icbper.Text.Trim();
            obe.Imp_inafecto = txtImp_inafecto.Text.Trim();
            obe.Imp_exonerado = txtImp_exonerado.Text.Trim();
            obe.Imp_isc = txtImp_isc.Text.Trim();
            obe.Base_ivap = txtBase_ivap.Text.Trim();
            obe.Igv_ivap = txtIgv_ivap.Text.Trim();
            obe.Imp_anticipo = txtImp_anticipo.Text.Trim();
            obe.Total = txtTotal.Text.Trim();

            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    respuesta = ds.Actualizarsql(obe);
                    if (respuesta.Equals("Actualizado"))
                    {

                        MessageBox.Show("Documento fue actualizado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencias_comercial.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar este documento.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        MessageBox.Show("documento fue actualizad0.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencias_comercial.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizada este documento.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void salvar()
        {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                connection.Open();
                try
                {
                    string query = "UPDATE com_detalledocumento  set ccodalma='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[0].Value).Trim() + "'," +
                                   " ccodprod ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[1].Value).Trim() + "'," +
                                   " ccodmed  ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[2].Value).Trim() + "'," +
                                   " ccodlote ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[3].Value).Trim() + "'," +
                                   " nuniori  ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[4].Value).Trim() + "'," +
                                   " nvvori ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[5].Value).Trim() + "'," +
                                   " npvori ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[6].Value).Trim() + "'," +
                                   " nvalor ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[7].Value).Trim() + "'," +
                                   " nigvtot ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[8].Value).Trim() + "'," +
                                   " ntotori ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[9].Value).Trim() + "'," +
                                   " npigv ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[10].Value).Trim() + "'," +
                                   " ccodcos ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[11].Value).Trim() + "'," +
                                   " ccodcos2 ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[12].Value).Trim() + "'," +
                                   " ccodpresu ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[13].Value).Trim() + "'," +
                                   " cctaprod ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[14].Value).Trim() + "'," +
                                   " npordscu ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[15].Value).Trim() + "'," +
                                   " ndsctos ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[16].Value).Trim() + "'," +
                                   " ccodisc ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[17].Value).Trim() + "'," +
                                   " nporisc ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[18].Value).Trim() + "'," +
                                   " nisc ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[19].Value).Trim() + "'," +
                                   " tipo_isc ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[20].Value).Trim() + "'," +
                                   " mdscl ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[21].Value).Trim() + "'," +
                                   " ffecfablote ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[22].Value).Trim() + "'," +
                                   " ffecvenlote ='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[23].Value).Trim() + "'" +
                                   " WHERE iddocumento='" + txtId.Text.Trim() + "' and iddetalledocumento='" + Convert.ToString(dataGridView2.SelectedRows[0].Cells[24].Value).Trim() + "'";
                                    
                                    SqlCommand commando1 = new SqlCommand(query, connection);
                                    commando1.ExecuteNonQuery();
                                    this.llenar_grilla();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.ToString());

                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }

                }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             

          
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {



          

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea Gurdar el dato modificado.?", "Contasis Corp.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.salvar();
                this.llenar_grilla();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.llenar_grilla();
            }

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }
    }
}
