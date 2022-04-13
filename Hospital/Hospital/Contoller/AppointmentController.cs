using Hospital.Model;
using Hospital.Service;

namespace Hospital.Contoller
{
    public class AppointmentController
    {
        private AppointmentService appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }
<<<<<<< HEAD
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

=======
        public Appointment CreateAppointment(DateTime dateTime, string lks, string lbo)
        {
            Appointment appointment = appointmentService.CreateAppointment(dateTime, lks, lbo);
            if(appointment != null)
            {
                return appointment;
            }
            else { return null; }
        }
      /*
      public Boolean UpdateAppointment(DateTime adress, int id)
      {
         // TODO: implement
         return false;
      }*/
      
>>>>>>> 83b63519c934bf444af32a84c6c7b94555ca382c
        public List<Appointment> ShowAppointments()
        {
            return appointmentService.ShowAppointments();
        }
        public Boolean DeleteAppointment(int id)
        {
            return appointmentService.DeleteAppointment(id);
        }
<<<<<<< HEAD

=======
      
>>>>>>> 83b63519c934bf444af32a84c6c7b94555ca382c
        public Appointment GetAppintment(int id)
        {
            return appointmentService.GetAppointment(id);
        }
<<<<<<< HEAD

    }
=======
   
   }
>>>>>>> 83b63519c934bf444af32a84c6c7b94555ca382c
}