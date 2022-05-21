using CompiladorMorse.App.transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.TablaComponentes
{
    public class TablaLiterales : TablaMaestra
    {
        private static TablaLiterales INSTANCIA = new TablaLiterales();
        private Dictionary<String, List<ComponenteLexico>> LITERALES = new Dictionary<string, List<ComponenteLexico>>();
        private TablaLiterales()
        {
            AsignarTipo(TipoComponente.LITERAL);
        }

        public static void Agregar(ComponenteLexico componente)
        {
            if (componente != null
                && !componente.ObtenerLexema().Equals("")
                && componente.ObtenerTipo().Equals(TipoComponente.LITERAL))
            {
                INSTANCIA.ObtenerLiteral(componente.ObtenerLexema()).Add(componente);
            }
        }

        private List<ComponenteLexico> ObtenerLiteral(String Lexema)
        {
            if (!LITERALES.ContainsKey(Lexema))
            {
                LITERALES.Add(Lexema, new List<ComponenteLexico>());
            }
            return LITERALES[Lexema];
        }

        public static TablaLiterales ObtenerTabla()
        {
            return INSTANCIA;
        }

        public static List<ComponenteLexico> ObtenerLiterales()
        {
            return INSTANCIA.LITERALES.Values.SelectMany(componente => componente).ToList();
        }
        public static void Limpiar()
        {
            INSTANCIA.LITERALES.Clear();
        }
    }
}
