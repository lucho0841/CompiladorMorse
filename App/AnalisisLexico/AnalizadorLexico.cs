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
        private int puntero;
        private int numeroDeLineaActual;
        private Linea lineaActual;
        private String caracterActual;
        private String lexema;
        private int estadoActual;
        private bool continuarAnalisis = true;
        private ComponenteLexico componente;

        public AnalizadorLexico()
        {
            this.numeroDeLineaActual = 0;
            CargarNuevaLinea();
        }

        private void CargarNuevaLinea()
        {
            numeroDeLineaActual++;
            lineaActual = Cache.obtenerCache().ObtenerLinea(numeroDeLineaActual);
            numeroDeLineaActual = lineaActual.ObtenerNumeroLinea();
            InicializarPuntero();
        }

        private void InicializarPuntero()
        {
            puntero = 1;
        }

        private void DevolverPuntero()
        {
            if (puntero > 1)
            {
                puntero--;
            }
        }

        private void AdelantarPuntero()
        {
            puntero++;
        }

        private void LeerSiguienteCaracter()
        {
            if (lineaActual.EsFinArchivo())
            {
                caracterActual = lineaActual.ObtenerContenido();
            }
            else if (puntero > lineaActual.ObtenerContenido().Length)
            {
                caracterActual = "@FL@";
                AdelantarPuntero();
            }
            else
            {
                caracterActual = lineaActual.ObtenerContenido().Substring(puntero - 1, 1);
                AdelantarPuntero();
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


        public ComponenteLexico Analizador(bool Metodo)
        {
            resetearTexto();
            while (continuarAnalisis)
            {
                if (estadoActual == 0)
                {
                    LeerSiguienteCaracter();

                    while (" ".Equals(caracterActual))
                    {
                        LeerSiguienteCaracter();
                    }

                    if (esSimbolo())
                    {
                        estadoActual = 1;
                        lexema = lexema + caracterActual;
                    }
                    else if (esFinArchivo())
                    {
                        estadoActual = 4;
                    }
                    else if (esFinLinea())
                    {
                        estadoActual = 3;
                    }
                    else
                    {
                        estadoActual = 2;
                    }
                }


                else if (estadoActual == 1)
                {
                    continuarAnalisis = false;
                    DevolverPuntero();
                    CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                }
                else if (estadoActual == 2)
                {
                    continuarAnalisis = false;
                    CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                }
                else if (estadoActual == 3)
                {
                    CargarNuevaLinea();
                    CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                }
                else if (estadoActual == 4)
                {
                    continuarAnalisis = false;
                    CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                }
            }

            return TablaMaestra.SincronizarTabla(componente);
        }

        private void resetearTexto()
        {
            estadoActual = 0;
            caracterActual = "";
            continuarAnalisis = true;
            ResetearLexema();
            componente = null;
        }

        private void ResetearLexema()
        {
            lexema = "";
        }

        private void CrearComponenteSimbolo(String Lexema, String categoria, int NumeroLinea, int PosicionInicial, int PosicionFinal)
        {
            componente = ComponenteLexico.CrearComponenteSimbolo(Lexema, categoria, NumeroLinea, PosicionInicial, PosicionFinal);
        }


        /*public ComponenteLexico DevolverSiguienteComponente()
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

        }*/

    }
}
