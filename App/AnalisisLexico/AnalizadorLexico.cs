using CompiladorMorse.App.modelo;
using CompiladorMorse.App.transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                        }
                        else if (esGuion())
                        {
                            estadoActual = 2;
                            lexema = lexema + caracterActual;
                        }
                        else if (esFinLinea())
                        {
                            estadoActual = 4;
                        }
                        else if (esFinArchivo())
                        {
                            estadoActual = 3;
                        }
                        else
                        {
                            estadoActual = 95;
                            lexema = lexema + caracterActual;
                        }

                    }
                    else if (estadoActual == 1)
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
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 5;
                        }
                        else if (esFinArchivo())
                        {
                            estadoActual= 3;
                        }
                        else
                        {
                            estadoActual = 95;
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
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 76;
                        }
                        else if (esFinArchivo())
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
                            estadoActual = 65;
                            lexema = lexema + caracterActual;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 8)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_B, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
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
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 75;
                        }
                        else if (esFinArchivo())
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
                            estadoActual = 59;
                            lexema = lexema + caracterActual;
                        }
                        else
                        {
                            estadoActual = 13;
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
                        }
                        else
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
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 62;
                        }
                        else if (esFinArchivo())
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
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 77;
                        }
                        else if (esFinArchivo())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
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
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 18)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 21;
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
                        else if (esSeparador() || esFinLinea() || esFinArchivo())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
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
                        }
                        else
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
                            estadoActual = 69;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 78;
                        }
                        else if (esFinArchivo())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
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
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 63;
                        }
                        else if (esFinArchivo())
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
                        }
                        else
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
                            estadoActual = 53;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 68;
                        }
                        else if (esFinArchivo())
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
                        }
                        else if (esPunto())
                        {
                            estadoActual = 36;
                            lexema = lexema + caracterActual;
                        }
                        else if (esFinLinea() || esSeparador())
                        {
                            estadoActual = 67;
                        }
                        else if (esFinArchivo())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
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
                            estadoActual = 79;
                            lexema = lexema + caracterActual;
                        }
                        else if (esFinArchivo())
                        {
                            estadoActual = 13;
                        }
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 58;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
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
                        else if (esFinArchivo())
                        {
                            estadoActual = 13;
                        }
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 8;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 34)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 35;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 87;
                            lexema = lexema + caracterActual;
                        }
                        else if (esPunto())
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
                            estadoActual = 71;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 61;
                        }
                        else if (esFinArchivo())
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
                        }
                        else if (esGuion())
                        {
                            estadoActual = 43;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinArchivo() || esFinLinea())
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
                            estadoActual = 82;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 81;
                        }
                        else if (esFinArchivo())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
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
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
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
                        else if (esSeparador() || esFinArchivo() || esFinLinea())
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
                        }
                        else if (esGuion())
                        {
                            estadoActual = 47;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 13;
                        }
                        else
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 44)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 45;
                        }
                        else if (esPunto())
                        {
                            estadoActual = 85;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
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
                    else if (estadoActual == 45)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_8, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 46)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 48;
                        }
                        else if (esPunto() || esGuion())
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
                    else if (estadoActual == 47)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinArchivo() || esFinLinea())
                        {
                            estadoActual = 49;
                        }
                        else if (esPunto() || esGuion())
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
                    else if (estadoActual == 53)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 54;
                            lexema = lexema + caracterActual;
                        }
                        else if (esGuion())
                        {
                            estadoActual = 56;
                            lexema = lexema + caracterActual;
                        }
                        else if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 64;
                        }
                        else if (esFinArchivo())
                        {
                            estadoActual = 13;
                        }
                        else
                        {

                        }
                    }
                    else if (estadoActual == 54)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 55;
                        }
                    }
                    else if (estadoActual == 55)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_C, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 56)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 57;
                        }
                        else if (esPunto())
                        {
                            estadoActual = 89;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 57)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_Y, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 58)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_D, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                    }
                    else if (estadoActual == 59)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 60;
                        }
                    }
                    else if (estadoActual == 60)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_F, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 61)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_G, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 62)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_H, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 63)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_J, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 64)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_K, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 65)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 66;
                        }
                        if (esPunto())
                        {
                            estadoActual = 73;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 66)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_R, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 67)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_M, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 68)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_N, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 69)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 70;
                        }
                    }
                    else if (estadoActual == 70)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_P, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 71)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 72;
                        }
                    }
                    else if (estadoActual == 72)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_Q, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 73)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 74;
                        }else if (esGuion())
                        {
                            estadoActual = 92;
                            lexema = lexema + caracterActual;
                        }
                        else if (esPunto())
                        {
                            estadoActual = 13;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 74)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_L, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 75)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_S, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 76)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_T, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 77)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_V, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 78)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_W, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 79)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 80;
                        }
                    }
                    else if (estadoActual == 80)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_X, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 81)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_MORSE_Z, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 82)
                    {
                        LeerSiguienteCaracter();
                        if (esGuion())
                        {
                            estadoActual = 83;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 83)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 84;
                        }
                    }
                    else if (estadoActual == 84)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_COMA, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 85)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 86;
                        }
                    }
                    else if (estadoActual == 86)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_DOS_PUNTOS, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 87)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 88;
                        }
                    }
                    else if (estadoActual == 88)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_GUION, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 89)
                    {
                        LeerSiguienteCaracter();
                        if (esGuion())
                        {
                            estadoActual = 90;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 90)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 91;
                        }
                    }
                    else if (estadoActual == 91)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_PARENTESIS, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 92)
                    {
                        LeerSiguienteCaracter();
                        if (esPunto())
                        {
                            estadoActual = 93;
                            lexema = lexema + caracterActual;
                        }
                    }
                    else if (estadoActual == 93)
                    {
                        LeerSiguienteCaracter();
                        if (esSeparador() || esFinLinea())
                        {
                            estadoActual = 91;
                        }
                    }
                    else if (estadoActual == 94)
                    {
                        continuarAnalisis = false;
                        DevolverPuntero();
                        CrearComponenteSimbolo(lexema, CategoriaGramatical.SIMBOLO_COMILLAS, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);

                    }
                    else if (estadoActual == 95)
                    {
                        continuarAnalisis = false;
                        CrearComponenteSimbolo("", CategoriaGramatical.ERROR_CRITICO, numeroDeLineaActual, puntero - lexema.Length, puntero - 1);
                        MessageBox.Show("Error crítico, caracter no válido en " + lexema);

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
