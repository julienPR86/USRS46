using System;
using System.Text.RegularExpressions;

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
        public override string ToString()
        {
            string toString = String.Format("Adresse = {0}\n", this.Adresse);
            toString += String.Format("Superficie = {0}m²\n", this.Superficie);
            toString += String.Format("Nombre de pièces = {0}\n", this.NbPieces);
            toString += String.Format("Présence d'un jardin = {0}\n", this.Jardin ? "Oui" : "Non");
            toString += String.Format("> VALEUR = {0}$", this.EvaluationValeur());
            return toString;
        }

        public float EvaluationValeur()
        {
            int facteur = 3000;

            if (this.Jardin) { facteur += 500; }
            if (this.NbPieces > 3) { facteur += 200; }

            if (Regex.IsMatch(this.Adresse, @"\bParis\b")) { facteur += 7000; }
            else if (Regex.IsMatch(this.Adresse, @"\bLyon\b")) { facteur += 2000; }

            return this.Superficie * facteur ;
        }
    }
    public class Terrain
    {
        private string adresse;
        private float superficie;
        private int NbCotesClotures;
        private int CoutFinirCloture;

        public Terrain(string adresse, float superficie, int NbCotesClotures, int CoutFinirCloture)
        {
            this.adresse = adresse;
            this.superficie = superficie;
            this.NbCotesClotures = NbCotesClotures;
            this.CoutFinirCloture = CoutFinirCloture;
        }
        public override string ToString()
        {
            string toString = String.Format("Adresse = {0}\n", this.adresse);
            toString += String.Format("Superficie = {0}m²\n", this.superficie);
            toString += String.Format("> VALEUR = {0}$", this.EvaluationValeur());
            return toString;
        }
        public float EvaluationValeur()
        {
            return 0;
        }
        public int CoutFinitCloture()
        {
            return 0;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Maison UneMaison = new Maison("11 Rue des Chartreux, 69001 Lyon",58f,4,false);
            Maison UneAutreMaison = new Maison("4 place Saint Louis, 22100 Dinan",86.5f,5,true);
            Maison UneDerniereMaison = new Maison("26 Boulevard Claude Lorrin, 40100 Dax",25.2f,2,false);

            Terrain UnTerrain = new Terrain("15 Rue des Chartreux, 69001 Lyon", 124f, 4, 0);
            Terrain UnAutreTerrain = new Terrain("8 place Saint Louis, 22100 Dinan", 49f, 48, 2);
            Terrain UnDernierTerrain = new Terrain("30 Boulevard Claude Lorrin, 40100 Dax", 256f, 21, 4);

            Maison[] CatalogueMaisons = new Maison[] {UneMaison, UneAutreMaison, UneDerniereMaison};
            Terrain[] CatalogueTerrains = new Terrain[] {UnTerrain, UnAutreTerrain, UnDernierTerrain};

            foreach(Maison M in CatalogueMaisons)
            {
                Console.WriteLine(M+"\n");
            }
            foreach(Terrain T in CatalogueTerrains)
            {
                Console.WriteLine(T+"\n");
            }
        }
    }
}
