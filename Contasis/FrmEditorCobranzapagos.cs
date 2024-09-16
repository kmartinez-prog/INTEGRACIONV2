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
                    string Cdoccan, string Csercan, string Cnumcan, string Cmoncan, string Nimporcan, string Ntipcam,
                    string Ccodpago, string Ccoddoc, string Cserie, string Cnumero, string Ffechadoc, string Ccodruc,
                    string Crazsoc, string Nimportes, string Nimported, string Ccodcue, string Ccodcos, string Ccodcos2, 
                    string obserror)
        {
            InitializeComponent();
            txtidcobranzapago.Text = Idcobranzas;
            txtffechacan.Text = Ffechacan;
            txtdocucan.Text = Cdoccan;
            txtseriecan.Text = Csercan;
            txtnumerocan.Text = Cnumcan;
            txtcuencon.Text = Cmoncan;
            txtmoneda.Text = Nimporcan;
            txtimporte.Text = Ntipcam;
            txttipocambio.Text = Ccodpago;
            txtmediopago.Text = Ccoddoc;
            txtdocu.Text = Cserie;
            txtserie.Text = Cnumero;
            txtnumero.Text = Ffechadoc;
            txtFfechadoc.Text = Ccodruc;
            txtFfechaven.Text = Crazsoc;
            txtcctatot.Text = Nimportes;
            txtccond.Text = Nimported;
            txtccodcos.Text = Ccodcue;
            txtccodcos2.Text = Ccodcos;
            txtcc.Text = Ccodcos2;
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
                this.Close();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
         /**   string respuesta = "";
            Clase.Cobranzas_propiedades obe = new Clase.Cobranzas_propiedades();
            Clase.Conbranzas_Inconsistencia ds = new Clase.Conbranzas_Inconsistencia();
            obe.Idcobranzas = txtidcobranzapago.Text;
            obe.Ffechadoc = txtffechacan.Text;
            obe.Ffechaven = txtdocucan.Text;
            obe.Ccoddoc = txtmoneda.Text.Trim();
            obe.Cserie = txtnumerocan.Text.Trim();
            obe.Cnumero = txtcuencon.Text.Trim();
            obe.Ctipdoc = txtmoneda.Text.Trim();
            obe.Crazsoc = txtimporte.Text.Trim();
            obe.Cruc = txtimporte.Text.Trim();
            obe.Base1 = txtmediopago.Text;
            obe.Nigv1 = txtdocu.Text;
            obe.Ntots = txtserie.Text;
            obe.Ntc = txtnumero.Text;
            obe.Cmreg = txtFfechadoc.Text.Trim();
            obe.Cctabase = txtFfechaven.Text.Trim();
            obe.Cctatot = txtcctatot.Text.Trim();
            obe.Ccond = txtccond.Text.Trim().ToUpper();
            obe.Ccodcos = txtccodcos.Text.Trim();
            obe.Ccodcos2 = txtccodcos2.Text.Trim();
            obe.Ccodpresu = txtccodpresu.Text.Trim();


            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    respuesta = ds.Actualizarsql(obe);
                    if (respuesta.Equals("Actualizado"))
                    {

                        MessageBox.Show("Cobranza fue actualizada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencia.instance.llenar_grilla();
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
                        FrmInconsistencia.instance.llenar_grilla();
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
            }*/
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
