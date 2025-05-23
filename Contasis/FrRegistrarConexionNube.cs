﻿using System;
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
    public partial class FrRegistrarConexionNube : Form
    {
        public FrRegistrarConexionNube()
        {
            InitializeComponent();
        }

        private void FrRegistrarConexionNube_Load(object sender, EventArgs e)
        {
            /*** Jalo automatico servidor **/
            txtServidor.Text = "";
            ///txtServidor.Text = Dns.GetHostName();
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

                
                txtbase.Text = "";

                txtServidor.Text = "";
                txtpuerto.Text = "";
                Txtusuario.Text = "";
                txtClave.Text = "";
                
                cmbEsquema.Enabled = false;
                txtcadena.Enabled = true;
                lblEstado.Text = "";
                txtcadena.Text = "";
            }
            else
            {
                txtServidor.Text = Dns.GetHostName();

                label4.Visible = true;
                txtpuerto.Visible = true;
                txtpuerto.Text = "";
                txtServidor.Enabled = true;
                Txtusuario.Enabled = true;
                txtClave.Enabled = true;
                cmbEsquema.Enabled = true;
                txtcadena.Enabled = true;
                btnValidar.Enabled = true;

                Txtusuario.Text = "";
                txtClave.Text = "";
                txtbase.Text = "";
                
                
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
            catch 
            {
                MessageBox.Show("Error no Existe Información de conexión a empresa." , "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        public void captura4()
        {
            try
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
            catch 
            {
                MessageBox.Show("Error no Existe Información de conexión a empresa." , "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        public void captura5()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                    connection.Open();
                    var command = new System.Data.SqlClient.SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT cCadena  FROM CONEXIONES where cubicacion like '%WEB%'";
                    var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    textBox1.Text = dataset.Tables[0].Rows[0][0].ToString();

                    using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Public\\Documents\\WEB.txt"))
                    {
                        outputfile.WriteLine(textBox1.Text);
                    }


                    connection.Close();
                }
                catch 
                {
                    MessageBox.Show("Error no Existe Información de conexión a empresa." , "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
             try
            {
                NpgsqlConnection conexionNew = new NpgsqlConnection();
                conexionNew.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                conexionNew.Open();
                var command = new NpgsqlCommand();
                command.Connection = conexionNew;
                command.CommandType = CommandType.Text;
                command.CommandText = "select  ccadena  from conexiones where cubicacion like 'WEB%'";
                var adapter = new NpgsqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                textBox1.Text = dataset.Tables[0].Rows[0][0].ToString();
                using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Public\\Documents\\WEB.txt"))
                {
                    outputfile.WriteLine(textBox1.Text);
                }


                conexionNew.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe Información de conexión a empresa." + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbOrigen.Text))
            {
                cmbOrigen.Focus();
                MessageBox.Show("Debe de selecionar el tipo de conexión donde se crea la Base de datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                            
                            txtcadena.Text = "server=" + txtServidor.Text + "; port=" + txtpuerto.Text + ";user id=" + Txtusuario.Text + ";password=" + txtClave.Text + ";database="+txtbase.Text+";";
                            Clase.esconder esconde1 = new Clase.esconder();
                            String str3;
                            string valor1 = cmbOrigen.Text;
                            string valor2 = txtServidor.Text;
                            string valor3 = txtpuerto.Text;
                            string valor4 = Txtusuario.Text;
                            string valor6 = txtbase.Text;
                            string valor9 = "WEB";
                            string valor5 = esconde1.Ocultar(txtClave.Text);
                            string valor7 = esconde1.Ocultar(txtcadena.Text);
                            string valor8 = Properties.Settings.Default.Usuario;


                            if (Properties.Settings.Default.cadenaPostPrincipal == "")
                            {
                                
                                SqlConnection connection2 = new SqlConnection(Properties.Settings.Default.cadenaSql);
                                connection2.Open();
                                String verifica2 = "select * from conexiones where cast(cCadena as varchar(5000)) = '" + txtcadena.Text.Trim() + "'";
                                SqlCommand comando01 = new SqlCommand(verifica2, connection2);
                                {
                                    DataTable dt2 = new DataTable();
                                    SqlDataAdapter da2 = new SqlDataAdapter(comando01);

                                    da2.Fill(dt2);
                                    if (dt2.Rows.Count > 0)
                                    {
                                        lblEstado.Text = "Se detecta que existe esa credencial guardada en el PostgrelSql.";
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
                                                txtpuerto.Enabled = false;
                                                Txtusuario.Enabled = false;
                                                txtClave.Enabled = false;
                                                txtbase.Enabled = false;
                                                cmbEsquema.Enabled = false;
                                                txtcadena.Enabled = false;
                                                btnValidar.Enabled = false;
                                            MessageBox.Show("Conexión registrada correctamente.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            lblEstado.Text = "Conexion valida y guardada en base del PostgrelSql.";
                                            Principal.instance.txtcontrol.Text = "1";
                                                this.captura5();
                                            }
                                            catch 
                                            {
                                                MessageBox.Show("No se grabo las credenciales en el Postgrel.", "Contasis Corp.",  MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            }
                                        
                                        connection2.Close();
                                    }
                                }
                            }
                            else
                            {
                                
                                    try
                                {
                                    NpgsqlConnection conexion = new NpgsqlConnection();
                                    conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal.Trim();
                                    conexion.Open();
                                    string text01 = "select distinct datname from pg_database where datname='bdintegradorcontasis'";
                                    NpgsqlCommand cmdp = new NpgsqlCommand(text01, conexion);
                                    DataTable dt = new DataTable();
                                    NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
                                    data.Fill(dt);

                                    if (dt.Rows.Count > 0)
                                    {
                                        lblEstado.Text = "ya existe esta base de datos en el PostgrelSql.";
                                    
                                        String verifica2 = "select * from conexiones where cCadena ='" + txtcadena.Text.Trim() + "'";
                                        NpgsqlCommand command = new NpgsqlCommand(verifica2, conexion);
                                        DataTable dt2 = new DataTable();
                                        NpgsqlDataAdapter data2 = new NpgsqlDataAdapter(command);
                                        data2.Fill(dt2);
                                        if (dt2.Rows.Count > 0)
                                        {
                                            lblEstado.Text = "Se detecta que ya existe la credencial en el PostgrelSql";
                                            return;
                                        }
                                        else

                                        {
                                            str3 = "Insert Into Conexiones(cTipoBase,cServidor,cUsuario,cClave,cPuerto,cBase,cubicacion,cCadena,cUsuarioCre) " +
                                            "values('" + valor1 + "','" + valor2 + "','" + valor4 + "','" + valor5 + "','" + valor3 + "','" + valor6 + "','" + valor9 + "','" + valor7 + "','" + valor8 + "')";
                                            NpgsqlCommand command1 = new NpgsqlCommand(str3, conexion);
                                            command1.ExecuteNonQuery();

                                            Properties.Settings.Default.cadenaweb = txtcadena.Text;
                                            Properties.Settings.Default.Save();
                                            Properties.Settings.Default.Reload();

                                            cmbOrigen.Enabled = false;
                                            txtServidor.Enabled = false;
                                            txtpuerto.Enabled = false;
                                            Txtusuario.Enabled = false;
                                            txtClave.Enabled = false;
                                            txtbase.Enabled = false;
                                            cmbEsquema.Enabled = false;
                                            txtcadena.Enabled = false;
                                            btnValidar.Enabled = false;
                                            conexion.Close();
                                            MessageBox.Show("Conexión registrada correctamente.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            lblEstado.Text = "Conexión valida y guardada en base del PostgrelSql.";
                                            
                                            Principal.instance.txtcontrol.Text = "1";
                                            this.captura5();
                                        }
                                    }
                                }
                                catch 
                                {
                                    MessageBox.Show("No se grabo las credenciales en tabla del Postgrel.", "Contasis Corp.",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                            break;
                        }


                }
            }
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
