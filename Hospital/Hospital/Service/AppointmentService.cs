using Hospital.Hospital.Exception;
using Hospital.Model;
using Hospital.Repository;

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
<<<<<<< HEAD
        /* public Boolean CreateAppointment(System.DateTime dateTime, int lks, int lbo)
         {
            // TODO: implement
            return null;
         }

         public Boolean UpdateAppointment(System.DateTime adress, int id)
         {
            // TODO: implement
            return null;
         }*/

=======
        public Appointment CreateAppointment(DateTime dateTime, string lks, string lbo)
        {
            if(dateTime == null || lks == null || lbo == null)
            {
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "lbo", lbo));
            }
            else
            {
                return appointmentRepository.CreateAppointment(dateTime, lks, lbo);
            }
        }
      /*
      public Boolean UpdateAppointment(DateTime adress, int id)
      {
         // TODO: implement
         return null;
      }*/
      
>>>>>>> 83b63519c934bf444af32a84c6c7b94555ca382c
        public List<Appointment> ShowAppointments()
        {
            return appointmentRepository.ShowAppointments();
        }
        public Boolean DeleteAppointment(int id)
        {
            return appointmentRepository.DeleteAppointment(id);
        }
<<<<<<< HEAD

=======
      
>>>>>>> 83b63519c934bf444af32a84c6c7b94555ca382c
        public Appointment GetAppointment(int id)
        {
            return appointmentRepository.GetAppointment(id);
        }
<<<<<<< HEAD

    }
=======
   
   }
>>>>>>> 83b63519c934bf444af32a84c6c7b94555ca382c
}