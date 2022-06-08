
using Project.Hospital.Model;
using Hospital.Service;
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
        public Room Create(String name, RoomType.RoomTypes type)
        {
            return roomService.Create(name, type);
        }

        public Boolean Update(String name, String newName, RoomType.RoomTypes newType)
        {
            return roomService.Update(name, newName, newType);
        }

        public List<Room> GetAll()
        {
            return roomService.GetAll();
        }

        public Boolean Delete(String name)
        {
            return roomService.Delete(name);
        }

        public Room GetOne(String name)
        {
            return roomService.GetOne(name);

        }
        public List<Room> GetMeetingRooms()
        {
            return roomService.GetMeetingRooms();
        }
        /*
        public void RenovateRoom(String Name, DateTime start, DateTime end, int days) {
            roomService.RenovateRoom(Name, start, end, days);
        }
        */
    }
}