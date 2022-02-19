
namespace Cliente_Administrador
{
    partial class View_VisualizarApostas
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
            this.lt_VisualizarApostas = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lt_VisualizarApostas
            // 
            this.lt_VisualizarApostas.HideSelection = false;
            this.lt_VisualizarApostas.Location = new System.Drawing.Point(13, 13);
            this.lt_VisualizarApostas.Name = "lt_VisualizarApostas";
            this.lt_VisualizarApostas.Size = new System.Drawing.Size(539, 383);
            this.lt_VisualizarApostas.TabIndex = 0;
            this.lt_VisualizarApostas.UseCompatibleStateImageBehavior = false;
            this.lt_VisualizarApostas.View = System.Windows.Forms.View.List;
            // 
            // View_VisualizarApostas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 408);
            this.Controls.Add(this.lt_VisualizarApostas);
            this.Name = "View_VisualizarApostas";
            this.Text = "Sorteio Atual";
            this.Load += new System.EventHandler(this.View_VisualizarApostas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lt_VisualizarApostas;
    }
}