using DemoRunner;
using System.Runtime.InteropServices.Marshalling;

namespace Abstract
{
    internal class Program
    {

        static void Main(string[] args)
        {
           
            Demo switchDemo = new SwitchStatementDemo();
            Demo arraysDemo = new ArraysDemo();
            Demo regexDemo = new RegexDemo();

            Demo inheritanceDemo = new InheritanceDemo();
            Demo castingDemo = new CastingDemo();
            Demo linqDemo = new LinqDemo();
            Demo shallowCopy = new  ShallowCopyDemo();
            Demo sendMailDemo = new SendMailDemo();

            linqDemo.Run();
          
        }

    }
}