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
            txtUrlArchivo.Text = "";
            txtCodigo.Text = "";
            lbCodigo.Items.Clear();
            dataGridView1.Rows.Clear();
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
                lbCodigo.Items.Add(cont + " ->> " + actualLine);
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
            dataGridView1.Rows.Clear();
            
        }

        private void LlenarTablas()
        {
            AnalizadorLexico analizador = new AnalizadorLexico();
            ComponenteLexico componente = analizador.Analizador(true);
            dataGridView1.Rows.Add(componente.ObtenerLexema(), componente.ObtenerCategoria(), componente.ObtenerNumeroLinea(), componente.ObtenerPosicionInicial(), componente.ObtenerPosicionFinal());
            while (!componente.ObtenerCategoria().Equals(CategoriaGramatical.FIN_ARCHIVO))
            {
                componente = analizador.Analizador(true);
                if (!componente.ObtenerCategoria().Equals(CategoriaGramatical.FIN_LINEA) && (!componente.ObtenerCategoria().Equals(CategoriaGramatical.FIN_ARCHIVO))) {
                    dataGridView1.Rows.Add(componente.ObtenerLexema(), componente.ObtenerCategoria(), componente.ObtenerNumeroLinea(), componente.ObtenerPosicionInicial(), componente.ObtenerPosicionFinal());
                } 
            }
        }

        private void LlenarTablasConMorse()
        {
            AnalizadorLexico analizador = new AnalizadorLexico();
            ComponenteLexico componente = analizador.Analizador(false);
            dataGridView1.Rows.Add(componente.ObtenerLexema(), componente.ObtenerCategoria(), componente.ObtenerNumeroLinea(), componente.ObtenerPosicionInicial(), componente.ObtenerPosicionFinal());
            while (!componente.ObtenerCategoria().Equals(CategoriaGramatical.FIN_ARCHIVO))
            {
                componente = analizador.Analizador(false);
                if (!componente.ObtenerCategoria().Equals(CategoriaGramatical.FIN_LINEA) && (!componente.ObtenerCategoria().Equals(CategoriaGramatical.FIN_ARCHIVO)))
                {
                    dataGridView1.Rows.Add(componente.ObtenerLexema(), componente.ObtenerCategoria(), componente.ObtenerNumeroLinea(), componente.ObtenerPosicionInicial(), componente.ObtenerPosicionFinal());
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
    }
}
