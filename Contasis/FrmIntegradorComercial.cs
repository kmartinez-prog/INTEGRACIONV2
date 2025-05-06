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

        int posicion;


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
                    command.CommandText = "select ltrim(ccodrucemisor)||'-'||ltrim(cdesrucemisor)::character(60) as emisor ," +
                    "NCOMVENTAFLG as venta,NCOMCOMPRAFLG as compra,NCOBRANZACOMERCIAL as cobranza,npagoflg as pago" +
                     "from cg_empemisor where flgactivo = '1'";
                     
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
        private void Empresas()
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
                    command.CommandText = "Select distinct CCOD_EMPRESA+'-'+NOMEMPRESA AS EMPRESA " +
                    " From cg_empresa inner join cg_empemisor on," +
                    " cg_empresa.ccodrucemisor = cg_empemisor.ccodrucemisor " +
                    "  where cast(cg_empemisor.flgActivo as integer) = 1";
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
                    command.CommandText = "SELECT distinct ltrim(CCOD_EMPRESA)||'-'||ltrim(NOMEMPRESA)::character(50) AS EMPRESA" +
                    " From cg_empresa inner join cg_empemisor on " +
                    " cg_empresa.ccodrucemisor = cg_empemisor.ccodrucemisor " +
                    "  where cast(cg_empemisor.flgActivo as integer) = 1";
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
        private void ActivaCobranza()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
            }

            else
            {

                Clase.Configuracion_comercial obj = new Clase.Configuracion_comercial();
                NpgsqlConnection conexion = new NpgsqlConnection();
                conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                conexion.Open();

                string nEmpresa = this.cmbempresas.Text.Substring(0, 3);

                string text01 = "select ncobranzacomercial as cobranzac from cg_empresa inner join cg_empemisor on cg_empresa.ccodrucemisor = cg_empemisor.ccodrucemisor " +
                " where cg_empresa.ccod_empresa = '" + nEmpresa + "'";
                var cmd = new NpgsqlCommand(text01, conexion);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    obj.PermisoCobranzaComercial = Convert.ToInt32(reader["cobranzac"].ToString());
                }
                if (obj.PermisoCobranzaComercial == 0)
                {
                    this.tabPage1.Parent = null;
                } 



            }
            


        }



        private void FrmIntegradorComercial_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            
            txtcadena.Text = Properties.Settings.Default.cadenaPost;
            ////// MessageBox.Show("" + Properties.Settings.Default.cadenaPost);

            this.cmbempresas.Focus();
            ///     this.ruc();
            this.Empresas();
            this.Limpiar();
            
        }
        private void Cmbempresas_SelectedIndexChanged(object sender, EventArgs e)
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
                xCodempresa = "contasis_" + cmbempresas.Text.Substring(0, 3).ToLower() ;
                txtcadena.Text = txtcadena.Text.Replace("contasis", xCodempresa.Trim());
                this.ActivaCobranza();
                this.cargar();
                
                ///Tablero.Enabled = false;
                this.Limpiar();
            }
        }
        private void Carga3()
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text01 = "SELECT CRAZEMP,CRUCEMP FROM cg_emppro WHERE CPER='" + cmbperiodo.Text + "'";
                cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmdp = new NpgsqlCommand(text01, cone1);
                cone1.Open();

                NpgsqlDataReader grilla = cmdp.ExecuteReader();
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
        private void Cmbperiodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Limpiar();
            txtperiodo.Text = cmbperiodo.Text.Trim();
            this.llena_modulo_comercial();
            this.Carga3();
            this.Modulos();
            Mostrar_registros_cobranzas();
            this.button1.Enabled = true;
            /*Cargar_Fecha_inicio();*/
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
                string text02 = "select ccodpag,cdespag  from cc_pago where upper(cdespag) LIKE '%CONT%' OR  cdespag LIKE '%CRED%' ORDER BY ccodpag";
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
            this.Validar_datos();
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
                    text03 = "select cserdoc::char(20) as serie,cserdoc::char(20) as serie2  from cc_numdoc where ctipmov='S' and ccoddoc='" + codigo.ToString() + "';";
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
        private void Movimiento(string doc,string serie,string tipmov)
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
        public void Limpiar()
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
        public void Modulos()

        {
            this.Validar_datos();
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                label5.Text = "Tipo de movimiento:";
                SqlConnection Cone = new SqlConnection();
                string text02 = "select ccodmudulo,cdesmodulo  from modulo_comercial;";
                Cone = Clase.ConexionSql.Instancial().Establecerconexion();
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
                    cone2 = Clase.ConexionPostgreslContasis.Instancial().establecerconexionPrincipal();  

                    ////cone2 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
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
        private void Cmbentidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
            if (cmbentidad.SelectedValue.ToString() != null)
            {
             ////   MessageBox.Show(cmbentidad.SelectedValue.ToString());
            }
        }
        private void Cmbanulados_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
            if (cmbanulados.SelectedValue.ToString() != null)
            {
              ////  MessageBox.Show(cmbanulados.SelectedValue.ToString());
            }
        }
        private void Cmbdocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
            /// MessageBox.Show(cmbdocumento.SelectedValue.ToString());
            ///MessageBox.Show(xtipomovi);

            Series(cmbdocumento.SelectedValue.ToString(), xtipomovi);
        }
        private void Cmbseries_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
            this.Movimiento(cmbdocumento.SelectedValue.ToString(), cmbseries.SelectedValue.ToString(), xtipomovi);
        }
        private void Cmbtipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
            label5.Text = "Tipo de movimiento:";
            this.Limpiar();
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
            this.Mostrar_grilla();
        }
        private void grabar()

        {
            Clase.Configuracion_comercial obj = new Clase.Configuracion_comercial();
            NpgsqlConnection conexion = new NpgsqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
            conexion.Open();


            string text01 = "Select coalesce(id,1)+1 as Id  From configuracion2 order by id desc limit 1 ;";
            var cmd = new NpgsqlCommand(text01, conexion);
            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                obj.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            else
            {
                obj.Id = 1;
            }

            obj.Ccod_empresa = cmbempresas.Text.Substring(0, 3);
            obj.Cper = txtperiodo.Text.Trim();
            obj.Crazemp = txtrazon.Text.Trim();
            obj.Crucemp = txtruc.Text.Trim();
            obj.Entidad = cmbentidad.SelectedValue.ToString().Trim();
            obj.Tipo = cmbtipo.Text.Substring(0, 5).Trim();
            obj.Codtipdocu = cmbdocumento.SelectedValue.ToString().Trim();
            obj.Cserie = cmbseries.SelectedValue.ToString().Trim();
            obj.Ccodmov = cmbmovimiento.SelectedValue.ToString().Trim();
            obj.Ccodpag = cmbpagos.SelectedValue.ToString().Trim();
            obj.Ccodvend = cmbpagos.SelectedValue.ToString().Trim();
            obj.Ccodalma = cmbalmacen.SelectedValue.ToString().Trim();
            obj.Ent_anula = cmbanulados.SelectedValue.ToString().Trim();
            obj.Prodanula = cboanulacionproducto.SelectedValue.ToString().Trim();
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
                            this.Limpiar();

                        }
                        else
                        {
                            MessageBox.Show("No se puedo actualizar esta configuración", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.Mostrar_grilla();
                    }

                    else
                    {
                        Clase.Comercial_procesos_configuracion ds = new Clase.Comercial_procesos_configuracion();
                        respuesta = ds.Comer_actualizarpostgres(obj);
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en tabla configuración comercial", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se puedo actualizar esta configuración", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.Mostrar_grilla();
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
                            this.Limpiar();

                        }
                        else
                        {
                            MessageBox.Show("No se puedo regitrar esta configuración", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.Mostrar_grilla();
                    }

                    else
                     {
                        Clase.Comercial_procesos_configuracion ds = new Clase.Comercial_procesos_configuracion();
                        respuesta = ds.Comer_insert_postgres(obj);
                        if (respuesta.Equals("Grabado"))
                       {
                          MessageBox.Show("Registro grabado en tabla configuración comercial", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          this.Limpiar();
                       }
                       else
                       {
                          MessageBox.Show("No se puedo regitrar esta configuración", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
                        this.Mostrar_grilla();
                    }
                }
            }
        }
        public void Mostrar_grilla()
        {
            dataGrid.Columns.Clear();
            this.Validar_datos();
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
        private void Btngrabar_Click(object sender, EventArgs e)
        {
            this.Validar_datos();
            /*  if (txtFechaInicio.Text == "")
              {
                  MessageBox.Show("Debe de grabar la fecha de Inicio.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
              }
              else
              {*/

            this.grabar();
               /* Grabar_Fecha_inicio();*/
                btngrabar.Enabled = false;
                this.Com_documento();
                this.Com_detalledocumento();
                this.Com_producto();
                this.funciones();
           /* }*/

        }
        private void cmbmovimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
          /*  xMovimiento = cmbmovimiento.SelectedValue.ToString();*/
            btngrabar.Enabled = true;
        }
        private void Btneliminar_Click(object sender, EventArgs e)
        {

            if (cmbempresas.Text == "")
            {
                this.Validar_datos();
            }
            else
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
                        this.Mostrar_grilla();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }

                btneliminar.Enabled = false;
            }   

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
        public void com_cobranzapago_integra()
        {
            NpgsqlConnection cone01 = new NpgsqlConnection();
            try
            {


                string query0 = "SELECT distinct TABLE_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='com_cobranzapago_integra'";
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand commando = new NpgsqlCommand(query0, cone01);
                cone01.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    string tmpquery = txtcom_cobranzas.Text;
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

                NpgsqlCommand commando1 = new NpgsqlCommand(txtCancelacion_comercial2025.Text, cone01);
                commando1.ExecuteNonQuery();

                NpgsqlCommand commando2 = new NpgsqlCommand(txtasientos_ventascomercial.Text, cone01);
                commando2.ExecuteNonQuery();

                NpgsqlCommand commando23 = new NpgsqlCommand(txtventascobranzasprincipal.Text, cone01);
                commando23.ExecuteNonQuery();

                NpgsqlCommand commando33 = new NpgsqlCommand(txtasientoscobranzasprincipalventascom.Text, cone01);
                commando33.ExecuteNonQuery();

                NpgsqlCommand commando43 = new NpgsqlCommand(txtAnularcompras.Text, cone01);
                commando43.ExecuteNonQuery();


                NpgsqlCommand commando53 = new NpgsqlCommand(txtanulasventas.Text, cone01);
                commando53.ExecuteNonQuery();


                NpgsqlCommand commando63 = new NpgsqlCommand(txtcompras_comercial.Text, cone01);
                commando63.ExecuteNonQuery();


                NpgsqlCommand commando73 = new NpgsqlCommand(txtasientoscompras.Text, cone01);
                commando73.ExecuteNonQuery();

                NpgsqlCommand commando82 = new NpgsqlCommand(txtventasasientos.Text, cone01);
                commando82.ExecuteNonQuery();

                NpgsqlCommand commando83 = new NpgsqlCommand(txtubigeo.Text, cone01);
                commando83.ExecuteNonQuery();

                NpgsqlCommand commando84 = new NpgsqlCommand(txtguardardocu.Text, cone01);
                commando84.ExecuteNonQuery();

                NpgsqlCommand commando85 = new NpgsqlCommand(txtActualizarstocanular.Text, cone01);
                commando85.ExecuteNonQuery();

                NpgsqlCommand commando86 = new NpgsqlCommand(txtActualizastock.Text, cone01);
                commando86.ExecuteNonQuery();


                ///-darwin comercial 

                NpgsqlCommand commando87 = new NpgsqlCommand(txtubigeo2.Text, cone01);
                commando87.ExecuteNonQuery();

                NpgsqlCommand commando88 = new NpgsqlCommand(txtguardarproducto_2025.Text, cone01);
                commando88.ExecuteNonQuery();

                NpgsqlCommand commando89 = new NpgsqlCommand(txtproductoprincipal2025.Text, cone01);
                commando89.ExecuteNonQuery();

                NpgsqlCommand commando90 = new NpgsqlCommand(txtdetalledocumento_2025.Text, cone01);
                commando90.ExecuteNonQuery();
                NpgsqlCommand commando91 = new NpgsqlCommand(txtcom_documento_2025.Text, cone01);
                commando91.ExecuteNonQuery();

                NpgsqlCommand commando92 = new NpgsqlCommand(txtcomercial_proceso_2025darwin.Text, cone01);
                commando92.ExecuteNonQuery();

                NpgsqlCommand commando93 = new NpgsqlCommand(txt_com_importar_ventas_principal2025.Text, cone01);
                commando93.ExecuteNonQuery();

                NpgsqlCommand commando94 = new NpgsqlCommand(txtcom_importar_ventas_generaasiento_2025.Text, cone01);
                commando94.ExecuteNonQuery();

                NpgsqlCommand commando95 = new NpgsqlCommand(txtcom_importar_compras_ventas_principal_actualiza_stock_anula.Text, cone01);
                commando95.ExecuteNonQuery();
                                                                    
                NpgsqlCommand commando96 = new NpgsqlCommand(txtcom_importar_ventas_generaasiento_cobranza_principal_2025.Text, cone01);
                commando96.ExecuteNonQuery();
                
                NpgsqlCommand commando97 = new NpgsqlCommand(txtcom_importar_ventas_principal_anular2025.Text, cone01);
                commando97.ExecuteNonQuery();


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
            this.com_cobranzapago_integra();
            this.funciones();
            string NombreTable, Nombrecampo, Query;
            string respuesta = "";
            Clase.Estructura_postgres objpos = new Clase.Estructura_postgres();

            NombreTable = "com_documento";
            Nombrecampo = "ccond";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " character(3) null default '';";
            respuesta = objpos.crear_Campos_nuevos_en_tablas_empresa(NombreTable, Nombrecampo, Query, txtcadena.Text);
            //------------------------------------------------------------------------------------//
            //-fin_cobranzapago_integra--//
            NombreTable = "com_documento";
            Nombrecampo = "ccuecan";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " character(20) null default '';";
            respuesta = objpos.crear_Campos_nuevos_en_tablas_empresa(NombreTable, Nombrecampo, Query, txtcadena.Text);

            //-com_documento en base del cliente ///
            NombreTable = "com_documento";
            Nombrecampo = "cdoccan";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " character(2) null default '';";
            respuesta = objpos.crear_Campos_nuevos_en_tablas_empresa(NombreTable, Nombrecampo, Query, txtcadena.Text);

            NombreTable = "com_documento";
            Nombrecampo = "csercan";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " character(20) null default '';";
            respuesta = objpos.crear_Campos_nuevos_en_tablas_empresa(NombreTable, Nombrecampo, Query, txtcadena.Text);

            NombreTable = "com_documento";
            Nombrecampo = "cnumcan";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " character(20) null default '';";
            respuesta = objpos.crear_Campos_nuevos_en_tablas_empresa(NombreTable, Nombrecampo, Query, txtcadena.Text);


            NombreTable = "com_documento";
            Nombrecampo = "ccodorican";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " character(3) null default '';";
            respuesta = objpos.crear_Campos_nuevos_en_tablas_empresa(NombreTable, Nombrecampo, Query, txtcadena.Text);

            NombreTable = "com_documento";
            Nombrecampo = "ccodsucan";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " character(2) null default '';";
            respuesta = objpos.crear_Campos_nuevos_en_tablas_empresa(NombreTable, Nombrecampo, Query, txtcadena.Text);

            NombreTable = "com_documento";
            Nombrecampo = "ccodflucan";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " character(4) null default '';";
            respuesta = objpos.crear_Campos_nuevos_en_tablas_empresa(NombreTable, Nombrecampo, Query, txtcadena.Text);

            NombreTable = "com_documento";
            Nombrecampo = "obserrorcan";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " text default '';";
            respuesta = objpos.crear_Campos_nuevos_en_tablas_empresa(NombreTable, Nombrecampo, Query, txtcadena.Text);

            NombreTable = "com_documento";
            Nombrecampo = "resultadocan_migracion";
            Query = "alter table " + NombreTable.Trim().ToLower() + " add " + Nombrecampo.Trim().ToLower() + " Numeric(1,0) default 0;";
            respuesta = objpos.crear_Campos_nuevos_en_tablas_empresa(NombreTable, Nombrecampo, Query, txtcadena.Text);

        }
        private void FechaInicio_ValueChanged(object sender, EventArgs e)
        {
            txtFechaInicio.Text = FechaInicio.Value.ToString("dd/MM/yyyy");
        }
        private void Grabar_Fecha_inicio()
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
                        Cone = Clase.ConexionSql.Instancial().Establecerconexion();

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
                        cone = Clase.ConexionSql.Instancial().Establecerconexion();

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
                  /*  MessageBox.Show("Debe de Existir un error, pase verificación de Estructura.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;*/
                }

            }

        }

        private void Cmbpagos_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
        }

        private void Cmbvendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
        }

        private void Cmbalmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
        }

        private void Cboanulacionproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Validar_datos()
        {
            if (this.cmbempresas.Text=="")
            {
                MessageBox.Show("Favor de seleccionar una empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbempresas.Focus();
                return;
            }
            if (this.cmbperiodo.Text == "")
            {
                MessageBox.Show("Favor de seleccionar el periodo.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Focus();
                return;
            }
        }
        private void Validar_cuentas(string valor, string valor2)
        {
            try
            {
                string xvalor = valor;
                string xvalor2 = valor2;
                NpgsqlConnection cone = new NpgsqlConnection();
                /** para ventas **/
                if (xvalor == "1")
                {
                    this.lvalida1.Text = "";
                    txtquery2.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI='" + xvalor2 + "' ORDER BY CCODORI ASC";
                }
                if (xvalor == "2")
                {
                    this.lvalida2.Text = "";
                    txtquery2.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  where CCODSU='" + xvalor2 + "'  ORDER BY CCODSU ASC";
                }
                
                if (xvalor == "7")
                {
                    this.lvalida3.Text = "";
                    txtquery2.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where CCODFLU='" + xvalor2 + "' AND cper='" + txtperiodo.Text + "' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                }
                

                cone = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmdp = new NpgsqlCommand(txtquery2.Text, cone);
                cone.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(cmdp);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    MessageBox.Show("No existe el valor Ingresado.", "Contasis Corp.valida la  cuenta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   
                   
                    if (xvalor == "1")
                    {
                     ///   this.lvalida1.Text = "No existe este sub diario.";      
                        txtsubdiario_cobra.Text = "";
                        txtsubdiario_cobra.Focus();
                    }
                    if (xvalor == "2")
                    {
                        ////this.lvalida2.Text = "No existe este libro de registro.";
                        txtregistro_cobra.Text = "";
                        txtregistro_cobra.Focus();
                    }
                    if (xvalor == "7")
                    {
                        ////this.lvalida3.Text = "No existe el codigo de flujo";
                        txtflujocobra.Text = "";
                        txtflujocobra.Focus();
                    }
                    cone.Close();
                }

            }
            catch (Exception ex1)
            {
                MessageBox.Show("" + ex1);
            }

        }
        private void BtnGrabarCobranza_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    string respuestacb = "";
                    Clase.CuentasPropiedad obj = new Clase.CuentasPropiedad();
                    if (txtsubdiario_cobra.Text == "")
                    {
                        txtsubdiario_cobra.Focus();
                    }
                    if (txtregistro_cobra.Text == "")
                    {
                        txtregistro_cobra.Focus();
                    }
                    if (txtflujocobra.Text == "")
                    {
                        txtflujocobra.Focus();
                    }
                    if (cmbperiodo.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar el periodo.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbperiodo.Focus();
                        return;
                    }
                    obj.EMPRESA = cmbempresas.Text.Substring(0, 3);
                    obj.PERIODO = txtperiodo.Text;
                    obj.RUC = txtruc.Text;
                    obj.CSUB1_vta = txtsubdiario_cobra.Text.TrimStart().TrimEnd();
                    obj.CLREG1_vta = txtregistro_cobra.Text.TrimStart().TrimEnd();
                    obj.CFEFEC_vta = txtflujocobra.Text.TrimStart().TrimEnd();
                    obj.CTIPO = "03";

                    Clase.Cuentas ds = new Clase.Cuentas();
                    respuestacb = ds.Insertar_postgres_comercial(obj);
                    if (respuestacb.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de cobranzas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Mostrar_registros_cobranzas();
                    }
                    else
                    {
                        if (respuestacb.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de cobranzas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Mostrar_registros_cobranzas();
                        }
                        else
                        {
                            //MessageBox.Show("No se puedo grabar en configuracion", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    /* FrmUsuarios.instance.grilla1();*/

                }
                catch
                {
                    MessageBox.Show("revise, todos los campos debe de ser llenados correctamente.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                try
                {
                    string respuesta = "";
                    Clase.CuentasPropiedad obj = new Clase.CuentasPropiedad();
                    if (txtsubdiario_cobra.Text == "")
                    {
                        txtsubdiario_cobra.Focus();
                    }
                    if (txtregistro_cobra.Text == "")
                    {
                        txtregistro_cobra.Focus();
                    }
                    if (txtflujocobra.Text == "")
                    {
                        txtflujocobra.Focus();
                    }
                    if (cmbperiodo.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar el periodo.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbperiodo.Focus();
                        return;
                    }
                    obj.EMPRESA = cmbempresas.Text.Substring(0, 3);
                    obj.PERIODO = txtperiodo.Text;
                    obj.RUC = txtruc.Text;
                    obj.CSUB1_vta = txtsubdiario_cobra.Text;
                    obj.CLREG1_vta = txtregistro_cobra.Text;
                    obj.CFEFEC_vta = txtflujocobra.Text;
                    obj.CTIPO = "03";
                    Clase.Cuentas ds = new Clase.Cuentas();
                    respuesta = ds.Insertar_postgres_comercial(obj);
                    if (respuesta.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de Cobranzas Comercial", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Mostrar_registros_cobranzas();
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de Cobranzas Comercial", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Mostrar_registros_cobranzas();
                        }
                        else
                        {
                            //MessageBox.Show("No se puedo grabar en configuracion", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    /* FrmUsuarios.instance.grilla1();*/

                }
                catch
                {
                    MessageBox.Show("revise, todos los campos debe de ser llenados correctamente.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtsubdiario_cobra_KeyDown(object sender, KeyEventArgs e)
        {
            this.Validar_datos();
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(1, txtcadena.Text, cmbperiodo.Text,"C");
                frmcuenta.ShowDialog();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("1", txtsubdiario_cobra.Text);
            }


        }

        private void txtregistro_cobra_KeyDown(object sender, KeyEventArgs e)
        {
            this.Validar_datos();
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(2, txtcadena.Text, cmbperiodo.Text,"C");
                frmcuenta.ShowDialog();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("2", txtregistro_cobra.Text);
            }


        }

        private void txtflujocobra_TextChanged(object sender, EventArgs e)
        {
            this.Validar_datos();
        }

        private void txtflujocobra_KeyDown(object sender, KeyEventArgs e)
        {
            this.Validar_datos();
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(7, txtcadena.Text, cmbperiodo.Text,"C");
                frmcuenta.ShowDialog();
            }

            
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("7", txtflujocobra.Text);
            }


        }

        private void txtsubdiario_cobra_TextChanged(object sender, EventArgs e)
        {
            this.Validar_datos();
        }
        public void Mostrar_registros_cobranzas()
        {

            this.Validar_datos();
            dataGridView_cobranza.Columns.Clear();
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {

                    Clase.Cuentas regis = new Clase.Cuentas();
                    string xEmpresa = cmbempresas.Text.Substring(0, 3);
                    string xperiodo = cmbperiodo.Text;
                    dataGridView_cobranza.DataSource = null;
                    dataGridView_cobranza.DataSource = regis.Cargar_cobranzas(xEmpresa, xperiodo);
                    dataGridView_cobranza.AllowUserToAddRows = false;

                    dataGridView_cobranza.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_cobranza.ReadOnly = true;

                    if (dataGridView_cobranza.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_cobranza.CurrentCell = this.dataGridView_cobranza.Rows[0].Cells[1];
                        this.dataGridView_cobranza.Refresh();
                        FechaInicio.Enabled = true;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {

                    Clase.Cuentas regis = new Clase.Cuentas();
                    string xEmpresa = cmbempresas.Text.Substring(0, 3);
                    string xperiodo = cmbperiodo.Text;

                    dataGridView_cobranza.AllowUserToAddRows = false;

                    dataGridView_cobranza.DataSource = regis.Cargar_cobranzas_postgres_comercial(xEmpresa, xperiodo);

                    dataGridView_cobranza.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_cobranza.ReadOnly = true;

                    if (dataGridView_cobranza.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_cobranza.CurrentCell = this.dataGridView_cobranza.Rows[0].Cells[1];
                        this.dataGridView_cobranza.Refresh();
                    }
                    this.dataGridView_cobranza.Refresh();
                    FechaInicio.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        /***************************************************************************************************************/
        public void llena_modulo_comercial()
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            try
            {

                conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                conexion.Open();
                string query0 = "SELECT *  FROM modulo_comercial";
                NpgsqlCommand commando = new NpgsqlCommand(query0, conexion);
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);


                string query00 = "alter table configuracion2 alter column tipo type character(5); ";
                NpgsqlCommand command33 = new NpgsqlCommand(query00, conexion);
                command33.ExecuteNonQuery();



                if (tablas.Rows.Count == 0)
                {
                    string query = "Insert into modulo_comercial(ccodmudulo, cdesmodulo) values("+"'COMPR'"+","+"'COMPRA'"+");";
                    NpgsqlCommand command3 = new NpgsqlCommand(query, conexion);
                    command3.ExecuteNonQuery();

                    string query1 = "Insert into modulo_comercial(ccodmudulo, cdesmodulo) values(" + "'VENTA'" + "," + "'VENTA'" + ");";
                    NpgsqlCommand command4 = new NpgsqlCommand(query1, conexion);
                    command4.ExecuteNonQuery();
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());

            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }

            }

        }

        private void dataGridView_cobranza_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_cobranza.Rows.Count > 0)
            {
                txtsubdiario_cobra.Text = dataGridView_cobranza.Rows[posicion].Cells["subdiario_cobranza"].Value.ToString();
                txtregistro_cobra.Text = dataGridView_cobranza.Rows[posicion].Cells["registro_cobranza"].Value.ToString();
                txtflujocobra.Text = dataGridView_cobranza.Rows[posicion].Cells["flujo_cobranza"].Value.ToString();
            }

        }

        private void dataGridView_cobranza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = e.RowIndex;
        }

        private void txtregistro_cobra_TextChanged(object sender, EventArgs e)
        {
            this.Validar_datos();
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Validar_datos();
        }
    }
}
