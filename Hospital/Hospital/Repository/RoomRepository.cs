

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
        */
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
                }
                
            }
            return true;

        }

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
        */
         public Room GetRoom(String name)
        {
            List<Room> rooms = ShowRooms();
            foreach (Room room in rooms) {
                if (room.Name.Equals(name))  
                    return room;     
            }
            return null;   
        }
        
    }

}