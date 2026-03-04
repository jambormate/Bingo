namespace Bingo
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<BingoJatekos> jatekosok = new List<BingoJatekos>();
			string[] jatekosNevek = File.ReadAllLines("nevek.text");
			foreach (string nev in jatekosNevek)
			{
				BingoJatekos jatekos = new BingoJatekos(nev);
				jatekos.Kereses(nev); 
				jatekosok.Add(jatekos);
			}
			Console.WriteLine("4. feladat: A játékosok száma: " + jatekosok.Count);

			Random rand = new Random();
			HashSet<int> kihuzottSzamok = new HashSet<int>();
			List<int> kihuzottSzamokLista = new List<int>();

			int sorsoltSzamIndex = 0;

            Console.WriteLine("7. feladat: Kihúzott számok");

            while (true)
            {
                int szam = rand.Next(1, 76);
                if (!kihuzottSzamok.Contains(szam))
                {
                    kihuzottSzamok.Add(szam);
                    kihuzottSzamokLista.Add(szam);
                    sorsoltSzamIndex++;

                    Console.Write($"{sorsoltSzamIndex,2}.->{szam,-2} ");

                    foreach (var jatekos in jatekosok)
                    {
                        jatekos.SorsoltSzamotJelol(szam.ToString());
                    }

                    List<BingoJatekos> nyertesek = new List<BingoJatekos>();

                    foreach (var jatekos in jatekosok)
                    {
                        if (jatekos.BingoEll())
                        {
                            nyertesek.Add(jatekos);
                        }
                    }

                    if (nyertesek.Count > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("8. feladat: Lehetséges nyertes(ek):");

                        foreach (var nyertes in nyertesek)
                        {
                            Console.WriteLine(nyertes.Nev + ":");
                            nyertes.Megjelenites();
                        }
                        break;
                    }
                }
            }
        }
	}
}
