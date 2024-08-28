using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Npgsql;


namespace Contasis
{
    public partial class FrmCrearTablas : Form
    {
        public static FrmCrearTablas instance = null;
        public FrmCrearTablas(string parametro1,int opcion1,int opcion2)
        {
            InitializeComponent();
            this.txtcadena.Text = parametro1;
            this.txtopcion1.Text = opcion1.ToString();
            this.txtopcion2.Text = opcion2.ToString();

            if (opcion1.ToString() == "0")
            {
                rbfinanciero.Text = "Modulo Contable Financiero SQL";
                rbcomercial.Text = "Modulo Comercial SQL";
            }
            if (opcion1.ToString() == "1")
            {
                rbfinanciero.Text = "Modulo Contable Financiero Postgres";
                rbcomercial.Text = "Modulo Comercial Postgres";
            }


            instance = this;
        }
        int contador = 0;
        int contador1 = 0;
        int contador2 = 0;
        int contador3 = 0;
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    
        private void btncreando_Click(object sender, EventArgs e)
        {
            if (rbfinanciero.Checked == true)
            {
                MessageBox.Show("Se crean las tablas e indexes para Financiero.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (txtopcion1.Text == "0")
                {
                    crearfinanciero objetconexion = new crearfinanciero();
                    objetconexion.crearventas(txtcadena.Text);
                    crearfinanciero objetconexion1 = new crearfinanciero();
                    objetconexion1.crearcompras(txtcadena.Text);
                    crearfinanciero objetconexion2 = new crearfinanciero();
                    objetconexion2.crearadicional(txtcadena.Text);
                    crearfinanciero objetconexion3 = new crearfinanciero();
                    objetconexion3.crearindex(txtcadena.Text);
                }
                if (txtopcion1.Text == "1")
                {

                    crearfinanciero objetconexion3 = new crearfinanciero();
                    objetconexion3.activartime();

                    NpgsqlConnection conexion = new NpgsqlConnection();
                    conexion.ConnectionString = txtcadena.Text.Trim();
                    conexion.Open();
                    NpgsqlCommand command1 = new NpgsqlCommand(txtxcrearfuncion.Text, conexion);
                    command1.ExecuteNonQuery();
                    
                    string ejecutar2 = "select * from tablas_negocio_online();";
                    NpgsqlCommand command2 = new NpgsqlCommand(ejecutar2, conexion);
                    command2.ExecuteNonQuery();

                    try
                    {
                        string ejecutar6 = txtcompras2.Text;
                        NpgsqlCommand command6 = new NpgsqlCommand(ejecutar6, conexion);
                        command6.ExecuteNonQuery();

                        string ejecutar7 = soloventasonline.Text;
                        NpgsqlCommand command7 = new NpgsqlCommand(ejecutar7, conexion);
                        command7.ExecuteNonQuery();


                        timer2.Enabled = true;
                        string ejecutar3 = txtventa1.Text;
                        NpgsqlCommand command3 = new NpgsqlCommand(ejecutar3, conexion);
                        command3.ExecuteNonQuery();
                        timer2.Enabled = false;

                        timer3.Enabled = true;
                        string ejecutar4 = txtventa2.Text;
                        NpgsqlCommand command4 = new NpgsqlCommand(ejecutar4, conexion);
                        command4.ExecuteNonQuery();
                        timer3.Enabled = false;


                        timer4.Enabled = true;
                        string ejecutar5 = txtcompras1.Text;
                        NpgsqlCommand command5 = new NpgsqlCommand(ejecutar5, conexion);
                        command5.ExecuteNonQuery();


                        timer4.Enabled = true;
                        string ejecutar8 = txtversion1.Text;
                        NpgsqlCommand command8 = new NpgsqlCommand(ejecutar8, conexion);
                        command8.ExecuteNonQuery();

                        timer4.Enabled = true;
                        string ejecutar9 = txtversion2.Text;
                        NpgsqlCommand command9 = new NpgsqlCommand(ejecutar9, conexion);
                        command9.ExecuteNonQuery();

                        timer4.Enabled = true;
                        string ejecutar10 = txtversion3.Text;
                        NpgsqlCommand command10 = new NpgsqlCommand(ejecutar10, conexion);
                        command10.ExecuteNonQuery();

                        timer4.Enabled = false;

                        conexion.Close();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("" + ex);
                        ////MessageBox.Show("Ya existe el procedimiento de envio resultados de  compras", "Contasis Corp.  Modulos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }




                    timer5.Stop();
                    timer5.Enabled = false;
                    MessageBox.Show("Proceso terminado, Se ha creador las tablas y funciones en el postgresql.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }


            }

            if (rbcomercial.Checked == true)
            {
                MessageBox.Show("Se crean las tablas e index para Comercial. ", "Contasis Corp. <<no activo>>", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            contador++;
            lblventa.Text = "creando tabla " + contador.ToString() + " %";
            if (progfventas.Value < 100)
            {
                progfventas.Value++;
            }
            if (progfventas.Value == 100)
            {
                timer1.Enabled = false;
                contador = 0;
            }

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            contador1++;
            lblcompras.Text = "creando tabla " + contador1.ToString() + " %";
            if (progfcompras.Value < 100)
            {
                progfcompras.Value++;
            }
            if (progfcompras.Value == 100)
            {
                timer2.Enabled = false;
            }

        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            contador2++;
            lblotros.Text = "creando tabla " + contador2.ToString() + " %";
            if (progvarios.Value < 100)
            {
                progvarios.Value++;
            }
            if (progvarios.Value == 100)
            {
                timer3.Enabled = false;
            }

            if (progfinal.Value < 100)
            {
                progfinal.Value++;
            }
            if (progfinal.Value == 100)
            {
                timer3.Enabled = false;
            }

        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            contador3++;
            lblindex.Text = "creando Index " + contador3.ToString() + " %";
            if (progindex.Value < 100)
            {
                progindex.Value++;
            }
            if (progindex.Value == 100)
            {

                timer4.Enabled = false;
                MessageBox.Show("Proceso Terminado para Financiero Sql.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            
        }
        private void FrmCrearTablas_KeyDown(object sender, KeyEventArgs e)
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
        private void timer5_Tick(object sender, EventArgs e)
        {
            contador++;
            lblventa.Text = "creando tabla " + contador.ToString() + " %";
            if (progfventas.Value < 100)
            {
                progfventas.Value++;
            }
            if (progfventas.Value == 100)
            {
                timer1.Enabled = false;
                contador = 0;
            }

            contador3++;
            lblindex.Text = "creando Index " + contador3.ToString() + " %";
            if (progindex.Value < 100)
            {
                progindex.Value++;
            }
            if (progindex.Value == 100)
            {

                timer4.Enabled = false;

            }



            contador1++;
            lblcompras.Text = "creando tabla " + contador1.ToString() + " %";
            if (progfcompras.Value < 100)
            {
                progfcompras.Value++;
            }
            if (progfcompras.Value == 100)
            {
                timer5.Enabled = false;
            }
            contador2++;
            lblotros.Text = "creando tabla " + contador2.ToString() + " %";
            if (progvarios.Value < 100)
            {
                progvarios.Value++;
            }
            if (progvarios.Value == 100)
            {
                timer3.Enabled = false;
            }

            if (progfinal.Value < 100)
            {
                progfinal.Value++;
            }
            if (progfinal.Value == 100)
            {
                timer3.Enabled = false;
            }

        }

     
    }
    }

