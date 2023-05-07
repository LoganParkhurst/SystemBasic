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

        private int day;

        public void PassTime(List<Entity> Creatures)
        {
            if(day > 10)
                day = 1;


            if(this.Type == Type.Consumer)
            {
                if (this.Name == "Brazilian free-tailed bat")
                    Consumer.Eat(Creatures, this);

                Eat(Creatures);
            }

            if(this.Type != Type.Producer && this.Type != Type.Person && day == 7)
            {
                OldAge();
            }

            Debug.WriteLine(day);

            day++;
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
            Debug.WriteLine($"half of {this.Name}'s {this.Amount} population is is {Math.Round(this.Amount / 2)}");
            if (this.Species == "Helicoverpa zea")
            {
                this.Amount += Math.Round(this.Amount / 1.25);
            }
            else
            {
                this.Amount += Math.Round(this.Amount / 2);
            }
            
            
        }

        public void Die(Entity food)
        {
            //Debug.WriteLine($"{this.Amount - Math.Ceiling(Math.Abs(food.Amount - (this.Amount * this.AmountOfFoodRequired)))} = {this.Amount} - {(Math.Ceiling(Math.Abs(food.Amount - (this.Amount * this.AmountOfFoodRequired))))}");
            this.Amount -= Math.Ceiling(Math.Abs(food.Amount - (this.Amount * this.AmountOfFoodRequired)));

            if(this.Amount < 0)
            {
                this.Amount = 0;
            }
        }

        public void OldAge()
        {
            double elders = 0;
            //creatures die of old age
            elders = Math.Floor(this.Amount * 0.01);
            Debug.WriteLine($"{this.Name} has a population of {this.Amount} and 0.01 of that is {elders}");
            this.Amount -= elders;
        }

        public void Eat(List<Entity> entities)
        {
            var food = entities.Find(x => x.Species == this.FoodToEat);
            //Debug.WriteLine($"{this.Name} wants some {food.Name} it has {food.Amount}");
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
