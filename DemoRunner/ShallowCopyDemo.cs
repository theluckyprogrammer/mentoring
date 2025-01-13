using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ShallowCopyDemo : Demo
    {
        public ShallowCopyDemo()
        {
           
        }

        public override void Run()
        {
            int test1 = 7, test2 = 6;
            ADD(test1, test2);

            Auto b1 = new Auto();
            Auto b2 = b1.Clone() as Auto;
            
            List<object> list = new List<object>();
            list.Add(b1);
            list.Add(b2);
            list.Add(new Motor());
            list.Add(new Motor());
            list.Add(new Motor());
            list.Add(new Auto());

            var clonableObject = list.Where(x => x is ICloneable).ToList();

            foreach(ICloneable o in clonableObject)
            {
                var newO = o.Clone();

            }


            ADD(b1,b2);
        }

        public int ADD(int x, int y)
        {
            int wynik = x + y;
            x = wynik;
            return wynik;
        }

        public int ADD(Auto a1, Auto a2)
        {
            int wynik = a1.x + a2.y;
            a1.x +=  wynik;
            return wynik;
        }


        public class Auto : ICloneable
        {
            public int x = 7, y = 6;
            public string FuelKind { get; private set; }
            public Auto() 
            {

                FuelKind = "benzyna";
            }

           

            public string GO()
            {
                return "jade po drodze, napędza mnie " + FuelKind;
            }

            public object Clone()
            {
                Auto result = new Auto();
                result.y = this.y;
                result.x = this.x;

                return result;

            }
        }

        public class Motor 
        {
            public int x = 2, y = 2;
            public string FuelKind { get; private set; }
            public Motor()
            {

                FuelKind = "benzyna";
            }



            public string GO()
            {
                return "jade po drodze, napędza mnie " + FuelKind;
            }

            public object Clone()
            {
                Auto result = new Auto();
                result.y = this.y;
                result.x = this.x;

                return result;

            }
        }
    }
}
