/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/

using Hospital.Model;

namespace Hospital.Repository
{
    public class RoomRepository
    {
        public RoomRepository() { }

        /* public Boolean CreateRoom(String newName, RoomType newType)
         {
            // TODO: implement
            return null;
         }

         public Boolean UpdateRoom(String name, String newName, RoomType newType)
         {
            // TODO: implement
            return null;
         }*/

        public List<Room> ShowRooms()
        {
            List<Room> rooms = new List<Room>();
            Serializer<Room> roomSerializer = new Serializer<Room>();
            rooms = roomSerializer.fromCSV("rooms.txt");
            return rooms;
        }

        /* public Boolean DeleteRoom(String name)
         {
            // TODO: implement
            return null;
         }

         public Room GetRoom(String name)
         {
            // TODO: implement
            return null;
         }*/

    }
}