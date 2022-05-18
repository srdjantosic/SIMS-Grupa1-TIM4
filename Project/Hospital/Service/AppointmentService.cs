using Hospital.Repository;
using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using Project.Hospital.Service;
using Project.Hospital.Model;

namespace Hospital.Service
{
    public class AppointmentService
    {

        private AppointmentRepository appointmentRepository;
        private DoctorService doctorService;
        private const string NOT_FOUND_ERROR = "Appointment with {0}:{1} can not be found!";

        public AppointmentService(AppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        public AppointmentService(AppointmentRepository appointmentRepository, DoctorService doctorService)
        {
            this.appointmentRepository = appointmentRepository;
            this.doctorService = doctorService;
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
            List<Appointment> appointments = GetAppointmentsByLks(doctor.lks);

            string[] workTime = {"08:00:00", "08:45:00", "09:30:00", "10:15:00", "11:00:00", "11:45:00", "12:30:00",
            "13:15:00", "14:00:00", "14:45:00", "15:30:00"};

            for(int i = 0; i<(end - start).TotalDays; i=i+1)
            {
                for (int j = 0; j < workTime.Length; j=j+1)
                {
                    if (DateTime.Compare(DateTime.Parse(start.ToShortDateString() + " " + workTime[j]), DateTime.Parse(start.ToString())) > 0 && DateTime.Compare(DateTime.Parse(end.ToShortDateString() + " " + workTime[j]), DateTime.Parse(end.ToString())) < 0)
                    {
                        Appointment newAvailableAppointment = new Appointment(availableAppointments.Count, doctor.lks, DateTime.Parse((start.AddDays(i)).ToShortDateString()+" "+workTime[j]), patient.Lbo, " ");

                        if((newAvailableAppointment.dateTime.DayOfWeek != DayOfWeek.Saturday) && (newAvailableAppointment.dateTime.DayOfWeek != DayOfWeek.Sunday))
                        {
                            int indicator = 0;
                            foreach (Appointment appointment in appointments)
                            {
                                if (!appointment.isDeleted)
                                {
                                    if (newAvailableAppointment.lks.Equals(appointment.lks) && newAvailableAppointment.dateTime == appointment.dateTime)
                                    {
                                        indicator = indicator + 1;
                                    }
                                }
                            }
                            if (indicator == 0)
                            {
                                availableAppointments.Add(newAvailableAppointment);
                            }
                        }
                    }
                }
            }


            return availableAppointments;
        }

        public List<Appointment> GetAllAvailableAppointments(Patient patient, DateTime start, DateTime end)
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

        public bool isNewDateTimeAvailable(Appointment appointment, DateTime newDateTime)
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
    }


}

