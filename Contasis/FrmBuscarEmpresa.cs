using Npgsql;
using System.Data;
using System;
using System.Windows.Forms;

namespace Contasis
{
    public partial class FrmBuscarEmpresa : Form
    {
        string rucemisor;

        public FrmBuscarEmpresa(string rucunico)
        {
            InitializeComponent();
            txtbuscar.CharacterCasing = CharacterCasing.Upper;
            rucemisor = rucunico.Trim();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            
            
        }
        private void FrmBuscarEmpresa_Load(object sender, EventArgs e)
        {
            this.cargar();
            Cmbseleccion.SelectedIndex = 0;
        }
        private void cargar()
        {

            NpgsqlConnection cone = new NpgsqlConnection();
            string text01 = "select ccodemp as cod_emp,cdesemp as empresa from  cg_contasis order by ccodemp;";
            cone = Clase.ConexionPostgreslContasis.Instancial().establecerconexion();
            NpgsqlCommand cmdp = new NpgsqlCommand(text01, cone);
            
            try
            {
                cone.Open();
                NpgsqlDataReader grilla = cmdp.ExecuteReader();
                dataGridView1.Rows.Clear();
                while (grilla.Read())
                {
                    dataGridView1.Rows.Add(grilla[0], grilla[1]);

                }
                grilla.Close();
            }
            catch
            {
                MessageBox.Show("No existe información de las Empresas dentro de Contasis.","Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            seleccionar();
        }
        private void seleccionar()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    DataTable Tabla = new DataTable();
                    string valor1 = "";
                    string cadenanew = "";
                    string empresa = "";
                    string cadena = "";
                    string empresanew = "";

                    Clase.empresaPropiedades obj = new Clase.empresaPropiedades();
                    obj.codempresa = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                    obj.empresa = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
                                      
                    cadena = Properties.Settings.Default.cadenaPost;
                    empresa = "contasis_" + obj.empresa.Trim();
                    empresanew = obj.codempresa.Trim().ToLower();
                    cadenanew = cadena.Replace("contasis", "contasis_"+empresanew);
                    
                   //////// MessageBox.Show(cadenanew);

                    try
                    {
                        NpgsqlConnection cone1 = new NpgsqlConnection();
                        string text01 = "select crucemp as ruc from cg_emppro order by cper desc limit 1;";
                        cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(cadenanew);
                        cone1.Open();
                        NpgsqlCommand cmdp = new NpgsqlCommand(text01, cone1);
                        NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
                        NpgsqlDataReader leer = cmdp.ExecuteReader();
                        if (leer.Read())
                        {
                            obj.ruc = Convert.ToString(leer["ruc"]);
                        }
                        if (obj.ruc.Trim() == rucemisor.Trim())
                        { }
                        else
                        {
                            MessageBox.Show("ruc emisor no coincide con ruc de empresa seleccionada."  , "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }


                        cone1.Close();
                        
                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Clase.Empresas ds1 = new Clase.Empresas();
                        valor1 = ds1.obtenerempresa(obj);
                    if (valor1.Equals("Grabado"))
                    {
                        FrmEmpresas.instance.grilla1();
                        MessageBox.Show("Registro grabado en tabla Empresa desde el Contasis Financiero.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Empresa ya fue registrada, seleccionar otra empresa.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                try
                {

                    string valor1 = "";
                    string cadenanew = "";
                    string empresa = "";
                    string cadena = "";
                    string empresanew = "";

                    Clase.empresaPropiedades obj = new Clase.empresaPropiedades();
                    obj.codempresa = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                    obj.empresa = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);




                    cadena = Properties.Settings.Default.cadenaPost;
                    empresa = "contasis_" + obj.empresa.Trim();
                    empresanew = obj.codempresa.Trim().ToLower();
                    cadenanew = cadena.Replace("contasis", "contasis_" + empresanew);

                    try
                    {
                        NpgsqlConnection cone1 = new NpgsqlConnection();
                        string text01 = "select crucemp as ruc from cg_emppro order by cper desc limit 1;";
                        cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(cadenanew);
                        cone1.Open();
                        NpgsqlCommand cmdp = new NpgsqlCommand(text01, cone1);
                        NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
                        NpgsqlDataReader leer = cmdp.ExecuteReader();
                        if (leer.Read())
                        {
                            obj.ruc = Convert.ToString(leer["ruc"]);
                        }
                        if (obj.ruc.Trim() == rucemisor.Trim())
                        { }
                        else
                        {
                            MessageBox.Show("ruc emisor no coincide con ruc de empresa seleccionada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }


                        cone1.Close();

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    Clase.Empresas ds1 = new Clase.Empresas();
                    valor1 = ds1.obtenerempresa_postgres(obj);
                    if (valor1.Equals("Grabado"))
                    {
                        FrmEmpresas.instance.grilla1();
                        MessageBox.Show("Registro grabado en tabla Empresa desde el Contasis Financiero.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Empresa ya fue registrada, seleccionar otra empresa.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }




        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionar();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void Cmbseleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbuscar.Text = "";
            this.cargar();
            txtbuscar.Focus(); 
        }
        private void cargar_codigo(string valor)
        {
            NpgsqlConnection cone = new NpgsqlConnection();
            cone = Clase.ConexionPostgreslContasis.Instancial().establecerconexion();
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
                if (Cmbseleccion.SelectedIndex == 0)
                {
                    string query1 = "select ccodemp as Cod_emp,cdesemp as Empresa from  cg_contasis where ccodemp like '%" + txtbuscar.Text + "%' order by ccodemp;";
                    this.cargar_codigo(query1);
                    dataGridView1.Focus(); 
                }
                else
                {
                    string query1 = "select ccodemp as Cod_emp,cdesemp as Empresa from  cg_contasis where  cdesemp like '%" + txtbuscar.Text + "%' order by ccodemp;";
                    this.cargar_codigo(query1);
                    dataGridView1.Focus();
                }
                
            }
        }

        private void FrmBuscarEmpresa_KeyDown(object sender, KeyEventArgs e)
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
    }
}
