using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class FrmExportarUsuariocs : Form
    {
        public FrmExportarUsuariocs()
        {
            InitializeComponent();
        }

        private void FrmExportarUsuariocs_Load(object sender, EventArgs e)
        {

        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            SqlDataReader carga;
            Excel.Application excelApp = new Excel.Application();
            SqlConnection cone = new SqlConnection();
            try
            {
                string query = "Select ccodusu as CODIGO,CDESUSU as USUARIOS From CG_usuario order by ccodusu asc";
                cone = Clase.ConexionSql.Instancial().establecerconexion();
                SqlCommand commando = new SqlCommand(query, cone);
                cone.Open();
                carga = commando.ExecuteReader();

                
                excelApp.Visible = true;
                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = (Worksheet)workbook.Sheets[1];
                worksheet.Cells.Font.Bold = true;
                worksheet.Cells[1, 2] = "CONTASIS CORP";
                worksheet.Cells[2, 2] = "REPORTE DE USUARIOS EN EL SISTEMA";
                worksheet.Cells[3, 2] = "FECHA :" + DateTime.Now.ToLongDateString();
                worksheet.Cells[4, 2] = "HORA :" + DateTime.Now.ToString("hh:mm:ss");

                /**   int col = 1;
                  for (int i = 0; i < carga.FieldCount+1; i++)
                  {
                      worksheet.Cells[6, col].Value2 = carga.GetName(i);
                      col++;
                  }

                 int row = 7;
                  while (carga.Read())
                  {
                      col = 1;
                      for (int i = 0; i < carga.FieldCount; i++)
                      {
                          worksheet.Cells[row, col].Value2 = carga[i];
                          col++;
                      }
                      row++;
                  
                  }

                  *******/
                string tempFile = System.IO.Path.GetTempFileName() + ".xls";
                workbook.SaveAs(tempFile);


            }
            catch (Exception ex1)
            {
                throw ex1;
            }
            finally
            {
                if (cone.State == ConnectionState.Open)
                {
                    cone.Close();
                }

            }












            
        }

        private void FrmExportarUsuariocs_KeyDown(object sender, KeyEventArgs e)
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

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }
    }
}
