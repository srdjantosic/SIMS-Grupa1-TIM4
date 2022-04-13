using Hospital.Hospital.Exception;
using Hospital.Model;

namespace Hospital.Repository
{
    public class AppointmentRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        /* public Boolean CreateAppointment(System.DateTime dateTime, String lks, String lbo)
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
            List<Appointment> appointments = new List<Appointment>();
            Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
            appointments = appointmentSerializer.fromCSV("appointment.txt");
            return appointments;
        }
        public Boolean DeleteAppointment(int id)
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments = ShowAppointments();
            Appointment appointmentToDelete = GetAppointment(id);
            if (appointmentToDelete != null && appointmentToDelete.IsDeleted == false)
            {
                appointments.RemoveAt(id);
                appointmentToDelete.IsDeleted = true;
                appointments.Insert(id, appointmentToDelete);
                Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
                appointmentSerializer.toCSV("appointment.txt", appointments);
            }
            else
            {
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));
            }
            return true;
        }

        public Appointment GetAppointment(int id)
        {
            try
            {
                {
                    return ShowAppointments().SingleOrDefault(appointment => appointment.Id == id);
                }
            }
            catch (ArgumentException)
            {
                {
                    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));
                }
            }
        }

    }
}