
namespace Contasis
{
    partial class FrmConfigurarServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigurarServicio));
            this.BtnSalir = new System.Windows.Forms.Button();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.txtquery = new System.Windows.Forms.TextBox();
            this.txtcadenas = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtperiodo = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnEstado = new System.Windows.Forms.Button();
            this.chkGenerarDatos = new System.Windows.Forms.CheckBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::Contasis.Properties.Resources._14;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(266, 149);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(110, 44);
            this.BtnSalir.TabIndex = 28;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(9, 511);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(112, 20);
            this.txtcodigo.TabIndex = 31;
            // 
            // txtquery
            // 
            this.txtquery.Location = new System.Drawing.Point(9, 539);
            this.txtquery.Name = "txtquery";
            this.txtquery.Size = new System.Drawing.Size(137, 20);
            this.txtquery.TabIndex = 32;
            // 
            // txtcadenas
            // 
            this.txtcadenas.Location = new System.Drawing.Point(9, 563);
            this.txtcadenas.Name = "txtcadenas";
            this.txtcadenas.Size = new System.Drawing.Size(171, 20);
            this.txtcadenas.TabIndex = 33;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(10, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(158, 18);
            this.lblTitle.TabIndex = 34;
            this.lblTitle.Text = "Base de Datos Origen:";
            // 
            // txtperiodo
            // 
            this.txtperiodo.Location = new System.Drawing.Point(9, 589);
            this.txtperiodo.Name = "txtperiodo";
            this.txtperiodo.Size = new System.Drawing.Size(91, 20);
            this.txtperiodo.TabIndex = 35;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Image = global::Contasis.Properties.Resources._3__Icono___Origen_de_datos;
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.Location = new System.Drawing.Point(12, 64);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(110, 44);
            this.btnIniciar.TabIndex = 36;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetener.Image = global::Contasis.Properties.Resources._2__Icono_Boton___Eliminar;
            this.btnDetener.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetener.Location = new System.Drawing.Point(139, 64);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(110, 44);
            this.btnDetener.TabIndex = 37;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // btnEstado
            // 
            this.btnEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstado.Image = global::Contasis.Properties.Resources._5__Icono_Boton___Aceptar;
            this.btnEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstado.Location = new System.Drawing.Point(266, 64);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(110, 44);
            this.btnEstado.TabIndex = 38;
            this.btnEstado.Text = "Ver Estado";
            this.btnEstado.UseVisualStyleBackColor = true;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // chkGenerarDatos
            // 
            this.chkGenerarDatos.AutoSize = true;
            this.chkGenerarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGenerarDatos.Location = new System.Drawing.Point(10, 31);
            this.chkGenerarDatos.Name = "chkGenerarDatos";
            this.chkGenerarDatos.Size = new System.Drawing.Size(206, 22);
            this.chkGenerarDatos.TabIndex = 39;
            this.chkGenerarDatos.Text = "¿Generar datos en origen?";
            this.chkGenerarDatos.UseVisualStyleBackColor = true;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(10, 121);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(13, 18);
            this.lblEstado.TabIndex = 40;
            this.lblEstado.Text = "-";
            // 
            // FrmConfigurarServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 205);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.chkGenerarDatos);
            this.Controls.Add(this.btnEstado);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.txtperiodo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtcadenas);
            this.Controls.Add(this.txtquery);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.BtnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfigurarServicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Servicio";
            this.Load += new System.EventHandler(this.FrmConfigurarServicio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConfigurarServicio_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.TextBox txtquery;
        private System.Windows.Forms.TextBox txtcadenas;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtperiodo;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.CheckBox chkGenerarDatos;
        private System.Windows.Forms.Label lblEstado;
    }
}