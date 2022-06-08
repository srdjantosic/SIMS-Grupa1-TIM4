using Hospital.Repository;
using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using Project.Hospital.Service;
using Project.Hospital.Model;
using System.Linq;
using Project.Hospital.Repository.IRepository;

namespace Hospital.Service
{
    public class AppointmentService
    {
        private IAppointmentRepository iAppointmentRepo;
        private DoctorService doctorService;
        private PatientService patientService;
        private const string NOT_FOUND_ERROR = "Appointment with {0}:{1} can not be found!";
        private string[] workTime = {"08:00:00", "08:45:00", "09:30:00", "10:15:00", "11:00:00", "11:45:00", "12:30:00","13:15:00", "14:00:00", "14:45:00", "15:30:00"};

        public AppointmentService(IAppointmentRepository iAppointmentRepo)
        {
            this.iAppointmentRepo = iAppointmentRepo;
        }

        public AppointmentService(IAppointmentRepository iAppointmentRepo, DoctorService doctorService)
        {
            this.iAppointmentRepo = iAppointmentRepo;
            this.doctorService = doctorService;
        }
        public AppointmentService(IAppointmentRepository iAppointmentRepo, DoctorService doctorService, PatientService patientService)
        {
            this.iAppointmentRepo = iAppointmentRepo;
            this.doctorService = doctorService;
            this.patientService = patientService;
        }
        public Appointment Create(Appointment newAppointment)
        {
            List<Appointment> appointments = GetAll();

            foreach (Appointment appointment in appointments)
            {
                if (isAppointmentAlreadyExist(appointment, newAppointment))
                    return null;
            }
            return iAppointmentRepo.Create(newAppointment);
        }

        private Boolean isAppointmentAlreadyExist(Appointment appointment, Appointment newAppointment)
        {
            if (appointment.Lks.Equals(newAppointment.Lks) && appointment.Lbo.Equals(newAppointment.Lbo) && appointment.dateTime == newAppointment.dateTime 
                && appointment.RoomName.Equals(newAppointment.RoomName) && appointment.isDeleted == false)
            {
                return true;
            }
            return false;
        }

        public Boolean UpdateTime(DateTime dateTime, int id)
        {
            if (iAppointmentRepo.GetById(id).isDeleted == true)
                return false;

            List<Appointment> appointments = GetAll();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id == id)
                {
                    appointment.dateTime = dateTime;
                    iAppointmentRepo.Save(appointments);
                    return true;
                }
            }
            return false;
        }

        //TODO
        public Appointment UpdateTimeAndRoom(int id, DateTime dateTime, string roomName)
        {
            if (iAppointmentRepo.GetById(id).isDeleted == true)
                return null;

            List<Appointment> appointments = GetAll();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.Id == id)
                {
                    appointment.dateTime = dateTime;
                    appointment.RoomName = roomName;
                    iAppointmentRepo.Save(appointments);
                    return appointment;
                }
            }
            return null;
        }

        public List<Appointment> GetAll()
        {
            return iAppointmentRepo.GetAll();
        }

        public List<Appointment> GetAllByLks(string lks)
        {
            List<Appointment> doctorAppointments = new List<Appointment>();
            foreach(Appointment appointment in GetAll())
            {
                if (appointment.Lks.Equals(lks)) {
                    doctorAppointments.Add(appointment);
                }
            }
            return doctorAppointments;
        }
        public Boolean Delete(int id)
        {
            List<Appointment> appointments = GetAll();
            Appointment appointmentToDelete = GetById(id);

            if (appointmentToDelete != null && appointmentToDelete.isDeleted == false)
            {
                appointments.RemoveAt(id);
                appointmentToDelete.isDeleted = true;
                appointments.Insert(id, appointmentToDelete);
                return iAppointmentRepo.Save(appointments);
            }

            return false;
        }

        public Appointment GetById(int id)
        {
            return iAppointmentRepo.GetById(id);
        }

        public List<Appointment> GetAllFutureByLks(DateTime dateTime, string lks)
        {
            List<Appointment> futureAppointments = new List<Appointment>();

            foreach(Appointment appointment in GetAllByLks(lks))
            {
                if(appointment.dateTime > dateTime)
                {
                    futureAppointments.Add(appointment);
                }
            }
            return futureAppointments;
        }
        public List<Appointment> GetAllPastByLks(DateTime dateTime, string lks)
        {
            List<Appointment> pastAppointments = new List<Appointment>();

            foreach (Appointment appointment in GetAllByLks(lks))
            {
                if (appointment.dateTime < dateTime)
                {
                    pastAppointments.Add(appointment);
                }
            }
            return pastAppointments;
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
            List<Appointment> appointments = GetAllByLks(doctor.lks);

            foreach (Appointment appointment in appointments)
            {
                if (!appointment.isDeleted)
                {
                    if (newAvailableAppointment.Lks.Equals(appointment.Lks) && newAvailableAppointment.dateTime == appointment.dateTime)
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
            foreach(Appointment appoint in GetAllByLks(appointment.Lks))
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

        public Appointment ScheduleEmergencyAppointment(Patient patient, String area, DateTime receptionTime)
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
                List<Appointment> appointments = GetAllByLks(doctor.lks);
                foreach (Appointment appointment in appointments)
                {
                    if (!appointment.isDeleted)
                    {
                        if (isAppointmentWithinNext45Minutes(appointment, receptionTime))
                        {
                            firstAvailableAppointment = FindFirstFreeTerm(appointment);
                            takenAppointments.Add(Tuple.Create(FindDifferenceInDays(appointment, firstAvailableAppointment), appointment, firstAvailableAppointment));

                        }
                    }
                }
            }
            return takenAppointments.OrderByDescending(t => t.Item1).ToList();
        }

       public bool isAppointmentWithinNext45Minutes(Appointment appointment, DateTime receptionTime)
        {
            return (DateTime.Compare(appointment.dateTime, receptionTime) >= 0 && DateTime.Compare(appointment.dateTime, receptionTime.AddMinutes(45)) <= 0);
        }

        public int FindDifferenceInDays(Appointment takenAppointment, Appointment firstAvailableAppointment)
        {
            return (int)(firstAvailableAppointment.dateTime - takenAppointment.dateTime).TotalDays;
        }

        public Appointment FindFirstFreeTerm(Appointment appointment)
        {
            Patient patient = patientService.GetOne(appointment.Lbo);
            Doctor doctor = doctorService.GetDoctorByLks(appointment.Lks);
            DateTime start = DateTime.Parse(appointment.dateTime.AddDays(1).ToShortDateString() + " " + workTime[0]);
            DateTime end = appointment.dateTime.AddDays(10);
            List<Appointment> availableAppointments = GetAvailableAppointments(doctor, patient, start, end);

            return availableAppointments.MinBy(app => app.dateTime);
        }
    }


}

