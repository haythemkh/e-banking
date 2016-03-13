using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Services : IServices
    {
        private static iagence.IAgence1 agence1;
        private static iagence.IAgence2 agence2;
        private static iagence.IAgence3 agence3;
        private static string agenceC;
        private String portAgence;

        private void determinerAgence(string numCompte)
        {
            agence1 = null; agence2 = null; agence3 = null;
            agenceC = "";

            IChannel[] regChannels = ChannelServices.RegisteredChannels;
            if(regChannels.Length > 0){
                IChannel channel = (IChannel)ChannelServices.GetChannel(regChannels[0].ChannelName);
                if(channel != null) ChannelServices.UnregisterChannel(channel);
            }

            switch(numCompte.ToString().Substring(0, 3)){
                case "101": {
                    portAgence = "7001";
                    try
                    {
                        // Definition du port
                        TcpChannel Port = new TcpChannel();
                        // Publication
                        ChannelServices.RegisterChannel(Port);
                        // Invocation du serveur
                        agenceC = "1";
                        agence1 = (iagence.IAgence1)Activator.GetObject(typeof(iagence.IAgence1), "tcp://localhost:" + portAgence + "/MesMethodes");
                    }
                    catch (Exception ex) { }
                    break; 
                }
                case "102": {
                    portAgence = "7002";
                    try
                    {
                        // Definition du port
                        TcpChannel Port = new TcpChannel();
                        // Publication
                        ChannelServices.RegisterChannel(Port);
                        // Invocation du serveur
                        agenceC = "2";
                        agence2 = (iagence.IAgence2)Activator.GetObject(typeof(iagence.IAgence2), "tcp://localhost:" + portAgence + "/MesMethodes");
                    }
                    catch (Exception ex) { }
                    break; 
                }
                case "103": {
                    portAgence = "7003";
                    try
                    {
                        // Definition du port
                        TcpChannel Port = new TcpChannel();
                        // Publication
                        ChannelServices.RegisterChannel(Port);
                        // Invocation du serveur
                        agenceC = "3";
                        agence3 = (iagence.IAgence3)Activator.GetObject(typeof(iagence.IAgence3), "tcp://localhost:" + portAgence + "/MesMethodes");
                    }
                    catch (Exception ex) { }
                    break; 
                }
            }
        }

        public string getSolde(string numCompte) {
            determinerAgence(numCompte);
            if (agenceC == "1")
            {
                if (agence1 == null) return "Erreur de connexion à l'agence!";
                return agence1.getSolde(numCompte);
            }
            else if (agenceC == "2")
            {
                if (agence2 == null) return "Erreur de connexion à l'agence!";
                return agence2.getSolde(numCompte);
            }
            else if (agenceC == "3")
            {
                if (agence3 == null) return "Erreur de connexion à l'agence!";
                return agence3.getSolde(numCompte);
            }
            return null;
        }
        public string getHistoriqueSoldes(string numCompte) {
            determinerAgence(numCompte);
            if (agenceC == "1")
            {
                if (agence1 == null) return "Erreur de connexion à l'agence!";
                return agence1.getHistoriqueSoldes(numCompte);
            }
            else if (agenceC == "2")
            {
                if (agence2 == null) return "Erreur de connexion à l'agence!";
                return agence2.getHistoriqueSoldes(numCompte);
            }
            else if (agenceC == "3")
            {
                if (agence3 == null) return "Erreur de connexion à l'agence!";
                return agence3.getHistoriqueSoldes(numCompte);
            }
            return null;
        }
        public string getHistoriqueMouvements(string numCompte) {
            determinerAgence(numCompte);
            if (agenceC == "1")
            {
                if (agence1 == null) return "Erreur de connexion à l'agence!";
                return agence1.getHistoriqueMouvements(numCompte);
            }
            else if (agenceC == "2")
            {
                if (agence2 == null) return "Erreur de connexion à l'agence!";
                return agence2.getHistoriqueMouvements(numCompte);
            }
            else if (agenceC == "3")
            {
                if (agence2 == null) return "Erreur de connexion à l'agence!";
                return agence2.getHistoriqueMouvements(numCompte);
            }
            return null;
        }
        public string effectuerVirement(string numCompte, string beneficiaire, string montant) {
            string v = verifierCompteBeneficiaire(beneficiaire);
            if (v != "OK") return v;
            determinerAgence(numCompte);
            string ret = "";
            if (agenceC == "1")
            {
                if (agence1 == null) return "Erreur de connexion à l'agence!";
                ret = agence1.effectuerVirement(numCompte, beneficiaire, montant, "resp");
            }
            else if (agenceC == "2")
            {
                if (agence2 == null) return "Erreur de connexion à l'agence!";
                ret = agence2.effectuerVirement(numCompte, beneficiaire, montant, "resp");
            }
            else if (agenceC == "3")
            {
                if (agence3 == null) return "Erreur de connexion à l'agence!";
                ret = agence3.effectuerVirement(numCompte, beneficiaire, montant, "resp");
            }
            if (ret == "OK")
            {
                determinerAgence(beneficiaire);
                if (agenceC == "1")
                {
                    if (agence1 == null) return "Erreur de connexion à l'agence!";
                    return agence1.effectuerVirement(numCompte, beneficiaire, montant, "benef");
                }
                else if (agenceC == "2")
                {
                    if (agence2 == null) return "Erreur de connexion à l'agence!";
                    return agence2.effectuerVirement(numCompte, beneficiaire, montant, "benef");
                }
                else if (agenceC == "3")
                {
                    if (agence3 == null) return "Erreur de connexion à l'agence!";
                    return agence3.effectuerVirement(numCompte, beneficiaire, montant, "benef");
                }
            }
            return ret;
        }
        public string retrait(string numCompte, string montant) {
            determinerAgence(numCompte);
            if (agenceC == "1")
            {
                if (agence1 == null) return "Erreur de connexion à l'agence!";
                return agence1.retrait(numCompte, montant);
            }
            else if (agenceC == "2")
            {
                if (agence2 == null) return "Erreur de connexion à l'agence!";
                return agence2.retrait(numCompte, montant);
            }
            else if (agenceC == "3")
            {
                if (agence3 == null) return "Erreur de connexion à l'agence!";
                return agence3.retrait(numCompte, montant);
            }
            return null;
        }
        public string verser(string numCompte, string montant) {
            determinerAgence(numCompte);
            if (agenceC == "1")
            {
                if (agence1 == null) return "Erreur de connexion à l'agence!";
                return agence1.verser(numCompte, montant);
            }
            else if (agenceC == "2")
            {
                if (agence2 == null) return "Erreur de connexion à l'agence!";
                return agence2.verser(numCompte, montant);
            }
            else if (agenceC == "3")
            {
                if (agence3 == null) return "Erreur de connexion à l'agence!";
                return agence3.verser(numCompte, montant);
            }
            return null;
        }
        public string connecter(string numCompte, string motDePasse) {
            determinerAgence(numCompte);
            if (agenceC == "1")
            {
                if (agence1 == null) return "Erreur de connexion à l'agence!";
                return agence1.connecter(numCompte, motDePasse);
            }
            else if (agenceC == "2")
            {
                if (agence2 == null) return "Erreur de connexion à l'agence!";
                return agence2.connecter(numCompte, motDePasse);
            }
            else if (agenceC == "3")
            {
                if (agence3 == null) return "Erreur de connexion à l'agence!";
                return agence3.connecter(numCompte, motDePasse);
            }
            return null;
        }
        public string getInfos(string numCompte) {
            determinerAgence(numCompte);
            if (agenceC == "1")
            {
                if (agence1 == null) return "Erreur de connexion à l'agence!";
                return agence1.getInfos(numCompte);
            }
            else if (agenceC == "2")
            {
                if (agence2 == null) return "Erreur de connexion à l'agence!";
                return agence2.getInfos(numCompte);
            }
            else if (agenceC == "3")
            {
                if (agence3 == null) return "Erreur de connexion à l'agence!";
                return agence3.getInfos(numCompte);
            }
            return null;
        }
        private string verifierCompteBeneficiaire(string beneficiaire)
        {
            determinerAgence(beneficiaire);
            if (agenceC == "1")
            {
                if (agence1 == null) return "Erreur de connexion à l'agence!";
                return agence1.verifierCompteBeneficiaire(beneficiaire);
            }
            else if (agenceC == "2")
            {
                if (agence2 == null) return "Erreur de connexion à l'agence!";
                return agence2.verifierCompteBeneficiaire(beneficiaire);
            }
            else if (agenceC == "3")
            {
                if (agence3 == null) return "Erreur de connexion à l'agence!";
                return agence3.verifierCompteBeneficiaire(beneficiaire);
            }
            return null;
        }
    }
}
