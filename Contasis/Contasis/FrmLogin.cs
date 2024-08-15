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
    public partial class FrmLogin : Form
    {
        int  nveces;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbusuario.Text == "")
            {
                MessageBox.Show("Debe de Seleccionar un usuario", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbusuario.Focus();
            }
            else
            {

                if (txtclave.Text == "contasis")
                {
                    Properties.Settings.Default.Usuario = cmbusuario.Text;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                   
                    Principal menu = new Principal();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                   if (nveces < 2)
                    {
                        MessageBox.Show("la clave esta errada", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtclave.Text = "";
                        txtclave.Focus();
                        nveces += 1;
                    }
                    else
                    {
                        MessageBox.Show("Acabaste tus 3 Intentos", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Hide();
                        this.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }
    }
}
