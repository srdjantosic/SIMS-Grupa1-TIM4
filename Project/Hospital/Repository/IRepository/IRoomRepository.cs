using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository.IRepository
{
    public interface IRoomRepository
    {
        public Room Create(String newName, RoomType.RoomTypes newType);
        public void Save(List<Room> rooms);
        public Boolean Delete(String name);
        public List<Room> GetAll();
        public Room GetOne(String name);
    }
}
