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
        public Appointment CreateAppointment(DateTime dateTime, string lks, string lbo)
        {
            if (lks.Equals("") || lbo.Equals(""))
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "lbo", lbo));

            List<Appointment> appointments = new List<Appointment>();
            appointments = ShowAppointments();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.Lks.Equals(lks) && appointment.Lbo.Equals(lbo) && appointment._DateTime == dateTime && appointment.IsDeleted == false)
                    return null;

            }
            return appointmentRepository.CreateAppointment(dateTime, lks, lbo);
        }
    
        public Boolean UpdateAppointment(DateTime dateTime, int id)
        {
            if (appointmentRepository.GetAppointment(id).IsDeleted == true)
                return false;
            else
                return appointmentRepository.UpdateAppointment(dateTime, id);
        }
      
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

