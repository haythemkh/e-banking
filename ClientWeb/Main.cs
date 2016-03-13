using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientWeb
{
    public partial class Main : Form
    {
        public static string stcNumCompte;
        localhost.Services s = new localhost.Services();
        public Main()
        {
            InitializeComponent();
        }

        private void bConnexion_Click(object sender, EventArgs e)
        {
            string mdp = "", numCompte = "101";
            if (txtNumCompte.Text.Trim() != "") numCompte = txtNumCompte.Text.Trim();
            if(txtMDP.Text.Trim() != "") mdp = txtMDP.Text.Trim();
            try
            {
                string ret = s.connecter(numCompte, mdp);
                if (ret == "OK")
                {
                    stcNumCompte = numCompte;
                    this.Hide();
                    Home h = new Home();
                    h.ShowDialog();
                }
                if (ret != "OK") MessageBox.Show(ret, "Connexion échouée", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
