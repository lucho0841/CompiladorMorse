using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompiladorMorse.App.transversal;
using CompiladorMorse.App.Error;
namespace CompiladorMorse.App.AnalisisSintactico;

public class AnalizadorSintactico
{
    private ComponenteLexico componente;
    private CompiladorMorse.App.AnalizadorLexico.AnalizadorLexico analizadorLexico = CompiladorMorse.App.AnalizadorLexico.AnalizadorLexico.crear();
    private Stack<double> pila = new Stack<double>();
    private StringBuilder Resultado;
    private StringBuilder TrazaDerivacion;
    private bool Metodo;

     private bool SaltoLinea;

    public Dictionary<string, object> Analizar(bool depurar, bool Metodo)
    {
        AnaLex = new AnalizadorLexico();
        this.Metodo = Metodo;
        TrazaDerivacion = new StringBuilder();
        Resultado = new StringBuilder();
        SaltoLinea = true;
            
        if (this.Metodo)
        {
                
            Avanzar();
            Morse(0);
            if (depurar)
            {
                MessageBox.Show(TrazaDerivacion.ToString());
            }
        }
        else
        {
            Avanzar();
            Latin(0);
            if (depurar)
            {
                MessageBox.Show(TrazaDerivacion.ToString());
            }
        }

        Dictionary<string, object> Respuesta = new Dictionary<string, object>();
        Respuesta.Add("COMPONENTE", Componente);
        Respuesta.Add("RESULTADO", Resultado);
        return Respuesta;

    }
    private void pedirComponente()
    {
        componente = analizadorLexico.Analizador(true);
    }

    //<latin>:: <alfabeto><latin>
    private void Latin(int jerarquia)
    {
        TrazarEntrada("<Latin>", jerarquia);
        alfabeto(jerarquia+1);
        Latin(jerarquia+1);
        TrazarSalida("</Latin>", jerarquia);
    }

    // <alfabeto>:= SIMBOLO_A|SIMBOLO_B| SIMBOLO_C | SIMBOLO_D |SIMBOLO_E | SIMBOLO_F |SIMBOLO_G |SIMBOLO_H| SIMBOLO_I | SIMBOLO_J |SIMBOLO_K |SIMBOLO_L |SIMBOLO_M |SIMBOLO_N | SIMBOLO_O | SIMBOLO_P | SIMBOLO_Q | SIMBOLO_R |SIMBOLO_S |SIMBOLO _T | SIMBOLO_U | SIMBOLO_V | SIMBOLO_W | SIMBOLO_X | SIMBOLO_Y | SIMBOLO_Z | SIMBOLO_1| SIMBOLO_2| SIMBOLO_3| SIMBOLO_4| SIMBOLO_5| SIMBOLO_6| SIMBOLO_7| SIMBOLO_8| SIMBOLO_9| SIMBOLO_0 | SIMBOLO_COMA | SIMBOLO_DOS_PUNTOS | SIMBOLO_GUION| SIMBOLO_PARENTESIS| SIMBOLO_COMILLAS|SIMBOLO_PUNTO
    private void alfabeto()
    {
        if (CategoriaGramatical.SIMBOLO_A.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_B.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
         else if (CategoriaGramatical.SIMBOLO_C.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
         else if (CategoriaGramatical.SIMBOLO_D.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
         else if (CategoriaGramatical.SIMBOLO_E.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
         else if (CategoriaGramatical.SIMBOLO_F.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
         else if (CategoriaGramatical.SIMBOLO_G.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
         else if (CategoriaGramatical.SIMBOLO_H.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
         else if (CategoriaGramatical.SIMBOLO_I.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
         else if (CategoriaGramatical.SIMBOLO_J.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_K.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        ValueTupleelse if (CategoriaGramatical.SIMBOLO_L.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_M.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_N.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_O.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_P.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_Q.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_R.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_S.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_T.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_U.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_V.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_W.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_X.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_Y.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_Z.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_0.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_1.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_2.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_3.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_4.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_5.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
         else if (CategoriaGramatical.SIMBOLO_6.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
         else if (CategoriaGramatical.SIMBOLO_7.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
         else if (CategoriaGramatical.SIMBOLO_8.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_9.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_COMA.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_DOS_PUNTOS.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_GUION.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();

        }
        else if (CategoriaGramatical.SIMBOLO_PARENTESIS.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_COMILLAS.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else if (CategoriaGramatical.SIMBOLO_PUNTO.Equals(componente.ObtenerCategoria()))
        {
            FormarResultadoLatin(Componente);
            pedirComponente();
        }
        else
            {
                String Causa = "Caracter leido no valido " + componente.ObtenerCategoria();
                String falla = "Caracter no valido";
                String Solucion = "Asegurese que el texto esté bien escrito";

                ComponenteError = ComponenteError.crearErrorSintactico(Componente.ObtenerLexema(), Componente.ObtenerCategoria(), Componente.ObtenerNumeroLinea(), Componente.ObetenerPosicionInicial(), Componente.ObtenerPosicionFinal(), falla, Causa, Solucion);
                ManejadorErrores.Reportar(Error);
                throw new Exception("Se ha presentado un error de tipo stopper dentro del proceso de compilacion. Por favor revise la consola de errores...");
            }   
    }


    private void FormarResultadoLatin(ComponenteLexico Componente)
    {
    switch (Componente.ObtenerCategoria())
    {
            switch (Componente.ObtenerLexema().ToUpper())
            {
                case "A":
                    Resultado.Append(".- ");
                    break;
                case "B":
                    Resultado.Append("-... ");
                    break;
                case "C":
                    Resultado.Append("-.-. ");
                    break;
                case "D":
                    Resultado.Append("-.. ");
                    break;
                case "E":
                    Resultado.Append(". ");
                    break;
                case "F":
                    Resultado.Append("..-. ");
                    break;
                case "G":
                    Resultado.Append("--. ");
                    break;
                case "H":
                    Resultado.Append(".... ");
                    break;
                case "I":
                    Resultado.Append(".. ");
                    break;
                case "J":
                    Resultado.Append(".--- ");
                    break;
                case "K":
                    Resultado.Append("-.- ");
                    break;
                case "L":
                    Resultado.Append(".-.. ");
                    break;
                case "M":
                    Resultado.Append("-- ");
                    break;
                case "N":
                    Resultado.Append("-. ");
                    break;
                case "O":
                    Resultado.Append("--- ");
                    break;
                case "P":
                    Resultado.Append(".--. ");
                    break;
                case "Q":
                    Resultado.Append("--.- ");
                    break;
                case "R":
                    Resultado.Append(".-. ");
                    break;
                case "S":
                    Resultado.Append("... ");
                    break;
                case "T":
                    Resultado.Append("- ");
                    break;
                case "U":
                    Resultado.Append("..- ");
                    break;
                case "V":
                    Resultado.Append("...- ");
                    break;
                case "W":
                    Resultado.Append(".-- ");
                    break;
                case "X":
                    Resultado.Append("-..- ");
                    break;
                case "Y":
                    Resultado.Append("-.-- ");
                    break;
                case "Z":
                    Resultado.Append("--.. ");
                    break;
                case "0":
                    Resultado.Append("----- ");
                    break;
                case "1":
                    Resultado.Append(".---- ");
                    break;
                case "2":
                    Resultado.Append("..--- ");
                    break;
                case "3":
                    Resultado.Append("...-- ");
                    break;
                case "4":
                    Resultado.Append("....- ");
                    break;
                case "5":
                    Resultado.Append("..... ");
                    break;
                case "6":
                    Resultado.Append("-.... ");
                    break;
                case "7":
                    Resultado.Append("--... ");
                    break;
                case "8":
                    Resultado.Append("---.. ");
                    break;
                case "9":
                    Resultado.Append("----. ");
                    break;
                case CategoriaGramatical.SIMBOLO_COMA:
                    Resultado.Append("--..-- ");
                    break;
                case CategoriaGramatical.SIMBOLO_DOS_PUNTOS:
                    Resultado.Append("---... ");
                    break;
                case CategoriaGramatical.SIMBOLO_GUION:
                    Resultado.Append("-....- ");
                    break;
                case CategoriaGramatical.SIMBOLO_PARENTESIS:
                    Resultado.Append("-.--. ");
                    break;
                case CategoriaGramatical.SIMBOLO_COMILLAS:
                    Resultado.Append(".----. ");
                    break;
                case CategoriaGramatical.SIMBOLO_PUNTO:
                    Resultado.Append(".-.-.- ");
                    break;
                case Categoria.FIN_DE_LINEA:
                    if (SaltoLinea)
                    {
                        Resultado.Append("/ ");
                        SaltoLinea = false;
                    }
                    break;
                default: 
                    Resultado.Append("#");
                    break;


            }
    }
 
}
