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
        

        public FrmRuceditor(int ntipo, string ruc, string nombre, string frase,int venta,int compras,int cobranza,int pago)
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
                txtruc.Text = ruc;
                txtempresa.Text = nombre;

                if (frase == "1")
                {
                    checkBoxestado.Checked = true;
                }
                else
                {
                    checkBoxestado.Checked =false;
                }
                /******/
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

                /*****/
            }
        }

        private void FrmRuceditor_Load(object sender, EventArgs e)
        {
            txtruc.Focus();

            if (tipo == 1)
            {
                limpiarcasilla();
            }

            txtempresa.CharacterCasing = CharacterCasing.Upper;
            txtruc.Focus();
        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void limpiarcasilla()
        {
            txtruc.Clear();
            txtempresa.Clear();
            checkBoxestado.Checked =false;
            
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


                        /*********/
                        Clase.ruc ds = new ruc();
                        respuesta = ds.Insertar(obj);
                        if (respuesta.Equals("Grabado"))
                        {
                            MessageBox.Show("Registro grabado en tabla ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.limpiarcasilla();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("No se puedo regitrar este ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        FrmRucemisor.instance.grilla1();
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

                        ruc_postgres ds = new ruc_postgres();
                        respuesta = ds.Insertar(obj);
                        if (respuesta.Equals("Grabado"))
                        {
                            MessageBox.Show("Registro grabado en tabla ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.limpiarcasilla();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se puedo regitrar este ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        FrmRucemisor.instance.grilla1();

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
                        this.limpiarcasilla();

                        this.Hide();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("No se puedo actualizar este ruc.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    FrmRucemisor.instance.grilla1();

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
        private void txtruc_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if  (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                e.Handled = true;
            }
            
        }
    }
}
