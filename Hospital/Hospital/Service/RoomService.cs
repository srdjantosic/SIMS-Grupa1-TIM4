/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class RoomService
    {
        private RoomRepository roomRepository;

        public RoomService(RoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

    

        public Room  CreateRoom(String newName, RoomType.RoomTypes newType)
        {
            if (GetRoom(newName) == null)
            {
                return roomRepository.CreateRoom(newName, newType);
            }
            else
            {
                return null;
            }

        }

        public Boolean UpdateRoom(String name, String newName, RoomType.RoomTypes newType)
        {
            return roomRepository.UpdateRoom(name, newName, newType);
            
        }
        
        public List<Room> ShowRooms()
        {
            return roomRepository.ShowRooms();
        }
        /*
        public Boolean DeleteRoom(String name)
        {
           // TODO: implement
           return null;
        }
        */
        public Room GetRoom(String name)
        {
             return roomRepository.GetRoom(name);
        }
        
    }
        
}