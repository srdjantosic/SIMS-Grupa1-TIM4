using Project.Hospital.Model;
using Project.Hospital.Exception;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Repository
{
    public class RoomRepository
    {
        private const string NOT_FOUND_ERROR = "Room with {0}:{1} can not be found!";
        public RoomRepository() { }

        public Room CreateRoom(String newName, RoomType.RoomTypes newType)
        {
            Serializer<Room> roomSerializer = new Serializer<Room>();
            Room room = new Room(newName, newType);
            roomSerializer.oneToCSV("rooms.txt", room);
            return room;
        }

        public Boolean UpdateRoom(String name, String newName, RoomType.RoomTypes newType)
        {
            List<Room> rooms = new List<Room>();
            rooms = ShowRooms();
            foreach (Room room in rooms)
            {
                if (room.Name.Equals(name))
                {
                    room.Name = newName;
                    room.Type = newType;
                    Serializer<Room> roomSerializer = new Serializer<Room>();
                    roomSerializer.toCSV("rooms.txt", rooms);
                    return true;
                }
                    
            }
            return false;

        }


        public List<Room> ShowRooms()
        {
            List<Room> rooms = new List<Room>();
            Serializer<Room> roomSerializer = new Serializer<Room>();
            rooms = roomSerializer.fromCSV("rooms.txt");
            return rooms;
        }

         public Boolean DeleteRoom(String name)
         {
            List<Room> rooms = new List<Room>();
            rooms = ShowRooms();

            foreach (Room room in rooms)
            {
                if (room.Name == name)
                {
                    if (rooms.Remove(room))
                    {
                        Serializer<Room> roomSerializer = new Serializer<Room>();
                        roomSerializer.toCSV("rooms.txt", rooms);
                        return true;
                    }
                    else
                    {
                       
                        return false;
                     
                    }
                }
            }
            
            return false;
            

        }
        
        public Room GetRoom(String name)
        {
            try
            {
                {
                    return ShowRooms().SingleOrDefault(room => room.Name == name);
                }
            }
            catch (ArgumentException)
            {
                {
                    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "name", name));
                }
            }

        }
    }
}