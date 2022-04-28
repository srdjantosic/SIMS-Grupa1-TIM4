using Hospital.Repository;
using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;

namespace Hospital.Service
{
    public class AppointmentService
    {

        private AppointmentRepository appointmentRepository;
        private const string NOT_FOUND_ERROR = "Appointment with {0}:{1} can not be found!";

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
        public Appointment createAppointment(DateTime dateTime, string lks, string lbo, string roomName)
        {
            if (lks.Equals("") || lbo.Equals(""))
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "lbo", lbo));

            List<Appointment> appointments = showAppointments();

            foreach (Appointment appointment in appointments)
            {
                if (isAppointmentAlreadyExist(appointment, lks, lbo, dateTime, roomName))
                    return null;
            }
            return appointmentRepository.createAppointment(dateTime, lks, lbo, roomName);
        }

        public Boolean updateAppointment(DateTime dateTime, int id)
        {
            if (appointmentRepository.getAppointment(id).isDeleted == true)
                return false;
            else
                return appointmentRepository.updateAppointment(dateTime, id);
        }

        public List<Appointment> showAppointments()
        {
            return appointmentRepository.showAppointments();
        }
        public Boolean deleteAppointment(int id)
        {
            return appointmentRepository.deleteAppointment(id);
        }

        public Appointment getAppointment(int id)
        {
            return appointmentRepository.getAppointment(id);
        }

        private Boolean isAppointmentAlreadyExist(Appointment appointment, string lks, string lbo, DateTime dateTime, string roomName)
        {
            if (appointment.lks.Equals(lks) && appointment.lbo.Equals(lbo) && appointment.dateTime == dateTime && appointment.roomName.Equals(roomName) 
                && appointment.isDeleted == false)
                return true;
            return false;
        }



    }


}

