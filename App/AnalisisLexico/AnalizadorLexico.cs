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
        private List<string> caracteres;
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

        public List<string> DeconstruirCadena(string[] data)
        {
            caracteres = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    caracteres.Add(data[i][j].ToString());
                }
            }
            return caracteres;
        }

        private void CargarNuevaLinea()
        {
            numeroDeLineaActual++;
            lineaActual = Cache.ObtenerCache().ObtenerLinea(numeroDeLineaActual);
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

        /*private bool esIgual(string cadenaUno, string cadenaDos)
        {
            if (cadenaUno == null && cadenaDos == null)
            {
                return false;
            }
            else if (cadenaUno != null)
            {
                return true;
            }
            return cadenaUno.Equals(cadenaDos);
        }*/

        private bool esPunto()
        {
            return caracterActual.Equals(".");
        }

        private bool esGuion()
        {
            return caracterActual.Equals("-");
        }

        private bool esSeparador()
        {
            return caracterActual.Equals(" ");
        }

        private bool esSimbolo()
        {
            if (caracterActual.ToLower() == "a" || caracterActual.ToLower() == "e" || caracterActual.ToLower() == "i" || caracterActual.ToLower() == "o" || caracterActual.ToLower() == "u" || Char.IsDigit(caracterActual.ToCharArray()[0]))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool esFinLinea()
        {
            return caracterActual.Equals("@FL@");
        }

        private bool esFinArchivo()
        {
            return caracterActual.Equals("@EOF@");
        }



        public ComponenteLexico Analizador(bool metodo)
        {
            resetearTexto();
            if (metodo)
            {
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
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 2)
                    {
                        continuarAnalisis = false;
                        CrearComponenteSimbolo("?", CategoriaGramatical.ERROR, numeroDeLineaActual, puntero - 1, puntero - 1);
                    }
                    else if (estadoActual == 3)
                    {
                        continuarAnalisis = false;
                        CargarNuevaLinea();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.FIN_LINEA, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 4)
                    {
                        continuarAnalisis = false;
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.FIN_ARCHIVO, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                }
            } else
            {
                while (continuarAnalisis)
                {
                    if (estadoActual == 0)
                    {
                        LeerSiguienteCaracter();

                        while (" ".Equals(caracterActual))
                        {
                            LeerSiguienteCaracter();
                        }

                        if (esPunto())
                        {
                            estadoActual = 1;
                            lexema = lexema + caracterActual;
                        } else if (esGuion())
                        {
                            estadoActual = 2;
                            lexema = lexema + caracterActual;
                        } else if (esFinLinea())
                        {
                            estadoActual = 4;
                        }
                        else if (esFinArchivo())
                        {
                            estadoActual = 3;
                        }else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }

                    } else if (estadoActual == 1)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 6;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 7;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 5;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 2)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 30;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 31;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 3)
                    {
                        continuarAnalisis = false;
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.FIN_ARCHIVO, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 4)
                    {
                        continuarAnalisis = false;
                        CargarNuevaLinea();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.FIN_LINEA, numeroDeLineaActual, puntero - 1, puntero - 1);
                    }
                    else if (estadoActual == 5)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_E, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 6)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 10;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 11;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 9;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 7)
                    {
                        LeerSiguienteCaracter();
                        if (esGuion())
                        {
                            estadoActual = 27;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinLinea() || esFinArchivo())
                        {
                            estadoActual = 24;
                        }
                        else if (esPunto())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else
                        {
                            estadoActual= 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 9)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_I, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 10)
                    {
                        LeerSiguienteCaracter();
                        if (esGuion())
                        {
                            estadoActual = 15;
                            lexema = lexema + caracterActual;
                        }
                        else if (esPunto())
                        {
                            estadoActual = 14;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 11)
                    {
                        LeerSiguienteCaracter();
                        if (esGuion())
                        {
                            estadoActual = 25;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 12;
                        }
                        else if (esPunto())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        } else
                        {
                            estadoActual= 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 12)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_U, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 13)
                    {
                        LeerSiguienteCaracter();
                        if (esFinLinea() || esSeparador())
                        {
                            continuarAnalisis = false;
                            DevolverPuntero();
                            CrearComponenteSimbolo("?", CategoriaGramatical.ERROR, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                        } else
                        {
                            lexema = lexema + caracterActual;
                        }
                        
                    }
                    else if (estadoActual == 14)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 17;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 18;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 15)
                    {
                        LeerSiguienteCaracter();
                        if (esGuion())
                        {
                            estadoActual = 23;
                            lexema = lexema + caracterActual;
                        }
                        else if (esPunto())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual= 13;
                            lexema= lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 17)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea() || esFinArchivo())
                        {
                            estadoActual = 20;
                        }
                        else if (esPunto() || esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        } else {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 18)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea() )
                        {
                            estadoActual = 21;
                        }
                        else if (esGuion() || esPunto())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        } else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 20)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_5, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 21)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_4, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 23)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 51;
                        }
                        else if (esGuion() || esPunto())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 24)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_A, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 25)
                    {
                        LeerSiguienteCaracter();
                        if (esGuion())
                        {
                            estadoActual = 26;
                            lexema = lexema + caracterActual;
                        }
                        else if (esPunto())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual= 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 26)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea() || esFinArchivo())
                        {
                            estadoActual = 50;
                        }
                        else if (esGuion() || esPunto())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        } else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 27)
                    {
                        LeerSiguienteCaracter();
                        if (esGuion())
                        {
                            estadoActual = 28;
                            lexema = lexema + caracterActual;
                        }
                        else if (esPunto())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else {
                            estadoActual = 13;
                            lexema= lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 28)
                    {
                        LeerSiguienteCaracter();
                        if (esGuion())
                        {
                            estadoActual = 29;
                            lexema = lexema + caracterActual;
                        }
                        else if (esPunto())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 29)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 52;
                        }
                        else if (esPunto() || esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        } else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 30)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 32;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 31)
                    {
                        LeerSiguienteCaracter();
                        if (esGuion())
                        {
                            estadoActual = 37;
                            lexema = lexema + caracterActual;
                        }else if (esPunto())
                        {
                            estadoActual = 36;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema= lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 32)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 33;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema= lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 33)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 34;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual= 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 34)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea() )
                        {
                            estadoActual = 35;
                        }
                        else if (esPunto() || esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        } else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 35)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_6, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 36)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 38;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 37)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 42;
                            lexema = lexema + caracterActual;
                        } else if (esGuion())
                        {
                            estadoActual = 43;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinArchivo() || esFinLinea() )
                        {
                            estadoActual = 41;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 38)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 39;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual= 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 39)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 40;
                        }
                        else if (esPunto() || esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        } else
                        {
                            estadoActual = 13;
                            lexema= lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 40)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_7, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 41)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_O, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 42)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 44;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 43)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 46;
                            lexema = lexema + caracterActual;
                        } else if (esGuion())
                        {
                            estadoActual = 47;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema= lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 44)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 45;
                        }
                        else if (esPunto() || esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        } else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 45)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_8, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 46)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea() )
                        {
                            estadoActual = 48;
                        }
                        else if (esPunto() || esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        } else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 47)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea() )
                        {
                            estadoActual = 49;
                        }
                        else if (esPunto() || esGuion())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        } else
                        {
                            estadoActual = 13;
                            lexema= lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 48)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_9, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 49)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_0, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 50)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_2, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 51)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_3, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 52)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_1, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }

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

        private void CrearComponenteSimbolo(String Lexema, CategoriaGramatical categoria, int NumeroLinea, int PosicionInicial, int PosicionFinal)
        {
            componente = ComponenteLexico.CrearComponenteSimbolo(Lexema, categoria, NumeroLinea, PosicionInicial, PosicionFinal);
        }
    }
}
