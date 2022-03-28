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
        public Form1()
        {
            InitializeComponent();
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
                txtCodigo.Show();
            }
        }

        private void rbArchivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbArchivo.Checked)
            {
                btnCargar.Location = new Point(733, 104);
                txtUrlArchivo.Show();
                btnCargar.Show();
                btnTexto.Hide();
                btnMorse.Hide();
                txtCodigo.Hide();
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
            //Clear();
            txtUrlArchivo.Text = "";
            txtCodigo.Text = "";
            lbCodigo.Items.Clear();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerNombreArchivo();
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
            catch (Exception ex)
            {

                throw;
            }
        }

        private StreamReader ObtenerNombreArchivo()
        {
            OpenFile.Filter = "Text Files(.txt)| *.txt";
            lbCodigo.Items.Clear();

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                archiveReference = OpenFile.FileName;
                streamReader = new StreamReader(archiveReference);
            }

            return streamReader;
        }

    }
}
