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
    public partial class FrmEliminarruc : Form
    {
        public FrmEliminarruc(string codigo, string nombre)
        {
            InitializeComponent();
            txtcodigo.Text = codigo;
            txtnombre.Text = nombre;
        }

        private void FrmEliminarruc_Load(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                Clase.rucpropiedades obe = new Clase.rucpropiedades();
                obe.ruc = txtcodigo.Text.Trim();
                obe.empresa = txtnombre.Text.Trim();
                

                if (Properties.Settings.Default.cadenaPostPrincipal == "")

                {
                    Clase.ruc ds = new Clase.ruc();
                    respuesta = ds.Eliminar(obe);
                    if (respuesta.Equals("Eliminar"))
                    {
                        FrmRucemisor.instance.Grilla1();
                        MessageBox.Show("ruc fue eliminado", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar este ruc.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ruc_postgres ds = new ruc_postgres();
                    respuesta = ds.Eliminar(obe);
                    if (respuesta.Equals("Eliminar"))
                    {
                        FrmRucemisor.instance.Grilla1();
                        MessageBox.Show("ruc fue eliminado", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar este ruc", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Hide();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
