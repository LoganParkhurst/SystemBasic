using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBasic
{
    public class Guano
    {
        public double Amount { get; set; } = 0;

        public static Guano Guano_Instance = new Guano();
    }
}
