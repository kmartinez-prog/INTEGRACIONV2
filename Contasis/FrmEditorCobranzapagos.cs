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
    public partial class FrmEditorCobranzapagos : Form
    {
        public FrmEditorCobranzapagos(string Idcobranzas, string Ffechacan,
                    string Cdoccan, string Csercan, string Cnumcan,string Ccuecan, string Cmoncan, string Nimporcan, string Ntipcam,
                    string Ccodpago, string Ccoddoc, string Cserie, string Cnumero, string Ffechadoc, 
                    string Ccodruc,  string Crazsoc, string Nimportes, string Nimported, 
                    string Ccodcue, string Ccodcos, string Ccodcos2, 
                    string obserror)
        {
            InitializeComponent();
            txtidcobranzapago.Text = Idcobranzas;
            txtffechacan.Text = Ffechacan;
            txtdocucan.Text = Cdoccan;
            txtseriecan.Text = Csercan;
            txtnumerocan.Text = Cnumcan;
            txtccuecan.Text = Ccuecan;
            txtmoneda.Text = Cmoncan;
            txtimporte.Text = Nimporcan;
            txttipocambio.Text = Ntipcam;
            txtmediopago.Text = Ccodpago;
            txtdocu.Text = Ccoddoc;
            txtserie.Text = Cserie;
            txtnumero.Text = Cnumero;
            txtFfechadoc.Text = Ffechadoc;
            txtruc.Text = Ccodruc;
            txtrazon.Text = Crazsoc;
            txtcodcue.Text = Ccodcue;
            txtImportesoles.Text= Nimportes;
            txtImportedolar.Text = Nimported;
            txtcosto.Text = Ccodcos;
            txtcosto2.Text = Ccodcos2;
            txtobservacion.Text = obserror;
        }

        private void FrmEditorCobranzapagos_Load(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    string respuesta = "";
                    Clase.Cobranzas_propiedades obe = new Clase.Cobranzas_propiedades();
                    obe.Idcobranzas = txtidcobranzapago.Text;
                    Clase.Conbranzas_Inconsistencia ds = new Clase.Conbranzas_Inconsistencia();
                    respuesta = ds.eliminarsql(obe);
                    FrmInconsistencias_Cobranza.instance.llenar_grilla();
                    if (respuesta.Equals("Eliminar"))
                    {
                        MessageBox.Show("Cobranza fue eliminada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar esa Cobranza.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Clase.Cobranzas_propiedades obe = new Clase.Cobranzas_propiedades();

                    obe.Idcobranzas = txtidcobranzapago.Text;
                    Clase.Conbranzas_Inconsistencia ds = new Clase.Conbranzas_Inconsistencia();

                    respuesta = ds.eliminarpos(obe);
                    if (respuesta.Equals("Eliminar"))
                    {
                        MessageBox.Show("Cobranza fue eliminada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar esa cobranza.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                FrmInconsistencias_Cobranza.instance.llenar_grilla();
                this.Close();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
           string respuesta = "";
            Clase.Cobranzas_propiedades obe = new Clase.Cobranzas_propiedades();
            Clase.Conbranzas_Inconsistencia ds = new Clase.Conbranzas_Inconsistencia();

            obe.Idcobranzas= txtidcobranzapago.Text;
            obe.Ffechacan= txtffechacan.Text;
            obe.Cdoccan= txtdocucan.Text;
            obe.Csercan= txtseriecan.Text;
            obe.Cnumcan= txtnumerocan.Text;
            obe.Ccuecan= txtccuecan.Text;
            obe.Cmoncan= txtmoneda.Text;
            obe.Nimporcan= txtimporte.Text;
            obe.Ntipcam= txttipocambio.Text;
            obe.Ccodpago= txtmediopago.Text;
            obe.Ccoddoc= txtdocu.Text;
            obe.Cserie= txtserie.Text;
            obe.Cnumero= txtnumero.Text;
            obe.Ffechadoc= txtFfechadoc.Text;
            obe.Ccodruc= txtruc.Text;
            obe.Crazsoc = txtrazon.Text;
            obe.Ccodcue= txtcodcue.Text;
            obe.Nimportes= txtImportesoles.Text;
            obe.Nimported= txtImportedolar.Text;
            obe.Ccodcos= txtcosto.Text;
            obe.Ccodcos2= txtcosto2.Text;
            obe.Obserror = txtobservacion.Text;



            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    respuesta = ds.Actualizarsql(obe);
                    if (respuesta.Equals("Actualizado"))
                    {

                        MessageBox.Show("Cobranza fue actualizada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencias_Cobranza.instance.llenar_grilla();

                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar esa Cobranza.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
                FrmInconsistencias_Cobranza.instance.llenar_grilla();
            }
            else
            {
                try
                {
                    respuesta = ds.Actualizarpos(obe);
                    if (respuesta.Equals("Actualizado"))
                    {

                        MessageBox.Show("Cobranza fue actualizada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencias_Cobranza.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizada esa Cobranza.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
                FrmInconsistencias_Cobranza.instance.llenar_grilla();
            }
        }

        private void FrmEditorCobranzapagos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Hide();
            }
        }
    }
}
