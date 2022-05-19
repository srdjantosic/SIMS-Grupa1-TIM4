using Hospital.Repository;
using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using Project.Hospital.Service;
using Project.Hospital.Model;
using System.Linq;

namespace Hospital.Service
{
    public class AppointmentService
    {

        private AppointmentRepository appointmentRepository;
        private DoctorService doctorService;
        private PatientService patientService;
        private const string NOT_FOUND_ERROR = "Appointment with {0}:{1} can not be found!";
        private string[] workTime = {"08:00:00", "08:45:00", "09:30:00", "10:15:00", "11:00:00", "11:45:00", "12:30:00","13:15:00", "14:00:00", "14:45:00", "15:30:00"};

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public AppointmentService(AppointmentRepository appointmentRepository, DoctorService doctorService)
        {
            this.appointmentRepository = appointmentRepository;
            this.doctorService = doctorService;
        }
        public AppointmentService(AppointmentRepository appointmentRepository, DoctorService doctorService, PatientService patientService)
        {
            this.appointmentRepository = appointmentRepository;
            this.doctorService = doctorService;
            this.patientService = patientService;
        }
        public Appointment CreateAppointment(DateTime dateTime, string lks, string lbo, string roomName)
        {
            if (lks.Equals("") || lbo.Equals(""))
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "lbo", lbo));

            List<Appointment> appointments = ShowAppointments();

            foreach (Appointment appointment in appointments)
            {
                if (isAppointmentAlreadyExist(appointment, lks, lbo, dateTime, roomName))
                    return null;
            }
            return appointmentRepository.CreateAppointment(dateTime, lks, lbo, roomName);
        }

        public Boolean UpdateAppointment(DateTime dateTime, int id)
        {
            if (appointmentRepository.GetAppointment(id).isDeleted == true)
                return false;
            else
                return appointmentRepository.UpdateAppointment(dateTime, id);
        }

        //TODO
        public Boolean UpdateDateTimeAndRoomName(int id, DateTime dateTime, string roomName)
        {
            if (appointmentRepository.GetAppointment(id).isDeleted == true)
                return false;
            else
                return appointmentRepository.UpdateDateTimeAndRoomName(id, dateTime, roomName);
        }

        public List<Appointment> ShowAppointments()
        {
            return appointmentRepository.ShowAppointments();
        }

        public List<Appointment> ShowAppointmentsByDoctorLks(string lks)
        {
            List<Appointment> doctorAppointments = new List<Appointment>();
            foreach(Appointment appointment in ShowAppointments())
            {
                if (appointment.lks.Equals(lks)) {
                    doctorAppointments.Add(appointment);
                }
            }
            return doctorAppointments;
        }
        public Boolean DeleteAppointment(int id)
        {
            return appointmentRepository.DeleteAppointment(id);
        }

        public Appointment GetAppointment(int id)
        {
            return appointmentRepository.GetAppointment(id);
        }

        private Boolean isAppointmentAlreadyExist(Appointment appointment, string lks, string lbo, DateTime dateTime, string roomName)
        {
            if (appointment.lks.Equals(lks) && appointment.lbo.Equals(lbo) && appointment.dateTime == dateTime && appointment.roomName.Equals(roomName) 
                && appointment.isDeleted == false)
                return true;
            return false;
        }

        public List<Appointment> GetFutureAppointments(DateTime dateTime, string lks)
        {
            List<Appointment> futureAppointments = new List<Appointment>();

            foreach(Appointment appointment in ShowAppointmentsByDoctorLks(lks))
            {
                if(appointment.dateTime > dateTime)
                {
                    futureAppointments.Add(appointment);
                }
            }
            return futureAppointments;
        }
        public List<Appointment> GetPastAppointments(DateTime dateTime, string lks)
        {
            List<Appointment> pastAppointments = new List<Appointment>();

            foreach (Appointment appointment in ShowAppointmentsByDoctorLks(lks))
            {
                if (appointment.dateTime < dateTime)
                {
                    pastAppointments.Add(appointment);
                }
            }
            return pastAppointments;
        }

        public List<Appointment> GetAppointmentsByLks(String lks)
        {
            List<Appointment> appointments = new List<Appointment>();

            foreach(Appointment appointment in appointmentRepository.ShowAppointments())
            {
                if(appointment.lks == lks)
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public List<Appointment> GetAvailableAppointments(Doctor doctor, Patient patient, DateTime start, DateTime end)
        {
            List<Appointment> availableAppointments = new List<Appointment>();
            
            for(int i = 0; i<(end - start).TotalDays; i=i+1)
            {
                for (int j = 0; j < workTime.Length; j=j+1)
                {
                    if (isAppointmentInEnteredInterval(start, end, j))
                    {
                        Appointment newAvailableAppointment = new Appointment(availableAppointments.Count, doctor.lks, DateTime.Parse((start.AddDays(i)).ToShortDateString()+" "+workTime[j]), patient.Lbo, doctor.roomName);

                        if(!isWeekend(newAvailableAppointment) && isAvailable(doctor, newAvailableAppointment))
                        {
                            availableAppointments.Add(newAvailableAppointment);
                        }
                    }
                }
            }
            return availableAppointments;
        }

        public bool isAppointmentInEnteredInterval(DateTime start, DateTime end, int j)
        {
            return (DateTime.Compare(DateTime.Parse(start.ToShortDateString() + " " + workTime[j]), DateTime.Parse(start.ToString())) >= 0 && DateTime.Compare(DateTime.Parse(end.ToShortDateString() + " " + workTime[j]), DateTime.Parse(end.ToString())) <= 0);
        }

        public bool isWeekend(Appointment appointment)
        {
            return (appointment.dateTime.DayOfWeek == DayOfWeek.Saturday) || (appointment.dateTime.DayOfWeek == DayOfWeek.Sunday);
        }

        public bool isAvailable(Doctor doctor, Appointment newAvailableAppointment)
        {
            List<Appointment> appointments = GetAppointmentsByLks(doctor.lks);

            foreach (Appointment appointment in appointments)
            {
                if (!appointment.isDeleted)
                {
                    if (newAvailableAppointment.lks.Equals(appointment.lks) && newAvailableAppointment.dateTime == appointment.dateTime)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public List<Appointment> GetAvailableAppointmentsForAllDoctors(Patient patient, DateTime start, DateTime end)
        {
            List<Appointment> allAvailableAppointments = new List<Appointment>();

            foreach(Doctor doctor in doctorService.GetAll())
            {
                foreach(Appointment appointment in GetAvailableAppointments(doctor, patient, start, end))
                {
                    allAvailableAppointments.Add(appointment);
                }
            }
            return allAvailableAppointments;
        }

        public bool IsNewDateTimeAvailable(Appointment appointment, DateTime newDateTime)
        {
            foreach(Appointment appoint in GetAppointmentsByLks(appointment.lks))
            {
                if(!appoint.isDeleted)
                {
                    if(appoint.dateTime.Equals(newDateTime))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Appointment GetFirstAvailableAppointment(Patient patient, String area, DateTime receptionTime)
        {
            List<Appointment> allAvailableAppointments = new List<Appointment>();

            foreach(Doctor doctor in doctorService.GetDoktorsFromGivenArea(area))
            {
                foreach(Appointment appointment in GetAvailableAppointments(doctor, patient, receptionTime, receptionTime.AddMinutes(45)))
                {
                    allAvailableAppointments.Add(appointment);
                }
            }
            return allAvailableAppointments.MinBy(appointment => appointment.dateTime);
        }

        public List<Tuple<int, Appointment, Appointment>> GetTakenAppointments(String area, DateTime receptionTime)
        {
            List<Tuple<int, Appointment, Appointment>> takenAppointments = new List<Tuple<int, Appointment, Appointment>>();
            Appointment firstAvailableAppointment;

            foreach (Doctor doctor in doctorService.GetDoktorsFromGivenArea(area))
            {
                List<Appointment> appointments = GetAppointmentsByLks(doctor.lks);
                foreach (Appointment appointment in appointments)
                {
                    if(DateTime.Compare(appointment.dateTime, receptionTime) >= 0 && DateTime.Compare(appointment.dateTime, receptionTime.AddMinutes(45)) <= 0)
                    {
                        firstAvailableAppointment = GetFirstAvailableAppointment(appointment);
                        takenAppointments.Add(Tuple.Create(FindDifferenceInDays(appointment, firstAvailableAppointment), appointment, firstAvailableAppointment));
                        
                    }
                }
            }
            return takenAppointments.OrderByDescending(t => t.Item1).ToList();
        }

        public int FindDifferenceInDays(Appointment takenAppointment, Appointment firstAvailableAppointment)
        {
            return (int)(firstAvailableAppointment.dateTime - takenAppointment.dateTime).TotalDays;
        }

        public Appointment GetFirstAvailableAppointment(Appointment appointment)
        {
            Patient patient = patientService.GetPatient(appointment.lbo);
            Doctor doctor = doctorService.GetDoctorByLks(appointment.lks);
            DateTime start = DateTime.Parse(appointment.dateTime.AddDays(1).ToShortDateString() + " " + workTime[0]);
            DateTime end = appointment.dateTime.AddDays(10);
            List<Appointment> availableAppointments = GetAvailableAppointments(doctor, patient, start, end);

            return availableAppointments.MinBy(app => app.dateTime);
        }
    }


}

