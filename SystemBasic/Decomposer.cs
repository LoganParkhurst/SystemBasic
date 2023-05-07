using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBasic
{
    class Decomposer : Entity, IConsumption
    {
        public void ProduceGuano(double food)
        {
            Guano.Guano_Instance.Amount += Math.Round(this.Amount * this.AmountOfFoodRequired) * this.Deterrent;
        }
        public void Consume(List<Entity> entities)
        {
            
        }
    }
}
