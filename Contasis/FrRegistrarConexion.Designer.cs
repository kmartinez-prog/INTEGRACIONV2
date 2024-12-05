namespace Contasis
{
    partial class FrRegistrarConexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrRegistrarConexion));
            this.btnValidar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbOrigen = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtcadena = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEsquema = new System.Windows.Forms.ComboBox();
            this.cmbBase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpuerto = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.Txtusuario = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnValidar
            // 
            this.btnValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.Location = new System.Drawing.Point(112, 386);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(148, 32);
            this.btnValidar.TabIndex = 9;
            this.btnValidar.Text = "Testear Conexión";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Location = new System.Drawing.Point(283, 386);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(148, 32);
            this.btnGrabar.TabIndex = 10;
            this.btnGrabar.Text = "Siguiente";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(14, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 42);
            this.panel1.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Base de datos Origen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Data Origen : ";
            // 
            // cmbOrigen
            // 
            this.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrigen.FormattingEnabled = true;
            this.cmbOrigen.Items.AddRange(new object[] {
            "Microsoft SQL Server",
            "PostgreSQL"});
            this.cmbOrigen.Location = new System.Drawing.Point(167, 139);
            this.cmbOrigen.Name = "cmbOrigen";
            this.cmbOrigen.Size = new System.Drawing.Size(150, 21);
            this.cmbOrigen.TabIndex = 1;
            this.cmbOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbOrigen_SelectedIndexChanged_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtcadena);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbEsquema);
            this.panel2.Controls.Add(this.cmbBase);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtpuerto);
            this.panel2.Controls.Add(this.txtClave);
            this.panel2.Controls.Add(this.Txtusuario);
            this.panel2.Controls.Add(this.txtServidor);
            this.panel2.Location = new System.Drawing.Point(14, 169);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 194);
            this.panel2.TabIndex = 19;
            // 
            // txtcadena
            // 
            this.txtcadena.Location = new System.Drawing.Point(58, 160);
            this.txtcadena.Name = "txtcadena";
            this.txtcadena.ReadOnly = true;
            this.txtcadena.Size = new System.Drawing.Size(492, 20);
            this.txtcadena.TabIndex = 22;
            this.txtcadena.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(68, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Esquema : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Base de Datos : ";
            // 
            // cmbEsquema
            // 
            this.cmbEsquema.Enabled = false;
            this.cmbEsquema.FormattingEnabled = true;
            this.cmbEsquema.Location = new System.Drawing.Point(150, 126);
            this.cmbEsquema.Name = "cmbEsquema";
            this.cmbEsquema.Size = new System.Drawing.Size(302, 21);
            this.cmbEsquema.TabIndex = 8;
            // 
            // cmbBase
            // 
            this.cmbBase.Enabled = false;
            this.cmbBase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbBase.FormattingEnabled = true;
            this.cmbBase.Location = new System.Drawing.Point(150, 99);
            this.cmbBase.Name = "cmbBase";
            this.cmbBase.Size = new System.Drawing.Size(302, 21);
            this.cmbBase.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Puerto  :";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Contraseña :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nombre de Usuario :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre del Servidor :";
            // 
            // txtpuerto
            // 
            this.txtpuerto.Location = new System.Drawing.Point(527, 25);
            this.txtpuerto.MaxLength = 4;
            this.txtpuerto.Name = "txtpuerto";
            this.txtpuerto.Size = new System.Drawing.Size(57, 20);
            this.txtpuerto.TabIndex = 3;
            this.txtpuerto.Visible = false;
            this.txtpuerto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpuerto_KeyPress_1);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(150, 74);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(182, 20);
            this.txtClave.TabIndex = 6;
            // 
            // Txtusuario
            // 
            this.Txtusuario.Location = new System.Drawing.Point(150, 49);
            this.Txtusuario.Name = "Txtusuario";
            this.Txtusuario.Size = new System.Drawing.Size(183, 20);
            this.Txtusuario.TabIndex = 4;
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(150, 25);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(320, 20);
            this.txtServidor.TabIndex = 2;
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.SkyBlue;
            this.lblEstado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Red;
            this.lblEstado.Location = new System.Drawing.Point(8, 427);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(606, 27);
            this.lblEstado.TabIndex = 20;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::Contasis.Properties.Resources._17;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(455, 386);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(148, 32);
            this.BtnSalir.TabIndex = 10;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Contasis.Properties.Resources.Logo___Contasis;
            this.pictureBox1.Location = new System.Drawing.Point(17, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(491, -60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 21;
            // 
            // FrRegistrarConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(623, 463);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmbOrigen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnValidar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrRegistrarConexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar conexión de Origen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbOrigen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbEsquema;
        private System.Windows.Forms.ComboBox cmbBase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpuerto;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox Txtusuario;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.TextBox txtcadena;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox textBox1;
    }
}

