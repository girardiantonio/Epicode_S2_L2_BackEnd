using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Epicode_U4_W2_D2_2
{
    internal class Appartamento
    {
        #region Paramethers

        private int NVani { get; set; }
        private bool Terrazza { get; set; }
        private bool Giardino { get; set; }
        private int Tipologia { get; set; } 
        private int MQ { get; set; }
        private int ValoreMQ { get; set; }
        private int Zona { get; set; }

        public static List<Appartamento> AppartamentiList { get; set; } = new List<Appartamento>();

        #endregion

        #region Constructors

        public Appartamento(int nvani, bool terrazza, bool giardino, int tipologia, int mq, int zona) 
        {
            NVani = nvani;
            Terrazza = terrazza;
            Giardino = giardino;
            MQ = mq;
            Zona = zona;
            Tipologia = tipologia;

            ValoreMQ = CalcoloMQ(mq, Zona);
        }

        #endregion

        #region Methods

        private static int CalcoloMQ(int mq, int zona)
        {
            int valoreAlMQ = 0;
            switch (zona)
            { 
                case 1:
                    valoreAlMQ = 1200;
                    break;
                case 2:
                    valoreAlMQ = 1000;
                    break;
                case 3:
                    valoreAlMQ = 900;
                    break;
                case 4:
                    valoreAlMQ = 750;
                    break;
                case 5:
                    valoreAlMQ = 600;
                    break;
            }

            return valoreAlMQ * mq;
        }

        public static void Menu()
        {
            Console.Clear();

            Console.WriteLine("================================");
            Console.WriteLine("1 - Stampa appuntamenti");
            Console.WriteLine("2 - Aggiungi appuntamento");
            Console.WriteLine("3 - Cerca un appuntamento");
            Console.WriteLine("================================");

            Console.Write("Scelta: ");
            int choice;
            try { choice = Convert.ToInt32(Console.ReadLine()); }
            catch { choice = 0; }
            Console.Clear();

            switch (choice)
            {
                case 1:
                    StampaAppartamenti();
                    break;
                case 2:
                    AggiungiAppartamento();
                    break;
                case 3:
                    CercaAppartamento();
                    break;
                default:
                    Console.WriteLine("Inserire un valore valido");
                    break;
            }
        }

        private static void StampaAppartamenti()
        {
            for(int i = 0; i < AppartamentiList.Count; i++)
                StampaAppartamento(AppartamentiList[i]);

            Console.ReadLine();
        }
        private static void StampaAppartamento(Appartamento appartamento)
        {
            Console.WriteLine($"{appartamento.NVani} vani.");

            if (appartamento.Terrazza)
                Console.WriteLine("Appartamento con terrazza.");
            if (appartamento.Giardino)
                Console.WriteLine("Appartamento con giardino.");

            Console.Write($"Tipo di appartamento ");
            switch(appartamento.Tipologia)
            {
                case 1:
                    Console.WriteLine("Villa");
                    break; 
                case 2:
                    Console.WriteLine("Appartamento in condominio");
                    break; 
                default:
                    Console.WriteLine("Catapecchia");
                    break;
            }
            Console.WriteLine($"{appartamento.MQ} metri quadri.");
            Console.Write($"Zona di appartenenza: ");
            switch (appartamento.Zona)
            {
                case 1:
                    Console.WriteLine("Centro\n");
                    break;
                case 2:
                    Console.WriteLine("Zona 1\n");
                    break;
                case 3:
                    Console.WriteLine("Zona 2\n");
                    break;
                case 4:
                    Console.WriteLine("Zona 3\n");
                    break;
                default:
                    Console.WriteLine("Periferia\n");
                    break;
            }
        }
       
        private static void AggiungiAppartamento()
        {
            //Numero di vani
            Console.Write("Inseire numero di vani: ");
            int nvani;
            try { nvani = Convert.ToInt32(Console.ReadLine()); }
            catch { nvani = 2; }
            nvani = nvani > 0 ? nvani : 1;

            //Presenza giardino
            Console.WriteLine("\nCon giardino?");
            Console.WriteLine("1) Sì");
            Console.WriteLine("2) No");
            Console.Write("Scelta: ");
            bool giardino = false;
            if(Console.ReadLine() == "1")
                giardino = true;

            //Presenza terrazzo
            Console.WriteLine("\nCon terrazzo?");
            Console.WriteLine("1) Sì");
            Console.WriteLine("2) No");
            Console.Write("Scelta: ");
            bool terrazzo = false;
            if (Console.ReadLine() == "1")
                terrazzo = true;

            //Tipo appartamento
            Console.WriteLine("\nTipologia immobile:");
            Console.WriteLine("1) Villa");
            Console.WriteLine("2) Appartamento in condominio");
            Console.WriteLine("3) Catapecchia");
            Console.Write("Scelta: ");
            int tipologia;
            try { tipologia = Convert.ToInt32(Console.ReadLine()); }
            catch { tipologia = 3; }

            //Metri quadrati
            Console.Write("\nMetri quadrati: ");
            int mq;
            try { mq = Convert.ToInt32(Console.ReadLine()); }
            catch { mq = 1; }

            //Zona appartenenza
            int zona;
            Console.WriteLine("\nZona di appartenenza:");
            Console.WriteLine("1) Centro");
            Console.WriteLine("2) Zona 1");
            Console.WriteLine("3) Zona 2");
            Console.WriteLine("4) Zona 3");
            Console.WriteLine("5) Periferia");

            try { zona = Convert.ToInt32(Console.ReadLine()); }
            catch { zona = 5; }

            AppartamentiList.Add(new Appartamento(nvani, terrazzo, giardino, tipologia, mq, zona));
        
        }
        private static void CercaAppartamento()
        {
            //Vani
            Console.Write("Inserire il minimo di vani: ");
            int nvani;
            try { nvani = Convert.ToInt32(Console.ReadLine()); }
            catch { nvani = 1; }

            //Metri quadrati
            Console.Write("\nInserire il minimo di metri quadrati: ");
            int mq;
            try { mq = Convert.ToInt32(Console.ReadLine()); }
            catch { mq = 1; }

            //Tipo appartamento
            Console.WriteLine("\nTipologia immobile:");
            Console.WriteLine("1) Villa");
            Console.WriteLine("2) Appartamento in condominio");
            Console.WriteLine("3) Catapecchia");
            Console.Write("Scelta: ");
            int tipologia;
            try { tipologia = Convert.ToInt32(Console.ReadLine()); }
            catch { tipologia = 3; }


            //Zona
            Console.WriteLine("\nInserire la zona");
            Console.WriteLine("1) Centro");
            Console.WriteLine("2) Zona 1");
            Console.WriteLine("3) Zona 2");
            Console.WriteLine("4) Zona 3");
            Console.WriteLine("5) Periferia");
            Console.Write("Scelta: ");
            int zona;
            try { zona = Convert.ToInt32(Console.ReadLine()); }
            catch { zona = 5; }

            Console.Clear();

            for(int i = 0; i < AppartamentiList.Count; i++)
                if (
                      AppartamentiList[i].NVani >= nvani         &&
                      AppartamentiList[i].MQ >= mq               &&
                      AppartamentiList[i].Tipologia == tipologia &&
                      AppartamentiList[i].Zona == zona
                    )
                    StampaAppartamento(AppartamentiList[i]);

            Console.ReadLine();
        }

        #endregion


    }
}
