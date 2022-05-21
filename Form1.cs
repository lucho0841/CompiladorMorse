using CompiladorMorse.App;
using CompiladorMorse.App.AnalisisSintactico;
using CompiladorMorse.App.AnalizadorLexico;
using CompiladorMorse.App.Error;
using CompiladorMorse.App.TablaComponentes;
using CompiladorMorse.App.transversal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TablaSimbolos = CompiladorMorse.App.TablaComponentes.TablaSimbolos;

namespace CompiladorMorse
{
    public partial class Form1 : Form
    {
        Boolean depurar = false;
        Boolean opcion;

        OpenFileDialog OpenFile = new OpenFileDialog();
        StreamReader streamReader;
        private string archiveReference;
        private Cache cache;
        private string[] linesData;
        List<ComponenteError> error = new List<ComponenteError>();
        public Form1()
        {
            InitializeComponent();
            btnMorse.Enabled = false;
            btnTexto.Enabled = false;
        }

        private void Clear()
        {
            Cache.ObtenerCache().Limpiar();
        }

        private void rbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCodigo.Checked)
            {
                btnCargar.Hide();
                txtUrlArchivo.Hide();
                btnTexto.Show();
                btnMorse.Show();
                txtUrlArchivo.ResetText();
                lbCodigo.Items.Clear();
                txtCodigo.Show();
            }
        }

        private void rbArchivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArchivo.Checked)
            {
                txtUrlArchivo.Show();
                btnCargar.Show();
                txtCodigo.Hide();
                lbCodigo.Items.Clear();
                txtCodigo.ResetText();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnTexto.Enabled = false;
            btnMorse.Enabled = false;
            rbCodigo.Checked = true;
            txtUrlArchivo.Hide();
            btnCargar.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Clear();
            ManejadorError.ObtenerManejadorError().Reiniciar();
            TablaMaestra.Limpiar();
            txtUrlArchivo.Text = "";
            txtCodigo.Text = "";
            lbCodigo.Items.Clear();
            dataGridViewSimbolos.Rows.Clear();
            dataGridViewDummys.Rows.Clear();
            dataGridViewLiterales.Rows.Clear();
            dataGridViewReservadas.Rows.Clear();
            dataGridViewError.Rows.Clear();
            btnMorse.Enabled=true;
            btnTexto.Enabled=true;
            txtCodigo.Enabled = true;
            txtUrlArchivo.Enabled = true;
            btnCargar.Enabled = true;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFile.Filter = "Text Files(.txt)| *.txt";
                lbCodigo.Items.Clear();

                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    archiveReference = OpenFile.FileName;
                    streamReader = new StreamReader(archiveReference);

                    txtUrlArchivo.Text = archiveReference;
                    if (txtUrlArchivo.Text.Length > 0)
                    {
                        lbCodigo.Enabled = true;
                        archiveReference = "";
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex);
            }
        }

        private void ObtenerNombreArchivo()
        {
            lbCodigo.Items.Clear();
            int cont = 1;
            while (true)
            {
                string actualLine = streamReader.ReadLine();
                if (actualLine != "")
                {
                    Cache.ObtenerCache().AgregarLinea(actualLine);
                }

                if (streamReader.EndOfStream)
                {
                    streamReader.Close();
                    break;
                }
                cont++;
            }
        }

        private void leerConsola()
        {
            linesData = txtCodigo.Text.Split('\n');
            lbCodigo.Enabled = true;
        }

        private void btnMorse_Click(object sender, EventArgs e)
        {
            if (rbArchivo.Checked)
            {
                ObtenerNombreArchivo();
                LlenarTablas();
            }
            else
            {
                leerConsola();
                GuardarLineaEnCache();
                LlenarTablas();
            }
            btnMorse.Enabled = false;
            btnTexto.Enabled = false;
            txtCodigo.Enabled = false;
            txtUrlArchivo.Enabled = false;
            btnCargar.Enabled = false;
        }

        private void Resetear()
        {
            Cache.ObtenerCache().Limpiar();
            //TablaMaestra.Limpiar();
            dataGridViewSimbolos.Rows.Clear();
            
        }

        private void LlenarTablas()
        {
            try
            {

                //AnalizadorLexico analizador = new AnalizadorLexico();
                //ComponenteLexico componente = analizador.Analizador(true);

                AnalizadorSintactico analizador = new AnalizadorSintactico();
                opcion = false;
                Dictionary<string, object> Resultados = analizador.Analizar(depurar, opcion);
                ComponenteLexico componente = (ComponenteLexico)Resultados["COMPONENTE"];
                string Resultado = Convert.ToString(Resultados["RESULTADO"]);
                List<ComponenteLexico> listaSimbolo = TablaSimbolos.ObtenerSimbolos();
                List<ComponenteLexico> listaLiterales = TablaLiterales.ObtenerLiterales();
                List<ComponenteLexico> listaReservadas = TablaPalabraReservada.ObtenerPalabrasReservadas();
                List<ComponenteLexico> listaDummys = TablaDummy.ObtenerDummys();

                if (!componente.ObtenerCategoria().Equals(CategoriaGramatical.ERROR))
                {

                    for (int i = 0; i < listaSimbolo.Count; i++)
                    {
                        dataGridViewSimbolos.Rows.Add(listaSimbolo[i].ObtenerLexema(), listaSimbolo[i].ObtenerCategoria(), listaSimbolo[i].ObtenerNumeroLinea(), listaSimbolo[i].ObtenerPosicionInicial(), listaSimbolo[i].ObtenerPosicionFinal());
                    }
                    for (int i = 0; i < listaLiterales.Count; i++)
                    {
                        dataGridViewLiterales.Rows.Add(listaLiterales[i].ObtenerLexema(), listaLiterales[i].ObtenerCategoria(), listaLiterales[i].ObtenerNumeroLinea(), listaLiterales[i].ObtenerPosicionInicial(), listaLiterales[i].ObtenerPosicionFinal());
                    }
                    for (int i = 0; i < listaReservadas.Count; i++)
                    {
                        dataGridViewReservadas.Rows.Add(listaReservadas[i].ObtenerLexema(), listaReservadas[i].ObtenerCategoria(), listaReservadas[i].ObtenerNumeroLinea(), listaReservadas[i].ObtenerPosicionInicial(), listaReservadas[i].ObtenerPosicionFinal());
                    }
                    for (int i = 0; i < listaDummys.Count; i++)
                    {
                        dataGridViewDummys.Rows.Add(listaDummys[i].ObtenerLexema(), listaDummys[i].ObtenerCategoria(), listaDummys[i].ObtenerNumeroLinea(), listaDummys[i].ObtenerPosicionInicial(), listaDummys[i].ObtenerPosicionFinal());
                    }
                }
                else
                {
                    for (int i = 0; i < listaDummys.Count; i++)
                    {
                        dataGridViewDummys.Rows.Add(listaDummys[i].ObtenerLexema(), listaDummys[i].ObtenerCategoria(), listaDummys[i].ObtenerNumeroLinea(), listaDummys[i].ObtenerPosicionInicial(), listaDummys[i].ObtenerPosicionFinal());
                    }
                }
                lbCodigo.Items.Add(Resultado);

                error = ManejadorError.ObtenerManejadorError().ObtenerErrores();
                for (int i = 0; i < error.Count; i++)
                {
                    dataGridViewError.Rows.Add(error[i].ObtenerNumeroLinea(), error[i].ObtenerPosicionInicial(), error[i].ObtenerPosicionFinal(), error[i].ObtenerCausa(), error[i].ObtenerFalla(), error[i].ObtenerSolucion());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                error = ManejadorError.ObtenerManejadorError().ObtenerErrores();
                for (int i = 0; i < error.Count; i++)
                {
                    dataGridViewError.Rows.Add(error[i].ObtenerNumeroLinea(), error[i].ObtenerPosicionInicial(), error[i].ObtenerPosicionFinal(), error[i].ObtenerCausa(), error[i].ObtenerFalla(), error[i].ObtenerSolucion());
                }
            }
        }

        private void LlenarTablasConMorse()
        {
            try
            {
                AnalizadorSintactico analizador = new AnalizadorSintactico();
                opcion = true;
                Dictionary<string, object> Resultados = analizador.Analizar(depurar, opcion);
                ComponenteLexico componente = (ComponenteLexico)Resultados["COMPONENTE"];
                string Resultado = Convert.ToString(Resultados["RESULTADO"]);
                List<ComponenteLexico> listaSimbolo = TablaSimbolos.ObtenerSimbolos();
                List<ComponenteLexico> listaLiterales = TablaLiterales.ObtenerLiterales();
                List<ComponenteLexico> listaReservadas = TablaPalabraReservada.ObtenerPalabrasReservadas();
                List<ComponenteLexico> listaDummys = TablaDummy.ObtenerDummys();

                if (!componente.ObtenerCategoria().Equals(CategoriaGramatical.ERROR))
                {
                    for (int i = 0; i < listaSimbolo.Count; i++)
                    {
                        dataGridViewSimbolos.Rows.Add(listaSimbolo[i].ObtenerLexema(), listaSimbolo[i].ObtenerCategoria(), listaSimbolo[i].ObtenerNumeroLinea(), listaSimbolo[i].ObtenerPosicionInicial(), listaSimbolo[i].ObtenerPosicionFinal());
                    }
                    for (int i = 0; i < listaLiterales.Count; i++)
                    {
                        dataGridViewLiterales.Rows.Add(listaLiterales[i].ObtenerLexema(), listaLiterales[i].ObtenerCategoria(), listaLiterales[i].ObtenerNumeroLinea(), listaLiterales[i].ObtenerPosicionInicial(), listaLiterales[i].ObtenerPosicionFinal());
                    }
                    for (int i = 0; i < listaReservadas.Count; i++)
                    {
                        dataGridViewReservadas.Rows.Add(listaReservadas[i].ObtenerLexema(), listaReservadas[i].ObtenerCategoria(), listaReservadas[i].ObtenerNumeroLinea(), listaReservadas[i].ObtenerPosicionInicial(), listaReservadas[i].ObtenerPosicionFinal());
                    }
                    for (int i = 0; i < listaDummys.Count; i++)
                    {
                        dataGridViewDummys.Rows.Add(listaDummys[i].ObtenerLexema(), listaDummys[i].ObtenerCategoria(), listaDummys[i].ObtenerNumeroLinea(), listaDummys[i].ObtenerPosicionInicial(), listaDummys[i].ObtenerPosicionFinal());
                    }

                } else
                {
                    for (int i = 0; i < listaDummys.Count; i++)
                    {
                        dataGridViewDummys.Rows.Add(listaDummys[i].ObtenerLexema(), listaDummys[i].ObtenerCategoria(), listaDummys[i].ObtenerNumeroLinea(), listaDummys[i].ObtenerPosicionInicial(), listaDummys[i].ObtenerPosicionFinal());
                    }
                }
                lbCodigo.Items.Add(Resultado);

                error = ManejadorError.ObtenerManejadorError().ObtenerErrores();
                for (int i = 0; i < error.Count; i++)
                {
                    dataGridViewError.Rows.Add(error[i].ObtenerNumeroLinea(), error[i].ObtenerPosicionInicial(), error[i].ObtenerPosicionFinal(), error[i].ObtenerCausa(), error[i].ObtenerFalla(), error[i].ObtenerSolucion());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                error = ManejadorError.ObtenerManejadorError().ObtenerErrores();
                for (int i = 0; i < error.Count; i++)
                {
                    dataGridViewError.Rows.Add(error[i].ObtenerNumeroLinea(), error[i].ObtenerPosicionInicial(), error[i].ObtenerPosicionFinal(), error[i].ObtenerCausa(), error[i].ObtenerFalla(), error[i].ObtenerSolucion());
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarDataGridView(DataGridView view, List<ComponenteLexico> componentes)
        {
           
        }

        private void GuardarLineaEnCache()
        {
            foreach (String linea in txtCodigo.Lines)
            {
                if (linea != null)
                {
                    Cache.ObtenerCache().AgregarLinea(linea);
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                btnMorse.Enabled = true;
                btnTexto.Enabled = true;
            } else
            {
                btnMorse.Enabled = false;
                btnTexto.Enabled= false;
            }
            
        }

        private void txtUrlArchivo_TextChanged(object sender, EventArgs e)
        {
            if (txtUrlArchivo.Text.Length > 0)
            {
                btnMorse.Enabled = true;
                btnTexto.Enabled = true;
            }
            else
            {
                btnMorse.Enabled = false;
                btnTexto.Enabled = false;
            }
        }

        private void btnTexto_Click(object sender, EventArgs e)
        {
            if (rbArchivo.Checked)
            {
                ObtenerNombreArchivo();
                LlenarTablasConMorse();
            }
            else
            {
                leerConsola();
                GuardarLineaEnCache();
                LlenarTablasConMorse();
            }
            btnTexto.Enabled = false;
            btnMorse.Enabled = false;
            txtCodigo.Enabled = false;
            txtUrlArchivo.Enabled = false;
            btnCargar.Enabled = false;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
