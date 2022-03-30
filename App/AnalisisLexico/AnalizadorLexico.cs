using CompiladorMorse.App.modelo;
using CompiladorMorse.App.transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompiladorMorse.App.AnalizadorLexico
{
    public class AnalizadorLexico
    {
        private int apuntador;
        private int numeroLineaActual;
        private Linea LineaActual;
        private string caracterActual;
        private string contenidoLineaActual;
        private string lexema;
        private int estadoActual;
        private ComponenteLexico retorno;
        private bool continuarAnalisis = false;

        public AnalizadorLexico()
        {
            numeroLineaActual = 0;
            CargarNuevaLinea();
        }

        private void CargarNuevaLinea()
        {
            numeroLineaActual = numeroLineaActual + 1;
            LineaActual = Cache.ObtenerLinea(numeroLineaActual);
            contenidoLineaActual = LineaActual.ObtenerContenidoLinea();
            numeroLineaActual = LineaActual.ObtenerNumeroLinea();
            InicializarApuntador();
        }

        private void InicializarApuntador()
        {
            apuntador = 1;
        }

        private void DevolverApuntador()
        {
            if (apuntador > 1)
            {
                apuntador = apuntador - 1;
            }
        }

        private void AdelantarApuntador()
        {
            apuntador = apuntador + 1;
        }

        private void LeerSiguienteCaracter()
        {
            if (CategoriaGramatical.FIN_ARCHIVO.Equals(contenidoLineaActual))
            {
                caracterActual = contenidoLineaActual;
            }
            else if (apuntador > contenidoLineaActual.Length)
            {
                caracterActual = CategoriaGramatical.FIN_LINEA;
            }
            else
            {
                caracterActual = contenidoLineaActual.Substring(apuntador - 1, 1);
                AdelantarApuntador();
            }
        }

        private bool esIgual(string cadenaUno, string cadenaDos)
        {
            if (cadenaUno == null && cadenaDos == null)
            {
                return false;
            } else if (cadenaUno != null)
            {
                return true;
            }
            return cadenaUno.Equals(cadenaDos);
        }

        private bool esSimbolo()
        {
            return Char.IsLetterOrDigit(caracterActual.ToCharArray()[0]);
        }

        private bool esFinLinea()
        {
            return esIgual(CategoriaGramatical.FIN_LINEA, caracterActual);
        }

        private bool esFinArchivo()
        {
            return esIgual(CategoriaGramatical.FIN_ARCHIVO, caracterActual);
        }

        public ComponenteLexico DevolverSiguienteComponente()
        {
            retorno = null;
            estadoActual = 0;
            lexema = "";
            continuarAnalisis = true;

            while (continuarAnalisis)
            {
                if (estadoActual == 0)
                {
                    LeerSiguienteCaracter();

                    while(" ".Equals(caracterActual))
                    {
                        LeerSiguienteCaracter();
                    }

                    if (esSimbolo())
                    {
                        estadoActual = 1;
                        lexema = lexema + caracterActual;
                    } else if (esFinArchivo())
                    {
                        estadoActual = 4;
                    } else if (esFinLinea())
                    {
                        estadoActual = 3;
                    } else
                    {
                        estadoActual = 2;
                    }
                } else if (estadoActual == 1)
                {
                    continuarAnalisis = false;
                    DevolverApuntador();
                    retorno = ComponenteLexico.Crear(lexema, CategoriaGramatical.SIMBOLO, numeroLineaActual, apuntador - lexema.Length, apuntador - 1);
                } else if (estadoActual == 2)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.Crear(lexema, CategoriaGramatical.ERROR, numeroLineaActual, apuntador - lexema.Length, apuntador - 1);
                } else if (estadoActual == 3)
                {
                    CargarNuevaLinea();
                    retorno = ComponenteLexico.Crear("", CategoriaGramatical.FIN_LINEA, numeroLineaActual, apuntador - lexema.Length, apuntador - 1);
                } else if (estadoActual == 4)
                {
                    continuarAnalisis = false;
                    retorno = ComponenteLexico.Crear(lexema, CategoriaGramatical.FIN_ARCHIVO, numeroLineaActual, apuntador - lexema.Length, apuntador - 1);
                }
            }

            return retorno;

        }
    }
}
