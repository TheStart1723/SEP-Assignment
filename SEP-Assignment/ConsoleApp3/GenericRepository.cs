using ConsoleApp3.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class GenericRepository : IRepository<Entity>
    {
        List<Entity> listEntity = new List<Entity>();
        public void Add(Entity item)
        {
            listEntity.Add(item);
        }

        public IEnumerable<Entity> GetAll()
        {
            return listEntity;
        }

        public Entity GetById(int id)
        {
            for (int i = 0; i < listEntity.Count; i++)
            {
                if (listEntity[i].Id == id)
                {
                    return listEntity[i];
                }
            }
            return null;
        }

        public void Remove(Entity item)
        {
            listEntity.Remove(item);
        }

        public void Save()
        {
            Console.WriteLine("Saved");
        }
    }
}
