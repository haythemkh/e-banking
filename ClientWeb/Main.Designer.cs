namespace ClientWeb
{
    partial class Main
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
            this.bConnexion = new System.Windows.Forms.Button();
            this.txtNumCompte = new System.Windows.Forms.TextBox();
            this.txtMDP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bConnexion
            // 
            this.bConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bConnexion.Location = new System.Drawing.Point(48, 82);
            this.bConnexion.Name = "bConnexion";
            this.bConnexion.Size = new System.Drawing.Size(219, 29);
            this.bConnexion.TabIndex = 0;
            this.bConnexion.Text = "Connexion";
            this.bConnexion.UseVisualStyleBackColor = true;
            this.bConnexion.Click += new System.EventHandler(this.bConnexion_Click);
            // 
            // txtNumCompte
            // 
            this.txtNumCompte.Location = new System.Drawing.Point(125, 17);
            this.txtNumCompte.Name = "txtNumCompte";
            this.txtNumCompte.Size = new System.Drawing.Size(169, 20);
            this.txtNumCompte.TabIndex = 1;
            // 
            // txtMDP
            // 
            this.txtMDP.Location = new System.Drawing.Point(125, 49);
            this.txtMDP.Name = "txtMDP";
            this.txtMDP.PasswordChar = '*';
            this.txtMDP.Size = new System.Drawing.Size(169, 20);
            this.txtMDP.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "N° de compte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mot-de-passe";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 122);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMDP);
            this.Controls.Add(this.txtNumCompte);
            this.Controls.Add(this.bConnexion);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Banking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConnexion;
        private System.Windows.Forms.TextBox txtNumCompte;
        private System.Windows.Forms.TextBox txtMDP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

