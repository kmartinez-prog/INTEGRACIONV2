﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerificacionEstrcutura));
            this.progfventas = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progfventas
            // 
            this.progfventas.Location = new System.Drawing.Point(28, 79);
            this.progfventas.Name = "progfventas";
            this.progfventas.Size = new System.Drawing.Size(393, 19);
            this.progfventas.Step = 20;
            this.progfventas.TabIndex = 4;
            // 
            // FrmVerificacionEstrcutura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 136);
            this.Controls.Add(this.progfventas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVerificacionEstrcutura";
            this.Text = "Verificación de estructura";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progfventas;
    }
}