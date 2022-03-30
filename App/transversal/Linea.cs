using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.modelo
{
    public class Linea
    {
        private int NumeroLinea { get; set; }
        private String Contenido { get; set; }

        private Linea(int NumeroLinea, String Contenido)
        {
            this.NumeroLinea = NumeroLinea;
            this.Contenido = Contenido;
        }

        public static Linea CrearLinea(int lineNumber, string ContentLine)
        {
            return new Linea(lineNumber, ContentLine);
        }

        public static Linea Crear(int NumeroLinea, String Contenido)
        {
            return new Linea(NumeroLinea, Contenido);
        }

        public int ObtenerNumeroLinea()
        {
            return NumeroLinea;
        }

        public String ObtenerContenido()
        {
            return Contenido;
        }

        public bool EsFinArchivo()
        {
            return "@EOF@".Equals(Contenido);
        }
    }
}
