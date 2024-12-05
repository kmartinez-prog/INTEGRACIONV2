using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contasis
{
    public partial class Principal : Form
    {
        FrmEmpresas master1;
        FrmUsuarios master2;
        FrRegistrarConexion master13;
        FrmIntegradorConta master4;
        FrmInconsistencia master5;
        FrmInconsistenciasCompras master6;
        FrmAyuda master7;
        FrmRucemisor master8;
        FrRegistrarConexionDestino master9;
        FrmConfigurarServicio master10;
        FrRegistrarConexionNube master11;
        FrmVerificacionEstrcutura master12;
        FrmInconsistencias_Cobranza master15;
        FrmInconsistencias_Pago master14;
        FrmIntegradorComercial master16;
        FrmInconsistencias_comercial master17;
        FrmInconsistencia_productos_comercial master18;
        

        public static Principal instance = null;
        public Principal(string valor)
        {
            InitializeComponent();
            txtcontrol.Text = valor;
            instance = this;
        }

        private void origenDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (master13 == null)
                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.Name == "master13")
                    { }
                    else
                    {
                        master13 = null;
                    }

                }

            {
                    master13 = new FrRegistrarConexion();
                    master13.ShowDialog();
                    master13.FormClosed += new FormClosedEventHandler(cierraconexion);
                    
                }
}
            void cierraconexion(object sender, EventArgs e)
            {
                master13 = null;
            }

        private void accesoAUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (txtcontrol.Text == "1")
            {
                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.Name == "master2")
                    { }
                    else
                    {
                        master2 = null;
                    }

                }
                if (master2 == null)
                {
                    master2 = new FrmUsuarios();
                    /// master2.WindowState = FormWindowState.Normal ;
                    master2.ShowDialog();
                   //// master2.MdiParent = this;
                    master2.FormClosed += new FormClosedEventHandler(cerrarusuarios);
                    
                }
                
            }
            else
            {
                MessageBox.Show("No existe la base de datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void cerrarusuarios(object sender, EventArgs e)
        {
            master2 = null;
        }


        private void Principal_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TipModulo == "2")
            {
                integradorContableToolStripMenuItem.Enabled = false;
                ventasContableToolStripMenuItem.Enabled = false;
                comprasContableToolStripMenuItem.Enabled = false;
                cobranzasContableToolStripMenuItem.Enabled = false;
                pagosContableToolStripMenuItem.Enabled = false;

                documentosComercialToolStripMenuItem.Enabled = true;
                productosToolStripMenuItem.Enabled = true;
                integradorComercialSQLToolStripMenuItem.Enabled = true;
                
            }
            else
            {
                integradorContableToolStripMenuItem.Enabled = true;
              ///  integradorComercialSQLToolStripMenuItem.Enabled = false;

                ventasContableToolStripMenuItem.Enabled =true;
                comprasContableToolStripMenuItem.Enabled = true;
                cobranzasContableToolStripMenuItem.Enabled = true;
                pagosContableToolStripMenuItem.Enabled = true;

                documentosComercialToolStripMenuItem.Enabled = false;
                productosToolStripMenuItem.Enabled = false;



            }

            


            // this.desacactivar();///
            toolStripStatusLabel1.Text = "Fecha Actual : "+DateTime.Now.ToLongDateString();
            toolStripStatusLabel2.Text = "| Hora Actual : " + DateTime.Now.ToString("hh:mm:ss");
            toolStripStatusLabel4.Text = "| Usuario Actual : " + Properties.Settings.Default.Usuario;
            toolStripStatusLabel5.Text = "| Conexion origen :  ";
            if (string.IsNullOrEmpty(Properties.Settings.Default.cadenaPostPrincipal))
            {
            }
            else
            {
                toolStripStatusLabel5.Text = "| Conexion origen : PostgresSQL ";
            }
            if (Properties.Settings.Default.cadenaSql == "")
            {
            }
            else
            {
                toolStripStatusLabel5.Text = "| Conexion origen : SQL SERVER ";
            }
            toolStripStatusLabel6.Text = "| Version del sistema :  " + Properties.Settings.Default.version;
            


            if (Properties.Settings.Default.TipModulo == "1")
            {
                toolStripStatusLabel7.Text = "|Modulo Financiero|";

                this.Text = "Configuración del Integrador Contasis 2024 - Contable Financiero SQL 2024 - PERIODO ACTUAL "+DateTime.Now.ToString("yyyy");
            }
            if (Properties.Settings.Default.TipModulo == "2")
            {
                toolStripStatusLabel7.Text = "|Modulo Comercial|";
                this.Text = "Configuración del Integrador Contasis 2024 - Comercial SQL 2024 - PERIODO ACTUAL " + DateTime.Now.ToString("yyyy");
            }

            if (Properties.Settings.Default.TipModulo == "")
            {
                this.Text = "Configuración del Integrador Contasis " + DateTime.Now.ToString("yyyy");
                toolStripStatusLabel7.Text = "";
            }

        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "| Hora Actual : " + DateTime.Now.ToString("hh:mm:ss");
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (master7 == null)
                 {
                master7 = new FrmAyuda();
                ///master7.MdiParent = this;

                master7.ShowDialog();
                master7.FormClosed += new FormClosedEventHandler(cerrarayuda);
              ////  master7.Show();
                 }
            
        }
        private void cerrarayuda(object sender, EventArgs e)
            {
                master7 = null;
            }
        private void integradorContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TipModulo == "1")
            {
                this.integradorContableToolStripMenuItem.Enabled = true;
                if (txtcontrol.Text == "1")
                {
                    foreach (Form OpenForm in Application.OpenForms)
                    {
                        if (OpenForm.Name == "master4")
                        { }
                        else
                        {
                            master4 = null;
                        }

                    }

                    if (master4 == null)
                    {
                        master4 = new FrmIntegradorConta();
                        /// master4.MdiParent = this;
                        master4.ShowDialog();
                        master4.FormClosed += new FormClosedEventHandler(cerrarconta);
                        /////master4.Show();
                    }
                }
                else
                {
                    master4 = null;
                    MessageBox.Show("No existe información para el sistema.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.integradorContableToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Opcion no disponible.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        void cerrarconta(object sender, EventArgs e)
        {
            master4 = null;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (txtcontrol.Text == "1")
            {
                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.Name == "master1")
                    { }
                    else
                    {
                        master1 = null;
                    }

                }
                if (master1 == null)
                {
                    master1 = new FrmEmpresas();
                    ////master1.MdiParent = this;
                    master1.ShowDialog();
                   // master1 = null;
                    master1.FormClosed += new FormClosedEventHandler(cerrarempresa);
                    
                }
            }
            else
            {
                MessageBox.Show("No existe información para el sistema", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void cerrarempresa(object sender, EventArgs e)
        {
            master1 = null;
        }
        private void activar()
        { 
        }
        private void desacactivar()
        {
            if (Properties.Settings.Default.Usuario.Trim() == "ADMIN")
            {
                inconsistenciasToolStripMenuItem.Enabled = true;
                accesoAUsuariosToolStripMenuItem.Enabled = true;
                toolStripMenuItem1.Enabled = true;
                integradorContableToolStripMenuItem.Enabled = true;
              //  estructuraDeDatosToolStripMenuItem.Enabled = true;
                ayudaToolStripMenuItem.Enabled = true;


            }
            else
            {

                inconsistenciasToolStripMenuItem.Enabled = false;
                accesoAUsuariosToolStripMenuItem.Enabled = false;
                toolStripMenuItem1.Enabled = false;
                integradorContableToolStripMenuItem.Enabled = false;
                estructuraDeDatosToolStripMenuItem.Enabled = false;
                ayudaToolStripMenuItem.Enabled = false;
            }
        }
        
        private void ventasContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcontrol.Text == "1")
            {
                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.Name == "master5")
                    { }
                    else
                    {
                        master5 = null;
                    }

                }
                if (master5 == null)
                {
                    master5 = new FrmInconsistencia();
                    // master5.MdiParent = this;
                    master5.ShowDialog();
                    master5.FormClosed += new FormClosedEventHandler(cerrarventas);
                    
                }
            }
            else
            {
                MessageBox.Show("No existe información para el sistema.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        void cerrarventas(object sender, EventArgs e)
        {
            master5 = null;
        }
        private void comprasContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtcontrol.Text == "1")
            {
                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.Name == "master6")
                    { }
                    else
                    {
                        master6 = null;
                    }

                }

                if (master6 == null)
                {
                    master6 = new FrmInconsistenciasCompras();
                    ///master6.MdiParent = this;
                    master6.ShowDialog();
                    master6.FormClosed += new FormClosedEventHandler(cerrarcompras);
                    
                }
            }
            else
            {
                MessageBox.Show("No existe información para el sistema.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        void cerrarcompras(object sender, EventArgs e)
        {
            master6 = null;
        }
        public void validar()
        {
            string respuesta = "";
            Clase.Inicio ds = new Clase.Inicio();
            respuesta = ds.validarbase();
            
            if (respuesta.Equals("1"))
            {
                txtcontrol.Text = respuesta;
            }
            else
            {
                txtcontrol.Text = respuesta;
            }

        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();  
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
          //  if (txtcontrol.Text == "0")
           /// {
                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.Name == "master8")
                    { }
                    else
                    {
                        master8 = null;
                    }

                }
                if (master8 == null)
                {
                    master8 = new FrmRucemisor();
                    ////master1.MdiParent = this;
                    master8.ShowDialog();
                    // master1 = null;
                    master8.FormClosed += new FormClosedEventHandler(cerrarruc);

                }
           /// }
           // else
            ///{
             ///   MessageBox.Show("No existe la base de datos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////}


        }
        void cerrarruc(object sender, EventArgs e)
        {
            master8 = null;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (txtcontrol.Text == "1")
            {
                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.Name == "master9")
                    { }
                    else
                    {
                        master9 = null;
                    }

                }
                if (master9 == null)
                {
                    master9 = new FrRegistrarConexionDestino();
                    ////master1.MdiParent = this;
                    master9.ShowDialog();
                    // master1 = null;
                    master9.FormClosed += new FormClosedEventHandler(cerrardestino);

                }
            }
            else
            {
                MessageBox.Show("No existe información para el sistema.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        void cerrardestino(object sender, EventArgs e)
        {
            master9 = null;
        }

        private void servicioDeIntegraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.Name == "master10")
                { }
                else
                {
                    master10 = null;
                }

            }

            if (master10 == null)
            {
                master10 = new FrmConfigurarServicio();
                ///master6.MdiParent = this;
                master10.ShowDialog();
                master10.FormClosed += new FormClosedEventHandler(CerrarConfiguracionServicio);

            }
        }
        void CerrarConfiguracionServicio(object sender, EventArgs e)
        {
            master10 = null;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.Name == "master11")
                { }
                else
                {
                    master11 = null;
                }

            }

            if (master11 == null)
            {
                master11 = new FrRegistrarConexionNube();
                ///master6.MdiParent = this;
                master11.ShowDialog();
                master11.FormClosed += new FormClosedEventHandler(CerrarConfiguracionServicionube);

            }
        }
        void CerrarConfiguracionServicionube(object sender, EventArgs e)
        {
            master11 = null;
        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseas actualizar las tablas y funciones del sistema Integrador ?", "Contasis Corpo. Cambios en Estructura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                ///MessageBox.Show("En proceso de activación.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);///
                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.Name == "master12")
                    { }
                    else
                    {
                        master12 = null;
                    }
                }
                if (master12 == null)
                {
                    master12 = new FrmVerificacionEstrcutura();
                    ///master6.MdiParent = this;
                    master12.ShowDialog();
                    master12.FormClosed += new FormClosedEventHandler(Cerrarestructura);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        
         }

        private void inconsistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void estructuraDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseas actualizar las tablas y funciones del sistema Integrador ?", "Contasis Corpo. Cambios en Estructura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                ///MessageBox.Show("En proceso de activación.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);///
                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.Name == "master12")
                    { }
                    else
                    {
                        master12 = null;
                    }
                }
                if (master12 == null)
                {
                    master12 = new FrmVerificacionEstrcutura();
                    ///master6.MdiParent = this;
                    master12.ShowDialog();
                    master12.FormClosed += new FormClosedEventHandler(Cerrarestructura);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
        void Cerrarestructura(object sender, EventArgs e)
        {
            master12 = null;
        }

        private void cobranzasContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.Name == "master15")
                { }
                else
                {
                    master15 = null;
                }

            }

            if (master15 == null)
            {
                master15 = new FrmInconsistencias_Cobranza();
                ///master6.MdiParent = this;
                master15.ShowDialog();
                master15.FormClosed += new FormClosedEventHandler(cerrarcobranza);
            }

        }

        void cerrarcobranza(object sender, EventArgs e)
        {
            master15 = null;
        }

        private void pagosContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.Name == "master14")
                { }
                else
                {
                    master14 = null;
                }

            }

            if (master14 == null)
            {
                master14 = new FrmInconsistencias_Pago();
                ///master6.MdiParent = this;
                master14.ShowDialog();
                master14.FormClosed += new FormClosedEventHandler(cerrarpagos);
            }
        }
        void cerrarpagos(object sender, EventArgs e)
        {
            master14 = null;
        }

        private void integradorComercialSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TipModulo == "2")
            {
                this.integradorComercialSQLToolStripMenuItem.Enabled = true;
                if (txtcontrol.Text == "1")
                {
                    foreach (Form OpenForm in Application.OpenForms)
                    {
                        if (OpenForm.Name == "master16")
                        { }
                        else
                        {
                            master16 = null;
                        }

                    }

                    if (master16 == null)
                    {
                        master16 = new FrmIntegradorComercial();
                        /// master4.MdiParent = this;
                        master16.ShowDialog();
                        master16.FormClosed += new FormClosedEventHandler(cerrarcomercial);
                        /////master4.Show();
                    }
                }
                else
                {

                    master16 = null;
                    MessageBox.Show("No existe información para el sistema.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.integradorComercialSQLToolStripMenuItem.Enabled = false;
                }
            
        }
            else
            {
                MessageBox.Show("Opcion no disponible.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void cerrarcomercial(object sender, EventArgs e)
        {
            master16 = null;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void documentosComercialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.Name == "master17")
                { }
                else
                {
                    master17 = null;
                }

            }



            if (master17 == null)
            {
                master17 = new FrmInconsistencias_comercial();
                ///master7.MdiParent = this;

                master17.ShowDialog();
                master17.FormClosed += new FormClosedEventHandler(cerrardcoumento);
                ////  master7.Show();
            }
        }
        private void cerrardcoumento(object sender, EventArgs e)
        {
            master17 = null;
        }
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.Name == "master18")
                { }
                else
                {
                    master18 = null;
                }

            }



            if (master18 == null)
            {
                master18 = new FrmInconsistencia_productos_comercial();
                ///master7.MdiParent = this;

                master18.ShowDialog();
                master18.FormClosed += new FormClosedEventHandler(cerrarproducto);
                ////  master7.Show();
            }
        }
        private void cerrarproducto(object sender, EventArgs e)
        {
            master18 = null;
        }



    }
}

