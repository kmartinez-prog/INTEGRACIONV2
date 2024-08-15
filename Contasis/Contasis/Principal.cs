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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void origenDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrRegistrarConexion frm002 = new FrRegistrarConexion();
            frm002.Show();
        }

        private void accesoAUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm001 = new FrmUsuarios();
            frm001.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Fecha Actual : "+DateTime.Now.ToLongDateString();
            toolStripStatusLabel2.Text = "| Hora Actual : " + DateTime.Now.ToString("hh:mm:ss");
            toolStripStatusLabel4.Text = "| Usuario Actual : " + Properties.Settings.Default.Usuario;
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "| Hora Actual : " + DateTime.Now.ToString("hh:mm:ss");
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAyuda frm008 = new FrmAyuda();
            frm008.Show();
        }

        private void estructuraDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstructura frm003 = new FrmEstructura();
            frm003.Show();
        }

        private void inconsistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInconsistencia frm007 = new FrmInconsistencia();
            frm007.Show();
        }

        private void integradorContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIntegradorConta frm004 = new FrmIntegradorConta();
            frm004.Show();
        }
    }
}
