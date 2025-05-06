using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Contasis
{
    public partial class FrmBuscarCuenta : Form
    {

        public static FrmBuscarCuenta  instance = null;

        public FrmBuscarCuenta(int codigo,string cadena,string periodo,string modulo)
        {
            InitializeComponent();

            txtcodigo.Text = codigo.ToString();
            txtcadenas.Text = cadena;
            txtperiodo.Text = periodo;
            txtModulo.Text = modulo; 
        }

        private void FrmBuscarCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Hide();
            }
        }
        private void FrmBuscarCuenta_Load(object sender, EventArgs e)
        {
            this.cargar();
            cmbbuscar.SelectedIndex = 1; 
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void cargar()
        {




            NpgsqlConnection cone = new NpgsqlConnection();
            /** para ventas **/
            if (txtcodigo.Text == "1")
            {
               txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN ORDER BY CCODORI ASC";
            }
            if (txtcodigo.Text == "2")
            {
                txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU ORDER BY CCODSU ASC";
            }
            if (txtcodigo.Text == "3")
            {
                txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN ORDER BY CCODORI ASC";
            }
            if (txtcodigo.Text == "4")
            {
                txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU ORDER BY CCODSU ASC";
            }
            if (txtcodigo.Text == "5")
            {
                txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='"+ txtperiodo.Text + "'  AND NANACUE=3 ORDER BY CCODCUE ASC";
            }
            if (txtcodigo.Text == "6")
            {
                txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='" + txtperiodo.Text + "'  AND NANACUE=3 ORDER BY CCODCUE ASC";
            }
            if (txtcodigo.Text == "7")
            {
                txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
            }
            /** para compras **/
            if (txtcodigo.Text == "8")
            {
                txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN ORDER BY CCODORI ASC";
            }
            if (txtcodigo.Text == "9")
            {
                txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU ORDER BY CCODSU ASC";
            }
            if (txtcodigo.Text == "10")
            {
                txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN ORDER BY CCODORI ASC";
            }
            if (txtcodigo.Text == "11")
            {
                txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU ORDER BY CCODSU ASC";
            }
            if (txtcodigo.Text == "12")
            {
                txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='" + txtperiodo.Text + "'  AND NANACUE=3 ORDER BY CCODCUE ASC";
            }
            if (txtcodigo.Text == "13")
            {
                txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='" + txtperiodo.Text + "'  AND NANACUE=3 ORDER BY CCODCUE ASC";
            }
            if (txtcodigo.Text == "14")
            {
                txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
            }
            if (txtcodigo.Text == "15")
            {
                txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN ORDER BY CCODORI ASC";
            }
            if (txtcodigo.Text == "16")
            {
                    txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU ORDER BY CCODSU ASC";
            }
            if (txtcodigo.Text == "17")
            {
                txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
            }
            if (txtcodigo.Text == "18")
            {
                txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN ORDER BY CCODORI ASC";
            }
            if (txtcodigo.Text == "19")
            {
                txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU ORDER BY CCODSU ASC";
            }
            if (txtcodigo.Text == "20")
            {
                txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
            }
            if (txtcodigo.Text == "21")
            {
                txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN ORDER BY CCODORI ASC";
            }
            if (txtcodigo.Text == "22")
            {
                txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU ORDER BY CCODSU ASC";
            }

            if (txtcodigo.Text == "23")
            {
                txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN ORDER BY CCODORI ASC";
            }
            if (txtcodigo.Text == "24")
            {
                txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU ORDER BY CCODSU ASC";
            }
            if (txtcodigo.Text == "25")
            {
                txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
            }



            cone = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadenas.Text);
            NpgsqlCommand cmdp = new NpgsqlCommand(txtquery.Text, cone);
            cone.Open();
            NpgsqlDataReader grilla = cmdp.ExecuteReader();
            while (grilla.Read())
            {
                dataGridView1.Rows.Add(grilla[0], grilla[1]);

            }
            lblTotales.Text = "Total de Registros : " + Convert.ToString(dataGridView1.Rows.Count - 1);


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;

            if (dataGridView1.Rows.Count - 1 > 0)
            {
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[0].Cells[1];
                this.dataGridView1.Refresh();
            }

            else

            {
                lblTotales.Text = "Total de Registros : 0";
            }
            this.dataGridView1.Refresh();

            grilla.Close();
        }
        private void seleccionar()
        {
            if (this.txtModulo.Text == "F")
            {
                /*** LINEAS PARA VENTAS **/
                if (txtcodigo.Text == "1")
                {
                    FrmIntegradorConta.instance.txtCSUB1.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "2")
                {
                    FrmIntegradorConta.instance.txtCLREG1.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "3")
                {
                    FrmIntegradorConta.instance.txtCSUB2.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "4")
                {
                    FrmIntegradorConta.instance.txtCLREG2.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "5")
                {
                    FrmIntegradorConta.instance.txtCCONTS.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "6")
                {
                    FrmIntegradorConta.instance.txtCCONTD.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "7")
                {
                    FrmIntegradorConta.instance.txtCFEFEC.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                /*** LINEAS PARA COMPRAS **/
                if (txtcodigo.Text == "8")
                {
                    FrmIntegradorConta.instance.txtCSUB1_com.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "9")
                {
                    FrmIntegradorConta.instance.txtCLREG1_com.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "10")
                {
                    FrmIntegradorConta.instance.txtCSUB2_com.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "11")
                {
                    FrmIntegradorConta.instance.txtCLREG2_com.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "12")
                {
                    FrmIntegradorConta.instance.txtCCONTS_com.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "13")
                {
                    FrmIntegradorConta.instance.txtCCONTD_com.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "14")
                {
                    FrmIntegradorConta.instance.txtCFEFEC_com.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "15")
                {
                    FrmIntegradorConta.instance.txtsubdiario_cobra.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());

                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "16")
                {
                    FrmIntegradorConta.instance.txtregistro_cobra.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "17")
                {
                    FrmIntegradorConta.instance.txtflujocobra.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "18")
                {
                    FrmIntegradorConta.instance.txtsubdiario_pago.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "19")
                {
                    FrmIntegradorConta.instance.txtregistro_pago.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "20")
                {
                    FrmIntegradorConta.instance.txtflujopago.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "21")
                {
                    FrmIntegradorConta.instance.txtanticipo.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());

                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "22")
                {
                    FrmIntegradorConta.instance.txtregistro_cobra_alternativo.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }


                if (txtcodigo.Text == "23")
                {
                    FrmIntegradorConta.instance.txtsubdiario_fondo.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }

                if (txtcodigo.Text == "24")
                {
                    FrmIntegradorConta.instance.txtregistro_fondo.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "25")
                {
                    FrmIntegradorConta.instance.txtflujofondo.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }

            }

            if (this.txtModulo.Text == "C")
            {
                /*** LINEAS PARA VENTAS **/
                if (txtcodigo.Text == "1")
                {
                    FrmIntegradorComercial.instance.txtsubdiario_cobra.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    ////FrmIntegradorComercial.instance.l   .Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "2")
                {
                    FrmIntegradorComercial.instance.txtregistro_cobra.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                if (txtcodigo.Text == "7")
                {
                    FrmIntegradorComercial.instance.txtflujocobra.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
                    BtnSalir.PerformClick();
                }
                

            }



        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.seleccionar();
        }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.seleccionar();
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.seleccionar();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.seleccionar();
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                {
                this.seleccionar();
                }
        }
        private void cmbbuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbuscar.Text = "";
            this.cargar();
            txtbuscar.Focus();
        }
        private void cargar_codigo(string valor)
        {
            NpgsqlConnection cone = new NpgsqlConnection();
            cone = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadenas.Text);
            NpgsqlCommand cmdp = new NpgsqlCommand(valor, cone);
            cone.Open();
            NpgsqlDataReader grilla = cmdp.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (grilla.Read())
            {
                dataGridView1.Rows.Add(grilla[0], grilla[1]);
            }
            grilla.Close();
        }
        private void txtbuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbbuscar.SelectedIndex == 0)
                {
                    /** para ventas **/
                    if (txtcodigo.Text == "1")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "2")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU   where CCODSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "3")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN   where CCODORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "4")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  where CCODSU like '%" + txtbuscar.Text + "%' ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "5")
                    {
                        txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='" + txtperiodo.Text + "'  and ccodcue like '%" + txtbuscar.Text + "%'  AND NANACUE=3 ORDER BY CCODCUE ASC";
                    }
                    if (txtcodigo.Text == "6")
                    {
                        txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='" + txtperiodo.Text + "'  and ccodcue like '%" + txtbuscar.Text + "%'   AND NANACUE=3 ORDER BY CCODCUE ASC";
                    }
                    if (txtcodigo.Text == "7")
                    {
                        txtquery.Text = "Select ccodflu AS COD,, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and  ccodflu  like '%" + txtbuscar.Text + "%' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                    }
                    /** para compras **/
                    if (txtcodigo.Text == "8")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN    where CCODORI like '%" + txtbuscar.Text + "%' ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "9")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  where CCODSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "10")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN    where CCODORI like '%" + txtbuscar.Text + "%' ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "11")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  where CCODSU like '%" + txtbuscar.Text + "%' ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "12")
                    {
                        txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='" + txtperiodo.Text + "'   and ccodcue like '%" + txtbuscar.Text + "%'  AND NANACUE=3 ORDER BY CCODCUE ASC";
                    }
                    if (txtcodigo.Text == "13")
                    {
                        txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='" + txtperiodo.Text + "'  and ccodcue like '%" + txtbuscar.Text + "%'   AND NANACUE=3 ORDER BY CCODCUE ASC";
                    }
                    if (txtcodigo.Text == "14")
                    {
                        txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and  ccodflu  like '%" + txtbuscar.Text + "%' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                    }
                    if (txtcodigo.Text == "15")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "16")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU   where CCODSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "17")
                    {
                        txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and  ccodflu  like '%" + txtbuscar.Text + "%' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                    }

                    if (txtcodigo.Text == "18")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "19")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU   where CCODSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "20")
                    {
                        txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and  ccodflu  like '%" + txtbuscar.Text + "%' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                    }
                    if (txtcodigo.Text == "21")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "22")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU   where CCODSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "23")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "24")
                    {

                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU   where CCODSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "25")
                    {
                        txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and  ccodflu  like '%" + txtbuscar.Text + "%' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                    }




                    this.cargar_codigo(txtquery.Text);
                    dataGridView1.Focus();
                }
                else
                {
                    /** para ventas **/
                    if (txtcodigo.Text == "1")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CDESORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "2")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU   where CDESSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "3")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN   where CDESORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "4")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  where CDESSU like '%" + txtbuscar.Text + "%' ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "5")
                    {
                        txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='" + txtperiodo.Text + "'  and CDESCUE like '%" + txtbuscar.Text + "%'  AND NANACUE=3 ORDER BY CCODCUE ASC";
                    }
                    if (txtcodigo.Text == "6")
                    {
                        txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='" + txtperiodo.Text + "'  and CDESCUE like '%" + txtbuscar.Text + "%'   AND NANACUE=3 ORDER BY CCODCUE ASC";
                    }
                    if (txtcodigo.Text == "7")
                    {
                        txtquery.Text = "Select ccodflu AS COD,, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and  cdesflu  like '%" + txtbuscar.Text + "%' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                    }
                    /** para compras **/
                    if (txtcodigo.Text == "8")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN    where CDESORI like '%" + txtbuscar.Text + "%' ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "9")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  where CDESSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "10")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN    where CDESORI like '%" + txtbuscar.Text + "%' ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "11")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  where CDESSU like '%" + txtbuscar.Text + "%' ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "12")
                    {
                        txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='" + txtperiodo.Text + "'   and CDESCUE like '%" + txtbuscar.Text + "%'  AND NANACUE=3 ORDER BY CCODCUE ASC";
                    }
                    if (txtcodigo.Text == "13")
                    {
                        txtquery.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CPER='" + txtperiodo.Text + "'  and CDESCUE like '%" + txtbuscar.Text + "%'   AND NANACUE=3 ORDER BY CCODCUE ASC";
                    }
                    if (txtcodigo.Text == "14")
                    {
                        txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and  cdesflu  like '%" + txtbuscar.Text + "%' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                    }
                    if (txtcodigo.Text == "15")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "15")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "16")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU   where CCODSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "17")
                    {
                        txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and  ccodflu  like '%" + txtbuscar.Text + "%' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                    }

                    if (txtcodigo.Text == "18")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "19")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU   where CCODSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "20")
                    {
                        txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and  ccodflu  like '%" + txtbuscar.Text + "%' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                    }
                    if (txtcodigo.Text == "21")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "22")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU   where CCODSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "23")
                    {
                        txtquery.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI like '%" + txtbuscar.Text + "%'  ORDER BY CCODORI ASC";
                    }
                    if (txtcodigo.Text == "24")
                    {
                        txtquery.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU   where CCODSU like '%" + txtbuscar.Text + "%'  ORDER BY CCODSU ASC";
                    }
                    if (txtcodigo.Text == "25")
                    {
                        txtquery.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where cper='" + txtperiodo.Text + "' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                    }

                    this.cargar_codigo(txtquery.Text);
                    dataGridView1.Focus();
                }

            }
        }
    }
}
