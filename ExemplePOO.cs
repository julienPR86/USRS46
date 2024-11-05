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
            Maison UneMaison = new Maison("11 Rue des Chartreux, 69001 Lyon",58f,4,false);
            Maison UneAutreMaison = new Maison("4 place Saint Louis, 22100 Dinan",86.5f,5,true);
            Maison UneDerniereMaison = new Maison("26 Boulevard Claude Lorrin, 40100 Dax",25.2f,2,false);

            Maison[] CatalogueMaisons = new Maison[] {UneMaison, UneAutreMaison, UneDerniereMaison};

            foreach(Maison M  in CatalogueMaisons)
            {
                Console.WriteLine("Adresse = {0}\n", M.Adresse);
                Console.WriteLine("Superficie = {0}m²\n", M.Superficie);
                Console.WriteLine("Nombre de pièces = {0}\n", M.NbPieces);
                Console.WriteLine("Présence d'un jardin = {0}", M.Jardin ? "Oui" : "Non");
            }
        }
    }
}
