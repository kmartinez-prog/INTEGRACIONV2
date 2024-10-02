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
    public partial class FrmUsuedit : Form
    {

        int tipo;
        int tcontrol;

        public FrmUsuedit(int ntipo,string codigo,string nombre,string frase)
        {
            InitializeComponent();
            tipo = ntipo;
                
            if (ntipo == 1)
            {
                txtcodigo.Visible = false;
                lblcodigo.Visible = false;
                btnverclave.Visible = false;
            }
            else 
            {
                txtcodigo.Visible = true;
                lblcodigo.Visible = true;
                txtcodigo.Text = codigo;
                txtusuario.Text = nombre;
                txtpassword.Text = frase;
                btnverclave.Visible = true;
                txtpassword.Enabled = false;

            }

        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void FrmUsuedit_Load(object sender, EventArgs e)
        {
            if (tipo == 1)
            {
                limpiarcasilla();
                btnverclave.Visible = false;

            }

            txtusuario.CharacterCasing = CharacterCasing.Upper;
         }
        private void limpiarcasilla()
        {
            txtcodigo.Clear();
            txtusuario.Clear();
            txtpassword.Clear();
            txtusuario.Focus(); 
        }
        private void BtnActualizar_Click(object sender, EventArgs e)
        {

            if (tipo == 1)
            {
                try
                {

                    if (txtusuario.Text == "")
                    {
                        MessageBox.Show("Usuario no puede estar vacio.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtusuario.Focus();
                        return; 
                    }
                    if (txtpassword.Text == "")
                    {
                        MessageBox.Show("password no puede estar vacio.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtpassword.Focus();
                        return;
                    }


                    string respuesta = "";

                    Clase.usuarioPropiedad obj = new usuarioPropiedad();
                    Clase.esconder ocultar = new esconder();
                    obj.codigo = "";
                    obj.nombre = txtusuario.Text;
                    obj.password = ocultar.Ocultar(txtpassword.Text);


                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {
                        Clase.usuario ds = new usuario();
                        respuesta = ds.Insertar(obj);
                        if (respuesta.Equals("Grabado"))
                        {
                            MessageBox.Show("Registro grabado en tabla Usuario", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.limpiarcasilla();

                        }
                        else
                        {
                            MessageBox.Show("No se puedo regitrar este usuario", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        FrmUsuarios.instance.grilla1();
                    }
                    else
                    {
                        usuario_postgres ds = new usuario_postgres();
                        respuesta = ds.Insertar(obj);
                        if (respuesta.Equals("Grabado"))
                        {
                            MessageBox.Show("Registro grabado en tabla Usuario", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.limpiarcasilla();

                        }
                        else
                        {
                            MessageBox.Show("No se puedo regitrar este usuario", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        FrmUsuarios.instance.grilla1();
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
                    Clase.usuarioPropiedad obj = new usuarioPropiedad();
                    Clase.esconder ocultar = new esconder();
                    obj.codigo = txtcodigo.Text;
                    obj.nombre = txtusuario.Text;
                    if (tcontrol == 1)
                    {
                        obj.password = ocultar.Ocultar(txtpassword.Text);
                    }
                    else
                    {
                        obj.password = txtpassword.Text;
                    }
                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {
                        Clase.usuario ds = new usuario();
                        respuesta = ds.Actualizar(obj);
                    }
                    else
                    {
                        usuario_postgres ds = new usuario_postgres();
                        respuesta = ds.Actualizar(obj);
                    }
                    
                    if (respuesta.Equals("Actualizado"))
                    {
                        MessageBox.Show("Registro ha sido actualizado en tabla Usuario", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.limpiarcasilla();
                        
                        this.Hide();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("No se puedo actualizar este usuario", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    FrmUsuarios.instance.grilla1();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtpassword.Focus(); 
            }
        }
        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnActualizar.Focus();
            }
        }
        private void btnverclave_Click(object sender, EventArgs e)
        {
            if (btnverclave.Text == "Mostrar clave")
            {
                tcontrol = 1;
                Clase.esconder ver = new esconder();
                txtpassword.Enabled = true;
                txtpassword.Text = ver.Mostrar(txtpassword.Text);
                txtpassword.PasswordChar = '\0';
                btnverclave.Text = "Ocultar clave";
                btnverclave.Refresh();

            }
            else {

                if (btnverclave.Text == "Ocultar clave")
                {
                    tcontrol = 2;
                    Clase.esconder ocultar = new esconder();
                    txtpassword.Enabled = false;
                    txtpassword.Text = ocultar.Ocultar(txtpassword.Text);
                   /** txtpassword.PasswordChar = '*';*/
                    btnverclave.Text = "Mostrar clave";
                    btnverclave.Refresh();

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

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }

    }
    

