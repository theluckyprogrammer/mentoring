﻿using DemoRunner;
using System.Runtime.InteropServices.Marshalling;

namespace Test
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Demo switchDemo = new SwitchStatementDemo();
            Demo ArraysDemo = new ArraysDemo();
            Demo regexDemo = new RegexDemo();

            Demo inheritanceDemo = new InheritanceDemo();
            inheritanceDemo.Run();            
            

            

            regexDemo.Run();
        }

    }
}