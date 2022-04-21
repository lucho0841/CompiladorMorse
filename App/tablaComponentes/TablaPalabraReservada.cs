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
        private static Dictionary<string, ComponenteLexico> TABLA_PALABRAS = new Dictionary<string, ComponenteLexico>();
        private TablaPalabraReservada()
        {
            AsignarTipo(transversal.TipoComponente.SIMBOLO);
        }

        private void Inicializar()
        {
            TABLA_PALABRAS.Add(".....", ComponenteLexico.CrearComponentePalabraReservada(".....", transversal.CategoriaGramatical.SIMBOLO_MORSE_5));
        }

        public static TablaPalabraReservada ObtenerTabla()
        {
            return INSTANCIA;
        }

        public void ComprobarPalabraReservada(ComponenteLexico componente)
        {
            if (componente != null && TABLA_PALABRAS.ContainsKey(componente.ObtenerLexema()))
            {
                componente = ComponenteLexico.CrearComponentePalabraReservada(componente.ObtenerLexema(), TABLA_PALABRAS[componente.ObtenerLexema()].ObtenerCategoria(),
                    componente.ObtenerNumeroLinea(), componente.ObtenerPosicionInicial(), componente.ObtenerPosicionFinal());
            }
        }

        public override void Agregar(ComponenteLexico componente)
        {
            ComprobarPalabraReservada(componente);
            base.Agregar(componente);
        }
    }
}
