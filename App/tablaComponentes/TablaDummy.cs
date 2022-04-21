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
        private TablaDummy()
        {
            AsignarTipo(transversal.TipoComponente.SIMBOLO);
        }

       public static TablaDummy ObtenerTabla()
        {
            return INSTANCIA;
        }
    }
}
