
namespace Contasis
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.txtfrase = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cmbusuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtclave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cmdModulos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbox5 = new System.Windows.Forms.TextBox();
            this.txtbox6 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 354);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(704, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // txtfrase
            // 
            this.txtfrase.Location = new System.Drawing.Point(50, 401);
            this.txtfrase.Name = "txtfrase";
            this.txtfrase.Size = new System.Drawing.Size(128, 20);
            this.txtfrase.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(189, -71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(128, -69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // cmbusuario
            // 
            this.cmbusuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbusuario.FormattingEnabled = true;
            this.cmbusuario.Items.AddRange(new object[] {
            "ADMIN"});
            this.cmbusuario.Location = new System.Drawing.Point(387, 147);
            this.cmbusuario.Name = "cmbusuario";
            this.cmbusuario.Size = new System.Drawing.Size(264, 21);
            this.cmbusuario.TabIndex = 6;
            this.cmbusuario.SelectedIndexChanged += new System.EventHandler(this.Cmbusuario_SelectedIndexChanged_1);
            this.cmbusuario.SelectedValueChanged += new System.EventHandler(this.Cmbusuario_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(387, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(387, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Usuario";
            // 
            // txtclave
            // 
            this.txtclave.Location = new System.Drawing.Point(387, 203);
            this.txtclave.Name = "txtclave";
            this.txtclave.PasswordChar = '*';
            this.txtclave.Size = new System.Drawing.Size(264, 20);
            this.txtclave.TabIndex = 7;
            this.txtclave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtclave_KeyDown);
            this.txtclave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtclave_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(354, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 110);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sistema Integración Contasis";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuBar;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(387, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(264, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "Ingresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(31, 23);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(271, 151);
            this.textBox3.TabIndex = 12;
            this.textBox3.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(31, 180);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(271, 151);
            this.textBox4.TabIndex = 13;
            this.textBox4.Visible = false;
            // 
            // cmdModulos
            // 
            this.cmdModulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdModulos.FormattingEnabled = true;
            this.cmdModulos.Items.AddRange(new object[] {
            "ADMIN"});
            this.cmdModulos.Location = new System.Drawing.Point(387, 262);
            this.cmdModulos.Name = "cmdModulos";
            this.cmdModulos.Size = new System.Drawing.Size(264, 21);
            this.cmdModulos.TabIndex = 8;
            this.cmdModulos.SelectedIndexChanged += new System.EventHandler(this.cmdModulos_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(387, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Modulo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtbox5
            // 
            this.txtbox5.Location = new System.Drawing.Point(317, -57);
            this.txtbox5.Name = "txtbox5";
            this.txtbox5.Size = new System.Drawing.Size(100, 20);
            this.txtbox5.TabIndex = 16;
            // 
            // txtbox6
            // 
            this.txtbox6.Location = new System.Drawing.Point(317, -31);
            this.txtbox6.Name = "txtbox6";
            this.txtbox6.Size = new System.Drawing.Size(100, 20);
            this.txtbox6.TabIndex = 17;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.BackgroundImage = global::Contasis.Properties.Resources.LOGIN;
            this.ClientSize = new System.Drawing.Size(704, 376);
            this.Controls.Add(this.txtbox6);
            this.Controls.Add(this.txtbox5);
            this.Controls.Add(this.cmdModulos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.cmbusuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtclave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtfrase);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txtfrase;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox cmbusuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtclave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox cmdModulos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbox5;
        private System.Windows.Forms.TextBox txtbox6;
    }
}