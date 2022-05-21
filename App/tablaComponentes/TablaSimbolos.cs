using CompiladorMorse.App.transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.TablaComponentes
{
    public class TablaSimbolos : TablaMaestra
    {
        private static TablaSimbolos INSTANCIA = new TablaSimbolos();
        private Dictionary<String, List<ComponenteLexico>> SIMBOLOS = new Dictionary<string, List<ComponenteLexico>>();
        private TablaSimbolos()
        {
            AsignarTipo(TipoComponente.SIMBOLO);
        }

        public static void Agregar(ComponenteLexico componente)
        {
            if (componente != null
                && !componente.ObtenerLexema().Equals("")
                && componente.ObtenerTipo().Equals(TipoComponente.SIMBOLO))
            {
                INSTANCIA.ObtenerSimbolo(componente.ObtenerLexema()).Add(componente);
            }
        }

        private List<ComponenteLexico> ObtenerSimbolo(String Lexema)
        {
            if (!SIMBOLOS.ContainsKey(Lexema))
            {
                SIMBOLOS.Add(Lexema, new List<ComponenteLexico>());
            }
            return SIMBOLOS[Lexema];
        }

        public static TablaSimbolos ObtenerTabla()
        {
            return INSTANCIA;
        }

        public static List<ComponenteLexico> ObtenerSimbolos()
        {
            return INSTANCIA.SIMBOLOS.Values.SelectMany(componente => componente).ToList();
        }

        public static void Limpiar()
        {
            INSTANCIA.SIMBOLOS.Clear();
        }
    }
}
