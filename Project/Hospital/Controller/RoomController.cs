
using Project.Hospital.Model;
using Project.Hospital.Model;
using Hospital.Service;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;

namespace Project.Hospital.Controller
{
    public class RoomController
    {
        private RoomService roomService;



        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }
        public Room CreateRoom(String name, RoomType.RoomTypes type)
        {
            Room room = roomService.CreateRoom(name, type);
            if (room != null)
            {
                return room;
            }
            else
            {
                return null;
            }
        }

        public Boolean UpdateRoom(String name, String newName, RoomType.RoomTypes newType)
        {
            return roomService.UpdateRoom(name, newName, newType);
        }

        public List<Room> ShowRooms()
        {
            return roomService.ShowRooms();
        }

        public Boolean DeleteRoom(String name)
        {
            return roomService.DeleteRoom(name);
        }

        public Room GetRoom(String name)
        {
            return roomService.GetRoom(name);

        }
        public void RenovateRoom(String Name, DateTime start, DateTime end, int days) {
            roomService.RenovateRoom(Name, start, end, days);
        }

    }
}