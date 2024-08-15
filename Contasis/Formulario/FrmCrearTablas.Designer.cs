
namespace Contasis
{
    partial class FrmCrearTablas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrearTablas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btncreando = new System.Windows.Forms.Button();
            this.rbcomercial = new System.Windows.Forms.RadioButton();
            this.rbfinanciero = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblindex = new System.Windows.Forms.Label();
            this.lblotros = new System.Windows.Forms.Label();
            this.lblcompras = new System.Windows.Forms.Label();
            this.lblventa = new System.Windows.Forms.Label();
            this.progfinal = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.progvarios = new System.Windows.Forms.ProgressBar();
            this.progindex = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.progfcompras = new System.Windows.Forms.ProgressBar();
            this.progfventas = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.txtcadena = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btncreando);
            this.panel1.Controls.Add(this.rbcomercial);
            this.panel1.Controls.Add(this.rbfinanciero);
            this.panel1.Location = new System.Drawing.Point(7, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 48);
            this.panel1.TabIndex = 18;
            // 
            // btncreando
            // 
            this.btncreando.Location = new System.Drawing.Point(433, 15);
            this.btncreando.Name = "btncreando";
            this.btncreando.Size = new System.Drawing.Size(122, 26);
            this.btncreando.TabIndex = 2;
            this.btncreando.Text = "Verificar Estructura";
            this.btncreando.UseVisualStyleBackColor = true;
            this.btncreando.Click += new System.EventHandler(this.btncreando_Click);
            // 
            // rbcomercial
            // 
            this.rbcomercial.AutoSize = true;
            this.rbcomercial.Location = new System.Drawing.Point(241, 18);
            this.rbcomercial.Name = "rbcomercial";
            this.rbcomercial.Size = new System.Drawing.Size(156, 19);
            this.rbcomercial.TabIndex = 1;
            this.rbcomercial.TabStop = true;
            this.rbcomercial.Text = "Modulo Comercial SQL";
            this.rbcomercial.UseVisualStyleBackColor = true;
            // 
            // rbfinanciero
            // 
            this.rbfinanciero.AutoSize = true;
            this.rbfinanciero.Location = new System.Drawing.Point(15, 17);
            this.rbfinanciero.Name = "rbfinanciero";
            this.rbfinanciero.Size = new System.Drawing.Size(210, 19);
            this.rbfinanciero.TabIndex = 0;
            this.rbfinanciero.TabStop = true;
            this.rbfinanciero.Text = "Modulo Contable Financiero SQL";
            this.rbfinanciero.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-67, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(347, 74);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Modulos a Integrar";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblindex);
            this.panel2.Controls.Add(this.lblotros);
            this.panel2.Controls.Add(this.lblcompras);
            this.panel2.Controls.Add(this.lblventa);
            this.panel2.Controls.Add(this.progfinal);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.progvarios);
            this.panel2.Controls.Add(this.progindex);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.progfcompras);
            this.panel2.Controls.Add(this.progfventas);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(7, 166);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 212);
            this.panel2.TabIndex = 20;
            // 
            // lblindex
            // 
            this.lblindex.AutoSize = true;
            this.lblindex.BackColor = System.Drawing.Color.Transparent;
            this.lblindex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblindex.Location = new System.Drawing.Point(474, 143);
            this.lblindex.Name = "lblindex";
            this.lblindex.Size = new System.Drawing.Size(25, 15);
            this.lblindex.TabIndex = 15;
            this.lblindex.Text = "0%";
            // 
            // lblotros
            // 
            this.lblotros.AutoSize = true;
            this.lblotros.BackColor = System.Drawing.Color.Transparent;
            this.lblotros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblotros.Location = new System.Drawing.Point(473, 117);
            this.lblotros.Name = "lblotros";
            this.lblotros.Size = new System.Drawing.Size(25, 15);
            this.lblotros.TabIndex = 14;
            this.lblotros.Text = "0%";
            // 
            // lblcompras
            // 
            this.lblcompras.AutoSize = true;
            this.lblcompras.BackColor = System.Drawing.Color.Transparent;
            this.lblcompras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblcompras.Location = new System.Drawing.Point(473, 41);
            this.lblcompras.Name = "lblcompras";
            this.lblcompras.Size = new System.Drawing.Size(25, 15);
            this.lblcompras.TabIndex = 13;
            this.lblcompras.Text = "0%";
            // 
            // lblventa
            // 
            this.lblventa.AutoSize = true;
            this.lblventa.BackColor = System.Drawing.Color.Transparent;
            this.lblventa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblventa.Location = new System.Drawing.Point(473, 16);
            this.lblventa.Name = "lblventa";
            this.lblventa.Size = new System.Drawing.Size(25, 15);
            this.lblventa.TabIndex = 12;
            this.lblventa.Text = "0%";
            this.lblventa.Click += new System.EventHandler(this.lblventa_Click);
            // 
            // progfinal
            // 
            this.progfinal.Location = new System.Drawing.Point(248, 171);
            this.progfinal.Name = "progfinal";
            this.progfinal.Size = new System.Drawing.Size(209, 19);
            this.progfinal.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Proceso Terminado";
            // 
            // progvarios
            // 
            this.progvarios.Location = new System.Drawing.Point(248, 116);
            this.progvarios.Name = "progvarios";
            this.progvarios.Size = new System.Drawing.Size(209, 19);
            this.progvarios.TabIndex = 9;
            // 
            // progindex
            // 
            this.progindex.Location = new System.Drawing.Point(248, 145);
            this.progindex.Name = "progindex";
            this.progindex.Size = new System.Drawing.Size(209, 13);
            this.progindex.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Creando correctamente";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(248, 76);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(209, 13);
            this.progressBar1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Creamdo Servicios";
            // 
            // progfcompras
            // 
            this.progfcompras.Location = new System.Drawing.Point(248, 40);
            this.progfcompras.Name = "progfcompras";
            this.progfcompras.Size = new System.Drawing.Size(209, 19);
            this.progfcompras.Step = 20;
            this.progfcompras.TabIndex = 4;
            // 
            // progfventas
            // 
            this.progfventas.Location = new System.Drawing.Point(248, 15);
            this.progfventas.Name = "progfventas";
            this.progfventas.Size = new System.Drawing.Size(209, 19);
            this.progfventas.Step = 20;
            this.progfventas.TabIndex = 3;
            this.progfventas.Click += new System.EventHandler(this.progfventas_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Creando Tablas Intermedias";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Creando Tablas Fin_Compras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Creando Tablas Fin_Ventas";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::Contasis.Properties.Resources.icono_salir;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(487, 383);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(110, 44);
            this.BtnSalir.TabIndex = 21;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // txtcadena
            // 
            this.txtcadena.Location = new System.Drawing.Point(5, 384);
            this.txtcadena.Name = "txtcadena";
            this.txtcadena.ReadOnly = true;
            this.txtcadena.Size = new System.Drawing.Size(448, 20);
            this.txtcadena.TabIndex = 23;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // FrmCrearTablas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(609, 432);
            this.Controls.Add(this.txtcadena);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCrearTablas";
            this.Text = "Creador de tablas en la parte del Cliente";
            this.Load += new System.EventHandler(this.FrmCrearTablas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbcomercial;
        private System.Windows.Forms.RadioButton rbfinanciero;
        private System.Windows.Forms.Button btncreando;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TextBox txtcadena;
        private System.Windows.Forms.ProgressBar progfinal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progvarios;
        private System.Windows.Forms.ProgressBar progindex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progfcompras;
        private System.Windows.Forms.ProgressBar progfventas;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblventa;
        private System.Windows.Forms.Label lblcompras;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label lblotros;
        private System.Windows.Forms.Label lblindex;
    }
}