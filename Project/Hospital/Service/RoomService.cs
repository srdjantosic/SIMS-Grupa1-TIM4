using Hospital.Repository;
using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;

namespace Hospital.Service
{
    public class RoomService
    {
        private RoomRepository roomRepository;
        private const string NOT_FOUND_ERROR = "Equipment with {0}:{1} can not be found!";
        public RoomService(RoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public Room CreateRoom(String newName, RoomType.RoomTypes newType)
        {
            if (newName.Length == 0)
            {
                throw new System.Exception(" ", null);
            }
            else
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
        }

        public Boolean UpdateRoom(String name, String newName, RoomType.RoomTypes newType)
        {
            return roomRepository.UpdateRoom(name, newName, newType);

        }

        public List<Room> GetRooms()
        {
            return roomRepository.GetRooms();
        }

        public Boolean DeleteRoom(String name)
        {
            return roomRepository.DeleteRoom(name);
        }

        public Room GetRoom(String name)
        {
            return roomRepository.GetRoom(name);
        }

        public void RenovateRoom(String Name, DateTime start, DateTime end, int days)
        {
            
            List<Appointment> appointments = new List<Appointment>();
            Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
            appointments = appointmentSerializer.fromCSV("appointments.txt");
            double i = (end - start).TotalDays;

                foreach (Appointment appointment in appointments) 
            {
                if ((appointment.roomName == Name) && ((appointment.dateTime == start) || (appointment.dateTime == start))){ 
                 throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "Not possible"));
                }



                if (start.Date.Equals(DateTime.Now.Date))
                {
                    Serializer<Room> roomSerializer = new Serializer<Room>();
                    Room room = new Room(Name, RoomType.RoomTypes.MeetingRoom);
                    roomSerializer.oneToCSV("roomToRenovate.txt", room);
                    roomRepository.DeleteRoom(Name);
                }

           
                if (end.Date.Equals(DateTime.Now.Date))
                {
                   
                  }

            }
            
            

        }

        public List<Room> GetMeetingRooms()
        {
            List<Room> meetingRooms = new List<Room>();
            foreach(Room room in GetRooms())
            {
                if(room.Type == RoomType.RoomTypes.MeetingRoom)
                {
                    meetingRooms.Add(room);
                }
            }
            return meetingRooms;
        }
    }
}
