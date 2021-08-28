
namespace VariablesAleatorias.Graficador
{
    partial class GraficadorFrecuencias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grdFrecuencias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFrecuencias)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(299, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(879, 533);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // grdFrecuencias
            // 
            this.grdFrecuencias.AllowUserToAddRows = false;
            this.grdFrecuencias.AllowUserToDeleteRows = false;
            this.grdFrecuencias.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdFrecuencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFrecuencias.Location = new System.Drawing.Point(13, 4);
            this.grdFrecuencias.Name = "grdFrecuencias";
            this.grdFrecuencias.ReadOnly = true;
            this.grdFrecuencias.RowTemplate.Height = 25;
            this.grdFrecuencias.Size = new System.Drawing.Size(280, 380);
            this.grdFrecuencias.TabIndex = 1;
            // 
            // GraficadorFrecuencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 541);
            this.Controls.Add(this.grdFrecuencias);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GraficadorFrecuencias";
            this.Text = "GraficadorFrecuencias";
            this.Load += new System.EventHandler(this.GraficadorFrecuencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFrecuencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView grdFrecuencias;
    }
}