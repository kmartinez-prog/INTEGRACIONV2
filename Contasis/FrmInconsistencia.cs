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
                dataGridView2.Columns[0].HeaderText = "ID VENTAS";
                dataGridView2.Columns[0].DataPropertyName = "idventas";
                dataGridView2.Columns[1].HeaderText = "COD EMPRESA";
                dataGridView2.Columns[1].DataPropertyName = "ccod_empresa";
                dataGridView2.Columns[2].HeaderText = "FECHA DE EMISIÓN DEL COMPROBANTE DE PAGO O DOCUMENTO";
                dataGridView2.Columns[2].DataPropertyName = "ffechadoc";
                dataGridView2.Columns[3].HeaderText = "FECHA DE VENCIMIENTO O FECHA DE PAGO";
                dataGridView2.Columns[3].DataPropertyName = "ffechaven";
                dataGridView2.Columns[4].HeaderText = "TIPO COMPROBANTE";
                dataGridView2.Columns[4].DataPropertyName = "ccoddoc";
                dataGridView2.Columns[5].HeaderText = "SERIE";
                dataGridView2.Columns[5].DataPropertyName = "cserie";
                dataGridView2.Columns[6].HeaderText = "NUMERO";
                dataGridView2.Columns[6].DataPropertyName = "cnumero";
                dataGridView2.Columns[7].HeaderText = "CODIGO ENTIDAD";
                dataGridView2.Columns[7].DataPropertyName = "ccodenti";
                dataGridView2.Columns[8].HeaderText = "DESCRIP. ENTIDAD";
                dataGridView2.Columns[8].DataPropertyName = "cdesenti";
                dataGridView2.Columns[9].HeaderText = "TIPO DOC.ENTIDAD";
                dataGridView2.Columns[9].DataPropertyName = "ctipdoc";
                dataGridView2.Columns[10].HeaderText = "TIPO DOC.ENTIDAD";
                dataGridView2.Columns[10].DataPropertyName = "ccodruc";

                dataGridView2.Columns[11].DataPropertyName = "crazsoc";

                dataGridView2.Columns[12].DataPropertyName = "nbase2";

                dataGridView2.Columns[13].DataPropertyName = "nbase1";
                dataGridView2.Columns[14].DataPropertyName = "nexo";
                dataGridView2.Columns[15].DataPropertyName = "nina";
                dataGridView2.Columns[16].DataPropertyName = "nisc";
                dataGridView2.Columns[17].DataPropertyName = "nigv1";
                dataGridView2.Columns[18].DataPropertyName = "nicbpers";
                dataGridView2.Columns[19].DataPropertyName = "nbase3";
                dataGridView2.Columns[20].DataPropertyName = "ntots";
                dataGridView2.Columns[21].DataPropertyName = "ntc";
                dataGridView2.Columns[22].DataPropertyName = "freffec";
                dataGridView2.Columns[23].DataPropertyName = "crefdoc";
                dataGridView2.Columns[24].DataPropertyName = "crefser";
                dataGridView2.Columns[25].DataPropertyName = "crefnum";
                dataGridView2.Columns[26].DataPropertyName = "cmreg";
                dataGridView2.Columns[27].DataPropertyName = "ndolar";
                dataGridView2.Columns[28].DataPropertyName = "ffechaven2";
                dataGridView2.Columns[29].DataPropertyName = "ccond";
                dataGridView2.Columns[30].DataPropertyName = "ccodcos";
                dataGridView2.Columns[31].DataPropertyName = "ccodcos2";
                dataGridView2.Columns[32].DataPropertyName = "cctabase";
                dataGridView2.Columns[33].DataPropertyName = "cctaicbper";
                dataGridView2.Columns[34].DataPropertyName = "cctaotrib";
                dataGridView2.Columns[35].DataPropertyName = "cctatot";
                dataGridView2.Columns[36].DataPropertyName = "nresp";
                dataGridView2.Columns[37].DataPropertyName = "nporre";
                dataGridView2.Columns[38].DataPropertyName = "nimpres";
                dataGridView2.Columns[39].DataPropertyName = "cserre";
                dataGridView2.Columns[40].DataPropertyName = "cnumre";
                dataGridView2.Columns[41].DataPropertyName = "ffecre";
                dataGridView2.Columns[42].DataPropertyName = "ccodpresu";
                dataGridView2.Columns[43].DataPropertyName = "nigv";
                dataGridView2.Columns[44].DataPropertyName = "ccodpago";
                dataGridView2.Columns[45].DataPropertyName = "nperdenre";
                dataGridView2.Columns[46].DataPropertyName = "nbaseres";
                dataGridView2.Columns[47].DataPropertyName = "cctaperc";
                dataGridView2.Columns[48].DataPropertyName = "obserror";
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
    }
}
