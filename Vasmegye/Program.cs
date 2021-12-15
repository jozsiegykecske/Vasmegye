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
      HetediKFeladat();
      NyolcadikFeladat();
      Console.ReadKey();
    }

    private static void NyolcadikFeladat()
    {
      int i = 0;
      while (i < lista.Count && !(Convert.ToInt32(lista[i].szuletes.ToString().Substring(2,4))==0224))
      {
        i++;
      }
      if (i<lista.Count)
      {
        Console.WriteLine("Született szökőnapon baba!");
      }
      else
      {
        Console.WriteLine("Nem született szökőnapon baba!");
      }
    }

    private static void HetediKFeladat()
    {
      int min = int.MaxValue;
      int minnem = 0;
      int max = int.MinValue;
      int maxnem = 0;
      foreach (var l in lista)
      {
        if (Convert.ToInt32(l.szuletes.ToString().Substring(0,2))<min)
        {
          min = Convert.ToInt32(l.szuletes.ToString().Substring(0, 2));
          minnem = l.nem;
        }
        else if (Convert.ToInt32(l.szuletes.ToString().Substring(0, 2)) > max)
        {
          max = Convert.ToInt32(l.szuletes.ToString().Substring(0, 2));
          maxnem= l.nem;
        }
      }
      string kezdoev = minnem < 3 ? "19" : "20" + min.ToString();
      string vegev = maxnem < 3 ? "19" : "20" + max.ToString();
      Console.WriteLine($"A vizsgált időszak: {kezdoev} - {vegev}");
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
      Console.WriteLine("3.feladat:");
      for (int i = 0; i < lista.Count; i++)
      {
        if (!CdvEll(lista[i]))
        {
          Console.WriteLine($"\tHibás a {lista[i].nem}-{lista[i].szuletes}-{lista[i].megkulonbozteto} személyi azonosító");
          lista.RemoveAt(i);
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
