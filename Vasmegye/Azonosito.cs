using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vasmegye
{
  internal class Azonosito
  {
    public int nem { get; set; }
    public string szuletes { get; set; }
    public int megkulonbozteto { get; set; }
    public Azonosito(string be)
    {
      string[] a = be.Split('-');
      nem = Convert.ToInt32(a[0]);
      szuletes = a[1];
      megkulonbozteto = Convert.ToInt32(a[2]);
    }
  }
    
}
