using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello_world
{
    public class Calculator
    {
        public Calculator()
        {
            x = 30;
            y = 40;
        }
        public int x { get; set; }

        public int y { get; set; }
         public int Add()
            { 
            return x + y; 
            }
        
        public int Sub()
        {
            return y - x;
        }
    }
}
