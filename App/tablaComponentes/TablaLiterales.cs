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
        private TablaLiterales()
        {
            AsignarTipo(transversal.TipoComponente.LITERAL);
        }

       public static TablaLiterales ObtenerTabla()
        {
            return INSTANCIA;
        }
    }
}
