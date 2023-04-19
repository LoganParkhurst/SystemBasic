using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace SystemBasic
{
    public class Cave
    {
        #region Properties
        public string Name { get; set; }
        public List<Entity> Creatures = new List<Entity>();
        #endregion

        public Cave()
        {
            Name = "Bat Cave";
            Creatures = LoadEntities("../../../Data/entities.xml");
        }
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
    }
}
