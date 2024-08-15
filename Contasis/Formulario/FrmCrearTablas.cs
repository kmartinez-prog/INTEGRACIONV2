using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Contasis
{
    public partial class FrmCrearTablas : Form
    {
        public FrmCrearTablas(string parametro1)
        {
            InitializeComponent();
            this.txtcadena.Text = parametro1;
        }
        int contador = 0;
        int contador1 = 0;
        int contador2 = 0;
        int contador3 = 0;
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void FrmCrearTablas_Load(object sender, EventArgs e)
        {
           
        }

        private void btncreando_Click(object sender, EventArgs e)
        {
            if (rbfinanciero.Checked == true)
            MessageBox.Show("Se Creara las tablas y index para Financiero Sql", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            crearfinanciero objetconexion = new crearfinanciero();
            objetconexion.crearventas(txtcadena.Text);
            timer1.Enabled = true;

            crearfinanciero objetconexion1 = new crearfinanciero();
            objetconexion1.crearcompras(txtcadena.Text);
            timer2.Enabled = true;

            crearfinanciero objetconexion2 = new crearfinanciero();
            objetconexion2.crearadicional(txtcadena.Text);
            timer3.Enabled = true;

            crearfinanciero objetconexion3 = new crearfinanciero();
            objetconexion3.crearindex(txtcadena.Text);
            timer4.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            contador++;
            lblventa.Text = "creando tabla " + contador.ToString() + " %";
            if (progfventas.Value < 100)
            {
                progfventas.Value++;
            }
            if (progfventas.Value == 100)
            {
                timer1.Enabled = false;
                contador = 0;
            }

        }

        private void lblventa_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            contador1++;
            lblcompras.Text = "creando tabla " + contador1.ToString() + " %";
            if (progfcompras.Value < 100)
            {
                progfcompras.Value++;
            }
            if (progfcompras.Value == 100)
            {
                timer2.Enabled = false;
            }

        }

        private void progfventas_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            contador2++;
            lblotros.Text = "creando tabla " + contador2.ToString() + " %";
            if (progvarios.Value < 100)
            {
                progvarios.Value++;
            }
            if (progvarios.Value == 100)
            {
                timer3.Enabled = false;
            }

            if (progfinal.Value < 100)
            {
                progfinal.Value++;
            }
            if (progfinal.Value == 100)
            {
                timer3.Enabled = false;
            }

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            contador3++;
            lblindex.Text = "creando Index " + contador3.ToString() + " %";
            if (progindex.Value < 100)
            {
                progindex.Value++;
            }
            if (progindex.Value == 100)
            {
                timer4.Enabled = false;
            }
        }
    }
    }

