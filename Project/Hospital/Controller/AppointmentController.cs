using Hospital.Service;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;

namespace Project.Hospital.Controller
{
    public class AppointmentController
    {
        private AppointmentService appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public Appointment createAppointment(DateTime dateTime, string lks, string lbo, string roomName)
        {
            Appointment appointment = appointmentService.createAppointment(dateTime, lks, lbo, roomName);
            if (appointment != null)
                return appointment;
            return null;
        }


        public Boolean updateAppointment(DateTime dateTime, int id)
        {
            return appointmentService.updateAppointment(dateTime, id);
        }

        public List<Appointment> showAppointments()
        {
            return appointmentService.showAppointments();
        }
        public Boolean deleteAppointment(int id)
        {
            return appointmentService.deleteAppointment(id);
        }

        public Appointment getAppintment(int id)
        {
            return appointmentService.getAppointment(id);
        }

    }
}

