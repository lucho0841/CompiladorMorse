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
        private String categoria = CategoriaGramatical.SIMBOLO;
        private int NumeroLinea;
        private int posicionInicial;
        private int posicionFinal;
        private String Tipo = CategoriaGramatical.SIMBOLO;

        private ComponenteLexico(String Lexedema, String categoria, int numeroLinea, int posicionInicial, int posicionFinal, String Componente)
        {
            this.Lexema = Lexedema;
            this.categoria = categoria;
            this.NumeroLinea = numeroLinea;
            this.posicionFinal = posicionFinal;
            this.posicionInicial = posicionInicial;
            this.Tipo = Componente;
        }


        public static ComponenteLexico CrearComponenteSimbolo(String Lexema, String categoria, int numeroLinea, int posicionInicial, int posicionFinal)
        {
            return new ComponenteLexico(Lexema, categoria, numeroLinea, posicionInicial, posicionFinal, CategoriaGramatical.SIMBOLO);
        }

        public String ObtenerLexema()
        {
            return Lexema;
        }
       
        public int ObtenerNumeroLinea()
        {
            return NumeroLinea;
        }
        public int ObtenerPosicionFinal()
        {
            return posicionFinal;
        }
        public int ObetenerPosicionInicial()
        {
            return posicionInicial;
        }
        public override string ToString()
        {
            StringBuilder informacion = new StringBuilder();
            informacion.Append("Categoria: ").Append(CategoriaGramatical.SIMBOLO).Append(" ");
            informacion.Append("Lexema: ").Append(ObtenerLexema()).Append(" ");
            informacion.Append("Numero de Linea: ").Append(ObtenerNumeroLinea()).Append(" ");
            informacion.Append("Posicion Inicial de la linea: ").Append(ObetenerPosicionInicial()).Append(" ");
            informacion.Append("Posicion final de la linea: ").Append(ObtenerPosicionFinal()).Append(" ");



            return informacion.ToString();
        }
    }
}
