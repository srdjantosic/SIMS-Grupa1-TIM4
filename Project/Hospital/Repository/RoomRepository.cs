using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Project.Hospital.Repository.IRepository;

namespace Hospital.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private const string NOT_FOUND_ERROR = "Room with {0}:{1} can not be found!";
        private const string fileName = "rooms.txt";
        public RoomRepository() { }

        public Room Create(String newName, RoomType.RoomTypes newType)
        {
            Serializer<Room> roomSerializer = new Serializer<Room>();
            Room room = new Room(newName, newType);
            roomSerializer.oneToCSV(fileName, room);
            return room;
        }
        public void Save(List<Room> rooms)
        {
            Serializer<Room> roomSerializer = new Serializer<Room>();
            roomSerializer.toCSV(fileName, rooms);
        }

        public List<Room> GetAll()
        {
            Serializer<Room> roomSerializer = new Serializer<Room>();
            return roomSerializer.fromCSV(fileName);
        }
        public Boolean Delete(String name)
        {
            List<Room> rooms = GetAll();
            Room room = GetOne(name);

            if(room != null && rooms.Remove(room))
            {
                Serializer<Room> roomSerializer = new Serializer<Room>();
                roomSerializer.toCSV(fileName, rooms);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Room GetOne(String name)
        {
            return GetAll().SingleOrDefault(room => room.Name == name);
        }
    }
}