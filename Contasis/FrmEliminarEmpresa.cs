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
    public partial class FrmEliminarEmpresa : Form
    {
        public FrmEliminarEmpresa(string codigo,string nombre)
        {
            InitializeComponent();
            txtcodigo.Text = codigo;
            txtnombreempresa.Text = nombre; 
        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void FrmEliminarEmpresa_Load(object sender, EventArgs e)
        {
             
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    string respuesta = "";
                    Clase.empresaPropiedades obe = new Clase.empresaPropiedades();
                    obe.codempresa = txtcodigo.Text;
                    obe.empresa = txtnombreempresa.Text;
                    Clase.Empresas ds = new Clase.Empresas();
                    respuesta = ds.eliminaremp(obe);
                    if (respuesta.Equals("Eliminar"))
                    {
                        FrmEmpresas.instance.grilla1();
                        MessageBox.Show("Empresa fue eliminada", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar esta empresa", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    string respuesta = "";
                    Clase.empresaPropiedades obe = new Clase.empresaPropiedades();
                    obe.codempresa = txtcodigo.Text;
                    obe.empresa = txtnombreempresa.Text;
                    Clase.Empresas ds = new Clase.Empresas();
                    respuesta = ds.eliminaremp_postgres(obe);
                    if (respuesta.Equals("Eliminar"))
                    {
                        FrmEmpresas.instance.grilla1();
                        MessageBox.Show("Empresa fue eliminada", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar esta empresa", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }





        }

        private void FrmEliminarEmpresa_KeyDown(object sender, KeyEventArgs e)
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
