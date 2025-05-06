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

        public string  CrearCadena(string _cadena)
        {
            cadena = _cadena;
            string resultado;
            String cadenaconexion = cadena;
            try {
                conex.ConnectionString = cadenaconexion;
                conex.Open();
              /*   MessageBox.Show("Conexión valida para el Postgresql", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);*/

                resultado = "1";
                Properties.Settings.Default.cadenaPost =cadena;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                conex.Close();
            }
            catch 
            {
                resultado = "0";
                Properties.Settings.Default.cadenaPost = "";
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                MessageBox.Show("No se pudo conectar al postgresql, revise por favor sus credenciales y si esta configurado con el Contasis.", "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                
                

            }

            return resultado;
        }


    }
}
