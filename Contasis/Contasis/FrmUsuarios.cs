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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FrmUsuedit Frnuevo = new FrmUsuedit();
            Frnuevo.Show();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            FrmUsuedit Fredit = new FrmUsuedit();
            Fredit.Show();
        }
    }
}
