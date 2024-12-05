using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public abstract class Demo
    {
        public Demo(string name)
        {
            Name = name;
        }

        public Demo()
        {
       
        }
        
        internal string Name { get; set; }
        public abstract void Run();
    }
}
