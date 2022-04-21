using CompiladorMorse.App.transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.TablaComponentes
{
    public class TablaMaestra
    {
        private Dictionary<string, List<ComponenteLexico>> Tabla = new Dictionary<string, List<ComponenteLexico>>();
        private TipoComponente tipo;

        protected void AsignarTipo(TipoComponente tipo)
        {
            this.tipo = tipo;
        }
        public virtual void Agregar(ComponenteLexico componente)
        {
            if (componente != null && tipo.Equals(componente.ObtenerTipo()))
            {
                ObtenerComponentes(componente.ObtenerLexema()).Add(componente);
            }
        }

        private List<ComponenteLexico> ObtenerComponentes(string lexema)
        {
            if (!Tabla.ContainsKey(lexema))
            {
                Tabla.Add(lexema, new List<ComponenteLexico>());
            }
            return Tabla[lexema];
        }

        public List<ComponenteLexico> ObtenerComponentes()
        {
            List<ComponenteLexico> lista = new List<ComponenteLexico>();
            foreach (List<ComponenteLexico> componentes in Tabla.Values)
            {
                lista.AddRange(componentes);
            }
            return lista;
        }

        public void Reiniciar()
        {
            Tabla.Clear();
        }
    }
}
