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
    public partial class FrmIntegradorComercial : Form
    {
        string xCodempresa;
        string xtipomovi;
        string xcontrol;
        string xmodulo;
      /*  string xMovimiento;*/
        public static FrmIntegradorComercial instance = null;
        public FrmIntegradorComercial()
        {
            InitializeComponent();
            instance = this;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        public void Ruc()
        {
            try
            {
                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                {

                    SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                    connection.Open();
                    var command = new System.Data.SqlClient.SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select ltrim(ccodrucemisor)+'-'+ltrim(cdesrucemisor) as emisor" +
                    " from cg_empemisor where flgactivo='1'";
                    var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    cmbrucemisor.Items.Clear();
                    if (dataset.Tables.Count == 0)
                    {
                        MessageBox.Show("No existe datos el ruc emisor para seleccionar.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Close();
                    }
                    else
                    {

                        DataTable dtDatabases = dataset.Tables[0];
                        string NewBase = dataset.Tables[0].Rows[0][0].ToString();

                        cmbrucemisor.Text = dataset.Tables[0].Rows[0][0].ToString();
                        
                        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                        {
                            cmbrucemisor.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                            cmbrucemisor.Refresh();

                        }
                    }

                    connection.Close();
                }
                else
                {
                    NpgsqlConnection conexion = new NpgsqlConnection();
                    conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                    conexion.Open();
                    var command = new NpgsqlCommand();
                    command.Connection = conexion;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select ltrim(ccodrucemisor)||'-'||ltrim(cdesrucemisor)::character(60) as emisor " +
                    "nventaflg as venta,ncompraflg as compra,ncobranzaflg as cobranza,npagoflg as pago " +
                    " from cg_empemisor where flgactivo='1'";
                    var adapter = new NpgsqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    
                    cmbrucemisor.Items.Clear();
                    if (dataset.Tables.Count == 0)
                    {
                        MessageBox.Show("No existe datos de ruc emisor para  seleccionar.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Close();
                    }
                    else
                    {

                        DataTable dtDatabases = dataset.Tables[0];
                        String NewBase = dataset.Tables[0].Rows[0][0].ToString();
                        cmbrucemisor.Text = dataset.Tables[0].Rows[0][0].ToString();

                        
                        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
                        {
                            cmbrucemisor.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                            cmbrucemisor.Refresh();
                        }
                    }

                    conexion.Close();

                }
            }
            catch
            {
                MessageBox.Show("Error no Existe Informacion de  empresa, favor en registrar una empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }



        }
        private void empresas()
        {
            try
            {
                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                {
                    SqlConnection connection = new SqlConnection(Properties.Settings.Default.cadenaSql);
                    connection.Open();
                    var command = new System.Data.SqlClient.SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "Select CCOD_EMPRESA+'-'+NOMEMPRESA AS EMPRESA,nventaflg as venta," +
                    "ncompraflg as compra,ncobranzaflg as cobranza,npagoflg as pago  from cg_empresa inner join cg_empemisor on " +
                    "cg_empresa.ccodrucemisor = cg_empemisor.ccodrucemisor " +
                    " where cg_empemisor.flgActivo = 1 ";
                    var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                 
                    if (dataset.Tables.Count == 0)
                    {
                        MessageBox.Show("No existe datos de empresa seleccionada empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Close();
                    }
                    else
                    {
                        DataTable dtDatabases = dataset.Tables[0];
                        String NewBase = dataset.Tables[0].Rows[0][0].ToString();
                        cmbempresas.Text = dataset.Tables[0].Rows[0][0].ToString();

                        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                        {
                            cmbempresas.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                            cmbempresas.Refresh();
                        }
                    }

                    connection.Close();
                }
                else
                {
                    NpgsqlConnection conexion = new NpgsqlConnection();
                    conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                    conexion.Open();

                    var command = new NpgsqlCommand();
                    command.Connection = conexion;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT ltrim(CCOD_EMPRESA)||'-'||ltrim(NOMEMPRESA)::character(50) AS EMPRESA,nventaflg as venta," +
                    "ncompraflg as compra,ncobranzaflg as cobranza,npagoflg as pago  from cg_empresa inner join cg_empemisor on " +
                    "cg_empresa.ccodrucemisor = cg_empemisor.ccodrucemisor " +
                    "  where cast(cg_empemisor.flgActivo as integer) =1";
                    var adapter = new NpgsqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                 
                    if (dataset.Tables.Count == 0)
                    {
                        MessageBox.Show("No existe datos de empresa seleccionada empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Close();
                    }
                    else
                    {
                        DataTable dtDatabases = dataset.Tables[0];
                        string NewBase = dataset.Tables[0].Rows[0][0].ToString();
                        cmbempresas.Text = dataset.Tables[0].Rows[0][0].ToString();


                        for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)

                        {
                            cmbempresas.Items.Add(dataset.Tables[0].Rows[i][0].ToString());
                            cmbempresas.Refresh();

                        }
                    }

                    conexion.Close();

                }
            }
            catch
            {
                MessageBox.Show("Error no Existe Información de  empresa, favor en registrar una empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }



        }
        private void FrmIntegradorComercial_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            txtcadena.Text = Properties.Settings.Default.cadenaPost;
            ////// MessageBox.Show("" + Properties.Settings.Default.cadenaPost);

            this.cmbempresas.Focus();
            ///     this.ruc();
            this.empresas();
            
            this.limpiar();
            
        }
        private void cmbempresas_SelectedIndexChanged(object sender, EventArgs e)
        {
           this.dataGrid.DataSource = null;
            this.button1.Enabled = false;
            if (cmbempresas.Text == "")
            {
                return;
            }
            else
            {

                txtcadena.Text = Properties.Settings.Default.cadenaPost;
                xCodempresa = "contasis_" + cmbempresas.Text.Substring(0, 3).ToLower();
                txtcadena.Text = txtcadena.Text.Replace("contasis", xCodempresa.Trim());
                this.cargar();
                
                ///Tablero.Enabled = false;
                this.limpiar();
            }
        }
        private void carga3()
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text01 = "SELECT CRAZEMP,CRUCEMP FROM cg_emppro WHERE CPER='" + cmbperiodo.Text + "'";
                cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmdp = new NpgsqlCommand(text01, cone1);
                cone1.Open();

                NpgsqlDataReader grilla = cmdp.ExecuteReader();
               //// dataGridView1.Rows.Clear();
                grilla.Read();

                txtrazon.Text = grilla[0].ToString().Replace("'", " ");
                txtruc.Text = grilla[1].ToString();
               //// this.seleccion();

                //  if (rucemisor.Trim() == txtruc.Text.Trim())
                //{

                ////}
                ////        else
                ///{
                ///  MessageBox.Show("No coinciden el dato del ruc emisor con el dato del ruc Empresa en Contasis." ,"Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ////                    return;

                ////            }

                grilla.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe los datos de empresa " + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }
        private void cargar()
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text02 = "SELECT CPER FROM cg_emppro order by cper desc";
                cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmdp2 = new NpgsqlCommand(text02, cone1);
                cone1.Open();
                NpgsqlDataReader grilla2 = cmdp2.ExecuteReader();
                cmbperiodo.Items.Clear();
                while (grilla2.Read())
                {
                    cmbperiodo.Items.Add(grilla2[0].ToString());
                    cmbperiodo.Refresh();
                }
                ///Tablero.Enabled = true;
                grilla2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe empresa " + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
                ////Tablero.Enabled = false;
            }

        }
        private void cargarentidad()
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text02 = "SELECT distinct  LTRIM(cg_emppro.ccodenti)::CHARACTER(10) as codigo,LTRIM(cg_entidad.cdesenti) ::CHARACTER(80) as entidad FROM cg_emppro inner join cg_entidad " +
                                " on cg_emppro.ccodenti = cg_entidad.ccodenti;";
                cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmd = new NpgsqlCommand(text02,cone1);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                cone1.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbentidad.Items.Clear();
                    cmbentidad.ValueMember = "codigo";
                    cmbentidad.DisplayMember = "entidad";
                    cmbentidad.DataSource = dt;
                    cmbentidad.Refresh();
                cone1.Close();
            }
            catch
            {
                if (xcontrol == "B")
                { }
                else
                {
                    MessageBox.Show("Error no Existe entidades.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }
        private void cmbperiodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.limpiar();
            txtperiodo.Text = cmbperiodo.Text.Trim();
            this.carga3();
            this.modulos();
            this.button1.Enabled = true;
            Cargar_Fecha_inicio();
        }
        private void Anulados()
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text02 = "select ltrim(CCODRUC)::char(20) as codigo ,LTRIM(CRAZSOC)::char(60) as razon  from cg_entitrib where NUTIANU=1";
                cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmd = new NpgsqlCommand(text02, cone1);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                cone1.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbanulados.Items.Clear();
                cmbanulados.ValueMember = "codigo";
                cmbanulados.DisplayMember = "razon";
                cmbanulados.DataSource = dt;
                cmbanulados.Refresh();
                cone1.Close();
            }

            catch
            {
                if (xcontrol == "B")
                { }
                else
                {
                    MessageBox.Show("Error no existen en Entidades anulados ", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }
        private void Documento()
        {
            try
            {
                NpgsqlConnection cone2 = new NpgsqlConnection();
                string text02 = "select ccoddoc as coddoc,cdesdoc as descri from cg_doc " +
                                " where ccoddoc in (select distinct ccoddoc  from cc_movimiento) " +
                                " order by ccoddoc";
                cone2 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmd = new NpgsqlCommand(text02, cone2);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                cone2.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbdocumento.Items.Clear();
                cmbdocumento.ValueMember = "coddoc";
                cmbdocumento.DisplayMember = "descri";
                cmbdocumento.DataSource = dt;
                cmbdocumento.Refresh();
                cone2.Close();
            }

            catch
            {
                if (xcontrol == "B")
                { }
                else
                {
                    MessageBox.Show("Error no existen en documentos creados ", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }
        private void Pagos()
        {
            try
            {
                NpgsqlConnection cone2 = new NpgsqlConnection();
                string text02 = "select ccodpag,cdespag  from cc_pago where cdespag LIKE '%CONT%' OR  cdespag LIKE '%CRED%' ORDER BY ccodpag";
                cone2 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmd = new NpgsqlCommand(text02, cone2);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                cone2.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbpagos.Items.Clear();
                cmbpagos.ValueMember = "ccodpag";
                cmbpagos.DisplayMember = "cdespag";
                cmbpagos.DataSource = dt;
                cmbpagos.Refresh();
                cone2.Close();
            }

            catch
            {
                if (xcontrol == "B")
                { }
                else
                {
                    MessageBox.Show("Error no existen en pagos creados ", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }
        private void Vendedor()
        {
            try
            {
                NpgsqlConnection cone2 = new NpgsqlConnection();
                string text02 = "select  ccodvend,cnomvend from cc_vendedor order by ccodvend";
                cone2 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmd = new NpgsqlCommand(text02, cone2);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                cone2.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbvendedor.Items.Clear();
                cmbvendedor.ValueMember = "ccodvend";
                cmbvendedor.DisplayMember = "cnomvend";
                cmbvendedor.DataSource = dt;
                cmbvendedor.Refresh();
                cone2.Close();
            }

            catch
            {
                if (xcontrol == "B")
                { }
                else
                {
                    MessageBox.Show("Error no existen en vendedores ", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }
        private void Almacen()
        {
            try
            {
                NpgsqlConnection cone2 = new NpgsqlConnection();
                string text02 = "select ccodalma,cdesalma  from cc_almacen order by ccodalma asc";
                cone2 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmd = new NpgsqlCommand(text02, cone2);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                cone2.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbalmacen.Items.Clear();
                cmbalmacen.ValueMember = "ccodalma";
                cmbalmacen.DisplayMember = "cdesalma";
                cmbalmacen.DataSource = dt;
                cmbalmacen.Refresh();
                cone2.Close();
            }

            catch
            {
                if (xcontrol == "B")
                { }
                else
                {
                    MessageBox.Show("Error no existen en almacen ", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }
        private void Series(string codigo,string xtipomovi)
        {
            string text03 = "";
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                cone1.Open();
                
                if (xtipomovi == "S")
                {
                    label5.Text = "Tipo de movimiento de Salida:";
                    text03 = "select cserdoc::char(20) as serie,cserdoc::char(20) as serie2  from cc_numdoc where ccoddoc='" + codigo.ToString() + "';";
                } else {
                    label5.Text = "Tipo de movimiento de Ingreso:";
                    text03 = "select cserie::char(20) as serie,cserie::char(20) as serie2  from cc_movimiento where  ctipmov='I' and ccoddoc='" + codigo.ToString() + "';";
                }
                
                NpgsqlCommand cmd = new NpgsqlCommand(text03, cone1);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cone1.Close();
                cmbseries.ValueMember = "serie";
                cmbseries.DisplayMember = "serie2";
                cmbseries.DataSource = dt;
                cmbseries.Refresh();
            }

            catch
            {
                MessageBox.Show("Error no existen en documentos con series ", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
            }

        }
        private void movimiento(string doc,string serie,string tipmov)
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                cone1.Open();
                string text03 = "select ccodmov,cdesmov  from cc_movimiento where ccoddoc='" + doc.Trim() + "' and cserie='" + serie.Trim() + "' and ctipmov='" + tipmov + "';";
                NpgsqlCommand cmd = new NpgsqlCommand(text03, cone1);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cone1.Close();
                cmbmovimiento.ValueMember = "ccodmov";
                cmbmovimiento.DisplayMember = "cdesmov";
                cmbmovimiento.DataSource = dt;
                cmbmovimiento.Refresh();
            }

            catch
            {
                MessageBox.Show("Error no existen en movimiento", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
            }

        }
        private void Anulacionproductos()
        {
            try
            {
                NpgsqlConnection cone2 = new NpgsqlConnection();
                string text02 = "select ccodprod,cdesprod  from cc_productos where nanuprod=1;";
                cone2 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmd = new NpgsqlCommand(text02, cone2);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                cone2.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboanulacionproducto.Items.Clear();
                cboanulacionproducto.ValueMember = "ccodprod";
                cboanulacionproducto.DisplayMember = "cdesprod";
                cboanulacionproducto.DataSource = dt;
                cboanulacionproducto.Refresh();
                cone2.Close();
            }

            catch
            {
                if (xcontrol == "B")
                { }
                else
                {
                    MessageBox.Show("Error no existen en productos anulados ", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }
        public void limpiar()
        {
            
            xcontrol = "B";
            cmbtipo.Text="";
            cmbentidad.Text = "";
            cmbanulados.Text = "";
            cmbdocumento.Text = "";
            cmbseries.Text = "";
            cmbpagos.Text = "";
            cmbmovimiento.Text = "";
            cmbvendedor.Text = "";
            cmbalmacen.Text = "";
            cboanulacionproducto.Text = "";
            dataGrid.DataSource = "";
        }
        public void modulos()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                label5.Text = "Tipo de movimiento:";
                SqlConnection Cone = new SqlConnection();
                string text02 = "select ccodmudulo,cdesmodulo  from modulo_comercial;";
                Cone = Clase.ConexionSql.Instancial().establecerconexion();
                SqlCommand cmd = new SqlCommand(text02,Cone);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                Cone.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                cmbtipo.ValueMember = "ccodmudulo";
                cmbtipo.DisplayMember = "cdesmodulo";
                cmbtipo.DataSource = dt;
                cmbtipo.Refresh();
                Cone.Close();
            }
            else
            {
                try
                {
                    label5.Text = "Tipo de movimiento:";
                    NpgsqlConnection cone2 = new NpgsqlConnection();
                    string text02 = "select ccodmudulo,cdesmodulo  from modulo_comercial;";
                    cone2 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand cmd = new NpgsqlCommand(text02, cone2);
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    cone2.Open();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbtipo.Items.Clear();
                    cmbtipo.ValueMember = "ccodmudulo";
                    cmbtipo.DisplayMember = "cdesmodulo";
                    cmbtipo.DataSource = dt;
                    cmbtipo.Refresh();
                    cone2.Close();
                }

                catch
                {
                    if (xcontrol == "B")
                    { }
                    else
                    {
                        MessageBox.Show("Error no existen en Modulos activos ", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }

        }
        private void cmbentidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
            if (cmbentidad.SelectedValue.ToString() != null)
            {
             ////   MessageBox.Show(cmbentidad.SelectedValue.ToString());
            }
        }
        private void cmbanulados_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
            if (cmbanulados.SelectedValue.ToString() != null)
            {
              ////  MessageBox.Show(cmbanulados.SelectedValue.ToString());
            }
        }
        private void cmbdocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
            /// MessageBox.Show(cmbdocumento.SelectedValue.ToString());
            ///MessageBox.Show(xtipomovi);

            Series(cmbdocumento.SelectedValue.ToString(), xtipomovi);
        }
        private void cmbseries_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
            this.movimiento(cmbdocumento.SelectedValue.ToString(), cmbseries.SelectedValue.ToString(), xtipomovi);
        }
         private void cmbtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
            label5.Text = "Tipo de movimiento:";
            xmodulo = cmbtipo.SelectedValue.ToString().Trim();
            if (xmodulo == "COMPR")
            {
                xtipomovi = "I";
                label5.Text = "Tipo de movimiento de Ingreso:";
            }
            if (xmodulo == "VENTA")
            {
                xtipomovi = "S";
               label5.Text = "Tipo de movimiento de Salida:";
            }
            
            this.limpiar();
            
            this.cargarentidad();
            this.Anulados();
            this.Pagos();
            this.Vendedor();
            this.Almacen();
            this.Documento();
            this.cmbdocumento.Refresh();
            Series(cmbdocumento.SelectedValue.ToString(), xtipomovi);
            this.cmbseries.Refresh();

            
            this.cmbmovimiento.Refresh();
            this.Anulacionproductos();
            this.mostrar_grilla();
        }
        private void grabar()

        {
            Clase.Configuracion_comercial obj = new Clase.Configuracion_comercial();
            obj.Ccod_empresa = cmbempresas.Text.Substring(0, 3);
            obj.Cper = txtperiodo.Text;
            obj.Crazemp = txtrazon.Text;
            obj.Crucemp = txtruc.Text;
            obj.Entidad = cmbentidad.SelectedValue.ToString();
            obj.Tipo = cmbtipo.Text.Substring(0, 5);
            obj.Codtipdocu = cmbdocumento.SelectedValue.ToString();
            obj.Cserie = cmbseries.SelectedValue.ToString();
            obj.Ccodmov = cmbmovimiento.SelectedValue.ToString();
            obj.Ccodpag = cmbpagos.SelectedValue.ToString();
            obj.Ccodvend = cmbpagos.SelectedValue.ToString();
            obj.Ccodalma = cmbalmacen.SelectedValue.ToString();
            obj.Ent_anula = cmbanulados.SelectedValue.ToString();
            obj.Prodanula = cboanulacionproducto.SelectedValue.ToString();
            this.cmbmovimiento.Refresh();
            this.cmbseries.Refresh();
            if (cmbmovimiento.Text == "")
            {
                MessageBox.Show("No existe codigo de Movimiento.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string respuesta = "";
                Clase.Comercial_procesos_configuracion ver = new Clase.Comercial_procesos_configuracion();
                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                {
                    respuesta = ver.Verifica_movimientosql(cmbmovimiento.SelectedValue.ToString(), cmbtipo.Text.Substring(0, 5), txtperiodo.Text.Trim());
                }
                else
                {
                    respuesta = ver.Verifica_movimientopossql(cmbmovimiento.SelectedValue.ToString(), cmbtipo.Text.Substring(0, 5), txtperiodo.Text.Trim());
                }

                ////MessageBox.Show(cmbmovimiento.SelectedValue.ToString());
                ///MessageBox.Show(cmbtipo.Text.Substring(0, 5));
                ////MessageBox.Show(respuesta);
                ///
                if (respuesta.Equals("1"))
                {
                    this.btngrabar.Enabled = true;
                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {
                        Clase.Comercial_procesos_configuracion ds = new Clase.Comercial_procesos_configuracion();
                        respuesta = ds.Comer_actualizar(obj);
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en tabla configuración comercial", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.limpiar();

                        }
                        else
                        {
                            MessageBox.Show("No se puedo actualizar esta configuración", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.mostrar_grilla();
                    }

                    else
                    {
                        Clase.Comercial_procesos_configuracion ds = new Clase.Comercial_procesos_configuracion();
                        respuesta = ds.Comer_actualizarpostgres(obj);
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en tabla configuración comercial", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se puedo actualizar esta configuración", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.mostrar_grilla();
                    }


                    /// MessageBox.Show("este movimiento ya figura en este periodo.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    this.btngrabar.Enabled = true;
                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {
                        Clase.Comercial_procesos_configuracion ds = new Clase.Comercial_procesos_configuracion();
                        respuesta = ds.Comer_insert(obj);
                        if (respuesta.Equals("Grabado"))
                        {
                            MessageBox.Show("Registro grabado en tabla configuración comercial", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.limpiar();

                        }
                        else
                        {
                            MessageBox.Show("No se puedo regitrar esta configuración", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.mostrar_grilla();
                    }

                    else
                     {
                        Clase.Comercial_procesos_configuracion ds = new Clase.Comercial_procesos_configuracion();
                        respuesta = ds.Comer_insert_postgres(obj);
                        if (respuesta.Equals("Grabado"))
                       {
                          MessageBox.Show("Registro grabado en tabla configuración comercial", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          this.limpiar();
                       }
                       else
                       {
                          MessageBox.Show("No se puedo regitrar esta configuración", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
                        this.mostrar_grilla();
                    }
                }
            }
        }
        public void mostrar_grilla()
        {
            try
            {
                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                {
                    Clase.Comercial_procesos_configuracion regis = new Clase.Comercial_procesos_configuracion();
                    dataGrid.DataSource =regis.Cargar(txtperiodo.Text, cmbempresas.Text.Substring(0, 3), xmodulo);
                }
                else
                {
                    Clase.Comercial_procesos_configuracion regis = new Clase.Comercial_procesos_configuracion();
                    dataGrid.DataSource = regis.Cargarpostgres(txtperiodo.Text, cmbempresas.Text.Substring(0, 3), xmodulo);
                }


                
               /// dataGrid.AllowUserToAddRows = false;
                ////dataGrid.Columns[0].HeaderText = "CODIGO";
                ///dataGrid.Columns[0].MinimumWidth = 50;
                /////dataGrid.Columns[0].Width = 100;
                /////dataGrid.Columns[1].HeaderText = "USUARIOS";
                ////dataGrid.Columns[1].MinimumWidth = 50;
                ////dataGrid.Columns[1].Width = 474;
                /////dataGrid.Columns[2].Visible = false;
                dataGrid.AllowUserToAddRows = false;
                lblTotales.Text = "Total de Registros : " + Convert.ToString(dataGrid.Rows.Count);
                dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGrid.ReadOnly = true;
                dataGrid.AutoResizeColumns();
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                if (dataGrid.Rows.Count - 1 > 0)
                {
                    this.dataGrid.CurrentCell = this.dataGrid.Rows[0].Cells[1];
                    this.dataGrid.Refresh();
                }
                this.dataGrid.Refresh();

            }
            catch
            {
               /// MessageBox.Show("No existe información para Mostrar.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btngrabar_Click(object sender, EventArgs e)
        {

            if (txtFechaInicio.Text == "")
            {
                MessageBox.Show("Debe de grabar la fecha de Inicio.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                this.grabar();
                grabar_Fecha_inicio();
                btngrabar.Enabled = false;
                this.Com_documento();
                this.Com_detalledocumento();
                this.Com_producto();
                this.funciones();
            }
        }
        private void cmbmovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
          /*  xMovimiento = cmbmovimiento.SelectedValue.ToString();*/
            btngrabar.Enabled = true;
        }
        private void Btneliminar_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Deseas eliminar movimiento seleccionado.?", "Contasis Corpor.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGrid.Rows.Count > 0)
                {
                    string codigo = Convert.ToString(dataGrid.SelectedRows[0].Cells[0].Value);
                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {
                        Clase.Comercial_procesos_configuracion regis = new Clase.Comercial_procesos_configuracion();
                        dataGrid.DataSource = regis.Eliminar_movimientosql(codigo);
                    }
                    else
                    {
                        Clase.Comercial_procesos_configuracion regis = new Clase.Comercial_procesos_configuracion();
                        dataGrid.DataSource = regis.Eliminar_movimientopossql(codigo);
                    }
                    this.mostrar_grilla();
                }
                else     {                  
                    return;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            btneliminar.Enabled = false;
        }
        private void DataGrid_Click(object sender, EventArgs e)
        {
            btneliminar.Enabled = true;
        }
        public void Com_documento()
        {
            NpgsqlConnection cone01 = new NpgsqlConnection();
            try
            {


                string query0 = "SELECT distinct TABLE_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='com_documento'";
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand commando = new NpgsqlCommand(query0, cone01);
                cone01.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    string tmpquery = txtdocumento.Text;
                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand commando1 = new NpgsqlCommand(tmpquery, cone01);
                    cone01.Open();
                    commando1.ExecuteNonQuery();
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());

            }
            finally
            {
                if (cone01.State == ConnectionState.Open)
                {
                    cone01.Close();
                }

            }

        }
        public void Com_detalledocumento()
        {
            NpgsqlConnection cone01 = new NpgsqlConnection();
            try
            {


                string query0 = "SELECT distinct TABLE_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='com_detalledocumento'";
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand commando = new NpgsqlCommand(query0, cone01);
                cone01.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    string tmpquery = txtdetalledocu.Text;
                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand commando1 = new NpgsqlCommand(tmpquery, cone01);
                    cone01.Open();
                    commando1.ExecuteNonQuery();
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());

            }
            finally
            {
                if (cone01.State == ConnectionState.Open)
                {
                    cone01.Close();
                }

            }

        }
        public void Com_producto()
        {
            NpgsqlConnection cone01 = new NpgsqlConnection();
            try
            {


                string query0 = "SELECT distinct TABLE_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='com_producto'";
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand commando = new NpgsqlCommand(query0, cone01);
                cone01.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    string tmpquery = txtproducto.Text;
                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand commando1 = new NpgsqlCommand(tmpquery, cone01);
                    cone01.Open();
                    commando1.ExecuteNonQuery();
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());

            }
            finally
            {
                if (cone01.State == ConnectionState.Open)
                {
                    cone01.Close();
                }

            }

        }
        public void funciones()
        {
                NpgsqlConnection cone01 = new NpgsqlConnection();

                try
                {
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                cone01.Open();

                NpgsqlCommand commando1 = new NpgsqlCommand(txtubigeo.Text, cone01);
                commando1.ExecuteNonQuery();

                NpgsqlCommand commando2 = new NpgsqlCommand(txtguardardocu.Text, cone01);
                commando2.ExecuteNonQuery();

                NpgsqlCommand commando23 = new NpgsqlCommand(txtguardarproducto.Text, cone01);
                commando23.ExecuteNonQuery();

                NpgsqlCommand commando33 = new NpgsqlCommand(txtproductoprincipal.Text, cone01);
                commando33.ExecuteNonQuery();

                NpgsqlCommand commando43 = new NpgsqlCommand(txtcompras_comercial.Text, cone01);
                commando43.ExecuteNonQuery();


                NpgsqlCommand commando53 = new NpgsqlCommand(txtventascomercial.Text, cone01);
                commando53.ExecuteNonQuery();


                NpgsqlCommand commando63 = new NpgsqlCommand(txtasientoscompras.Text, cone01);
                commando63.ExecuteNonQuery();


                NpgsqlCommand commando73 = new NpgsqlCommand(txtventasasientos.Text, cone01);
                commando73.ExecuteNonQuery();

                NpgsqlCommand commando82 = new NpgsqlCommand(txtActualizarstocanular.Text, cone01);
                commando82.ExecuteNonQuery();

                NpgsqlCommand commando83 = new NpgsqlCommand(txtActualizastock.Text, cone01);
                commando83.ExecuteNonQuery();

                NpgsqlCommand commando84 = new NpgsqlCommand(txtanulasventas.Text, cone01);
                commando84.ExecuteNonQuery();

                NpgsqlCommand commando85 = new NpgsqlCommand(txtAnularcompras.Text, cone01);
                commando85.ExecuteNonQuery();

            }
            catch (Exception ex1)
                {
                    MessageBox.Show(ex1.ToString());

                }
                finally
                {
                    if (cone01.State == ConnectionState.Open)
                    {
                        cone01.Close();
                    }

                }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Com_documento();
            this.Com_detalledocumento();
            this.Com_producto();
            this.funciones();
        }

        private void FechaInicio_ValueChanged(object sender, EventArgs e)
        {
            txtFechaInicio.Text = FechaInicio.Value.ToString("dd/MM/yyyy");
        }
        private void grabar_Fecha_inicio()
        {
            string query10 = "Update  configuracion2 set ffecha_inicioproceso='" + txtFechaInicio.Text + "'  where   ccod_empresa='" + cmbempresas.Text.Substring(0, 3) + "' and cper='" + cmbperiodo.Text + "';";
            if (cmbempresas.Text == "")
            {
                txtFechaInicio.Text = null;
            }
            else
            {
                SqlConnection Cone = new SqlConnection();

                try
                {
                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {
                        Cone = Clase.ConexionSql.Instancial().establecerconexion();

                        SqlCommand commando = new SqlCommand(query10, Cone);
                        commando.ExecuteNonQuery();
                        Cone.Close();
                    }

                    else
                    {

                        NpgsqlConnection conexion = new NpgsqlConnection();
                        conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                        conexion.Open();

                        NpgsqlCommand cmdp = new NpgsqlCommand(query10, conexion);
                        cmdp.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Debe de Existir un error, pase verificación de Estructura.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }

        }

        private void Cargar_Fecha_inicio()
        {

            FechaInicio.Enabled = false;

            string query10 = "select ffecha_inicioproceso from configuracion2 where ccod_empresa='" + cmbempresas.Text.Substring(0, 3) + "' and cper='" + cmbperiodo.Text + "';";
            if (cmbempresas.Text == "")
            {
                txtFechaInicio.Text = null;
            }
            else
            {
                SqlConnection cone = new SqlConnection();

                try
                {
                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {
                        cone = Clase.ConexionSql.Instancial().establecerconexion();

                        SqlCommand commando = new SqlCommand(query10, cone);
                        DataTable dt = new DataTable();
                        cone.Open();
                        SqlDataAdapter data = new SqlDataAdapter(commando);
                        data.Fill(dt);
                        txtFechaInicio.Text = dt.Rows[1].ToString();
                    }

                    else
                    {

                        NpgsqlConnection conexion = new NpgsqlConnection();
                        conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                        conexion.Open();

                        NpgsqlCommand cmdp = new NpgsqlCommand(query10, conexion);
                        NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
                        NpgsqlDataReader leer = cmdp.ExecuteReader();
                        if (leer.Read())
                        {
                            txtFechaInicio.Text = Convert.ToString(leer["ffecha_inicioproceso"]);
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Debe de Existir un error, pase verificación de Estructura.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }

        }

        private void cmbpagos_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
        }

        private void cmbvendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
        }

        private void cmbalmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
        }

        private void cboanulacionproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
        }
        /***************************************************************************************************************/
    }
}
