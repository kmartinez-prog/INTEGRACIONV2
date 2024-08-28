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


                    obj.ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.estado = "";

                    this.dataGridView2.Refresh();
                    dataGridView2.DataSource = listasql.listassql(obj);
                    dataGridView2.AllowUserToAddRows = false;
                    label2.Text = "Total de Registros : " + Convert.ToString(dataGridView2.Rows.Count);
                    ///dataGridView2.Columns[0].HeaderText = "RUC EMISOR";
                    ///dataGridView2.Columns[0].DataPropertyName = "ccodrucemisor";
                    ///
                 /*   DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
                    chkCol.Name = "Seleccione";
                    dataGridView2.Columns.Add(chkCol);
                    dataGridView2.Columns[1].HeaderText = "ID VENTAS";
                    dataGridView2.Columns[1].DataPropertyName = "idventas";
                    dataGridView2.Columns[2].HeaderText = "COD EMPRESA";
                    dataGridView2.Columns[2].DataPropertyName = "ccod_empresa";
                    dataGridView2.Columns[3].HeaderText = "FECHA DE EMISIÓN DEL COMPROBANTE DE PAGO O DOCUMENTO";
                    dataGridView2.Columns[3].DataPropertyName = "ffechadoc";
                    dataGridView2.Columns[4].HeaderText = "FECHA DE VENCIMIENTO O FECHA DE PAGO";
                    dataGridView2.Columns[4].DataPropertyName = "ffechaven";
                    dataGridView2.Columns[5].HeaderText = "TIPO COMPROBANTE";
                    dataGridView2.Columns[5].DataPropertyName = "ccoddoc";
                    dataGridView2.Columns[6].HeaderText = "SERIE";
                    dataGridView2.Columns[6].DataPropertyName = "cserie";
                    dataGridView2.Columns[7].HeaderText = "NUMERO";
                    dataGridView2.Columns[7].DataPropertyName = "cnumero";
                    dataGridView2.Columns[8].HeaderText = "CODIGO ENTIDAD";
                    dataGridView2.Columns[8].DataPropertyName = "ccodenti";
                    dataGridView2.Columns[9].HeaderText = "DESCRIP. ENTIDAD";
                    dataGridView2.Columns[9].DataPropertyName = "cdesenti";
                    dataGridView2.Columns[10].HeaderText = "TIPO DOC.ENTIDAD";
                    dataGridView2.Columns[10].DataPropertyName = "ctipdoc";
                    dataGridView2.Columns[11].HeaderText = "RUC";
                    dataGridView2.Columns[11].DataPropertyName = "ccodruc";
                    dataGridView2.Columns[12].HeaderText = "RAZON SOCIAL";
                    dataGridView2.Columns[12].Width = 200;
                    dataGridView2.Columns[12].DataPropertyName = "crazsoc";
                    dataGridView2.Columns[13].HeaderText = "VALOR FACTURADO DE LA EXPORTACION";
                    dataGridView2.Columns[13].DataPropertyName = "nbase2";
                    dataGridView2.Columns[14].HeaderText = "BASE IMPONIBLE DE LA OPERACION GRAVADA";
                    dataGridView2.Columns[14].DataPropertyName = "nbase1";
                    dataGridView2.Columns[15].HeaderText = "EXONERADA";
                    dataGridView2.Columns[15].DataPropertyName = "nexo";
                    dataGridView2.Columns[16].HeaderText = "INAFECTA";
                    dataGridView2.Columns[16].DataPropertyName = "nina";
                    dataGridView2.Columns[17].HeaderText = "ISC";
                    dataGridView2.Columns[17].DataPropertyName = "nisc";
                    dataGridView2.Columns[18].HeaderText = "IGV";
                    dataGridView2.Columns[18].DataPropertyName = "nigv1";
                    dataGridView2.Columns[19].HeaderText = "ICBPER";
                    dataGridView2.Columns[19].DataPropertyName = "nicbpers";
                    dataGridView2.Columns[20].HeaderText = "OTROS TRIBUTOS Y CARGOS QUE NO FORMAN PARTE DE LA BASE IMPONIBLE";
                    dataGridView2.Columns[20].DataPropertyName = "nbase3";
                    dataGridView2.Columns[21].HeaderText = "IMPORTE TOTAL DEL COMPROBANTE DE PAGO";
                    dataGridView2.Columns[21].DataPropertyName = "ntots";
                    dataGridView2.Columns[22].HeaderText = "TIPO DE CAMBIO";
                    dataGridView2.Columns[22].DataPropertyName = "ntc";
                    dataGridView2.Columns[23].HeaderText = "FECHA D REF.";
                    dataGridView2.Columns[23].DataPropertyName = "freffec";
                    dataGridView2.Columns[24].HeaderText = "TIPO REFERENCIA";
                    dataGridView2.Columns[24].DataPropertyName = "crefdoc";
                    dataGridView2.Columns[25].HeaderText = "SERIE REFERENCIA";
                    dataGridView2.Columns[25].DataPropertyName = "crefser";
                    dataGridView2.Columns[26].HeaderText = "N° COMPROBANTE PAGO O DOCUMENTO";
                    dataGridView2.Columns[26].DataPropertyName = "crefnum";
                    dataGridView2.Columns[27].HeaderText = "MONEDA";
                    dataGridView2.Columns[27].DataPropertyName = "cmreg";
                    dataGridView2.Columns[28].HeaderText = "EQUIVALENTE EN DOLARES AMERICANOS";
                    dataGridView2.Columns[28].DataPropertyName = "ndolar";
                    dataGridView2.Columns[29].HeaderText = "FECHA VENCIMIENTO";
                    dataGridView2.Columns[29].DataPropertyName = "ffechaven2";
                    dataGridView2.Columns[30].HeaderText = "CONDICIÓN CONTADO/CRÉDITO";
                    dataGridView2.Columns[30].DataPropertyName = "ccond";
                    dataGridView2.Columns[31].HeaderText = "CÓDIGO CENTRO DE COSTOS";
                    dataGridView2.Columns[31].DataPropertyName = "ccodcos";
                    dataGridView2.Columns[32].HeaderText = "CÓDIGO CENTRO DE COSTOS 2";
                    dataGridView2.Columns[32].DataPropertyName = "ccodcos2";
                    dataGridView2.Columns[33].HeaderText = "CUENTA CONTABLE BASE IMPONIBLE";
                    dataGridView2.Columns[33].DataPropertyName = "cctabase";
                    dataGridView2.Columns[34].HeaderText = "CUENTA CONTABLE ICBPER";
                    dataGridView2.Columns[34].DataPropertyName = "cctaicbper";
                    dataGridView2.Columns[35].HeaderText = "CUENTA CONTABLE OTROS TRIBUTOS Y CARGOS";
                    dataGridView2.Columns[35].DataPropertyName = "cctaotrib";
                    dataGridView2.Columns[36].HeaderText = "CUENTA CONTABLE TOTAL";
                    dataGridView2.Columns[36].DataPropertyName = "cctatot";
                    dataGridView2.Columns[37].HeaderText = "RÉGIMEN ESPECIAL";
                    dataGridView2.Columns[37].DataPropertyName = "nresp";
                    dataGridView2.Columns[38].HeaderText = "PORCENTAJE RÉGIMEN ESPECIAL";
                    dataGridView2.Columns[38].DataPropertyName = "nporre";
                    dataGridView2.Columns[39].HeaderText = "IMPORTE RÉGIMEN ESPECIAL";
                    dataGridView2.Columns[39].DataPropertyName = "nimpres";
                    dataGridView2.Columns[40].HeaderText = "SERIE DOCUMENTO RÉGIMEN ESPECIAL";
                    dataGridView2.Columns[40].DataPropertyName = "cserre";
                    dataGridView2.Columns[41].HeaderText = "NÚMERO DOCUMENTO RÉGIMEN ESPECIAL";
                    dataGridView2.Columns[41].DataPropertyName = "cnumre";
                    dataGridView2.Columns[42].HeaderText = "FECHA DOCUMENTO RÉGIMEN ESPECIAL";
                    dataGridView2.Columns[42].DataPropertyName = "ffecre";
                    dataGridView2.Columns[43].HeaderText = "CÓDIGO PRESUPUESTO";
                    dataGridView2.Columns[43].DataPropertyName = "ccodpresu";
                    dataGridView2.Columns[44].HeaderText = "PORCENTAJE I.G.V.";
                    dataGridView2.Columns[44].DataPropertyName = "nigv";
                    dataGridView2.Columns[45].HeaderText = "MEDIO DE PAGO";
                    dataGridView2.Columns[45].DataPropertyName = "ccodpago";
                    dataGridView2.Columns[46].HeaderText = "CONDICIÓN DE PERCEPCIÓN";
                    dataGridView2.Columns[46].DataPropertyName = "nperdenre";
                    dataGridView2.Columns[47].HeaderText = "IMPORTE PARA CÁLCULO RÉGIMEN ESPECIAL";
                    dataGridView2.Columns[47].DataPropertyName = "nbaseres";
                    dataGridView2.Columns[48].HeaderText = "CUENTA CONTABLE PERCEPCIONES";
                    dataGridView2.Columns[48].DataPropertyName = "cctaperc";
                    dataGridView2.Columns[49].HeaderText = "OBSERVACIONES";
                    dataGridView2.Columns[49].DataPropertyName = "obserror";
                    dataGridView2.Columns[49].Width = 500;
                 */
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


                    obj.ruc = cmbrucemisor.Text.Trim().Substring(0, 11);
                    obj.empresa = cmbempresas.Text.Trim().Substring(0, 3);
                    obj.estado = "";

                    dataGridView2.Refresh();
                    dataGridView2.DataSource = listapos.listaspos(obj);
                    dataGridView2.AllowUserToAddRows = false;
                    label2.Text = "Total de Registros : " + Convert.ToString(dataGridView2.Rows.Count);

                    //dataGridView2.Columns[0].HeaderText = "RUC EMISOR";
                    ///dataGridView2.Columns[0].DataPropertyName = "ccodrucemisor";
                    ///
                    /*    DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
                        chkCol.Name = "MARCA";
                        dataGridView2.Columns.Add(chkCol);
                        dataGridView2.Columns[0].HeaderText = "MARCA";
                        dataGridView2.Columns[0].DataPropertyName = "MARCA";
                        dataGridView2.Columns[1].HeaderText = "ID VENTAS";
                        dataGridView2.Columns[1].DataPropertyName = "idventas";
                        dataGridView2.Columns[2].HeaderText = "COD EMPRESA";
                        dataGridView2.Columns[2].DataPropertyName = "ccod_empresa";
                        dataGridView2.Columns[3].HeaderText = "FECHA DE EMISIÓN DEL COMPROBANTE DE PAGO O DOCUMENTO";
                        dataGridView2.Columns[3].DataPropertyName = "ffechadoc";
                        dataGridView2.Columns[4].HeaderText = "FECHA DE VENCIMIENTO O FECHA DE PAGO";
                        dataGridView2.Columns[4].DataPropertyName = "ffechaven";
                        dataGridView2.Columns[5].HeaderText = "TIPO COMPROBANTE";
                        dataGridView2.Columns[5].DataPropertyName = "ccoddoc";
                        dataGridView2.Columns[6].HeaderText = "SERIE";
                        dataGridView2.Columns[6].DataPropertyName = "cserie";
                        dataGridView2.Columns[7].HeaderText = "NUMERO";
                        dataGridView2.Columns[7].DataPropertyName = "cnumero";
                        dataGridView2.Columns[8].HeaderText = "CODIGO ENTIDAD";
                        dataGridView2.Columns[8].DataPropertyName = "ccodenti";
                        dataGridView2.Columns[9].HeaderText = "DESCRIP. ENTIDAD";
                        dataGridView2.Columns[9].DataPropertyName = "cdesenti";
                        dataGridView2.Columns[10].HeaderText = "TIPO DOC.ENTIDAD";
                        dataGridView2.Columns[10].DataPropertyName = "ctipdoc";
                        dataGridView2.Columns[11].HeaderText = "RUC";
                        dataGridView2.Columns[11].DataPropertyName = "ccodruc";
                        dataGridView2.Columns[12].HeaderText = "RAZON SOCIAL";
                        dataGridView2.Columns[12].Width = 200;
                        dataGridView2.Columns[12].DataPropertyName = "crazsoc";
                        dataGridView2.Columns[13].HeaderText = "VALOR FACTURADO DE LA EXPORTACION";
                        dataGridView2.Columns[13].DataPropertyName = "nbase2";
                        dataGridView2.Columns[14].HeaderText = "BASE IMPONIBLE DE LA OPERACION GRAVADA";
                        dataGridView2.Columns[14].DataPropertyName = "nbase1";
                        dataGridView2.Columns[15].HeaderText = "EXONERADA";
                        dataGridView2.Columns[15].DataPropertyName = "nexo";
                        dataGridView2.Columns[16].HeaderText = "INAFECTA";
                        dataGridView2.Columns[16].DataPropertyName = "nina";
                        dataGridView2.Columns[17].HeaderText = "ISC";
                        dataGridView2.Columns[17].DataPropertyName = "nisc";
                        dataGridView2.Columns[18].HeaderText = "IGV";
                        dataGridView2.Columns[18].DataPropertyName = "nigv1";
                        dataGridView2.Columns[19].HeaderText = "ICBPER";
                        dataGridView2.Columns[19].DataPropertyName = "nicbpers";
                        dataGridView2.Columns[20].HeaderText = "OTROS TRIBUTOS Y CARGOS QUE NO FORMAN PARTE DE LA BASE IMPONIBLE";
                        dataGridView2.Columns[20].DataPropertyName = "nbase3";
                        dataGridView2.Columns[21].HeaderText = "IMPORTE TOTAL DEL COMPROBANTE DE PAGO";
                        dataGridView2.Columns[21].DataPropertyName = "ntots";
                        dataGridView2.Columns[22].HeaderText = "TIPO DE CAMBIO";
                        dataGridView2.Columns[22].DataPropertyName = "ntc";
                        dataGridView2.Columns[23].HeaderText = "FECHA D REF.";
                        dataGridView2.Columns[23].DataPropertyName = "freffec";
                        dataGridView2.Columns[24].HeaderText = "TIPO REFERENCIA";
                        dataGridView2.Columns[24].DataPropertyName = "crefdoc";
                        dataGridView2.Columns[25].HeaderText = "SERIE REFERENCIA";
                        dataGridView2.Columns[25].DataPropertyName = "crefser";
                        dataGridView2.Columns[26].HeaderText = "N° COMPROBANTE PAGO O DOCUMENTO";
                        dataGridView2.Columns[26].DataPropertyName = "crefnum";
                        dataGridView2.Columns[27].HeaderText = "MONEDA";
                        dataGridView2.Columns[27].DataPropertyName = "cmreg";
                        dataGridView2.Columns[28].HeaderText = "EQUIVALENTE EN DOLARES AMERICANOS";
                        dataGridView2.Columns[28].DataPropertyName = "ndolar";
                        dataGridView2.Columns[29].HeaderText = "FECHA VENCIMIENTO";
                        dataGridView2.Columns[29].DataPropertyName = "ffechaven2";
                        dataGridView2.Columns[30].HeaderText = "CONDICIÓN CONTADO/CRÉDITO";
                        dataGridView2.Columns[30].DataPropertyName = "ccond";
                        dataGridView2.Columns[31].HeaderText = "CÓDIGO CENTRO DE COSTOS";
                        dataGridView2.Columns[31].DataPropertyName = "ccodcos";
                        dataGridView2.Columns[32].HeaderText = "CÓDIGO CENTRO DE COSTOS 2";
                        dataGridView2.Columns[32].DataPropertyName = "ccodcos2";
                        dataGridView2.Columns[33].HeaderText = "CUENTA CONTABLE BASE IMPONIBLE";
                        dataGridView2.Columns[33].DataPropertyName = "cctabase";
                        dataGridView2.Columns[34].HeaderText = "CUENTA CONTABLE ICBPER";
                        dataGridView2.Columns[34].DataPropertyName = "cctaicbper";
                        dataGridView2.Columns[35].HeaderText = "CUENTA CONTABLE OTROS TRIBUTOS Y CARGOS";
                        dataGridView2.Columns[35].DataPropertyName = "cctaotrib";
                        dataGridView2.Columns[36].HeaderText = "CUENTA CONTABLE TOTAL";
                        dataGridView2.Columns[36].DataPropertyName = "cctatot";
                        dataGridView2.Columns[37].HeaderText = "RÉGIMEN ESPECIAL";
                        dataGridView2.Columns[37].DataPropertyName = "nresp";
                        dataGridView2.Columns[38].HeaderText = "PORCENTAJE RÉGIMEN ESPECIAL";
                        dataGridView2.Columns[38].DataPropertyName = "nporre";
                        dataGridView2.Columns[39].HeaderText = "IMPORTE RÉGIMEN ESPECIAL";
                        dataGridView2.Columns[39].DataPropertyName = "nimpres";
                        dataGridView2.Columns[40].HeaderText = "SERIE DOCUMENTO RÉGIMEN ESPECIAL";
                        dataGridView2.Columns[40].DataPropertyName = "cserre";
                        dataGridView2.Columns[41].HeaderText = "NÚMERO DOCUMENTO RÉGIMEN ESPECIAL";
                        dataGridView2.Columns[41].DataPropertyName = "cnumre";
                        dataGridView2.Columns[42].HeaderText = "FECHA DOCUMENTO RÉGIMEN ESPECIAL";
                        dataGridView2.Columns[42].DataPropertyName = "ffecre";
                        dataGridView2.Columns[43].HeaderText = "CÓDIGO PRESUPUESTO";
                        dataGridView2.Columns[43].DataPropertyName = "ccodpresu";
                        dataGridView2.Columns[44].HeaderText = "PORCENTAJE I.G.V.";
                        dataGridView2.Columns[44].DataPropertyName = "nigv";
                        dataGridView2.Columns[45].HeaderText = "MEDIO DE PAGO";
                        dataGridView2.Columns[45].DataPropertyName = "ccodpago";
                        dataGridView2.Columns[46].HeaderText = "CONDICIÓN DE PERCEPCIÓN";
                        dataGridView2.Columns[46].DataPropertyName = "nperdenre";
                        dataGridView2.Columns[47].HeaderText = "IMPORTE PARA CÁLCULO RÉGIMEN ESPECIAL";
                        dataGridView2.Columns[47].DataPropertyName = "nbaseres";
                        dataGridView2.Columns[48].HeaderText = "CUENTA CONTABLE PERCEPCIONES";
                        dataGridView2.Columns[48].DataPropertyName = "cctaperc";
                        dataGridView2.Columns[49].HeaderText = "OBSERVACIONES";
                        dataGridView2.Columns[49].DataPropertyName = "obserror";
                        dataGridView2.Columns[49].Width = 500;
                        dataGridView2.AllowUserToAddRows = false;*/
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
                    command.CommandText = "SELECT distinct obserror " +
                    "  FROM fin_compras where es_con_migracion not in(0,1,4) and ccodrucemisor='" + vruc.Trim() + "' and ccod_empresa='" + vempresa.Trim() + "'";
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
                    "  FROM fin_compras where es_con_migracion not in(0,1,4) and ccodrucemisor='" + vruc.Trim() + "' and ccod_empresa='" + vempresa.Trim() + "'";
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
                MessageBox.Show("No Existe información de Inconsistencias.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
                    txtLista.Text = dataGridView2.CurrentRow.Cells["obserror"].Value.ToString();
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
                    txtLista.Text = dataGridView2.CurrentRow.Cells["obserror"].Value.ToString();
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
                    txtLista.Text = dataGridView2.CurrentRow.Cells["obserror"].Value.ToString();
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
                /// txtLista.Text = dataGridView2.CurrentRow.Cells["obserror"].Value.ToString();
                Refresh();
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(dataGridView2.Rows.Count) == "0")
            { }
            else
            {
                Clase.Compras_propiedadescs obj = new Clase.Compras_propiedadescs();
                obj.idcompras = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                obj.ffechadoc = Convert.ToString(dataGridView2.SelectedRows[0].Cells[3].Value).Trim();
                obj.fechaven = Convert.ToString(dataGridView2.SelectedRows[0].Cells[4].Value).Trim();
                obj.ccoddoc = Convert.ToString(dataGridView2.SelectedRows[0].Cells[5].Value).Trim();
                obj.cserie = Convert.ToString(dataGridView2.SelectedRows[0].Cells[8].Value).Trim();
                obj.cnumero = Convert.ToString(dataGridView2.SelectedRows[0].Cells[9].Value).Trim();
                obj.ctipdoc = Convert.ToString(dataGridView2.SelectedRows[0].Cells[10].Value).Trim();
                obj.crazsoc = Convert.ToString(dataGridView2.SelectedRows[0].Cells[12].Value).Trim();
                obj.ccodruc = Convert.ToString(dataGridView2.SelectedRows[0].Cells[11].Value).Trim();
                obj.nbase1 = Convert.ToString(dataGridView2.SelectedRows[0].Cells[14].Value).Trim();
                obj.nigv1 = Convert.ToString(dataGridView2.SelectedRows[0].Cells[15].Value).Trim();
                obj.ntots = Convert.ToString(dataGridView2.SelectedRows[0].Cells[24].Value).Trim();
                obj.ntc = Convert.ToString(dataGridView2.SelectedRows[0].Cells[28].Value).Trim();
                obj.cmreg = Convert.ToString(dataGridView2.SelectedRows[0].Cells[33].Value).Trim();
                obj.cctabase = Convert.ToString(dataGridView2.SelectedRows[0].Cells[37].Value).Trim();
                obj.cctatot = Convert.ToString(dataGridView2.SelectedRows[0].Cells[40].Value).Trim();
                obj.ccond = Convert.ToString(dataGridView2.SelectedRows[0].Cells[36].Value).Trim();
                obj.ccodcos = Convert.ToString(dataGridView2.SelectedRows[0].Cells[41].Value).Trim();
                obj.ccodcos2 = Convert.ToString(dataGridView2.SelectedRows[0].Cells[42].Value).Trim();

                Frm_comprasEditor editcompras = new Frm_comprasEditor(obj.idcompras, obj.ffechadoc,
                obj.fechaven, obj.ccoddoc, obj.cserie, obj.cnumero, obj.ctipdoc, obj.crazsoc,
                obj.ccodruc, obj.nbase1, obj.nigv1, obj.ntots, obj.ntc, obj.cmreg, obj.cctabase, obj.cctatot, obj.ccond, obj.ccodcos, obj.ccodcos2);
                /// Frm_ventasEditor editventas = new Frm_ventasEditor();
                editcompras.ShowDialog();
            }
        }
    /////////////////////////////////////////////////////////////////////////////////////////////////
}
}
