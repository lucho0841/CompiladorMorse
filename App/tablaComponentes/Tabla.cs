using CompiladorMorse.App.transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.TablaComponentes
{
    public class Tabla
    {
        private static Tabla INSTANCIA = new Tabla();

        private Tabla()
        {

        }

        public static Tabla ObtenerTabla()
        {
            return INSTANCIA;
        }

        public void Agregar(ComponenteLexico componente)
        {
            TablaPalabraReservada.ObtenerTabla().Agregar(componente);
        }

        public void Reiniciar()
        {
            TablaPalabraReservada.ObtenerTabla().Reiniciar();
        }

        public List<ComponenteLexico> ObtenerComponentes(TipoComponente tipo)
        {
            List<ComponenteLexico> lista = new List<ComponenteLexico>();

            if (TipoComponente.LITERAL.Equals(tipo))
            {
                lista = TablaLiterales.ObtenerTabla().ObtenerComponentes();
            } else if (TipoComponente.PALABRA_RESERVADA.Equals(tipo))
            {
                lista = TablaPalabraReservada.ObtenerTabla().ObtenerComponentes();
            }
            else if (TipoComponente.SIMBOLO.Equals(tipo))
            {
                lista = TablaSimbolos.ObtenerTabla().ObtenerComponentes();
            }
            else if (TipoComponente.DUMMY.Equals(tipo))
            {
                lista = TablaDummy.ObtenerTabla().ObtenerComponentes();
            }
            return lista;
        }
    }
}
