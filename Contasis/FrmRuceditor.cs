﻿using Contasis.Clase;
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
        int tcontrol;

        public FrmRuceditor(int ntipo, string ruc, string nombre, string frase)
        {
            InitializeComponent();
            tipo = ntipo;

            if (ntipo == 1)
            {
                txtruc.Visible = true;
                lblcodigo.Visible = true;
                txtestado.Visible = true;
            }
            else
            {
                txtruc.Visible = true;
                lblcodigo.Visible = true;
                txtruc.Text = ruc;
                txtempresa.Text = nombre;
                txtestado.Text = frase;
                
                txtestado.Enabled = true;

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
            txtestado.Clear();
            txtruc.Focus();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
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
                    if (txtestado.Text == "")
                    {
                        MessageBox.Show("estado no puede estar vacio.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtestado.Focus();
                        return;
                    }

                    if (Properties.Settings.Default.cadenaPostPrincipal == "")
                    {
                        string respuesta = "";

                        Clase.rucpropiedades obj = new rucpropiedades();

                        obj.ruc = txtruc.Text.Trim();
                        obj.empresa = txtempresa.Text.Trim();
                        obj.estado = txtestado.Text.Trim();
                        Clase.ruc ds = new ruc();
                        respuesta = ds.Insertar(obj);
                        if (respuesta.Equals("Grabado"))
                        {
                            MessageBox.Show("Registro grabado en tabla ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.limpiarcasilla();

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
                        obj.estado = txtestado.Text.Trim();
                        ruc_postgres ds = new ruc_postgres();
                        respuesta = ds.Insertar(obj);
                        if (respuesta.Equals("Grabado"))
                        {
                            MessageBox.Show("Registro grabado en tabla ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.limpiarcasilla();

                        }
                        else
                        {
                            MessageBox.Show("No se puedo regitrar este ruc emisor", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        FrmRucemisor.instance.grilla1();
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
                    obj.estado = txtestado.Text.Trim();
                 
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
    }
}
