using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.modelo
{
    public class Linea
    {
        private int LineNumber;
        private string ContentLine;

        public Linea(int lineNumber, string contentLine)
        {
            LineNumber = lineNumber;
            ContentLine = contentLine;
        }

        public static Linea CrearLinea(int lineNumber, string ContentLine)
        {
            return new Linea(lineNumber, ContentLine);
        }

        public int ObtenerNumeroLinea() => LineNumber;

        public string ObtenerContenidoLinea() => ContentLine;
    }
}
