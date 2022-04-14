using Hospital.Hospital.Exception;
using Hospital.Model;

namespace Hospital.Repository
{
<<<<<<< HEAD
        public class AppointmentRepository
        {
=======
   public class AppointmentRepository
   {
>>>>>>> dd9f4fac733eb55b01dde56b96ce1c428b909399
        private const string NOT_FOUND_ERROR = "Appointment with {0}:{1} can not be found!";

        public Appointment CreateAppointment(DateTime dateTime, String lks, String lbo)
        {
<<<<<<< HEAD
            
=======
>>>>>>> dd9f4fac733eb55b01dde56b96ce1c428b909399
            Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
            Appointment appointment = new Appointment(ShowAppointments().Count, lks, dateTime, lbo);
            appointmentSerializer.oneToCSV("appointment.txt", appointment);
            return appointment;
        }
        public Boolean UpdateAppointment(DateTime dateTime, int id)
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments = ShowAppointments();

            foreach (Appointment appointment in appointments)
            {
                if(appointment.Id == id)
                {
                    appointment._DateTime = dateTime;
                    Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
                    appointmentSerializer.toCSV("appointment.txt", appointments);
                    return true;
                }
            }
            return false;
        }

        public List<Appointment> ShowAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
            appointments = appointmentSerializer.fromCSV("appointment.txt");
            return appointments;
        }
<<<<<<< HEAD

        public Boolean DeleteAppointment(int id)
        { 
=======
        public Boolean DeleteAppointment(int id)
        {  
>>>>>>> dd9f4fac733eb55b01dde56b96ce1c428b909399
             List<Appointment> appointments = new List<Appointment>();
             appointments = ShowAppointments();
             Appointment appointmentToDelete = GetAppointment(id);
             if (appointmentToDelete != null && appointmentToDelete.IsDeleted == false)
             {
<<<<<<< HEAD
=======

>>>>>>> dd9f4fac733eb55b01dde56b96ce1c428b909399
                appointments.RemoveAt(id);
                appointmentToDelete.IsDeleted = true;
                appointments.Insert(id, appointmentToDelete);
                Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
                appointmentSerializer.toCSV("appointment.txt", appointments);
                return true;
             }

             return false;
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