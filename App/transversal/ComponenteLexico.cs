using CompiladorMorse.App.transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App
{
    public class ComponenteLexico
    {
        private String Lexema;
        private CategoriaGramatical categoria;
        private int NumeroLinea;
        private int posicionInicial;
        private int posicionFinal;

        private ComponenteLexico(String Lexedema, CategoriaGramatical categoria, int numeroLinea, int posicionInicial, int posicionFinal)
        {
            this.Lexema = Lexedema;
            this.categoria = categoria;
            this.NumeroLinea = numeroLinea;
            this.posicionFinal = posicionFinal;
            this.posicionInicial = posicionInicial;
        }

        public ComponenteLexico()
        {

        }


        public static ComponenteLexico CrearComponenteSimbolo(String Lexema, CategoriaGramatical categoria, int numeroLinea, int posicionInicial, int posicionFinal)
        {
            return new ComponenteLexico(Lexema, categoria, numeroLinea, posicionInicial, posicionFinal);
        }

        public String ObtenerLexema()
        {
            return Lexema;
        }

        public CategoriaGramatical ObtenerCategoria()
        {
            return categoria;
        }
       
        public int ObtenerNumeroLinea()
        {
            return NumeroLinea;
        }
        public int ObtenerPosicionFinal()
        {
            return posicionFinal;
        }
        public int ObtenerPosicionInicial()
        {
            return posicionInicial;
        }
        public override string ToString()
        {
            StringBuilder informacion = new StringBuilder();
            informacion.Append("Categoria: ").Append(CategoriaGramatical.SIMBOLO).Append(" ");
            informacion.Append("Lexema: ").Append(ObtenerLexema()).Append(" ");
            informacion.Append("Numero de Linea: ").Append(ObtenerNumeroLinea()).Append(" ");
            informacion.Append("Posicion Inicial de la linea: ").Append(ObtenerPosicionInicial()).Append(" ");
            informacion.Append("Posicion final de la linea: ").Append(ObtenerPosicionFinal()).Append(" ");



            return informacion.ToString();
        }
    }
}
