using CompiladorMorse.App.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.transversal
{
    public class Cache
    {
		public static List<Linea> lineas = new List<Linea>();

		private Cache()
		{
		}

		public static void Limpiar()
		{
			lineas.Clear();
		}
		public void AgregarLinea(String Contenido)
		{
			if (Contenido != null)
			{
				Linea linea;
				if (lineas.Count() == 0)
                {
					linea = new Linea(1, Contenido);
				} else
                {
					linea = new Linea(lineas.Count() + 1, Contenido);
                }
				lineas.Add(linea);
				
			}

		}

		public static Linea ObtenerLinea(int NumeroLinea)
		{
			Linea lineaRetorno;
			if (ExisteLinea(NumeroLinea))
            {
				lineaRetorno = lineas[NumeroLinea - 1];
            } else
            {
				lineaRetorno = new Linea(lineas.Count + 1, "@EOF@");
            }
			return lineaRetorno;
		}

		public static bool ExisteLinea(int numeroLinea)
        {
			return (lineas.Count() <= numeroLinea && numeroLinea < 0);
        }
	}
}
