using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using ExcelDataReader;


namespace Contasis
{
    public partial class FrmRucemisor : Form
    {
        public static FrmRucemisor instance = null;
        string control;
        string valor;

        public FrmRucemisor()
        {
            InitializeComponent();
            instance = this;
        }

        private void FrmRucemisor_Load(object sender, EventArgs e)
        {
            control = "1";
            grilla1();
        }
        public void grilla1()
        {
            try
            {
                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                {
                    Clase.rucemisor regis = new Clase.rucemisor();
                    dataGrid1.DataSource = regis.Cargar();
                }
                else
                {
                    Clase.rucemisor regis = new Clase.rucemisor();
                    dataGrid1.DataSource = regis.Cargarpostgres();
                }


                lblTotales.Text = "Total de Registros : " + Convert.ToString(dataGrid1.Rows.Count - 1);
                dataGrid1.Columns[0].HeaderText = "RUC";
                dataGrid1.Columns[0].MinimumWidth = 50;
                dataGrid1.Columns[0].Width = 100;
                dataGrid1.Columns[1].HeaderText = "EMPRESA";
                dataGrid1.Columns[1].MinimumWidth = 50;
                dataGrid1.Columns[1].Width = 374;
                dataGrid1.Columns[2].HeaderText = "ACTIVO";
                dataGrid1.Columns[2].MinimumWidth = 50;
                dataGrid1.Columns[2].Width = 100;



                dataGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGrid1.ReadOnly = true;

                if (dataGrid1.Rows.Count - 1 > 0)
                {
                    this.dataGrid1.CurrentCell = this.dataGrid1.Rows[0].Cells[1];
                    this.dataGrid1.Refresh();
                }
                this.dataGrid1.Refresh();
                control = "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No existe información para Mostrar.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control = "0";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            grilla1();
        }
        private void BtnExcel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseas exportar a un excel los usuarios", "Contasis Corpor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGrid1.Rows.Count > 0)
                {
                    FrmExportarUsuariocs Frmeexelusu = new FrmExportarUsuariocs();
                    Frmeexelusu.Show();
                }
                else
                {
                    MessageBox.Show("No existe registros a exportar", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }












            /*   Excel.Application excelApp = new Excel.Application();
               excelApp.Visible = true;
               Workbook workbook = excelApp.Workbooks.Add();
               Worksheet worksheet = (Worksheet)workbook.Sheets[1];
               worksheet.Cells.Font.Bold = true;
               worksheet.Cells[1, 2] = "CONTASIS CORP";
               worksheet.Cells[2, 2] = "REPORTE DE USUARIOS EN EL SISTEMA";
               worksheet.Cells[3, 2] = "FECHA :" + DateTime.Now.ToLongDateString();
               worksheet.Cells[4, 2] = "HORA :" + DateTime.Now.ToString("hh:mm:ss");
               worksheet.Cells.Font.Bold = true;
               int col = 1;
               int columnCount = 3;
               for (int i=0;i < columnCount; i++)




               /*int columnCount = 3;

               for (int i = 1; i < columnCount; i++)
               {
                   worksheet.Cells.Font.Bold = true;
                   worksheet.Cells[6, i + 1] = dataGrid1.Columns[i - 1].HeaderText;
                   worksheet.Cells.Font.Bold = true;
               }

               for (int j=2; j< dataGrid1.RowCount;j++)
               {
                   int i = 7;
                   int cnt = dataGrid1.RowCount;
                  /* worksheet.Cells.Font.Bold = false;*/
            /*    worksheet.Cells[7, 2].NumberFormat = "@";
                worksheet.Cells[i++, j++] = dataGrid1.Rows[0].Cells[0].Value;
                worksheet.Cells[i++, j++] = dataGrid1.Rows[0].Cells[1].Value;
            }
        */

            /** int rowCount = dataGrid1.RowCount+6 ;
             /**for (int i = 7; i < rowCount; i++)
                 for (int i = 7;  i++)
             {
                 /*for (int j = 2; j < columnCount -1; j++)
                 for (int j = 2;  j++)
                 {
                     worksheet.Cells[i , j ] = dataGrid1.Rows[i].Cells[j].Value;
                     worksheet.Cells[i , j ].NumberFormat = "@";
                 }
             }
                 **/


        }
        private void FrmRucemisor_KeyDown(object sender, KeyEventArgs e)
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
        private void btnAccesso_Click(object sender, EventArgs e)
        {
            if (dataGrid1.Rows.Count > 0)
            {
                Clase.usuarioPropiedad obj = new Clase.usuarioPropiedad();
                obj.codigo = Convert.ToString(dataGrid1.SelectedRows[0].Cells[0].Value).Trim();
                obj.nombre = Convert.ToString(dataGrid1.SelectedRows[0].Cells[1].Value).Trim();
                obj.password = Convert.ToString(dataGrid1.SelectedRows[0].Cells[2].Value).Trim();

                FrmAccesoUsuario Frmacceso = new FrmAccesoUsuario(obj.codigo, obj.nombre, obj.password);
                Frmacceso.Show();


            }
            else
            {
                MessageBox.Show("No Existe registros a modificar", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
        private void btncerrar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void btnnuevo_Click_1(object sender, EventArgs e)
        {
            FrmRuceditor Frnuevo = new FrmRuceditor(1, "", "", "");
            Frnuevo.Text = "Registrar Ruc Nuevo";
            Frnuevo.Show();

        }
        private void btnmodificar_Click_1(object sender, EventArgs e)
        {
            if (dataGrid1.Rows.Count > 0)
            {
                Clase.rucpropiedades obj = new Clase.rucpropiedades();
                obj.ruc = Convert.ToString(dataGrid1.SelectedRows[0].Cells[0].Value).Trim();
                obj.empresa = Convert.ToString(dataGrid1.SelectedRows[0].Cells[1].Value).Trim();
                obj.estado = Convert.ToString(dataGrid1.SelectedRows[0].Cells[2].Value).Trim();

                FrmRuceditor Fredit = new FrmRuceditor(2, obj.ruc, obj.empresa, obj.estado);
                Fredit.Text = "Actualizar datos del Ruc";
                Fredit.Show();

            }
            else
            {
                MessageBox.Show("No Existe registros a modificar", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseas eliminar el ruc seleccionado.?", "Contasis Corp.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGrid1.Rows.Count > 0)
                {
                    Clase.rucpropiedades obj = new Clase.rucpropiedades();


                    obj.ruc = Convert.ToString(dataGrid1.SelectedRows[0].Cells[0].Value).Trim();
                    obj.empresa = Convert.ToString(dataGrid1.SelectedRows[0].Cells[1].Value).Trim();
                    

                   /// if (Properties.Settings.Default.Usuario.Trim() == Convert.ToString(dataGrid1.SelectedRows[0].Cells[1].Value).Trim())
                   // {
                    ///    MessageBox.Show("No se puede eliminar ruc,se encuentra vinculado con empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                      ///  return;
                    ///}
                  //  else
                   // {


                        FrmEliminarruc Frmeliruc = new FrmEliminarruc(obj.ruc, obj.empresa);
                        Frmeliruc.Show();
                    ////}
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

        }
    }
}

