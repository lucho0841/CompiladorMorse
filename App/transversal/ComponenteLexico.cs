using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App
{
    public class ComponenteLexico
    {
        public int numeroLinea;
        public int posicionInicial;
        public int posicionFinal;
        public string categoria;
        public string lexema;

        private ComponenteLexico(string categoria, string lexema, int numeroLinea, int posicionInicial, int posicionFinal)
        {
            this.numeroLinea = numeroLinea;
            this.posicionInicial = posicionInicial;
            this.posicionFinal = posicionFinal;
            this.categoria = categoria;
            this.lexema = lexema;
        }

        public static ComponenteLexico Crear(string _lexema, string _categoria, int _numeroLinea, int _posicionInicial, int _posicionFinal)
        {
            return new ComponenteLexico(_lexema, _categoria, _numeroLinea, _posicionInicial, _posicionFinal);
        }

        public int obtenerLinea()
        {
            return numeroLinea;
        }
        public int obtenerPosInicial()
        {
            return posicionInicial;
        }
        public int obtenerPosFinal()
        {
            return posicionFinal;
        }
        public string obtenerCategoria()
        {
            return categoria;
        }
        public string obtenerLexema()
        {
            return lexema;
        }
    }
}
