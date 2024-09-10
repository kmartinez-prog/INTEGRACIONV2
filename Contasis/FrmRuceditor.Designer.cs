
namespace Contasis
{
    partial class FrmRuceditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRuceditor));
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.btncerrar = new System.Windows.Forms.Button();
            this.checkBoxestado = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtempresa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtruc = new System.Windows.Forms.TextBox();
            this.lblcodigo = new System.Windows.Forms.Label();
            this.checkventa = new System.Windows.Forms.CheckBox();
            this.checkCompras = new System.Windows.Forms.CheckBox();
            this.checkPagos = new System.Windows.Forms.CheckBox();
            this.checkCobranza = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.BackColor = System.Drawing.Color.White;
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Image = global::Contasis.Properties.Resources._9__Icono_Boton___Grabar;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnActualizar.Location = new System.Drawing.Point(208, 168);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(100, 32);
            this.BtnActualizar.TabIndex = 7;
            this.BtnActualizar.Text = "Grabar";
            this.BtnActualizar.UseVisualStyleBackColor = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // btncerrar
            // 
            this.btncerrar.BackColor = System.Drawing.Color.White;
            this.btncerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrar.Image = global::Contasis.Properties.Resources._11;
            this.btncerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncerrar.Location = new System.Drawing.Point(315, 168);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(100, 32);
            this.btncerrar.TabIndex = 8;
            this.btncerrar.Text = "Salir";
            this.btncerrar.UseVisualStyleBackColor = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // checkBoxestado
            // 
            this.checkBoxestado.AutoSize = true;
            this.checkBoxestado.Location = new System.Drawing.Point(17, 107);
            this.checkBoxestado.Name = "checkBoxestado";
            this.checkBoxestado.Size = new System.Drawing.Size(129, 19);
            this.checkBoxestado.TabIndex = 6;
            this.checkBoxestado.Text = "Check para activar";
            this.checkBoxestado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Estado";
            // 
            // txtempresa
            // 
            this.txtempresa.Location = new System.Drawing.Point(17, 65);
            this.txtempresa.MaxLength = 60;
            this.txtempresa.Name = "txtempresa";
            this.txtempresa.Size = new System.Drawing.Size(396, 20);
            this.txtempresa.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de empresa";
            // 
            // txtruc
            // 
            this.txtruc.Location = new System.Drawing.Point(17, 24);
            this.txtruc.MaxLength = 11;
            this.txtruc.Name = "txtruc";
            this.txtruc.Size = new System.Drawing.Size(124, 20);
            this.txtruc.TabIndex = 4;
            // 
            // lblcodigo
            // 
            this.lblcodigo.AutoSize = true;
            this.lblcodigo.Location = new System.Drawing.Point(17, 6);
            this.lblcodigo.Name = "lblcodigo";
            this.lblcodigo.Size = new System.Drawing.Size(32, 15);
            this.lblcodigo.TabIndex = 1;
            this.lblcodigo.Text = "Ruc:";
            // 
            // checkventa
            // 
            this.checkventa.AutoSize = true;
            this.checkventa.Location = new System.Drawing.Point(171, 107);
            this.checkventa.Name = "checkventa";
            this.checkventa.Size = new System.Drawing.Size(104, 19);
            this.checkventa.TabIndex = 9;
            this.checkventa.Text = "Activar Ventas";
            this.checkventa.UseVisualStyleBackColor = true;
            // 
            // checkCompras
            // 
            this.checkCompras.AutoSize = true;
            this.checkCompras.Location = new System.Drawing.Point(171, 132);
            this.checkCompras.Name = "checkCompras";
            this.checkCompras.Size = new System.Drawing.Size(117, 19);
            this.checkCompras.TabIndex = 10;
            this.checkCompras.Text = "Activar Compras";
            this.checkCompras.UseVisualStyleBackColor = true;
            // 
            // checkPagos
            // 
            this.checkPagos.AutoSize = true;
            this.checkPagos.Location = new System.Drawing.Point(290, 133);
            this.checkPagos.Name = "checkPagos";
            this.checkPagos.Size = new System.Drawing.Size(102, 19);
            this.checkPagos.TabIndex = 12;
            this.checkPagos.Text = "Activar Pagos";
            this.checkPagos.UseVisualStyleBackColor = true;
            // 
            // checkCobranza
            // 
            this.checkCobranza.AutoSize = true;
            this.checkCobranza.Location = new System.Drawing.Point(290, 108);
            this.checkCobranza.Name = "checkCobranza";
            this.checkCobranza.Size = new System.Drawing.Size(120, 19);
            this.checkCobranza.TabIndex = 11;
            this.checkCobranza.Text = "Activar Cobranza";
            this.checkCobranza.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Activar Servicios";
            // 
            // FrmRuceditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(418, 210);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkPagos);
            this.Controls.Add(this.checkCobranza);
            this.Controls.Add(this.checkCompras);
            this.Controls.Add(this.checkventa);
            this.Controls.Add(this.checkBoxestado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtempresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtruc);
            this.Controls.Add(this.lblcodigo);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.btncerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRuceditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ruc Emisor";
            this.Load += new System.EventHandler(this.FrmRuceditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button btncerrar;
        private System.Windows.Forms.CheckBox checkBoxestado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtempresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtruc;
        private System.Windows.Forms.Label lblcodigo;
        private System.Windows.Forms.CheckBox checkventa;
        private System.Windows.Forms.CheckBox checkCompras;
        private System.Windows.Forms.CheckBox checkPagos;
        private System.Windows.Forms.CheckBox checkCobranza;
        private System.Windows.Forms.Label label1;
    }
}