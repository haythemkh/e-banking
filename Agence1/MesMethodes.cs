using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iagence;
using System.Data;
using System.Globalization;

namespace agence1
{
    class MesMethodes : MarshalByRefObject, iagence.IAgence1
    {
        SqlConnection sc = new SqlConnection("Data Source=Xar;Initial Catalog=agence1;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader rdr;

        string IAgence1.getSolde(string numCompte)
        {
            if (sc != null && sc.State == ConnectionState.Closed)
                sc.Open();
            string ret = "";
            try
            {
                cmd = new SqlCommand("SELECT montant FROM TSolde WHERE numCompte = " + numCompte + " ORDER BY id DESC", sc);
                
                rdr = cmd.ExecuteReader();
                rdr.Read();
                ret = rdr.GetDecimal(0).ToString().Trim().Substring(0, rdr.GetDecimal(0).ToString().Trim().Length-1);
            }
            catch (Exception e) { return e.ToString(); }
            finally
            {
                rdr.Close();
                sc.Close();
            }
            return ret;
        }
        string IAgence1.getHistoriqueSoldes(string numCompte)
        {
            if (sc != null && sc.State == ConnectionState.Closed)
                sc.Open();
            string ret = "<table style='border-collapse: collapse;'><tr><th style='font-size:13px;border: 1px solid black;padding:3px;padding:3px;'>Montant</th><th style='font-size:13px;border: 1px solid black;padding:3px;padding:3px;'>Date</th></tr>";
            try
            {
                cmd = new SqlCommand("SELECT montant,dateSolde FROM TSolde WHERE numCompte = " + numCompte + " ORDER BY id DESC", sc);
                
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                    ret += "<tr style='border: 1px solid black;'><td style='border: 1px solid black;padding:3px;font-size:13px;'>" + rdr.GetDecimal(0).ToString().Trim().Substring(0, rdr.GetDecimal(0).ToString().Trim().Length - 1) + "</td><td style='border: 1px solid black;padding:3px;font-size:13px;'>" + rdr.GetDateTime(1) + "</td></tr>";
                ret += "</table>";
            }
            catch (Exception e) { return e.ToString(); }
            finally
            {
                rdr.Close();
                sc.Close();
            }
            return ret;
        }
        string IAgence1.getHistoriqueMouvements(string numCompte)
        {
            if (sc != null && sc.State == ConnectionState.Closed)
                sc.Open();
            string ret = "<table style='border-collapse: collapse;'><tr style='border: 1px solid black;'><th style='font-size:13px;border: 1px solid black;padding:3px;'>Opération</th><th style='font-size:13px;border: 1px solid black;padding:3px;'>Montant</th><th style='font-size:13px;border: 1px solid black;padding:3px;'>Date</th><th style='font-size:13px;border: 1px solid black;padding:3px;'>Bénéficiaire</th></tr>";
            try 
            {
                cmd = new SqlCommand("SELECT codeOp,montant,date,beneficiaire FROM TMvt WHERE numCompte = " + numCompte + " ORDER BY numOp DESC", sc);
                rdr = cmd.ExecuteReader();
                int i = 0;
                while (rdr.Read())
                {
                    int codeOp = rdr.GetInt32(0);
                    string beneficiaire = "--";
                    if(!rdr.IsDBNull(3))
                        beneficiaire = rdr.GetInt32(3).ToString().Trim();
                    string montant = rdr.GetDecimal(1).ToString().Trim();
                    DateTime date = rdr.GetDateTime(2);
                    rdr.Close();
                    cmd = new SqlCommand("SELECT libelle FROM TOperation WHERE codeOp = " + codeOp, sc);
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    ret += "<tr style='border: 1px solid black;'><td style='font-size:13px;border: 1px solid black;padding:3px;'>" + rdr.GetString(0) + "</td><td style='font-size:13px;border: 1px solid black;padding:3px;'>" + montant + "</td><td style='font-size:13px;border: 1px solid black;padding:3px;'>" + date + "</td><td style='font-size:13px;border: 1px solid black;padding:3px;'>" + beneficiaire + "</td></tr>";
                    rdr.Close();
                    cmd = new SqlCommand("SELECT codeOp,montant,date,beneficiaire FROM TMvt WHERE numCompte = " + numCompte + " ORDER BY numOp DESC", sc);
                    rdr = cmd.ExecuteReader();
                    i++;
                    for (int j = 0; j < i; j++)
                        rdr.Read();
                }
                ret += "</table>";
            }
            catch (Exception e) { return e.ToString(); }
            finally
            {
                rdr.Close();
                sc.Close();
            }
            return ret;
        }
        string IAgence1.effectuerVirement(string numCompte, string beneficiaire, string mnt, string statut)
        {
            decimal montant = decimal.Parse(mnt, CultureInfo.InvariantCulture);
            String strMontant = montant.ToString();
            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");
            if (sc != null && sc.State == ConnectionState.Closed)
                sc.Open();
            try
            {
                // GET DERNIER ID
                cmd = new SqlCommand("SELECT id FROM TSolde ORDER BY id DESC", sc);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                int count = rdr.GetInt32(0);
                rdr.Close();

                int numCompteR;

                if (statut == "resp")
                {

                    // GET SOLDE COURANT DU COMPTE RESPONSABLE DE L'OPERATION
                    cmd = new SqlCommand("SELECT montant FROM TSolde WHERE numCompte = " + numCompte + " ORDER BY id DESC", sc);
                    rdr = cmd.ExecuteReader();
                    decimal montantC = 0;
                    rdr.Read();
                    montantC = rdr.GetDecimal(0);
                    if (montantC < montant) return "Vous ne disposez pas d'un tel montant!";
                    rdr.Close();

                    // MAJ DU SOLDE COMPTE RESPONSABLE DE L'OPERATION
                    count++;
                    montantC -= montant;
                    String strMontantC = montantC.ToString();
                    cmd = new SqlCommand("INSERT INTO TSolde(id,numCompte,montant,dateSolde) VALUES(" + count + "," + numCompte + "," + strMontantC.Replace(',', '.') + "," + dateNow + ")", sc);
                    cmd.ExecuteNonQuery();
                    rdr.Close();
                }

                if (statut == "benef")
                {
                    // GET SOLDE COURANT DU BENEFICIAIRE
                    cmd = new SqlCommand("SELECT montant FROM TSolde WHERE numCompte = " + beneficiaire + " ORDER BY id DESC", sc);
                    rdr = cmd.ExecuteReader();
                    decimal montantB = 0;
                    rdr.Read();
                    montantB = rdr.GetDecimal(0);
                    rdr.Close();

                    // MAJ DU SOLDE BENEFICIAIRE
                    count++;
                    montantB += montant;
                    String strMontantB = montantB.ToString();
                    cmd = new SqlCommand("INSERT INTO TSolde(id,numCompte,montant,dateSolde) VALUES(" + count + "," + beneficiaire + "," + strMontantB.Replace(',', '.') + "," + dateNow + ")", sc);
                    cmd.ExecuteNonQuery();
                    rdr.Close();
                }

                // SAUVEGARDE DU MOUVEMENT EFFECTUE
                cmd = new SqlCommand("SELECT numOp FROM TMvt ORDER BY numOP DESC", sc);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                int numOp = 1;
                try
                {
                    if (!rdr.IsDBNull(0))
                        numOp = rdr.GetInt32(0);
                }
                catch (Exception e) { }
                rdr.Close();
                numOp++;
                cmd = new SqlCommand("INSERT INTO TMvt(numOp,numCompte,codeOp,montant,date,beneficiaire) VALUES(" + numOp + "," + numCompte + "," + 3 + "," + strMontant.Replace(',', '.') + "," + dateNow + "," + beneficiaire + ")", sc);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { return e.ToString(); }
            finally
            {
                rdr.Close();
                sc.Close();
            }
            return "OK";
        }
        string IAgence1.retrait(string numCompte, string mnt)
        {
            decimal montant = decimal.Parse(mnt, CultureInfo.InvariantCulture);
            String strMontant = montant.ToString();
            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");
            if (sc != null && sc.State == ConnectionState.Closed)
                sc.Open();
            try 
            {
                // GET SOLDE COURANT
                cmd = new SqlCommand("SELECT montant FROM TSolde WHERE numCompte = " + numCompte + " ORDER BY id DESC", sc);
                rdr = cmd.ExecuteReader();
                decimal montantC = 0;
                rdr.Read();
                montantC = rdr.GetDecimal(0);
                rdr.Close();

                // GET DERNIER ID
                cmd = new SqlCommand("SELECT id FROM TSolde ORDER BY id DESC", sc);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                int count = rdr.GetInt32(0);
                rdr.Close();

                // SOLDE COMPTE RESPONSABLE
                count++;
                montantC -= montant;
                String strMontantC = montantC.ToString();
                cmd = new SqlCommand("INSERT INTO TSolde(id,numCompte,montant,dateSolde) VALUES(" + count + "," + numCompte + "," + strMontantC.Replace(',', '.') + "," + dateNow + ")", sc);
                cmd.ExecuteNonQuery();
                rdr.Close();
                // SAUVEGARDE DU MOUVEMENT EFFECTUE
                cmd = new SqlCommand("SELECT numOp FROM TMvt ORDER BY numOP DESC", sc);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                int numOp = 1;
                try
                {
                    if (!rdr.IsDBNull(0))
                        numOp = rdr.GetInt32(0);
                }
                catch (Exception e) { }
                rdr.Close();
                numOp++;
                cmd = new SqlCommand("INSERT INTO TMvt(numOp,numCompte,codeOp,montant,date) VALUES(" + numOp + "," + numCompte + "," + 2 + "," + strMontant.Replace(',', '.') + "," + dateNow + ")", sc);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { return e.ToString(); }
            finally
            {
                rdr.Close();
                sc.Close();
            }
            return "OK";
        }
        string IAgence1.verser(string numCompte, string mnt)
        {
            decimal montant = decimal.Parse(mnt, CultureInfo.InvariantCulture);
            String strMontant = montant.ToString();
            string dateNow = DateTime.Now.ToString("yyyy-MM-dd");
            if (sc != null && sc.State == ConnectionState.Closed)
                sc.Open();
            try 
            {
                // GET SOLDE COURANT
                cmd = new SqlCommand("SELECT montant FROM TSolde WHERE numCompte = " + numCompte + " ORDER BY id DESC", sc);
                rdr = cmd.ExecuteReader();
                decimal montantC = 0;
                rdr.Read();
                montantC = rdr.GetDecimal(0);
                rdr.Close();

                // GET DERNIER ID
                cmd = new SqlCommand("SELECT id FROM TSolde ORDER BY id DESC", sc);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                int count = rdr.GetInt32(0);
                rdr.Close();

                // SOLDE COMPTE RESPONSABLE
                count++;
                montantC += montant;
                String strMontantC = montantC.ToString();
                cmd = new SqlCommand("INSERT INTO TSolde(id,numCompte,montant,dateSolde) VALUES(" + count + "," + numCompte + "," + strMontantC.Replace(',', '.') + "," + dateNow + ")", sc);
                cmd.ExecuteNonQuery();
                rdr.Close();

                // SAUVEGARDE DU MOUVEMENT EFFECTUE
                cmd = new SqlCommand("SELECT numOp FROM TMvt ORDER BY numOP DESC", sc);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                int numOp = 1;
                try
                {
                    if (!rdr.IsDBNull(0))
                        numOp = rdr.GetInt32(0);
                }
                catch (Exception e) { }
                rdr.Close();
                numOp++;
                cmd = new SqlCommand("INSERT INTO TMvt(numOp,numCompte,codeOp,montant,date) VALUES(" + numOp + "," + numCompte + "," + 1 + "," + strMontant.Replace(',', '.') + "," + dateNow + ")", sc);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { return e.ToString(); }
            finally
            {
                rdr.Close();
                sc.Close();
            }
            return "OK";
        }
        string IAgence1.connecter(string numCompte, string motDePasse)
        {
            if (sc != null && sc.State == ConnectionState.Closed)
                sc.Open();
            try 
            {
                cmd = new SqlCommand("SELECT * FROM TCompte WHERE num = " + numCompte + " AND motDePasse = " + motDePasse, sc);
                rdr = cmd.ExecuteReader();
                if (!rdr.Read()){
                    rdr.Close();
                    return "Numéro de compte ou mot-de-passe est incorrecte!";
                }
            }
            catch (Exception e) { return e.ToString(); }
            finally
            {
                rdr.Close();
                sc.Close();
            }
            return "OK";
        }
        string IAgence1.getInfos(string numCompte)
        {
            if (sc != null && sc.State == ConnectionState.Closed)
                sc.Open();
            string ret = "";
            try 
            {
                cmd = new SqlCommand("SELECT nom, prenom FROM TCompte WHERE num = " + numCompte, sc);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                    ret += rdr.GetString(0).Trim() + " " + rdr.GetString(1).Trim();
            }
            catch (Exception e) { return e.ToString(); }
            finally
            {
                rdr.Close();
                sc.Close();
            }
            return ret;
        }

        string IAgence1.verifierCompteBeneficiaire(string beneficiaire)
        {
            if (sc != null && sc.State == ConnectionState.Closed)
                sc.Open();
            try
            {
                // VERIFIER L'EXISTENCE DU COMPTE BENEFICIAIRE
                cmd = new SqlCommand("SELECT * FROM TCompte WHERE num =" + beneficiaire, sc);
                rdr = cmd.ExecuteReader();
                if (!(int.Parse(beneficiaire) == 1012345678))
                {
                    rdr.Close();
                    return "Numéro de compte du bénéficiaire est invalide!"; 
                }
            }
            catch (Exception e) { return e.ToString(); }
            finally
            {
                rdr.Close();
                sc.Close();
            }
            return "OK";
        }
    }
}
