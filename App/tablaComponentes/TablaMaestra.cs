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

        public static ComponenteLexico SincronizarTabla(ComponenteLexico Componente)
        {
            if (Componente != null)
            {
                //Componente = TablaPalabraReservadas.ComprobarPalabraReservada(Componente);

                switch (Componente.ObtenerTipo())
                {
                    case TipoComponente.DUMMY:
                        TablaDummy.Agregar(Componente);
                        break;
                    case TipoComponente.PALABRA_RESERVADA:
                        TablaPalabraReservada.Agregar(Componente);
                        break;
                    case TipoComponente.LITERAL:
                        TablaLiterales.Agregar(Componente);
                        break;
                    case TipoComponente.SIMBOLO:
                        TablaSimbolos.Agregar(Componente);
                        break;

                }
            }
            return Componente;
        }

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
        public static void Limpiar()
        {
            TablaDummy.Limpiar();
            TablaPalabraReservada.Limpiar();
            TablaLiterales.Limpiar();
            TablaSimbolos.Limpiar();
        }

        public void Reiniciar()
        {
            Tabla.Clear();
        }
    }
}
