using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contasis.Clase
{
    public class ValidarVersion
    {
        private readonly HttpClient httpClient;
        private readonly string VersionApp = "24.0.4";

        private readonly string UrlVersion = "https://videocontasis.com/Contasiscorp_2023/SQL_2023/Update_Integrador/version.txt?v=" + DateTime.Now.ToString("ddMMyyyyHHmmss");
        

      /// private readonly string UrlVersion = "https://contasiscorpfab.s3.amazonaws.com/version.txt";
      /// private readonly string UrlVersion = "https://contasiscorpfab.s3.amazonaws.com/version.txt";

        private string CadenaSql;
        private string MotorBD;

        private readonly string MOTOR_POSTGRES = "POSTGRES";
        private readonly string MOTOR_SQLSERVER = "SQLSERVER";

        public ValidarVersion()
        {

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            httpClient = new HttpClient();

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
        public void CopyFilesActualizador()
        {
            try
            {
                string versionFolderPath = Path.Combine(Application.StartupPath, "version");
                if (!Directory.Exists(versionFolderPath)) { return; }
                string[] files = { "Actualizador.exe", "Actualizador.exe.config", "MaterialSkin.dll" };


                foreach (string file in files)
                {
                    string sourceFile = Path.Combine(versionFolderPath, file);
                    if (File.Exists(sourceFile))
                    {
                        string destinationFile = Path.Combine(Application.StartupPath, file);
                        File.Copy(sourceFile, destinationFile, overwrite: true);
                    }
                    
                }

                Directory.Delete(versionFolderPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reemplazar el actualizador " + ex.Message);
            }
        }

        public async Task Validar()
        {
            if (CadenaSql == null)
            {
                return;
            }

            try
            {
                CopyFilesActualizador();
                string versionURL = await ConsultarVersionAsync();
                if (versionURL == null)
                {
                    return;
                }
                // si version de bd es diferente a version de app actualizar bd.
                bool requiereActualizacion = false;
                // sql o postgres?
                if (MotorBD == MOTOR_POSTGRES)
                {
                    requiereActualizacion = SincronizarVersionPostgres(versionURL);
                }
                else
                {
                    requiereActualizacion = SincronizarVersionSqlServer(versionURL);
                }
                //requiereActualizacion = await SincronizarVersionSqlServerAsync();

                if (!requiereActualizacion)
                {
                    return;
                }

                DialogResult result = MessageBox.Show("Se encontró una versión más reciente\n¿Desea descargarla?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string appActualizador = Path.Combine(Application.StartupPath, "actualizador.exe");
                    Process.Start(appActualizador);
                    Environment.Exit(0);
                    //await DowloadInstalador(versionURL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar version del integrador: " + ex.Message);
            }
        }


        // Postgres
        private bool SincronizarVersionPostgres(string newVersion)
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
                    ExecScriptUpdatePostgres(conexion);
                    ExecUpdateVersionPostgres(conexion, VersionApp);
                }
                versionBD = VersionApp;
                //
                requiereActualizacion = (versionBD != newVersion);
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

        private void ExecUpdateVersionPostgres(NpgsqlConnection conexion, string version)
        {
            using (NpgsqlCommand cmdp1 = new NpgsqlCommand("select * from fn_actualizar_version(@p_version)", conexion))
            {
                cmdp1.Parameters.AddWithValue("@p_version", version);
                cmdp1.ExecuteNonQuery();
            }
        }

        private void ExecScriptUpdatePostgres(NpgsqlConnection conexion)
        {
            /*string sql = Properties.Resources.ScriptActualizacionPostgres;
            using (NpgsqlCommand cmdp1 = new NpgsqlCommand(sql, conexion))
            {                
                cmdp1.ExecuteNonQuery();
            }*/
        }

        // sql server
        private bool SincronizarVersionSqlServer(string newVersion)
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
                    ExecScriptUpdateSqlServer(conexion);
                    ExecUpdateVersionSqlServer(conexion, VersionApp);
                }
                versionBD = VersionApp;
                requiereActualizacion = (versionBD != newVersion);
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

        private void ExecUpdateVersionSqlServer(SqlConnection conexion, string version)
        {
            using (SqlCommand cmd = new SqlCommand("dbo.sp_actualizar_version", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@p_version", version));
                cmd.CommandTimeout = 5000;
                cmd.ExecuteNonQuery();
            }
        }

        private void ExecScriptUpdateSqlServer(SqlConnection conexion)
        {
            /*string sql = Properties.Resources.ScriptActualizacionSQLServer;
            using (SqlCommand command = new SqlCommand(sql, conexion))
            {
                command.CommandTimeout = 5000;
                command.ExecuteNonQuery();
            }*/
        }

        // General
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
                    if (response.Content != null)
                    {
                        content = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                string pathLog = Path.Combine(Application.StartupPath, "logs");
                if (!Directory.Exists(pathLog))
                {
                    Directory.CreateDirectory(pathLog);
                }
                string logFile = Path.Combine(pathLog, ("error-" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"));
                File.WriteAllText(logFile, ex.ToString());
                MessageBox.Show("No fue posible buscar nuevas actualizaciones");
            }
            return content;
        }

    }
}