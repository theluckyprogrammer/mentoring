using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    internal class CastingDemo : Demo
    {

        public override void Run()
        {
           int x2 = 0;
           int wynik = 7 / x2; 
           Console.WriteLine(wynik);   
           Console.ReadKey();
            
        }


    }
}

