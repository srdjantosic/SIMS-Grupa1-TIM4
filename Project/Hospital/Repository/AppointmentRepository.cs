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

            public Appointment createAppointment(DateTime dateTime, String lks, String lbo)
            {

            Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
            Appointment appointment = new Appointment(showAppointments().Count, lks, dateTime, lbo);
            appointmentSerializer.oneToCSV(fileName, appointment);
            return appointment;
            }
            public Boolean updateAppointment(DateTime dateTime, int id)
            {
                List<Appointment> appointments = showAppointments();

                foreach (Appointment appointment in appointments)
                {
                    if(appointment.id == id)
                    {
                        appointment.dateTime = dateTime;
                        Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
                        appointmentSerializer.toCSV(fileName, appointments);
                        return true;
                    }
                }
            return false;
        }

            public List<Appointment> showAppointments()
            {
                Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
                List<Appointment> appointments = appointmentSerializer.fromCSV(fileName);
                return appointments;
            }


            public Boolean deleteAppointment(int id)
            { 

                List<Appointment> appointments = showAppointments();
                Appointment appointmentToDelete = getAppointment(id);
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

            public Appointment getAppointment(int id)
            {
                try
                {
                    {
                        return showAppointments().SingleOrDefault(appointment => appointment.id == id);
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