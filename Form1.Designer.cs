
namespace CompiladorMorse
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMorse = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnTexto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCodigo = new System.Windows.Forms.ListBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.txtUrlArchivo = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.rbArchivo = new System.Windows.Forms.RadioButton();
            this.rbCodigo = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridViewSimbolos = new System.Windows.Forms.DataGridView();
            this.Lexema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posicionInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posicionFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGridViewDummys = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.dataGridViewLiterales = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.dataGridViewReservadas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewError = new System.Windows.Forms.DataGridView();
            this.dgvNumeroLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCausa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFalla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvsSolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimbolos)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDummys)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLiterales)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservadas)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewError)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMorse
            // 
            this.btnMorse.Location = new System.Drawing.Point(275, 234);
            this.btnMorse.Name = "btnMorse";
            this.btnMorse.Size = new System.Drawing.Size(98, 41);
            this.btnMorse.TabIndex = 0;
            this.btnMorse.Text = "Lectura simbolos";
            this.btnMorse.UseVisualStyleBackColor = true;
            this.btnMorse.Click += new System.EventHandler(this.btnMorse_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(807, 456);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.btnLimpiar);
            this.tabPage1.Controls.Add(this.btnTexto);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lbCodigo);
            this.tabPage1.Controls.Add(this.btnCargar);
            this.tabPage1.Controls.Add(this.txtUrlArchivo);
            this.tabPage1.Controls.Add(this.txtCodigo);
            this.tabPage1.Controls.Add(this.rbArchivo);
            this.tabPage1.Controls.Add(this.rbCodigo);
            this.tabPage1.Controls.Add(this.btnMorse);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(799, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Compilador";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(144, 246);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Depurar";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(598, 234);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(53, 41);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnTexto
            // 
            this.btnTexto.Location = new System.Drawing.Point(415, 234);
            this.btnTexto.Name = "btnTexto";
            this.btnTexto.Size = new System.Drawing.Size(89, 41);
            this.btnTexto.TabIndex = 10;
            this.btnTexto.Text = "Lectura Morse";
            this.btnTexto.UseVisualStyleBackColor = true;
            this.btnTexto.Click += new System.EventHandler(this.btnTexto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Consola:";
            // 
            // lbCodigo
            // 
            this.lbCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCodigo.FormattingEnabled = true;
            this.lbCodigo.ItemHeight = 16;
            this.lbCodigo.Location = new System.Drawing.Point(6, 290);
            this.lbCodigo.Name = "lbCodigo";
            this.lbCodigo.Size = new System.Drawing.Size(787, 132);
            this.lbCodigo.TabIndex = 8;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(703, 130);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(79, 34);
            this.btnCargar.TabIndex = 7;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // txtUrlArchivo
            // 
            this.txtUrlArchivo.Location = new System.Drawing.Point(16, 138);
            this.txtUrlArchivo.Name = "txtUrlArchivo";
            this.txtUrlArchivo.Size = new System.Drawing.Size(681, 20);
            this.txtUrlArchivo.TabIndex = 6;
            this.txtUrlArchivo.TextChanged += new System.EventHandler(this.txtUrlArchivo_TextChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(6, 97);
            this.txtCodigo.Multiline = true;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(787, 122);
            this.txtCodigo.TabIndex = 5;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // rbArchivo
            // 
            this.rbArchivo.AutoSize = true;
            this.rbArchivo.Location = new System.Drawing.Point(415, 50);
            this.rbArchivo.Name = "rbArchivo";
            this.rbArchivo.Size = new System.Drawing.Size(61, 17);
            this.rbArchivo.TabIndex = 2;
            this.rbArchivo.TabStop = true;
            this.rbArchivo.Text = "Archivo";
            this.rbArchivo.UseVisualStyleBackColor = true;
            this.rbArchivo.CheckedChanged += new System.EventHandler(this.rbArchivo_CheckedChanged);
            // 
            // rbCodigo
            // 
            this.rbCodigo.AutoSize = true;
            this.rbCodigo.Checked = true;
            this.rbCodigo.Location = new System.Drawing.Point(315, 50);
            this.rbCodigo.Name = "rbCodigo";
            this.rbCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbCodigo.TabIndex = 1;
            this.rbCodigo.TabStop = true;
            this.rbCodigo.Text = "Código";
            this.rbCodigo.UseVisualStyleBackColor = true;
            this.rbCodigo.CheckedChanged += new System.EventHandler(this.rbCodigo_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(799, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Analizador léxico";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Location = new System.Drawing.Point(17, 22);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(765, 387);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridViewSimbolos);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(757, 361);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Tabla de Simbolos";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSimbolos
            // 
            this.dataGridViewSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSimbolos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lexema,
            this.categoria,
            this.numeroLinea,
            this.posicionInicial,
            this.posicionFinal});
            this.dataGridViewSimbolos.Location = new System.Drawing.Point(24, 23);
            this.dataGridViewSimbolos.Name = "dataGridViewSimbolos";
            this.dataGridViewSimbolos.Size = new System.Drawing.Size(710, 315);
            this.dataGridViewSimbolos.TabIndex = 0;
            this.dataGridViewSimbolos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Lexema
            // 
            this.Lexema.HeaderText = "Lexema";
            this.Lexema.Name = "Lexema";
            // 
            // categoria
            // 
            this.categoria.HeaderText = "Categoría";
            this.categoria.Name = "categoria";
            this.categoria.Width = 200;
            // 
            // numeroLinea
            // 
            this.numeroLinea.HeaderText = "Numero Linea";
            this.numeroLinea.Name = "numeroLinea";
            // 
            // posicionInicial
            // 
            this.posicionInicial.HeaderText = "Posición Inicial";
            this.posicionInicial.Name = "posicionInicial";
            // 
            // posicionFinal
            // 
            this.posicionFinal.HeaderText = "Posicion Final";
            this.posicionFinal.Name = "posicionFinal";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGridViewDummys);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(757, 361);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Tabla de Dummys";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDummys
            // 
            this.dataGridViewDummys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDummys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridViewDummys.Location = new System.Drawing.Point(23, 23);
            this.dataGridViewDummys.Name = "dataGridViewDummys";
            this.dataGridViewDummys.Size = new System.Drawing.Size(710, 315);
            this.dataGridViewDummys.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Lexema";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Categoría";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Numero Linea";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Posición Inicial";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Posicion Final";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.dataGridViewLiterales);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(757, 361);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Tabla de Literales";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLiterales
            // 
            this.dataGridViewLiterales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLiterales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dataGridViewLiterales.Location = new System.Drawing.Point(23, 23);
            this.dataGridViewLiterales.Name = "dataGridViewLiterales";
            this.dataGridViewLiterales.Size = new System.Drawing.Size(710, 315);
            this.dataGridViewLiterales.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Lexema";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Categoría";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Numero Linea";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Posición Inicial";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Posicion Final";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.dataGridViewReservadas);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(757, 361);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Tabla de Palabras Reservadas";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // dataGridViewReservadas
            // 
            this.dataGridViewReservadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservadas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15});
            this.dataGridViewReservadas.Location = new System.Drawing.Point(23, 23);
            this.dataGridViewReservadas.Name = "dataGridViewReservadas";
            this.dataGridViewReservadas.Size = new System.Drawing.Size(710, 315);
            this.dataGridViewReservadas.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Lexema";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Categoría";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 200;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Numero Linea";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Posición Inicial";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Posicion Final";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewError);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(799, 430);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Errores";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewError
            // 
            this.dataGridViewError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewError.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvNumeroLinea,
            this.dgvFinal,
            this.dgvInicial,
            this.dgvCausa,
            this.dgvFalla,
            this.dgvsSolucion});
            this.dataGridViewError.Location = new System.Drawing.Point(24, 27);
            this.dataGridViewError.Name = "dataGridViewError";
            this.dataGridViewError.Size = new System.Drawing.Size(744, 341);
            this.dataGridViewError.TabIndex = 1;
            this.dataGridViewError.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // dgvNumeroLinea
            // 
            this.dgvNumeroLinea.HeaderText = "Numero de línea";
            this.dgvNumeroLinea.Name = "dgvNumeroLinea";
            // 
            // dgvFinal
            // 
            this.dgvFinal.HeaderText = "Posicion Inicial";
            this.dgvFinal.Name = "dgvFinal";
            this.dgvFinal.Width = 200;
            // 
            // dgvInicial
            // 
            this.dgvInicial.HeaderText = "Posicion Final";
            this.dgvInicial.Name = "dgvInicial";
            // 
            // dgvCausa
            // 
            this.dgvCausa.HeaderText = "Causa";
            this.dgvCausa.Name = "dgvCausa";
            // 
            // dgvFalla
            // 
            this.dgvFalla.HeaderText = "Falla";
            this.dgvFalla.Name = "dgvFalla";
            // 
            // dgvsSolucion
            // 
            this.dgvsSolucion.HeaderText = "Solución";
            this.dgvsSolucion.Name = "dgvsSolucion";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 480);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSimbolos)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDummys)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLiterales)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservadas)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMorse;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RadioButton rbArchivo;
        private System.Windows.Forms.RadioButton rbCodigo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.TextBox txtUrlArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbCodigo;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnTexto;
        private System.Windows.Forms.DataGridView dataGridViewSimbolos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexema;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn posicionInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn posicionFinal;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewError;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNumeroLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCausa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFalla;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvsSolucion;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataGridView dataGridViewDummys;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridView dataGridViewLiterales;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridView dataGridViewReservadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

