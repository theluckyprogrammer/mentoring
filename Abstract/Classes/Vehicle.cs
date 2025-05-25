using System;
using System.Collections.Generic;
using System.Text;

namespace Abstract.Classes
{
    public abstract class Vehicle
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

    public class Auto : Vehicle
    {
        public Auto() : base("AUDI")
        {

            FuelKind = "gasoline";
        }

        public override string GO()
        {
            return "I'm driving on " + FuelKind;
        }
    }

    public class Airplane : Vehicle
    {
        public Airplane() : base()
        {
            FuelKind = "Rocketfuel";
        }

        public override string GO()
        {
            return "I'm flying on " + FuelKind;
        }
    }

    public class Submarine : Vehicle
    {
        private Submarine()
        {
            FuelKind = "Atom";
        }

        public Submarine(string fuelKind)
        {
            Brand = fuelKind;
        }

        public override string GO()
        {
            return "I'm powered by " + FuelKind;
        }
    }
}
