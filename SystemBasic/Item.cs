using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBasic
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double deterrent { get; set; }

        public Item(string name, string description, double deterrent)
        {
            Name = name;
            Description = description;
            this.deterrent = deterrent;
        }
    }
}
