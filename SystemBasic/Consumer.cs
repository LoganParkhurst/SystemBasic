using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBasic
{
    class Consumer : Entity
    {
        public static void EatBats(List<Entity> entities, Entity entity)
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
                        food2.Amount -= (entity.Amount * entity.AmountOfFoodRequired);
                        food2.Amount = Math.Round(food2.Amount);
                    }
                    else
                    {
                        //Debug.WriteLine((Math.Abs(food.Amount - (entity.Amount * entity.AmountOfFoodRequired))));
                        if (entity.Amount - (Math.Abs(food.Amount - (entity.Amount * entity.AmountOfFoodRequired))) < 0)
                        {
                            entity.Amount = 0;
                        }
                        else
                        {
                            entity.Die(food);
                        }
                    }
                }
                //Debug.WriteLine($"{entity.Name} wants some {food.Name} it has {food.Amount}");
            }
            else
            {
                //Debug.WriteLine($"{entity.Name} wants some {food.Name} it has {food.Amount}");
                if (entity.CanEat(food2))
                {
                    food2.Amount -= (entity.Amount * entity.AmountOfFoodRequired);
                    food2.Amount = Math.Round(food2.Amount);
                }
                else
                {
                    if (entity.CanEat(food))
                    {
                        food.Amount -= (entity.Amount * entity.AmountOfFoodRequired);
                        food.Amount = Math.Round(food.Amount);
                    }
                    else
                    {
                        //Debug.WriteLine((Math.Abs(food2.Amount - (entity.Amount * entity.AmountOfFoodRequired))));
                        if (entity.Amount - (Math.Abs(food2.Amount - (entity.Amount * entity.AmountOfFoodRequired))) < 0)
                        {
                            entity.Amount = 0;
                        }
                        else
                        {
                            entity.Die(food2);
                        }
                    }
                }
                //Debug.WriteLine($"{entity.Name} wants some {food2.Name} it has {food2.Amount}");
            }
        }

        public static void ConsumerEat(List<Entity> entities, Entity entity)
        {
            var food = entities.Find(x => x.Species == entity.FoodToEat);
            Debug.WriteLine($"{entity.Name} wants some {food.Name} it has {food.Amount}");
            if (entity.CanReproduce(food))
            {
                entity.Reproduce();
            }

            if (entity.CanEat(food))
            {
                food.Amount -= Math.Round(entity.Amount * entity.AmountOfFoodRequired) * entity.deterrent;
            }
            else
            {
                //Debug.WriteLine((Math.Abs(food.Amount - (entity.Amount * entity.AmountOfFoodRequired))));
                entity.Die(food);    
            }
            //Debug.WriteLine($"{entity.Name} wants some {food.Name} it has {food.Amount}");
        }

    }
}
