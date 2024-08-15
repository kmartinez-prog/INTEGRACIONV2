using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contasis
{
    public class Servidor
    {
        public String Origen1 { get; set; }
        public String Servido { get; set; }
        public String usuario { get; set; }
        public String contrase { get; set; }
        public String basedate { get; set; }
        public String esquema { get; set; }


        public Servidor() { }

        public Servidor(string Origen1, string Servido, string usuario, string contrase, string basedate, string esquema)

        {
            this.Origen1 = Origen1;
            this.Servido = Servido;
            this.usuario = usuario;
            this.contrase = contrase;
            this.basedate = basedate;
            this.esquema = esquema;
        }
    }
}    