﻿
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progreotrastablas = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblindex = new System.Windows.Forms.Label();
            this.lblotros = new System.Windows.Forms.Label();
            this.lblcompras = new System.Windows.Forms.Label();
            this.lblventa = new System.Windows.Forms.Label();
            this.progfinal = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.progvarios = new System.Windows.Forms.ProgressBar();
            this.progindex = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.progfcompras = new System.Windows.Forms.ProgressBar();
            this.progfventas = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcadena = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.BtnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtopcion1 = new System.Windows.Forms.TextBox();
            this.txtopcion2 = new System.Windows.Forms.TextBox();
            this.txtxcrearfuncion = new System.Windows.Forms.TextBox();
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.txtventa1 = new System.Windows.Forms.TextBox();
            this.txtventa2 = new System.Windows.Forms.TextBox();
            this.txtcompras1 = new System.Windows.Forms.TextBox();
            this.txtcompras2 = new System.Windows.Forms.TextBox();
            this.soloventasonline = new System.Windows.Forms.TextBox();
            this.txtversion1 = new System.Windows.Forms.TextBox();
            this.txtversion2 = new System.Windows.Forms.TextBox();
            this.txtversion3 = new System.Windows.Forms.TextBox();
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.timer7 = new System.Windows.Forms.Timer(this.components);
            this.Funcion_comercial = new System.Windows.Forms.TextBox();
            this.func_guardar_com_documento = new System.Windows.Forms.TextBox();
            this.func_guardar_com_producto = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btncreando);
            this.panel1.Controls.Add(this.rbcomercial);
            this.panel1.Controls.Add(this.rbfinanciero);
            this.panel1.Location = new System.Drawing.Point(21, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 48);
            this.panel1.TabIndex = 18;
            // 
            // btncreando
            // 
            this.btncreando.Location = new System.Drawing.Point(448, 7);
            this.btncreando.Name = "btncreando";
            this.btncreando.Size = new System.Drawing.Size(128, 30);
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
            this.rbcomercial.CheckedChanged += new System.EventHandler(this.rbcomercial_CheckedChanged);
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
            this.rbfinanciero.CheckedChanged += new System.EventHandler(this.rbfinanciero_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Modulos a Integrar";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.progreotrastablas);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblindex);
            this.panel2.Controls.Add(this.lblotros);
            this.panel2.Controls.Add(this.lblcompras);
            this.panel2.Controls.Add(this.lblventa);
            this.panel2.Controls.Add(this.progfinal);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.progvarios);
            this.panel2.Controls.Add(this.progindex);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.progfcompras);
            this.panel2.Controls.Add(this.progfventas);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(21, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 198);
            this.panel2.TabIndex = 20;
            // 
            // progreotrastablas
            // 
            this.progreotrastablas.Location = new System.Drawing.Point(248, 71);
            this.progreotrastablas.Name = "progreotrastablas";
            this.progreotrastablas.Size = new System.Drawing.Size(185, 19);
            this.progreotrastablas.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Realizando verificacion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(447, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "0%";
            // 
            // lblindex
            // 
            this.lblindex.AutoSize = true;
            this.lblindex.BackColor = System.Drawing.Color.Transparent;
            this.lblindex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblindex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblindex.Location = new System.Drawing.Point(447, 143);
            this.lblindex.Name = "lblindex";
            this.lblindex.Size = new System.Drawing.Size(27, 15);
            this.lblindex.TabIndex = 15;
            this.lblindex.Text = "0%";
            // 
            // lblotros
            // 
            this.lblotros.AutoSize = true;
            this.lblotros.BackColor = System.Drawing.Color.Transparent;
            this.lblotros.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblotros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblotros.Location = new System.Drawing.Point(447, 111);
            this.lblotros.Name = "lblotros";
            this.lblotros.Size = new System.Drawing.Size(27, 15);
            this.lblotros.TabIndex = 14;
            this.lblotros.Text = "0%";
            // 
            // lblcompras
            // 
            this.lblcompras.AutoSize = true;
            this.lblcompras.BackColor = System.Drawing.Color.Transparent;
            this.lblcompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcompras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblcompras.Location = new System.Drawing.Point(447, 41);
            this.lblcompras.Name = "lblcompras";
            this.lblcompras.Size = new System.Drawing.Size(27, 15);
            this.lblcompras.TabIndex = 13;
            this.lblcompras.Text = "0%";
            // 
            // lblventa
            // 
            this.lblventa.AutoSize = true;
            this.lblventa.BackColor = System.Drawing.Color.Transparent;
            this.lblventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblventa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblventa.Location = new System.Drawing.Point(447, 16);
            this.lblventa.Name = "lblventa";
            this.lblventa.Size = new System.Drawing.Size(27, 15);
            this.lblventa.TabIndex = 12;
            this.lblventa.Text = "0%";
            // 
            // progfinal
            // 
            this.progfinal.Location = new System.Drawing.Point(248, 171);
            this.progfinal.Name = "progfinal";
            this.progfinal.Size = new System.Drawing.Size(185, 19);
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
            this.progvarios.Location = new System.Drawing.Point(248, 111);
            this.progvarios.Name = "progvarios";
            this.progvarios.Size = new System.Drawing.Size(185, 19);
            this.progvarios.TabIndex = 9;
            // 
            // progindex
            // 
            this.progindex.Location = new System.Drawing.Point(248, 143);
            this.progindex.Name = "progindex";
            this.progindex.Size = new System.Drawing.Size(185, 19);
            this.progindex.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Creando Procedimientos funciones";
            // 
            // progfcompras
            // 
            this.progfcompras.Location = new System.Drawing.Point(248, 40);
            this.progfcompras.Name = "progfcompras";
            this.progfcompras.Size = new System.Drawing.Size(185, 19);
            this.progfcompras.Step = 20;
            this.progfcompras.TabIndex = 4;
            // 
            // progfventas
            // 
            this.progfventas.Location = new System.Drawing.Point(248, 15);
            this.progfventas.Name = "progfventas";
            this.progfventas.Size = new System.Drawing.Size(185, 19);
            this.progfventas.Step = 20;
            this.progfventas.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 112);
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
            // txtcadena
            // 
            this.txtcadena.Location = new System.Drawing.Point(22, 417);
            this.txtcadena.Name = "txtcadena";
            this.txtcadena.ReadOnly = true;
            this.txtcadena.Size = new System.Drawing.Size(248, 20);
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
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Image = global::Contasis.Properties.Resources._12;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(509, 330);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(100, 32);
            this.BtnSalir.TabIndex = 21;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Contasis.Properties.Resources.Logo___Contasis;
            this.pictureBox1.Location = new System.Drawing.Point(9, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // txtopcion1
            // 
            this.txtopcion1.Location = new System.Drawing.Point(280, 416);
            this.txtopcion1.Name = "txtopcion1";
            this.txtopcion1.Size = new System.Drawing.Size(78, 20);
            this.txtopcion1.TabIndex = 25;
            // 
            // txtopcion2
            // 
            this.txtopcion2.Location = new System.Drawing.Point(364, 416);
            this.txtopcion2.Name = "txtopcion2";
            this.txtopcion2.Size = new System.Drawing.Size(78, 20);
            this.txtopcion2.TabIndex = 26;
            // 
            // txtxcrearfuncion
            // 
            this.txtxcrearfuncion.Location = new System.Drawing.Point(647, 26);
            this.txtxcrearfuncion.Multiline = true;
            this.txtxcrearfuncion.Name = "txtxcrearfuncion";
            this.txtxcrearfuncion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtxcrearfuncion.Size = new System.Drawing.Size(209, 134);
            this.txtxcrearfuncion.TabIndex = 27;
            this.txtxcrearfuncion.Text = resources.GetString("txtxcrearfuncion.Text");
            // 
            // timer5
            // 
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // txtventa1
            // 
            this.txtventa1.BackColor = System.Drawing.SystemColors.Info;
            this.txtventa1.Location = new System.Drawing.Point(861, 26);
            this.txtventa1.Multiline = true;
            this.txtventa1.Name = "txtventa1";
            this.txtventa1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtventa1.Size = new System.Drawing.Size(209, 336);
            this.txtventa1.TabIndex = 28;
            this.txtventa1.Text = resources.GetString("txtventa1.Text");
            // 
            // txtventa2
            // 
            this.txtventa2.BackColor = System.Drawing.SystemColors.Info;
            this.txtventa2.Location = new System.Drawing.Point(1075, 26);
            this.txtventa2.Multiline = true;
            this.txtventa2.Name = "txtventa2";
            this.txtventa2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtventa2.Size = new System.Drawing.Size(209, 336);
            this.txtventa2.TabIndex = 29;
            this.txtventa2.Text = resources.GetString("txtventa2.Text");
            // 
            // txtcompras1
            // 
            this.txtcompras1.Location = new System.Drawing.Point(1288, 26);
            this.txtcompras1.Multiline = true;
            this.txtcompras1.Name = "txtcompras1";
            this.txtcompras1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtcompras1.Size = new System.Drawing.Size(179, 336);
            this.txtcompras1.TabIndex = 30;
            this.txtcompras1.Text = resources.GetString("txtcompras1.Text");
            // 
            // txtcompras2
            // 
            this.txtcompras2.Location = new System.Drawing.Point(1479, 26);
            this.txtcompras2.Multiline = true;
            this.txtcompras2.Name = "txtcompras2";
            this.txtcompras2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtcompras2.Size = new System.Drawing.Size(179, 336);
            this.txtcompras2.TabIndex = 31;
            this.txtcompras2.Text = resources.GetString("txtcompras2.Text");
            // 
            // soloventasonline
            // 
            this.soloventasonline.Location = new System.Drawing.Point(1667, 26);
            this.soloventasonline.Multiline = true;
            this.soloventasonline.Name = "soloventasonline";
            this.soloventasonline.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.soloventasonline.Size = new System.Drawing.Size(220, 336);
            this.soloventasonline.TabIndex = 32;
            this.soloventasonline.Text = resources.GetString("soloventasonline.Text");
            // 
            // txtversion1
            // 
            this.txtversion1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtversion1.Location = new System.Drawing.Point(647, 377);
            this.txtversion1.Multiline = true;
            this.txtversion1.Name = "txtversion1";
            this.txtversion1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtversion1.Size = new System.Drawing.Size(209, 137);
            this.txtversion1.TabIndex = 33;
            this.txtversion1.Text = "CREATE TABLE cg_version\r\n(\r\n    cversion character(15) not null,\r\n    cfecha time" +
    "stamp default now() not null    \r\n);";
            // 
            // txtversion2
            // 
            this.txtversion2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtversion2.Location = new System.Drawing.Point(862, 377);
            this.txtversion2.Multiline = true;
            this.txtversion2.Name = "txtversion2";
            this.txtversion2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtversion2.Size = new System.Drawing.Size(209, 137);
            this.txtversion2.TabIndex = 34;
            this.txtversion2.Text = resources.GetString("txtversion2.Text");
            // 
            // txtversion3
            // 
            this.txtversion3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtversion3.Location = new System.Drawing.Point(1077, 377);
            this.txtversion3.Multiline = true;
            this.txtversion3.Name = "txtversion3";
            this.txtversion3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtversion3.Size = new System.Drawing.Size(209, 137);
            this.txtversion3.TabIndex = 35;
            this.txtversion3.Text = resources.GetString("txtversion3.Text");
            // 
            // timer6
            // 
            this.timer6.Tick += new System.EventHandler(this.timer6_Tick);
            // 
            // Funcion_comercial
            // 
            this.Funcion_comercial.Location = new System.Drawing.Point(646, 182);
            this.Funcion_comercial.Multiline = true;
            this.Funcion_comercial.Name = "Funcion_comercial";
            this.Funcion_comercial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Funcion_comercial.Size = new System.Drawing.Size(209, 134);
            this.Funcion_comercial.TabIndex = 36;
            this.Funcion_comercial.Text = resources.GetString("Funcion_comercial.Text");
            // 
            // func_guardar_com_documento
            // 
            this.func_guardar_com_documento.BackColor = System.Drawing.Color.Moccasin;
            this.func_guardar_com_documento.Location = new System.Drawing.Point(1291, 377);
            this.func_guardar_com_documento.Multiline = true;
            this.func_guardar_com_documento.Name = "func_guardar_com_documento";
            this.func_guardar_com_documento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.func_guardar_com_documento.Size = new System.Drawing.Size(172, 137);
            this.func_guardar_com_documento.TabIndex = 37;
            this.func_guardar_com_documento.Text = resources.GetString("func_guardar_com_documento.Text");
            // 
            // func_guardar_com_producto
            // 
            this.func_guardar_com_producto.BackColor = System.Drawing.Color.Moccasin;
            this.func_guardar_com_producto.Location = new System.Drawing.Point(1473, 377);
            this.func_guardar_com_producto.Multiline = true;
            this.func_guardar_com_producto.Name = "func_guardar_com_producto";
            this.func_guardar_com_producto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.func_guardar_com_producto.Size = new System.Drawing.Size(189, 137);
            this.func_guardar_com_producto.TabIndex = 38;
            this.func_guardar_com_producto.Text = resources.GetString("func_guardar_com_producto.Text");
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Moccasin;
            this.textBox3.Location = new System.Drawing.Point(1667, 377);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(189, 137);
            this.textBox3.TabIndex = 39;
            // 
            // FrmCrearTablas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(631, 372);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.func_guardar_com_producto);
            this.Controls.Add(this.func_guardar_com_documento);
            this.Controls.Add(this.Funcion_comercial);
            this.Controls.Add(this.txtversion3);
            this.Controls.Add(this.txtversion2);
            this.Controls.Add(this.txtversion1);
            this.Controls.Add(this.soloventasonline);
            this.Controls.Add(this.txtcompras2);
            this.Controls.Add(this.txtcompras1);
            this.Controls.Add(this.txtventa2);
            this.Controls.Add(this.txtventa1);
            this.Controls.Add(this.txtxcrearfuncion);
            this.Controls.Add(this.txtopcion2);
            this.Controls.Add(this.txtopcion1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtcadena);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCrearTablas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCrearTablas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCrearTablas_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.ProgressBar progfcompras;
        private System.Windows.Forms.ProgressBar progfventas;
        private System.Windows.Forms.Label lblventa;
        private System.Windows.Forms.Label lblcompras;
        private System.Windows.Forms.Label lblotros;
        private System.Windows.Forms.Label lblindex;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Timer timer3;
        public System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtopcion1;
        private System.Windows.Forms.TextBox txtopcion2;
        private System.Windows.Forms.TextBox txtxcrearfuncion;
        public System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.TextBox txtventa1;
        private System.Windows.Forms.TextBox txtventa2;
        private System.Windows.Forms.TextBox txtcompras1;
        private System.Windows.Forms.TextBox txtcompras2;
        private System.Windows.Forms.TextBox soloventasonline;
        private System.Windows.Forms.TextBox txtversion1;
        private System.Windows.Forms.TextBox txtversion2;
        private System.Windows.Forms.TextBox txtversion3;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Timer timer6;
        private System.Windows.Forms.ProgressBar progreotrastablas;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Timer timer7;
        private System.Windows.Forms.TextBox Funcion_comercial;
        private System.Windows.Forms.TextBox func_guardar_com_documento;
        private System.Windows.Forms.TextBox func_guardar_com_producto;
        private System.Windows.Forms.TextBox textBox3;
    }
}