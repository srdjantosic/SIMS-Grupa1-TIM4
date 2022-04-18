using Project.Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Hospital.Controller
{
    public class AppointmentController
    {
        private AppointmentService appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public Appointment createAppointment(DateTime dateTime, string lks, string lbo)
        {
            Appointment appointment = appointmentService.createAppointment(dateTime, lks, lbo);
            if(appointment != null)
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

