using Npgsql;
using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contasis.Clase
{
    public class ValidarVersion
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string VersionApp = "1.0.8";
        private readonly string UrlVersion = "https://videocontasis.com/Contasiscorp_2023/SQL_2023/Update_Integrador/version.txt";
        private readonly string UrlApp = "https://videocontasis.com/Contasiscorp_2023/SQL_2023/Update_Integrador/Integrador.zip";
        private readonly string UbicacionInstalador = @"C:\\Users\\Public\\Documents\\integrador\\version";
        private readonly string NombreInstalador = "Integrador.msi";
        private readonly string NombreServicio = "IntegradorOnline";

        private string CadenaSql;
        private string MotorBD;

        private readonly string MOTOR_POSTGRES = "POSTGRES";
        private readonly string MOTOR_SQLSERVER = "SQLSERVER";

       /// string zipPath = @"C:\Users\Public\Documents\Online.Zip";
        ///string extractPath = @"C:\Users\Public\Documents\extract";

        public ValidarVersion()
        {
            if (File.Exists(@"C:\Users\Public\Documents\SQL.txt"))
            {
                CadenaSql = Mostrar(File.ReadAllText(@"C:\Users\Public\Documents\SQL.txt"));
                MotorBD = MOTOR_SQLSERVER;
            }
            else if (File.Exists(@"C:\Users\Public\Documents\PostgreSQL.txt"))
            {
                CadenaSql = Mostrar(File.ReadAllText(@"C:\Users\Public\Documents\PostgreSQL.txt"));
                MotorBD = MOTOR_POSTGRES;
            }
        }
        
        private string Mostrar(string _cadena)
        {
            byte[] descrcriptar = Convert.FromBase64String(_cadena);
            return Encoding.Unicode.GetString(descrcriptar);
        }

        public async Task Validar()
        {            
            if(CadenaSql == null)
            {
                return;
            }

            try
            {
                // si version de bd es diferente a version de app actualizar bd.
                bool requiereActualizacion = false;
                // sql o postgres?
                if(MotorBD == MOTOR_POSTGRES)
                {
                    requiereActualizacion = await SincronizarVersionPostgresAsync();
                } else
                {
                    requiereActualizacion = await SincronizarVersionSqlServerAsync();
                }
                //requiereActualizacion = await SincronizarVersionSqlServerAsync();

                if (!requiereActualizacion)
                {
                    return;
                }

                DialogResult result = MessageBox.Show("Se encontró una versión más reciente\n¿Desea descargarla?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await DowloadInstalador();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar version del integrador");
            }
        }


        // Postgres
        private async Task<bool> SincronizarVersionPostgresAsync()
        {
            bool requiereActualizacion = false;
            using (NpgsqlConnection conexion = new NpgsqlConnection(CadenaSql))
            {
                conexion.Open();
                string versionBD = ExecSelectVersionPostgres(conexion);
                if (versionBD == null)
                {
                    ExecUpdateVersionPostgres(conexion, VersionApp);
                }
                else if (versionBD != VersionApp)
                {
                    ExecUpdateVersionPostgres(conexion, VersionApp);
                }
                versionBD = VersionApp;
                //
                string versionURL = await ConsultarVersionAsync(UrlVersion);
                requiereActualizacion = (versionBD != versionURL);
            }
            return requiereActualizacion;
        }
        
        private string ExecSelectVersionPostgres(NpgsqlConnection conexion)
        {
            string version = null;            
            using (NpgsqlCommand cmdp1 = new NpgsqlCommand("select cversion from public.fn_select_version();", conexion))
            {
                using (NpgsqlDataReader reader = cmdp1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        version = reader["cversion"].ToString();
                    }
                }
            }
            return version;
        }

        private string ExecUpdateVersionPostgres(NpgsqlConnection conexion, string version)
        {
            using (NpgsqlCommand cmdp1 = new NpgsqlCommand("select * from fn_actualizar_version(@p_version)", conexion))
            {
                cmdp1.Parameters.AddWithValue("@p_version", version);
                cmdp1.ExecuteNonQuery();
            }
            return version;
        }

        // sql server
        private async Task<bool> SincronizarVersionSqlServerAsync()
        {
            bool requiereActualizacion = false;
            using (SqlConnection conexion = new SqlConnection(CadenaSql))
            {
                conexion.Open();
                string versionBD = ExecSelectVersionSqlServer(conexion);
                if (versionBD == null)
                {
                    ExecUpdateVersionSqlServer(conexion, VersionApp);
                }
                else if (versionBD != VersionApp)
                {
                    ExecUpdateVersionSqlServer(conexion, VersionApp);
                }
                versionBD = VersionApp;
                //
                string versionURL = await ConsultarVersionAsync(UrlVersion);
                requiereActualizacion = (versionBD != versionURL);
            }
            return requiereActualizacion;
        }

        private string ExecSelectVersionSqlServer(SqlConnection conexion)
        {
            string version = null;
            using (SqlCommand command = new SqlCommand("dbo.sp_select_version", conexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            version = reader["cversion"].ToString();
                        }
                    }
                }
            }

            return version;
        }

        private string ExecUpdateVersionSqlServer(SqlConnection conexion, string version)
        {
            using (SqlCommand cmd = new SqlCommand("dbo.sp_actualizar_version", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@p_version", version));
                cmd.CommandTimeout = 5000;
                cmd.ExecuteNonQuery();
            }
            return version;
        }

        // General
        private async Task<string> ConsultarVersionAsync(string url)
        {
            string content = null;
            using (HttpResponseMessage response = await httpClient.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                content = await response.Content.ReadAsStringAsync();
            }
            return content;
        }

        private async Task DowloadInstalador()
        {

            if (Directory.Exists(UbicacionInstalador))
            {
                Directory.Delete(UbicacionInstalador, true);
            }
            Directory.CreateDirectory(UbicacionInstalador);
            string pathInstalador = UbicacionInstalador + NombreInstalador.Replace(".msi", ".zip");
            await DownloadFileAsync(pathInstalador);
            ExtractZipFile(pathInstalador, UbicacionInstalador);
        }

        private async Task DownloadFileAsync(string filePath)
        {
            using (HttpResponseMessage response = await httpClient.GetAsync(UrlApp))
            {
                response.EnsureSuccessStatusCode();
                byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();
                File.WriteAllBytes(filePath, fileBytes);
            }
        }

        private void ExtractZipFile(string zipPath, string extractPath)
        {
            

            if (!Directory.Exists(extractPath))
            {
                Directory.CreateDirectory(extractPath);
            }
            

            ZipFile.ExtractToDirectory(zipPath, extractPath);
            string file = Path.Combine(extractPath, NombreInstalador);

            if (File.Exists(file))
            {
                IniciarInstalacion(extractPath, file);
            }
        }

        private void IniciarInstalacion(string pathmsi, string msi)
        {
            try
            {
                DetenerServicio();
                MessageBox.Show(pathmsi + Environment.NewLine + msi);
                Process.Start(pathmsi);
                Process.Start(msi);
                /*var processInfo = new Process();
                processInfo.StartInfo.FileName = NombreInstalador;
                processInfo.StartInfo.Arguments = $"/i \"{msi}\" /qn";
                processInfo.StartInfo.UseShellExecute = false;

                processInfo.Start();*/
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible iniciar el instalador, por favor realice esta accion manualmente");
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

        private void DetenerServicio()
        {
            string arguments = $"stop {NombreServicio}";
            var processInfo = GetProcessStartInfo(arguments);

            try
            {
                using (var process = Process.Start(processInfo))
                {
                    process.WaitForExit();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al detener servico de integrador online");
            }
        }
    }
}
