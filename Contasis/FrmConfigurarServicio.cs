using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;

namespace Contasis
{
    public partial class FrmConfigurarServicio : Form
    {
        string tipoBD = "SQLSERVER";
        string conexionSQL = Properties.Settings.Default.cadenaSql;

        private string serviceName = "IntegradorOnline";

        public FrmConfigurarServicio()
        {
           InitializeComponent();
           
            if (conexionSQL == "")
            {
                tipoBD = "POSTGRES";
                conexionSQL = Properties.Settings.Default.cadenaPostPrincipal;
            }
            lblTitle.Text = "Base de datos origen: "+tipoBD.Trim();
        }

        private void FrmConfigurarServicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Hide();
            }
        }
        
        private void FrmConfigurarServicio_Load(object sender, EventArgs e)
        {
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }



        private void btnIniciar_Click(object sender, EventArgs e)
        {
           
            string generar = chkGenerarDatos.Checked ? "S" : "N";
            string arguments = $"start {serviceName} \"{conexionSQL}\" \"{tipoBD}\" \"{generar}\"";
            lblEstado.Text = conexionSQL;
            var processInfo = GetProcessStartInfo(arguments);
            try
            {                
                using (var process = Process.Start(processInfo))
                {
                    process.WaitForExit(); 
                    if (process.ExitCode == 0)
                    {
                        lblEstado.Text = "Servicio iniciado.";
                    }
                    else
                    {
                        lblEstado.Text = $"Error al iniciar el servicio. Código de salida: {process.ExitCode}";
                    }
                }
            }
            catch (Win32Exception ex)
            {
                lblEstado.Text = $"Error al solicitar permisos elevados: {ex.Message}";
            }
          /////  lblEstado.Text += "\n"+conexionSQL;
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            string arguments = $"stop {serviceName}";
            var processInfo = GetProcessStartInfo(arguments);

            try
            {
                using (var process = Process.Start(processInfo))
                {
                    process.WaitForExit();
                    if (process.ExitCode == 0)
                    {
                        lblEstado.Text = "Servicio detenido.";
                    }
                    else
                    {
                        lblEstado.Text = $"Error al detener el servicio. Código de salida: {process.ExitCode}";
                    }
                }
            }
            catch (Win32Exception ex)
            {
                lblEstado.Text = $"Error al solicitar permisos elevados: {ex.Message}";
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sc = new ServiceController(serviceName))
                {
                    string status = sc.Status.ToString();
                    lblEstado.Text = $"Estado del servicio: {status}";
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error al obtener el estado del servicio: {ex.Message}";
            }
        }

        private ProcessStartInfo GetProcessStartInfo(string arguments)
        {
            return new ProcessStartInfo
            {
                FileName = "sc.exe",
                Arguments = arguments,
                Verb = "runas", // Solicitar permiso de administrador
                UseShellExecute = true,
                CreateNoWindow = true
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ocultarsql;
            try
            {
                Clase.esconder ocultar = new Clase.esconder();
                ocultarsql = ocultar.Ocultar(conexionSQL);



                string pathBase = Application.StartupPath + "/service";
                if (!Directory.Exists(pathBase))
                {
                    Directory.CreateDirectory(pathBase);
                }
                string pathFile = Path.Combine(pathBase, "initservice.bat");

                string generar = chkGenerarDatos.Checked ? "S" : "N";
                string command = $"sc start {serviceName} \"{ocultarsql}\" \"{tipoBD}\" \"{generar}\"";
                File.WriteAllText(pathFile, command);

                Process.Start(pathBase);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear archivo para iniciar servicio: " + ex.Message);
            }
        }
    }
}
