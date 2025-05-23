﻿using System;
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


        public FrmRucemisor()
        {
            InitializeComponent();
            instance = this;

        }
        readonly Clase.rucpropiedades obj = new Clase.rucpropiedades();
        private void FrmRucemisor_Load(object sender, EventArgs e)
        {

            Grilla1();
        }
        public void limpiarcontrol()
        {
            obj.ruc = "";
            obj.empresa = "";
            obj.estado = "";
            obj.checkventas = 0;
            obj.checkcompras = 0;
            obj.checkcobranzas = 0;
            obj.checkpagos = 0;
            obj.ncomproductoflg = 0;
            obj.ncomcompraflg = 0;
            obj.ncomventaflg = 0;
            obj.nfondoM = 0;

            this.btneliminar.Enabled = false;
            this.btnmodificar.Enabled = false;
        }
        public void Grilla1()
        {
            try
            {
                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                {
                    Clase.rucemisor regis = new Clase.rucemisor();
                    dataGrid1.DataSource = regis.Cargar();
                    lblTotales.Text = "Total de Registros : " + Convert.ToString(dataGrid1.Rows.Count);
                    dataGrid1.AllowUserToAddRows = false;
                    lblTotales.Refresh();
                }
                else
                {
                    Clase.rucemisor regis = new Clase.rucemisor();
                    dataGrid1.DataSource = regis.Cargarpostgres();
                    lblTotales.Text = "Total de Registros : " + Convert.ToString(dataGrid1.Rows.Count);
                    dataGrid1.AllowUserToAddRows = false;
                    lblTotales.Refresh();
                }




                dataGrid1.Columns[0].HeaderText = "RUC";
                dataGrid1.Columns[0].MinimumWidth = 50;
                dataGrid1.Columns[0].Width = 100;
                dataGrid1.Columns[1].HeaderText = "EMPRESA";
                dataGrid1.Columns[1].MinimumWidth = 50;
                dataGrid1.Columns[1].Width = 374;
                dataGrid1.Columns[2].HeaderText = "ACTIVO";
                dataGrid1.Columns[2].MinimumWidth = 50;
                dataGrid1.Columns[2].Width = 100;

                if (Properties.Settings.Default.TipModulo == "1")
                {
                    dataGrid1.Columns[3].HeaderText = "EST_VENTAS";
                    dataGrid1.Columns[3].MinimumWidth = 50;
                    dataGrid1.Columns[3].Width = 100;


                    dataGrid1.Columns[4].HeaderText = "EST_COMPRAS";
                    dataGrid1.Columns[4].MinimumWidth = 50;
                    dataGrid1.Columns[4].Width = 100;

                    dataGrid1.Columns[5].HeaderText = "EST_COBRANZA";
                    dataGrid1.Columns[5].MinimumWidth = 50;
                    dataGrid1.Columns[5].Width = 100;


                    dataGrid1.Columns[6].HeaderText = "EST_PAGO";
                    dataGrid1.Columns[6].MinimumWidth = 50;
                    dataGrid1.Columns[6].Width = 100;


                    dataGrid1.Columns[7].HeaderText = "FONDO_M";
                    dataGrid1.Columns[7].MinimumWidth = 50;
                    dataGrid1.Columns[7].Width = 100;

                }

                if (Properties.Settings.Default.TipModulo == "2")
                {
                    dataGrid1.Columns[3].HeaderText = "COM_PRODUCTOS";
                    dataGrid1.Columns[3].MinimumWidth = 50;
                    dataGrid1.Columns[3].Width = 100;


                    dataGrid1.Columns[4].HeaderText = "COM_COMPRAS";
                    dataGrid1.Columns[4].MinimumWidth = 50;
                    dataGrid1.Columns[4].Width = 100;

                    dataGrid1.Columns[5].HeaderText = "COM_VENTAS";
                    dataGrid1.Columns[5].MinimumWidth = 50;
                    dataGrid1.Columns[5].Width = 100;


                    dataGrid1.Columns[6].HeaderText = "COM_COBRANZA";
                    dataGrid1.Columns[6].MinimumWidth = 50;
                    dataGrid1.Columns[6].Width = 100;

                }
                dataGrid1.AllowUserToAddRows = false;


                dataGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGrid1.ReadOnly = true;

                if (dataGrid1.Rows.Count > 0)
                {
                    this.dataGrid1.CurrentCell = this.dataGrid1.Rows[0].Cells[1];
                    this.dataGrid1.Refresh();
                }
                this.dataGrid1.Refresh();
                lblTotales.Text = "Total de Registros : " + Convert.ToString(dataGrid1.Rows.Count);
                dataGrid1.AllowUserToAddRows = false;
                lblTotales.Refresh();

            }
            catch
            {
                MessageBox.Show("No existe información para Mostrar.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.btneliminar.Enabled = false;
            this.btnmodificar.Enabled = false;
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
         //   Grilla1();
        }
        private void BtnExcel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseas exportar a un excel los usuarios", "Contasis Corpor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGrid1.Rows.Count > 0)
                {
                    FrmExportarUsuariocs Frmeexelusu = new FrmExportarUsuariocs();
                    Frmeexelusu.ShowDialog();
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
        private void BtnAccesso_Click(object sender, EventArgs e)
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
                MessageBox.Show("No Existe registros a modificar.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
        private void Btncerrar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void Btnnuevo_Click_1(object sender, EventArgs e)
        {
            FrmRuceditor Frnuevo = new FrmRuceditor(1, "", "", "", 0, 0, 0, 0, 0, 0, 0,0,0);
            Frnuevo.Text = "Registrar Ruc Nuevo";
            Frnuevo.ShowDialog();
            this.Grilla1();

        }



        private void Btnmodificar_Click_1(object sender, EventArgs e) 
        {
            FrmRuceditor Fredit = new FrmRuceditor(2, obj.ruc, obj.empresa, obj.estado, obj.checkventas, obj.checkcompras, obj.checkcobranzas, obj.nfondoM, 
                obj.ncomproductoflg, obj.ncomcompraflg, obj.ncomventaflg,obj.nfondoM,obj.check_cobranzacomercial);
            Fredit.Text = "Actualizar datos del Ruc";
            Fredit.ShowDialog();
            this.limpiarcontrol();
            this.Grilla1();
            this.btneliminar.Enabled = false;
            this.btnmodificar.Enabled = false;
        }

        private void dataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btneliminar.Enabled = true;
            this.btnmodificar.Enabled = true;
        }
        private void Btneliminar_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseas eliminar el ruc seleccionado.?", "Contasis Corp.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGrid1.Rows.Count > 0)
                {
                    Clase.rucpropiedades obj = new Clase.rucpropiedades();
                    obj.ruc = Convert.ToString(dataGrid1.SelectedRows[0].Cells[0].Value).Trim();
                    obj.empresa = Convert.ToString(dataGrid1.SelectedRows[0].Cells[1].Value).Trim();
                    FrmEliminarruc Frmeliruc = new FrmEliminarruc(obj.ruc, obj.empresa);
                    Frmeliruc.ShowDialog();
                    this.Grilla1();

                }
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Grilla1();
                this.dataGrid1.Refresh();  
                this.limpiarcontrol();
                this.btneliminar.Enabled = false;
                this.btnmodificar.Enabled = false;
                return;
            }

        }
        private void dataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            this.limpiarcontrol();
            if (dataGrid1.Rows.Count > 0)
            {
                this.btneliminar.Enabled = false;
                this.btnmodificar.Enabled = false;

                int n = e.RowIndex;
                if (n != -1)
                {
                    obj.ruc = (string)dataGrid1.Rows[n].Cells[0].Value;
                    obj.empresa = (string)dataGrid1.Rows[n].Cells[1].Value;
                    //////////MessageBox.Show((string)dataGrid1.Rows[n].Cells[0].Value);
                    


                    if (Convert.ToString(dataGrid1.Rows[n].Cells[2].Value) == "1")
                    {
                        obj.estado = "1";
                    }
                    else
                    {
                        obj.estado = "0";
                    }
                    if (Properties.Settings.Default.TipModulo == "1")
                    {

                        if (Convert.ToString(dataGrid1.SelectedRows[0].Cells[3].Value).Trim() == "1")
                        {
                            obj.checkventas = 1;
                        }
                        else
                        {
                            obj.checkventas = 0;
                        }

                        if (Convert.ToString(dataGrid1.SelectedRows[0].Cells[4].Value).Trim() == "1")
                        {
                            obj.checkcompras = 1;
                        }
                        else
                        {
                            obj.checkcompras = 0;
                        }

                        if (Convert.ToString(dataGrid1.SelectedRows[0].Cells[5].Value).Trim() == "1")
                        {
                            obj.checkcobranzas = 1;
                        }
                        else
                        {
                            obj.checkcobranzas = 0;
                        }

                        if (Convert.ToString(dataGrid1.SelectedRows[0].Cells[6].Value).Trim() == "1")
                        {
                            obj.checkpagos = 1;
                        }
                        else
                        {
                            obj.checkpagos = 0;
                        }
                        if (Convert.ToString(dataGrid1.SelectedRows[0].Cells[7].Value).Trim() == "1")
                        {
                            obj.nfondoM = 1;
                        }
                        else
                        {
                            obj.nfondoM = 0;
                        }

                    }

                    if (Properties.Settings.Default.TipModulo == "2")
                    {

                        if (Convert.ToString(dataGrid1.SelectedRows[0].Cells[3].Value).Trim() == "1")
                        {
                            obj.ncomproductoflg = 1;
                        }
                        else
                        {
                            obj.ncomproductoflg = 0;
                        }

                        if (Convert.ToString(dataGrid1.SelectedRows[0].Cells[4].Value).Trim() == "1")
                        {
                            obj.ncomcompraflg = 1;
                        }
                        else
                        {
                            obj.ncomcompraflg = 0;
                        }

                        if (Convert.ToString(dataGrid1.SelectedRows[0].Cells[5].Value).Trim() == "1")
                        {
                            obj.ncomventaflg = 1;
                        }
                        else
                        {
                            obj.ncomventaflg = 0;
                        }
                        if (Convert.ToString(dataGrid1.SelectedRows[0].Cells[6].Value).Trim() == "1")
                        {
                            obj.check_cobranzacomercial = 1;
                        }
                        else
                        {
                            obj.check_cobranzacomercial = 0;
                        }



                    }


                    /***********************/
                }

                else
                {
                    MessageBox.Show("No Existe registros a modificar", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }



            }

            }

        private void dataGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btneliminar.Enabled = true;
            this.btnmodificar.Enabled = true;
        }

        private void dataGrid1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btneliminar.Enabled = true;
            this.btnmodificar.Enabled = true;
        }
    }
 
}

