using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.Error
{
    public class ComponenteError
    {
        private int numeroLinea;
        private int posicionInicial;
        private int posicionFinal;
        private string causa;
        private string falla;
        private string solucion;
        private TipoError tipo;

        private ComponenteError(int numeroLinea, int posicionInicial, int posicionFinal, string causa, string falla, string solucion)
        {
            this.numeroLinea = numeroLinea;
            this.posicionInicial = posicionInicial;
            this.posicionFinal = posicionFinal;
            this.causa = causa;
            this.falla = falla;
            this.solucion = solucion;
        }

        public ComponenteError()
        {

        }

        public static ComponenteError crearErrorLexico(int numeroLinea, int posicionInicial, int posicionFinal, string causa, string falla, string solucion)
        {
            return new ComponenteError(numeroLinea, posicionInicial, posicionFinal, causa, falla, solucion, TipoError.LEXICO);
        }

        public static ComponenteError crearErrorSintactico(int numeroLinea, int posicionInicial, int posicionFinal, string causa, string falla, string solucion)
        {
            return new ComponenteError(numeroLinea, posicionInicial, posicionFinal, causa, falla, solucion, TipoError.SINTACTICO);
        }

        public static ComponenteError crearErrorSemantico(int numeroLinea, int posicionInicial, int posicionFinal, string causa, string falla, string solucion)
        {
            return new ComponenteError(numeroLinea, posicionInicial, posicionFinal, causa, falla, solucion, TipoError.SEMANTICO);
        }



        public int ObtenerNumeroLinea()
        {
            return numeroLinea;
        }
        public int ObtenerPosicionFinal()
        {
            return posicionFinal;
        }
        public int ObtenerPosicionInicial()
        {
            return posicionInicial;
        }

        public string ObtenerCausa()
        {
            return causa;
        }

        public string ObtenerFalla()
        {
            return falla;
        }

        public string ObtenerSolucion()
        {
            return solucion;
        }

        public TipoError ObtenerTipo()
        {
            return tipo;
        }
    }

    
}
