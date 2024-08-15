using Npgsql; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contasis
{
    public class ConexionPostgrelSql
    {
        NpgsqlConnection conex = new NpgsqlConnection();
        private string cadena;

        public string Cadena { get => cadena; set => cadena = value; }

        public void crearCadena(string _cadena)
        {
            cadena = _cadena;
            
            String cadenaconexion = cadena;
            try {
                conex.ConnectionString = cadenaconexion;
                conex.Open();
                 MessageBox.Show("Conexion valida para el Postgresql", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                Properties.Settings.Default.cadenaPost =cadena;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                conex.Close();
            }
            catch (NpgsqlException e)
            {
                Properties.Settings.Default.cadenaPost = "";
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                MessageBox.Show("No se pudo conectar al postgresql, error :"+e.ToString(), "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
                
            
        }


    }
}
