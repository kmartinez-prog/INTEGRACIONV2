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
    public partial class FrmInconsistencias_Cobranza : Form
    {
        string vruc;
        string vempresa;
        public FrmInconsistencias_Cobranza()
        {
            InitializeComponent();
            
        }

        private void FrmInconsistencias_Cobranza_Load(object sender, EventArgs e)
        {
            this.ruc();
        }
        private void FrmInconsistencias_Cobranza_KeyDown(object sender, KeyEventArgs e)
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
        public void llenar_grilla()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {

                    Clase.Cobranzas_propiedades obj = new Clase.Cobranzas_propiedades();
                    Clase.Conbranzas_Inconsistencia listasql = new Clase.Conbranzas_Inconsistencia();
                    Clase.Conbranzas_Inconsistencia actuasql = new Clase.Conbranzas_Inconsistencia();
                    obj.Ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.Empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.Estado = "";
                    actuasql.ActualizaEstadoSQL(obj);
                    this.dataGridView2.Refresh();

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

                        MessageBox.Show("No Existe datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    this.dataGridView2.Refresh();
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

                    Clase.Cobranzas_propiedades obj = new Clase.Cobranzas_propiedades();
                    Clase.Conbranzas_Inconsistencia listapos = new Clase.Conbranzas_Inconsistencia();
                    Clase.Conbranzas_Inconsistencia actuapos = new Clase.Conbranzas_Inconsistencia();

                    obj.Ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.Empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.Estado = "";
                    actuapos.ActualizaEstadoPOS(obj);
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
                    MessageBox.Show(ex.ToString(), "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    command.CommandText = "SELECT distinct convert(varchar(900),obserror) as obserror " +
                    "  FROM fin_ventas where es_con_migracion =2 and ccodrucemisor='" + vruc.Trim() + "' and ccod_empresa='" + vempresa.Trim() + "'";
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
                    command.CommandText = "SELECT distinct obserror " +
                    "  FROM fin_ventas where es_con_migracion=2 and ccodrucemisor='" + vruc.Trim() + "' and ccod_empresa='" + vempresa.Trim() + "'";
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

                    Clase.Cobranzas_propiedades obj = new Clase.Cobranzas_propiedades();
                    Clase.Conbranzas_Inconsistencia listasql = new Clase.Conbranzas_Inconsistencia();
                    Clase.Conbranzas_Inconsistencia actualizar = new Clase.Conbranzas_Inconsistencia();
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

                    Clase.Cobranzas_propiedades obj = new Clase.Cobranzas_propiedades();
                    Clase.Conbranzas_Inconsistencia listapos = new Clase.Conbranzas_Inconsistencia();
                    Clase.Conbranzas_Inconsistencia actualizar = new Clase.Conbranzas_Inconsistencia();

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
                    }
                    this.dataGridView2.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No Existe datos." + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void actualizamotivo(string id)
        {
            string respuesta = "";
            Clase.Cobranzas_propiedades obe = new Clase.Cobranzas_propiedades();
            Clase.Conbranzas_Inconsistencia ds = new Clase.Conbranzas_Inconsistencia();
            obe.Idcobranzas = id;
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
    
        private void cmbempresas_SelectedIndexChanged_1(object sender, EventArgs e)
            
        {
            this.dataGridView2.DataSource = null;
            vempresa = cmbempresas.Text.Trim().Substring(0, 3);
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
          
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)

        {
           
        }
        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToString(dataGridView2.Rows.Count) == "0")
                { }
                else
                {
                    txtLista.Text = dataGridView2.CurrentRow.Cells["obserror"].Value.ToString();
                    Refresh();
                }
            }
            catch
            { }
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
         
        }
        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        //////////////////////////////////////////////////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            /*     using Microsoft.Office.Interop.Excel;

                 objExcel.Application excelApp = new objExcel.Application();
                 excelApp.Visible = false;
                 Workbook workbook = excelApp.Workbooks.Add();
                 Worksheet worksheet = (Worksheet)workbook.Sheets[1];
                 if (Convert.ToString(dataGridView2.Rows.Count) == "0")
                 {
                     MessageBox.Show("No existe registros a exportar.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     return;
                 }
                 else
                 {

                     try
                     {
                         MessageBox.Show("Se inicia copiado de registros a una Hoja de Excel.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         int columncount = dataGridView2.ColumnCount;
                         for (int i=0; i<columncount;i++)
                         {
                             worksheet.Cells[1, i + 1] = dataGridView2.Columns[i].HeaderText;
                         }
                         int rowCount = dataGridView2.RowCount;
                         for (int i = 0; i < rowCount; i++)
                         {
                             for (int j = 0; j < columncount; j++)
                             {
                                 worksheet.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value;
                             }

                         }
                         worksheet.Range["A:Z"].EntireColumn.AutoFit();
                         worksheet.Range["A:A"].EntireColumn.Insert();
                         worksheet.Range["1:5"].EntireRow.Insert();
                         worksheet.Range["A:Z"].EntireColumn.AutoFit();
                         worksheet.Range["A2"].Value = "REPORTE DE INCONSISTENCIAS";



                         MessageBox.Show("Se Termino de  copiar los registros a una Hoja de Excel.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         excelApp.Visible = true;


                     }
                     catch(Exception ex)
                     {
                         MessageBox.Show(ex.ToString());
                     }
                 }*/
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[32].Value).Trim();
                Refresh();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void cmbrucemisor_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.dataGridView2.DataSource = null;
            this.checkSeleccionar.Enabled = false;
            this.btnseleccionar.Enabled = false;
            this.checkSeleccionar.Checked = false;
            this.checkSeleccionar.Text = "Seleccionar todo";
            vruc = cmbrucemisor.Text.Trim().Substring(0, 11);
            this.empresas();
        }

        private void btnMostrar_Click_1(object sender, EventArgs e)
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

        private void checkSeleccionar_CheckedChanged_1(object sender, EventArgs e)
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

        private void btnseleccionar_Click_1(object sender, EventArgs e)
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
                            this.txtLista.Text = "";
                        }
                    }
                    this.llenar_grilla();



                }
            }

        }

        private void dataGridView2_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[32].Value).Trim();
                Refresh();
            }
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                try
                {
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[32].Value).Trim();
                    Refresh();
                }
                catch
                { }
            }
        }

        private void dataGridView2_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToString(dataGridView2.Rows.Count) == "0")
                { }
                else
                {
                    txtLista.Text = dataGridView2.CurrentRow.Cells["obserror"].Value.ToString();
                    Refresh();
                }
            }
            catch
            { }
        }

        private void dataGridView2_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {

                txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[32].Value).Trim();
                Refresh();


                Clase.Cobranzas_propiedades obj = new Clase.Cobranzas_propiedades();
                obj.Idcobranzas = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                obj.Ffechacan = Convert.ToString(dataGridView2.SelectedRows[0].Cells[3].Value).Trim();
                obj.Cdoccan = Convert.ToString(dataGridView2.SelectedRows[0].Cells[4].Value).Trim();
                obj.Csercan = Convert.ToString(dataGridView2.SelectedRows[0].Cells[5].Value).Trim();
                obj.Cnumcan = Convert.ToString(dataGridView2.SelectedRows[0].Cells[6].Value).Trim();
                obj.Cmoncan = Convert.ToString(dataGridView2.SelectedRows[0].Cells[8].Value).Trim();
                obj.Nimporcan = Convert.ToString(dataGridView2.SelectedRows[0].Cells[9].Value).Trim();
                obj.Ntipcam = Convert.ToString(dataGridView2.SelectedRows[0].Cells[10].Value).Trim();
                obj.Ccodpago = Convert.ToString(dataGridView2.SelectedRows[0].Cells[11].Value).Trim();
                obj.Ccoddoc = Convert.ToString(dataGridView2.SelectedRows[0].Cells[12].Value).Trim();
                obj.Cserie = Convert.ToString(dataGridView2.SelectedRows[0].Cells[13].Value).Trim();
                obj.Cnumero = Convert.ToString(dataGridView2.SelectedRows[0].Cells[14].Value).Trim();
                obj.Ffechadoc = Convert.ToString(dataGridView2.SelectedRows[0].Cells[15].Value).Trim();
                obj.Ccodruc = Convert.ToString(dataGridView2.SelectedRows[0].Cells[18].Value).Trim();
                obj.Crazsoc = Convert.ToString(dataGridView2.SelectedRows[0].Cells[19].Value).Trim();
                obj.Nimportes = Convert.ToString(dataGridView2.SelectedRows[0].Cells[20].Value).Trim();
                obj.Nimported = Convert.ToString(dataGridView2.SelectedRows[0].Cells[21].Value).Trim();
                obj.Ccodcue = Convert.ToString(dataGridView2.SelectedRows[0].Cells[22].Value).Trim();
                obj.Ccodcos = Convert.ToString(dataGridView2.SelectedRows[0].Cells[24].Value).Trim();
                obj.Ccodcos2 = Convert.ToString(dataGridView2.SelectedRows[0].Cells[25].Value).Trim();
                obj.Obserror = Convert.ToString(dataGridView2.SelectedRows[0].Cells[32].Value).Trim();

                FrmEditorCobranzapagos editcobranza = new FrmEditorCobranzapagos(obj.Idcobranzas, obj.Ffechacan,
                obj.Cdoccan, obj.Csercan, obj.Cnumcan, obj.Cmoncan, obj.Nimporcan,
                obj.Ntipcam, obj.Ccodpago, obj.Ccoddoc, obj.Cserie, obj.Cnumero, obj.Ffechadoc, obj.Ccodruc, obj.Crazsoc, obj.Nimportes,
                obj.Nimported, obj.Ccodcue, obj.Ccodcos, obj.Ccodcos2, obj.Obserror);
                /// Frm_ventasEditor editventas = new Frm_ventasEditor();
                editcobranza.ShowDialog();
            }
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToString(dataGridView2.Rows.Count) == "0")
                { }
                else
                {
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[32].Value).Trim();
                    Refresh();
                }
            }
            catch
            { }
        }

        private void dataGridView2_SelectionChanged_1(object sender, EventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                try
                {
                    txtLista.Text = Convert.ToString(dataGridView2.SelectedRows[0].Cells[32].Value).Trim();
                    Refresh();
                }
                catch
                { }
            }
        }
    }
    }

