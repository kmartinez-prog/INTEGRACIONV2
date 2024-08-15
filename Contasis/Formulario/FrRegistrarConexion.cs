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
                MessageBox.Show("Debe de selecionar el tipo de conexion", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                                    cmbBase.Enabled = true;
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
                                    String verifica = "SELECT  * FROM SYSDATABASES WHERE NAME='bdintegradorContasis'";
                                    SqlCommand comando = new SqlCommand(verifica, connection1);
                                    
                                    DataTable dt = new DataTable();
                                    SqlDataAdapter da = new SqlDataAdapter(comando);

                                    da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    btnValidar.Enabled = true;
                                    btnGrabar.Enabled = false;
                                    lblEstado.Text = "Ya Existe la base de datos <<bdintegradorContasis>>";
                                    /***MessageBox.Show("Ya Existe la base de datos <<bdintegradorContasis>>", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);***/
                                    return;

                                }
                                else
                                {
                                    lblEstado.Text = "base de datos <<bdintegradorContasis>> sera creada";
                                    /***MessageBox.Show("base de datos <<bdintegradorContasis>> sera creada", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);***/
                                    {

                                        String verifica2 = "SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME ='Conexiones'";
                                        SqlCommand comando01 = new SqlCommand(verifica2, connection1);
                                        {
                                            DataTable dt2 = new DataTable();
                                            SqlDataAdapter da2 = new SqlDataAdapter(comando01);

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
                                                    str1 = "Create Table Conexiones(Id int Identity(1,1)," +
                                                          "cTipoBase Char(50),cServidor char(50),cUsuario Char(50)," +
                                                          "cClave char(50),cPuerto char(50),cBase char(50)," +
                                                          "cEsquema Varchar(250),cCadena varchar(150), fFechaCreacion DateTime Default Getdate()," +
                                                          "fFechaModificacion Datetime, cUsuarioCre char(5),cUsuarioModi char(5))";

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
                                                        string valor05 = txtClave.Text;
                                                        string valor06 = cmbBase.Text;
                                                        string valor09 = cmbEsquema.Text;
                                                        string valor07 = txtcadena.Text;
                                                        string valor08 = Properties.Settings.Default.Usuario;
                                                        str2 = "Insert Into Conexiones(cTipoBase,cServidor,cUsuario,cClave,cPuerto,cBase,cEsquema,cCadena,cUsuarioCre) " +
                                                        "values('" + valor01 + "','" + valor02 + "','" + valor04 + "','" + valor05 + "','" + valor03 + "','" + valor06 + "','" + valor09 + "','" + valor07 + "','" + valor08 + "')";
                                                        SqlCommand myCommand2 = new SqlCommand(str2, connection1);

                                                        Properties.Settings.Default.cadenaSql = txtcadena.Text;
                                                        Properties.Settings.Default.Save();
                                                        Properties.Settings.Default.Reload();

                                                        try
                                                        {
                                                            myCommand2.ExecuteNonQuery();
                                                            cmbOrigen.Enabled = false;
                                                            txtServidor.Enabled = false;
                                                            txtpuerto.Enabled = false;
                                                            Txtusuario.Enabled = false;
                                                            txtClave.Enabled = false;
                                                            cmbBase.Enabled = false;
                                                            cmbEsquema.Enabled = false;
                                                            txtcadena.Enabled = false;
                                                            btnValidar.Enabled = false;
                                                            btnGrabar.Enabled = true;
                                                            btnGrabar.Focus();
                                                        }
                                                        catch (System.Exception ex1)
                                                        {
                                                            MessageBox.Show(ex1.ToString(), "Contasis Corp. No se grabo las Credenciales en tabla", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                        }
                                                        connection1.Close();

                                                    }
                                                    catch (System.Exception ex)
                                                    {
                                                        MessageBox.Show(ex.ToString(), "Contasis Corp. No se pudo crear Tabla de conexiones", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                 }
                                catch (System.Exception ex)
                                {
                                    MessageBox.Show(ex.ToString(), "Contasis Corp. - Error en Credenciales", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                c.Close();
                                lblEstado.Text = "Registro de Credenciales Sql Server grabadas";
                                break;
                            }
                        
                    case 1: /** Sql Postgrel **/
                        
                        txtcadena.Text = "server=" + txtServidor.Text+ "; port=" + txtpuerto.Text + ";user id=" + Txtusuario.Text + ";password=" + txtClave.Text + ";database=contasis;";
                        ConexionPostgrelSql objetconexionPls = new ConexionPostgrelSql();
                        objetconexionPls.crearCadena(txtcadena.Text);
                        String str3;
                        string valor1 = cmbOrigen.Text;
                        string valor2 = txtServidor.Text;
                        string valor3 = txtpuerto.Text;
                        string valor4 = Txtusuario.Text;
                        string valor5 = txtClave.Text;
                        string valor6 = "contasis";
                        string valor9 = cmbEsquema.Text;
                        string valor7 = txtcadena.Text;
                        string valor8 = Properties.Settings.Default.Usuario;
                        SqlConnection connection2 = new SqlConnection(Properties.Settings.Default.cadenaSql);
                        connection2.Open();

                        if (txtcadena.Text == Properties.Settings.Default.cadenaPost)
                        {
                            MessageBox.Show("Se detecta que ya existen esas credenciales guardadas para el PostgrelSql", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;

                        }
                        else
                        {
                            str3 = "Insert Into Conexiones(cTipoBase,cServidor,cUsuario,cClave,cPuerto,cBase,cEsquema,cCadena,cUsuarioCre) " +
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
                                cmbBase.Enabled = false;
                                cmbEsquema.Enabled = false;
                                txtcadena.Enabled = false;
                                btnValidar.Enabled = false;
                                btnGrabar.Enabled = true;
                                btnGrabar.Focus();
                            }
                            catch (System.Exception ex1)
                            {
                                MessageBox.Show(ex1.ToString(), "Contasis Corp. No se grabo las Credenciales en tabla del Postgrel", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            connection2.Close();
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
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            String parametercadena = txtcadena.Text;  

            FrmCrearTablas frm = new FrmCrearTablas(parametercadena);
            frm.Show();
        }
        private void cmbBase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbOrigen_SelectedIndexChanged(object sender, EventArgs e)
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
                cmbBase.Enabled = true;
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
                cmbBase.Enabled = true;
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
    }
}
