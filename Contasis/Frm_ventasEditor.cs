﻿using System;
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
    public partial class Frm_ventasEditor : Form
    {
        public static Frm_ventasEditor instance = null;
        public Frm_ventasEditor(string idventas, string ffechadoc,
                     string ffechaven, string ccoddoc, string cserie, string cnumero, string ctipdoc, string crazsoc,
                    string ruc, string  base1, string  nigv1, string  ntots, string ntc, string  cmreg,
                    string  cctabase, string  cctatot, string  ccond,string ccodcos, string ccodcos2,string ccodpresu,string obserror)
        {
            InitializeComponent();
            txtidventas.Text = idventas;
            txtffechadoc.Text =ffechadoc;
            txtffechaven.Text =ffechaven;
            txtccoddoc.Text = ccoddoc;
            txtcserie.Text = cserie;
            txtcnumero.Text =cnumero;
            txtctipdoc.Text =ctipdoc;
            txtcrazsoc.Text = crazsoc;
            txtruc.Text = ruc;
            txtbase1.Text = base1;
            txtnigv1.Text = nigv1;
            txtntots.Text = ntots;
            txtntc.Text = ntc;
            txtcmreg.Text = cmreg;
            txtcctabase.Text = cctabase;
            txtcctatot.Text = cctatot;
            txtccond.Text = ccond;
            txtccodcos.Text = ccodcos;
            txtccodcos2.Text = ccodcos2;
            txtccodpresu.Text = ccodpresu;
            txtobservacion.Text = obserror;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == (Keys.Escape))
            {
                Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Frm_ventasEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Hide();
            }
        }

        private void Frm_ventasEditor_Load(object sender, EventArgs e)
        {
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    string respuesta = "";
                    Clase.VENTAS_PROPIEDADES obe = new Clase.VENTAS_PROPIEDADES();

                    obe.Idventas = txtidventas.Text;
                    
                    Clase.Ventas_inconsistencias ds = new Clase.Ventas_inconsistencias();
                    respuesta = ds.eliminarsql(obe);
                    if (respuesta.Equals("Eliminar"))
                    {
                        
                        MessageBox.Show("Venta fue eliminada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmInconsistencia.instance.llenar_grilla();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar esa venta.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                try
                {
                    string respuesta = "";
                    Clase.VENTAS_PROPIEDADES obe = new Clase.VENTAS_PROPIEDADES();

                    obe.Idventas = txtidventas.Text;
                    Clase.Ventas_inconsistencias ds = new Clase.Ventas_inconsistencias();
                    
                    respuesta = ds.eliminarpos(obe);
                    if (respuesta.Equals("Eliminar"))
                    {
                        
                        MessageBox.Show("Venta fue eliminada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmInconsistencia.instance.llenar_grilla();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar esa venta.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string respuesta = "";
            Clase.VENTAS_PROPIEDADES obe = new Clase.VENTAS_PROPIEDADES();
            Clase.Ventas_inconsistencias ds = new Clase.Ventas_inconsistencias();
            obe.Idventas = txtidventas.Text;
            obe.Ffechadoc = txtffechadoc.Text;
            obe.Ffechaven = txtffechaven.Text;
            obe.Ccoddoc = txtccoddoc.Text.Trim();
            obe.Cserie = txtcserie.Text.Trim();
            obe.Cnumero = txtcnumero.Text.Trim();
            obe.Ctipdoc = txtctipdoc.Text.Trim();
            obe.Crazsoc = txtcrazsoc.Text.Trim();
            obe.Cruc = txtruc.Text.Trim();
            obe.Base1 = txtbase1.Text;
            obe.Nigv1 = txtnigv1.Text;
            obe.Ntots = txtntots.Text;
            obe.Ntc = txtntc.Text;
            obe.Cmreg = txtcmreg.Text.Trim();
            obe.Cctabase = txtcctabase.Text.Trim();
            obe.Cctatot = txtcctatot.Text.Trim();
            obe.Ccond = txtccond.Text.Trim().ToUpper();
            obe.Ccodcos = txtccodcos.Text.Trim();
            obe.Ccodcos2 = txtccodcos2.Text.Trim();
            obe.Ccodpresu = txtccodpresu.Text.Trim();
            

            if (Properties.Settings.Default.cadenaPostPrincipal == "")
            {
                try
                {
                    respuesta = ds.Actualizarsql(obe);
                    if (respuesta.Equals("Actualizado"))
                    {

                        MessageBox.Show("Venta fue actualizada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencia.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar esa venta.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
            else
            {
                try
                {
                    respuesta = ds.Actualizarpos(obe);
                    if (respuesta.Equals("Actualizado"))
                    {

                        MessageBox.Show("Venta fue actualizada.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        FrmInconsistencia.instance.llenar_grilla();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizada esa venta.", "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error : " + ex.Message, "Contasis Corp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private void txtffechaven_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
