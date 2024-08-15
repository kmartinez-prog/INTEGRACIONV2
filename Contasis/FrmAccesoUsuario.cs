using System;
using System.Windows.Forms;

namespace Contasis
{
    public partial class FrmAccesoUsuario : Form
    {
        public FrmAccesoUsuario(string codigo,string nombre,string clave)

        {
            InitializeComponent();
            txtcodigo.Text = codigo;
        }
        

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void FrmAccesoUsuario_Load(object sender, EventArgs e)
        {
            this.grilla_accesos();
        }

        private void FrmAccesoUsuario_KeyDown(object sender, KeyEventArgs e)
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
        public void grilla_accesos()
        {
            try
            {
                Clase.usuarioPropiedad obj = new Clase.usuarioPropiedad();
                Clase.usuario acceso = new Clase.usuario();
                obj.codigo = txtcodigo.Text;
                obj.nombre ="";
                obj.password = "";
                



                  dataGridView1.DataSource = acceso.accesos(obj);
                  dataGridView1.Columns[0].HeaderText = "CODIGO";
                  dataGridView1.Columns[0].MinimumWidth = 50;
                  dataGridView1.Columns[0].Width = 100;
                  dataGridView1.Columns[1].HeaderText = "OPCION";
                  dataGridView1.Columns[1].MinimumWidth = 50;
                  dataGridView1.Columns[1].Width = 250;
           ///       dataGridView1.Columns[2].HeaderText = "ACCESO";
              //    dataGridView1.Columns[2].MinimumWidth = 50;
                ///  dataGridView1.Columns[2].Width = 100;


                

                //DataGridViewCheckBoxColumn dgv = new DataGridViewCheckBoxColumn();
                //dgv.ValueType = typeof(int);
                //dgv.Name = "ACCESO";
                //dataGridView1.Columns.Add(dgv);
                //dataGridView1.Columns.RemoveAt(2);
                //dataGridView1.Columns.Insert(2, dgv);
                //dataGridView1.Columns[2].Width = 50;
                //dataGridView1.Columns[2].HeaderText = "ACCESO";

                /*dataGridView1.Columns[2].HeaderText = "ACCESO";
                dataGridView1.Columns[2].MinimumWidth = 50;
                dataGridView1.Columns[2].Width = 100;
              */



                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.ReadOnly = true;
                if (dataGridView1.IsCurrentCellDirty)
                {
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit); 
                }

                
                if (dataGridView1.Rows.Count - 1 > 0)
                {
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[0].Cells[1];
                    this.dataGridView1.Refresh();
                }
                this.dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
