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
        private TablaSimbolos()
        {
            AsignarTipo(transversal.TipoComponente.SIMBOLO);
        }

       public static TablaSimbolos ObtenerTabla()
        {
            return INSTANCIA;
        }
    }
}
