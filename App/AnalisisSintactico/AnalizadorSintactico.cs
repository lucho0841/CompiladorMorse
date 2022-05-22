using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompiladorMorse.App.transversal;
using CompiladorMorse.App.Error;
using System.Windows.Forms;

namespace CompiladorMorse.App.AnalisisSintactico
{
    public class AnalizadorSintactico
    {
        private ComponenteLexico componente;
        private AnalizadorLexico.AnalizadorLexico analizadorLexico;
        private Stack<double> pila = new Stack<double>();
        private StringBuilder Resultado;
        private StringBuilder TrazaDerivacion;
        private ComponenteError error;
        private bool Metodo;
        Dictionary<string, object> Respuesta = new Dictionary<string, object>();

        private bool SaltoLinea;

        public Dictionary<string, object> Analizar(bool depurar, bool Metodo)
        {
            analizadorLexico = AnalizadorLexico.AnalizadorLexico.crear();
            this.Metodo = Metodo;
            TrazaDerivacion = new StringBuilder();
            Resultado = new StringBuilder();
            SaltoLinea = true;

            if (this.Metodo)
            {

                pedirComponenteMorse();
                Morse(0);
                /*if (depurar)
                {
                    MessageBox.Show(TrazaDerivacion.ToString());
                }*/
                MessageBox.Show(TrazaDerivacion.ToString());
            }
            else
            {
                pedirComponente();
                Latin(0);
                /*if (depurar)
                {
                    MessageBox.Show(TrazaDerivacion.ToString());
                }*/

                MessageBox.Show(TrazaDerivacion.ToString());
            }

            Respuesta.Add("COMPONENTE", componente);
            Respuesta.Add("RESULTADO", Resultado);
            return Respuesta;

        }
        private void pedirComponente()
        {
            componente = analizadorLexico.Analizador(true);
        }

        private void pedirComponenteMorse()
        {
            componente = analizadorLexico.Analizador(false);
        }

        //<latin>:: <alfabeto><latin>
        private void Latin(int jerarquia)
        {
            if (!CategoriaGramatical.FIN_ARCHIVO.Equals(componente.ObtenerCategoria()))
            {
                TrazarEntrada("<Latin>", jerarquia);
                alfabeto(jerarquia + 1);
                Latin(jerarquia +1 );
                TrazarSalida("</Latin>", jerarquia);
            }
            
        }


        //<Morse>:: <alfabetoMorse><Morse>
        private void Morse(int jerarquia)
        {
            if (!CategoriaGramatical.FIN_ARCHIVO.Equals(componente.ObtenerCategoria()))
            {
                TrazarEntrada("<Morse>", jerarquia);
                alfabetoMorse(jerarquia + 1);
                Morse(jerarquia + 1);
                TrazarSalida("</Morse>", jerarquia);
            }
        }

        // <alfabeto>:= SIMBOLO_A|SIMBOLO_B| SIMBOLO_C | SIMBOLO_D |SIMBOLO_E | SIMBOLO_F |SIMBOLO_G |SIMBOLO_H| SIMBOLO_I | SIMBOLO_J |SIMBOLO_K |SIMBOLO_L |SIMBOLO_M |SIMBOLO_N | SIMBOLO_O | SIMBOLO_P | SIMBOLO_Q | SIMBOLO_R |SIMBOLO_S |SIMBOLO _T | SIMBOLO_U | SIMBOLO_V | SIMBOLO_W | SIMBOLO_X | SIMBOLO_Y | SIMBOLO_Z | SIMBOLO_1| SIMBOLO_2| SIMBOLO_3| SIMBOLO_4| SIMBOLO_5| SIMBOLO_6| SIMBOLO_7| SIMBOLO_8| SIMBOLO_9| SIMBOLO_0 | SIMBOLO_COMA | SIMBOLO_DOS_PUNTOS | SIMBOLO_GUION| SIMBOLO_PARENTESIS| SIMBOLO_COMILLAS|SIMBOLO_PUNTO
        private void alfabeto(int jerarquia)
        {
            TrazarEntrada("<alfabeto>", jerarquia);
            if (CategoriaGramatical.SIMBOLO_A.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_B.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_C.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_D.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_E.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_F.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_G.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_H.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_I.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_J.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_K.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_L.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_M.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_N.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_O.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_P.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_Q.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_R.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_S.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_T.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_U.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_V.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_W.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_X.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_Y.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_Z.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_0.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_1.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_2.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_3.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_4.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_5.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_6.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_7.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_8.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_9.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_COMA.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_DOS_PUNTOS.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_GUION.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();

            }
            else if (CategoriaGramatical.SIMBOLO_PARENTESIS_ABRE.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_PARENTESIS_CIERRA.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_COMILLAS.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.SIMBOLO_PUNTO.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.BLANCO.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else if (CategoriaGramatical.FIN_LINEA.Equals(componente.ObtenerCategoria()))
            {
                FormarResultadoLatin(componente);
                pedirComponente();
            }
            else
            {
                string causa = "Caracter leido no valido " + componente.ObtenerLexema();
                string falla = "Caracter no valido";
                string solucion = "Asegurese que el texto esté bien escrito";

                error = ComponenteError.crearErrorSintactico(
                    componente.ObtenerNumeroLinea(),
                    componente.ObtenerPosicionInicial(),
                    componente.ObtenerPosicionFinal(),
                    causa,
                    falla,
                    solucion);
                throw new Exception("Se ha presentado un error de tipo stopper dentro del proceso de compilacion. Por favor revise la consola de errores...");
                //MessageBox.Show("Se ha presentado un error de tipo stopper dentro del proceso de compilacion. Por favor revise la consola de errores...");
            }

            TrazarSalida("</alfabeto>", jerarquia);
        }

        private void alfabetoMorse(int jerarquia)
        {
            TrazarEntrada("<alfabetoMorse>", jerarquia);
            if (CategoriaGramatical.SIMBOLO_MORSE_A.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_B.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_C.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_D.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_E.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_F.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_G.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_H.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_I.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_J.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_K.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_L.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_M.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_N.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_O.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_P.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_Q.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_R.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_S.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_T.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_U.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_V.Equals(componente.ObtenerCategoria())){
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_W.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_X.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_Y.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_Z.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_0.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_1.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_2.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_3.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_4.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_5.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_6.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_7.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_8.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_MORSE_9.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_COMA.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_DOS_PUNTOS.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_GUION.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_PARENTESIS_ABRE.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_PARENTESIS_CIERRA.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_COMILLAS.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SIMBOLO_PUNTO.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.FIN_LINEA.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();


            }
            else if (CategoriaGramatical.BLANCO.Equals(componente.ObtenerCategoria()))
            {
                pedirComponenteMorse();
            }
            else if (CategoriaGramatical.SEPARADOR_MORSE.Equals(componente.ObtenerCategoria()))
            {
                formarResultadoMorse(componente);
                pedirComponenteMorse();
            }
            else
            {
                string causa = "Caracter leido no valido " + componente.ObtenerLexema();
                string falla = "Caracter no valido";
                string solucion = "Asegurese que el código morse esté bien escrito";

                error = ComponenteError.crearErrorSintactico(
                    componente.ObtenerNumeroLinea(),
                    componente.ObtenerPosicionInicial(),
                    componente.ObtenerPosicionFinal(),
                    causa,
                    falla,
                    solucion);
                throw new Exception("Se ha presentado un error de tipo stopper dentro del proceso de compilacion. Por favor revise la consola de errores...");
                //MessageBox.Show("Se ha presentado un error de tipo stopper dentro del proceso de compilacion. Por favor revise la consola de errores...");
            }
            TrazarSalida("</alfabetoMorse>", jerarquia);

        }


        private void FormarResultadoLatin(ComponenteLexico Componente)
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
                case ",":
                    Resultado.Append("--..-- ");
                    break;
                case ":":
                    Resultado.Append("---... ");
                    break;
                case "-":
                    Resultado.Append("-....- ");
                    break;
                case "(":
                    Resultado.Append("-.--. ");
                    break;
                case ")":
                    Resultado.Append("-.--.- ");
                    break;
                case "'":
                    Resultado.Append(".----. ");
                    break;
                case ".":
                    Resultado.Append(".-.-.- ");
                    break;
                case " ":
                    Resultado.Append(" / ");
                    break;
                case "@FL@":
                    if (SaltoLinea)
                    {
                        Resultado.Append("\n ");
                        SaltoLinea = false;
                    }
                    break;
                default:
                    Resultado.Append("#");
                    break;


            }
        }

        private void formarResultadoMorse(ComponenteLexico componente)
        {
            switch (componente.ObtenerLexema().ToUpper())
            {
                case TraductorMorse.A:
                    Resultado.Append("A");
                    break;
                case TraductorMorse.B:
                    Resultado.Append("B");
                    break;
                case TraductorMorse.C:
                    Resultado.Append("C");
                    break;
                case TraductorMorse.D:
                    Resultado.Append("D");
                    break;
                case TraductorMorse.E:
                    Resultado.Append("E");
                    break;
                case TraductorMorse.F:
                    Resultado.Append("F");
                    break;
                case TraductorMorse.G:
                    Resultado.Append("G");
                    break;
                case TraductorMorse.H:
                    Resultado.Append("H");
                    break;
                case TraductorMorse.I:
                    Resultado.Append("I");
                    break;
                case TraductorMorse.J:
                    Resultado.Append("J");
                    break;
                case TraductorMorse.K:
                    Resultado.Append("K");
                    break;
                case TraductorMorse.L:
                    Resultado.Append("L");
                    break;
                case TraductorMorse.M:
                    Resultado.Append("M");
                    break;
                case TraductorMorse.N:
                    Resultado.Append("N");
                    break;
                case TraductorMorse.O:
                    Resultado.Append("O");
                    break;
                case TraductorMorse.P:
                    Resultado.Append("P");
                    break;
                case TraductorMorse.Q:
                    Resultado.Append("Q");
                    break;
                case TraductorMorse.R:
                    Resultado.Append("R");
                    break;
                case TraductorMorse.S:
                    Resultado.Append("S");
                    break;
                case TraductorMorse.T:
                    Resultado.Append("T");
                    break;
                case TraductorMorse.U:
                    Resultado.Append("U");
                    break;
                case TraductorMorse.V:
                    Resultado.Append("V");
                    break;
                case TraductorMorse.W:
                    Resultado.Append("W");
                    break;
                case TraductorMorse.X:
                    Resultado.Append("X");
                    break;
                case TraductorMorse.Y:
                    Resultado.Append("Y");
                    break;
                case TraductorMorse.Z:
                    Resultado.Append("Z");
                    break;
                case TraductorMorse.UNO:
                    Resultado.Append("1");
                    break;
                case TraductorMorse.DOS:
                    Resultado.Append("2");
                    break;
                case TraductorMorse.TRES:
                    Resultado.Append("3");
                    break;
                case TraductorMorse.CUATRO:
                    Resultado.Append("4");
                    break;
                case TraductorMorse.CINCO:
                    Resultado.Append("5");
                    break;
                case TraductorMorse.SEIS:
                    Resultado.Append("6");
                    break;
                case TraductorMorse.SIETE:
                    Resultado.Append("7");
                    break;
                case TraductorMorse.OCHO:
                    Resultado.Append("8");
                    break;
                case TraductorMorse.NUEVE:
                    Resultado.Append("9");
                    break;
                case TraductorMorse.CERO:
                    Resultado.Append("0");
                    break;
                case TraductorMorse.DOS_PUNTOS:
                    Resultado.Append(":");
                    break;
                case TraductorMorse.PUNTO:
                    Resultado.Append(".");
                    break;
                case TraductorMorse.GUION:
                    Resultado.Append("-");
                    break;
                case TraductorMorse.PARENTESIS_ABRE:
                    Resultado.Append("(");
                    break;
                case TraductorMorse.PARENTESIS_CIERRA:
                    Resultado.Append(")");
                    break;
                case TraductorMorse.COMA:
                    Resultado.Append(",");
                    break;
                case TraductorMorse.COMILLAS:
                    Resultado.Append("'");
                    break;
                case " ":
                    Resultado.Append(" ");
                    break;
                case "/":
                    Resultado.Append(" ");
                    break;
                case "@FL@":
                    if (SaltoLinea)
                    {
                        Resultado.Append("\n ");
                        SaltoLinea = false;
                    }
                    break;
                default:
                    Resultado.Append("#");
                    break;
            }
        }

        private void TrazarEntrada(string NombreRegla, int jerarquia)
        {
            TrazaDerivacion.Append(FormarCadenaEspaciosBlanco(jerarquia));
            TrazaDerivacion.Append(NombreRegla).Append("(").Append(componente.ObtenerCategoria()).Append(")");
            TrazaDerivacion.Append(Environment.NewLine);

        }
        private void TrazarSalida(string NombreRegla, int jerarquia)
        {
            TrazaDerivacion.Append(FormarCadenaEspaciosBlanco(jerarquia));
            TrazaDerivacion.Append(NombreRegla);
            TrazaDerivacion.Append(Environment.NewLine);

        }

        private string FormarCadenaEspaciosBlanco(int jerarquia)
        {
            String EspaciosBlanco = "";
            for (int i = 1; i <= jerarquia; i++)
            {
                EspaciosBlanco = EspaciosBlanco + " | ";
            }
            return EspaciosBlanco;
        }

    }
}