﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBasic
{
    //SciTE
    enum Type 
    {
        Producer,
        Consumer,
        Decomposer
    }
    public class Creature
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int Amount { get; set; }

        public void Sleep()
        {

        }
        public void Eat()
        {
            
        }
    }
}
