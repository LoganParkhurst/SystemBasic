using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBasic
{
    public class Guano
    {
        private Guano() { }
        private static Guano instance = null;
        public static Guano Guano_Instance { get { return instance; } }

        public double Amount;
    }
}
