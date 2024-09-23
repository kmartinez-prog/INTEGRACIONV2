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
    public partial class FrmInconsistenciasCompras : Form
    {
        public static FrmInconsistenciasCompras instance = null;
        string vruc;
        string vempresa;
        public FrmInconsistenciasCompras()
        {
        InitializeComponent();
        instance = this;
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }
        private void FrmInconsistenciasCompras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Hide();
            }
        }
        private void FrmInconsistenciasCompras_Load(object sender, EventArgs e)
        {
            this.ruc();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void llenar_grilla()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {

                    Clase.Compras_propiedadescs obj = new Clase.Compras_propiedadescs();
                    Clase.Compras_inconsistencias listasql = new Clase.Compras_inconsistencias();
                    Clase.Compras_inconsistencias actualizar = new Clase.Compras_inconsistencias();

                    obj.ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.estado = "";
                    this.dataGridView2.Refresh();
                    actualizar.ActualizaEstadoSQL(obj);
                    dataGridView2.DataSource = listasql.listassql(obj);
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
                        this.motivo();
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
                    }


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

                    Clase.Compras_propiedadescs obj = new Clase.Compras_propiedadescs();
                    Clase.Compras_inconsistencias listapos = new Clase.Compras_inconsistencias();
                    Clase.Compras_inconsistencias actualizar = new Clase.Compras_inconsistencias();

                    obj.ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.estado = "";
                    actualizar.ActualizaEstadoSQL(obj);
                    dataGridView2.Refresh();
                    dataGridView2.DataSource = listapos.listaspos(obj);
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
                        this.motivo();
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Existe datos." + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
                    command.CommandText = "SELECT distinct cast(obserror as varchar) as obserror " +
                    "  FROM fin_compras where es_con_migracion=2 and ccodrucemisor='" + vruc.Trim() + "' and ccod_empresa='" + vempresa.Trim() + "'";
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
                        this.comboBox1.Enabled = true;
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
                    command.CommandText = "SELECT distinct coalesce(obserror,'')::varchar as obserror " +
                    "  FROM fin_compras where es_con_migracion=2 and ccodrucemisor='" + vruc.Trim() + "' and ccod_empresa='" + vempresa.Trim() + "'";
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
                        this.comboBox1.Enabled = true;
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
                MessageBox.Show("No Existe información de Motivo de error.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }



        }
        public void llenar_grillamotivo()
        {
            this.btnseleccionar.Enabled = false;
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {

                try
                {

                    Clase.Compras_propiedadescs obj = new Clase.Compras_propiedadescs();
                    Clase.Compras_inconsistencias listasql = new Clase.Compras_inconsistencias();


                    obj.ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.estado = comboBox1.Text.Trim();

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
                        this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                        this.dataGridView2.Refresh();
                        this.checkSeleccionar.Enabled = true;
                        this.btnseleccionar.Enabled = true;
                        this.button1.Enabled = true;
                        this.comboBox1.Enabled = true;
                        this.checkSeleccionar.Text = "Seleccionar todo";
                        this.checkSeleccionar.Checked = false;
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


                    this.dataGridView2.Refresh();
                }
                catch
                {
                   //// MessageBox.Show("No Existe datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                try
                {

                    Clase.Compras_propiedadescs obj = new Clase.Compras_propiedadescs();
                    Clase.Compras_inconsistencias listapos = new Clase.Compras_inconsistencias();


                    obj.ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.estado = comboBox1.Text.Trim();

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
                        this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                        this.dataGridView2.Refresh();
                        this.checkSeleccionar.Enabled = true;
                        this.btnseleccionar.Enabled = true;
                        this.button1.Enabled = true;
                        this.comboBox1.Enabled = true;
                    }
                    else
                    {
                        this.comboBox1.Items.Clear();
                        this.comboBox1.Enabled = false;
                        this.checkSeleccionar.Enabled = false;
                        this.btnseleccionar.Enabled = false;
                        this.button1.Enabled = false;
                        MessageBox.Show("No Existe datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.dataGridView2.Refresh();
                }
                catch 
                {
                    ///(Exception ex)MessageBox.Show("No Existe datos." + ex.ToString(), "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void actualizamotivo(string id)
        {
            string respuesta = "";
            Clase.Compras_propiedadescs obe = new Clase.Compras_propiedadescs();
            Clase.Compras_inconsistencias ds = new Clase.Compras_inconsistencias();
            obe.vidcompras = id;
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    respuesta = ds.Actualizarmasivosql(obe);
                    if (respuesta.Equals("Actualizado"))
                    {                 }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar esa compra.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    {                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizada esa compra.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (cmbempresas.Text == "")
            {
                return;
            }
            else
            {
                this.llenar_grilla();
                this.motivo();

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
                this.btnseleccionar.Enabled = true;
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
        private void btnseleccionar_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
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
                            string valor = dataGridView2.Rows[i].Cells[1].Value.ToString();
                            this.actualizamotivo(valor);
                        }
                    }
                    this.llenar_grilla();
                }
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
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[54].Value).Trim();
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
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[54].Value).Trim();
                    Refresh();
                }
            }
            catch
            { }
        }
        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToString(dataGridView2.Rows.Count) == "0")
                { }
                else
                {
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[54].Value).Trim();
                    Refresh();
                }
            }
            catch
            { }
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                try
                {
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[54].Value).Trim();
                    Refresh();
                }
                catch
                { }
            }
        }
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[54].Value).Trim();
                Clase.Compras_propiedadescs obj = new Clase.Compras_propiedadescs();
                obj.idcompras = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                obj.ffechadoc = Convert.ToString(dataGridView2.SelectedRows[0].Cells[3].Value).Trim();
                obj.fechaven  = Convert.ToString(dataGridView2.SelectedRows[0].Cells[4].Value).Trim();
                obj.ccoddoc   = Convert.ToString(dataGridView2.SelectedRows[0].Cells[5].Value).Trim();
                obj.cserie    = Convert.ToString(dataGridView2.SelectedRows[0].Cells[8].Value).Trim();
                obj.cnumero   = Convert.ToString(dataGridView2.SelectedRows[0].Cells[9].Value).Trim();
                obj.ctipdoc   = Convert.ToString(dataGridView2.SelectedRows[0].Cells[10].Value).Trim();
                obj.crazsoc   = Convert.ToString(dataGridView2.SelectedRows[0].Cells[12].Value).Trim();
                obj.ccodruc   = Convert.ToString(dataGridView2.SelectedRows[0].Cells[11].Value).Trim();
                obj.nbase1    = Convert.ToString(dataGridView2.SelectedRows[0].Cells[14].Value).Trim();
                obj.nigv1     = Convert.ToString(dataGridView2.SelectedRows[0].Cells[15].Value).Trim();
                obj.ntots     = Convert.ToString(dataGridView2.SelectedRows[0].Cells[24].Value).Trim();
                obj.ntc       = Convert.ToString(dataGridView2.SelectedRows[0].Cells[28].Value).Trim();
                obj.cmreg     = Convert.ToString(dataGridView2.SelectedRows[0].Cells[33].Value).Trim();
                obj.cctabase  = Convert.ToString(dataGridView2.SelectedRows[0].Cells[37].Value).Trim();
                obj.cctatot   = Convert.ToString(dataGridView2.SelectedRows[0].Cells[40].Value).Trim();
                obj.ccond     = Convert.ToString(dataGridView2.SelectedRows[0].Cells[36].Value).Trim();
                obj.ccodcos   = Convert.ToString(dataGridView2.SelectedRows[0].Cells[41].Value).Trim();
                obj.ccodcos2  = Convert.ToString(dataGridView2.SelectedRows[0].Cells[42].Value).Trim();
                obj.ccodpresu = Convert.ToString(dataGridView2.SelectedRows[0].Cells[49].Value).Trim();
                obj.obserror  = Convert.ToString(dataGridView2.SelectedRows[0].Cells[54].Value).Trim();

                Frm_comprasEditor editcompras = new Frm_comprasEditor(obj.idcompras, obj.ffechadoc,
                obj.fechaven, obj.ccoddoc, obj.cserie, obj.cnumero, obj.ctipdoc, obj.crazsoc,
                obj.ccodruc, obj.nbase1, obj.nigv1, obj.ntots, obj.ntc, obj.cmreg, obj.cctabase, 
                obj.cctatot, obj.ccond, obj.ccodcos, obj.ccodcos2, obj.ccodpresu,obj.obserror);
                /// Frm_ventasEditor editventas = new Frm_ventasEditor();
                editcompras.ShowDialog();
            }
        }
    /////////////////////////////////////////////////////////////////////////////////////////////////
}
}
