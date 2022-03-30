using CompiladorMorse.App;
using CompiladorMorse.App.AnalizadorLexico;
using CompiladorMorse.App.transversal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiladorMorse
{
    public partial class Form1 : Form
    {
        OpenFileDialog OpenFile = new OpenFileDialog();
        StreamReader streamReader;
        private string archiveReference;
        private Cache cache;
        private string[] linesData;
        public Form1()
        {
            InitializeComponent();
            btnMorse.Enabled = false;
            btnTexto.Enabled = false;
        }

       /* private void Clear()
        {
            Cache.Limpiar();
        }*/

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
            btnTexto.Enabled = true;
            btnMorse.Enabled = true;
            rbCodigo.Checked = true;
            txtUrlArchivo.Hide();
            btnCargar.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            /*Clear();*/
            txtUrlArchivo.Text = "";
            txtCodigo.Text = "";
            lbCodigo.Items.Clear();
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
                lbCodigo.Items.Add(cont + " ->> " + actualLine);

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
            for (int cont = 1; cont <= linesData.Length; cont++)
            {
                lbCodigo.Items.Add(cont + " ->> " + linesData[cont - 1]);
            }
            lbCodigo.Enabled = true;
        }

        private void btnMorse_Click(object sender, EventArgs e)
        {
            if (rbArchivo.Checked)
            {
                ObtenerNombreArchivo();
            }
            else
            {
                //linesData = txtCodigo.Lines;
                linesData = txtCodigo.Text.Split('\n');
                //salidaDatos.Lines = lineasEntradas;
                lbCodigo.Items.Clear();
                Resetear();
                for (int i = 0; i < linesData.Length; i++)
                {
                    Cache.obtenerCache().AgregarLinea(linesData[i]);
                }
            }
            try
            {
                LlenarTablas();


            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        private void Resetear()
        {
            Cache.obtenerCache().Limpiar();
            //TablaMaestra.Limpiar();
            dataGridView1.Rows.Clear();
            
        }

        private void LlenarTablas()
        {
            List<ComponenteLexico> listaSimbolo = TablaSimbolos.ObtenerSimbolos();
            for (int i = 0; i < listaSimbolo.Count; i++)
            {
                dataGridView1.Rows.Add(listaSimbolo[i].ObtenerLexema(), CategoriaGramatical.SIMBOLO, listaSimbolo[i].ObtenerNumeroLinea(), listaSimbolo[i].ObetenerPosicionInicial(), listaSimbolo[i].ObtenerPosicionFinal());

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
                    cache.AgregarLinea(linea);
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0)
            {
                btnMorse.Enabled = true;
            } else
            {
                btnMorse.Enabled = false;
            }
            
        }
    }
}
