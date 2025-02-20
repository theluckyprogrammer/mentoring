using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class ArraysDemo : Demo
    {

        public override void Run()
        {
           
            string markaSamochodu = "AUDI";
            string modelSamochodu = "Quattro";
            string markaimodel = markaSamochodu + modelSamochodu;

            int iloscCylindrow = 8;
            var konwersja = iloscCylindrow.ToString();

            char[] markaSamochodu2 = ['a', 'u', 'd', 'i'];
            var test = markaSamochodu2.ToString();

            int iloscZnakow = markaSamochodu.Length;
            int iloscZnakow2 = markaSamochodu2.Length;

            char cc1 = markaSamochodu[0];  // A
            char cc2 = markaSamochodu[1];  // U
            char cc3 = markaSamochodu[2];  // D
            char cc4 = markaSamochodu[3];  // I
                                           //  char cc5 = markaSamochodu[4];  // ArgumentOutOfRangeException();
            char lo1 = markaSamochodu[markaSamochodu.Length - 1];

            int ostatniIndex = markaSamochodu.Length - 1;
            lo1 = markaSamochodu[ostatniIndex];

            foreach (char c in markaSamochodu2)
            {
                Console.WriteLine(c);
            }
        }


        private static bool GetMeOnlyThreeCharacterLeghtWords(string word)
        {
            return word.Length == 3;
        }
    }
}

