using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.AnalisisSintactico
{
    public class AnalizadorSintactico
    {
        private ComponenteLexico componente;
        private CompiladorMorse.App.AnalizadorLexico.AnalizadorLexico analizadorLexico = CompiladorMorse.App.AnalizadorLexico.AnalizadorLexico.crear();
        private Stack<double> pila = new Stack<double>();

        public void analizar()
        {

        }
        private void pedirComponente()
        {
            componente = analizadorLexico.Analizador(true);
        }
        private void primera()
        {
            segunda();
            primeraPrima();
        }

        private void primeraPrima()
        {

        }

        private void segunda()
        {
            tercera();
            segundaPrima();
        }

        private void segundaPrima()
        {

        }

        private void tercera()
        {
            if ("ENTERO".Equals(componente.ObtenerCategoria()))
            {
                pila.Push(Convert.ToInt32(componente.ObtenerLexema()));
                pedirComponente();
            }
            else if ("DECIMAL".Equals(componente.ObtenerCategoria()))
            {
                pila.Push(Convert.ToDouble(componente.ObtenerLexema()));
                pedirComponente();
            }
            else if ("PARENTESIS".Equals(componente.ObtenerCategoria()))
            {
                pedirComponente();
                primera();
            }else
            {
                //reportar error
                throw new Exception("Se presentó error");
            }
        }
    }
}
