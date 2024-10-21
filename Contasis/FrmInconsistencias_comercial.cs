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
    public partial class FrmInconsistencias_comercial : Form
    {
        public static FrmInconsistencias_comercial instance = null;
        string vruc;
        string vempresa;
        public FrmInconsistencias_comercial()
        {
            InitializeComponent();
            instance = this;
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void FrmInconsistencias_comercial_Load(object sender, EventArgs e)
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

                    Clase.Comercial_documentoPropiedades obj = new Clase.Comercial_documentoPropiedades();
                    Clase.Documentos_comercial_Inconsistencias verlista = new Clase.Documentos_comercial_Inconsistencias();
                    Clase.Documentos_comercial_Inconsistencias actuasql = new Clase.Documentos_comercial_Inconsistencias();

                    obj.Ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.Empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.Estado = "";
                   /// actuasql.ActualizaEstadoSQL(obj);
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

                    Clase.Comercial_documentoPropiedades obj = new Clase.Comercial_documentoPropiedades();
                    Clase.Documentos_comercial_Inconsistencias listapos = new Clase.Documentos_comercial_Inconsistencias();
                    Clase.Documentos_comercial_Inconsistencias actuapos = new Clase.Documentos_comercial_Inconsistencias();

                    obj.Ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.Empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.Estado = "";
                   // actuapos.ActualizaEstadoPOS(obj);
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
                    " FROM com_documento a inner join configuracion2 b on  " +
                    " ltrim(a.ccodmodulo) = ltrim(b.Tipo) and  " +
                    " ltrim(a.ccoddoc) = ltrim(b.codtipdocu) and  " +
                    " ltrim(a.cserie) = ltrim(b.cserie)  " +
                    " where a.es_con_migracion = 2 AND  a.ccodrucemisor='" + vruc.Trim() + "' and a.ccod_empresa='" + vempresa.Trim() + "'";
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
                    "  FROM com_documento where es_con_migracion=2 and ccodrucemisor='" + vruc.Trim() + "' and ccod_empresa='" + vempresa.Trim() + "'";
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
        public void llenar_grillamotivo()
        {
            this.btnseleccionar.Enabled = false;
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {

                try
                {
                    Clase.Comercial_documentoPropiedades obj = new Clase.Comercial_documentoPropiedades();
                    Clase.Documentos_comercial_Inconsistencias verlista = new Clase.Documentos_comercial_Inconsistencias();
                    Clase.Documentos_comercial_Inconsistencias actuasql = new Clase.Documentos_comercial_Inconsistencias();



                    obj.Ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.Empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.Estado = comboBox1.Text.Trim();
                    actuasql.ActualizaEstadoSQL(obj);
                    this.dataGridView2.Refresh();
                    dataGridView2.DataSource = verlista.listascombosql(obj);
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

                    Clase.Comercial_documentoPropiedades obj = new Clase.Comercial_documentoPropiedades();
                    Clase.Documentos_comercial_Inconsistencias listapos = new Clase.Documentos_comercial_Inconsistencias();
                    Clase.Documentos_comercial_Inconsistencias actualizar = new Clase.Documentos_comercial_Inconsistencias();

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
            Clase.Comercial_documentoPropiedades obe = new Clase.Comercial_documentoPropiedades();
            Clase.Documentos_comercial_Inconsistencias ds = new Clase.Documentos_comercial_Inconsistencias();
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
                        MessageBox.Show("No se pudo actualizar este documento.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            //// MessageBox.Show(dataGridView2.Rows[i].Cells[1].Value.ToString());
                            string valor = dataGridView2.Rows[i].Cells[1].Value.ToString();
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
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                try
                {
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[57].Value).Trim();
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
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[57].Value).Trim();
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
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[57].Value).Trim();
                    Refresh();
                }
            }
            catch
            { }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[57].Value).Trim();
                Refresh();
                Clase.Comercial_documentoPropiedades obj = new Clase.Comercial_documentoPropiedades();
                obj.Id = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                obj.Modulo = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                obj.Cod_movimiento = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                obj.Cod_documento = dataGridView2.CurrentRow.Cells[4].Value.ToString();
                obj.Serie = dataGridView2.CurrentRow.Cells[5].Value.ToString();
                obj.Numero = dataGridView2.CurrentRow.Cells[6].Value.ToString();
                obj.Cod_entiedad = dataGridView2.CurrentRow.Cells[7].Value.ToString();
                obj.Nombre_entidad = dataGridView2.CurrentRow.Cells[8].Value.ToString();
                obj.Tipo_doc_entidad = dataGridView2.CurrentRow.Cells[9].Value.ToString();
                obj.Ruc_rz = dataGridView2.CurrentRow.Cells[10].Value.ToString();
                obj.Razon_social = dataGridView2.CurrentRow.Cells[11].Value.ToString();
                obj.Direc_cliente = dataGridView2.CurrentRow.Cells[12].Value.ToString();
                obj.Ubigeo = dataGridView2.CurrentRow.Cells[13].Value.ToString();
                obj.Contacto = dataGridView2.CurrentRow.Cells[14].Value.ToString();
                obj.Nomb_contacto = dataGridView2.CurrentRow.Cells[15].Value.ToString();
                obj.Fec_documento = dataGridView2.CurrentRow.Cells[16].Value.ToString();
                obj.Fec_vencimiento = dataGridView2.CurrentRow.Cells[17].Value.ToString();
                obj.Fec_almacen = dataGridView2.CurrentRow.Cells[18].Value.ToString();
                obj.Condicion_pago = dataGridView2.CurrentRow.Cells[19].Value.ToString();
                obj.Moneda = dataGridView2.CurrentRow.Cells[20].Value.ToString();
                obj.Tipo_cambio = dataGridView2.CurrentRow.Cells[21].Value.ToString();
                obj.Serie_guia = dataGridView2.CurrentRow.Cells[22].Value.ToString();
                obj.Numero_guia = dataGridView2.CurrentRow.Cells[23].Value.ToString();
                obj.Inf_adicional_doc = dataGridView2.CurrentRow.Cells[24].Value.ToString();
                obj.Cod_vendedor = dataGridView2.CurrentRow.Cells[25].Value.ToString();
                obj.Cod_clasi_bbss = dataGridView2.CurrentRow.Cells[26].Value.ToString();
                obj.Otros_conceptos = dataGridView2.CurrentRow.Cells[27].Value.ToString();
                obj.Orden_compra = dataGridView2.CurrentRow.Cells[28].Value.ToString();
                obj.Tip_referencia = dataGridView2.CurrentRow.Cells[29].Value.ToString();
                obj.Fec_doc_referencia = dataGridView2.CurrentRow.Cells[30].Value.ToString();
                obj.Serie_doc_referencia = dataGridView2.CurrentRow.Cells[31].Value.ToString();
                obj.Numero_referencia = dataGridView2.CurrentRow.Cells[32].Value.ToString();
                obj.Cod_motivo_notacredito = dataGridView2.CurrentRow.Cells[33].Value.ToString();
                obj.Motivo_notacredito = dataGridView2.CurrentRow.Cells[34].Value.ToString();
                obj.Reg_especial = dataGridView2.CurrentRow.Cells[35].Value.ToString();
                obj.Cod_detraccion = dataGridView2.CurrentRow.Cells[36].Value.ToString();
                obj.Porcentaje_detraccion = dataGridView2.CurrentRow.Cells[37].Value.ToString();
                obj.Fec_deposito = dataGridView2.CurrentRow.Cells[38].Value.ToString();
                obj.Contancia_deposito = dataGridView2.CurrentRow.Cells[39].Value.ToString();
                obj.Cod_percepcion = dataGridView2.CurrentRow.Cells[40].Value.ToString();
                obj.Porcentaje_percepcion = dataGridView2.CurrentRow.Cells[41].Value.ToString();
                obj.Documento_dentrofuera = dataGridView2.CurrentRow.Cells[42].Value.ToString();
                obj.Base_imp1 = dataGridView2.CurrentRow.Cells[43].Value.ToString();
                obj.Igv1 = dataGridView2.CurrentRow.Cells[44].Value.ToString();
                obj.Base_imp2 = dataGridView2.CurrentRow.Cells[45].Value.ToString();
                obj.Igv2 = dataGridView2.CurrentRow.Cells[46].Value.ToString();
                obj.Base_imp3 = dataGridView2.CurrentRow.Cells[47].Value.ToString();
                obj.Igv3 = dataGridView2.CurrentRow.Cells[48].Value.ToString();
                obj.Imp_icbper = dataGridView2.CurrentRow.Cells[49].Value.ToString();
                obj.Imp_inafecto = dataGridView2.CurrentRow.Cells[50].Value.ToString();
                obj.Imp_exonerado = dataGridView2.CurrentRow.Cells[51].Value.ToString();
                obj.Imp_isc = dataGridView2.CurrentRow.Cells[52].Value.ToString();
                obj.Base_ivap = dataGridView2.CurrentRow.Cells[53].Value.ToString();
                obj.Igv_ivap = dataGridView2.CurrentRow.Cells[54].Value.ToString();
                obj.Imp_anticipo = dataGridView2.CurrentRow.Cells[55].Value.ToString();
                obj.Total = dataGridView2.CurrentRow.Cells[56].Value.ToString();
                obj.Observacion = dataGridView2.CurrentRow.Cells[57].Value.ToString();


                
                Frm_com_DocumentosEditor editdocumento = new Frm_com_DocumentosEditor(obj.Id,obj.Modulo,obj.Cod_movimiento,
                obj.Cod_documento,obj.Serie,obj.Numero,obj.Cod_entiedad,obj.Nombre_entidad,obj.Tipo_doc_entidad,
                obj.Ruc_rz,obj.Razon_social, obj.Direc_cliente, obj.Ubigeo, obj.Contacto, obj.Nomb_contacto,
                obj.Fec_documento,obj.Fec_vencimiento, obj.Fec_almacen, obj.Condicion_pago, obj.Moneda,obj.Tipo_cambio,
                obj.Serie_guia, obj.Numero_guia, obj.Inf_adicional_doc, obj.Cod_vendedor,obj.Cod_clasi_bbss,
                obj.Otros_conceptos,obj.Orden_compra,obj.Tip_referencia,obj.Fec_doc_referencia,obj.Serie_doc_referencia,
                obj.Numero_referencia, obj.Cod_motivo_notacredito,obj.Motivo_notacredito, obj.Reg_especial,obj.Cod_detraccion,
                obj.Porcentaje_detraccion,obj.Fec_deposito,obj.Contancia_deposito,obj.Cod_percepcion,obj.Porcentaje_percepcion,
                obj.Documento_dentrofuera,obj.Base_imp1,obj.Igv1,obj.Base_imp2, obj.Igv2,obj.Base_imp3,
                obj.Igv3,obj.Imp_icbper,obj.Imp_inafecto,obj.Imp_exonerado,obj.Imp_isc,obj.Base_ivap,obj.Igv_ivap,
                obj.Imp_anticipo,obj.Total,obj.Observacion);
                 editdocumento.ShowDialog();

            }
        }

        /**********************************************************************************************************/
    }
}
