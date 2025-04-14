using Contasis.Clase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Contasis
{
    public partial class FrmRuceditor : Form
    {
        int tipo;
     public FrmRuceditor(int ntipo, string ruc, string nombre, string frase,int venta,int compras,int cobranza,int pago, int productos, int comcompras, int conventas,int fondom, int ncobranzacomercial)
        {
            InitializeComponent();
            tipo = ntipo;

            if (ntipo == 1)
            {
                txtruc.Visible = true;
                lblcodigo.Visible = true;
                
                
            }
            else
            {
                txtruc.Visible = true;
                lblcodigo.Visible = true;
                txtruc.Text = ruc.Trim() ;
                txtempresa.Text = nombre.Trim();

                if (frase == "1")
                {
                    checkBoxestado.Checked = true;
                }
                else
                {
                    checkBoxestado.Checked =false;
                }
                /******/
                if (Properties.Settings.Default.TipModulo == "1")
                {
                    if (venta == 1)
                    {
                        checkventa.Checked = true;
                    }
                    else
                    {
                        checkventa.Checked = false;
                    }

                    if (compras == 1)
                    {
                        checkCompras.Checked = true;
                    }
                    else
                    {
                        checkCompras.Checked = false;
                    }

                    if (cobranza == 1)
                    {
                        checkCobranza.Checked = true;
                    }
                    else
                    {
                        checkCobranza.Checked = false;
                    }

                    if (pago == 1)
                    {
                        checkPagos.Checked = true;
                    }
                    else
                    {
                        checkPagos.Checked = false;
                    }

                    if (fondom == 1)
                    {
                        checkBoxFondom.Checked = true;
                    }
                    else
                    {
                        checkBoxFondom.Checked = false;
                    }
                    if (ncobranzacomercial == 1)
                    {
                        check_cobranzacomercial.Checked = true;
                    }
                    else
                    {
                        check_cobranzacomercial.Checked = false;
                    }


                }


                if (Properties.Settings.Default.TipModulo == "2")
                {
                    if (productos == 1)
                    {
                        checkPRODUCTO.Checked = true;
                    }
                    else
                    {
                        checkPRODUCTO.Checked = false;
                    }

                    if (comcompras == 1)
                    {
                        checkcomprascom.Checked = true;
                    }
                    else
                    {
                        checkcomprascom.Checked = false;
                    }

                    if (conventas == 1)
                    {
                        checkventascom.Checked = true;
                    }
                    else
                    {
                        checkventascom.Checked = false;
                    }
                    if (ncobranzacomercial == 1)
                    {
                        check_cobranzacomercial.Checked = true;
                    }
                    else
                    {
                        check_cobranzacomercial.Checked = false;
                    }


                }

                /*****/
            }
        }

        private void FrmRuceditor_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            {
                this.checkPRODUCTO.Visible = false;
                this.checkcomprascom.Visible = false;
                this.checkventascom.Visible = false;
                Limpiarcasilla();
            }
            if (Properties.Settings.Default.TipModulo == "1")
            {
                this.label1.Visible = true;
                this.checkventa.Visible = true;
                this.checkCobranza.Visible = true;
                this.checkCompras.Visible = true;
                this.checkPagos.Visible = true;
                this.checkPRODUCTO.Visible = false;
                this.checkcomprascom.Visible = false;
                this.checkventascom.Visible = false;
                this.check_cobranzacomercial.Visible = false;
            }

            if (Properties.Settings.Default.TipModulo == "2")
            {
                this.label1.Visible = false;
                this.checkventa.Visible = false;
                this.checkCobranza.Visible = false;
                this.checkCompras.Visible = false;
                this.checkPagos.Visible = false;
                this.checkBoxFondom.Visible = false;
                this.checkPRODUCTO.Visible = true;
                this.checkcomprascom.Visible = true;
                this.checkventascom.Visible = true;
                this.check_cobranzacomercial.Visible = true;
            }
          
            txtempresa.CharacterCasing = CharacterCasing.Upper;
            this.txtruc.Focus();
        }
        private void Btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void Limpiarcasilla()
        {
            this.txtruc.Clear();
            this.txtempresa.Clear();
            this.checkBoxestado.Checked =false;
            txtruc.Focus(); 


        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if (txtruc.MaxLength < 11)
            {
                MessageBox.Show("Debe de ingresar un ruc de 11 digitos.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtruc.Text = "";
                txtruc.Focus();
            }
            if (txtruc.Text.Substring(0, 2) == "10")
            { }
            else
            {
                if (txtruc.Text.Substring(0, 2) == "20")
                { }
                else
                {
                    MessageBox.Show("Ruc no valido, debe de comenzar con 20 ó 10.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtruc.Text = "";
                    txtruc.Focus();
                }
            }
            if (tipo == 1)
            {
                try
                {
                    if (txtruc.Text == "")
                    {
                        MessageBox.Show("ruc no puede estar vacio.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtruc.Focus();
                        return;
                    }

                    if (txtempresa.Text == "")
                    {
                        MessageBox.Show("empresa no puede estar vacio.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtempresa.Focus();
                        return;
                    }
                  
                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {
                        string respuesta = "";

                        Clase.rucpropiedades obj = new rucpropiedades();

                        obj.ruc = txtruc.Text.Trim();
                        obj.empresa = txtempresa.Text.Trim();

                        if (checkBoxestado.Checked == true)
                        {
                            obj.estado = "1";
                        }
                        else
                        {
                            obj.estado = "0";
                        }
                        /*********/

                        if (checkventa.Checked == true)
                        {
                            obj.checkventas = 1;
                        }
                        else
                        {
                            obj.checkventas = 0;
                        }

                        if (checkCompras.Checked == true)
                        {
                            obj.checkcompras = 1;
                        }
                        else
                        {
                            obj.checkcompras = 0;
                        }

                        if (checkCobranza.Checked == true)
                        {
                            obj.checkcobranzas = 1;
                        }
                        else
                        {
                            obj.checkcobranzas = 0;
                        }

                        if (checkPagos.Checked == true)
                        {
                            obj.checkpagos = 1;
                        }
                        else
                        {
                            obj.checkpagos = 0;
                        }

                        if (checkBoxFondom.Checked == true)
                        {
                            obj.nfondoM  = 1;
                        }
                        else
                        {
                            obj.nfondoM = 0;
                        }
                        if (check_cobranzacomercial.Checked == true)
                        {
                            obj.check_cobranzacomercial = 1;
                            
                        }
                        else
                        {
                            obj.check_cobranzacomercial = 0;
                        }





                        if (Properties.Settings.Default.TipModulo == "2")
                        {
                            if (checkPRODUCTO.Checked == true)
                            {
                                obj.ncomproductoflg = 1;
                            }
                            else
                            {
                                obj.ncomproductoflg = 0;
                            }

                            if (checkcomprascom.Checked == true)
                            {
                                obj.ncomcompraflg = 1;
                            }
                            else
                            {
                                obj.ncomcompraflg = 0;
                            }

                            if (checkventascom.Checked == true)
                            {
                                obj.ncomventaflg = 1;
                            }
                            else
                            {
                                obj.ncomventaflg = 0;
                            }

                            if (check_cobranzacomercial.Checked == true)
                            {
                                obj.check_cobranzacomercial = 1;
                            }
                            else
                            {
                                obj.check_cobranzacomercial = 0;
                            }

                            



                        }



                            /*********/
                            Clase.ruc ds = new ruc();
                        respuesta = ds.Insertar(obj);
                        if (respuesta.Equals("Grabado"))
                        {
                            MessageBox.Show("Registro grabado en tabla ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Limpiarcasilla();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("No se puedo regitrar este ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        FrmRucemisor.instance.Grilla1();
                    }
                    else
                    {
                        string respuesta = "";

                        Clase.rucpropiedades obj = new rucpropiedades();

                        obj.ruc = txtruc.Text.Trim();
                        obj.empresa = txtempresa.Text.Trim();
                        if (checkBoxestado.Checked == true)
                        {
                            obj.estado = "1";
                        }
                        else
                        {
                            obj.estado = "0";
                        }
                        if (checkventa.Checked == true)
                        {
                            obj.checkventas = 1;
                        }
                        else
                        {
                            obj.checkventas = 0;
                        }

                        if (checkCompras.Checked == true)
                        {
                            obj.checkcompras = 1;
                        }
                        else
                        {
                            obj.checkcompras = 0;
                        }

                        if (checkCobranza.Checked == true)
                        {
                            obj.checkcobranzas = 1;
                        }
                        else
                        {
                            obj.checkcobranzas = 0;
                        }

                        if (checkPagos.Checked == true)
                        {
                            obj.checkpagos = 1;
                        }
                        else
                        {
                            obj.checkpagos = 0;
                        }


                        if (checkBoxFondom.Checked == true)
                        {
                            obj.nfondoM = 1;
                        }
                        else
                        {
                            obj.nfondoM = 0;
                        }




                        if (Properties.Settings.Default.TipModulo == "2")
                        {
                            if (checkPRODUCTO.Checked == true)
                            {
                                obj.ncomproductoflg = 1;
                            }
                            else
                            {
                                obj.ncomproductoflg = 0;
                            }

                            if (checkcomprascom.Checked == true)
                            {
                                obj.ncomcompraflg = 1;
                            }
                            else
                            {
                                obj.ncomcompraflg = 0;
                            }

                            if (checkventascom.Checked == true)
                            {
                                obj.ncomventaflg = 1;
                            }
                            else
                            {
                                obj.ncomventaflg = 0;
                            }

                            if (check_cobranzacomercial.Checked == true)
                            {
                                obj.check_cobranzacomercial = 1;
                            }
                            else
                            {
                                obj.check_cobranzacomercial = 0;
                            }


                        }

                        ruc_postgres ds = new ruc_postgres();
                        respuesta = ds.Insertar(obj);
                        if (respuesta.Equals("Grabado"))
                        {
                            MessageBox.Show("Registro grabado en tabla ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Limpiarcasilla();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se puedo regitrar este ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        FrmRucemisor.instance.Grilla1();

                        this.Hide();
                        this.Close();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (tipo == 2)
            {
                try
                {
                    string respuesta = "";
                    Clase.rucpropiedades obj = new rucpropiedades();
                    
                    obj.ruc = txtruc.Text.Trim();
                    obj.empresa = txtempresa.Text.Trim();
                    if (checkBoxestado.Checked == true)
                    {
                        obj.estado = "1";
                    }
                    else
                    {
                        obj.estado = "0";
                    }
                    if (checkventa.Checked == true)
                    {
                        obj.checkventas = 1;
                    }
                    else
                    {
                        obj.checkventas = 0;
                    }

                    if (checkCompras.Checked == true)
                    {
                        obj.checkcompras = 1;
                    }
                    else
                    {
                        obj.checkcompras = 0;
                    }

                    if (checkCobranza.Checked == true)
                    {
                        obj.checkcobranzas = 1;
                    }
                    else
                    {
                        obj.checkcobranzas = 0;
                    }

                    if (checkPagos.Checked == true)
                    {
                        obj.checkpagos = 1;
                    }
                    else
                    {
                        obj.checkpagos = 0;
                    }


                    if (checkBoxFondom.Checked == true)
                    {
                        obj.nfondoM = 1;
                    }
                    else
                    {
                        obj.nfondoM = 0;
                    }

                    if (Properties.Settings.Default.TipModulo == "2")
                    {
                        if (checkPRODUCTO.Checked == true)
                        {
                            obj.ncomproductoflg = 1;
                        }
                        else
                        {
                            obj.ncomproductoflg = 0;
                        }

                        if (checkcomprascom.Checked == true)
                        {
                            obj.ncomcompraflg = 1;
                        }
                        else
                        {
                            obj.ncomcompraflg = 0;
                        }

                        if (checkventascom.Checked == true)
                        {
                            obj.ncomventaflg = 1;
                        }
                        else
                        {
                            obj.ncomventaflg = 0;
                        }

                        if (checkBoxFondom.Checked == true)
                        {
                            obj.nfondoM = 1;
                        }
                        else
                        {
                            obj.nfondoM = 0;
                        }
                        if (check_cobranzacomercial.Checked == true)
                        {
                            obj.check_cobranzacomercial = 1;
                        }
                        else
                        {
                            obj.check_cobranzacomercial = 0;
                        }


                    }





                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {
                        Clase.ruc ds = new ruc();
                        respuesta = ds.Actualizar(obj);
                    }
                    else
                    {
                        ruc_postgres ds = new ruc_postgres();
                        respuesta = ds.Actualizar(obj);
                    }

                    if (respuesta.Equals("Actualizado"))
                    {
                        MessageBox.Show("Registro ha sido actualizado en tabla ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Limpiarcasilla();

                        this.Hide();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("No se puedo actualizar este ruc.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    FrmRucemisor.instance.Grilla1();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


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
        private void Txtruc_KeyPress(object sender, KeyPressEventArgs e)
        {
              if  (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                e.Handled = true;
            }
        }
        private void FrmRuceditor_Shown(object sender, EventArgs e)
        {
            txtruc.Focus(); 
        }

        private void Txtruc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtempresa.Focus();
            }
        }

        private void CheckBoxestado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Properties.Settings.Default.TipModulo == "2")
                {
                    BtnActualizar.Focus();
                }
                else
                {
                    checkventa.Focus();
                }
            }
        }

        private void Txtempresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkBoxestado.Focus();
            }
        }

        private void Txtruc_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Txtempresa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
