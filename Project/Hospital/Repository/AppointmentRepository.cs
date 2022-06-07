using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Repository
{
    public class AppointmentRepository
    {

        private const string NOT_FOUND_ERROR = "Appointment with {0}:{1} can not be found!";
        private const string fileName = "appointment.txt";

        public Appointment CreateAppointment(DateTime dateTime, String lks, String lbo, String roomName)
        {

            Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
            Appointment appointment = new Appointment(ShowAppointments().Count, lks, dateTime, lbo, roomName);
            appointmentSerializer.oneToCSV(fileName, appointment);
            return appointment;
        }
        public Boolean UpdateAppointment(DateTime dateTime, int id)
        {
            List<Appointment> appointments = ShowAppointments();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.id == id)
                {
                    appointment.dateTime = dateTime;
                    Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
                    appointmentSerializer.toCSV(fileName, appointments);
                    return true;
                }
            }
            return false;
        }

        //TODO
        public Appointment UpdateDateTimeAndRoomName(int id, DateTime dateTime, string roomName)
        {
            List<Appointment> appointments = ShowAppointments();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.id == id)
                {
                    appointment.dateTime = dateTime;
                    appointment.roomName = roomName;
                    Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
                    appointmentSerializer.toCSV(fileName, appointments);
                    return appointment;
                }
            }
            return null;
        }

        public List<Appointment> ShowAppointments()
        {
            Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
            List<Appointment> appointments = appointmentSerializer.fromCSV(fileName);
            return appointments;
        }

        public Boolean DeleteAppointment(int id)
        {

            List<Appointment> appointments = ShowAppointments();
            Appointment appointmentToDelete = GetAppointment(id);
            if (appointmentToDelete != null && appointmentToDelete.isDeleted == false)
            {

                appointments.RemoveAt(id);
                appointmentToDelete.isDeleted = true;
                appointments.Insert(id, appointmentToDelete);
                Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
                appointmentSerializer.toCSV(fileName, appointments);
                return true;
            }

            return false;
        }

        public Appointment GetAppointment(int id)
        {
            try
            {
                {
                    return ShowAppointments().SingleOrDefault(appointment => appointment.id == id);
                }
            }
            catch (ArgumentException)
            {
                {
                    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));
                }
            }
        }
    }
}