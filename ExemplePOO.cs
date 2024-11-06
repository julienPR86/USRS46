using System;
using System.Text.RegularExpressions;

namespace ExemplePOO
{
    public class Piece
    {
        public int Superficie;
        public string Nom;

        public Piece(int superficie, string nom)
        {
            Superficie = superficie;
            Nom = nom;
        }
        
        public override string ToString()
        {
            string toString = String.Format("La pièce {0} fait {1}m²", this.Nom, this.Superficie);
            return toString;
        }
    }
    public class Bien
    {
        public string Adresse;
        public float Superficie;

        public Bien(string adresse, float superficie)
        {
        Adresse = adresse;
        Superficie = superficie;
        }
    
        public override string ToString()
        {
        string toString = String.Format("Adresse = {0}\n", this.Adresse);
        toString += String.Format("Superficie = {0}m²\n", this.Superficie);
        return toString;
        }

        public float EvaluationValeur()
        {
        int facteur = 3000;

        return this.Superficie * facteur ;
        }
    }
    public class Maison  : Bien
    {
        public int NbPieces;
        public bool Jardin;

        public Maison(string adresse, float superficie, int nbPieces, bool jardin) : base(adresse,superficie)
        {
        NbPieces = nbPieces;
        Jardin = jardin;
        }

        public override string ToString()
        {
        string toString = String.Format("Nombre de pièces = {0}\n", this.NbPieces);
        toString += String.Format("Présence d'un jardin = {0}\n", this.Jardin ? "Oui" : "Non");
        toString += String.Format("> VALEUR = {0}$\n", this.EvaluationValeur());
        return toString;
        }

        public new float EvaluationValeur()
        {
        int facteur = 3000;

        if (this.Jardin) { facteur += 500; }
        if (this.NbPieces > 3) { facteur += 200; }

        if (Regex.IsMatch(this.Adresse, @"\bParis\b")) { facteur += 7000; }
        else if (Regex.IsMatch(this.Adresse, @"\bLyon\b")) { facteur += 2000; }

        return this.Superficie * facteur ;
        }
    }
    public class Terrain : Bien
    {
        public int NbCotesClotures;
        public bool Riviere;

        public Terrain(string adresse, float superficie, int nbCotesClotures, bool riviere) : base(adresse,superficie)
        {
            NbCotesClotures = nbCotesClotures;
            Riviere = riviere;
        }

        public override string ToString()
        {
            string toString = String.Format("Nombre de cotés clorutés = {0}\n", this.NbCotesClotures);
            toString += String.Format("Présence d'une rivière = {0}\n", this.Riviere ? "Oui" : "Non");
            toString += String.Format("> VALEUR = {0}$\n", this.EvaluationValeur());
            return toString;
        }

        public new float EvaluationValeur()
        {
            int facteur = 3000;

            if (this.Riviere) { facteur += 600; }

            facteur += 100 * this.NbCotesClotures; 

            if (Regex.IsMatch(this.Adresse, @"\bParis\b")) { facteur += 7000; }
            else if (Regex.IsMatch(this.Adresse, @"\bLyon\b")) { facteur += 2000; }

            return this.Superficie * facteur ;
        }
    }
    
    public class Proprietaire
    {
        public string Nom;
        public string Prenom;
        public Bien[] Biens = new Bien[0];
        

        public Proprietaire(string nom, string prenom, Bien[] biens)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Biens = biens;
        }

        private string ListeBiens()
        {
            string listeBiens = "";
            foreach (Bien B in this.Biens)
            {
                listeBiens += String.Format("- {0} {1} au {2}\n", B.GetType().Name == "Maison" ? "Une" : "Un", B.GetType().Name, B.Adresse );
            }
            return listeBiens;
        }

        public override string ToString()
        {
            string toString = String.Format("{1} {0} {2}", this.Nom, this.Prenom, this.Biens?.Length !=0 ? "possède\n" : "ne possède aucun bien" );
            toString += ListeBiens();
            return toString;
        }   
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Maison UneMaison = new Maison("11 Rue des Chartreux, 69001 Lyon",58f,4,false);
            Maison UneAutreMaison = new Maison("4 place Saint Louis, 22100 Dinan",86.5f,5,true);
            Maison UneDerniereMaison = new Maison("26 Boulevard Claude Lorrin, 40100 Dax",25.2f,2,false);

            Terrain UnTerrain = new Terrain("55 route cabossée, 29130 Locmaria-Plouzané",5000f,2,true);
            Terrain UnAutreTerrain = new Terrain("102 route des volcans, 63000 Clermont-Ferrand",1500f,4,false);

            Bien[] CatalogueBiens = new Bien[] {UneMaison, UneAutreMaison, UneDerniereMaison, UnTerrain, UnAutreTerrain};

            foreach(Bien B in CatalogueBiens)
            {
                Console.WriteLine(B);
            }

            Proprietaire Elodie = new Proprietaire("Martin", "Elodie", new Bien[] {UneMaison, UnTerrain});
            Console.WriteLine(Elodie);

            Proprietaire Marc = new Proprietaire("Dupont", "Marc", new Bien[] {UneAutreMaison, UneDerniereMaison, UnAutreTerrain });
            Console.WriteLine(Marc);

            Proprietaire Leo = new Proprietaire("Marin", "Leo", new Bien[0]);
            Console.WriteLine(Leo);
        }
    }
}
