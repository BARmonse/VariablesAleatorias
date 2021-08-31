
namespace VariablesAleatorias
{
    partial class PantallaPruebaChi
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
            this.grdResultados = new System.Windows.Forms.DataGridView();
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtValorCritico = new System.Windows.Forms.TextBox();
            this.txtEstadisticoPruebaAcumulado = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // grdResultados
            // 
            this.grdResultados.AllowUserToAddRows = false;
            this.grdResultados.AllowUserToDeleteRows = false;
            this.grdResultados.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultados.Location = new System.Drawing.Point(32, 12);
            this.grdResultados.Name = "grdResultados";
            this.grdResultados.ReadOnly = true;
            this.grdResultados.RowTemplate.Height = 25;
            this.grdResultados.Size = new System.Drawing.Size(500, 304);
            this.grdResultados.TabIndex = 0;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblResultado.Location = new System.Drawing.Point(32, 333);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(118, 32);
            this.lblResultado.TabIndex = 1;
            this.lblResultado.Text = "Resultado";
            // 
            // txtValorCritico
            // 
            this.txtValorCritico.Location = new System.Drawing.Point(671, 12);
            this.txtValorCritico.Name = "txtValorCritico";
            this.txtValorCritico.Size = new System.Drawing.Size(117, 23);
            this.txtValorCritico.TabIndex = 2;
            // 
            // txtEstadisticoPruebaAcumulado
            // 
            this.txtEstadisticoPruebaAcumulado.Location = new System.Drawing.Point(671, 53);
            this.txtEstadisticoPruebaAcumulado.Name = "txtEstadisticoPruebaAcumulado";
            this.txtEstadisticoPruebaAcumulado.Size = new System.Drawing.Size(117, 23);
            this.txtEstadisticoPruebaAcumulado.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(570, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Valor Crítico";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(570, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Estadístico";
            // 
            // PantallaPruebaChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEstadisticoPruebaAcumulado);
            this.Controls.Add(this.txtValorCritico);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.grdResultados);
            this.Name = "PantallaPruebaChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PantallaPruebaChi";
            this.Load += new System.EventHandler(this.PantallaPruebaChi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdResultados;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TextBox txtValorCritico;
        private System.Windows.Forms.TextBox txtEstadisticoPruebaAcumulado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}