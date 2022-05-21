using CompiladorMorse.App.transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.TablaComponentes
{
    public class TablaPalabraReservada : TablaMaestra
    {
        private static TablaPalabraReservada INSTANCIA = new TablaPalabraReservada();
        private Dictionary<String, List<ComponenteLexico>> TABLA_PALABRAS = new Dictionary<string, List<ComponenteLexico>>();
        private TablaPalabraReservada()
        {
            AsignarTipo(TipoComponente.PALABRA_RESERVADA);
        }

        public static void Agregar(ComponenteLexico componente)
        {
            if (componente != null
                && !componente.ObtenerLexema().Equals("")
                && componente.ObtenerTipo().Equals(TipoComponente.PALABRA_RESERVADA))
            {
                INSTANCIA.ObtenerPalabraReservada(componente.ObtenerLexema()).Add(componente);
            }
        }

        private List<ComponenteLexico> ObtenerPalabraReservada(String Lexema)
        {
            if (!TABLA_PALABRAS.ContainsKey(Lexema))
            {
                TABLA_PALABRAS.Add(Lexema, new List<ComponenteLexico>());
            }
            return TABLA_PALABRAS[Lexema];
        }

        public static TablaPalabraReservada ObtenerTabla()
        {
            return INSTANCIA;
        }

        public static List<ComponenteLexico> ObtenerPalabrasReservadas()
        {
            return INSTANCIA.TABLA_PALABRAS.Values.SelectMany(componente => componente).ToList();
        }

        public static void Limpiar()
        {
            INSTANCIA.TABLA_PALABRAS.Clear();
        }
    }
}
