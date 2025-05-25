using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public class SwitchStatementDemo : Demo
    {
        public override void Run()
        {
            PropertyPaternMatching();

            RelationalPatternMatching();

            SimplifiedSwitch();

            SimpleSwitch();


        }

        private static void PropertyPaternMatching()
        {
            Person person = new Person { Name = "Alice", Age = 30 };

            string description = person switch
            {
                { Age: < 13 } => "Child",
                { Age: >= 13 and < 20 } => "Teenager",
                { Age: >= 20 and < 65 } => "Adult",
                _ => "Senior"
            };

            Console.WriteLine(description);
        }

        private static void RelationalPatternMatching()
        {
            int age = 25;

            string category = age switch
            {
                < 13 => "Child",
                >= 13 and < 20 => "Teenager",
                >= 20 and < 65 => "Adult",
                _ => "Senior"
            };

            Console.WriteLine(category);
        }

        private static void SimplifiedSwitch()
        {
            int number = -1;

            string result = number switch
            {
                1 => "One",
                2 => "Two",
                3 => "Three",
                _ => "Number is not 1, 2, or 3"
            };

            Console.WriteLine(result);
        }

        private static void SimpleSwitch()
        {
            int dayOfWeek =  (int)DateTime.Now.DayOfWeek;

            switch (dayOfWeek)
            {
                case 0:
                    Console.WriteLine("It's Sunday!");
                    break;
                case 1:
                    Console.WriteLine("It's Monday!");
                    break;
                case 2:
                    Console.WriteLine("It's Tuesday!");
                    break;
                case 3:
                    Console.WriteLine("It's Wednesday!");
                    break;
                case 4:
                    Console.WriteLine("It's Thursday!");
                    break;
                case 5:
                    Console.WriteLine("It's Friday!");
                    break;
                case 6:
                    Console.WriteLine("It's Saturday!");
                    break;
                default:
                    Console.WriteLine("Unknown day.");
                    break;
            }
        }



    private class Person  
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

    }
}
