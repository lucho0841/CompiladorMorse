using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.transversal
{
    public class TablaMaestra
    {
        private TablaMaestra()
        {

        }

        public static ComponenteLexico SincronizarTabla(ComponenteLexico Componente)
        {
            if (Componente != null)
            {

                TablaSimbolos.Agregar(Componente);
            }
            return Componente;
        }
    }
}
