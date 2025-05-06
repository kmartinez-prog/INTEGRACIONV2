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
    public partial class FrmAyuda : Form
    {
        public FrmAyuda()
        {
            InitializeComponent();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void FrmAyuda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Hide();
            }
        }

        private void FrmAyuda_Load(object sender, EventArgs e)
        {
            label2.Text = " Version del sistema :  " + Properties.Settings.Default.version;

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Caja.Text = "Este modulo de Integración permite vincular la información de su sistema interno con el sistema de Contasis Corp. Financiero Sql. mediante una base de datos intermedia en donde lo que el cliente guarde ahi Contasis lo estaria leyendo para el su propio modulo.";
            payuda2.Visible = false;
            payuda3.Visible = false;
            payuda4.Visible = false; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Caja.Text = "Consiste en cargar desde su sistema interno la información de las compras y ventas hacia el sistema Financiero Sql de Contasis Corp. con la finalidad de generar asientos contables y todo el  proceso contable que actualmente la Sunat solicita a sus Contribuyentes como en el caso del SIRE.";
            payuda2.Visible = true;
            payuda3.Visible = false;
            payuda4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Caja.Text = "Como primer paso tener instalado el sistema Financiero de Contasis Corp. luego dentro del Modulo de Integración ir a la opción de configuración y dar click en Origen de datos para crear la base de datos en SQL con sus respectivas tablas. ";
            payuda2.Visible = false;
            payuda3.Visible = true;
            payuda4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Caja.Text = "Esta relacionado con el Sistenama Financiero Sql de Contasis Corp.";
            
            payuda2.Visible = false;
            payuda3.Visible = false;
            payuda4.Visible = true;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
