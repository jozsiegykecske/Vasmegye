using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vasmegye
{
  internal class Program
  {
    static List<Azonosito> lista = new List<Azonosito>();
    static void Main(string[] args)
    {
      Beolvasas();
      NegyedikFeladat();
      OtodikFeladat();
      HatodikFeladat();
      HetedikFeladat();
      NyolcadikFeladat();
      KilencedikFeladat();
      TizesFeladat();
      TizenegyesFeladat();
      TizenKettesFeladat();
      Console.ReadKey();
    }

    private static void TizenKettesFeladat()
    {
      using (StreamWriter ki = new StreamWriter("lanyok.txt"))
      {
        foreach (var l in lista)
        {
          if (l.nem % 2 == 0)
          {
            ki.WriteLine($"{l.nem}-{l.szuletes}-{l.megkulonbozteto}");
          }
        }
      }
      using (StreamWriter ki = new StreamWriter("fiuk.txt"))
      {
        foreach (var l in lista)
        {
          if (l.nem % 2 != 0)
          {
            ki.WriteLine($"{l.nem}-{l.szuletes}-{l.megkulonbozteto}");
          }
        }
      }
    }

    private static void TizenegyesFeladat()
    {
      Console.WriteLine($"11 feladat: {lista.Count(x => x.nem > 2)} db gyerek született 2000 után.");

    }

    private static void TizesFeladat()
    {
      Dictionary<int, int> stat = new Dictionary<int, int>();
      foreach (var l in lista)
      {
        if (stat.ContainsKey(Convert.ToInt32(l.szuletes.Substring(2,4))))
        {
          stat[Convert.ToInt32(l.szuletes.Substring(2, 4))]++;
        }
        else
        {
          stat.Add(Convert.ToInt32(l.szuletes.Substring(2, 4)),1);
        }
      }
      int legnagyobbhonap = 0101;
      foreach (var s in stat)
      {
        if (s.Value>stat[legnagyobbhonap])
        {
          legnagyobbhonap = s.Key;
        }
      }
      Console.WriteLine($"10.feladat: Ezen a napon született a legtöbb ember: {legnagyobbhonap.ToString().Substring(0,2)}.{legnagyobbhonap.ToString().Substring(2)}.");
    }

    private static void KilencedikFeladat()
    {
      Dictionary<string, int> stat = new Dictionary<string, int>();
      foreach (var l in lista)
      {
        if (stat.ContainsKey(l.szuletes.Substring(0,2)))
        {
          stat[l.szuletes.Substring(0, 2)]++;
        }
        else
        {
          stat.Add(l.szuletes.Substring(0, 2),1);
        }
      }
      Console.WriteLine("9.feladat: ");
      foreach (var s in stat)
      {
        Console.WriteLine( Convert.ToInt32(s.Key) > 21 ? "\t19" + s.Key + " - " + s.Value + " db" : "\t20" + s.Key + " - " + s.Value + " db");
      }
    }

    private static void NyolcadikFeladat()
    {
      int i = 0;
      while (i < lista.Count && !(Convert.ToDouble(lista[i].szuletes.Substring(2,4))==0224) && !(Convert.ToInt32(lista[i].szuletes.Substring(0,2))%4==0))
      {
        i++;
      }
      if (i<lista.Count)
      {
        Console.WriteLine("8.feladat: Született szökőnapon baba!");
      }
      else
      {
        Console.WriteLine("8.feladat: Nem született szökőnapon baba!");
      }
    }

    private static void HetedikFeladat()
    {
      Dictionary<int, int> tizenkilenc = new Dictionary<int, int>();
      Dictionary<int, int> husz = new Dictionary<int, int>();
      foreach (var l in lista)
      {
        if (Convert.ToInt32(l.szuletes.Substring(0,2))>21)
        {
          if (!tizenkilenc.ContainsKey(Convert.ToInt32(l.szuletes.Substring(0, 2))))
          {
            tizenkilenc.Add(Convert.ToInt32(l.szuletes.Substring(0, 2)),1);
          }
        }
        else
        {
          if (!husz.ContainsKey(Convert.ToInt32(l.szuletes.Substring(0, 2))))
          {
            husz.Add(Convert.ToInt32(l.szuletes.Substring(0, 2)), 1);
          }
        }
      }
      Console.WriteLine($"7.feladat: A vizsgált időszak: 19{tizenkilenc.Min(x=>x.Key)} - 200{husz.Max(x=>x.Key)}");
    }

    private static void HatodikFeladat()
    {
      int db = 0;
      foreach (var l in lista)
      {
        if (l.nem==1 || l.nem==3)
        {
          db++;
        }
      }
      Console.WriteLine($"6.feladat: A fiú csecsemők száma: {db} db");
    }

    private static void OtodikFeladat()
    {
      Console.WriteLine($"5. feladat: {lista.Count} db csecsemő született!");
    }

    private static void NegyedikFeladat()
    {
      Console.WriteLine("4.feladat:");
      for (int i = 0; i < lista.Count; i++)
      {
        if (!CdvEll(lista[i]))
        {
          Console.WriteLine($"\tHibás a {lista[i].nem}-{lista[i].szuletes}-{lista[i].megkulonbozteto} személyi azonosító");
          lista.RemoveAt(i);
          i--;
        }
      }
    }

    private static void Beolvasas()
    {
      using (StreamReader be = new StreamReader("vas.txt"))
      {
        while (!be.EndOfStream)
        {
          lista.Add(new Azonosito(be.ReadLine()));
        }
      }
    }
    public static bool CdvEll(Azonosito be)
    {
      int ossz = 0;
      string a = be.nem.ToString() + be.szuletes.ToString() + be.megkulonbozteto.ToString();
      for (int i = 0; i < a.Length-1; i++)
      {
        ossz += Convert.ToInt32(a[i]) * (10 - i);
      }
      if (Convert.ToInt32(a.Substring(a.Length-1))==ossz%11)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
