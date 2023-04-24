using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBasic
{
    public enum Type
    {
        Consumer,
        Decomposer,
        Producer,
        Person
    }
    public class Entity
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public Type Type { get; set; }
        public double Amount { get; set; }
        public string FoodToEat { get; set; }
        public double AmountOfFoodRequired { get; set; }
        public int deterrent { get; set; } = 1;

        public void PassTime(List<Entity> Creatures)
        {
            switch (this.Name)
            {
                case "Brazilian free-tailed bat":
                    Consumer.EatBats(Creatures, (Creatures.Find(x => x.Name == "Brazilian free-tailed bat")));
                    break;

                case "Corn earworm":
                    Consumer.ConsumerEat(Creatures, (Creatures.Find(x => x.Name == "Corn earworm")));
                    break;

                case "Cotton Bollworm":
                    Consumer.ConsumerEat(Creatures, (Creatures.Find(x => x.Name == "Cotton Bollworm")));
                    break;

                case "Red-tailed hawk":
                    Consumer.ConsumerEat(Creatures, (Creatures.Find(x => x.Name == "Red-tailed hawk")));
                    break;
            }
        }

        public bool CanEat(Entity food)
        {
            //Debug.WriteLine($"{food.Name} has {food.Amount}");
            if (food.Amount >= (this.AmountOfFoodRequired * this.Amount))
                return true;

            return false;
        }

        public bool CanReproduce(Entity food)
        {
            if (food.Amount >= ((this.AmountOfFoodRequired * this.Amount) * 2))
                return true;

            return false;
        }

        public void Reproduce()
        {
            Debug.WriteLine($"{this.Name} is currently at {this.Amount}");
            Debug.WriteLine($"{Math.Round(this.Amount / 2)} + {this.Amount} = {this.Amount + Math.Round(this.Amount % 2)}");
            this.Amount += Math.Round(this.Amount / 2);
            Debug.WriteLine($"{this.Name} is currently at {this.Amount}");
        }

        public void Die(Entity food)
        {
            this.Amount -= Math.Round(Math.Abs(food.Amount - (this.Amount * this.AmountOfFoodRequired)));
        }

    }
}
