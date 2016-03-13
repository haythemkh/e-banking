using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Services
{
    [ServiceContract]
    public interface IServices
    {
        [OperationContract]
        string getSolde(string numCompte);
        [OperationContract]
        string getHistoriqueSoldes(string numCompte);
        [OperationContract]
        string getHistoriqueMouvements(string numCompte);
        [OperationContract]
        string effectuerVirement(string numCompte, string beneficiaire, string montant);
        [OperationContract]
        string retrait(string numCompte, string montant);
        [OperationContract]
        string verser(string numCompte, string montant);
        [OperationContract]
        string connecter(string numCompte, string motDePasse);
        [OperationContract]
        string getInfos(string numCompte);
    }
}
