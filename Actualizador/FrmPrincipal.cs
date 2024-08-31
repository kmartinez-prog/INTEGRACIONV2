using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actualizador
{
    public partial class FrmPrincipal : MaterialForm
    {
        private HttpClient httpClient;
        private MaterialSkinManager msk;

      private readonly string UrlVersion = "https://videocontasis.com/Contasiscorp_2023/SQL_2023/Update_Integrador/version.txt";
      private readonly string UrlApp = "https://videocontasis.com/Contasiscorp_2023/SQL_2023/Update_Integrador/Setup_{0}.zip";

      ///private readonly string UrlVersion = "https://contasiscorpfab.s3.amazonaws.com/version.txt";
       ///private readonly string UrlApp = "https://contasiscorpfab.s3.amazonaws.com/Setup_{0}.zip";

        private readonly string UbicacionInstalador = Application.StartupPath + "\\version"; //@"C:\\Users\\Public\\Documents\\integrador\\version";
        private readonly string NombreInstalador = "Integracion Online.exe";

        private readonly List<string> ArchivosExcluidos = new List<string>()
        {
            "actualizador.config",
            "actualizador.exe",
            "setup.exe",
            "setup_1.msi",
            "Integracion Online.zip", // igual que NombreInstalador
            "MaterialSkin.dll"
        };

        public FrmPrincipal()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            msk = MaterialSkinManager.Instance;
            msk.AddFormToManage(this);
            msk.Theme = MaterialSkinManager.Themes.LIGHT;
            msk.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue200, Accent.Blue200, TextShade.WHITE);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblEstado.Text = "Consultando última versión...";
            InitAsync();
        }


        private async void InitAsync()
        {
            try
            {
                string newVersion = await ConsultarVersionAsync();
                if (newVersion == null)
                {
                    //MessageBox.Show("El enlace de decarga no esta disponible en este momento, intente más tarde");
                    lblEstado.Text = "El enlace de decarga no esta disponible";
                    return;
                }
                lblEstado.Text = "Descargando actualización de integrador...";
                InitProgressBar();
                await DowloadInstalador(newVersion);
                lblEstado.Text = "Proceso finalizado";
                await Task.Delay(1000);
                string fileExe = Path.Combine(Application.StartupPath, NombreInstalador);
                if(File.Exists(fileExe))
                {
                    Process.Start(fileExe);
                } else
                {
                    MessageBox.Show("No fue posible iniciar la aplicación, inicie manualmente el integrador online");
                }
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: "  + ex.Message);
            }
        }

        private void InitProgressBar()
        {
            progressBar.Value = 0;
            progressBar.Maximum = 100;
            lblPorcentaje.Text = "";
        }

        private async Task<string> ConsultarVersionAsync()
        {
            string content = null;
            try
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(UrlVersion))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    response.EnsureSuccessStatusCode();
                    if(response.Content != null)
                    {
                        content = await response.Content.ReadAsStringAsync();
                    }                    
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\CEO_DESARROLLO_NET\repos\carlos\log.txt", ex.ToString());
            }
            return content;
        }

        private async Task DowloadInstalador(string newVersion)
        {            

            if (Directory.Exists(UbicacionInstalador))
            {
                Directory.Delete(UbicacionInstalador, true);
            }
            Directory.CreateDirectory(UbicacionInstalador);
            string pathInstalador = Path.Combine(UbicacionInstalador, NombreInstalador.Replace(".exe", ".zip"));
            if (await DownloadFileAsync(pathInstalador, newVersion))
            {
                await ExtractZipFileAsync(pathInstalador, UbicacionInstalador);
            }
        }

        private async Task<bool> DownloadFileAsync(string filePath, string newVersion)
        {
            bool ok = false;
            try
            {
                string url = string.Format(UrlApp, newVersion);
                using (var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    if(!response.IsSuccessStatusCode)
                    {                       
                        MessageBox.Show("El enlace de descarga no es accesible en este momento intente otra vez");
                        return ok;
                    }
                    response.EnsureSuccessStatusCode();

                    var totalBytes = response.Content.Headers.ContentLength.GetValueOrDefault();
                    if (totalBytes == 0)
                    {
                        MessageBox.Show("El enlace de descarga no es accesible en este momento intente otra vez");
                        return ok;
                    }
                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        var buffer = new byte[8192];
                        var totalReadBytes = 0L;
                        int readBytes;

                        while ((readBytes = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, readBytes);
                            totalReadBytes += readBytes;
                            int progressPercentage = (int)((totalReadBytes * 100) / totalBytes);
                            Invoke(new Action(() =>
                            {
                                progressBar.Value = progressPercentage;
                                lblPorcentaje.Text = $"{progressPercentage} %";
                            }));
                        }
                        ok = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error descarga: " + ex.Message);
            }
            
            return ok;            
        }

        private async Task ExtractZipFileAsync(string zipPath, string extractPath)
        {
            try
            {                
                lblEstado.Text = "Extrayendo componentes de actualización";
                await Task.Delay(1000);
                if (!File.Exists(zipPath))
                {
                    MessageBox.Show("La descarga se concluyo pero el archivo no se guardo en el equipo");
                    return;
                }
                if (!Directory.Exists(extractPath))
                {
                    Directory.CreateDirectory(extractPath);
                }                

                ZipFile.ExtractToDirectory(zipPath, extractPath);
                string file = Path.Combine(extractPath, "setup.exe");

                if (File.Exists(file))
                {
                    //IniciarInstalacion(extractPath, file);                    
                    lblEstado.Text = "Actualizando aplicación";                    
                    await Task.Run(() => CopyFiles(extractPath, Application.StartupPath));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al extraer archivos: " + ex.ToString());
            }
        }

        public void CopyFiles(string sourceDir, string destDir)
        {
            try
            {
               
                // Verifica que el directorio de destino exista
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                }

                // Obtiene todos los archivos del directorio de origen
                var files = Directory.GetFiles(sourceDir);
                int totalFiles = files.Length;
                int filesCopied = 0;

                // Configura el ProgressBar
                Invoke(new Action(() =>
                {
                    progressBar.Maximum = 100;
                    progressBar.Value = 0;
                    lblPorcentaje.Text = "";
                }));

                foreach (var file in files)
                {
                    // Extrae el nombre del archivo
                    string fileName = Path.GetFileName(file);

                    // Verifica si el archivo estÃ¡ en la lista de exclusiÃ³n
                    if (!ArchivosExcluidos.Contains(fileName.ToLower(), StringComparer.OrdinalIgnoreCase))
                    {
                        // Construye la ruta de destino
                        string destFile = Path.Combine(destDir, fileName);
                        // Copia el archivo
                        File.Copy(file, destFile, overwrite: true);                        
                    }
                    filesCopied++;
                    int porcentaje = (int)((float)filesCopied / totalFiles * 100);
                    Invoke(new Action(() =>
                    {
                        progressBar.Value = porcentaje;
                        lblPorcentaje.Text = $"{porcentaje}%";
                    }));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reemplazar componentes: " + ex.Message);
            }
        }
    }
}
