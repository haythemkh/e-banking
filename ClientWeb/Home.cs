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
    public partial class Home : Form
    {
        localhost.Services s = new localhost.Services();
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lblNomPrenom.Text = s.getInfos(Main.stcNumCompte);
            lblSolde.Text = "Solde: " + s.getSolde(Main.stcNumCompte).Trim() + " TND";
            wbHistoriqueMouvements.DocumentText += formatDate(s.getHistoriqueMouvements(Main.stcNumCompte));
            wbHistoriqueSoldes.DocumentText += formatDate(s.getHistoriqueSoldes(Main.stcNumCompte));
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            string ret = s.retrait(Main.stcNumCompte, txtMontant.Text.Trim());
            if (ret != "OK") MessageBox.Show(ret, "Veuillez vérifier ce qui suit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                lblSolde.Text = "Solde: " + s.getSolde(Main.stcNumCompte).Trim() + " TND";
                clearWB();
                wbHistoriqueMouvements.DocumentText += formatDate(s.getHistoriqueMouvements(Main.stcNumCompte));
                wbHistoriqueSoldes.DocumentText += formatDate(s.getHistoriqueSoldes(Main.stcNumCompte));
            }
        }

        private void btnVerser_Click(object sender, EventArgs e)
        {
            string ret = s.verser(Main.stcNumCompte, txtMontant.Text.Trim());
            if (ret != "OK") MessageBox.Show(ret, "Veuillez vérifier ce qui suit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                lblSolde.Text = "Solde: " + s.getSolde(Main.stcNumCompte).Trim() + " TND";
                clearWB();
                wbHistoriqueMouvements.DocumentText = formatDate(s.getHistoriqueMouvements(Main.stcNumCompte));
                wbHistoriqueSoldes.DocumentText = formatDate(s.getHistoriqueSoldes(Main.stcNumCompte));
            }
        }

        private void btnVirement_Click(object sender, EventArgs e)
        {
            string ret = s.effectuerVirement(Main.stcNumCompte, txtBeneficiaireVirement.Text.Trim(), txtMontantVirement.Text.Trim());
            if (ret != "OK") MessageBox.Show(ret, "Veuillez vérifier ce qui suit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                lblSolde.Text = "Solde: " + s.getSolde(Main.stcNumCompte).Trim() + " TND";
                clearWB();
                wbHistoriqueMouvements.DocumentText = formatDate(s.getHistoriqueMouvements(Main.stcNumCompte));
                wbHistoriqueSoldes.DocumentText = formatDate(s.getHistoriqueSoldes(Main.stcNumCompte));
            }
        }

        private void clearWB()
        {
            wbHistoriqueMouvements.Document.OpenNew(true); ;
            wbHistoriqueSoldes.Document.OpenNew(true); ;
        }

        private string formatDate(string str)
        {
            return str.Replace("1905-06-20", "20/01/2016").Replace("19/06/1905", "20/01/2016").Replace("00:00:00", DateTime.Now.ToShortTimeString());
        }
    }
}
