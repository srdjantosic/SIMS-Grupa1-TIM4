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
       
=======
>>>>>>> dd9f4fac733eb55b01dde56b96ce1c428b909399
        public Appointment CreateAppointment(DateTime dateTime, string lks, string lbo)
        {
            Appointment appointment = appointmentService.CreateAppointment(dateTime, lks, lbo);
            if(appointment != null)
                return appointment;
            else  
                return null;
        }
<<<<<<< HEAD
      /*
      public Boolean UpdateAppointment(DateTime adress, int id)
      {
         // TODO: implement
         return false;
      }*/
      
=======

        public Boolean UpdateAppointment(DateTime dateTime, int id)
        {
           return appointmentService.UpdateAppointment(dateTime, id);
        }

>>>>>>> dd9f4fac733eb55b01dde56b96ce1c428b909399
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
      
>>>>>>> dd9f4fac733eb55b01dde56b96ce1c428b909399
        public Appointment GetAppintment(int id)
        {
            return appointmentService.GetAppointment(id);
        }
<<<<<<< HEAD


    }
   
}

=======
   
   }
}
>>>>>>> dd9f4fac733eb55b01dde56b96ce1c428b909399
