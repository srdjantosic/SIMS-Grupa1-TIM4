using Hospital.Hospital.Exception;
using Hospital.Model;

namespace Hospital.Repository
{
<<<<<<< HEAD
    public class AppointmentRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        /* public Boolean CreateAppointment(System.DateTime dateTime, String lks, String lbo)
         {
            // TODO: implement
            return null;
         }
=======
   public class AppointmentRepository
   {
        private const string NOT_FOUND_ERROR = "Appointment with {0}:{1} can not be found!";
>>>>>>> 83b63519c934bf444af32a84c6c7b94555ca382c

        public Appointment CreateAppointment(DateTime dateTime, String lks, String lbo)
        {
            /*Serializer<Patient> patientSerializer = new Serializer<Patient>();
            Patient patient = new Patient(firstName, lastName, gender, email, phoneNumber, jmbg, lbo, birthday, country, city, adress);
            patientSerializer.oneToCSV("patients.txt", patient);
            return GetPatient(patient.Lbo);*/
            Serializer<Appointment> appointmentSerializer = new Serializer<Appointment>();
            Appointment appointment = new Appointment(ShowAppointments().Count, lks, dateTime, lbo);
            appointmentSerializer.oneToCSV("appointment.txt", appointment);
            return appointment;
        }
        /*
        public Boolean UpdateAppointment(DateTime adress, int id)
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
<<<<<<< HEAD
        public Boolean DeleteAppointment(int id)
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments = ShowAppointments();
            Appointment appointmentToDelete = GetAppointment(id);
            if (appointmentToDelete != null && appointmentToDelete.IsDeleted == false)
            {
=======
         public Boolean DeleteAppointment(int id)
         { 
             List<Appointment> appointments = new List<Appointment>();
             appointments = ShowAppointments();
             Appointment appointmentToDelete = GetAppointment(id);
             if (appointmentToDelete != null && appointmentToDelete.IsDeleted == false)
             {
>>>>>>> 83b63519c934bf444af32a84c6c7b94555ca382c
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