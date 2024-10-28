using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using objExcel = Microsoft.Office.Interop.Excel;
using ExcelDataReader;
using System.Data;
using System.Data.SqlClient;
using Npgsql;


namespace Contasis
{
    public partial class FrmInconsistencia_productos_comercial : Form
    {

        public static FrmInconsistencia_productos_comercial instance = null;
        string vruc;
        string vempresa;
        public FrmInconsistencia_productos_comercial()
        {
            InitializeComponent();
            instance = this;
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void FrmInconsistencia_productos_comercial_Load(object sender, EventArgs e)
        {
            this.ruc();
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

            }
        }
        private void empresas()
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
                    command.CommandText = "SELECT CCOD_EMPRESA+'-'+NOMEMPRESA AS EMPRESA FROM CG_EMPRESA where ccodrucemisor='" + vruc.Trim() + "'";
                    var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    cmbempresas.Items.Clear();

                    if (dataset.Tables.Count == 0)
                    {
                        //// MessageBox.Show("No existe datos de empresa seleccionada empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //// this.Close();
                    }
                    else
                    {
                        DataTable dtDatabases = dataset.Tables[0];
                        String NewBase = dataset.Tables[0].Rows[0][0].ToString();
                        cmbempresas.Text = dataset.Tables[0].Rows[0][0].ToString();
                        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                        {
                            cmbempresas.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                            cmbempresas.Refresh();

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
                    command.CommandText = "SELECT ltrim(CCOD_EMPRESA)||'-'||ltrim(NOMEMPRESA)::character(50) AS EMPRESA FROM CG_EMPRESA  where ccodrucemisor='" + vruc + "'";
                    var adapter = new NpgsqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    cmbempresas.Items.Clear();

                    if (dataset.Tables.Count == 0)
                    {
                        ///  MessageBox.Show("No existe datos de empresa seleccionada empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        ///  this.Close();
                    }
                    else
                    {
                        DataTable dtDatabases = dataset.Tables[0];
                        String NewBase = dataset.Tables[0].Rows[0][0].ToString();
                        cmbempresas.Text = dataset.Tables[0].Rows[0][0].ToString();
                        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                        {
                            cmbempresas.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                            cmbempresas.Refresh();

                        }
                    }

                    conexion.Close();

                }
            }
            catch
            {
                ///  MessageBox.Show("Error no Existe Informacion de  empresa, favor en registrar una empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void cmbrucemisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView2.DataSource = null;
            this.checkSeleccionar.Enabled = false;
            this.btnseleccionar.Enabled = false;
            this.checkSeleccionar.Checked = false;
            this.checkSeleccionar.Text = "Seleccionar todo";
            vruc = cmbrucemisor.Text.Trim().Substring(0, 11);
            this.empresas();
        }

        private void cmbempresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView2.DataSource = null;
            vempresa = cmbempresas.Text.Trim().Substring(0, 3);
        }
        public void llenar_grilla()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {

                    Clase.Comercial_productos_propiedades obj = new Clase.Comercial_productos_propiedades();
                    Clase.Productos_comercial_Inconsistencia verlista = new Clase.Productos_comercial_Inconsistencia();
                    Clase.Productos_comercial_Inconsistencia actuasql = new Clase.Productos_comercial_Inconsistencia();
                    
                    obj.Ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.Empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.Estado = "";
                    actuasql.ActualizaEstadoSQL(obj);
                    this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    
                    this.dataGridView2.Refresh();

                    dataGridView2.DataSource = verlista.listarsql(obj);
                    dataGridView2.AllowUserToAddRows = false;
                    label2.Text = "Total de Registros : " + Convert.ToString(dataGridView2.Rows.Count);

                    dataGridView2.AllowUserToAddRows = false;

                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    ////  dataGridView2.ReadOnly = true;
                    if (dataGridView2.IsCurrentCellDirty)
                    {
                        dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }
                    if (dataGridView2.Rows.Count > 0)
                    {
                        this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                        this.dataGridView2.Refresh();
                        this.checkSeleccionar.Enabled = true;
                        this.btnseleccionar.Enabled = true;
                        this.button1.Enabled = true;
                        this.checkSeleccionar.Text = "Seleccionar todo";
                        this.checkSeleccionar.Checked = false;
                        this.comboBox1.Items.Clear();
                        ///this.motivo();
                    }
                    else
                    {
                        this.checkSeleccionar.Text = "Seleccionar todo";
                        this.checkSeleccionar.Checked = false;
                        this.comboBox1.Items.Clear();
                        this.comboBox1.Enabled = false;
                        this.checkSeleccionar.Enabled = false;
                        this.btnseleccionar.Enabled = false;
                        this.button1.Enabled = false;

                        MessageBox.Show("No Existe datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dataGridView2.Refresh();
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                }
                catch
                {
                    ////(Exception ex)  MessageBox.Show(ex.ToString(), "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                try
                {

                    Clase.Comercial_productos_propiedades obj = new Clase.Comercial_productos_propiedades();
                    Clase.Productos_comercial_Inconsistencia listapos = new Clase.Productos_comercial_Inconsistencia();
                    Clase.Productos_comercial_Inconsistencia actuapos = new Clase.Productos_comercial_Inconsistencia();

                    obj.Ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.Empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.Estado = "";
                    actuapos.ActualizaEstadoPOS(obj);
                    dataGridView2.Refresh();
                    dataGridView2.DataSource = listapos.listarpostgres(obj);
                    dataGridView2.AllowUserToAddRows = false;
                    label2.Text = "Total de Registros : " + Convert.ToString(dataGridView2.Rows.Count);

                    this.dataGridView2.Refresh();

                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    /////dataGridView2.ReadOnly = true;
                    if (dataGridView2.IsCurrentCellDirty)
                    {
                        dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }


                    if (dataGridView2.Rows.Count > 0)
                    {
                        this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                        this.dataGridView2.Refresh();
                        this.checkSeleccionar.Enabled = true;
                        this.btnseleccionar.Enabled = true;
                        this.button1.Enabled = true;
                        this.comboBox1.Items.Clear();
                        this.comboBox1.Enabled = true;
                        ////this.motivo();
                    }
                    else
                    {
                        this.comboBox1.Items.Clear();
                        this.comboBox1.Enabled = false;
                        this.checkSeleccionar.Enabled = false;
                        this.btnseleccionar.Enabled = false;
                        this.button1.Enabled = false;
                    }
                    this.dataGridView2.Refresh();
                    this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                    dataGridView2.FirstDisplayedScrollingRowIndex = 1;
                    dataGridView2.HorizontalScrollingOffset = 1;
                    
                    this.motivo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (cmbempresas.Text == "")
            {
                return;
            }
            else
            {
                this.llenar_grilla();

                if (dataGridView2.Rows.Count > 0)
                    
                {
                    this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                    if (dataGridView2.Rows.Count > 1)
                    {
                        dataGridView2.FirstDisplayedScrollingRowIndex = 1;
                        dataGridView2.HorizontalScrollingOffset = 1;
                    }
                    this.motivo();
                }
            }
        }
        private void motivo()
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
                    command.CommandText = "SELECT distinct convert(varchar(900),obserror) as obserror " +
                    "  FROM com_producto where es_con_migracion =2 and ccodrucemisor='" + vruc.Trim() + "' and ccod_empresa='" + vempresa.Trim() + "'";
                    var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);

                    comboBox1.Items.Clear();
                    if (dataset.Tables.Count == 0)
                    {
                        MessageBox.Show("No existe motivo registrado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                    else
                    {

                        DataTable dtDatabases = dataset.Tables[0];
                        String NewBase = dataset.Tables[0].Rows[0][0].ToString();
                        comboBox1.Text = dataset.Tables[0].Rows[0][0].ToString();
                        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                        {
                            comboBox1.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                            comboBox1.Refresh();

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
                    command.CommandText = "SELECT distinct ltrim(obserror) as obserror " +
                    "  FROM com_producto where es_con_migracion=2 and ccodrucemisor='" + vruc.Trim() + "' and ccod_empresa='" + vempresa.Trim() + "'";
                    var adapter = new NpgsqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);

                    comboBox1.Items.Clear();
                    if (dataset.Tables.Count == 0)
                    {
                        MessageBox.Show("No existe motivo registrado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                    else
                    {

                        DataTable dtDatabases = dataset.Tables[0];
                        String NewBase = dataset.Tables[0].Rows[0][0].ToString();
                        comboBox1.Text = dataset.Tables[0].Rows[0][0].ToString();
                        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                        {
                            comboBox1.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                            comboBox1.Refresh();

                        }
                    }

                    conexion.Close();

                }
            }
            catch
            {
                MessageBox.Show("No existe Motivo de error.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }



        }
        private void checkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            {
                return;
            }
            else
            {
                if (checkSeleccionar.Checked == true)
                {

                    checkSeleccionar.Text = "Desmarcar todo";
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        dataGridView2.Rows[i].Cells[0].Value = CheckState.Checked;
                    }
                }
                else
                {

                    checkSeleccionar.Text = "Seleccionar todo";
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        dataGridView2.Rows[i].Cells[0].Value = CheckState.Unchecked;
                    }
                }
            }
        }
        private void actualizamotivo(string id)
        {
            string respuesta = "";
            Clase.Comercial_productos_propiedades obe = new Clase.Comercial_productos_propiedades();
            Clase.Productos_comercial_Inconsistencia ds = new Clase.Productos_comercial_Inconsistencia();
            obe.Id = id;
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    respuesta = ds.Actualizarmasivosql(obe);
                    if (respuesta.Equals("Actualizado"))
                    {

                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar esa venta.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    respuesta = ds.Actualizarmasivopos(obe);
                    if (respuesta.Equals("Actualizado"))
                    {

                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizada esa venta.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        private void btnseleccionar_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (Convert.ToString(dataGridView2.Rows.Count) == "0")
                {
                    return;
                }
                else
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        
                        if (dataGridView2.Rows[i].Cells[0].Value.ToString() == "Checked")
                        {
                           ////MessageBox.Show(dataGridView2.Rows[i].Cells[2].Value.ToString());
                           string valor = dataGridView2.Rows[i].Cells[2].Value.ToString();
                           this.actualizamotivo(valor);
                       
                        }
                    }
                    this.llenar_grilla();
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            { }
            else
            {
                this.llenar_grillamotivo();
                this.checkSeleccionar.Text = "Seleccionar todo";
                this.checkSeleccionar.Checked = false;
            }
        }
        public void llenar_grillamotivo()
        {
            this.btnseleccionar.Enabled = false;
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {

                try
                {

                    Clase.Comercial_productos_propiedades obj = new Clase.Comercial_productos_propiedades();
                    Clase.Productos_comercial_Inconsistencia listasql = new Clase.Productos_comercial_Inconsistencia();
                    Clase.Productos_comercial_Inconsistencia actualizar = new Clase.Productos_comercial_Inconsistencia();
                    obj.Ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.Empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.Estado = comboBox1.Text.Trim();
                    actualizar.ActualizaEstadoSQL(obj);
                    this.dataGridView2.Refresh();
                    dataGridView2.DataSource = listasql.listascombosql(obj);
                    dataGridView2.AllowUserToAddRows = false;
                    label2.Text = "Total de Registros : " + Convert.ToString(dataGridView2.Rows.Count);

                    dataGridView2.AllowUserToAddRows = false;

                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    if (dataGridView2.IsCurrentCellDirty)
                    {
                        dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }
                    if (dataGridView2.Rows.Count > 0)
                    {
                        
                        this.dataGridView2.Refresh();
                        this.checkSeleccionar.Enabled = true;
                        this.btnseleccionar.Enabled = true;
                        this.button1.Enabled = true;
                        this.comboBox1.Enabled = true;
                        this.checkSeleccionar.Text = "Seleccionar todo";
                        this.checkSeleccionar.Checked = false;
                        this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                    }
                    else
                    {
                        this.checkSeleccionar.Text = "Seleccionar todo";
                        this.checkSeleccionar.Checked = false;
                        this.comboBox1.Items.Clear();
                        this.comboBox1.Enabled = false;
                        this.checkSeleccionar.Enabled = false;
                        this.btnseleccionar.Enabled = false;
                        this.button1.Enabled = false;
                        this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                    }
                    dataGridView2.FirstDisplayedScrollingRowIndex = 0;
                    dataGridView2.HorizontalScrollingOffset = 0;

                    this.dataGridView2.Refresh();
                }
                catch
                {
                    MessageBox.Show("No Existe datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                try
                {

                    Clase.Comercial_productos_propiedades obj = new Clase.Comercial_productos_propiedades();
                    Clase.Productos_comercial_Inconsistencia listapos = new Clase.Productos_comercial_Inconsistencia();
                    Clase.Productos_comercial_Inconsistencia actualizar = new Clase.Productos_comercial_Inconsistencia();

                    obj.Ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.Empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.Estado = comboBox1.Text.Trim();
                    actualizar.ActualizaEstadoPOS(obj);
                    dataGridView2.Refresh();
                    dataGridView2.DataSource = listapos.listascombopos(obj);
                    dataGridView2.AllowUserToAddRows = false;
                    label2.Text = "Total de Registros : " + Convert.ToString(dataGridView2.Rows.Count);

                    this.dataGridView2.Refresh();

                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    if (dataGridView2.IsCurrentCellDirty)
                    {
                        dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }


                    if (dataGridView2.Rows.Count > 0)
                    {
                        
                        this.dataGridView2.Refresh();
                        this.checkSeleccionar.Enabled = true;
                        this.btnseleccionar.Enabled = true;
                        this.button1.Enabled = true;
                        this.comboBox1.Enabled = true;
                        this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                    }
                    else
                    {
                        this.comboBox1.Items.Clear();
                        this.comboBox1.Enabled = false;
                        this.checkSeleccionar.Enabled = false;
                        this.btnseleccionar.Enabled = false;
                        this.button1.Enabled = false;
                        this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                    }
                    this.dataGridView2.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Existe datos." + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                try
                {
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[67].Value).Trim();
                    Refresh();
                }
                catch
                { }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                try
                {
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[67].Value).Trim();
                    Refresh();
                }
                catch
                { }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToString(dataGridView2.Rows.Count) == "0")
                { }
                else
                {
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[67].Value).Trim();
                    Refresh();
                }
            }
            catch
            { }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[32].Value).Trim();
                Refresh();


                Clase.Comercial_productos_propiedades obj = new Clase.Comercial_productos_propiedades();
               //// obj.Id = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                obj.Id = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                obj.Modulo = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                obj.Cod_grupo = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                obj.Descripcion_grupo = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                obj.Cod_familia = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                obj.Desc_familia = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                obj.Cod_producto = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                obj.Descripcion_producto = dataGridView2.CurrentRow.Cells[9].Value.ToString();
                obj.Descripcion_general = dataGridView2.CurrentRow.Cells[10].Value.ToString();
                obj.Existencia = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                obj.Marca = dataGridView2.CurrentRow.Cells[12].Value.ToString();
                obj.Unidad_medida = dataGridView2.CurrentRow.Cells[13].Value.ToString();
                obj.Cod_osce = dataGridView2.CurrentRow.Cells[14].Value.ToString();
                obj.Descrip_osce = dataGridView2.CurrentRow.Cells[15].Value.ToString();
                obj.Tipo = dataGridView2.CurrentRow.Cells[16].Value.ToString();
                obj.Unid_secundaria = dataGridView2.CurrentRow.Cells[17].Value.ToString();
                obj.Peso = dataGridView2.CurrentRow.Cells[18].Value.ToString();
                obj.Cod_barra = dataGridView2.CurrentRow.Cells[19].Value.ToString();
                obj.Inhabilitar_prod = dataGridView2.CurrentRow.Cells[20].Value.ToString();
                obj.Para_anular = dataGridView2.CurrentRow.Cells[21].Value.ToString();
                obj.Lote = dataGridView2.CurrentRow.Cells[22].Value.ToString();
                obj.Serie_unica = dataGridView2.CurrentRow.Cells[23].Value.ToString();
                obj.Icbper = dataGridView2.CurrentRow.Cells[24].Value.ToString();
                obj.Prod_anticipo = dataGridView2.CurrentRow.Cells[25].Value.ToString();
                obj.Gasto_relacionado = dataGridView2.CurrentRow.Cells[26].Value.ToString();
                obj.Prod_safnif = dataGridView2.CurrentRow.Cells[27].Value.ToString();
                obj.Cuenta_compras = dataGridView2.CurrentRow.Cells[28].Value.ToString();
                obj.Cuenta_ventas = dataGridView2.CurrentRow.Cells[29].Value.ToString();
                obj.Costo_debito_salida = dataGridView2.CurrentRow.Cells[30].Value.ToString();
                obj.Costos_credito_salida = dataGridView2.CurrentRow.Cells[31].Value.ToString();
                obj.Debito_costo_ingresos = dataGridView2.CurrentRow.Cells[32].Value.ToString();
                obj.Credito_costo_ingresos = dataGridView2.CurrentRow.Cells[33].Value.ToString();
                obj.Ccostos = dataGridView2.CurrentRow.Cells[34].Value.ToString();
                obj.Ccostos2 = dataGridView2.CurrentRow.Cells[35].Value.ToString();
                obj.Presupuesto = dataGridView2.CurrentRow.Cells[36].Value.ToString();
                obj.Reg_compras = dataGridView2.CurrentRow.Cells[37].Value.ToString();
                obj.Reg_ventas = dataGridView2.CurrentRow.Cells[38].Value.ToString();
                obj.Afecto_isc = dataGridView2.CurrentRow.Cells[39].Value.ToString();
                obj.Moneda = dataGridView2.CurrentRow.Cells[40].Value.ToString();
                obj.Precio1 = dataGridView2.CurrentRow.Cells[41].Value.ToString();
                obj.Precio2 = dataGridView2.CurrentRow.Cells[42].Value.ToString();
                obj.Precio3 = dataGridView2.CurrentRow.Cells[43].Value.ToString();
                obj.Precio4 = dataGridView2.CurrentRow.Cells[44].Value.ToString();
                obj.Precio5 = dataGridView2.CurrentRow.Cells[45].Value.ToString();
                obj.Precio6 = dataGridView2.CurrentRow.Cells[46].Value.ToString();
                obj.Precio7 = dataGridView2.CurrentRow.Cells[47].Value.ToString();
                obj.Precio8 = dataGridView2.CurrentRow.Cells[48].Value.ToString();
                obj.Precio9 = dataGridView2.CurrentRow.Cells[49].Value.ToString();
                obj.Precio10 = dataGridView2.CurrentRow.Cells[50].Value.ToString();
                obj.Precio11 = dataGridView2.CurrentRow.Cells[51].Value.ToString();
                obj.Precio12 = dataGridView2.CurrentRow.Cells[52].Value.ToString();
                obj.Precio13 = dataGridView2.CurrentRow.Cells[53].Value.ToString();
                obj.Precio14 = dataGridView2.CurrentRow.Cells[54].Value.ToString();
                obj.Precio15 = dataGridView2.CurrentRow.Cells[55].Value.ToString();
                obj.Stock_minimo = dataGridView2.CurrentRow.Cells[56].Value.ToString();
                obj.Stock_maximo = dataGridView2.CurrentRow.Cells[57].Value.ToString();
                obj.Limite_inferior_precio = dataGridView2.CurrentRow.Cells[58].Value.ToString();
                obj.Limite_superior_precio = dataGridView2.CurrentRow.Cells[59].Value.ToString();
                obj.Regimen_especial = dataGridView2.CurrentRow.Cells[60].Value.ToString();
                obj.Codigo_percepcion = dataGridView2.CurrentRow.Cells[61].Value.ToString();
                obj.Codigo_detraccion = dataGridView2.CurrentRow.Cells[62].Value.ToString();
                obj.Monto_minimo = dataGridView2.CurrentRow.Cells[63].Value.ToString();
                obj.Codigo_laboratorio = dataGridView2.CurrentRow.Cells[64].Value.ToString();
                obj.Descripcion_laboratorio = dataGridView2.CurrentRow.Cells[65].Value.ToString();
                obj.Estado = dataGridView2.CurrentRow.Cells[66].Value.ToString();
                obj.Observacion = dataGridView2.CurrentRow.Cells[67].Value.ToString();

                Frm_com_productosEditor editorproducto = new Frm_com_productosEditor(obj);
                editorproducto.ShowDialog();
              
            }
        }

        private void FrmInconsistencia_productos_comercial_KeyDown(object sender, KeyEventArgs e)
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

        /*********************************************************************************/
    }
}
