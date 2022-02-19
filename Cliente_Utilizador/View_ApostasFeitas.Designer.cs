
namespace Cliente_Utilizador
{
    partial class View_ApostasFeitas
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
            this.lt_apostasfeitas = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lt_apostasfeitas
            // 
            this.lt_apostasfeitas.HideSelection = false;
            this.lt_apostasfeitas.Location = new System.Drawing.Point(12, 12);
            this.lt_apostasfeitas.Name = "lt_apostasfeitas";
            this.lt_apostasfeitas.Size = new System.Drawing.Size(542, 426);
            this.lt_apostasfeitas.TabIndex = 0;
            this.lt_apostasfeitas.UseCompatibleStateImageBehavior = false;
            this.lt_apostasfeitas.View = System.Windows.Forms.View.List;
            // 
            // View_ApostasFeitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 450);
            this.Controls.Add(this.lt_apostasfeitas);
            this.Name = "View_ApostasFeitas";
            this.Text = "Apostas Feitas";
            this.Load += new System.EventHandler(this.View_ApostasFeitas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lt_apostasfeitas;
    }
}