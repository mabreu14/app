using System;
using System.Collections.Generic;
using app.utility;

namespace app.console
{
  class Program
  {
    static void Main(string[] args)
    {
      var generator = new LabelGenerator(new List<string>
      {
        "a",
        "b",
        "c"
      }, 200);

      foreach (var label in generator)
        Console.Out.WriteLine(label); 

    }
  }
}