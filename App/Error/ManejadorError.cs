using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.Error
{
    public class ManejadorError
    {
        private Dictionary<TipoError, List<ComponenteError>> errores;
        private static ManejadorError INSTANCIA = new ManejadorError();
        private TipoError tipo;

        private ManejadorError()
        {
            Reiniciar();
        }

        public void Reiniciar()
        {
            errores = new Dictionary<TipoError, List<ComponenteError>>();
            errores.Add(TipoError.LEXICO, new List<ComponenteError>());
            errores.Add(TipoError.SINTACTICO, new List<ComponenteError>());
            errores.Add(TipoError.SEMANTICO, new List<ComponenteError>());
        }

        public static ManejadorError ObtenerManejadorError()
        {
            return INSTANCIA;
        }

        public void agregar(ComponenteError error)
        {
            if (error != null)
            {
                errores[error.ObtenerTipo()].Add(error);
            }
        }

        public bool hayErrores(TipoError tipo)
        {
            return errores[tipo].Count() > 0;
        }

        public bool hayErrores()
        {
            return hayErrores(TipoError.LEXICO) || hayErrores(TipoError.SINTACTICO) || hayErrores(TipoError.SEMANTICO);
        }

        public List<ComponenteError> ObtenerErrores()
        {
            List<ComponenteError> listaErrores = new List<ComponenteError>();
            foreach (List<ComponenteError> componentes in errores.Values)
            {
                listaErrores.AddRange(componentes);
            }
            return listaErrores;
        }

        public static void Reportar(ComponenteError Error)
        {
            if (Error != null)
            {
                ObtenerErrores(Error.ObtenerTipo()).Add(Error);
            }
        }

        public TipoError ObtenerTipo()
        {
            return tipo;
        }

        public static List<ComponenteError> ObtenerErrores(TipoError Tipo)
        {
            return INSTANCIA.errores[Tipo];
        }

        public static bool HayErrores()
        {
            return HayErroresLexicos() || HayErroresSemanticos() || HayErroresSintancticos();
        }

        public static bool HayErroresLexicos()
        {
            return HayErrores(TipoError.LEXICO);
        }
        public static bool HayErroresSintancticos()
        {
            return HayErrores(TipoError.SINTACTICO);
        }
        public static bool HayErroresSemanticos()
        {
            return HayErrores(TipoError.SEMANTICO);
        }

        public static bool HayErrores(TipoError Tipo)
        {
            return ObtenerErrores(Tipo).Count > 0;
        }
    }


}
