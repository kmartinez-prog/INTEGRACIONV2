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
    public partial class FrmModificarEmpresa : Form
    {
        public FrmModificarEmpresa(string codigo,string nombre)
        {
            InitializeComponent();
            txtnombreempresa.CharacterCasing = CharacterCasing.Upper;
            txtcodigo.Text = codigo;
            txtnombreempresa.Text = nombre; 
        }
         private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void FrmModificarEmpresa_Load(object sender, EventArgs e)
        {
            txtnombreempresa.Focus(); 
        }
        private void btngrabar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                Clase.empresaPropiedades obe = new Clase.empresaPropiedades();
                obe.codempresa = txtcodigo.Text;
                obe.empresa = txtnombreempresa.Text;
                Clase.Empresas ds = new Clase.Empresas();
                respuesta = ds.actualizaremp(obe);
                if (respuesta.Equals("Actualizado"))
                {
                    FrmEmpresas.instance.grilla1();
                    MessageBox.Show("Dato actualizado en empresa","Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar esta empresa", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtnombreempresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btngrabar.Focus(); 
            }
        }

        private void FrmModificarEmpresa_KeyDown(object sender, KeyEventArgs e)
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
