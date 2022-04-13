/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;

namespace Hospital.Contoller
{
    public class RoomController
    {
        private RoomService roomService;



        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }
         public Room  CreateRoom(String name, RoomType.RoomTypes type)
         {
            Room room= roomService.CreateRoom(name,type);
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
            return roomService.UpdateRoom(name,newName,newType);
        }

        public List<Room> ShowRooms()
        {
            return roomService.ShowRooms();
        }

        /* public Boolean DeleteRoom(String name)
         {
            // TODO: implement
            return null;
         }
        */
         public Room GetRoom(String name)
         {
            return roomService.GetRoom(name);

        }

    }
}