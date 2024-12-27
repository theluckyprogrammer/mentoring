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



        abstract class Vehicle
        {
            public string Name;
            protected string Brand;
            protected string FuelKind;

            protected Vehicle(string brand)
            {                
                Brand = brand;
            }

            public Vehicle()
            {

            }


            public abstract string GO();
        }

        class Auto : Vehicle
        {
            public Auto():base("AUDI") {

                FuelKind = "benzyna";
            }

            public override string GO()
            {
                return "jade po drodze, napędza mnie " + FuelKind; 
            }
        }

        class Airplane : Vehicle
        {
            public Airplane():base() {
                FuelKind = "paliwo rakietowe";
            }

            public override string GO()
            {
                return "lece w powietrzu, napędza mnie " + FuelKind;
            }
        }

        class Submarine : Vehicle
        {
            private Submarine() {
                FuelKind = "energia atomowa";
            }

            public Submarine(string fuelKind)
            {
               this.Brand = fuelKind;
            }

            public override string GO()
            {
                return "Płyne pod wodą, napędza mnie " + FuelKind;
            }
        }
    }

}
