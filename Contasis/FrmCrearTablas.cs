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
        public FrmCrearTablas(string parametro1, int opcion1, int opcion2)
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
        int contador6 = 0;
        
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btncreando_Click(object sender, EventArgs e)
        {
            if (rbfinanciero.Checked == true)
            {
                MessageBox.Show("Se crean las tablas,procedimiento,funciones e indexes para Financiero.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                        string cModulo = "update conexiones set nmodulo=1;";
                        NpgsqlCommand command20 = new NpgsqlCommand(cModulo, conexion);
                        command20.ExecuteNonQuery();
                        Properties.Settings.Default.TipModulo = "1";
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();


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
                MessageBox.Show("Se crean las tablas,procedimiento,funciones e indexes para Comercial. ", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (txtopcion1.Text == "0")
                {
                    crearcomercial objetconexion1 = new crearcomercial();
                    objetconexion1.crearcabeceracomercial(txtcadena.Text);
                    objetconexion1.creardetallecomercial(txtcadena.Text);
                    objetconexion1.crearproductocomercial(txtcadena.Text);
                    objetconexion1.creartablasdelsistema(txtcadena.Text);
                    objetconexion1.crearotros(txtcadena.Text);
                }
                if (txtopcion1.Text == "1")
                {
                    
                  //  crearfinanciero objetconexion3 = new crearfinanciero();
                  //  objetconexion3.activartime();

                    NpgsqlConnection conexion = new NpgsqlConnection();
                    conexion.ConnectionString = txtcadena.Text.Trim();
                    conexion.Open();
                    NpgsqlCommand command1 = new NpgsqlCommand(Funcion_comercial.Text, conexion);
                    command1.ExecuteNonQuery();

                    string ejecutar2 = "select * from tablas_negocio_online_comercial();";
                    NpgsqlCommand command2 = new NpgsqlCommand(ejecutar2, conexion);
                    command2.ExecuteNonQuery();

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



                    string cModulo = "update conexiones set nmodulo=2;";
                    NpgsqlCommand command20 = new NpgsqlCommand(cModulo, conexion);
                    command20.ExecuteNonQuery();
                    Properties.Settings.Default.TipModulo = "2";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();


                    try
                    {
                       

                        timer4.Enabled = true;
                        
                        string ejecutar5 = func_guardar_com_documento.Text;
                        NpgsqlCommand command5 = new NpgsqlCommand(ejecutar5, conexion);
                        command5.ExecuteNonQuery();

                        string ejecutar6 = func_guardar_com_producto.Text;
                        NpgsqlCommand command6 = new NpgsqlCommand(ejecutar6, conexion);
                        command6.ExecuteNonQuery();



                        string ejecutar18 = txtversion1.Text;
                        NpgsqlCommand command18 = new NpgsqlCommand(ejecutar18, conexion);
                        command18.ExecuteNonQuery();

                        timer4.Enabled = true;
                        string ejecutar19 = txtversion2.Text;
                        NpgsqlCommand command19 = new NpgsqlCommand(ejecutar19, conexion);
                        command19.ExecuteNonQuery();

                        timer4.Enabled = true;
                        string ejecutar20 = txtversion3.Text;
                        NpgsqlCommand command290 = new NpgsqlCommand(ejecutar20, conexion);
                        command290.ExecuteNonQuery();

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
                if (rbfinanciero.Checked == true)
                {
                    MessageBox.Show("Proceso Terminado para Financiero Sql.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (rbcomercial.Checked == true)
                {

                    MessageBox.Show("Proceso Terminado para Comercial Sql.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
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

        private void rbfinanciero_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = true;
            progindex.Visible = true;
            lblindex.Visible = true;
            label4.Text = "Creando Tablas Intermedias";

            contador = 0;
            label2.Text = "Creando Tablas Fin_Ventas";
            lblventa.Text = "creando tabla " + contador.ToString() + " %";
            this.progfventas.Value = 0;

            contador1=0;
            label3.Text = "Creando Tablas Fin_Compras";
            lblcompras.Text = "creando tabla " + contador1.ToString() + " %";
            this.progfcompras.Value = 0;

            label5.Visible = false;
            label8.Visible = false;
            progreotrastablas.Visible = false;
            contador2 =0;
            label5.Text = "Creando Servicios";
            lblotros.Text = "creando tabla " + contador2.ToString() + " %";
            this.progvarios.Value = 0;
        }

        private void rbcomercial_CheckedChanged(object sender, EventArgs e)
        {

            label6.Visible =false;
            progindex.Visible = false;
            lblindex.Visible = false;
            label4.Text = "Creando Tablas Intermedias Proc.y Func.";

            label5.Visible = true;
            label8.Visible = true;
            progreotrastablas.Visible = true;
            
            progreotrastablas.Value = progreotrastablas.Minimum;
            progfinal.Value= progfinal.Minimum;
            label8.Text = "creando tabla " + contador.ToString() + " %";

            contador = 0;
            label2.Text = "Creando Tabla Com_documento";
            lblventa.Text = "creando tabla " + contador.ToString() + " %";
            this.progfventas.Value = 0;
            
            contador1 = 0;
            label3.Text = "Creando Tabla Com_detalledocumento";
            lblcompras.Text = "creando tabla " + contador1.ToString() + " %";
            this.progfcompras.Value = 0;
            
            contador2 = 0;
            label5.Text = "Creando Tabla Com_producto";
            lblotros.Text = "creando tabla " + contador2.ToString() + " %";
            this.progvarios.Value = 0;
            progvarios.Value = progvarios.Minimum;
            contador3 = 0;
            lblindex.Text = "creando tabla " + contador3.ToString() + " %";
           

        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            contador6++;
            label8.Text = "creando tabla " + contador6.ToString() + " %";
            if (progreotrastablas.Value < 100)
            {
                progreotrastablas.Value++;
            }
            if (progreotrastablas.Value == 100)
            {
                timer6.Enabled = false;
                contador6 = 0;
            }
            
            lblotros.Text = "creando tabla " + contador6.ToString() + " %";
            if (progvarios.Value < 100)
            {
                progvarios.Value++;
            }
            if (progvarios.Value == 100)
            {
                timer6.Enabled = false;
            }
            
            if (progfinal.Value < 100)
            {
                progfinal.Value++;
            }
            if (progfinal.Value == 100)
            {
                timer6.Enabled = false;
                contador6 = 0;
            }

        }

        private void FrmCrearTablas_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
            label8.Visible = false;
            progreotrastablas.Visible = false;
        }

      
    }   
}

