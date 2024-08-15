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
    public partial class FrmEliminarUsuario : Form
    {
        public FrmEliminarUsuario(string codigo, string nombre)
        {
            InitializeComponent();
            txtcodigo.Text = codigo;
            txtnombre.Text = nombre;
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
                Clase.usuarioPropiedad obe = new Clase.usuarioPropiedad();
                obe.codigo = txtcodigo.Text;
                obe.nombre = txtnombre.Text;
                obe.password = "";

                if (Properties.Settings.Default.cadenaPostPrincipal == "")

                {
                    Clase.usuario ds = new Clase.usuario();
                    respuesta = ds.Eliminar(obe);
                    if (respuesta.Equals("Eliminar"))
                    {
                        FrmUsuarios.instance.grilla1();
                        MessageBox.Show("usuario fue eliminado", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar este usuario", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    usuario_postgres ds = new usuario_postgres();
                    respuesta = ds.Eliminar(obe);
                    if (respuesta.Equals("Eliminar"))
                    {
                        FrmUsuarios.instance.grilla1();
                        MessageBox.Show("usuario fue eliminado", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar este usuario", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }




            }
            catch (Exception ex)
            {

                MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmEliminarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Hide();
            }
        }

        private void FrmEliminarUsuario_Load(object sender, EventArgs e)
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
    }
}
