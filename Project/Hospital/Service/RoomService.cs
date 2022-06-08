using Hospital.Repository;
using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using Project.Hospital.Repository.IRepository;

namespace Hospital.Service
{
    public class RoomService
    {
        private IRoomRepository iRoomRepo;
        private const string NOT_FOUND_ERROR = "Equipment with {0}:{1} can not be found!";
        public RoomService(IRoomRepository iRoomRepo)
        {
            this.iRoomRepo = iRoomRepo;
        }
        public Room Create(String newName, RoomType.RoomTypes newType)
        {
            return iRoomRepo.Create(newName, newType);
        }

        public Boolean Update(String name, String newName, RoomType.RoomTypes newType)
        {
            List<Room> rooms = GetAll();
            foreach(Room room in rooms)
            {
                if(room.Name == name)
                {
                    room.Name = newName;
                    room.Type = newType;
                    iRoomRepo.Save(rooms);
                    return true;
                }
            }
            return false;
        }

        public List<Room> GetAll()
        {
            return iRoomRepo.GetAll();
        }

        public Boolean Delete(String name)
        {
            return iRoomRepo.Delete(name);
        }

        public Room GetOne(String name)
        {
            return iRoomRepo.GetOne(name);
        }
        public List<Room> GetMeetingRooms()
        {
            List<Room> meetingRooms = new List<Room>();
            foreach (Room room in GetAll())
            {
                if (room.Type == RoomType.RoomTypes.MeetingRoom)
                {
                    meetingRooms.Add(room);
                }
            }
            return meetingRooms;
        }
        /*
        public void RenovateRoom(String Name, DateTime start, DateTime end, int days)
        {

            List<Appointment> appointments = appointmentService.ShowAppointments();
            double i = (end - start).TotalDays;

            foreach (Appointment appointment in appointments)
            {
                if ((appointment.RoomName == Name) && ((appointment.dateTime == start) || (appointment.dateTime == start)))
                {
                    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "Not possible"));
                }
                else
                {
                    if (start.Date.Equals(DateTime.Now.Date))
                    {
                        iRoomRepo.Delete(Name);
                    }
                }

            }
        }
        */
    }
}
