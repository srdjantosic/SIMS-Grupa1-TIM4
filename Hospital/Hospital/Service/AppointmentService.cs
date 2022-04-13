using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class AppointmentService
    {

        private AppointmentRepository appointmentRepository;

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }
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

        public List<Appointment> ShowAppointments()
        {
            return appointmentRepository.ShowAppointments();
        }
        public Boolean DeleteAppointment(int id)
        {
            return appointmentRepository.DeleteAppointment(id);
        }

        public Appointment GetAppointment(int id)
        {
            return appointmentRepository.GetAppointment(id);
        }

    }
}