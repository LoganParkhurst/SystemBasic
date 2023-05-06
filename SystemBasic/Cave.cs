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
        public List<Entity> Creatures { get; set; } = new List<Entity>();
        public int Day { get; set; } = 0;
        #endregion

        public Cave()
        {
            Name = "Bat Cave";
            Creatures = LoadEntities("../../../Data/entities.xml");
        }

        #region Static
        //Made in class.
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
                        temp.Type = Type.Producer;
                    }
                    else if (entity.GetAttribute("type") == "Consumer")
                    {
                        temp = new Consumer();
                        temp.Type = Type.Consumer;
                    }
                    else if (entity.GetAttribute("type") == "Decomposer")
                    {
                        temp = new Decomposer();
                        temp.Type = Type.Decomposer;
                    }
                    else if (entity.GetAttribute("type") == "Player" || entity.GetAttribute("type") == "Vendor")
                    {
                        temp = new Person();
                        temp.Type = Type.Person;
                    }
                    else
                    {
                        temp = new Entity();
                    }
                    temp.Name = entity.GetAttribute("name");
                    temp.Species = entity.GetAttribute("species");
                    temp.FoodToEat = entity.GetAttribute("foodSource");
                    if (int.TryParse(entity.GetAttribute("amount"), out int a)) { temp.Amount = a; }
                    if (double.TryParse(entity.GetAttribute("foodNeeded"), out double b)) { temp.AmountOfFoodRequired = b; }
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
                entity.PassTime(Creatures);
            }
            Day++;
        }
    }
}