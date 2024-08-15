using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Contasis.Clase
{
    internal class ConexionSql
    /**Clase para conectar solo al SQL Server **/

    {
        private static ConexionSql cone = null;
        public SqlConnection establecerconexion()
        {
        SqlConnection cadena = new SqlConnection();
        try
        {
                cadena.ConnectionString = ""+Properties.Settings.Default.cadenaSql;
        }
        catch(Exception ex)
        {
                cadena=null;
                MessageBox.Show("No se establec la conexion " + ex.ToString(), "Contasis Corp. ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        return cadena;
        }
        public static ConexionSql Instancial()
        {
            if (cone == null)
            {
                cone = new ConexionSql();
            }
            return cone;
        }
        
    }
}
