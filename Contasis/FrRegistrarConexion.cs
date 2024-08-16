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
    public partial class FrRegistrarConexion : Form
    {
        
        public FrRegistrarConexion()
        {
            InitializeComponent();
         }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbOrigen.Text))
            {
                cmbOrigen.Focus();
                MessageBox.Show("Debe de selecionar el tipo de conexion donde se crean la Base de datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    case 0: /** Sql server **/
                        {
                            
                                txtcadena.Text = "Data Source=" + txtServidor.Text + ";Initial Catalog=Master;user id=" + Txtusuario.Text + ";password=" + txtClave.Text + "";

                                Establecerconexion objetconexion = new Establecerconexion();
                                objetconexion.crearCadena(txtcadena.Text);
                                SqlConnection c = new SqlConnection(txtcadena.Text);
                                try
                                {
                                    c.Open();
                                    ////cmbBase.Enabled = true;
                                    SqlConnection connection0 = new SqlConnection(txtcadena.Text);
                                    connection0.Open();
                                    var command0 = new System.Data.SqlClient.SqlCommand();
                                    command0.Connection = connection0;
                                    command0.CommandType = CommandType.Text;
                                    command0.CommandText = "select @@SERVERNAME as servidor";
                                    var adapter0 = new System.Data.SqlClient.SqlDataAdapter(command0);
                                    var dataset0 = new DataSet();
                                    adapter0.Fill(dataset0);
                                    DataTable dtDatabases0 = dataset0.Tables[0];
                                    txtServidor.Text = dataset0.Tables[0].Rows[0][0].ToString();
                                    connection0.Close();


                                    /***********************************************************************/
                                    SqlConnection connection = new SqlConnection(txtcadena.Text);
                                    connection.Open();
                                    var command = new System.Data.SqlClient.SqlCommand();
                                    command.Connection = connection;
                                    command.CommandType = CommandType.Text;
                                    command.CommandText = "SELECT NAME FROM MASTER.SYS.databases  ORDER BY CREATE_DATE DESC";
                                    var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                                    var dataset = new DataSet();
                                    adapter.Fill(dataset);
                                    DataTable dtDatabases = dataset.Tables[0];
                                    String NewBase = dataset.Tables[0].Rows[0][0].ToString();
                                    cmbBase.Text = dataset.Tables[0].Rows[0][0].ToString();
                                    for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                                    {
                                        cmbBase.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                                        cmbBase.Refresh();
                                        txtcadena.Text = "Data Source=" + txtServidor.Text + ";Initial Catalog=" + NewBase + ";user id=" + Txtusuario.Text + ";password=" + txtClave.Text + "";
                                    }
                                    connection.Close();

                                    Establecerconexion objetconexion1 = new Establecerconexion();
                                    objetconexion1.crearCadena(txtcadena.Text);
                                    SqlConnection connection1 = new SqlConnection(txtcadena.Text);
                                    connection1.Open();
                                    String verifica = "SELECT * FROM SYSDATABASES WHERE NAME='bdintegradorContasis'";
                                    SqlCommand comando = new SqlCommand(verifica, connection1);

                                    DataTable dt = new DataTable();
                                    SqlDataAdapter da = new SqlDataAdapter(comando);

                                    da.Fill(dt);
                                    if (dt.Rows.Count > 0)
                                    {
                                        btnValidar.Enabled = true;
                                        btnGrabar.Enabled = false;
                                        lblEstado.Text = "Ya Existe la base de datos <<bdintegradorContasis>>";





                                        String verifica1 = "SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME ='Conexiones'";
                                        SqlCommand comando00 = new SqlCommand(verifica1, connection1);
                                        {
                                            DataTable dt2 = new DataTable();
                                            SqlDataAdapter da2 = new SqlDataAdapter(comando00);

                                            da2.Fill(dt2);
                                            if (dt2.Rows.Count > 0)
                                            {
                                                lblEstado.Text = "Ya existe la tabla creada  sera creada";

                                                return;

                                            }
                                            else
                                            {
                                                lblEstado.Text = "se estara creando la tabla conexiones";
                                                /***MessageBox.Show("base de datos <<bdintegradorContasis>> sera creada", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);**/
                                                {
                                                    String str1;
                                                    str1 = "Create Table conexiones(Id int Identity(1,1)," +
                                                           "cTipoBase Char(250),cubicacion Char(250),cServidor text,cUsuario Char(250)," +
                                                           "cClave text,cPuerto char(50),cBase char(250)," +
                                                           "cEsquema Varchar(250),cCadena text, fFechaCreacion DateTime Default Getdate()," +
                                                           "fFechaModificacion Datetime, cUsuarioCre char(35),cUsuarioModi char(35))";

                                                SqlCommand myCommand1 = new SqlCommand(str1, connection1);
                                                    try
                                                    {
                                                        myCommand1.ExecuteNonQuery();

                                                        lblEstado.Text = "Tabla Conexiones ha sido creada y se ha guardado los datos de conexión del Sql Server";
                                                        String str2;
                                                        string valor01 = cmbOrigen.Text;
                                                        string valor02 = txtServidor.Text;
                                                        string valor03 = txtpuerto.Text;
                                                        string valor04 = Txtusuario.Text;
                                                        string valor06 = cmbBase.Text;
                                                      
                                                        string valor08 = Properties.Settings.Default.Usuario;
                                                        string valor09 = "ORIGEN";
                                                        Clase.esconder ocultar = new Clase.esconder();
                                                        string valor05 = ocultar.Ocultar(txtClave.Text);
                                                        string valor07 = ocultar.Ocultar(txtcadena.Text);
                                                        
                                                        str2 = "Insert Into Conexiones(cTipoBase,cServidor,cUsuario,cClave,cPuerto,cBase,cubicacion,cCadena,cUsuarioCre) " +
                                                            "values('" + valor01 + "','" + valor02 + "','" + valor04 + "','" + valor05 + "','" + valor03 + "','" + valor06 + "','" + valor09 + "','" + valor07 + "','" + valor08 + "')";
                                                        SqlCommand myCommand2 = new SqlCommand(str2, connection1);
                                                        Properties.Settings.Default.cadenaSql = txtcadena.Text;
                                                        Properties.Settings.Default.Save();
                                                        Properties.Settings.Default.Reload();



                                                        try
                                                        {
                                                            myCommand2.ExecuteNonQuery();
                                                            cmbOrigen.Text = "";
                                                            txtServidor.Text = "";
                                                            txtpuerto.Text = "";
                                                            Txtusuario.Text = "";
                                                            txtClave.Text = "";
                                                            ///cmbBase.Enabled = true;
                                                            cmbEsquema.Enabled = false;
                                                            txtcadena.Enabled = false;
                                                            btnGrabar.Enabled = true;
                                                            btnGrabar.Focus();

                                                        }
                                                        catch (System.Exception ex1)
                                                        {
                                                            MessageBox.Show("Error, favor revise", "Contasis Corp. No se grabo las Credenciales en tabla", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                        }
                                                        connection1.Close();

                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        MessageBox.Show("Tablas no se pudo crear.", "Contasis Corp. No se pudo crear Tabla de conexiones", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                                catch (System.Exception ex)
                                {
                                    MessageBox.Show("Revise las credenciales.", "Contasis Corp. - Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                c.Close();
                                lblEstado.Text = "Registro de Credenciales Sql Server grabadas";
                                Principal.instance.txtcontrol.Text = "1";
                                this.captura1();
                            
                           

                                break;
                            
                            }
                        
                    case 1: /** Sql Postgrel **/
                        { 
                            string estadoconepos;
                            txtcadena.Text = "server=" + txtServidor.Text + "; port=" + txtpuerto.Text + ";user id=" + Txtusuario.Text + ";password=" + txtClave.Text + ";database=contasis;";
                            ConexionPostgrelSql objetconexionPls = new ConexionPostgrelSql();
                            estadoconepos = objetconexionPls.crearCadena(txtcadena.Text);
                            Clase.esconder esconde1 = new Clase.esconder();
                       
                            try
                            {

                                NpgsqlConnection conexion = new NpgsqlConnection();
                                conexion.ConnectionString = txtcadena.Text.Trim();
                                conexion.Open();
                                string text01 = "select distinct datname from pg_database where datname='bdintegradorcontasis'";
                                NpgsqlCommand cmdp = new NpgsqlCommand(text01, conexion);
                                DataTable dt = new DataTable();
                                NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
                                data.Fill(dt);
                                string conexionnewpos = txtcadena.Text.Replace("contasis", "bdintegradorcontasis");
                                if (dt.Rows.Count > 0)
                                {
                                    lblEstado.Text = "ya existe esta base de datos en el PostgrelSql";
                                }
                                else
                                {

                                    string text02 = "create database bdintegradorcontasis;";
                                    NpgsqlCommand cmdp2 = new NpgsqlCommand(text02, conexion);
                                    cmdp2.ExecuteNonQuery();
                                    MessageBox.Show("Se ha creado la base de datos con existo.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    conexion.Close();
                                    NpgsqlConnection conexionNew = new NpgsqlConnection();
                                    conexionNew.ConnectionString = conexionnewpos.Trim();
                                    conexionNew.Open();
                                    string text03 = "select distinct table_schema FROM information_schema.columns where table_schema='conexiones'";
                                    NpgsqlCommand cmdp3 = new NpgsqlCommand(text03, conexionNew);
                                    DataTable dt1 = new DataTable();
                                    NpgsqlDataAdapter data1 = new NpgsqlDataAdapter(cmdp3);
                                    data1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    lblEstado.Text = "ya existe la tabla de conexiones en bdintegradorcontasis";
                                }
                                else
                                {
                                    string text04 = "create sequence sec_id_conexion minvalue 1 maxvalue 9999999999 increment by 1 ;" +
                                    "Create Table conexiones(id int default nextval('sec_id_conexion')," +
                                    "ctipobase Char(250), cubicacion Char(250),cservidor text, cusuario Char(250)," +
                                    "cclave text, cpuerto char(50), cbase char(250)," +
                                    "cesquema Varchar(250), ccadena text, fFechacreacion timestamp," +
                                    "ffechamodificacion timestamp, cusuarioCre char(35), cusuariomodi char(35));";
                                    NpgsqlCommand cmdp4 = new NpgsqlCommand(text04, conexionNew);
                                    cmdp4.ExecuteNonQuery();

                                    String str33;
                                    string malor1 = cmbOrigen.Text;
                                    string malor2 = txtServidor.Text;
                                    string malor3 = txtpuerto.Text;
                                    string malor4 = Txtusuario.Text;
                                    string malor6 = "bdintegradorcontasis";
                                    string malor5 = esconde1.Ocultar(txtClave.Text);
                                    string malor7 = esconde1.Ocultar(conexionnewpos);
                                    string malor8 = Properties.Settings.Default.Usuario;
                                    string malor9 = "DESTINO";
                                    str33 = "Insert Into conexiones(ctipobase,cservidor,cusuario,cclave,cpuerto,cbase,cubicacion,ccadena,cusuariocre) " +
                                   "values('" + malor1 + "','" + malor2 + "','" + malor4 + "','" + malor5 + "','" + malor3 + "','" + malor6 + "','" + malor9 + "','" + malor7 + "','" + malor8 + "')";
                                    NpgsqlCommand cmdp5 = new NpgsqlCommand(str33, conexionNew);
                                    Properties.Settings.Default.cadenaPostPrincipal = conexionnewpos;
                                    Properties.Settings.Default.Save();
                                    Properties.Settings.Default.Reload();
                                    cmdp5.ExecuteNonQuery();


                                }
                                        cmbOrigen.Enabled = false;
                                        txtServidor.Enabled = false;
                                        txtpuerto.Enabled = false;
                                        Txtusuario.Enabled = false;
                                        txtClave.Enabled = false;
                                        cmbBase.Enabled = false;
                                        cmbEsquema.Enabled = false;
                                        txtcadena.Enabled = false;
                                        btnValidar.Enabled = false;
                                        btnGrabar.Enabled = false;
                                        MessageBox.Show("Conexion registrada correctamente", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        Principal.instance.txtcontrol.Text = "1";
                                        txtcadena.Text = conexionnewpos;
                                        btnGrabar.Enabled = true;
                                        btnGrabar.Focus();
                                        conexionNew.Close();
                                        this.captura2();
                                        Principal.instance.txtcontrol.Text = "1";
                                }
                                
                            }
                            catch (System.Exception ex1)
                            {
                                MessageBox.Show(ex1.ToString(), "Contasis Corp. no se ha creado la base de datos en Postgrel", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }


                        }
                            
                        break;
                }
            }
            }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*** Jalo automatico servidor **/
            txtServidor.Text = Dns.GetHostName();
            lblEstado.Text = "";
            cmbOrigen.Focus();
        }
        private void FrRegistrarConexion_KeyDown(object sender, KeyEventArgs e)
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
        private void btnGrabar_Click_1(object sender, EventArgs e)
        {
            int opcion = cmbOrigen.SelectedIndex;
            
            
                String parametercadena = txtcadena.Text;
                FrmCrearTablas frm = new FrmCrearTablas(parametercadena,opcion, 0);
                frm.Show();
            

        }
        private void cmbOrigen_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbOrigen.SelectedIndex == 1)
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
                btnGrabar.Enabled = false;
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
                btnGrabar.Enabled = false;
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
        public void captura1()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                connection.Open();
                var command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT cCadena  FROM CONEXIONES where ctipoBase like '%SQL%'";
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);


                textBox1.Text = dataset.Tables[0].Rows[0][0].ToString();



                using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Public\\Documents\\SQL.txt"))
                {
                    outputfile.WriteLine(textBox1.Text);
                }


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe Informacion de conexion a empresa " + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        public void captura2()
        {
            try
            {
                NpgsqlConnection conexionNew = new NpgsqlConnection();
                conexionNew.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                conexionNew.Open();
                var command = new NpgsqlCommand();
                command.Connection = conexionNew;
                command.CommandType = CommandType.Text;
                command.CommandText = "select  ccadena  from conexiones where cbase like '%bdintegradorcont%'";
                var adapter = new NpgsqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                textBox1.Text = dataset.Tables[0].Rows[0][0].ToString();
                using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Public\\Documents\\PostgreSQL.txt"))
                {
                    outputfile.WriteLine(textBox1.Text);
                }


                conexionNew.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe Informacion de conexion a empresa " + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }



        }


    }



    }

