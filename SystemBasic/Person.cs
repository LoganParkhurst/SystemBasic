using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemBasic
{
    class Person : Entity
    {
        public List<Item> Shop { get; set; } = new List<Item>();
        
        public double Coin { get; set; }
        public double LowPrice { get; set; } = 0.15;
        public double NormPrice { get; set; } = 0.25;
        public double HighPrice { get; set; } = 0.30;

        public void SetUpShop()
        {
            Item deterrent = new Item("Deterrent", "makes the hawks attack less", -0.5); //reduces how many bats the hawks eat
            Item wormfeed = new Item("Worm Feed", "Add extra worms to the enviroment", 0); //adds extra worms for the bats
            Item corn = new Item("Corn", "Adds extra Corn to the cave", 0);    //adds extra corn to the system
            Item cotton = new Item("Cotton", "Adds extra Cotton to the cave", 0); //adds extra cotton to the system

            Shop.Add(deterrent);
            Shop.Add(wormfeed);
            Shop.Add(corn);
            Shop.Add(cotton);
        }

        public string ShowShop()
        {
            string result = "";

            foreach (Item item in Shop)
            {
                result += $"{item.Name} => {item.Description}\n";
            }

            return result;
        }

        public void BuyItem(string item)
        {
            switch (item.ToLower())
            {
                case "deterrent":
                    break;

                case "wormfeed":
                    break;

                case "corn":
                    break;

                case "cotton":
                    break;
            }
        }

        public double Sell()
        {
            double result = 0;
            Random rand = new Random();
            int value = rand.Next(0, 11);
            if (value <= 4)
            {
                result = Guano.Guano_Instance.Amount * LowPrice;
            }
            else if(value >= 5 && value <= 9)
            {
                result = Guano.Guano_Instance.Amount * NormPrice;
            }
            else if(value == 10)
            {
                result = Guano.Guano_Instance.Amount * HighPrice;
            }
            Guano.Guano_Instance.Amount = 0;
            return result;
        }
    }
}
