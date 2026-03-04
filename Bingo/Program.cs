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
		}
	}
}
