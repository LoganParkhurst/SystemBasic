using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBasic
{
    public interface IConsumption
    {
        void Consume(List<Entity> entities);
        void ProduceGuano(double food);
    }

}
