using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
	internal class BingoJatekos
	{
		public string Nev { get; set; }
        public string[,] Kartya { get; set; }
        public bool[,] Jelolve { get; set; }
        public BingoJatekos(string nev)
        {
            Nev = nev;
            Kartya = new string[5, 5];
            Jelolve = new bool[5, 5];
        }
        public void Kereses(string fajlnev)
        {
            string[] sorok = File.ReadAllLines(fajlnev);

            for (int i = 0; i < 5; i++)
            {
                string[] szamok = sorok[i].Split(';');

                for (int j = 0; j < 5; j++)
                {
                    Kartya[i, j] = szamok[j].Trim();
                }
            }

            Kartya[2, 2] = "X";
            Jelolve[2, 2] = true;
        }
        public void SorsoltSzamotJelol(string sorsoltSzam)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Kartya[i, j] == sorsoltSzam)
                    {
                        Jelolve[i, j] = true;
                    }
                }
            }
        }
        public bool BingoEll()
        {
            for (int i = 0; i < 5; i++)
            {
                bool teljesSor = true;
                for (int j = 0; j < 5; j++)
                {
                    if (!Jelolve[i, j])
                    {
                        teljesSor = false;
                        break;
                    }
                }
                if (teljesSor) return true;
            }

            for (int j = 0; j < 5; j++)
            {
                bool teljesOszlop = true;
                for (int i = 0; i < 5; i++)
                {
                    if (!Jelolve[i, j])
                    {
                        teljesOszlop = false;
                        break;
                    }
                }
                if (teljesOszlop) return true;
            }
            bool foAtlo = true;
            for (int i = 0; i < 5; i++)
            {
                if (!Jelolve[i, i])
                {
                    foAtlo = false;
                    break;
                }
            }
            if (foAtlo) return true;

            bool mellekAtlo = true;
            for (int i = 0; i < 5; i++)
            {
                if (!Jelolve[i, 4 - i])
                {
                    mellekAtlo = false;
                    break;
                }
            }
            if (mellekAtlo) return true;

            return false;
        }
        public void Megjelenites()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 2 && j == 2)
                    {
                        Console.Write($"{"X",3}");
                    }
                    else if (Jelolve[i, j])
                    {
                        Console.Write($"{Kartya[i, j],3}");
                    }
                    else
                    {
                        Console.Write($"{0,3}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
