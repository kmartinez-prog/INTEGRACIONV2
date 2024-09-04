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
    public partial class Frm_comprasEditor : Form
    {
        public Frm_comprasEditor(string idcompras, string ffechadoc,
                     string ffechaven, string ccoddoc, string cserie, string cnumero, string ctipdoc, string crazsoc,
                    string ruc, string base1, string nigv1, string ntots, string ntc, string cmreg,
                    string cctabase, string cctatot, string ccond, string ccodcos, string ccodcos2)
        {
            InitializeComponent();
            txtidcompras.Text = idcompras;
            txtffechadoc.Text = ffechadoc;
            txtffechaven.Text = ffechaven;
            txtccoddoc.Text = ccoddoc;
            txtcserie.Text = cserie;
            txtcnumero.Text = cnumero;
            txtctipdoc.Text = ctipdoc;
            txtcrazsoc.Text = crazsoc;
            txtruc.Text = ruc;
            txtbase1.Text = base1;
            txtnigv1.Text = nigv1;
            txtntots.Text = ntots;
            txtntc.Text = ntc;
            txtcmreg.Text = cmreg;
            txtcctabase.Text = cctabase;
            txtcctatot.Text = cctatot;
            txtccond.Text = ccond;
            txtccodcos.Text = ccodcos;
            txtccodcos2.Text = ccodcos2;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            Clase.Compras_propiedadescs obe = new Clase.Compras_propiedadescs();
            Clase.Compras_inconsistencias ds = new Clase.Compras_inconsistencias();
            obe.idcompras = txtidcompras.Text;
            obe.ffechadoc = txtffechadoc.Text;
            obe.fechaven = txtffechaven.Text;
            obe.ccoddoc = txtctipdoc.Text.Trim();
            obe.cserie = txtcserie.Text.Trim();
            obe.cnumero = txtcnumero.Text.Trim();
            obe.ctipdoc = txtctipdoc.Text.Trim();
            obe.crazsoc = txtcrazsoc.Text.Trim();
            obe.ccodruc = txtcrazsoc.Text.Trim();
            obe.nbase1 = txtbase1.Text;
            obe.nigv1 = txtnigv1.Text;
            obe.ntots = txtntots.Text;
            obe.ntc = txtntc.Text;
            obe.cmreg = txtcmreg.Text.Trim();
            obe.cctabase = txtcctabase.Text.Trim();
            obe.cctatot = txtcctatot.Text.Trim();
            obe.ccond = txtccond.Text.Trim().ToUpper();
            obe.ccodcos = txtccodcos.Text.Trim();
            obe.ccodcos2 = txtccodcos2.Text.Trim();


            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    respuesta = ds.Actualizarsql(obe);
                    if (respuesta.Equals("Actualizado"))
                    {

                        MessageBox.Show("Compras fue actualizada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistenciasCompras.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar esa venta.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        MessageBox.Show("Compras fue actualizada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistenciasCompras.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizada esa venta.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }

        }

        private void Frm_comprasEditor_Load(object sender, EventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Frm_comprasEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Hide();
            }
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    string respuesta = "";
                    Clase.Compras_propiedadescs obe = new Clase.Compras_propiedadescs();

                    obe.idcompras = txtidcompras.Text;

                    Clase.Compras_inconsistencias ds = new Clase.Compras_inconsistencias();
                    respuesta = ds.eliminarsql(obe);
                    if (respuesta.Equals("Eliminar"))
                    {

                        MessageBox.Show("Venta fue eliminada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistenciasCompras.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar esa venta.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    obe.idcompras = txtidcompras.Text;
                    Clase.Compras_inconsistencias ds = new Clase.Compras_inconsistencias();

                    respuesta = ds.eliminarpos(obe);
                    if (respuesta.Equals("Eliminar"))
                    {

                        MessageBox.Show("Venta fue eliminada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistenciasCompras.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar esa venta.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }
    }
}
