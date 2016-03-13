using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace agence1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Définition du port
                TcpChannel Port = new TcpChannel(7001);
                // Publication
                ChannelServices.RegisterChannel(Port);
                // Démarrage du serveur
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(MesMethodes), "MesMethodes", WellKnownObjectMode.Singleton);
                Console.WriteLine("Le serveur AGENCE1 a bien demarre.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Echec du demarrage du serveur " + ex.Message);
                Console.ReadLine();
            }
        }
    }
}
