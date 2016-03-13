using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iagence
{
    public interface IAgence3
    {
        string getSolde(string numCompte);
        string getHistoriqueSoldes(string numCompte);
        string getHistoriqueMouvements(string numCompte);
        string effectuerVirement(string numCompte, string beneficiaire, string montant, string statut);
        string retrait(string numCompte, string montant);
        string verser(string numCompte, string montant);
        string connecter(string numCompte, string motDePasse);
        string getInfos(string numCompte);
        string verifierCompteBeneficiaire(string beneficiaire);
    }
}
