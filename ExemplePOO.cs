using System;

namespace ExemplePOO
{
    public class Maison
    {
        public string Adresse;
        public float Superficie;
        public int NbPieces;
        public bool Jardin;

        public Maison(string adresse, float superficie, int nbPieces, bool jardin)
        {
            Adresse = adresse;
            Superficie = superficie;
            NbPieces = nbPieces;
            Jardin = jardin;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Maison UneMaison = new Maison();

            Console.WriteLine("Adresse = {0}", UneMaison.Adresse);
            Console.WriteLine("Superficie = {0}", UneMaison.Superficie);
            Console.WriteLine("Nombre de pièces = {0}", UneMaison.NbPieces);
            Console.WriteLine("Présence d'un jardin = {0}", UneMaison.Jardin);
        }
    }
}
