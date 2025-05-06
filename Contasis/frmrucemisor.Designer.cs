
namespace Contasis
{
    partial class FrmRucemisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRucemisor));
            this.dataGrid1 = new System.Windows.Forms.DataGridView();
            this.lblTotales = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btncerrar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowUserToDeleteRows = false;
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid1.Location = new System.Drawing.Point(4, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGrid1.RowHeadersWidth = 51;
            this.dataGrid1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGrid1.Size = new System.Drawing.Size(610, 162);
            this.dataGrid1.TabIndex = 18;
            this.dataGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid1_CellClick);
            this.dataGrid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid1_CellContentClick);
            this.dataGrid1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid1_CellContentDoubleClick);
            this.dataGrid1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid1_CellDoubleClick);
            // 
            // lblTotales
            // 
            this.lblTotales.AutoSize = true;
            this.lblTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotales.Location = new System.Drawing.Point(9, 259);
            this.lblTotales.Name = "lblTotales";
            this.lblTotales.Size = new System.Drawing.Size(144, 15);
            this.lblTotales.TabIndex = 14;
            this.lblTotales.Text = "Total de Registros : 0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Contasis.Properties.Resources.Logo___Contasis;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // btnnuevo
            // 
            this.btnnuevo.BackColor = System.Drawing.Color.White;
            this.btnnuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnuevo.Image = global::Contasis.Properties.Resources._4__Icono_Boton___Nuevo;
            this.btnnuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnuevo.Location = new System.Drawing.Point(206, 275);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(100, 32);
            this.btnnuevo.TabIndex = 17;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = false;
            this.btnnuevo.Click += new System.EventHandler(this.Btnnuevo_Click_1);
            // 
            // btnmodificar
            // 
            this.btnmodificar.BackColor = System.Drawing.Color.White;
            this.btnmodificar.Enabled = false;
            this.btnmodificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmodificar.Image = global::Contasis.Properties.Resources._3__Icono_Boton___Modificar;
            this.btnmodificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmodificar.Location = new System.Drawing.Point(315, 275);
            this.btnmodificar.Name = "btnmodificar";
            this.btnmodificar.Size = new System.Drawing.Size(100, 32);
            this.btnmodificar.TabIndex = 16;
            this.btnmodificar.Text = "Modificar";
            this.btnmodificar.UseVisualStyleBackColor = false;
            this.btnmodificar.Click += new System.EventHandler(this.Btnmodificar_Click_1);
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.White;
            this.btneliminar.Enabled = false;
            this.btneliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneliminar.Image = global::Contasis.Properties.Resources._2__Icono_Boton___Eliminar;
            this.btneliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btneliminar.Location = new System.Drawing.Point(424, 275);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(100, 32);
            this.btneliminar.TabIndex = 15;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.Btneliminar_Click_1);
            // 
            // btncerrar
            // 
            this.btncerrar.BackColor = System.Drawing.Color.White;
            this.btncerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrar.Image = global::Contasis.Properties.Resources._1__Icono_Boton___Salir;
            this.btncerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncerrar.Location = new System.Drawing.Point(533, 275);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(100, 32);
            this.btncerrar.TabIndex = 13;
            this.btncerrar.Text = "Salir";
            this.btncerrar.UseVisualStyleBackColor = false;
            this.btncerrar.Click += new System.EventHandler(this.Btncerrar_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dataGrid1);
            this.panel1.Location = new System.Drawing.Point(7, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 181);
            this.panel1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Seleccionar primero un registro para que se active los botones de modificar y eli" +
    "minar";
            // 
            // FrmRucemisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 333);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.lblTotales);
            this.Controls.Add(this.btncerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRucemisor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento  Ruc Emisor";
            this.Load += new System.EventHandler(this.FrmRucemisor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGrid1;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Label lblTotales;
        private System.Windows.Forms.Button btncerrar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}