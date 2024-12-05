using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Contasis
{
    public partial class FrmLogin : Form
    {
        int  nveces;
        string control,control2,control3;
        public FrmLogin()
        {
            InitializeComponent();
            txtfrase.Text = "contasis";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbusuario.Text == "")
            {
                MessageBox.Show("Debe de Seleccionar un usuario", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbusuario.Focus();
            }
            else
            {           

                    if (txtclave.Text == txtfrase.Text)
                    {
                        Properties.Settings.Default.Usuario = cmbusuario.Text;
                        Properties.Settings.Default.Save();
                        Properties.Settings.Default.Reload();

                        Principal menu = new Principal(control);
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (nveces < 2)
                        {
                            MessageBox.Show("la clave esta errada", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtclave.Text = "";
                            txtclave.Focus();
                            nveces += 1;
                        }
                        else
                        {
                            MessageBox.Show("Acabaste tus 3 Intentos", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.Hide();
                            this.Close();
                        }
                    }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Hide();
            }
        }
        public void llenarcombo()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                ////connection.Open();
                var command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT CDESUSU,PASSWORD  FROM CG_USUARIO";
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                cmbusuario.Items.Clear(); 
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                {
                    cmbusuario.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                    cmbusuario.Refresh();

                }
                connection.Close();
            }
            catch 
            {
                MessageBox.Show("Error no Existe Informacion en la tabla usuario, use clave inicial."  , "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }



        }
        public void version1()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                ////connection.Open();
                var command1 = new System.Data.SqlClient.SqlCommand();
                command1.Connection = connection;
                command1.CommandType = CommandType.Text;
                command1.CommandText = "SELECT cversion+'-['+convert(char(10),cfecha,103)+']' as version  FROM  cg_version";
                var adapter1 = new System.Data.SqlClient.SqlDataAdapter(command1);
                var dataset1 = new DataSet();
                adapter1.Fill(dataset1);
                for (int i = 0; i < dataset1.Tables[0].Rows.Count; i++)
                {
                    Properties.Settings.Default.version = dataset1.Tables[0].Rows[i][0].ToString();
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Error no Existe Información en la tabla versión.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }



        }
        public void llenarcombo2()
        {
            try
            {
                NpgsqlConnection conexionNew = new NpgsqlConnection();
                conexionNew.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                conexionNew.Open();
                var command = new NpgsqlCommand();
                command.Connection = conexionNew;
                command.CommandType = CommandType.Text;
                command.CommandText = "select cdesusu,password from cg_usuario";
                var adapter = new NpgsqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                cmbusuario.Items.Clear();
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                {
                    cmbusuario.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                    cmbusuario.Refresh();

                }

                var command1 = new NpgsqlCommand();
                command1.Connection = conexionNew;
                command1.CommandType = CommandType.Text;
                command1.CommandText = "select concat(ltrim(cversion),'-[',to_char(cfecha,'dd/mm/yyyy'),']') as version from cg_version";
                var adapter1 = new NpgsqlDataAdapter(command1);
                var dataset1 = new DataSet();
                adapter1.Fill(dataset1);
                
                for (int i = 0; i < dataset1.Tables[0].Rows.Count; i++)

                {
                    
                    Properties.Settings.Default.version = dataset1.Tables[0].Rows[i][0].ToString();
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                }




                conexionNew.Close();
            }
            catch 
            {
                MessageBox.Show("Error no Existe Informacion en la tabla usuario, use clave inicial.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }



        }
        public void version2()
        {
            try
            {
                NpgsqlConnection conexionNew = new NpgsqlConnection();
                conexionNew.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                conexionNew.Open();
                var command = new NpgsqlCommand();
                command.Connection = conexionNew;
                command.CommandType = CommandType.Text;
                command.CommandText = "select concat(ltrim(cversion),'-[',to_char(cfecha,'dd/mm/yyyy'),']') as version from cg_version";
                var adapter = new NpgsqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                {
                    Properties.Settings.Default.version = dataset.Tables[0].Rows[i][0].ToString();
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
                 conexionNew.Close();
            }
            catch
            {
                MessageBox.Show("Error no Existe Información en la tabla versión.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }



        }
        public void capturarclave()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                connection.Open();
                var command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT TOP 1 PASSWORD  FROM CG_USUARIO where CDESUSU='"+ cmbusuario.Text+ "'";
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                txtfrase.Text = "";
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                {
                  txtfrase.Text= dataset.Tables[0].Rows[i][0].ToString();
                }
                connection.Close();
            }
            catch 
            {
                MessageBox.Show("Error no Existe Informacion de conexion a empresa." , "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        public void capturarclave2()
        {
            try
            {
                NpgsqlConnection conexionNew = new NpgsqlConnection();
                conexionNew.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                conexionNew.Open();


                var command = new NpgsqlCommand();
                command.Connection = conexionNew;
                command.CommandType = CommandType.Text;
                command.CommandText = "select distinct password  from cg_usuario where cdesusu='" + cmbusuario.Text + "'";
                var adapter = new NpgsqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                {
                    txtfrase.Text = dataset.Tables[0].Rows[i][0].ToString();
                }
                conexionNew.Close();
            }
            catch 
            {
                MessageBox.Show("Error no Existe Informacion de conexion a empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }


        }
        public string Mostrar(string _cadena)
        {
            string resultado = string.Empty;
            Byte[] descrcriptar = Convert.FromBase64String(_cadena);
            resultado = System.Text.Encoding.Unicode.GetString(descrcriptar);
            return resultado;
        }
        public void revisar()
        {

            string ubicacion = @"C:\\Users\\Public\\Documents\\SQL.txt";
            if (File.Exists(ubicacion))
            {
                this.conexiones();
                this.conexion0();
                this.Modulo_Sql();
                control2 = "1";
            }
            else
            {
                control2 = "0";
            }

            /**** valida que exista bbase de datos ***/
            string respuesta = "";
            Clase.LeerUsuarios ds = new Clase.LeerUsuarios();
            respuesta = ds.validaUsuario();
            control = respuesta;
            if (control == "1")
            {
                this.existetablausuario();
            }

            if (control == "1" && control2 == "1" && control3 == "1")
            {
                control = "1";
                this.llenarcombo();
                this.captura1();
                this.captura2();
                this.version1();
                return;
            }

            else
            {

                if (control3 == "1")
                {
                    MessageBox.Show("Bienvenido al Sistema de Integración.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                   
            }

        }
        public void revisar2()
        {
            string ubicacion = @"C:\\Users\\Public\\Documents\\PostgreSQL.txt";
            if (File.Exists(ubicacion))
            {
                this.conexion2();
                this.conexion0();
                this.Modulo_postgres();
                control2 = "1";
            }
            else
            {
                control2 = "0";
            }
            
            /**** valida que exista bbase de datos postgrel ***/
            string respuesta = "";
            Clase.LeerUsuarios ds = new Clase.LeerUsuarios();
            respuesta = ds.validaUsuario2();
            control = respuesta;
            if (control == "1")
            {
                this.existetablausuario2();
            }
                if (control=="1"  && control2== "1" && control3 == "1")
                {
                     control = "1";
                    this.llenarcombo2();
                    this.version2();
                    this.captura3();
                    this.captura4();
                   
                }
        
                else
                {

                if (control3 == "1")
                {
                    MessageBox.Show("Bienvenido al Sistema de Integración.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bienvenido al Sistema de Integración por primera vez.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                control = "0";
                txtfrase.Text = "contasis";
                }
            
        }
        private async void FrmLogin_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.cadenaSql = "";
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            Properties.Settings.Default.cadenaPostPrincipal = "";
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();


            Properties.Settings.Default.cadenaPost = "";
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            Properties.Settings.Default.cadenaweb = "";
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            Properties.Settings.Default.version = "";
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            Properties.Settings.Default.TipModulo = "";
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

         /*   Clase.esconder Mostrar = new Clase.esconder();
            textBox3.Text = Mostrar.Mostrar("cwBlAHIAdgBlAHIAPQBsAG8AYwBhAGwAaABvAHMAdAA7ACAAcABvAHIAdAA9ADUANAAzADIAOwB1AHMAZQByACAAaQBkAD0AcABvAHMAdABnAHIAZQBzADsAcABhAHMAcwB3AG8AcgBkAD0AcABvAHMAdABnAHIAZQBzADsAZABhAHQAYQBiAGEAcwBlAD0AYwBvAG4AdABhAHMAaQBzADsA");
            textBox4.Text = Mostrar.Mostrar("cwBlAHIAdgBlAHIAPQBkAGEAdABhAGIAYQBzAGUALQBzAHEAbABjAG8AbgB0AGEAcwBpAHMALQBkAGEAcgB3AGkAbgAuAGMAbwBhADAAbgB1AGgANwA3AHcAbQBwAC4AdQBzAC0AZQBhAHMAdAAtADIALgByAGQAcwAuAGEAbQBhAHoAbwBuAGEAdwBzAC4AYwBvAG0AOwAgAHAAbwByAHQAPQA1ADQAMwAyADsAdQBzAGUAcgAgAGkAZAA9AHAAbwBzAHQAZwByAGUAcwA7AHAAYQBzAHMAdwBvAHIAZAA9AFMAUQBMAGMAMABuAHQANABzADEAcwAqADIAMgA7AGQAYQB0AGEAYgBhAHMAZQA9AG8AbgBwAHIAZQBtAGkAcwBzAGUAZABiADsA");
         */

            this.revisar();
            if (control == "0" || control=="")
            {
                this.revisar2();
                if (control=="0" || control=="")
                        {

                            ////MessageBox.Show("Bienvenido al Sistema de Integración por primera vez.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            control = "0";
                            txtfrase.Text = "contasis";
                        }

            }
            await new Clase.ValidarVersion().Validar();

        }
        private void cmbusuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (control == "1")
            {
                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                {
                    this.capturarclave();
                    Clase.esconder Mostrar = new Clase.esconder();
                    txtfrase.Text = Mostrar.Mostrar(txtfrase.Text);
                    txtfrase.Refresh();
                }
                else
                {
                    this.capturarclave2();
                    Clase.esconder Mostrar = new Clase.esconder();
                    txtfrase.Text = Mostrar.Mostrar(txtfrase.Text);
                    txtfrase.Refresh();
                }
            }
            else
            { 
                    txtfrase.Text = "contasis";
                
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
               

                textBox2.Text=dataset.Tables[0].Rows[0][0].ToString();
               


                using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Public\\Documents\\SQL.txt"))
                    {
                    outputfile.WriteLine(textBox2.Text);
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
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                connection.Open();
                var command = new System.Data.SqlClient.SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT cCadena  FROM CONEXIONES where ctipoBase like '%PostgreSQL%'";
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var dataset = new DataSet();
                adapter.Fill(dataset);
                textBox2.Text = dataset.Tables[0].Rows[0][0].ToString();

                using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Public\\Documents\\pos.txt"))
                {
                    outputfile.WriteLine(textBox2.Text);
                }


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe Informacion de conexion de destino de la empresa " + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }



        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cmbusuario.Text == "")
            {
                MessageBox.Show("Debe de Seleccionar un usuario", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbusuario.Focus();
            }
            else
            {

                if (txtclave.Text == txtfrase.Text)
                {
                    Properties.Settings.Default.Usuario = cmbusuario.Text;
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                    Principal menu = new Principal(control);
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    if (nveces < 2)
                    {
                        MessageBox.Show("la clave esta errada", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtclave.Text = "";
                        txtclave.Focus();
                        nveces += 1;
                    }
                    else
                    {
                        MessageBox.Show("Acabaste tus 3 Intentos", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Hide();
                        this.Close();
                    }
                }
            }
        }
        private void cmbusuario_SelectedValueChanged(object sender, EventArgs e)
        {
            if (control == "1")
            {
                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                {
                    this.capturarclave();
                    Clase.esconder Mostrar = new Clase.esconder();
                    txtfrase.Text = Mostrar.Mostrar(txtfrase.Text);


                   

                    txtfrase.Refresh();
                }
                else
                {
                    this.capturarclave2();
                    Clase.esconder Mostrar = new Clase.esconder();
                    txtfrase.Text = Mostrar.Mostrar(txtfrase.Text);
                    txtfrase.Refresh();
                }
            }
            else
            {
                txtfrase.Text = "contasis";

            }
        }
        private void cmbusuario_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (control == "1")
            {
                if (txtfrase.Text.Trim() == "")
                { }
                else
                {
                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {
                        this.capturarclave();
                        Clase.esconder Mostrar = new Clase.esconder();
                        txtfrase.Text = Mostrar.Mostrar(txtfrase.Text);
                        txtfrase.Refresh();
                    }
                    else
                    {
                        this.capturarclave2();
                        Clase.esconder Mostrar = new Clase.esconder();
                        txtfrase.Text = Mostrar.Mostrar(txtfrase.Text);
                        txtfrase.Refresh();
                    }
                }


            }
            else
            {
                txtfrase.Text = "contasis";

            }
        }
        public void conexiones()
        {
            string ubicacion = @"C:\\Users\\Public\\Documents\\SQL.txt";
            if (File.Exists(ubicacion))
            {
                string cadenaSql = System.IO.File.ReadAllText(@"C:\Users\Public\Documents\SQL.txt");
                cadenaSql = Mostrar(cadenaSql);
                Properties.Settings.Default.cadenaSql = cadenaSql;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            else
            {
                Properties.Settings.Default.cadenaSql = "";
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();

            }

            string ubicacion2 = @"C:\Users\Public\Documents\pos.txt";
            if (File.Exists(ubicacion2))
            {
                string cadenaPostgrel = System.IO.File.ReadAllText(@"C:\Users\Public\Documents\pos.txt");
                cadenaPostgrel = Mostrar(cadenaPostgrel);
                Properties.Settings.Default.cadenaPost = cadenaPostgrel;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            else
            {
                Properties.Settings.Default.cadenaPost = "";
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }

        }
        public void conexion2()
        {

            Properties.Settings.Default.cadenaSql = "";
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            string ubicacion = @"C:\Users\Public\Documents\PostgreSQL.txt";
            if (File.Exists(ubicacion))
            {
                string cadenaPostgrelPrincipal = System.IO.File.ReadAllText(@"C:\Users\Public\Documents\PostgreSQL.txt");
                
                cadenaPostgrelPrincipal = Mostrar(cadenaPostgrelPrincipal);
                Properties.Settings.Default.cadenaPostPrincipal = cadenaPostgrelPrincipal;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            else
            {
                Properties.Settings.Default.cadenaPostPrincipal = "";
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }


            string ubicacion2 = @"C:\Users\Public\Documents\pos.txt";
            if (File.Exists(ubicacion2))
            {
                string cadenaPostgrel = System.IO.File.ReadAllText(@"C:\Users\Public\Documents\pos.txt");

                cadenaPostgrel = Mostrar(cadenaPostgrel);

                Properties.Settings.Default.cadenaPost = cadenaPostgrel;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            else
            {
                Properties.Settings.Default.cadenaPostPrincipal = "";
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }

        }
        public void conexion0()
        {
            try
            {
                FileStream x = File.OpenRead("C:\\Users\\Public\\Documents\\WEB.txt");


                string cadenaweb = System.IO.File.ReadAllText(@"C:\Users\Public\Documents\WEB.txt");

                cadenaweb = Mostrar(cadenaweb);


                Properties.Settings.Default.cadenaweb = cadenaweb;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
            catch 
            { 
            ///MessageBox.Show("No existe archivo de ruta web." ,"Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        public void existetablausuario()
        {
            SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
            connection.Open();
            string verifica = "SELECT* FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'CG_USUARIO'";
                SqlCommand comando1 = new SqlCommand(verifica, connection);
                {
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(comando1);

                    da1.Fill(dt1);
                if (dt1.Rows.Count == 0)
                {
                    control3 = "0";
                    txtfrase.Text = "contasis";
                }
                else
                {
                    string verifica2 = "SELECT * FROM CG_USUARIO";
                    SqlCommand comando2 = new SqlCommand(verifica2, connection);
                    {
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(comando2);

                        da2.Fill(dt2);
                        if (dt2.Rows.Count == 0)
                        {
                            control3 = "0";
                        }
                        else
                        {
                            control3 = "1";
                        }
                    }
                }
                connection.Close();
                }
            }
        public void existetablausuario2()
        {
            NpgsqlConnection conexionNew = new NpgsqlConnection();
            conexionNew.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexionNew.Open();
            string text03 = "select distinct table_name FROM information_schema.columns where table_name='cg_usuario'";
            NpgsqlCommand cmdp3 = new NpgsqlCommand(text03, conexionNew);
            DataTable dt1 = new DataTable();
            NpgsqlDataAdapter data1 = new NpgsqlDataAdapter(cmdp3);
            data1.Fill(dt1);
            if (dt1.Rows.Count == 0)
            {
                control3 = "0";
                txtfrase.Text = "contasis";
            }
            else
            {
                string usuario2 = "select * from cg_usuario";
                NpgsqlCommand cmdp4 = new NpgsqlCommand(usuario2, conexionNew);
                DataTable dt2 = new DataTable();
                NpgsqlDataAdapter data2 = new NpgsqlDataAdapter(cmdp4);
                data2.Fill(dt2);
                if (dt2.Rows.Count == 0)
                {
                    control3 = "0";
                }
                else
                {
                    control3 = "1";
                }
            }
            conexionNew.Close();
        }
        public void captura3()
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
                textBox2.Text = dataset.Tables[0].Rows[0][0].ToString();
                using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Public\\Documents\\PostgreSQL.txt"))
                {
                    outputfile.WriteLine(textBox2.Text);
                }


                conexionNew.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe Informacion de conexion a empresa " + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

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
                textBox2.Text = dataset.Tables[0].Rows[0][0].ToString();
                using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Public\\Documents\\pos.txt"))
                {
                    outputfile.WriteLine(textBox2.Text);
                }


                conexionNew.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe Informacion de conexion a empresa " + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Modulo_Sql()
        {
            try
            {
                SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                connection.Open();
                Clase.Estructura_SQL obj = new Clase.Estructura_SQL();
                string NombreTable = "conexiones";
                string Nombrecampo = "nModulo";
                string Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " int not null default 0;";
                string respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);


                string query0 = "SELECT* FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = 'com_documento'";
                SqlCommand commando = new SqlCommand(query0, connection);
                DataTable dt = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string actualizar = "Update CONEXIONES set nModulo=2";
                    SqlCommand comando2 = new SqlCommand(actualizar, connection);
                    comando2.ExecuteReader();
                    Properties.Settings.Default.TipModulo = "2";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                }
                else
                {
                    string actualizar = "Update CONEXIONES set nModulo=1";
                    SqlCommand comando2 = new SqlCommand(actualizar, connection);
                    comando2.ExecuteReader();
                    Properties.Settings.Default.TipModulo = "1";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe Informacion de conexion a empresa " + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        public void Modulo_postgres()
        {
            
                NpgsqlConnection conexionNew = new NpgsqlConnection();
                conexionNew.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            try
            {
                conexionNew.Open();

                Clase.Estructura_postgres obj = new Clase.Estructura_postgres();
                string NombreTable = "conexiones";
                string Nombrecampo = "nmodulo";
                string Query = "alter table " + NombreTable.Trim().ToLower() + " add column " + Nombrecampo.Trim().ToLower() + " integer;";
                string respuesta = obj.crear_Campos_nuevos_en_tablas(NombreTable, Nombrecampo, Query);
                //// MessageBox.Show(respuesta);
                ///


                string query = "SELECT * FROM INFORMATION_SCHEMA.columns where TABLE_NAME = 'com_documento'";
                NpgsqlCommand commando = new NpgsqlCommand(query, conexionNew);


                DataTable dt = new DataTable();
                NpgsqlDataAdapter data = new NpgsqlDataAdapter(commando);
                data.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    string actualizar = "Update conexiones set nmodulo=2";
                    NpgsqlCommand comando2 = new NpgsqlCommand(actualizar, conexionNew);
                    comando2.ExecuteReader();
                    Properties.Settings.Default.TipModulo = "2";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();

                }
                else
                {
                    string actualizar = "Update conexiones set nmodulo=1";
                    NpgsqlCommand comando2 = new NpgsqlCommand(actualizar, conexionNew);
                    comando2.ExecuteReader();
                    Properties.Settings.Default.TipModulo = "1";
                    Properties.Settings.Default.Save();
                    Properties.Settings.Default.Reload();
                }
                conexionNew.Close();
            }
            catch 
            {
               /* string fileName = @"C:\\Users\\Public\\Documents\\PostgreSQL.txt";

                if (File.Exists(fileName))
                {
                    try
                    {
                        File.Delete(fileName);
                    }
                    catch (Exception e)
                    {
                        
                    }
                }
                else
                {
                   
                }
               */

                MessageBox.Show("Error no Existe Información de conexión a empresa.","Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        /*******************************************************************************/

    }
}
    
    
