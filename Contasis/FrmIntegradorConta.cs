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
        String xCodempresa;
        string rucemisor;
        string rucempresa;
        
        public static FrmIntegradorConta  instance = null;
        
        public FrmIntegradorConta()
        {
            InitializeComponent();
            instance = this;
        }
        int posicion;
        string combo;

        private void ruc()
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
                    command.CommandText = "select ltrim(ccodrucemisor)+'-'+ltrim(cdesrucemisor) as emisor  from cg_empemisor where flgactivo='1'";
                    var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
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
                    command.CommandText = "select ltrim(ccodrucemisor)||'-'||ltrim(cdesrucemisor)::character(60) as emisor  from cg_empemisor where flgactivo='1'";
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
            catch (Exception ex)
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
                    command.CommandText = "SELECT CCOD_EMPRESA+'-'+NOMEMPRESA AS EMPRESA FROM CG_EMPRESA";
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
                    command.CommandText = "SELECT ltrim(CCOD_EMPRESA)||'-'||ltrim(NOMEMPRESA)::character(50) AS EMPRESA FROM CG_EMPRESA";
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
                        String NewBase = dataset.Tables[0].Rows[0][0].ToString();
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
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe Informacion de  empresa, favor en registrar una empresa.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }



        }
        private void FrmIntegradorConta_Load(object sender, EventArgs e)
        {
            txtcadena.Text = Properties.Settings.Default.cadenaPost;
            ////// MessageBox.Show("" + Properties.Settings.Default.cadenaPost);

            this.cmbempresas.Focus();
       ////     this.ruc();
            this.empresas();
            
            
        }
        private void cmbempresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtcadena.Text = Properties.Settings.Default.cadenaPost;
            xCodempresa = "contasis_"+cmbempresas.Text.Substring(0, 3);
            txtcadena.Text = txtcadena.Text.Replace("contasis", xCodempresa);
            this.cargar();
            this.cargarentidad();
            this.anulados();
            Tablero.Enabled = false;
            this.limpiar();
            
        }
        private void grabar_ventas()
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

                    this.crear_ventas_recepcion();
                    this.crear_ventas_asientos();

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
                    respuesta = ds.Insertar(obj);
                    if (respuesta.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de ventas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de ventas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /*this.limpiarcasilla();*/
                        }
                        else
                        {
                            //MessageBox.Show("No se puedo grabar en configuracion", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    /* FrmUsuarios.instance.grilla1();*/

                }
                catch (Exception ex)
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

                    this.crear_ventas_recepcion();
                    this.crear_ventas_asientos();

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
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de ventas", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /*this.limpiarcasilla();*/
                        }
                        else
                        {
                            //MessageBox.Show("No se puedo grabar en configuracion", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    /* FrmUsuarios.instance.grilla1();*/

                }
                catch (Exception ex)
                {
                    MessageBox.Show("revise, todos los campos debe de ser llenados correctamente.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }



      }
        private void grabar_compras()
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
                    this.crear_compras_recepcion();
                    this.crear_compras_asientos();
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
                    respuesta = ds.Insertar(obj);
                    if (respuesta.Equals("Grabado"))
                    {
                        MessageBox.Show("Registro grabado en configuracion para cuentas de compras.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de compras.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /*this.limpiarcasilla();*/
                        }
                        else
                        {
                            MessageBox.Show("No se puedo grabar en configuracion.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    /* FrmUsuarios.instance.grilla1();*/

                }
                catch (Exception ex)
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
                    this.crear_compras_recepcion();
                    this.crear_compras_asientos();
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
                        /*this.limpiarcasilla();*/
                    }
                    else
                    {
                        if (respuesta.Equals("Actualizado"))
                        {
                            MessageBox.Show("Registro actualizado en configuracion para cuentas de compras.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            /*this.limpiarcasilla();*/
                        }
                        else
                        {
                            MessageBox.Show("No se puedo grabar en configuracion.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    /* FrmUsuarios.instance.grilla1();*/

                }
                catch (Exception ex)
                {
                    MessageBox.Show("revise, todos los campos debe de ser llenados correctamente.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }



        }
        private void carga2()
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
                    dataGridView1.Rows.Clear();
                    grilla.Read();

                    txtrazon.Text = grilla[0].ToString().Replace("'"," ");
                    txtruc.Text = grilla[1].ToString();
                this.seleccion();

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
                MessageBox.Show("Error no Existe empresa "+ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
                Tablero.Enabled = false;
            }

        }
        private void cargarentidad()
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text02 = "SELECT CONCAT(LTRIM(CCODTIPENT),'-',LTRIM(CDESTIPENT)) ::CHARACTER(80)AS ENTIDAD FROM cg_tipentidad";
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
            catch (Exception ex)
            {
                MessageBox.Show("Error no Existe entidades " + ex, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
            }

        }
        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        public  void cmbperiodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtperiodo.Text = cmbperiodo.Text;
            this.carga3();
            
            
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
        private void txtCSUB1_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(1, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }

            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("1", txtCSUB1.Text);
            }



        }
        private void txtCLREG1_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(2, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("2", txtCLREG1.Text);
            }


        }
        private void txtCSUB2_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(3, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("3", txtCSUB2.Text);
            }


        }
        private void txtCLREG2_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(4, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("4", txtCLREG2.Text);
            }

        }
        private void txtCCONTS_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(5, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("5", txtCCONTS.Text);
            }

        }
        private void txtCCONTD_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(6, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("6", txtCCONTD.Text);
            }


        }
        private void txtCFEFEC_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(7, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("7", txtCFEFEC.Text);
            }
        }
        public  void txtperiodo_TextChanged(object sender, EventArgs e)
        {
            txtperiodo.Text = cmbperiodo.Text;
        }
        private void txtCSUB1_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(8, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("8", txtCSUB1_com.Text);
            }
        }
        private void txtCLREG1_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(9, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("9", txtCLREG1_com.Text);
            }
        }
        private void txtCSUB2_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(10, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("10", txtCSUB2_com.Text);
            }
        }
        private void txtCLREG2_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(11, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("11", txtCLREG2_com.Text);
            }
        }
        private void txtCCONTS_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(12, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("12", txtCCONTS_com.Text);
            }
        }
        private void txtCCONTD_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(13, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("13", txtCCONTD_com.Text);
            }
        }
        private void txtCFEFEC_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'L')

            {
                FrmBuscarCuenta frmcuenta = new FrmBuscarCuenta(14, txtcadena.Text, cmbperiodo.Text);
                frmcuenta.Show();
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.validar_cuentas("14", txtCFEFEC_com.Text);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.grabar_ventas();
            this.Mostrar_registros_ventas();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.grabar_compras();
            this.Mostrar_registros_compras();
        }

        public void Mostrar_registros_ventas()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {

                    Clase.Cuentas regis = new Clase.Cuentas();
                    string xEmpresa = cmbempresas.Text.Substring(0, 3);
                    string xperiodo = cmbperiodo.Text;
                    dataGridView_venta.DataSource = regis.Cargar_ventas(xEmpresa, xperiodo);

                    dataGridView_venta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_venta.ReadOnly = true;

                    if (dataGridView_venta.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_venta.CurrentCell = this.dataGridView_venta.Rows[0].Cells[1];
                        this.dataGridView_venta.Refresh();
                    }
                    this.dataGridView_venta.Refresh();
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
                    dataGridView_venta.DataSource = regis.Cargar_ventas_postgres(xEmpresa, xperiodo);

                    dataGridView_venta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_venta.ReadOnly = true;

                    if (dataGridView_venta.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_venta.CurrentCell = this.dataGridView_venta.Rows[0].Cells[1];
                        this.dataGridView_venta.Refresh();
                    }
                    this.dataGridView_venta.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }
        public void Mostrar_registros_compras()
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {

                try
                {
                    Clase.Cuentas regis = new Clase.Cuentas();

                    string xEmpresa = cmbempresas.Text.Substring(0, 3);
                    string xperiodo = cmbperiodo.Text;

                    dataGridView_compra.DataSource = regis.Cargar_compras(xEmpresa, xperiodo);

                    dataGridView_compra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_compra.ReadOnly = true;

                    if (dataGridView_compra.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_compra.CurrentCell = this.dataGridView_compra.Rows[0].Cells[1];
                        this.dataGridView_compra.Refresh();
                    }
                    this.dataGridView_compra.Refresh();
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

                    dataGridView_compra.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView_compra.ReadOnly = true;

                    if (dataGridView_compra.Rows.Count - 1 > 0)
                    {
                        this.dataGridView_compra.CurrentCell = this.dataGridView_compra.Rows[0].Cells[1];
                        this.dataGridView_compra.Refresh();
                    }
                    this.dataGridView_compra.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }


        }

        public void seleccion()
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
                     " AND ncierre10> 0 AND ncierre11> 0 AND ncierre12> 0 then 'CERRADO' ELSE 'ABIERTO' END From cg_emppro where cper = '" + txtperiodo.Text.Trim() + "'";

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
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la consulta de periodos en contasis.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

                /**********************************************************/

                Tablero.Enabled = true;

                DataTable Tabla = new DataTable();
                SqlConnection cone = new SqlConnection();

                try
                {
                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {

                        string query0 = "SELECT * FROM CONFIGURACION WHERE CPER='" + txtperiodo.Text + "' AND CCOD_EMPRESA='" + cmbempresas.Text.Substring(0, 3) + "'";
                        cone = Clase.ConexionSql.Instancial().establecerconexion();
                        SqlCommand commando = new SqlCommand(query0, cone);
                        DataTable dt = new DataTable();
                        cone.Open();
                        SqlDataAdapter data = new SqlDataAdapter(commando);
                        data.Fill(dt);


                        if (dt.Rows.Count > 0)
                        {
                            this.Mostrar_registros_ventas();
                            this.Mostrar_registros_compras();
                        }

                        else
                        {
                            this.carga2();
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
                        }

                        else
                        {
                            this.carga2();
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
        private void dataGridView_venta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = e.RowIndex;
        }
        private void dataGridView_venta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (posicion == 1)
            {
                return;
            }

            if (dataGridView_venta.Rows.Count > 0)
            {

                txtCSUB1.Text = dataGridView_venta.Rows[posicion].Cells["csub1_vta"].Value.ToString();
                txtCLREG1.Text = dataGridView_venta.Rows[posicion].Cells["clreg1_vta"].Value.ToString();
                txtCSUB2.Text = dataGridView_venta.Rows[posicion].Cells["csub2_vta"].Value.ToString();
                txtCLREG2.Text = dataGridView_venta.Rows[posicion].Cells["clreg2_vta"].Value.ToString();
                txtCCONTS.Text = dataGridView_venta.Rows[posicion].Cells["cconts_vta"].Value.ToString();
                txtCCONTD.Text = dataGridView_venta.Rows[posicion].Cells["ccontd_vta"].Value.ToString();
                txtCFEFEC.Text = dataGridView_venta.Rows[posicion].Cells["cfefec_vta"].Value.ToString();
                
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
                this.cargarentidad2(dataGridView_venta.Rows[posicion].Cells["ENTIDAD_VENTA"].Value.ToString());
                cmbentidadvta.Text = combo;

                this.anulados2(dataGridView_venta.Rows[posicion].Cells["ENT_ANULADO"].Value.ToString());
                cmbanuladosventas.Text = combo;

            }
        }
        private void cargarentidad2(string valor)
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text02 = "SELECT CONCAT(LTRIM(CCODTIPENT),'-',LTRIM(CDESTIPENT)) ::CHARACTER(80)AS ENTIDAD FROM cg_tipentidad WHERE CCODTIPENT='"+valor+"'";
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
        private void anulados()
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text02 = "select concat(CCODRUC,'-',LTRIM(CRAZSOC))  ::char(60) as CODIGO  from cg_entitrib where NUTIANU=1";
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

            catch (Exception ex)
            {
                MessageBox.Show("Error no existen en Entidades anulados ","Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbperiodo.Items.Clear();
            }

        }
        private void anulados2(string valor)
        {
            try
            {
                NpgsqlConnection cone1 = new NpgsqlConnection();
                string text02 = "select concat(CCODRUC,'-',LTRIM(CRAZSOC))  ::char(60) as CODIGO  from cg_entitrib where NUTIANU = 1 and CCODRUC = '" + valor + "'";
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
        private void dataGridView_compra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = e.RowIndex;
        }
        private void dataGridView_compra_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
                this.cargarentidad2(dataGridView_compra.Rows[posicion].Cells["ENTIDAD_COMPRA"].Value.ToString());
                cmbentidadcrp.Text = combo;

                this.anulados2(dataGridView_venta.Rows[posicion].Cells["ENT_ANULADO"].Value.ToString());
                cmbanuladoscompras.Text = combo;

            }
        }
        public void crear_compras_anulaciones()
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
        public void crear_compras_recepcion()
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
        public void crear_ventas_recepcion()
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
                    "ccodenti nchar(11) NULL,cdesenti nchar(100) NULL,ctipodoc nchar(1) NULL,ccodruc nchar(15) NULL,crazsoc nchar(100) NULL," +
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
        public void crear_compras_asientos()
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
        public void crear_ventas_asientos()
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
        private void txtCSUB1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCLREG1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCLREG2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCCONTS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCCONTD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCFEFEC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCSUB1_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCLREG1_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCSUB2_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCLREG2_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCCONTS_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCCONTD_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtCFEFEC_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
          /********************************************************************/
        private void validar_cuentas(string valor,string valor2)
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
                    cone.Close();
                }
                
            }
            catch (Exception ex1)
            {
                MessageBox.Show(""+ex1);
            }
            
        }
        private void txtCSUB1_Validated(object sender, EventArgs e)
        {
            if (txtCSUB1.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCSUB1.Focus();
            }
        }
        private void txtCLREG1_Validated(object sender, EventArgs e)
        {
            if (txtCLREG1.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCLREG1.Focus();
            }
        }
        private void txtCSUB2_Validated(object sender, EventArgs e)
        {
            if (txtCSUB2.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCSUB2.Focus();
            }
        }
        private void txtCLREG2_Validated(object sender, EventArgs e)
        {
            if (txtCLREG2.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCLREG2.Focus();
            }
        }
        private void txtCCONTS_Validated(object sender, EventArgs e)
        {

            if (txtCCONTS.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCONTS.Focus();
            }
        }
        private void txtCCONTD_Validated(object sender, EventArgs e)
        {
            if (txtCCONTD.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCONTD.Focus();
            }
        }
        private void txtCFEFEC_TextChanged(object sender, EventArgs e)
        {
            if (txtCFEFEC.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCFEFEC.Focus();
            }
        }
        private void txtCSUB1_com_Validated(object sender, EventArgs e)
        {
            if (txtCSUB1_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCSUB1_com.Focus();
            }
        }
        private void txtCLREG1_com_Validated(object sender, EventArgs e)
        {
            if (txtCLREG1_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCLREG1_com.Focus();
            }
        }
        private void txtCSUB2_com_Validated(object sender, EventArgs e)
        {
            
                if (txtCSUB2_com.Text == "")
            { 
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCSUB2_com.Focus();
            }

        }
        private void txtCLREG2_com_Validated(object sender, EventArgs e)
        {
            if (txtCLREG2_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCLREG2_com.Focus();
            }
        }
        private void txtCCONTS_com_Validated(object sender, EventArgs e)
        {
            if (txtCCONTS_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCONTS_com.Focus();
            }

        }
        private void txtCCONTD_com_Validated(object sender, EventArgs e)
        {
            if (txtCCONTD_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCCONTD_com.Focus();
            }

        }
        private void txtCFEFEC_com_Validated(object sender, EventArgs e)
        {
            if (txtCFEFEC_com.Text == "")
            {
                MessageBox.Show("Debe de ingresar la cuentra correcta.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCFEFEC_com.Focus();
            }

        }
        private void cmbanuladosventas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }
        private void cmbanuladoscompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
        }
        public void limpiar()
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
            
        }
        private void cmbrucemisor_SelectedIndexChanged(object sender, EventArgs e)
        {
         ///////   rucemisor = cmbrucemisor.Text.Trim().Substring(0,11);
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
