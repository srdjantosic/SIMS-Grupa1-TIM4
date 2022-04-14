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
        public Appointment CreateAppointment(DateTime dateTime, string lks, string lbo)
        {
            Appointment appointment = appointmentService.CreateAppointment(dateTime, lks, lbo);
            if(appointment != null)
                return appointment;
            else  
                return null;
        }

        public Boolean UpdateAppointment(DateTime dateTime, int id)
        {
           return appointmentService.UpdateAppointment(dateTime, id);
        }

        public List<Appointment> ShowAppointments()
        {
            return appointmentService.ShowAppointments();
        }
        public Boolean DeleteAppointment(int id)
        {
            return appointmentService.DeleteAppointment(id);
        }
      
        public Appointment GetAppintment(int id)
        {
            return appointmentService.GetAppointment(id);
        }
   
   }
}