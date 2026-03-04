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
		public string[,] Kartyanap { get; set; }
		public BingoJatekos(string nev)
		{
			Nev = nev;
			Kartyanap = new string[5, 5];
		}
		public void Kereses(string fajlnev)
		{
			string[] sorok = File.ReadAllLines(fajlnev); 
			for (int i = 0; i < 5; i++)
			{
				string[] szamok = sorok[i].Split(';'); 
				for (int j = 0; j < 5; j++)
				{
					Kartyanap[i, j] = szamok[j].Trim(); 
				}
			}
		}
		public void SorsoltSzamotJelol(string sorsoltSzam)
		{
			bool talalt = false;

			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (Kartyanap[i, j] == sorsoltSzam) 
					{
						Kartyanap[i, j] = "X";  
						talalt = true;
						break;
					}
				}
				if (talalt) break; 
			}
		}
		public bool BingoEll()
		{
			for (int i = 0; i < 5; i++)
			{
				bool teljesSor = true;
				for (int j = 0; j < 5; j++)
				{
					if (Kartyanap[i, j] != "X")  
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
					if (Kartyanap[i, j] != "X")  
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
				if (Kartyanap[i, i] != "X")  
				{
					foAtlo = false;
					break;
				}
			}
			if (foAtlo) return true;  

			bool mellekAtlo = true;
			for (int i = 0; i < 5; i++)
			{
				if (Kartyanap[i, 4 - i] != "X")  
				{
					mellekAtlo = false;
					break;
				}
			}
			if (mellekAtlo) return true; 

			return false; 
		}
		public void Megjelenites(List<int> kihuzottSzamokLista)
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (i == 2 && j == 2)
					{
						Console.Write(" X ");  
					}
					else
					{
						if (int.TryParse(Kartyanap[i, j], out int szam)) 
						{
							if (kihuzottSzamokLista.Contains(szam))
							{
								Console.Write($" {szam} "); 
							}
							else
							{
								Console.Write($" 0 ");  
							}
						}
						else
						{
							Console.Write(" 0 ");  
						}
					}
				}
				Console.WriteLine();  
			}
		}
	}
}
