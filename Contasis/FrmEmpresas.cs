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
    public partial class FrmEmpresas : Form
    {
        
        public static FrmEmpresas instance = null;
        public FrmEmpresas()
        {
            InitializeComponent();
            instance = this;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.cadenaPost == "")
            {
                MessageBox.Show("No se ha registrado la conexión al postgrelSQL." ,"Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                timer1.Enabled = true;
                FrmBuscarEmpresa FrmBus = new FrmBuscarEmpresa();
                FrmBus.Show();
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            
        }
        private void FrmEmpresas_Load(object sender, EventArgs e)
        {
            this.grilla1();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void grilla1()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    Clase.Empresas regis = new Clase.Empresas();
                    dataGridView1.DataSource = regis.Cargar_empresa();
                    dataGridView1.Columns[0].HeaderText = "CODIGO";
                    dataGridView1.Columns[0].MinimumWidth = 50;
                    dataGridView1.Columns[0].Width = 80;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].HeaderText = "EMPRESAS";
                    dataGridView1.Columns[1].MinimumWidth = 50;
                    dataGridView1.Columns[1].Width = 415;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Font = new Font("Arial", 8, FontStyle.Regular);
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.ReadOnly = true;
                    if (dataGridView1.Rows.Count - 1 > 0)
                    {
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[0].Cells[1];
                        this.dataGridView1.Refresh();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error, no se encuentras las tablas.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    Clase.Empresas regis = new Clase.Empresas();
                    dataGridView1.DataSource = regis.Cargar_empresa_postgres();
                    dataGridView1.Columns[0].HeaderText = "CODIGO";
                    dataGridView1.Columns[0].MinimumWidth = 50;
                    dataGridView1.Columns[0].Width = 80;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].HeaderText = "EMPRESAS";
                    dataGridView1.Columns[1].MinimumWidth = 50;
                    dataGridView1.Columns[1].Width = 415;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Font = new Font("Arial", 8, FontStyle.Regular);
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.ReadOnly = true;
                    if (dataGridView1.Rows.Count - 1 > 0)
                    {
                        this.dataGridView1.CurrentCell = this.dataGridView1.Rows[0].Cells[1];
                        this.dataGridView1.Refresh();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error, no se encuentras las tablas.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }




        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Clase.empresaPropiedades obj = new Clase.empresaPropiedades();
                obj.codempresa = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                obj.empresa = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
                FrmModificarEmpresa FrmModEmp = new FrmModificarEmpresa(obj.codempresa, obj.empresa);
                FrmModEmp.Show();
            }
            else
            {
                MessageBox.Show("No Existe registros a modificar", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count-1 == 0)
            {
                MessageBox.Show("No Existe registros a eliminar", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            DialogResult dialogResult = MessageBox.Show("Deseas eliminar el registros seleccionado", "Contasis Corpo. Borrar empresa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Clase.empresaPropiedades obj = new Clase.empresaPropiedades();
                    obj.codempresa = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                    obj.empresa = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
                    FrmEliminarEmpresa FrmEliEmp = new FrmEliminarEmpresa(obj.codempresa, obj.empresa);
                    FrmEliEmp.Show();
                }
                else
                {
                    MessageBox.Show("No Existe registros a eliminar", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
        private void FrmEmpresas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
                Hide();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if(keyData==(Keys.Escape))
                {
                Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
