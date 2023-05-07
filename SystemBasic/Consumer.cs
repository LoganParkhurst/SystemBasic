using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBasic
{
    class Consumer : Entity, IConsumption
    {
        public static void Eat(List<Entity> entities, Entity entity)
        {
            Random RNG = new Random();
            var food = entities.Find(x => x.Name == "Cotton Bollworm");
            var food2 = entities.Find(x => x.Name == "Corn earworm");

            if (entity.CanReproduce(food))
            {
                entity.Reproduce();
            }
            else if (entity.CanReproduce(food2))
            {
                entity.Reproduce();
            }

            if (RNG.Next(1, 3) == 2)
            {
                //Debug.WriteLine($"{entity.Name} wants some {food.Name} it has {food.Amount}");
                if (entity.CanEat(food))
                {
                    food.Amount -= (entity.Amount * entity.AmountOfFoodRequired);
                    food.Amount = Math.Round(food.Amount);
                }
                else
                {
                    if (entity.CanEat(food2))
                    {
                        //Debug.WriteLine($"{entity.Name} wants some {food2.Name} it has {food2.Amount}");
                        food2.Amount -= (entity.Amount * entity.AmountOfFoodRequired);
                        food2.Amount = Math.Round(food2.Amount);
                    }
                    else
                    {
                        entity.Die(food);
                    }
                }
                //Debug.WriteLine($"{entity.Name} wants some {food.Name} it has {food.Amount}");
            }
            else
            {
                //Debug.WriteLine($"{entity.Name} wants some {food2.Name} it has {food2.Amount}");
                if (entity.CanEat(food2))
                {
                    food2.Amount -= (entity.Amount * entity.AmountOfFoodRequired);
                    food2.Amount = Math.Round(food2.Amount);
                }
                else
                {
                    if (entity.CanEat(food))
                    {
                        //Debug.WriteLine($"{entity.Name} wants some {food.Name} it has {food.Amount}");
                        food.Amount -= (entity.Amount * entity.AmountOfFoodRequired);
                        food.Amount = Math.Round(food.Amount);
                    }
                    else
                    {
                        entity.Die(food2);
                    }
                }
                //Debug.WriteLine($"{entity.Name} wants some {food2.Name} it has {food2.Amount}");
            }
        }

        public void ProduceGuano(double food)
        {
            Guano.Guano_Instance.Amount += Math.Round(this.Amount * this.AmountOfFoodRequired) * this.Deterrent;
        }

        public void Consume(List<Entity> entities)
        {

        }
    }
}
