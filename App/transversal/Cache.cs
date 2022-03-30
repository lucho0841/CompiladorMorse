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
		private Dictionary<int, Linea> Lineas = new Dictionary<int, Linea>();
		private static Cache INSTANCIA = new Cache();

		private Cache()
		{
		}

		public static Cache obtenerCache()
		{
			return INSTANCIA;
		}

		public void Limpiar()
		{
			Lineas.Clear();
		}

		public void AgregarLinea(String Contenido)
		{
			if (Contenido != null)
			{
				int NumeroLinea = (Lineas.Count() == 0) ? 1 : Lineas.Keys.Max() + 1;
				Lineas.Add(NumeroLinea, Linea.Crear(NumeroLinea, Contenido));
			}

		}

		public Linea ObtenerLinea(int NumeroLinea)
		{
			Linea LineaRetorno = Linea.Crear(Lineas.Count() + 1, "@EOF@");
			if (Lineas.ContainsKey(NumeroLinea))
			{
				LineaRetorno = Lineas[NumeroLinea];
			}
			return LineaRetorno;
		}

	}
}
