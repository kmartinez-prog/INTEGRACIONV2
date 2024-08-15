using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Contasis.Clase
{
    class usuarioPropiedad
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string password { get; set; }
    }
    internal class esconder
    {
        public string Ocultar(string _cadena)
        {
            string resultado = string.Empty;
            Byte[] encriptar = System.Text.Encoding.Unicode.GetBytes(_cadena);
            resultado = Convert.ToBase64String(encriptar);
            return resultado;
            
        }
        public string Mostrar(string _cadena)
        {
            string resultado = string.Empty;
            Byte[] descrcriptar = Convert.FromBase64String(_cadena);
            resultado = System.Text.Encoding.Unicode.GetString(descrcriptar);
            return resultado;
        }
    }

}
