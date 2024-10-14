
namespace Contasis
{
    partial class FrmVerificacionEstrcutura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerificacionEstrcutura));
            this.pBarra = new System.Windows.Forms.ProgressBar();
            this.btncerrar = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtversion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pBarra
            // 
            this.pBarra.Location = new System.Drawing.Point(7, 33);
            this.pBarra.Name = "pBarra";
            this.pBarra.Size = new System.Drawing.Size(393, 19);
            this.pBarra.Step = 20;
            this.pBarra.TabIndex = 4;
            // 
            // btncerrar
            // 
            this.btncerrar.BackColor = System.Drawing.Color.White;
            this.btncerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrar.Image = global::Contasis.Properties.Resources._11;
            this.btncerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncerrar.Location = new System.Drawing.Point(300, 136);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(100, 32);
            this.btncerrar.TabIndex = 5;
            this.btncerrar.Text = "Salir";
            this.btncerrar.UseVisualStyleBackColor = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensaje.CausesValidation = false;
            this.txtMensaje.Location = new System.Drawing.Point(10, 82);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(393, 13);
            this.txtMensaje.TabIndex = 6;
            this.txtMensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMensaje.TextChanged += new System.EventHandler(this.txtMensaje_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtversion
            // 
            this.txtversion.Location = new System.Drawing.Point(538, 45);
            this.txtversion.Multiline = true;
            this.txtversion.Name = "txtversion";
            this.txtversion.Size = new System.Drawing.Size(401, 99);
            this.txtversion.TabIndex = 7;
            this.txtversion.Text = "CREATE TABLE cg_version( \r\ncversion character(15) COLLATE pg_catalog.\"default\" NO" +
    "T NULL,\r\ncfecha timestamp without time zone NOT NULL DEFAULT now()); ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(194, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "0";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FrmVerificacionEstrcutura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 101);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtversion);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.pBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVerificacionEstrcutura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificación de estructura";
            this.Load += new System.EventHandler(this.FrmVerificacionEstrcutura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pBarra;
        private System.Windows.Forms.Button btncerrar;
        private System.Windows.Forms.TextBox txtMensaje;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtversion;
        private System.Windows.Forms.Label label1;
    }
}