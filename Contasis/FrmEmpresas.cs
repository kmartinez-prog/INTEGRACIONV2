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
using Npgsql;
namespace Contasis
{
    public partial class FrmEmpresas : Form
    {
        string rucemisor;
        public static FrmEmpresas instance = null;
        public FrmEmpresas()
        {
            InitializeComponent();
            instance = this;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            if (cmbrucemisor.Text == "")
            {
                MessageBox.Show("Debe de Seleccionar ruc emisor para registrar Empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }    


            if (Properties.Settings.Default.cadenaPost == "")
            {
                MessageBox.Show("No se ha registrado la conexión al postgrelSQL." ,"Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                timer1.Enabled = true;
                FrmBuscarEmpresa FrmBus = new FrmBuscarEmpresa(rucemisor);
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
            this.ruc();
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
                    dataGridView1.Columns[1].Width = 405;
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
                catch 
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
                    dataGridView1.Columns[1].Width = 405;
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
                catch 
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
        private void ruc()
        {



            try
            {
                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                {

                    SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                    connection.Open();
                    var command = new System.Data.SqlClient.SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select ltrim(ccodrucemisor)+'-'+ltrim(cdesrucemisor) as emisor  from cg_empemisor where flgactivo='1'";
                    var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);

                    cmbrucemisor.Items.Clear();
                    if (dataset.Tables.Count == 0)
                    {
                        MessageBox.Show("No existe ningún ruc emisor registrado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Close();
                    }
                    else
                    {

                        DataTable dtDatabases = dataset.Tables[0];
                        String NewBase = dataset.Tables[0].Rows[0][0].ToString();
                        cmbrucemisor.Text = dataset.Tables[0].Rows[0][0].ToString();
                        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                        {
                            cmbrucemisor.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                            cmbrucemisor.Refresh();

                        }
                    }

                    connection.Close();
                }
                else
                {
                    NpgsqlConnection conexion = new NpgsqlConnection();
                    conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                    conexion.Open();
                    var command = new NpgsqlCommand();
                    command.Connection = conexion;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select ltrim(ccodrucemisor)||'-'||ltrim(cdesrucemisor)::character(60) as emisor  from cg_empemisor where flgactivo='1'";
                    var adapter = new NpgsqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);

                    cmbrucemisor.Items.Clear();
                    if (dataset.Tables.Count == 0)
                    {
                        MessageBox.Show("No existe ningún ruc emisor registrado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Close();
                    }
                    else
                    {

                        DataTable dtDatabases = dataset.Tables[0];
                        String NewBase = dataset.Tables[0].Rows[0][0].ToString();
                        cmbrucemisor.Text = dataset.Tables[0].Rows[0][0].ToString();
                        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                        {
                            cmbrucemisor.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                            cmbrucemisor.Refresh();

                        }
                    }

                    conexion.Close();

                }
            }
            catch 
            {
                MessageBox.Show("No Existe información de  empresa, favor en registrar empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }



        }

        private void cmbrucemisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            rucemisor = cmbrucemisor.Text.Trim().Substring(0, 11);
            /////MessageBox.Show(rucemisor);
        }
    }
}
