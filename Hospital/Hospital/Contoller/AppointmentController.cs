using Hospital.Model;
using Hospital.Service;
using System;

namespace Hospital.Contoller
{
   public class AppointmentController
   {
        private AppointmentService appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }
      /*public Boolean CreateAppointment(System.DateTime dateTime, int lks, int lbo)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean UpdateAppointment(System.DateTime adress, int id)
      {
         // TODO: implement
         return false;
      }*/
      
      public List<Appointment> ShowAppointments()
      {
         return appointmentService.ShowAppointments();
      }

      /*
      public Boolean DeleteAppointment(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Appointment GetAppintment(int id)
      {
         // TODO: implement
         return null;
      }*/
   
   }
}