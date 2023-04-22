using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace SystemBasic
{
    public class Cave
    {
        #region Properties
        public string Name { get; set; }
        public List<Entity> Creatures = new List<Entity>();
        public int Day = 0;
        #endregion

        public Cave()
        {
            Name = "Bat Cave";
            Creatures = LoadEntities("../../../Data/entities.xml");
        }

        #region Static
        public static List<Entity> LoadEntities(string fileName)
        {
            List<Entity> entities = new List<Entity>();
            if (File.Exists(fileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlNode root = doc.DocumentElement;
                XmlNodeList entityList = root.SelectNodes("/environment/entity");
                foreach (XmlElement entity in entityList)
                {
                    Entity temp;
                    if (entity.GetAttribute("type") == "Producer")
                    {
                        temp = new Producer();
                    }
                    else if (entity.GetAttribute("type") == "Consumer")
                    {
                        temp = new Consumer();
                    }
                    else if (entity.GetAttribute("type") == "Decomposer")
                    {
                        temp = new Decomposer();
                    }
                    else if (entity.GetAttribute("type") == "Player" || entity.GetAttribute("type") == "Vendor")
                    {
                        temp = new Person();
                    }
                    else
                    {
                        temp = new Entity();
                    }
                    temp.Name = entity.GetAttribute("name");
                    temp.Species = entity.GetAttribute("species");
                    if (int.TryParse(entity.GetAttribute("amount"), out int a)) { temp.Amount = a; }
                    entities.Add(temp);
                }
            }
            return entities;

        }

        public static string GetPopulation(List<Entity> creatures)
        {
            string result = "";

            foreach(Entity entity in creatures)
            {
                if(entity.Species != "Human" && entity.Species != "Zea mays saccharata" && entity.Species != "Gossypium hirsutum")
                {
                    result += $"{entity.Amount} {entity.Name}'s\n";
                }
            }

            return result;
        }

        public static string GetFoodLevels(List<Entity> entities)
        {
            string restult = "";

            foreach(Entity entity in entities)
            {
                if(entity.Species == "Zea mays saccharata" || entity.Species == "Gossypium hirsutum")
                {
                    restult += $"{entity.Amount} of {entity.Name}\n";
                }
            }

            return restult;
        }
        #endregion

        public void ProgressDay()
        {
            foreach(Entity entity in Creatures)
            {
                Debug.WriteLine($"{entity.Name} {entity.Amount} {entity.FoodToEat} {Creatures.Find(x => x.FoodToEat == entity.FoodToEat).Name}");
                if(entity.Species != "Human" && entity.Species != "Zea mays saccharata" && entity.Species != "Gossypium hirsutum")
                {
                    entity.PassTime(Creatures.Find(x => x.FoodToEat == entity.FoodToEat));
                    if(entity.CanEat(Creatures.Find(x => x.FoodToEat == entity.FoodToEat)))
                    {
                        Creatures.Find(x => x.FoodToEat == entity.FoodToEat).Amount -= (entity.AmountOfFoodRequired * entity.Amount);
                        Debug.WriteLine(Creatures.Find(x => x.FoodToEat == entity.FoodToEat).Amount);
                    }
                }
            }
            Day++;
        }
    }
}