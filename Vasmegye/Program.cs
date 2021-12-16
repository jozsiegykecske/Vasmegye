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
    static int osszes = 0;
    static int db = 0;
    static List<Azonosito> lista = new List<Azonosito>();
    static void Main(string[] args)
    {
      Beolvasas();
      NegyedikFeladat();
      OtodikFeladat();
      HatodikFeladat();
      Console.ReadKey();
    }

    private static void HatodikFeladat()
    {
      Console.WriteLine($"6.feladat: A fiú csecsemők száma: {db} db");
    }

    private static void OtodikFeladat()
    {
      Console.WriteLine($"5. feladat: {osszes} db csecsemő született!");
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
      osszes = lista.Count();
    }
    public static bool CdvEll(Azonosito be)
    {
      int ossz = 0;
      string a = be.nem.ToString() + be.szuletes.ToString() + be.megkulonbozteto.ToString();
      for (int i = 0; i < a.Length-1; i++)
      {
        ossz += Convert.ToInt32(a[i]) * (10 - i);
      }
      if (be.nem == 1 || be.nem == 3)
      {
        db++;
      }
      if (Convert.ToInt32(a.Substring(a.Length-1))==(ossz%11))
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
