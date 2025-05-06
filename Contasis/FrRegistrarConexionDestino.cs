using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using Npgsql;
namespace Contasis
{
    public partial class FrRegistrarConexionDestino : Form
    
    {

        public FrRegistrarConexionDestino()
        {
            InitializeComponent();
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            /*** Jalo automatico servidor **/
            txtServidor.Text = Dns.GetHostName();
            lblEstado.Text = "";
            cmbOrigen.Focus();
        }
        private void FrRegistrarConexionDestino_KeyDown(object sender, KeyEventArgs e)
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
        private void txtpuerto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void btnValidar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbOrigen.Text))
            {
                cmbOrigen.Focus();
                MessageBox.Show("Debe de selecionar el tipo de conexión donde se crean la Base de datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Txtusuario.Text))
                {
                    Txtusuario.Focus();
                    MessageBox.Show("Debe de Ingresar el Usuario", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtClave.Text))
                {
                    txtClave.Focus();
                    MessageBox.Show("Debe de Ingresar su clave", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                int opcion = cmbOrigen.SelectedIndex;
                switch (opcion)
                {
                    
                    case 0: /** Postgrel **/
                    { 
                        string estadoconepos;
                        txtcadena.Text = "server=" + txtServidor.Text + "; port=" + txtpuerto.Text + ";user id=" + Txtusuario.Text + ";password=" + txtClave.Text + ";database=contasis;";
                         
                          
                            ConexionPostgrelSql objetconexionPls = new ConexionPostgrelSql();
                            estadoconepos = objetconexionPls.CrearCadena(txtcadena.Text);
                            Clase.esconder esconde1 = new Clase.esconder();

                            if (estadoconepos == "0")
                            {
                                MessageBox.Show("Credenciales ingresadas son Invalidas para la Base de Contasis.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                NpgsqlConnection conexion = new NpgsqlConnection();
                                conexion.ConnectionString = txtcadena.Text.Trim();
                                conexion.Open();
                                /*MessageBox.Show("Credenciales ingresadas son Validas para la Base de Contasis.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                                String str3;
                                string valor1 = cmbOrigen.Text;
                                string valor2 = txtServidor.Text;
                                string valor3 = txtpuerto.Text;
                                string valor4 = Txtusuario.Text;
                                string valor6 = "contasis";
                                string valor9 = "DESTINO";
                                string valor5 = esconde1.Ocultar(txtClave.Text);
                                string valor7 = esconde1.Ocultar(txtcadena.Text);
                                string valor8 = Properties.Settings.Default.Usuario;
                                conexion.Close();

                                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                                {


                                    SqlConnection connection2 = new SqlConnection(Properties.Settings.Default.cadenaSql);
                                    connection2.Open();
                                    String verifica2 = "select * from conexiones where cubicacion='DESTINO' AND  cast(cCadena as varchar(5000)) ='" + txtcadena.Text.Trim() + "'";
                                    SqlCommand comando01 = new SqlCommand(verifica2, connection2);
                                    {
                                        DataTable dt2 = new DataTable();
                                        SqlDataAdapter da2 = new SqlDataAdapter(comando01);
                                        da2.Fill(dt2);
                                        if (dt2.Rows.Count > 0)
                                        {
                                            lblEstado.Text = "Se detecta que ya existen esas credenciales guardadas para el PostgrelSql";
                                            connection2.Close();
                                            return;
                                        }
                                        else
                                        {

                                            str3 = "Insert Into Conexiones(cTipoBase,cServidor,cUsuario,cClave,cPuerto,cBase,cubicacion,cCadena,cUsuarioCre) " +
                                            "values('" + valor1 + "','" + valor2 + "','" + valor4 + "','" + valor5 + "','" + valor3 + "','" + valor6 + "','" + valor9 + "','" + valor7 + "','" + valor8 + "')";
                                            SqlCommand myCommand3 = new SqlCommand(str3, connection2);
                                            try
                                            {
                                                myCommand3.ExecuteNonQuery();
                                                cmbOrigen.Enabled = false;
                                                txtServidor.Enabled = false;
                                                Txtusuario.Enabled = false;
                                                txtClave.Enabled = false;
                                                cmbBase.Enabled = false;
                                                cmbEsquema.Enabled = false;
                                                txtcadena.Enabled = false;
                                                btnValidar.Enabled = false;
                                                MessageBox.Show("Conexión registrada correctamente.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                lblEstado.Text = "Conexión registrada correctamente para el PostgrelSql";
                                                Principal.instance.txtcontrol.Text = "1";
                                                this.captura2();
                                                connection2.Close();
                                            }
                                            catch (System.Exception ex1)
                                            {
                                                MessageBox.Show(ex1.ToString(), "Contasis Corp. No se grabo las Credenciales en tabla del Postgrel", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            }
                                                                            
                                        }
                                    }
                                }
                                else
                                {
                                    ////   ConexionPostgrelSql objetconexionPls = new ConexionPostgrelSql();
                                    ////  estadoconepos = objetconexionPls.crearCadena(txtcadena.Text);
                                    try
                                    {
                                        /*   NpgsqlConnection conexion = new NpgsqlConnection();*/
                                        conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                                        conexion.Open();

                                        string text01 = "select distinct datname from pg_database where datname='bdintegradorcontasis'";
                                        NpgsqlCommand cmdp = new NpgsqlCommand(text01, conexion);
                                        DataTable dt = new DataTable();
                                        NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
                                        data.Fill(dt);

                                        if (dt.Rows.Count > 0)
                                        {


                                            String verifica2 = "select * from conexiones where cubicacion ='DESTINO'";
                                            NpgsqlCommand command = new NpgsqlCommand(verifica2, conexion);
                                            DataTable dt2 = new DataTable();
                                            NpgsqlDataAdapter data2 = new NpgsqlDataAdapter(command);
                                            data2.Fill(dt2);
                                            if (dt2.Rows.Count > 0)
                                            {
                                                lblEstado.Text = "Se detecta que ya existe la credencial  para el PostgrelSql";
                                                return;
                                            }
                                            else
                                            {
                                                string cvalor1 = cmbOrigen.Text;
                                                string cvalor2 = txtServidor.Text;
                                                string cvalor3 = txtpuerto.Text;
                                                string cvalor4 = Txtusuario.Text;
                                                string cvalor6 = "contasis";
                                                string cvalor9 = "DESTINO";
                                                string cvalor5 = esconde1.Ocultar(txtClave.Text);
                                                string cvalor7 = esconde1.Ocultar(txtcadena.Text);
                                                string cvalor8 = Properties.Settings.Default.Usuario;






                                                str3 = "Insert Into Conexiones(cTipoBase,cServidor,cUsuario,cClave,cPuerto,cBase,cubicacion,cCadena,cUsuarioCre) " +
                                                "values('" + cvalor1 + "','" + cvalor2 + "','" + cvalor4 + "','" + cvalor5 + "','" + cvalor3 + "','" + cvalor6 + "','" + cvalor9 + "','" + cvalor7 + "','" + cvalor8 + "')";
                                                NpgsqlCommand command1 = new NpgsqlCommand(str3, conexion);
                                                command1.ExecuteNonQuery();
                                                Properties.Settings.Default.cadenaPost = txtcadena.Text;
                                                Properties.Settings.Default.Save();
                                                Properties.Settings.Default.Reload();
                                                MessageBox.Show("Conexión registrada correctamente.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                lblEstado.Text = "Conexión registrada correctamente para el PostgrelSql";
                                                cmbOrigen.Enabled = false;
                                                txtServidor.Enabled = false;

                                                Txtusuario.Enabled = false;
                                                txtClave.Enabled = false;
                                                cmbBase.Enabled = false;
                                                cmbEsquema.Enabled = false;
                                                txtcadena.Enabled = false;
                                                btnValidar.Enabled = false;
                                                conexion.Close();


                                                Principal.instance.txtcontrol.Text = "1";
                                                this.captura4();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("No existe Base de datos en Postgrel.", "Contasis Corpo.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }

                                    }
                                    catch (System.Exception ex1)
                                    {
                                        MessageBox.Show(ex1.ToString(), "Contasis Corp. No se grabo las Credenciales en tabla del Postgrel", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                }
                            }
                 break;
                    }

                        
                }
            }
        }

        private void cmbOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrigen.SelectedIndex == 0)
            {
                txtServidor.Text = "";
                label4.Visible = true;
                txtpuerto.Visible = true;
                txtpuerto.Text = "";

                txtServidor.Enabled = true;
                txtpuerto.Enabled = true;
                Txtusuario.Enabled = true;
                txtClave.Enabled = true;
                //// cmbBase.Enabled = true;
                cmbEsquema.Enabled = true;
                txtcadena.Enabled = true;
                btnValidar.Enabled = true;

                cmbBase.Items.Clear();
                cmbBase.Text = "";

                txtServidor.Text = "";
                txtpuerto.Text = "";
                Txtusuario.Text = "";
                txtClave.Text = "";
                cmbBase.Enabled = false;
                cmbEsquema.Enabled = false;
                txtcadena.Enabled = true;
                lblEstado.Text = "";
                txtcadena.Text = "";
            }
            else
            {
                txtServidor.Text = Dns.GetHostName();

                label4.Visible = false;
                txtpuerto.Visible = false;
                txtpuerto.Text = "";
                txtServidor.Enabled = true;
                Txtusuario.Enabled = true;
                txtClave.Enabled = true;
                cmbEsquema.Enabled = true;
                txtcadena.Enabled = true;
                btnValidar.Enabled = true;

                Txtusuario.Text = "";
                txtClave.Text = "";
                cmbBase.Items.Clear();
                cmbBase.Text = "";
                cmbBase.Enabled = false;
                cmbEsquema.Enabled = false;
                txtcadena.Enabled = true;
                txtcadena.Text = "";
                lblEstado.Text = "";
            }

        }

        public void captura2()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                connection.Open();
                var command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT cCadena  FROM CONEXIONES where ctipoBase like '%PostgreSQL%'";
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                textBox1.Text = dataset.Tables[0].Rows[0][0].ToString();

                using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Public\\Documents\\pos.txt"))
                {
                    outputfile.WriteLine(textBox1.Text);
                }


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe Información de conexión a empresa." + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        public void captura4()
        {
            try
            {
                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                { }
                else
                {
                    NpgsqlConnection conexionNew = new NpgsqlConnection();
                    conexionNew.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                    conexionNew.Open();
                    var command = new NpgsqlCommand();
                    command.Connection = conexionNew;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select  ccadena  from conexiones where cbase like 'contasis%'";
                    var adapter = new NpgsqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    textBox1.Text = dataset.Tables[0].Rows[0][0].ToString();
                    using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Public\\Documents\\pos.txt"))
                    {
                        outputfile.WriteLine(textBox1.Text);
                    }
                    conexionNew.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe Información de conexión a empresa." + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void FrRegistrarConexionDestino_Load(object sender, EventArgs e)
        {

        }

        private void txtpuerto_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtpuerto_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
