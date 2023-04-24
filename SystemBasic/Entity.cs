using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBasic
{
    public class Entity
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public double Amount { get; set; }
        public string FoodToEat { get; set; }
        public double AmountOfFoodRequired { get; set; }

        public void PassTime(Entity food)
        {
            if (CanReproduce(food))
            {
                Reproduce(food);
            }

            if (CanEat(food))
            {
                Eat(food);
            }
            else
            {
                Die();
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

        public void Reproduce(Entity food)
        {
            if(food.Amount > ((this.AmountOfFoodRequired * this.Amount) * 2))
            {
                this.Amount = this.Amount % 2 + this.Amount;
            }
        }

        public void Eat(Entity food)
        {
            if(AmountOfFoodRequired <= food.Amount)
            {
                food.Amount -= (this.AmountOfFoodRequired * this.Amount);
               //Debug.WriteLine(food.Amount);
            }
        }

        public void Die()
        {
            this.Amount--;
        }

    }
}
