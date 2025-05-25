using Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace DemoRunner
{
    internal class InheritanceDemo : Demo
    {
        public InheritanceDemo() : base("InheritanceDemo")
        {

        }
        public override void Run()
        {
            Vehicle auto = new Auto { Name = "BMW" };
            Vehicle airplane = new Airplane { Name = "Boeing 737" };
            Vehicle submarine = new Submarine("USS A");
            
            VehicleGo(auto);
            VehicleGo(airplane);
            VehicleGo(submarine);
        }


        private void VehicleGo(Vehicle vehicle)
        {
            Console.WriteLine(vehicle.GO());
        }



        
    }

}
