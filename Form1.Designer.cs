
namespace VariablesAleatorias
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.gbDistribucion = new System.Windows.Forms.GroupBox();
            this.rbPoisson = new System.Windows.Forms.RadioButton();
            this.rbExponencialNegativa = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbUniforme = new System.Windows.Forms.RadioButton();
            this.gbUniforme = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.gbMuestra = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cantIntervalos = new System.Windows.Forms.TextBox();
            this.cantDatos = new System.Windows.Forms.TextBox();
            this.gbNormal = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.desviacionNormal = new System.Windows.Forms.TextBox();
            this.mediaNormal = new System.Windows.Forms.TextBox();
            this.gbExponencialNegativa = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lambdaExponencial = new System.Windows.Forms.TextBox();
            this.mediaExponencial = new System.Windows.Forms.TextBox();
            this.gbPoisson = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lambdaPoisson = new System.Windows.Forms.TextBox();
            this.mediaPoisson = new System.Windows.Forms.TextBox();
            this.grdAleatorios = new System.Windows.Forms.DataGridView();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.gbGrafico = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gbDistribucion.SuspendLayout();
            this.gbUniforme.SuspendLayout();
            this.gbMuestra.SuspendLayout();
            this.gbNormal.SuspendLayout();
            this.gbExponencialNegativa.SuspendLayout();
            this.gbPoisson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAleatorios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(277, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(621, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generador de Variables Aleatorias";
            // 
            // gbDistribucion
            // 
            this.gbDistribucion.Controls.Add(this.rbPoisson);
            this.gbDistribucion.Controls.Add(this.rbExponencialNegativa);
            this.gbDistribucion.Controls.Add(this.rbNormal);
            this.gbDistribucion.Controls.Add(this.rbUniforme);
            this.gbDistribucion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbDistribucion.Location = new System.Drawing.Point(12, 67);
            this.gbDistribucion.Name = "gbDistribucion";
            this.gbDistribucion.Size = new System.Drawing.Size(216, 165);
            this.gbDistribucion.TabIndex = 1;
            this.gbDistribucion.TabStop = false;
            this.gbDistribucion.Text = "Seleccione una distribución";
            // 
            // rbPoisson
            // 
            this.rbPoisson.AutoSize = true;
            this.rbPoisson.Location = new System.Drawing.Point(18, 123);
            this.rbPoisson.Name = "rbPoisson";
            this.rbPoisson.Size = new System.Drawing.Size(81, 25);
            this.rbPoisson.TabIndex = 3;
            this.rbPoisson.TabStop = true;
            this.rbPoisson.Text = "Poisson";
            this.rbPoisson.UseVisualStyleBackColor = true;
            this.rbPoisson.CheckedChanged += new System.EventHandler(this.rbPoisson_CheckedChanged);
            // 
            // rbExponencialNegativa
            // 
            this.rbExponencialNegativa.AutoSize = true;
            this.rbExponencialNegativa.Location = new System.Drawing.Point(18, 92);
            this.rbExponencialNegativa.Name = "rbExponencialNegativa";
            this.rbExponencialNegativa.Size = new System.Drawing.Size(173, 25);
            this.rbExponencialNegativa.TabIndex = 2;
            this.rbExponencialNegativa.TabStop = true;
            this.rbExponencialNegativa.Text = "Exponencial negativa";
            this.rbExponencialNegativa.UseVisualStyleBackColor = true;
            this.rbExponencialNegativa.CheckedChanged += new System.EventHandler(this.rbExponencialNegativa_CheckedChanged);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(18, 61);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(81, 25);
            this.rbNormal.TabIndex = 1;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.rbNormal_CheckedChanged);
            // 
            // rbUniforme
            // 
            this.rbUniforme.AutoSize = true;
            this.rbUniforme.Location = new System.Drawing.Point(18, 30);
            this.rbUniforme.Name = "rbUniforme";
            this.rbUniforme.Size = new System.Drawing.Size(94, 25);
            this.rbUniforme.TabIndex = 0;
            this.rbUniforme.TabStop = true;
            this.rbUniforme.Text = "Uniforme";
            this.rbUniforme.UseVisualStyleBackColor = true;
            this.rbUniforme.CheckedChanged += new System.EventHandler(this.rbUniforme_CheckedChanged);
            // 
            // gbUniforme
            // 
            this.gbUniforme.Controls.Add(this.label3);
            this.gbUniforme.Controls.Add(this.label2);
            this.gbUniforme.Controls.Add(this.txtB);
            this.gbUniforme.Controls.Add(this.txtA);
            this.gbUniforme.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbUniforme.Location = new System.Drawing.Point(234, 67);
            this.gbUniforme.Name = "gbUniforme";
            this.gbUniforme.Size = new System.Drawing.Size(254, 165);
            this.gbUniforme.TabIndex = 2;
            this.gbUniforme.TabStop = false;
            this.gbUniforme.Text = "Parámetros";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Límite Superior:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Límite Inferior:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(134, 88);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 29);
            this.txtB.TabIndex = 1;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(134, 29);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 29);
            this.txtA.TabIndex = 0;
            // 
            // gbMuestra
            // 
            this.gbMuestra.Controls.Add(this.label5);
            this.gbMuestra.Controls.Add(this.label4);
            this.gbMuestra.Controls.Add(this.cantIntervalos);
            this.gbMuestra.Controls.Add(this.cantDatos);
            this.gbMuestra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbMuestra.Location = new System.Drawing.Point(13, 239);
            this.gbMuestra.Name = "gbMuestra";
            this.gbMuestra.Size = new System.Drawing.Size(215, 155);
            this.gbMuestra.TabIndex = 3;
            this.gbMuestra.TabStop = false;
            this.gbMuestra.Text = "Ingrese los datos de la muestra";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Intervalos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantidad";
            // 
            // cantIntervalos
            // 
            this.cantIntervalos.Location = new System.Drawing.Point(101, 107);
            this.cantIntervalos.Name = "cantIntervalos";
            this.cantIntervalos.Size = new System.Drawing.Size(108, 29);
            this.cantIntervalos.TabIndex = 1;
            // 
            // cantDatos
            // 
            this.cantDatos.Location = new System.Drawing.Point(101, 54);
            this.cantDatos.Name = "cantDatos";
            this.cantDatos.Size = new System.Drawing.Size(108, 29);
            this.cantDatos.TabIndex = 0;
            // 
            // gbNormal
            // 
            this.gbNormal.Controls.Add(this.label6);
            this.gbNormal.Controls.Add(this.label7);
            this.gbNormal.Controls.Add(this.desviacionNormal);
            this.gbNormal.Controls.Add(this.mediaNormal);
            this.gbNormal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbNormal.Location = new System.Drawing.Point(234, 67);
            this.gbNormal.Name = "gbNormal";
            this.gbNormal.Size = new System.Drawing.Size(254, 165);
            this.gbNormal.TabIndex = 4;
            this.gbNormal.TabStop = false;
            this.gbNormal.Text = "Parámetros";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "Desviación:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "Media:";
            // 
            // desviacionNormal
            // 
            this.desviacionNormal.Location = new System.Drawing.Point(116, 88);
            this.desviacionNormal.Name = "desviacionNormal";
            this.desviacionNormal.Size = new System.Drawing.Size(100, 29);
            this.desviacionNormal.TabIndex = 1;
            // 
            // mediaNormal
            // 
            this.mediaNormal.Location = new System.Drawing.Point(116, 30);
            this.mediaNormal.Name = "mediaNormal";
            this.mediaNormal.Size = new System.Drawing.Size(100, 29);
            this.mediaNormal.TabIndex = 0;
            // 
            // gbExponencialNegativa
            // 
            this.gbExponencialNegativa.Controls.Add(this.label8);
            this.gbExponencialNegativa.Controls.Add(this.label9);
            this.gbExponencialNegativa.Controls.Add(this.lambdaExponencial);
            this.gbExponencialNegativa.Controls.Add(this.mediaExponencial);
            this.gbExponencialNegativa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbExponencialNegativa.Location = new System.Drawing.Point(234, 67);
            this.gbExponencialNegativa.Name = "gbExponencialNegativa";
            this.gbExponencialNegativa.Size = new System.Drawing.Size(254, 165);
            this.gbExponencialNegativa.TabIndex = 5;
            this.gbExponencialNegativa.TabStop = false;
            this.gbExponencialNegativa.Text = "Parámetros";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 21);
            this.label8.TabIndex = 3;
            this.label8.Text = "Lambda:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "Media:";
            // 
            // lambdaExponencial
            // 
            this.lambdaExponencial.Location = new System.Drawing.Point(116, 88);
            this.lambdaExponencial.Name = "lambdaExponencial";
            this.lambdaExponencial.Size = new System.Drawing.Size(100, 29);
            this.lambdaExponencial.TabIndex = 1;
            // 
            // mediaExponencial
            // 
            this.mediaExponencial.Location = new System.Drawing.Point(116, 30);
            this.mediaExponencial.Name = "mediaExponencial";
            this.mediaExponencial.Size = new System.Drawing.Size(100, 29);
            this.mediaExponencial.TabIndex = 0;
            // 
            // gbPoisson
            // 
            this.gbPoisson.Controls.Add(this.label10);
            this.gbPoisson.Controls.Add(this.label11);
            this.gbPoisson.Controls.Add(this.lambdaPoisson);
            this.gbPoisson.Controls.Add(this.mediaPoisson);
            this.gbPoisson.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbPoisson.Location = new System.Drawing.Point(234, 67);
            this.gbPoisson.Name = "gbPoisson";
            this.gbPoisson.Size = new System.Drawing.Size(254, 165);
            this.gbPoisson.TabIndex = 6;
            this.gbPoisson.TabStop = false;
            this.gbPoisson.Text = "Parámetros";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 21);
            this.label10.TabIndex = 3;
            this.label10.Text = "Lambda:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 21);
            this.label11.TabIndex = 2;
            this.label11.Text = "Media:";
            // 
            // lambdaPoisson
            // 
            this.lambdaPoisson.Location = new System.Drawing.Point(116, 88);
            this.lambdaPoisson.Name = "lambdaPoisson";
            this.lambdaPoisson.Size = new System.Drawing.Size(100, 29);
            this.lambdaPoisson.TabIndex = 1;
            // 
            // mediaPoisson
            // 
            this.mediaPoisson.Location = new System.Drawing.Point(116, 30);
            this.mediaPoisson.Name = "mediaPoisson";
            this.mediaPoisson.Size = new System.Drawing.Size(100, 29);
            this.mediaPoisson.TabIndex = 0;
            // 
            // grdAleatorios
            // 
            this.grdAleatorios.AllowUserToAddRows = false;
            this.grdAleatorios.AllowUserToDeleteRows = false;
            this.grdAleatorios.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdAleatorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAleatorios.Location = new System.Drawing.Point(13, 401);
            this.grdAleatorios.Name = "grdAleatorios";
            this.grdAleatorios.ReadOnly = true;
            this.grdAleatorios.RowTemplate.Height = 25;
            this.grdAleatorios.Size = new System.Drawing.Size(475, 202);
            this.grdAleatorios.TabIndex = 7;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGenerar.Location = new System.Drawing.Point(234, 250);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(254, 65);
            this.btnGenerar.TabIndex = 8;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // gbGrafico
            // 
            this.gbGrafico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbGrafico.Location = new System.Drawing.Point(494, 66);
            this.gbGrafico.Name = "gbGrafico";
            this.gbGrafico.Size = new System.Drawing.Size(758, 577);
            this.gbGrafico.TabIndex = 9;
            this.gbGrafico.TabStop = false;
            this.gbGrafico.Text = "Gráfico";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(234, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 63);
            this.button1.TabIndex = 11;
            this.button1.Text = "Realizar prueba CHI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 655);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbGrafico);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.grdAleatorios);
            this.Controls.Add(this.gbPoisson);
            this.Controls.Add(this.gbExponencialNegativa);
            this.Controls.Add(this.gbNormal);
            this.Controls.Add(this.gbMuestra);
            this.Controls.Add(this.gbUniforme);
            this.Controls.Add(this.gbDistribucion);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Variableas Aleatorias";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbDistribucion.ResumeLayout(false);
            this.gbDistribucion.PerformLayout();
            this.gbUniforme.ResumeLayout(false);
            this.gbUniforme.PerformLayout();
            this.gbMuestra.ResumeLayout(false);
            this.gbMuestra.PerformLayout();
            this.gbNormal.ResumeLayout(false);
            this.gbNormal.PerformLayout();
            this.gbExponencialNegativa.ResumeLayout(false);
            this.gbExponencialNegativa.PerformLayout();
            this.gbPoisson.ResumeLayout(false);
            this.gbPoisson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAleatorios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDistribucion;
        private System.Windows.Forms.RadioButton rbPoisson;
        private System.Windows.Forms.RadioButton rbExponencialNegativa;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbUniforme;
        private System.Windows.Forms.GroupBox gbUniforme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.GroupBox gbMuestra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cantIntervalos;
        private System.Windows.Forms.TextBox cantDatos;
        private System.Windows.Forms.GroupBox gbNormal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox desviacionNormal;
        private System.Windows.Forms.TextBox mediaNormal;
        private System.Windows.Forms.GroupBox gbExponencialNegativa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lambdaExponencial;
        private System.Windows.Forms.TextBox mediaExponencial;
        private System.Windows.Forms.GroupBox gbPoisson;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox lambdaPoisson;
        private System.Windows.Forms.TextBox mediaPoisson;
        private System.Windows.Forms.DataGridView grdAleatorios;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.GroupBox gbGrafico;
        private System.Windows.Forms.Button button1;
    }
}

