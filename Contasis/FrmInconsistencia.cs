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
    public partial class FrmInconsistencia : Form
    {
        public FrmInconsistencia()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void FrmInconsistencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Hide();
            }
        }

        private void FrmInconsistencia_Load(object sender, EventArgs e)
        {
            this.llenar_grilla();  
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
            try
            {

                Clase.ventas_propiedades obj = new Clase.ventas_propiedades();
                Clase.Ventas_inconsistencias listasql = new Clase.Ventas_inconsistencias();
                obj.ruc = "";
                obj.empresa = "";
                obj.estado = "";

                dataGridView2.DataSource = listasql.listassql(obj);
                label2.Text = "Total de Registros : " + Convert.ToString(dataGridView2.Rows.Count - 1);

                dataGridView2.Columns[0].HeaderText = "RUC EMISOR";
                dataGridView2.Columns[0].DataPropertyName = "ccodrucemisor";
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



                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView2.ReadOnly = true;
                if (dataGridView2.IsCurrentCellDirty)
                {
                    dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }


                if (dataGridView2.Rows.Count - 1 > 0)
                {
                    this.dataGridView2.CurrentCell = this.dataGridView2.Rows[0].Cells[1];
                    this.dataGridView2.Refresh();
                }
                this.dataGridView2.Refresh();
            }
            catch 
            {
                MessageBox.Show("No Existe datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtLista.Text = dataGridView2.CurrentRow.Cells["obserror"].Value.ToString();
                Refresh();
            }
            catch
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
