using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contasis.Clase
{
    
        internal class ConexionPostgreslContasis
    /**Clase para conectar solo al SQL Postgrel Contasis **/

    {
        private static ConexionPostgreslContasis cone1 = null;
        public NpgsqlConnection establecerconexion()
        {
            NpgsqlConnection cadena = new NpgsqlConnection();
            try
            {
                cadena.ConnectionString = "" + Properties.Settings.Default.cadenaPost;
              /*  MessageBox.Show(Properties.Settings.Default.cadenaPost);*/
            }
            /*(Exception ex)*/


            catch 
            {
                cadena = null;
                MessageBox.Show("No se establec la conexión a la base de datos del Contasis Corp. ", "Contasis Corp. final de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            return cadena;
        }
        public NpgsqlConnection establecerconexion2(string cadenanew)
        {
            NpgsqlConnection cadena = new NpgsqlConnection();
            try
            {
                cadena.ConnectionString = "" + cadenanew;
            }
            catch (Exception ex)
            {
                cadena = null;
                MessageBox.Show("No se establec la conexion " + ex.ToString(), "Contasis Corp.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return cadena;
        }
        public NpgsqlConnection establecerconexionPrincipal()
        {
            NpgsqlConnection cadena = new NpgsqlConnection();
            try
            {
                cadena.ConnectionString = "" + Properties.Settings.Default.cadenaPostPrincipal;
            }

            catch (Exception ex)
            {
                cadena = null;
                MessageBox.Show("No se establec la conexion " + ex.ToString(), "Contasis Corp. final de conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            return cadena;
        }
        public static ConexionPostgreslContasis Instancial()
        {
            if (cone1 == null)
            {
                cone1 = new ConexionPostgreslContasis();
            }
            return cone1;
        }

    }


}
