using Project.Hospital.Exception;
using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private const string NOT_FOUND_ERROR = "Appointment with {0}:{1} can not be found!";
        private const string fileName = "appointment.txt";

        public Appointment Create(Appointment newAppointment)
        {
            Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
            Appointment appointment = new Appointment(GetAll().Count, newAppointment.Lks, newAppointment.dateTime, newAppointment.Lbo, newAppointment.RoomName);
            appointmentSerializer.oneToCSV(fileName, appointment);
            return appointment;
        }

        public Boolean Save(List<Appointment> appointments)
        {
            Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
            appointmentSerializer.toCSV(fileName, appointments);
            return true;
        }
        public List<Appointment> GetAll()
        {
            Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
            List<Appointment> appointments = appointmentSerializer.fromCSV(fileName);
            return appointments;
        }
        public Appointment GetOne(int id)
        {
            try
            {
                {
                    return GetAll().SingleOrDefault(appointment => appointment.Id == id);
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