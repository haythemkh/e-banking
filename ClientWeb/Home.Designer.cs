namespace ClientWeb
{
    partial class Home
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
            this.lblBienvenu = new System.Windows.Forms.Label();
            this.lblSolde = new System.Windows.Forms.Label();
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnVerser = new System.Windows.Forms.Button();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNomPrenom = new System.Windows.Forms.Label();
            this.btnVirement = new System.Windows.Forms.Button();
            this.txtBeneficiaireVirement = new System.Windows.Forms.TextBox();
            this.txtMontantVirement = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wbHistoriqueMouvements = new System.Windows.Forms.WebBrowser();
            this.wbHistoriqueSoldes = new System.Windows.Forms.WebBrowser();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBienvenu
            // 
            this.lblBienvenu.AutoSize = true;
            this.lblBienvenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenu.Location = new System.Drawing.Point(11, 11);
            this.lblBienvenu.Name = "lblBienvenu";
            this.lblBienvenu.Size = new System.Drawing.Size(72, 16);
            this.lblBienvenu.TabIndex = 0;
            this.lblBienvenu.Text = "Bienvenue";
            // 
            // lblSolde
            // 
            this.lblSolde.AutoSize = true;
            this.lblSolde.Location = new System.Drawing.Point(291, 11);
            this.lblSolde.Name = "lblSolde";
            this.lblSolde.Size = new System.Drawing.Size(40, 13);
            this.lblSolde.TabIndex = 1;
            this.lblSolde.Text = "Solde: ";
            // 
            // btnRetirer
            // 
            this.btnRetirer.Location = new System.Drawing.Point(142, 19);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(74, 23);
            this.btnRetirer.TabIndex = 4;
            this.btnRetirer.Text = "Retirer";
            this.btnRetirer.UseVisualStyleBackColor = true;
            this.btnRetirer.Click += new System.EventHandler(this.btnRetirer_Click);
            // 
            // btnVerser
            // 
            this.btnVerser.Location = new System.Drawing.Point(222, 19);
            this.btnVerser.Name = "btnVerser";
            this.btnVerser.Size = new System.Drawing.Size(74, 23);
            this.btnVerser.TabIndex = 5;
            this.btnVerser.Text = "Verser";
            this.btnVerser.UseVisualStyleBackColor = true;
            this.btnVerser.Click += new System.EventHandler(this.btnVerser_Click);
            // 
            // txtMontant
            // 
            this.txtMontant.Location = new System.Drawing.Point(17, 21);
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(106, 20);
            this.txtMontant.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Historique des mouvements";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Historique des soldes";
            // 
            // lblNomPrenom
            // 
            this.lblNomPrenom.AutoSize = true;
            this.lblNomPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomPrenom.Location = new System.Drawing.Point(79, 11);
            this.lblNomPrenom.Name = "lblNomPrenom";
            this.lblNomPrenom.Size = new System.Drawing.Size(0, 16);
            this.lblNomPrenom.TabIndex = 12;
            // 
            // btnVirement
            // 
            this.btnVirement.Location = new System.Drawing.Point(238, 32);
            this.btnVirement.Name = "btnVirement";
            this.btnVirement.Size = new System.Drawing.Size(154, 23);
            this.btnVirement.TabIndex = 13;
            this.btnVirement.Text = "Effectuer un virement";
            this.btnVirement.UseVisualStyleBackColor = true;
            this.btnVirement.Click += new System.EventHandler(this.btnVirement_Click);
            // 
            // txtBeneficiaireVirement
            // 
            this.txtBeneficiaireVirement.Location = new System.Drawing.Point(7, 34);
            this.txtBeneficiaireVirement.Name = "txtBeneficiaireVirement";
            this.txtBeneficiaireVirement.Size = new System.Drawing.Size(106, 20);
            this.txtBeneficiaireVirement.TabIndex = 15;
            // 
            // txtMontantVirement
            // 
            this.txtMontantVirement.Location = new System.Drawing.Point(124, 34);
            this.txtMontantVirement.Name = "txtMontantVirement";
            this.txtMontantVirement.Size = new System.Drawing.Size(106, 20);
            this.txtMontantVirement.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnVirement);
            this.groupBox1.Controls.Add(this.txtBeneficiaireVirement);
            this.groupBox1.Controls.Add(this.txtMontantVirement);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 64);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Virement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Montant";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Bénéficiaire";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnVerser);
            this.groupBox2.Controls.Add(this.btnRetirer);
            this.groupBox2.Controls.Add(this.txtMontant);
            this.groupBox2.Location = new System.Drawing.Point(108, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 48);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Retrait / Versement";
            // 
            // wbHistoriqueMouvements
            // 
            this.wbHistoriqueMouvements.Location = new System.Drawing.Point(12, 185);
            this.wbHistoriqueMouvements.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHistoriqueMouvements.Name = "wbHistoriqueMouvements";
            this.wbHistoriqueMouvements.Size = new System.Drawing.Size(232, 211);
            this.wbHistoriqueMouvements.TabIndex = 8;
            // 
            // wbHistoriqueSoldes
            // 
            this.wbHistoriqueSoldes.Location = new System.Drawing.Point(250, 185);
            this.wbHistoriqueSoldes.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHistoriqueSoldes.Name = "wbHistoriqueSoldes";
            this.wbHistoriqueSoldes.Size = new System.Drawing.Size(160, 211);
            this.wbHistoriqueSoldes.TabIndex = 9;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 407);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblNomPrenom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.wbHistoriqueSoldes);
            this.Controls.Add(this.wbHistoriqueMouvements);
            this.Controls.Add(this.lblSolde);
            this.Controls.Add(this.lblBienvenu);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E-Banking";
            this.Load += new System.EventHandler(this.Home_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenu;
        private System.Windows.Forms.Label lblSolde;
        private System.Windows.Forms.Button btnRetirer;
        private System.Windows.Forms.Button btnVerser;
        private System.Windows.Forms.TextBox txtMontant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNomPrenom;
        private System.Windows.Forms.Button btnVirement;
        private System.Windows.Forms.TextBox txtBeneficiaireVirement;
        private System.Windows.Forms.TextBox txtMontantVirement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser wbHistoriqueMouvements;
        private System.Windows.Forms.WebBrowser wbHistoriqueSoldes;
    }
}