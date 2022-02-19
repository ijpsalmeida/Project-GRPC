
namespace Cliente_Administrador
{
    partial class View_Administrador
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
            this.b_novosorteio = new System.Windows.Forms.Button();
            this.b_apostasatuais = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(141, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 41);
            this.label1.TabIndex = 9;
            this.label1.Text = "Euromilhões";
            // 
            // b_novosorteio
            // 
            this.b_novosorteio.Location = new System.Drawing.Point(12, 83);
            this.b_novosorteio.Name = "b_novosorteio";
            this.b_novosorteio.Size = new System.Drawing.Size(178, 29);
            this.b_novosorteio.TabIndex = 10;
            this.b_novosorteio.Text = "Novo Sorteio";
            this.b_novosorteio.UseVisualStyleBackColor = true;
            this.b_novosorteio.Click += new System.EventHandler(this.b_novosorteio_Click);
            // 
            // b_apostasatuais
            // 
            this.b_apostasatuais.Location = new System.Drawing.Point(269, 83);
            this.b_apostasatuais.Name = "b_apostasatuais";
            this.b_apostasatuais.Size = new System.Drawing.Size(178, 29);
            this.b_apostasatuais.TabIndex = 11;
            this.b_apostasatuais.Text = "Ver apostas atuais";
            this.b_apostasatuais.UseVisualStyleBackColor = true;
            this.b_apostasatuais.Click += new System.EventHandler(this.b_apostasatuais_Click);
            // 
            // View_Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 139);
            this.Controls.Add(this.b_apostasatuais);
            this.Controls.Add(this.b_novosorteio);
            this.Controls.Add(this.label1);
            this.Name = "View_Administrador";
            this.Text = "Administrador";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_novosorteio;
        private System.Windows.Forms.Button b_apostasatuais;
    }
}

