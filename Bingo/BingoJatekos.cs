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
					Kartyanap[i, j] = szamok[j];
				}
			}
		}
	}
}
