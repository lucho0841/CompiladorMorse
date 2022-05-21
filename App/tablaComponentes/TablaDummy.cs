using CompiladorMorse.App.transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.TablaComponentes
{
    public class TablaDummy : TablaMaestra
    {
        private static TablaDummy INSTANCIA = new TablaDummy();
        private Dictionary<String, List<ComponenteLexico>> DUMMYS = new Dictionary<string, List<ComponenteLexico>>();
        private TablaDummy()
        {
            AsignarTipo(TipoComponente.SIMBOLO);
        }

        public static void Agregar(ComponenteLexico componente)
        {
            if (componente != null
                && !componente.ObtenerLexema().Equals("")
                && componente.ObtenerTipo().Equals(TipoComponente.DUMMY))
            {
                INSTANCIA.ObtenerDummy(componente.ObtenerLexema()).Add(componente);
            }
        }

        private List<ComponenteLexico> ObtenerDummy(String Lexema)
        {
            if (!DUMMYS.ContainsKey(Lexema))
            {
                DUMMYS.Add(Lexema, new List<ComponenteLexico>());
            }
            return DUMMYS[Lexema];
        }

        public static TablaDummy ObtenerTabla()
        {
            return INSTANCIA;
        }

        public static List<ComponenteLexico> ObtenerDummys()
        {
            return INSTANCIA.DUMMYS.Values.SelectMany(componente => componente).ToList();
        }

        public static void Limpiar()
        {
            INSTANCIA.DUMMYS.Clear();
        }
    }
}
