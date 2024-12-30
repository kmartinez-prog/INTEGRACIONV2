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
    public partial class FrmIntegradorConta : Form
    {
        string xCodempresa;
        string xRucemisor;
      
        
        
        public static FrmIntegradorConta  instance = null;
        
        public FrmIntegradorConta()
        {
            InitializeComponent();
            instance = this;
        }
        int posicion;
        string combo;

        /*private void  Ruc_empresa()
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
                    command.CommandText = "select ltrim(ccodrucemisor)+'-'+ltrim(cdesrucemisor) as emisor,"+
                    "nventaflg as venta,ncompraflg as compra,ncobranzaflg as cobranza,npagoflg as pago "+    
                    " from cg_empemisor where flgactivo='1'";
                    var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    txtventa.Text = "";
                    txtcompras.Text = "";
                    txtcobranza.Text = "";
                    txtpago.Text = "";
                    cmbrucemisor.Items.Clear();
                    if (dataset.Tables.Count == 0)
                    {
                        MessageBox.Show("No existe datos el ruc emisor para seleccionar.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Close();
                    }
                    else
                    {

                        DataTable dtDatabases = dataset.Tables[0];
                        String NewBase = dataset.Tables[0].Rows[0][0].ToString();

                        cmbrucemisor.Text = dataset.Tables[0].Rows[0][0].ToString();
                        txtventa.Text= dataset.Tables[0].Rows[1][1].ToString();
                        txtcompras.Text = dataset.Tables[0].Rows[1][2].ToString();
                        txtcobranza.Text = dataset.Tables[0].Rows[1][3].ToString();
                        txtpago.Text = dataset.Tables[0].Rows[1][4].ToString();
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
                    command.CommandText = "select ltrim(ccodrucemisor)||'-'||ltrim(cdesrucemisor)::character(60) as emisor "+
                    "nventaflg as venta,ncompraflg as compra,ncobranzaflg as cobranza,npagoflg as pago "+      
                    " from cg_empemisor where flgactivo='1'";
                    var adapter = new NpgsqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    txtventa.Text = "";
                    txtcompras.Text = "";
                    txtcobranza.Text = "";
                    txtpago.Text = "";
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

                        txtventa.Text = dataset.Tables[0].Rows[1][0].ToString();
                        txtcompras.Text = dataset.Tables[0].Rows[2][0].ToString();
                        txtcobranza.Text = dataset.Tables[0].Rows[3][0].ToString();
                        txtpago.Text = dataset.Tables[0].Rows[4][0].ToString();
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
       


        }*/

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
                    command.CommandText = "Select CCOD_EMPRESA+'-'+NOMEMPRESA AS EMPRESA,nventaflg as venta," +
                    "ncompraflg as compra,ncobranzaflg as cobranza,npagoflg as pago  from cg_empresa inner join cg_empemisor on " +
                    "cg_empresa.ccodrucemisor = cg_empemisor.ccodrucemisor " +
                    " where cg_empemisor.flgActivo = 1 ";
                    var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                    var dataset = new DataSet();
                    adapter.Fill(dataset);
                    txtventa.Text = "";
                    txtcompras.Text = "";
                    txtcobranza.Text = "";
                    txtpago.Text = "";
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
                    txtventa.Text = "";
                    txtcompras.Text = "";
                    txtcobranza.Text = "";
                    txtpago.Text = "";
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
                            txtventa.Text = dataset.Tables[0].Rows[i][1].ToString();
                            txtcompras.Text = dataset.Tables[0].Rows[i][2].ToString();
                            txtcobranza.Text = dataset.Tables[0].Rows[i][3].ToString();
                            txtpago.Text = dataset.Tables[0].Rows[i][4].ToString();
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
        private void FrmIntegradorConta_Load(object sender, EventArgs e)
        {
            txtcadena.Text = Properties.Settings.Default.cadenaPost;
            ////// MessageBox.Show("" + Properties.Settings.Default.cadenaPost);

            this.cmbempresas.Focus();
       
            this.Empresas();
            
            
        }
        private void Cmbempresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView_venta.DataSource = null;
            this.dataGridView_compra.DataSource = null;
            this.dataGridView_cobranza.DataSource = null;
            this.dataGridView_pago.DataSource = null;
            this.txtFechaInicio.Text = null;
            if (cmbempresas.Text == "")
            {
                return;
            }
            else
            {
                
                txtcadena.Text = Properties.Settings.Default.cadenaPost;
                xCodempresa = "contasis_" + cmbempresas.Text.Substring(0, 3).ToLower();
                txtcadena.Text = txtcadena.Text.Replace("contasis", xCodempresa.Trim());
                this.Cargar();
                this.Cargarentidad();
                this.Anulados();
                Tablero.Enabled = false;
                this.Limpiar();
            }
        }
        private void Grabar_ventas()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {


                try
                {
                    string respuesta = "";
                    Clase.CuentasPropiedad obj = new Clase.CuentasPropiedad();
                    if (txtCSUB1.Text == "")
                    {
                        txtCSUB1.Focus();
                    }
                    if (txtCLREG1.Text == "")
                    {
                        txtCLREG1.Focus();
                    }
                    if (txtCSUB2.Text == "")
                    {
                        txtCSUB2.Focus();
                    }
                    if (txtCLREG2.Text == "")
                    {
                        txtCLREG2.Focus();
                    }
                    if (txtCCONTS.Text == "")
                    {
                        txtCCONTS.Focus();
                    }
                    if (txtCCONTD.Text == "")
                    {
                        txtCCONTD.Focus();
                    }
                    if (txtCFEFEC.Text == "")
                    {
                        txtCFEFEC.Focus();
                    }
                    if (cmbentidadvta.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar la identidad.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbentidadvta.Focus();
                        return;
                    }

                    if (cmbperiodo.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar el periodo.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbperiodo.Focus();
                        return;
                    }
                    if (cmbanuladosventas.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar la entidad de anulacion.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbanuladosventas.Focus();
                    }

                    this.Crear_ventas_recepcion();
                    this.Crear_ventas_asientos();

                    obj.EMPRESA = cmbempresas.Text.Substring(0, 3);
                    obj.PERIODO = txtperiodo.Text.Trim();
                    obj.RAZONSOCIAL = txtrazon.Text.Trim();
                    obj.RUC = txtruc.Text.Trim();
                    obj.ENTIDAD = cmbentidadvta.Text.Substring(0, 3);
                    obj.CSUB1_vta = txtCSUB1.Text.Trim();
                    obj.CLREG1_vta = txtCLREG1.Text.Trim();
                    obj.CSUB2_vta = txtCSUB2.Text.Trim();
                    obj.CLREG2_vta = txtCLREG2.Text.Trim();
                    obj.CCONTS_vta = txtCCONTS.Text.Trim();
                    obj.CCONTD_vta = txtCCONTD.Text;
                    obj.CFEFEC_vta = txtCFEFEC.Text;
                    obj.CENT_ANULA = cmbanuladosventas.Text.Substring(0, 15);

                    if (checkctaresu.Checked == true)
                    {
                        obj.CTARES_vta = 1;
                    }
                    else
                    {
                        obj.CTARES_vta = 0;
                    }
                    if (checkctaimp.Checked == true)
                    {
                        obj.CTAIMP_vta = 1;
                    }
                    else
                    {
                        obj.CTAIMP_vta = 0;
                    }
                    if (checkctaactivo.Checked == true)
                    {
                        obj.CTAACT_Vta = 1;
                    }
                    else
                    {
                        obj.CTAACT_Vta = 0;
                    }
                    if (checkAsientovta.Checked == true)
                    {
                        obj.ASIENTOS_vta = 1;
                    }
                    else
                    {
                        obj.ASIENTOS_vta = 0;
                    }
                    obj.CTIPO = "01";
                    Clase.Cuentas ds = new Clase.Cuentas();
                    respuesta = ds.Insertar(obj);
                    if (respuesta.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de ventas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grabar_Fecha_inicio();
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de ventas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Grabar_Fecha_inicio();
                            /*this.limpiarcasilla();*/
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
                    if (txtCSUB1.Text == "")
                    {
                        txtCSUB1.Focus();
                    }
                    if (txtCLREG1.Text == "")
                    {
                        txtCLREG1.Focus();
                    }
                    if (txtCSUB2.Text == "")
                    {
                        txtCSUB2.Focus();
                    }
                    if (txtCLREG2.Text == "")
                    {
                        txtCLREG2.Focus();
                    }
                    if (txtCCONTS.Text == "")
                    {
                        txtCCONTS.Focus();
                    }
                    if (txtCCONTD.Text == "")
                    {
                        txtCCONTD.Focus();
                    }
                    if (txtCFEFEC.Text == "")
                    {
                        txtCFEFEC.Focus();
                    }
                    if (cmbentidadvta.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar la identidad.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbentidadvta.Focus();
                        return;
                    }

                    if (cmbperiodo.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar el periodo.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbperiodo.Focus();
                        return;
                    }
                    if (cmbanuladosventas.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar la entidad de anulacion.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbanuladosventas.Focus();
                    }

                    this.Crear_ventas_recepcion();
                    this.Crear_ventas_asientos();

                    obj.EMPRESA = cmbempresas.Text.Substring(0, 3);
                    obj.PERIODO = txtperiodo.Text;
                    obj.RAZONSOCIAL = txtrazon.Text;
                    obj.RUC = txtruc.Text;
                    obj.ENTIDAD = cmbentidadvta.Text.Substring(0, 3);
                    obj.CSUB1_vta = txtCSUB1.Text;
                    obj.CLREG1_vta = txtCLREG1.Text;
                    obj.CSUB2_vta = txtCSUB2.Text;
                    obj.CLREG2_vta = txtCLREG2.Text;
                    obj.CCONTS_vta = txtCCONTS.Text;
                    obj.CCONTD_vta = txtCCONTD.Text;
                    obj.CFEFEC_vta = txtCFEFEC.Text;
                    obj.CENT_ANULA = cmbanuladosventas.Text.Substring(0, 15);

                    if (checkctaresu.Checked == true)
                    {
                        obj.CTARES_vta = 1;
                    }
                    else
                    {
                        obj.CTARES_vta = 0;
                    }
                    if (checkctaimp.Checked == true)
                    {
                        obj.CTAIMP_vta = 1;
                    }
                    else
                    {
                        obj.CTAIMP_vta = 0;
                    }
                    if (checkctaactivo.Checked == true)
                    {
                        obj.CTAACT_Vta = 1;
                    }
                    else
                    {
                        obj.CTAACT_Vta = 0;
                    }
                    if (checkAsientovta.Checked == true)
                    {
                        obj.ASIENTOS_vta = 1;
                    }
                    else
                    {
                        obj.ASIENTOS_vta = 0;
                    }
                    obj.CTIPO = "01";
                    Clase.Cuentas ds = new Clase.Cuentas();
                    respuesta = ds.Insertar_postgres(obj);
                    if (respuesta.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de ventas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grabar_Fecha_inicio();
                        
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de ventas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Grabar_Fecha_inicio();
                            /*this.limpiarcasilla();*/
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
        private void Grabar_compras()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    if (txtCSUB1_com.Text == "")
                    {
                        txtCSUB1_com.Focus();
                    }
                    if (txtCLREG1_com.Text == "")
                    {
                        txtCLREG1_com.Focus();
                    }
                    if (txtCSUB2_com.Text == "")
                    {
                        txtCSUB2_com.Focus();
                    }
                    if (txtCLREG2_com.Text == "")
                    {
                        txtCLREG2_com.Focus();
                    }
                    if (txtCCONTS_com.Text == "")
                    {
                        txtCCONTS_com.Focus();
                    }
                    if (txtCCONTD_com.Text == "")
                    {
                        txtCCONTD_com.Focus();
                    }
                    if (txtCFEFEC_com.Text == "")
                    {
                        txtCFEFEC_com.Focus();
                    }

                    string respuesta = "";
                    Clase.CuentasPropiedad obj = new Clase.CuentasPropiedad();


                    if (cmbentidadcrp.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar la identidad.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbentidadcrp.Focus();
                    }

                    if (cmbperiodo.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar el periodo.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbperiodo.Focus();
                    }
                    if (cmbanuladoscompras.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar la entidad de anulacion.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbanuladoscompras.Focus();
                    }
                    this.Crear_compras_recepcion();
                    this.Crear_compras_asientos();
                    ///this.crear_compras_anulaciones();

                    obj.EMPRESA = cmbempresas.Text.Substring(0, 3);
                    obj.PERIODO = txtperiodo.Text.Trim();
                    obj.RAZONSOCIAL = txtrazon.Text.Trim();
                    obj.RUC = txtruc.Text.Trim();
                    obj.ENTIDAD = cmbentidadcrp.Text.Substring(0, 3);
                    obj.CSUB1_com = txtCSUB1_com.Text.Trim();
                    obj.CLREG1_com = txtCLREG1_com.Text.Trim();
                    obj.CSUB2_com = txtCSUB2_com.Text.Trim();
                    obj.CLREG2_com = txtCLREG2_com.Text.Trim();
                    obj.CCONTS_com = txtCCONTS_com.Text.Trim();
                    obj.CCONTD_com = txtCCONTD_com.Text.Trim();
                    obj.CFEFEC_com = txtCFEFEC_com.Text.Trim();
                    obj.CENT_ANULA = cmbanuladoscompras.Text.Substring(0, 15);
                    if (check_ctare_com.Checked == true)
                    {
                        obj.CTARES_com = 1;
                    }
                    else
                    {
                        obj.CTARES_com = 0;
                    }
                    if (check_imp_com.Checked == true)
                    {
                        obj.CTAIMP_com = 1;
                    }
                    else
                    {
                        obj.CTAIMP_com = 0;
                    }
                    if (check_actv_com.Checked == true)
                    {
                        obj.CTAPAS_com = 1;
                    }
                    else
                    {
                        obj.CTAPAS_com = 0;
                    }
                    if (check_asicom_com.Checked == true)
                    {
                        obj.ASIENTOS_com = 1;
                    }
                    else
                    {
                        obj.ASIENTOS_com = 0;
                    }
                    obj.CTIPO = "02";
                    Clase.Cuentas ds = new Clase.Cuentas();
                    respuesta = ds.Insertar(obj);
                    if (respuesta.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de compras.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grabar_Fecha_inicio();
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de compras.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Grabar_Fecha_inicio();
                            /*this.limpiarcasilla();*/
                        }
                        else
                        {
                            MessageBox.Show("No se puedo grabar en configuracion.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    if (txtCSUB1_com.Text == "")
                    {
                        txtCSUB1_com.Focus();
                    }
                    if (txtCLREG1_com.Text == "")
                    {
                        txtCLREG1_com.Focus();
                    }
                    if (txtCSUB2_com.Text == "")
                    {
                        txtCSUB2_com.Focus();
                    }
                    if (txtCLREG2_com.Text == "")
                    {
                        txtCLREG2_com.Focus();
                    }
                    if (txtCCONTS_com.Text == "")
                    {
                        txtCCONTS_com.Focus();
                    }
                    if (txtCCONTD_com.Text == "")
                    {
                        txtCCONTD_com.Focus();
                    }
                    if (txtCFEFEC_com.Text == "")
                    {
                        txtCFEFEC_com.Focus();
                    }

                    string respuesta = "";
                    Clase.CuentasPropiedad obj = new Clase.CuentasPropiedad();


                    if (cmbentidadcrp.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar la identidad.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbentidadcrp.Focus();
                    }

                    if (cmbperiodo.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar el periodo.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbperiodo.Focus();
                    }
                    if (cmbanuladoscompras.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar la entidad de anulacion.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbanuladoscompras.Focus();
                    }
                    this.Crear_compras_recepcion();
                    this.Crear_compras_asientos();
                    ///this.crear_compras_anulaciones();

                    obj.EMPRESA = cmbempresas.Text.Substring(0, 3);
                    obj.PERIODO = txtperiodo.Text;
                    obj.RAZONSOCIAL = txtrazon.Text;
                    obj.RUC = txtruc.Text;
                    obj.ENTIDAD = cmbentidadcrp.Text.Substring(0, 3);
                    obj.CSUB1_com = txtCSUB1_com.Text;
                    obj.CLREG1_com = txtCLREG1_com.Text;
                    obj.CSUB2_com = txtCSUB2_com.Text;
                    obj.CLREG2_com = txtCLREG2_com.Text;
                    obj.CCONTS_com = txtCCONTS_com.Text;
                    obj.CCONTD_com = txtCCONTD_com.Text;
                    obj.CFEFEC_com = txtCFEFEC_com.Text;
                    obj.CENT_ANULA = cmbanuladoscompras.Text.Substring(0, 15);
                    if (check_ctare_com.Checked == true)
                    {
                        obj.CTARES_com = 1;
                    }
                    else
                    {
                        obj.CTARES_com = 0;
                    }
                    if (check_imp_com.Checked == true)
                    {
                        obj.CTAIMP_com = 1;
                    }
                    else
                    {
                        obj.CTAIMP_com = 0;
                    }
                    if (check_actv_com.Checked == true)
                    {
                        obj.CTAPAS_com = 1;
                    }
                    else
                    {
                        obj.CTAPAS_com = 0;
                    }
                    if (check_asicom_com.Checked == true)
                    {
                        obj.ASIENTOS_com = 1;
                    }
                    else
                    {
                        obj.ASIENTOS_com = 0;
                    }
                    obj.CTIPO = "02";
                    Clase.Cuentas ds = new Clase.Cuentas();
                    respuesta = ds.Insertar_postgres(obj);
                    if (respuesta.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de compras.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grabar_Fecha_inicio();
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de compras.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Grabar_Fecha_inicio();
                            /*this.limpiarcasilla();*/
                        }
                        else
                        {
                            MessageBox.Show("No se puedo grabar en configuracion.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
        private void Grabar_cobranzas()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
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

                    this.Crear_fin_cobranzapago_asientos();
                    this.Crear_fin_cobranzapago_integra_asientos();

                    obj.EMPRESA = cmbempresas.Text.Substring(0, 3);
                    obj.PERIODO = txtperiodo.Text;
                    obj.RAZONSOCIAL = txtrazon.Text;
                    obj.RUC = txtruc.Text;
                    obj.ENTIDAD = "";
                    obj.CSUB1_vta = txtsubdiario_cobra.Text;
                    obj.CLREG1_vta = txtregistro_cobra.Text;
                    obj.CSUB2_vta = "";
                    obj.CLREG2_vta = "";
                    obj.CCONTS_vta = "";
                    obj.CCONTD_vta = "";
                    obj.CFEFEC_vta = txtflujocobra.Text;
                    obj.CENT_ANULA = "";
                    obj.CTARES_vta = 0;
                    obj.CTAIMP_vta = 0;
                    obj.CTAACT_Vta = 0;
                    obj.ASIENTOS_vta = 0;
                    obj.CTIPO = "03";

                    Clase.Cuentas ds = new Clase.Cuentas();
                    respuesta = ds.Insertar(obj);
                    if (respuesta.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de cobranzas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grabar_Fecha_inicio();
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de cobranzas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Grabar_Fecha_inicio();
                            /*this.limpiarcasilla();*/
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
                 
                    this.Crear_fin_cobranzapago_asientos();
                    this.Crear_fin_cobranzapago_integra_asientos();

                    obj.EMPRESA = cmbempresas.Text.Substring(0, 3);
                    obj.PERIODO = txtperiodo.Text;
                    obj.RAZONSOCIAL = txtrazon.Text;
                    obj.RUC = txtruc.Text;
                    obj.ENTIDAD = "";
                    obj.CSUB1_vta = txtsubdiario_cobra.Text;
                    obj.CLREG1_vta = txtregistro_cobra.Text;
                    obj.CSUB2_vta = "";
                    obj.CLREG2_vta = "";
                    obj.CCONTS_vta = "";
                    obj.CCONTD_vta = "";
                    obj.CFEFEC_vta = txtflujocobra.Text;
                    obj.CENT_ANULA = "";
                    obj.CTARES_vta = 0;
                    obj.CTAIMP_vta = 0;
                    obj.CTAACT_Vta = 0;
                    obj.ASIENTOS_vta = 0;
                    obj.CTIPO = "03";
                  
                    Clase.Cuentas ds = new Clase.Cuentas();
                    respuesta = ds.Insertar_postgres(obj);
                    if (respuesta.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de ventas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grabar_Fecha_inicio();
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de ventas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Grabar_Fecha_inicio();
                            /*this.limpiarcasilla();*/
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
        private void Grabar_pagos()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {


                try
                {
                    string respuesta = "";
                    Clase.CuentasPropiedad obj = new Clase.CuentasPropiedad();
                    if (txtsubdiario_pago.Text == "")
                    {
                        txtsubdiario_pago.Focus();
                    }
                    if (txtregistro_pago.Text == "")
                    {
                        txtregistro_pago.Focus();
                    }
                    if (txtflujopago.Text == "")
                    {
                        txtflujopago.Focus();
                    }
                    if (cmbperiodo.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar el periodo.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbperiodo.Focus();
                        return;
                    }
                    this.Crear_fin_cobranzapago_asientos();
                    this.Crear_fin_cobranzapago_integra_asientos();

                    obj.EMPRESA = cmbempresas.Text.Substring(0, 3);
                    obj.PERIODO = txtperiodo.Text;
                    obj.RAZONSOCIAL = txtrazon.Text;
                    obj.RUC = txtruc.Text;
                    obj.ENTIDAD = "";
                    obj.CSUB1_com = txtsubdiario_pago.Text;
                    obj.CLREG1_com = txtregistro_pago.Text;
                    obj.CSUB2_com = "";
                    obj.CLREG2_com = "";
                    obj.CCONTS_com = "";
                    obj.CCONTD_com = "";
                    obj.CFEFEC_com = txtflujopago.Text;
                    obj.CENT_ANULA = "";
                    obj.CTARES_com = 0;
                    obj.CTAIMP_com = 0;
                    obj.CTAPAS_com = 0;
                    obj.ASIENTOS_com = 0;
                    obj.CTIPO = "04";
                    Clase.Cuentas ds = new Clase.Cuentas();
                    respuesta = ds.Insertar(obj);
                    if (respuesta.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de pagos", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grabar_Fecha_inicio();
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de pagos", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Grabar_Fecha_inicio();
                            /*this.limpiarcasilla();*/
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
                    if (txtsubdiario_pago.Text == "")
                    {
                        txtsubdiario_pago.Focus();
                    }
                    if (txtregistro_pago.Text == "")
                    {
                        txtregistro_pago.Focus();
                    }
                    if (txtflujopago.Text == "")
                    {
                        txtflujopago.Focus();
                    }
                    if (cmbperiodo.Text == "")
                    {
                        MessageBox.Show("Favor de seleccionar el periodo.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        cmbperiodo.Focus();
                        return;
                    }
                    

                    this.Crear_fin_cobranzapago_asientos();
                    this.Crear_fin_cobranzapago_integra_asientos();

                    obj.EMPRESA = cmbempresas.Text.Substring(0, 3);
                    obj.PERIODO = txtperiodo.Text;
                    obj.RAZONSOCIAL = txtrazon.Text;
                    obj.RUC = txtruc.Text;
                    obj.ENTIDAD = "";
                    obj.CSUB1_com = txtsubdiario_pago.Text;
                    obj.CLREG1_com = txtregistro_pago.Text;
                    obj.CSUB2_com = "";
                    obj.CLREG2_com = "";
                    obj.CCONTS_com = "";
                    obj.CCONTD_com = "";
                    obj.CFEFEC_com = txtflujopago.Text;
                    obj.CENT_ANULA = "";
                    obj.CTARES_com = 0;
                    obj.CTAIMP_com = 0;
                    obj.CTAPAS_com = 0;
                    obj.ASIENTOS_com = 0;
                    obj.CTIPO = "04";
                    Clase.Cuentas ds = new Clase.Cuentas();
                    respuesta = ds.Insertar_postgres(obj);
                    if (respuesta.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de pagos", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de pagos", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /*this.limpiarcasilla();*/
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
        private void Carga2()
        //*   proceso para jalar de la empresa seleccionada la informacion del cg_emppro*//
        {
            try
            { 
            NpgsqlConnection cone1 = new NpgsqlConnection();
            string text01 = "SELECT CSUB1,CLREG1,CSUB2,CLREG2,CCONTS,CCONTD," +
             "CFEFEC,CTARES,CTAIMP,CTAACT,GENVTA FROM cg_emppro where CPER='" + cmbperiodo.Text + "'";
            cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
            NpgsqlCommand cmdp = new NpgsqlCommand(text01, cone1);
            cone1.Open();
            
                NpgsqlDataReader grilla = cmdp.ExecuteReader();
                dataGridView1.Rows.Clear();
                grilla.Read();

                txtCSUB1.Text = grilla[0].ToString();
                txtCLREG1.Text = grilla[1].ToString();
                txtCSUB2.Text = grilla[2].ToString();
                txtCLREG2.Text = grilla[3].ToString();
                txtCCONTS.Text = grilla[4].ToString();
                txtCCONTD.Text = grilla[5].ToString();
                txtCFEFEC.Text = grilla[6].ToString();

                if (grilla[7].ToString() == "1")
                {
                    checkctaresu.Checked = true;
                }
                else
                {
                    checkctaresu.Checked = false;
                }
                if (grilla[8].ToString() == "1")
                {
                    checkctaimp.Checked = true;
                }
                else
                {
                    checkctaimp.Checked = false;
                }
                if (grilla[9].ToString() == "1")
                {
                    checkctaactivo.Checked = true;
                }
                else
                {
                    checkctaactivo.Checked = false;
                }
                if (grilla[10].ToString() == "1")
                {
                    checkAsientovta.Checked = true;
                }
                else
                {
                    checkAsientovta.Checked = false;
                }
 
                grilla.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe los datos de ventas " + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
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
                    dataGridView1.Rows.Clear();
                    grilla.Read();

                    txtrazon.Text = grilla[0].ToString().Replace("'"," ");
                    txtruc.Text = grilla[1].ToString();
                    this.Seleccion();

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
        private void Cargar()
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
                MessageBox.Show("Error no Existe empresa "+ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
                Tablero.Enabled = false;
            }

        }
        private void Cargarentidad()
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text02 = "SELECT CONCAT(LTRIM(CCODTIPENT),' ',LTRIM(CDESTIPENT)) ::CHARACTER(80)AS ENTIDAD FROM cg_tipentidad";
                cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmdp2 = new NpgsqlCommand(text02, cone1);
                cone1.Open();
                NpgsqlDataReader grilla2 = cmdp2.ExecuteReader();
                cmbentidadvta.Items.Clear();
                cmbentidadcrp.Items.Clear();
                while (grilla2.Read())
                {
                    cmbentidadvta.Items.Add(grilla2[0].ToString());
                    cmbentidadvta.Refresh();
                    cmbentidadcrp.Items.Add(grilla2[0].ToString());
                    cmbentidadcrp.Refresh();


                }
                grilla2.Close();
            }
            catch 
            {
                MessageBox.Show("Error no Existe entidades." , "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
            }

        }
        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        public  void Cmbperiodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtperiodo.Text = cmbperiodo.Text.Trim();

            

            if (this.txtventa.Text== "0")
            { this.tabPage1.Parent = null; }

            if (this.txtcompras.Text == "0")
            { this.tabPage2.Parent = null; }

            if (this.txtcobranza.Text == "0")
            { this.tabPage3.Parent = null; }

            if (this.txtpago.Text == "0")
            { this.tabPage4.Parent = null; }


            this.Carga3();
            
            
        }
        private void FrmIntegradorConta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult dialogResult = MessageBox.Show("Deseas salir de configuracion de cuentas.?", "Contasis Corp.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                    this.Hide();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
               
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                DialogResult dialogResult = MessageBox.Show("Deseas salir de configuracion de cuentas.?", "Contasis Corp.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                    this.Hide();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

            }
            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void TxtCSUB1_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(1, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("1", txtCSUB1.Text);
            }



        }
        private void TxtCLREG1_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(2, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("2", txtCLREG1.Text);
            }


        }
        private void TxtCSUB2_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(3, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("3", txtCSUB2.Text);
            }


        }
        private void TxtCLREG2_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(4, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("4", txtCLREG2.Text);
            }

        }
        private void TxtCCONTS_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(5, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("5", txtCCONTS.Text);
            }

        }
        private void TxtCCONTD_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(6, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("6", txtCCONTD.Text);
            }
        }
        private void TxtCFEFEC_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(7, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("7", txtCFEFEC.Text);
            }
        }
        public  void Txtperiodo_TextChanged(object sender, EventArgs e)
        {
            txtperiodo.Text = cmbperiodo.Text;
        }
        private void TxtCSUB1_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(8, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("8", txtCSUB1_com.Text);
            }
        }
        private void TxtCLREG1_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(9, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("9", txtCLREG1_com.Text);
            }
        }
        private void TxtCSUB2_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(10, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("10", txtCSUB2_com.Text);
            }
        }
        private void TxtCLREG2_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(11, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("11", txtCLREG2_com.Text);
            }
        }
        private void TxtCCONTS_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(12, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("12", txtCCONTS_com.Text);
            }
        }
        private void TxtCCONTD_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(13, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("13", txtCCONTD_com.Text);
            }
        }
            private void TxtCFEFEC_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(14, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("14", txtCFEFEC_com.Text);
            }
            if (e.KeyCode == Keys.Tab)
            {
                this.Validar_cuentas("14", txtCFEFEC_com.Text);
            }


        }
        private void Button1_Click(object sender, EventArgs e)
        {/*** PDI-148 06/12/2024**/
            if (txtFechaInicio.Text == "")
            {
                MessageBox.Show("Favor ingrese una fecha para el inicio del proceso de Integración.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                this.Grabar_ventas();
                this.Mostrar_registros_ventas();
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {/*** PDI-148 06/12/2024**/
            if (txtFechaInicio.Text == "")
            {
                MessageBox.Show("Favor ingrese una fecha para el inicio del proceso de Integración.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                this.Grabar_compras();
                this.Mostrar_registros_compras();
            }
        }
        public void Mostrar_registros_ventas()
        {
            FechaInicio.Enabled = true;
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {

                    Clase.Cuentas regis = new Clase.Cuentas();
                    string xEmpresa = cmbempresas.Text.Substring(0, 3);
                    string xperiodo = cmbperiodo.Text;
                    dataGridView_venta.DataSource = null;
                    dataGridView_venta.DataSource = regis.Cargar_ventas(xEmpresa, xperiodo);
                    dataGridView_venta.AllowUserToAddRows = false;

                    dataGridView_venta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_venta.ReadOnly = true;

                    if (dataGridView_venta.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_venta.CurrentCell = this.dataGridView_venta.Rows[0].Cells[1];
                        this.dataGridView_venta.Refresh();
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
                    
                    dataGridView_venta.AllowUserToAddRows = false;
                    
                    dataGridView_venta.DataSource = regis.Cargar_ventas_postgres(xEmpresa, xperiodo);

                    dataGridView_venta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_venta.ReadOnly = true;

                    if (dataGridView_venta.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_venta.CurrentCell = this.dataGridView_venta.Rows[0].Cells[1];
                        this.dataGridView_venta.Refresh();
                    }
                    this.dataGridView_venta.Refresh();
                    FechaInicio.Enabled = true; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }
        public void Mostrar_registros_compras()
        {
            FechaInicio.Enabled = true;
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {

                try
                {
                    Clase.Cuentas regis = new Clase.Cuentas();

                    string xEmpresa = cmbempresas.Text.Substring(0, 3);
                    string xperiodo = cmbperiodo.Text;

                    dataGridView_compra.DataSource = regis.Cargar_compras(xEmpresa, xperiodo);
                    dataGridView_compra.AllowUserToAddRows = false;
                    dataGridView_compra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_compra.ReadOnly = true;

                    if (dataGridView_compra.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_compra.CurrentCell = this.dataGridView_compra.Rows[0].Cells[1];
                        this.dataGridView_compra.Refresh();
                    }
                    this.dataGridView_compra.Refresh();
                    FechaInicio.Enabled = true;
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

                    dataGridView_compra.DataSource = regis.Cargar_compras_postgres(xEmpresa, xperiodo);
                    dataGridView_compra.AllowUserToAddRows = false;
                    dataGridView_compra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_compra.ReadOnly = true;

                    if (dataGridView_compra.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_compra.CurrentCell = this.dataGridView_compra.Rows[0].Cells[1];
                        this.dataGridView_compra.Refresh();
                    }
                    this.dataGridView_compra.Refresh();
                    FechaInicio.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }


        }
        public void Mostrar_registros_cobranzas()
        {
            FechaInicio.Enabled = true;
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

                    dataGridView_cobranza.DataSource = regis.Cargar_cobranzas_postgres(xEmpresa, xperiodo);

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
        public void Mostrar_registros_pagos()
        {
            FechaInicio.Enabled = true;
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {

                try
                {
                    Clase.Cuentas regis = new Clase.Cuentas();

                    string xEmpresa = cmbempresas.Text.Substring(0, 3);
                    string xperiodo = cmbperiodo.Text;

                    dataGridView_pago.DataSource = regis.Cargar_pagos(xEmpresa, xperiodo);
                    dataGridView_pago.AllowUserToAddRows = false;
                    dataGridView_pago.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_pago.ReadOnly = true;

                    if (dataGridView_pago.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_pago.CurrentCell = this.dataGridView_pago.Rows[0].Cells[1];
                        this.dataGridView_pago.Refresh();
                    }
                    this.dataGridView_pago.Refresh();
                    FechaInicio.Enabled = true;
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

                    dataGridView_pago.DataSource = regis.Cargar_pagos_postgres(xEmpresa, xperiodo);
                    dataGridView_pago.AllowUserToAddRows = false;
                    dataGridView_pago.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_pago.ReadOnly = true;

                    if (dataGridView_pago.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_pago.CurrentCell = this.dataGridView_pago.Rows[0].Cells[1];
                        this.dataGridView_pago.Refresh();
                    }
                    this.dataGridView_pago.Refresh();
                    FechaInicio.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }


        }
        public void Seleccion()
        {
            if (cmbperiodo.Text == " ")
            {
                MessageBox.Show("Favor seleccionar periodo vigente.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbperiodo.Focus();
                return;
            }
            else
            {
                /**********************************************************/
                try
                {
                    

                    string query01 = "select case when ncierre1>0 AND ncierre2>0  AND ncierre3>0 AND ncierre4>0 AND ncierre5>0  AND ncierre6>0 AND ncierre7>0  AND  ncierre8>0  AND ncierre9>0 " +
                     " AND ncierre10> 0 AND ncierre11> 0 AND ncierre12> 0 then 'CERRADO' ELSE 'ABIERTO' END From cg_emppro"+
                     " where cper = '" + txtperiodo.Text.Trim() + "'";

                    NpgsqlConnection cone1 = new NpgsqlConnection();
                    cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand cmdp2 = new NpgsqlCommand(query01, cone1);
                    cone1.Open();
                    NpgsqlDataReader grilla2 = cmdp2.ExecuteReader();
                    while (grilla2.Read())
                    {
                        txtestado.Text = grilla2[0].ToString();
                    }
                    grilla2.Close();

                    if (txtestado.Text.Trim() == "CERRADO")
                    {
                        MessageBox.Show("Periodo no puede ser seleccionar por estar cerrado.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }
                }
                catch 
                {
                    MessageBox.Show("Error en la consulta de periodos en contasis.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

                /**********************************************************/

                Tablero.Enabled = true;
                SqlConnection cone = new SqlConnection();

                try
                {
                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {

                        string query0 = "SELECT * FROM CONFIGURACION WHERE CPER='" + txtperiodo.Text + "' AND CCOD_EMPRESA='" + cmbempresas.Text.Substring(0, 3) + "'";
                        cone = Clase.ConexionSql.Instancial().Establecerconexion();
                        SqlCommand commando = new SqlCommand(query0, cone);
                        DataTable dt = new DataTable();
                        cone.Open();
                        SqlDataAdapter data = new SqlDataAdapter(commando);
                        data.Fill(dt);


                        if (dt.Rows.Count > 0)
                        {
                            this.Mostrar_registros_ventas();
                            this.Mostrar_registros_compras();
                            this.Mostrar_registros_cobranzas();
                            this.Mostrar_registros_pagos();
                            this.Cargar_Fecha_inicio();
                          
                        }

                        else
                        {
                            this.Carga2();
                        }

                    }
                    else
                    {
                        
                        NpgsqlConnection conexion = new NpgsqlConnection();
                        conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                        conexion.Open();
                        string query0 = "SELECT * FROM CONFIGURACION WHERE CPER='" + txtperiodo.Text + "' AND CCOD_EMPRESA='" + cmbempresas.Text.Substring(0, 3) + "'";
                        NpgsqlCommand cmdp = new NpgsqlCommand(query0, conexion);
                        DataTable dt = new DataTable();
                        NpgsqlDataAdapter data = new NpgsqlDataAdapter(cmdp);
                        data.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            this.Mostrar_registros_ventas();
                            this.Mostrar_registros_compras();
                            this.Mostrar_registros_cobranzas();
                            this.Mostrar_registros_pagos();
                            this.Cargar_Fecha_inicio();
                            
                        }

                        else
                        {
                            this.Carga2();
                        }


                    }
                }


                catch (Exception ex1)
                {
                    MessageBox.Show(ex1.ToString());

                }
                finally
                {
                    if (cone.State == ConnectionState.Open)
                    {
                        cone.Close();
                    }

                }
            



            }
            
        }
        private void DataGridView_venta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = e.RowIndex;
        }
        private void DataGridView_venta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (posicion == 1)
            {
                return;
            }

            if (dataGridView_venta.Rows.Count > 0)
            {
                if (posicion == -1)
                {
                    posicion = 0;
                        }
                else { 
                    posicion = e.RowIndex;
                     }
                txtCSUB1.Text = dataGridView_venta.Rows[posicion].Cells["csub1_vta"].Value.ToString();
                txtCLREG1.Text = dataGridView_venta.Rows[posicion].Cells["clreg1_vta"].Value.ToString();
                txtCSUB2.Text = dataGridView_venta.Rows[posicion].Cells["csub2_vta"].Value.ToString();
                txtCLREG2.Text = dataGridView_venta.Rows[posicion].Cells["clreg2_vta"].Value.ToString();
                txtCCONTS.Text = dataGridView_venta.Rows[posicion].Cells["cconts_vta"].Value.ToString();
                txtCCONTD.Text = dataGridView_venta.Rows[posicion].Cells["ccontd_vta"].Value.ToString();
                txtCFEFEC.Text = dataGridView_venta.Rows[posicion].Cells["cfefec_vta"].Value.ToString();
                FechaInicio.Enabled = true;
                
                if (dataGridView_venta.Rows[posicion].Cells["RESULTADO"].Value.ToString() == "1")
                {
                    checkctaresu.Checked = true;
                }
                else
                {
                    checkctaresu.Checked = false;
                }
                if (dataGridView_venta.Rows[posicion].Cells["IMPUESTOS"].Value.ToString() == "1")
                {
                    checkctaimp.Checked = true;
                }
                else
                {
                    checkctaimp.Checked = false;
                }
                if (dataGridView_venta.Rows[posicion].Cells["ACTIVO_VTA"].Value.ToString() == "1")
                {
                    checkctaactivo.Checked = true;
                }
                else
                {
                    checkctaactivo.Checked = false;
                }
                if (dataGridView_venta.Rows[posicion].Cells["ASIENTO_VTA"].Value.ToString() == "1")
                {
                    checkAsientovta.Checked = true;
                }
                else
                {
                    checkAsientovta.Checked = false;
                }
                this.Cargarentidad2(dataGridView_venta.Rows[posicion].Cells["ENTIDAD_VENTA"].Value.ToString());
                cmbentidadvta.Text = combo;

                this.Anulados2(dataGridView_venta.Rows[posicion].Cells["ENT_ANULADO"].Value.ToString());
                cmbanuladosventas.Text = combo;

            }
        }
        private void Cargarentidad2(string valor)
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text02 = "SELECT CONCAT(LTRIM(CCODTIPENT),' ',LTRIM(CDESTIPENT)) ::CHARACTER(80)AS ENTIDAD FROM cg_tipentidad WHERE CCODTIPENT='"+valor+"'";
                cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmdp2 = new NpgsqlCommand(text02, cone1);
                cone1.Open();
                NpgsqlDataReader grilla2 = cmdp2.ExecuteReader();
               
                while (grilla2.Read())
                {
                    combo = grilla2[0].ToString();

                }
                
                grilla2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe entidades." + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
            }
            
        }
        private void Anulados()
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text02 = "select concat(CCODRUC,' ',LTRIM(CRAZSOC))  ::char(60) as CODIGO  from cg_entitrib where NUTIANU=1";
                cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand comando3 = new NpgsqlCommand(text02, cone1);
                    cone1.Open();
                    NpgsqlDataReader grilla3 = comando3.ExecuteReader();
                cmbanuladoscompras.Items.Clear();
                cmbanuladosventas.Items.Clear();
                    while (grilla3.Read())
                    {
                    cmbanuladoscompras.Items.Add(grilla3[0].ToString());
                    cmbanuladoscompras.Refresh();
                    cmbanuladosventas.Items.Add(grilla3[0].ToString());
                    cmbanuladosventas.Refresh();


                    }
                    grilla3.Close();
                }

            catch 
            {
                MessageBox.Show("Error no existen en Entidades anulados ","Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
            }

        }
        private void Anulados2(string valor)
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text02 = "select concat(CCODRUC,' ',LTRIM(CRAZSOC))  ::char(60) as CODIGO  from cg_entitrib where NUTIANU = 1 and CCODRUC = '" + valor + "'";
                cone1 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand cmdp2 = new NpgsqlCommand(text02, cone1);
                cone1.Open();
                NpgsqlDataReader grilla2 = cmdp2.ExecuteReader();

                while (grilla2.Read())
                {
                    combo = grilla2[0].ToString();

                }

                grilla2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe entidades " + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
            }

        }
        private void DataGridView_compra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = e.RowIndex;
        }
        private void DataGridView_compra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (posicion == 1)
            {
                return;
            }



            if (dataGridView_compra.Rows.Count > 0)
            {

                txtCSUB1_com.Text = dataGridView_compra.Rows[posicion].Cells["csub1_com"].Value.ToString();
                txtCLREG1_com.Text = dataGridView_compra.Rows[posicion].Cells["clreg1_com"].Value.ToString();
                txtCSUB2_com.Text = dataGridView_compra.Rows[posicion].Cells["csub2_com"].Value.ToString();
                txtCLREG2_com.Text = dataGridView_compra.Rows[posicion].Cells["clreg2_com"].Value.ToString();
                txtCCONTS_com.Text = dataGridView_compra.Rows[posicion].Cells["cconts_com"].Value.ToString();
                txtCCONTD_com.Text = dataGridView_compra.Rows[posicion].Cells["ccontd_com"].Value.ToString();
                txtCFEFEC_com.Text = dataGridView_compra.Rows[posicion].Cells["cfefec_com"].Value.ToString();

                if (dataGridView_compra.Rows[posicion].Cells["RESULTADO_COM"].Value.ToString() == "1")
                {
                    check_ctare_com.Checked = true;
                }
                else
                {
                    check_ctare_com.Checked = false;
                }
                if (dataGridView_compra.Rows[posicion].Cells["IMPUESTOS_COM"].Value.ToString() == "1")
                {
                    check_imp_com.Checked = true;
                }
                else
                {
                    check_imp_com.Checked = false;
                }
                if (dataGridView_compra.Rows[posicion].Cells["ACTIVO_COM"].Value.ToString() == "1")
                {
                    check_actv_com.Checked = true;
                }
                else
                {
                    check_actv_com.Checked = false;
                }
                if (dataGridView_compra.Rows[posicion].Cells["ASIENTO_COM"].Value.ToString() == "1")
                {
                    check_asicom_com.Checked = true;
                }
                else
                {
                    check_asicom_com.Checked = false;
                }
                this.Cargarentidad2(dataGridView_compra.Rows[posicion].Cells["ENTIDAD_COMPRA"].Value.ToString());
                cmbentidadcrp.Text = combo;

                this.Anulados2(dataGridView_venta.Rows[posicion].Cells["ENT_ANULADO"].Value.ToString());
                cmbanuladoscompras.Text = combo;

            }
        }
        public void Crear_compras_anulaciones()
        {

            NpgsqlConnection cone01 = new NpgsqlConnection();

            try
            {


                string query0 = "SELECT distinct TABLE_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='fin_anuladoc'";
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand commando = new NpgsqlCommand(query0, cone01);
                cone01.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    string tmpquery = "create table fin_anuladoc ("+
                    " idcompras numeric(20,0),"+
                    " ccod_empresa character(3)," +
                    " cper character(4)," +
                    " ccoddoc character(2)," +
                    "  cserie character(20)," +
                    " cnumero character(20)," +
                    " ccodruc character(15)," +
                    " ccodrucanula character(15)) ";
                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand commando1 = new NpgsqlCommand(tmpquery, cone01);
                    cone01.Open();
                    commando1.ExecuteNonQuery();

                    NpgsqlCommand commando2 = new NpgsqlCommand(txtguardarcompras.Text, cone01);
                    commando2.ExecuteNonQuery();

                 //   NpgsqlCommand commando22 = new NpgsqlCommand(txtanulacionventas.Text, cone01);
                  //  commando22.ExecuteNonQuery();

                }

                else
                {
                   
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
        public void Crear_compras_recepcion()
        {
            
            NpgsqlConnection cone01 = new NpgsqlConnection();

            try
            {


                string query0 = "SELECT distinct TABLE_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='fin_compras'";
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand commando = new NpgsqlCommand(query0, cone01);
                cone01.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    string tmpquery = "CREATE TABLE FIN_COMPRAS(idcompras numeric(20),ccod_empresa char(3) NULL,cper char(4) NULL,cmes char(2) NULL," +
                    "ccodori CHAR(3),ccodsu CHAR(2),ccodori_P CHAR(3),ccodsu_P CHAR(2),ccodcue_ps CHAR(20),ccodcue_pd CHAR(20) ,ccodflu CHAR(4),"+
                    "flgctares numeric(1),flgctaimp numeric(1),flgctaact numeric(1),flggencomp numeric(1), ccodtipent char(3)," +
                    "ffechadoc date NULL,fechaven date NULL,ccoddoc nchar(2) NULL,ccoddas nchar(3) NULL,cyeardas nchar(4) NULL," +
                    "cserie nchar(20) NULL,cnumero nchar(20) NULL,ccodenti nchar(11) NULL,cdesenti nchar(100) NULL,ctipdoc nchar(1) NULL," +
                    "ccodruc nchar(15) NULL,crazsoc nchar(100) NULL,ccodclas nchar(1) NULL,nbase1 numeric(15, 2) NULL,nigv1 numeric(15, 2) NULL," +
                    "nbase2 numeric(15, 2) NULL,nigv2 numeric(15, 2) NULL,nbase3 numeric(15, 2) NULL,nigv3 numeric(15, 2) NULL," +
                    "nina numeric(15, 2) NULL,nisc numeric(15, 2) NULL,	nicbper numeric(15, 2) NULL,nexo numeric(15, 2) NULL,ntots numeric(15, 2) NULL," +
                    "cdocnodom nchar(20) NULL,cnumdere nchar(15) NULL,ffecre date NULL,	ntc numeric(10, 6) NULL,freffec date NULL," +
                    "crefdoc nchar(2) NULL,	crefser nchar(6) NULL,crefnum nchar(13) NULL,	cmreg nchar(1) NULL,ndolar numeric(15, 2) NULL," +
                    "ffechaven2 date NULL,ccond nchar(3) NULL,cctabase nchar(10) NULL,cctaicbper nchar(10) NULL,cctaotrib nchar(10) NULL," +
                    "cctatot nchar(10) NULL,ccodcos nchar(9) NULL,ccodcos2 nchar(9) NULL,nresp numeric(1, 0) NULL,nporre numeric(5, 2) NULL," +
                    "nimpres numeric(15, 2) NULL,cserre nchar(6) NULL,cnumre nchar(13) NULL,ffecre2 date NULL,ccodpresu nchar(10) NULL," +
                    "nigv numeric(5, 2) NULL,cglosa nchar(50) NULL,nperdenre numeric(15, 2) NULL,nbaseres numeric(15, 2) NULL,cigvxacre nchar(1) NULL," +
	                "created_at timestamp NULL,	updated_at timestamp NULL,estado varchar(255) NULL,en_ambiente_de varchar(255) NULL,"+
                    "es_con_migracion numeric(1, 0) NULL,ccodcos3 nchar(15) NULL,ccodrucanula nchar(15)  not null default '',   obserror text NULL," +
                    "resultado_migracion numeric(1,0),nflgexisteanular integer not null default 0)";
                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand commando1 = new NpgsqlCommand(tmpquery, cone01);
                    cone01.Open();
                    commando1.ExecuteNonQuery();

                    NpgsqlCommand commando2 = new NpgsqlCommand(txtguardarcompras.Text, cone01);
                    commando2.ExecuteNonQuery();

                    //NpgsqlCommand commando22 = new NpgsqlCommand(txtanulacionventas.Text, cone01);
                    //commando22.ExecuteNonQuery();

                    NpgsqlCommand commando23 = new NpgsqlCommand(txtasientocompas1.Text, cone01);
                    commando23.ExecuteNonQuery();

                    NpgsqlCommand commando24 = new NpgsqlCommand(txtasientocompas2.Text, cone01);
                    commando24.ExecuteNonQuery();

                }

                else
                {
                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    cone01.Open();
                    NpgsqlCommand commando2 = new NpgsqlCommand(txtguardarcompras.Text, cone01);
                    commando2.ExecuteNonQuery();

                   // NpgsqlCommand commando22 = new NpgsqlCommand(txtanulacionventas.Text, cone01);
                    //commando22.ExecuteNonQuery();

                    NpgsqlCommand commando23 = new NpgsqlCommand(txtasientocompas1.Text, cone01);
                    commando23.ExecuteNonQuery();

                    NpgsqlCommand commando24 = new NpgsqlCommand(txtasientocompas2.Text, cone01);
                    commando24.ExecuteNonQuery();
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
        public void Crear_ventas_recepcion()
        {

            NpgsqlConnection cone01 = new NpgsqlConnection();

            try
            {


                string query0 = "SELECT distinct TABLE_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='fin_ventas'";
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand commando = new NpgsqlCommand(query0, cone01);
                cone01.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    string tmpquery = "CREATE TABLE FIN_VENTAS(idventas numeric(20),ccod_empresa char(3) NULL,cper char(4) NULL,cmes char(2) NULL," +
                    "ccodori CHAR(3),ccodsu CHAR(2),ccodori_P CHAR(3),ccodsu_P CHAR(2),ccodcue_ps CHAR(20),ccodcue_pd CHAR(20) ,ccodflu CHAR(4)," +
                    "flgctares numeric(1),flgctaimp numeric(1),flgctaact numeric(1),flggencomp numeric(1), ccodtipent char(3)," +
                    "ffechadoc date NULL,ffechaven date NULL,ccoddoc nchar(2) NULL,cserie nchar(20) NULL,cnumero nchar(20) NULL," +
                    "ccodenti nchar(11) NULL,cdesenti nchar(100) NULL,ctipdoc nchar(1) NULL,ccodruc nchar(15) NULL,crazsoc nchar(100) NULL," +
                    "nbase2 numeric(15, 2) NULL,nbase1 numeric(15, 2) NULL,	nexo numeric(15, 2) NULL,nina numeric(15, 2) NULL,nisc numeric(15, 2) NULL," +
                    "nigv1 numeric(15, 2) NULL,nicbpers numeric(15, 2) NULL,nbase3 numeric(15, 2) NULL,ntots numeric(15, 2) NULL,ntc numeric(10, 6) NULL," +
                    "freffec timestamp NULL,crefdoc nchar(2) NULL,crefser char(6) NULL,crefnum nchar(13) NULL,cmreg nchar(1) NULL,ndolar numeric(15, 2) NULL," +
                    "ffechaven2 date NULL,ccond nchar(3) NULL,ccodcos nchar(9) NULL,ccodcos2 nchar(9) NULL,cctabase nchar(20) NULL,cctaicbper nchar(20) NULL," +
                    "cctaotrib nchar(20) NULL,cctatot nchar(20) NULL,nresp numeric(1, 0) NULL,nporre numeric(5, 2) NULL,nimpres numeric(15, 2) NULL," +
                    "cserre nchar(6) NULL,cnumre nchar(13) NULL,ffecre timestamp NULL,ccodpresu nchar(10) NULL,	nigv numeric(5, 2) NULL,cglosa nchar(80) NULL," +
                    "ccodpago nchar(3) NULL,nperdenre numeric(1, 0) NULL,nbaseres numeric(15, 2) NULL,cctaperc nchar(20) NULL,created_at timestamp NULL," +
                    "updated_at timestamp NULL,	estado varchar(255) NULL,	en_ambiente_de varchar(255) NULL," +
                    "es_con_migracion numeric(1, 0) NULL,ccodcos3 nchar(15) NULL,ccodrucanula nchar(15)  not null default '',   obserror text NULL," +
                    "resultado_migracion numeric(1,0),nflgexisteanular integer not null default 0)";
                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand commando1 = new NpgsqlCommand(tmpquery, cone01);
                    cone01.Open();
                    commando1.ExecuteNonQuery();

                    NpgsqlCommand commando2 = new NpgsqlCommand(txtguardarventas.Text, cone01);
                    commando2.ExecuteNonQuery();
                                        
                    NpgsqlCommand commando3 = new NpgsqlCommand(txtasientoventas1.Text, cone01);
                    commando3.ExecuteNonQuery();

                    NpgsqlCommand commando4 = new NpgsqlCommand(txtasientoventas2.Text, cone01);
                    commando4.ExecuteNonQuery();




                }

                else
                {
                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    cone01.Open();
                    NpgsqlCommand commando2 = new NpgsqlCommand(txtguardarventas.Text, cone01);
                    commando2.ExecuteNonQuery();
                    
                    NpgsqlCommand commando3 = new NpgsqlCommand(txtasientoventas1.Text, cone01);
                    commando3.ExecuteNonQuery();

                    NpgsqlCommand commando4 = new NpgsqlCommand(txtasientoventas2.Text, cone01);
                    commando4.ExecuteNonQuery();

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
        public void Crear_compras_asientos()
        {

            NpgsqlConnection cone01 = new NpgsqlConnection();

            try
            {


                string query0 = "SELECT distinct TABLE_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='cf_regcom_integra'";
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand commando = new NpgsqlCommand(query0, cone01);
                cone01.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    string tmpquery = "CREATE TABLE cf_regcom_integra(idcompras numeric(20)," +
                    "cper character(4) NOT NULL DEFAULT ''::bpchar,  cmes character(2) NOT NULL DEFAULT ''::bpchar," +
                    "ccodori character(3),  ccodsu character(2),  ccodori_p character(3),  ccodsu_p character(2),  ccodcue_ps character(20)," +
                    "ccodcue_pd character(20),  ccodflu character(4),  flgctares numeric(1, 0),  flgctaimp numeric(1, 0),  flgctaact numeric(1, 0)," +
                    "flggencomp numeric(1, 0)," +
                    "ccodtipent character(3),  nasiento numeric(6, 0) NOT NULL DEFAULT 0,  ffechadoc date,  ffechaven date," +
                    "ccoddoc character(2) NOT NULL DEFAULT ''::bpchar,  ccoddas character(3) NOT NULL DEFAULT ''::bpchar,  cyeardas character(4) NOT NULL DEFAULT ''::bpchar," +
                    "cserie character(20) NOT NULL DEFAULT ''::bpchar,  cnumero character(20) NOT NULL DEFAULT ''::bpchar," +
                    "ccodenti character(11) NOT NULL DEFAULT ''::bpchar,  cdesenti character(100) NOT NULL DEFAULT ''::bpchar," +
                    "ctipdoc character(1) NOT NULL DEFAULT ''::bpchar,  ccodruc character(15) NOT NULL DEFAULT ''::bpchar," +
                    "crazsoc character(150) NOT NULL DEFAULT ''::bpchar,  ccodclas character(1) NOT NULL DEFAULT ''::bpchar," +
                    "nbase1 numeric(15, 2) NOT NULL DEFAULT 0,  nigv1 numeric(15, 2) NOT NULL DEFAULT 0,  nbase2 numeric(15, 2) NOT NULL DEFAULT 0," +
                    "nigv2 numeric(15, 2) NOT NULL DEFAULT 0,  nbase3 numeric(15, 2) NOT NULL DEFAULT 0,  nigv3 numeric(15, 2) NOT NULL DEFAULT 0," +
                    "nina numeric(15, 2) NOT NULL DEFAULT 0,  nisc numeric(15, 2) NOT NULL DEFAULT 0,  nexo numeric(15, 2) NOT NULL DEFAULT 0,  ntots numeric(15, 2) NOT NULL DEFAULT 0," +
                    "cdocnodom character(20) NOT NULL DEFAULT ''::bpchar,  cnumdere character(15) NOT NULL DEFAULT ''::bpchar," +
                    "ffecre date,  ntc numeric(10, 6) NOT NULL DEFAULT 0,  freffec date,  crefdoc character(2) NOT NULL DEFAULT ''::bpchar,  crefser character(10) NOT NULL DEFAULT ''::bpchar," +
                    "crefnum character(13) NOT NULL DEFAULT ''::bpchar,  cmreg character(1) NOT NULL DEFAULT ''::bpchar," +
                    "ndolar numeric(15, 2) NOT NULL DEFAULT 0,  ffechaven2 date,  ccond character(3) NOT NULL DEFAULT ''::bpchar," +
                    "cctabase character(20) NOT NULL DEFAULT ''::bpchar,  cctaotrib character(20) NOT NULL DEFAULT ''::bpchar,  cctatot character(20) NOT NULL DEFAULT ''::bpchar," +
                    "ccodcos character(9) NOT NULL DEFAULT ''::bpchar,  ccodcos2 character(9) NOT NULL DEFAULT ''::bpchar," +
                    "nresp numeric(1, 0) NOT NULL DEFAULT 0,  nporre numeric(5, 2) NOT NULL DEFAULT 0,  nimpres numeric(15, 2) NOT NULL DEFAULT 0," +
                    "cserre character(6) NOT NULL DEFAULT ''::bpchar,  cnumre character(13) NOT NULL DEFAULT ''::bpchar,  ffecre2 date, ccodpresu character(10) NOT NULL DEFAULT ''::bpchar," +
                    "nigv numeric(5, 2) NOT NULL DEFAULT 0,  cglosa character varying(80) NOT NULL DEFAULT ''::character varying," +
                    "nperdenre numeric(1, 0) NOT NULL DEFAULT 0," +
                    "nbaseres numeric(15, 2) NOT NULL DEFAULT 0, incomp character(5) NOT NULL DEFAULT ''::bpchar,  lneg character(5) NOT NULL DEFAULT ''::bpchar," +
                    "vmespd numeric(15, 2) NOT NULL DEFAULT 0,  nnetd numeric(15, 2) NOT NULL DEFAULT 0, nimpd numeric(15, 2) NOT NULL DEFAULT 0," +
                    "nbase2d numeric(15, 2) NOT NULL DEFAULT 0,  nigv2d numeric(15, 2) NOT NULL DEFAULT 0,  nbase3d numeric(15, 2) NOT NULL DEFAULT 0," +
                    "nigv3d numeric(15, 2) NOT NULL DEFAULT 0,  ninad numeric(15, 2) NOT NULL DEFAULT 0,  niscd numeric(15, 2) NOT NULL DEFAULT 0," +
                    "nexod numeric(15, 2) NOT NULL DEFAULT 0,  ntotd numeric(15, 2) NOT NULL DEFAULT 0,  nntc numeric(10, 6) NOT NULL DEFAULT 0," +
                    "nbaseimp numeric(15, 2) NOT NULL DEFAULT 0,  nbaseimpd numeric(15, 2) NOT NULL DEFAULT 0,  nresini character(13) NOT NULL DEFAULT ''::bpchar," +
                    "nresfin character(13) NOT NULL DEFAULT ''::bpchar,  errores text NOT NULL DEFAULT ''::text,  cctacobra character(20) NOT NULL DEFAULT ''::bpchar," +
                    "flaganalb numeric(1, 0) NOT NULL DEFAULT 0,  flaganalo numeric(1, 0) NOT NULL DEFAULT 0,  flaganalt numeric(1, 0) NOT NULL DEFAULT 0," +
                    "flagccosb numeric(1, 0) NOT NULL DEFAULT 0,  flagccoso numeric(1, 0) NOT NULL DEFAULT 0,  flagccost numeric(1, 0) NOT NULL DEFAULT 0," +
                    "flagpresub numeric(1, 0) NOT NULL DEFAULT 0,  flagpresuo numeric(1, 0) NOT NULL DEFAULT 0,  flagpresut numeric(1, 0) NOT NULL DEFAULT 0," +
                    "nicbper numeric(15, 2) NOT NULL DEFAULT 0,  cctaicbper character(20) NOT NULL DEFAULT ''::bpchar,  cigvxacre character(1) NOT NULL DEFAULT ''::bpchar)";                   
                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand commando1 = new NpgsqlCommand(tmpquery, cone01);
                    cone01.Open();
                    commando1.ExecuteNonQuery();


                }

                else
                {
                    return;

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
        public void Crear_ventas_asientos()
        {

            NpgsqlConnection cone01 = new NpgsqlConnection();

            try
            {


                string query0 = "SELECT distinct TABLE_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='cf_regven_integra'";
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand commando = new NpgsqlCommand(query0, cone01);
                cone01.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    string tmpquery = "CREATE TABLE cf_regven_integra  " +
                    "(  " +
                    "cper character(4),  " +
                    "cmes character(2),  " +
                    "  ffechadoc date,  " +
                    "  ffechaven date,  " +
                    "  ccoddoc character(2) NOT NULL DEFAULT ''::bpchar,  " +
                    "  cserie character(20) NOT NULL DEFAULT ''::bpchar,  " +
                    "  cnumero character(20) NOT NULL DEFAULT ''::bpchar,  " +
                    "  ccodenti character(11) NOT NULL DEFAULT ''::bpchar,  " +
                    "  cdesenti character(100) NOT NULL DEFAULT ''::bpchar,  " +
                    "  ctipdoc character(1) NOT NULL DEFAULT ''::bpchar,  " +
                    "  ccodruc character(15) NOT NULL DEFAULT ''::bpchar,  " +
                    "  crazsoc character(150) NOT NULL DEFAULT ''::bpchar,  " +
                    "  nbase2 numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nbase1 numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nexo numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nina numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nisc numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nigv1 numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nbase3 numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  ntots numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  ntc numeric(10,6) NOT NULL DEFAULT 0,  " +
                    "  freffec date,  " +
                    "  crefdoc character(2) NOT NULL DEFAULT ''::bpchar,  " +
                    "  crefser character(10) NOT NULL DEFAULT ''::bpchar,  " +
                    "  crefnum character(13) NOT NULL DEFAULT ''::bpchar,  " +
                    "  cmreg character(1) NOT NULL DEFAULT ''::bpchar,  " +
                    "  ndolar numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  ffechaven2 date,  " +
                    "  ccond character(3) NOT NULL DEFAULT ''::bpchar,  " +
                    "  ccodcos character(9) NOT NULL DEFAULT ''::bpchar,  " +
                    "  ccodcos2 character(9) NOT NULL DEFAULT ''::bpchar,  " +
                    "  cctabase character(20) NOT NULL DEFAULT ''::bpchar,  " +
                    "  cctaotrib character(20) NOT NULL DEFAULT ''::bpchar,  " +
                    "  cctatot character(20) NOT NULL DEFAULT ''::bpchar,  " +
                    "  nresp numeric(1,0) NOT NULL DEFAULT 0,  " +
                    "  nporre numeric(5,2) NOT NULL DEFAULT 0,  " +
                    "  nimpres numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  cserre character(6) NOT NULL DEFAULT ''::bpchar,  " +
                    "  cnumre character(13) NOT NULL DEFAULT ''::bpchar,  " +
                    "  ffecre date,  " +
                    "  ccodpresu character(10) NOT NULL DEFAULT ''::bpchar,  " +
                    "  nigv numeric(5,2) NOT NULL DEFAULT 0,  " +
                    "  cglosa character varying(80) NOT NULL DEFAULT ''::character varying,  " +
                    "  ccodpago character(3) NOT NULL DEFAULT ''::bpchar,  " +
                    "  nperdenre numeric(1,0) NOT NULL DEFAULT 0,  " +
                    "  nbaseres numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  cctaperc character varying(20) NOT NULL DEFAULT ''::character varying,  " +
                    "  incomp character(5) NOT NULL DEFAULT ''::bpchar,  " +
                    "  lneg character(5) NOT NULL DEFAULT ''::bpchar,  " +
                    "  vmespd numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nnetd numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nimpd numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nbase2d numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nigv2d numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nbase3d numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nigv3d numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  ninad numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  niscd numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nexod numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  ntotd numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nntc numeric(10,6) NOT NULL DEFAULT 0,  " +
                    "  nbaseimp numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nbaseimpd numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nresini character(13) NOT NULL DEFAULT ''::bpchar,  " +
                    "  nresfin character(13) NOT NULL DEFAULT ''::bpchar,  " +
                    "  nigv2 numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  nigv3 numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  errores text NOT NULL DEFAULT ''::text,  " +
                    "  cctacobra character(20) NOT NULL DEFAULT ''::bpchar,  " +
                    "  flaganalb numeric(1,0) NOT NULL DEFAULT 0,  " +
                    "  flaganalo numeric(1,0) NOT NULL DEFAULT 0,  " +
                    "  flaganalt numeric(1,0) NOT NULL DEFAULT 0,  " +
                    "  flagccosb numeric(1,0) NOT NULL DEFAULT 0,  " +
                    "  flagccoso numeric(1,0) NOT NULL DEFAULT 0,  " +
                    "  flagccost numeric(1,0) NOT NULL DEFAULT 0,  " +
                    "  flagpresub numeric(1,0) NOT NULL DEFAULT 0,  " +
                    "  flagpresuo numeric(1,0) NOT NULL DEFAULT 0,  " +
                    "  flagpresut numeric(1,0) NOT NULL DEFAULT 0,  " +
                    "  nasiento numeric(6,0) NOT NULL DEFAULT 0,  " +
                    "  cnumfin character(20) NOT NULL DEFAULT ''::bpchar,  " +
                    "  nicbpers numeric(15,2) NOT NULL DEFAULT 0,  " +
                    "  cctaicbper character(20) NOT NULL DEFAULT ''::bpchar    " +
                    ") " +
                    "WITH ( " +
                    "  OIDS=FALSE " +
                    ");  ";


                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand commando1 = new NpgsqlCommand(tmpquery, cone01);
                    cone01.Open();
                    commando1.ExecuteNonQuery();


                }

                else
                {
                    return;

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
        public void Crear_fin_cobranzapago_asientos()
        {

            NpgsqlConnection cone01 = new NpgsqlConnection();

            try
            {


                string query0 = "SELECT distinct TABLE_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='fin_cobranzapago'";
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand commando = new NpgsqlCommand(query0, cone01);
                cone01.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    string tmpquery = "CREATE TABLE fin_cobranzapago (" +
                      " idcobranzapago numeric(20, 0), " +
                      " ccod_empresa character(3), " +
                      " cper character(4), " +
                      " cmes character(2), " +
                      " ccodori character(3), " +
                      " ccodsu character(2), " +
                      " ccodflu character(4), " +
                      " ntipocobpag integer, " +
                      " ffechacan date, " +
                      " cdoccan character(2) NOT NULL DEFAULT ''::bpchar, " +
                      " csercan character(20) NOT NULL DEFAULT ''::bpchar, " +
                      " cnumcan character(20) NOT NULL DEFAULT ''::bpchar, " +
                      " ccuecan character(20) NOT NULL DEFAULT ''::bpchar, " +
                      " cmoncan character(1) NOT NULL DEFAULT ''::bpchar, " +
                      " nimporcan numeric(15, 2) NOT NULL DEFAULT 0, " +
                      " ntipcam numeric(10, 6) NOT NULL DEFAULT 0, " +
                      " ccodpago character(3) NOT NULL DEFAULT ''::bpchar, " +
                      " ccoddoc character(2) NOT NULL DEFAULT ''::bpchar, " +
                      " cserie character(20) NOT NULL DEFAULT ''::bpchar, " +
                      " cnumero character(20) NOT NULL DEFAULT ''::bpchar, " +
                      " ffechadoc date, " +
                      " ffechaven date, " +
                      " ccodenti character(11) NOT NULL DEFAULT ''::bpchar, " +
                      " ccodruc character(15) NOT NULL DEFAULT ''::bpchar, " +
                      " crazsoc character(150) NOT NULL DEFAULT ''::bpchar, " +
                      " nimportes numeric(15, 2) NOT NULL DEFAULT 0, " +
                      " nimported numeric(15, 2) NOT NULL DEFAULT 0, " +
                      " ccodcue character(20) NOT NULL DEFAULT ''::bpchar, " +
                      " cglosa character varying(80) NOT NULL DEFAULT ''::character varying, " +
                      " ccodcos character(9) NOT NULL DEFAULT ''::bpchar, " +
                      " ccodcos2 character(9) NOT NULL DEFAULT ''::bpchar, " +
                      " nporre numeric(5, 2) NOT NULL DEFAULT 0, " +
                      " nimpperc numeric(15, 2) NOT NULL DEFAULT 0, " +
                      " nperdenre numeric(1, 0) NOT NULL DEFAULT 0, " +
                      " cserre character(6) NOT NULL DEFAULT ''::bpchar, " +
                      " cnumre character(13) NOT NULL DEFAULT ''::bpchar, " +
                      " ffecre date, " +
                      " es_con_migracion numeric(1, 0), " +
                      " obserror text, " +
                      " resultado_migracion numeric(1, 0) )";


                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand commando1 = new NpgsqlCommand(tmpquery, cone01);
                    cone01.Open();
                    commando1.ExecuteNonQuery();

                    NpgsqlCommand commando2 = new NpgsqlCommand(txt_cobra01.Text, cone01);
                    commando2.ExecuteNonQuery();

                    NpgsqlCommand commando3 = new NpgsqlCommand(txt_cobra02.Text, cone01);
                    commando3.ExecuteNonQuery();

                    NpgsqlCommand commando4 = new NpgsqlCommand(txt_cobra03.Text, cone01);
                    commando4.ExecuteNonQuery();

                    NpgsqlCommand commando5 = new NpgsqlCommand(txt_cobra04.Text, cone01);
                    commando5.ExecuteNonQuery();

                }

                else
                {
                    NpgsqlCommand commando2 = new NpgsqlCommand(txt_cobra01.Text, cone01);
                    commando2.ExecuteNonQuery();

                    NpgsqlCommand commando3 = new NpgsqlCommand(txt_cobra02.Text, cone01);
                    commando3.ExecuteNonQuery();

                    NpgsqlCommand commando4 = new NpgsqlCommand(txt_cobra03.Text, cone01);
                    commando4.ExecuteNonQuery();

                    NpgsqlCommand commando5 = new NpgsqlCommand(txt_cobra04.Text, cone01);
                    commando5.ExecuteNonQuery();

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
        public void Crear_fin_cobranzapago_integra_asientos()
        {

            NpgsqlConnection cone01 = new NpgsqlConnection();

            try
            {


                string query0 = "SELECT distinct TABLE_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='fin_cobranzapago_integra'";
                cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                NpgsqlCommand commando = new NpgsqlCommand(query0, cone01);
                cone01.Open();
                NpgsqlDataAdapter datos = new NpgsqlDataAdapter(commando);
                DataTable tablas = new DataTable();
                datos.Fill(tablas);

                if (tablas.Rows.Count == 0)
                {
                    string tmpquery = "CREATE TABLE fin_cobranzapago_integra "+
                        " (idcobranzapago numeric(20, 0), " +
                        " ffechacan date, " +
                        " cdoccan character(2) NOT NULL DEFAULT ''::bpchar, " +
                        " csercan character(20) NOT NULL DEFAULT ''::bpchar, " +
                        " cnumcan character(20) NOT NULL DEFAULT ''::bpchar, " +
                        " ccuecan character(20) NOT NULL DEFAULT ''::bpchar, " +
                        " cmoncan character(1) NOT NULL DEFAULT ''::bpchar, " +
                        " nimporcan numeric(15, 2) NOT NULL DEFAULT 0, " +
                        " ntipcam numeric(10, 6) NOT NULL DEFAULT 0, " +
                        " ccodpago character(3) NOT NULL DEFAULT ''::bpchar, " +
                        " ccoddoc character(2) NOT NULL DEFAULT ''::bpchar, " +
                        " cserie character(20) NOT NULL DEFAULT ''::bpchar, " +
                        " cnumero character(20) NOT NULL DEFAULT ''::bpchar, " +
                        " ffechadoc date, " +
                        " ffechaven date, " +
                        " ccodenti character(11) NOT NULL DEFAULT ''::bpchar, " +
                        " ccodruc character(15) NOT NULL DEFAULT ''::bpchar, " +
                        " crazsoc character(150) NOT NULL DEFAULT ''::bpchar, " +
                        " nimportes numeric(15, 2) NOT NULL DEFAULT 0, " +
                        " nimported numeric(15, 2) NOT NULL DEFAULT 0, " +
                        " ccodcue character(20) NOT NULL DEFAULT ''::bpchar, " +
                        " cglosa character varying(80) NOT NULL DEFAULT ''::character varying, " +
                        " ccodcos character(9) NOT NULL DEFAULT ''::bpchar, " +
                        " ccodcos2 character(9) NOT NULL DEFAULT ''::bpchar, " +
                        " nporre numeric(5, 2) NOT NULL DEFAULT 0, " +
                        " nimpperc numeric(15, 2) NOT NULL DEFAULT 0, " +
                        " nperdenre numeric(1, 0) NOT NULL DEFAULT 0, " +
                        " cserre character(6) NOT NULL DEFAULT ''::bpchar, " +
                        " cnumre character(13) NOT NULL DEFAULT ''::bpchar, " +
                        " ffecre date)  ";


                    cone01 = Clase.ConexionPostgreslContasis.Instancial().establecerconexion2(txtcadena.Text);
                    NpgsqlCommand commando1 = new NpgsqlCommand(tmpquery, cone01);
                    cone01.Open();
                    commando1.ExecuteNonQuery();

                    NpgsqlCommand commando2 = new NpgsqlCommand(txt_cobra01.Text, cone01);
                    commando2.ExecuteNonQuery();

                    NpgsqlCommand commando3 = new NpgsqlCommand(txt_cobra02.Text, cone01);
                    commando3.ExecuteNonQuery();

                    NpgsqlCommand commando4 = new NpgsqlCommand(txt_cobra03.Text, cone01);
                    commando4.ExecuteNonQuery();

                    NpgsqlCommand commando5 = new NpgsqlCommand(txt_cobra04.Text, cone01);
                    commando5.ExecuteNonQuery();
                }

                else
                {
                    NpgsqlCommand commando2 = new NpgsqlCommand(txt_cobra01.Text, cone01);
                    commando2.ExecuteNonQuery();

                    NpgsqlCommand commando3 = new NpgsqlCommand(txt_cobra02.Text, cone01);
                    commando3.ExecuteNonQuery();

                    NpgsqlCommand commando4 = new NpgsqlCommand(txt_cobra03.Text, cone01);
                    commando4.ExecuteNonQuery();

                    NpgsqlCommand commando5 = new NpgsqlCommand(txt_cobra04.Text, cone01);
                    commando5.ExecuteNonQuery();

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
        private void TxtCSUB1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCLREG1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCLREG2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCCONTS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCCONTD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCFEFEC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCSUB1_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCLREG1_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCSUB2_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCLREG2_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCCONTS_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCCONTD_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TxtCFEFEC_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
          /********************************************************************/
        private void Validar_cuentas(string valor,string valor2)
        {
            try
            {
                string xvalor = valor;
                string xvalor2 = valor2;
                NpgsqlConnection cone = new NpgsqlConnection();
                /** para ventas **/
                if (xvalor == "1")
                {
                    txtquery2.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI='"+ xvalor2 + "' ORDER BY CCODORI ASC";
                }
                if (xvalor == "2")
                {
                    txtquery2.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  where CCODSU='" + xvalor2 + "'  ORDER BY CCODSU ASC";
                }
                if (xvalor == "3")
                {
                    txtquery2.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN where CCODORI='" + xvalor2 + "'  ORDER BY CCODORI ASC";
                }
                if (xvalor == "4")
                {
                    txtquery2.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU WHERE CCODSU='" + xvalor2 + "'  ORDER BY CCODSU ASC";
                }
                if (xvalor == "5")
                {
                    txtquery2.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CCODCUE='" + xvalor2 + "' AND   CPER='" + txtperiodo.Text + "'  AND NANACUE=3 ORDER BY CCODCUE ASC";
                }
                if (xvalor == "6")
                {
                    txtquery2.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CCODCUE='" + xvalor2 + "' AND CPER='" + txtperiodo.Text + "'  AND NANACUE=3 ORDER BY CCODCUE ASC";
                }
                if (xvalor == "7")
                {
                    txtquery2.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where CCODFLU='" + xvalor2 + "' AND cper='" + txtperiodo.Text + "' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                }
                /** para compras **/
                if (xvalor == "8")
                {
                    txtquery2.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN WHERE CCODORI='" + xvalor2 + "'  ORDER BY CCODORI ASC";
                }
                if (xvalor == "9")
                {
                    txtquery2.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  WHERE CCODSU='" + xvalor2 + "'  ORDER BY CCODSU ASC";
                }
                if (xvalor == "10")
                {
                    txtquery2.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN WHERE CCODORI='" + xvalor2 + "'  ORDER BY CCODORI ASC";
                }
                if (xvalor == "11")
                {
                    txtquery2.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  WHERE CCODSU='" + xvalor2 + "' ORDER BY CCODSU ASC";
                }
                if (xvalor == "12")
                {
                    txtquery2.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where  CCODCUE='" + xvalor2 + "' AND CPER='" + txtperiodo.Text + "'  AND NANACUE=3 ORDER BY CCODCUE ASC";
                }
                if (xvalor == "13")
                {
                    txtquery2.Text = "SELECT CCODCUE AS COD,CDESCUE AS DESCRIPCION FROM Cf_PLAN where CCODCUE='" + xvalor2 + "' AND CPER='" + txtperiodo.Text + "'  AND NANACUE=3 ORDER BY CCODCUE ASC";
                }
                if (xvalor == "14")
                {
                    txtquery2.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where CCODFLU='" + xvalor2 + "' AND cper='" + txtperiodo.Text + "' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                }
                /** para cobranzas **/
                if (xvalor == "15")
                {
                    txtquery2.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI='" + xvalor2 + "' ORDER BY CCODORI ASC";
                }
                if (xvalor == "16")
                {
                    txtquery2.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  where CCODSU='" + xvalor2 + "'  ORDER BY CCODSU ASC";
                }
                if (xvalor == "17")
                {
                    txtquery2.Text = "Select ccodflu AS COD, cdesflu AS DESCRIPCION From cf_flujo  Where CCODFLU='" + xvalor2 + "' AND cper='" + txtperiodo.Text + "' and mformula = '' and right(ccodflu,3) <> '000' and right(ccodflu,2) <> '00'  order by ccodflu asc";
                }
                /** para pagos **/
                if (xvalor == "18")
                {
                    txtquery2.Text = "SELECT CCODORI as COD,CDESORI AS DESCRIPCION FROM CF_ORIGEN  where CCODORI='" + xvalor2 + "' ORDER BY CCODORI ASC";
                }
                if (xvalor == "19")
                {
                    txtquery2.Text = "SELECT CCODSU as COD,CDESSU AS DESCRIPCION FROM CF_ORIGENSU  where CCODSU='" + xvalor2 + "'  ORDER BY CCODSU ASC";
                }
                if (xvalor == "20")
                {
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
                        txtCSUB1.Text = "";
                        txtCSUB1.Focus();
                    }
                    if (xvalor == "2")
                    {
                        txtCLREG1.Text = "";
                        txtCLREG1.Focus();
                    }
                    if (xvalor == "3")
                    {
                        txtCSUB2.Text = "";
                        txtCSUB2.Focus();
                    }
                    if (xvalor == "4")
                    {
                        txtCLREG2.Text = "";
                        txtCLREG2.Focus();
                    }
                    if (xvalor == "5")
                    {
                        txtCCONTS.Text = "";
                        txtCCONTS.Focus();
                    }
                    if (xvalor == "6")
                    {
                        txtCCONTD.Text = "";
                        txtCCONTD.Focus();
                    }
                    if (xvalor == "7")
                    {
                        txtCFEFEC.Text = "";
                        txtCFEFEC.Focus();
                    }
                    /** para compras **/
                    if (xvalor == "8")
                    {
                        txtCSUB1_com.Text = "";
                        txtCSUB1_com.Focus();
                    }
                    if (xvalor == "9")
                    {
                        txtCLREG1_com.Text = "";
                        txtCLREG1_com.Focus();
                    }
                    if (xvalor == "10")
                    {
                        txtCSUB2_com.Text = "";
                        txtCSUB2_com.Focus();
                    }
                    if (xvalor == "11")
                    {
                        txtCLREG2_com.Text = "";
                        txtCLREG2_com.Focus();
                    }
                    if (xvalor == "12")
                    {
                        txtCCONTS_com.Text = "";
                        txtCCONTS_com.Focus();
                    }
                    if (xvalor == "13")
                    {
                        txtCCONTD_com.Text = "";
                        txtCCONTD_com.Focus();
                    }
                    if (xvalor == "14")
                    {
                        txtCFEFEC_com.Text = "";
                        txtCFEFEC_com.Focus();
                    }

                    if (xvalor == "15")
                    {
                        txtsubdiario_cobra.Text = "";
                        txtsubdiario_cobra.Focus();
                    }
                    if (xvalor == "16")
                    {
                        txtregistro_cobra.Text = "";
                        txtregistro_cobra.Focus();
                    }
                    if (xvalor == "17")
                    {
                        txtflujocobra.Text = "";
                        txtflujocobra.Focus();
                    }
                    if (xvalor == "18")
                    {
                        txtsubdiario_pago.Text = "";
                        txtsubdiario_pago.Focus();
                    }
                    if (xvalor == "19")
                    {
                        txtregistro_pago.Text = "";
                        txtregistro_pago.Focus();
                    }
                    if (xvalor == "20")
                    {
                        txtflujopago.Text = "";
                        txtflujopago.Focus();
                    }

                    cone.Close();
                }
                
            }
            catch (Exception ex1)
            {
                MessageBox.Show(""+ex1);
            }
            
        }
        private void TxtCSUB1_Validated(object sender, EventArgs e)
        {
            if (txtCSUB1.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCSUB1.Focus();
            }
        }
        private void TxtCLREG1_Validated(object sender, EventArgs e)
        {
            if (txtCLREG1.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCLREG1.Focus();
            }
        }
        private void TxtCSUB2_Validated(object sender, EventArgs e)
        {
            if (txtCSUB2.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCSUB2.Focus();
            }
        }
        private void TxtCLREG2_Validated(object sender, EventArgs e)
        {
            if (txtCLREG2.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCLREG2.Focus();
            }
        }
        private void TxtCCONTS_Validated(object sender, EventArgs e)
        {

            if (txtCCONTS.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCONTS.Focus();
            }
        }
        private void TxtCCONTD_Validated(object sender, EventArgs e)
        {
            if (txtCCONTD.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCONTD.Focus();
            }
        }
        private void TxtCFEFEC_TextChanged(object sender, EventArgs e)
        {
            if (txtCFEFEC.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCFEFEC.Focus();
            }
        }
        private void TxtCSUB1_com_Validated(object sender, EventArgs e)
        {
            if (txtCSUB1_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCSUB1_com.Focus();
            }
        }
        private void TxtCLREG1_com_Validated(object sender, EventArgs e)
        {
            if (txtCLREG1_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCLREG1_com.Focus();
            }
        }
        private void TxtCSUB2_com_Validated(object sender, EventArgs e)
        {
            
                if (txtCSUB2_com.Text == "")
            { 
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCSUB2_com.Focus();
            }

        }
        private void TxtCLREG2_com_Validated(object sender, EventArgs e)
        {
            if (txtCLREG2_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCLREG2_com.Focus();
            }
        }
        private void TxtCCONTS_com_Validated(object sender, EventArgs e)
        {
            if (txtCCONTS_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCONTS_com.Focus();
            }

        }
        private void TxtCCONTD_com_Validated(object sender, EventArgs e)
        {
            if (txtCCONTD_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCONTD_com.Focus();
            }

        }
        private void TxtCFEFEC_com_Validated(object sender, EventArgs e)
        {
            if (txtCFEFEC_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCFEFEC_com.Focus();
            }

        }
        private void Cmbanuladosventas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
            FechaInicio.Enabled = true;
        }
        private void Cmbanuladoscompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.button2.Enabled = true;
            FechaInicio.Enabled = true;
        }
        public void Limpiar()
        {
            txtCSUB1.Text = "";
            txtCLREG1.Text = "";
            txtCSUB2.Text = "";
            txtCLREG2.Text = "";
            txtCCONTS.Text = "";
            txtCCONTD.Text = "";
            txtCFEFEC.Text = "";
            cmbentidadvta.Text = "";
            cmbanuladosventas.Text = "";
            checkctaresu.Checked = false;
            checkctaimp.Checked = false;
            checkctaactivo.Checked = false;
            checkAsientovta.Checked = false;
            cmbentidadcrp.Text = "";
            txtCSUB1_com.Text = "";
            txtCLREG1_com.Text = "";
            txtCSUB2_com.Text = "";
            txtCLREG2_com.Text = "";
            txtCCONTS_com.Text = "";
            txtCCONTD_com.Text = "";
            txtCFEFEC_com.Text = "";
            cmbanuladoscompras.Text="";
            check_ctare_com.Checked = false;
            check_imp_com.Checked = false;
            check_actv_com.Checked = false;
            check_asicom_com.Checked = false;
            txtsubdiario_cobra.Text = "";
            txtsubdiario_pago.Text = "";
            txtregistro_cobra.Text = "";
            txtregistro_pago.Text = "";
            txtflujocobra.Text = "";
            txtflujopago.Text = "";
        }
        private void Cmbrucemisor_SelectedIndexChanged(object sender, EventArgs e)
        {
         xRucemisor = cmbrucemisor.Text.Trim().Substring(0,11);
            
        }
        /****************************************************************************************************************/
        private void Button4_Click(object sender, EventArgs e)
        {
            if (txtFechaInicio.Text == "")
            {
                MessageBox.Show("Favor ingrese una fecha para el inicio del proceso de Integración.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                this.Grabar_pagos();
                this.Mostrar_registros_pagos();
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {/*** PDI-148 06/12/2024**/
            if (txtFechaInicio.Text == "")
            {
                MessageBox.Show("Favor ingrese una fecha para el inicio del proceso de Integración.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                this.Grabar_cobranzas();
                this.Mostrar_registros_cobranzas();
            }
        }
        private void Txtsubdiario_cobra_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(15, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("15", txtsubdiario_cobra.Text);
            }
          
        }
        private void Txtsubdiario_cobra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void Txtregistro_cobra_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(16, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("16", txtsubdiario_cobra.Text);
            }

        }
        private void Txtregistro_cobra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Txtflujocobra_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(17, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("17", txtflujocobra.Text);
            }
        }
        private void Txtflujocobra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Txtsubdiario_cobra_Validated(object sender, EventArgs e)
        {
            if (txtsubdiario_cobra.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsubdiario_cobra.Focus();
            }
        }
        private void Txtregistro_cobra_Validated(object sender, EventArgs e)
        {
            if (txtregistro_cobra.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtregistro_cobra.Focus();
            }
        }
        private void Txtflujocobra_TextChanged(object sender, EventArgs e)
        {
            this.button3.Enabled = true;
            FechaInicio.Enabled = true;
        }
        private void Txtflujocobra_Validated(object sender, EventArgs e)
        {
            if (txtflujocobra.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtflujocobra.Focus();
            }
        }
        private void Txtsubdiario_pago_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(18, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("18", txtsubdiario_pago.Text);
            }
        }
        private void Txtregistro_pago_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(19, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("19", txtregistro_pago.Text);
            }
        }
        private void Txtflujopago_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(20, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.ShowDialog();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.Validar_cuentas("20", txtflujopago.Text);
            }
        }
        private void Txtsubdiario_pago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Txtregistro_pago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Txtflujopago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Txtsubdiario_pago_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.Validar_cuentas("18", txtsubdiario_pago.Text);
            }
        }
        private void Txtsubdiario_cobra_KeyUp(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Tab)
            {
                this.Validar_cuentas("15", txtsubdiario_cobra.Text);
                if (txtsubdiario_cobra.Text.Trim() == "")
                {
                    txtsubdiario_cobra.Focus();
                }
            }
        }
        private void Txtregistro_cobra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.Validar_cuentas("15", txtsubdiario_cobra.Text);
                if (txtsubdiario_cobra.Text == "")
                {
                    txtsubdiario_cobra.Focus();
                }
            }
        }
        private void Txtflujocobra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.Validar_cuentas("16", txtregistro_cobra.Text);
                if (txtregistro_cobra.Text == "")
                {
                    txtregistro_cobra.Focus();
                }
            }
        }
        private void Txtregistro_pago_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.Validar_cuentas("19", txtregistro_pago.Text);
                if (txtregistro_pago.Text == "")
                {
                    txtregistro_pago.Focus();
                }
            }
        }
        private void Txtflujopago_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.Validar_cuentas("20", txtflujopago.Text);
                if (txtflujopago.Text == "")
                {
                    txtflujopago.Focus();
                }
            }
        }
        private void Txtflujopago_TextChanged(object sender, EventArgs e)
        {
            FechaInicio.Enabled = true;
            this.button4.Enabled = true;
        }
        private void DataGridView_cobranza_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = e.RowIndex;
        }
        private void DataGridView_cobranza_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (posicion == 1)
            {
                return;
            }

            if (dataGridView_cobranza.Rows.Count > 0)
            {
                txtsubdiario_cobra.Text = dataGridView_cobranza.Rows[posicion].Cells["SUBDIARIO_COBRANZA"].Value.ToString();
                txtregistro_cobra.Text = dataGridView_cobranza.Rows[posicion].Cells["REGISTRO_COBRANZA"].Value.ToString();
                txtflujocobra.Text = dataGridView_cobranza.Rows[posicion].Cells["FLUJO_COBRANZA"].Value.ToString();
            }

        }
        private void DataGridView_pago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = e.RowIndex;
        }
        private void DataGridView_pago_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (posicion == 1)
            {
                return;
            }

            if (dataGridView_pago.Rows.Count > 0)
            {
                txtsubdiario_pago.Text = dataGridView_pago.Rows[posicion].Cells["SUBDIARIO_PAGO"].Value.ToString();
                txtregistro_pago.Text = dataGridView_pago.Rows[posicion].Cells["REGISTRO_PAGO"].Value.ToString();
                txtflujopago.Text = dataGridView_pago.Rows[posicion].Cells["FLUJO_PAGOS"].Value.ToString();
            }

        }
        private void Cargar_Fecha_inicio()
        {
            FechaInicio.Enabled = false;
                
            string query10 = "select ffecha_inicioproceso from configuracion where ccod_empresa='" + cmbempresas.Text.Substring(0, 3) + "' and cper='" + cmbperiodo.Text + "';";
                try
                {
                if (Properties.Settings.Default.cadenaPostPrincipal == "")
                {
                    SqlConnection cone = new SqlConnection();
                    cone = Clase.ConexionSql.Instancial().Establecerconexion();
                    SqlCommand commando = new SqlCommand(query10, cone);
                    cone.Open();
                    SqlDataAdapter data = new SqlDataAdapter(commando);
                    SqlDataReader carga = commando.ExecuteReader();
                    if (carga.Read())
                    {
                        txtFechaInicio.Text = Convert.ToString(carga["ffecha_inicioproceso"]);
                        cone.Close();
                    }
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
                    conexion.Close();
                }
                }
                catch
                {
                    MessageBox.Show("Debe de Existir un error, pase verificación de Estructura.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
        private void FechaInicio_ValueChanged(object sender, EventArgs e)
        {
            txtFechaInicio.Text = FechaInicio.Value.ToString("dd/MM/yyyy");

        }
        private void Grabar_Fecha_inicio()
        {
            /*** PDI-148 06/12/2024**/
            if (txtFechaInicio.Text == "")
            {
                MessageBox.Show("Debe de grabar la fecha de Inicio.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                
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
                            string query10 = "Update  configuracion set ffecha_inicioproceso=cast('" + FechaInicio.Value.ToString("dd/MM/yyyy") + "' as date)  where   ccod_empresa='" + cmbempresas.Text.Substring(0, 3) + "' and cper='" + cmbperiodo.Text + "';";
                            cone.Open();
                            SqlCommand commando = new SqlCommand(query10, cone);
                            commando.ExecuteNonQuery();
                            cone.Close();
                        }

                        else
                        {

                            NpgsqlConnection conexion = new NpgsqlConnection();
                            conexion.ConnectionString = Properties.Settings.Default.cadenaPostPrincipal;
                            conexion.Open();
                            string query10 = "Update  configuracion set ffecha_inicioproceso='" + FechaInicio.Value.ToString("dd/MM/yyyy") + "'  where   ccod_empresa='" + cmbempresas.Text.Substring(0, 3) + "' and cper='" + cmbperiodo.Text + "';";

                            
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
        }
        private void FechaInicio_ValueChanged_1(object sender, EventArgs e)
        {
            /*** PDI-148 06/12/2024**/
            txtFechaInicio.Text = FechaInicio.Value.ToString("dd/MM/yyyy");
        }
        private void DataGridView_venta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*** PDI-148 06/12/2024**/
            FechaInicio.Enabled = true;
        }

        
        /****************************************************************************************************************/
    }
}
