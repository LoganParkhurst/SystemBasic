using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public int Deterrent { get; set; } = 1;

        public void PassTime(List<Entity> Creatures)
        {
            if(this.Type == Type.Consumer)
            {
                if (this.Name == "Brazilian free-tailed bat")
                    Consumer.Eat(Creatures, this);

                Eat(Creatures);
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
            if (food.Amount >= ((this.AmountOfFoodRequired * this.Amount) * 2) && this.Amount >= 2)
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
            Debug.WriteLine($"{this.Amount - Math.Ceiling(Math.Abs(food.Amount - (this.Amount * this.AmountOfFoodRequired)))} = {this.Amount} - {(Math.Ceiling(Math.Abs(food.Amount - (this.Amount * this.AmountOfFoodRequired))))}");
            this.Amount -= Math.Ceiling(Math.Abs(food.Amount - (this.Amount * this.AmountOfFoodRequired)));

            if(this.Amount < 0)
            {
                this.Amount = 0;
            }
        }

        public void Eat(List<Entity> entities)
        {
            var food = entities.Find(x => x.Species == this.FoodToEat);
            Debug.WriteLine($"{this.Name} wants some {food.Name} it has {food.Amount}");
            if (this.CanReproduce(food))
            {
                this.Reproduce();
            }

            if (this.CanEat(food))
            {
                food.Amount -= Math.Round(this.Amount * this.AmountOfFoodRequired) * this.Deterrent;
                Guano.Guano_Instance.Amount += Math.Round(this.Amount * this.AmountOfFoodRequired) * this.Deterrent;
            }
            else
            {
                this.Die(food);
            }
        }

    }
}
