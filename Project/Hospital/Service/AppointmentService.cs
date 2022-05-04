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
        public Appointment createAppointment(DateTime dateTime, string lks, string lbo, string roomName)
        {
            if (lks.Equals("") || lbo.Equals(""))
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "lbo", lbo));

            List<Appointment> appointments = showAppointments();

            foreach (Appointment appointment in appointments)
            {
                if (isAppointmentAlreadyExist(appointment, lks, lbo, dateTime, roomName))
                    return null;
            }
            return appointmentRepository.createAppointment(dateTime, lks, lbo, roomName);
        }

        public Boolean updateAppointment(DateTime dateTime, int id)
        {
            if (appointmentRepository.getAppointment(id).isDeleted == true)
                return false;
            else
                return appointmentRepository.updateAppointment(dateTime, id);
        }

        public List<Appointment> showAppointments()
        {
            return appointmentRepository.showAppointments();
        }
        public Boolean deleteAppointment(int id)
        {
            return appointmentRepository.deleteAppointment(id);
        }

        public Appointment getAppointment(int id)
        {
            return appointmentRepository.getAppointment(id);
        }

        private Boolean isAppointmentAlreadyExist(Appointment appointment, string lks, string lbo, DateTime dateTime, string roomName)
        {
            if (appointment.lks.Equals(lks) && appointment.lbo.Equals(lbo) && appointment.dateTime == dateTime && appointment.roomName.Equals(roomName) 
                && appointment.isDeleted == false)
                return true;
            return false;
        }

        public List<Appointment> getFutureAppointments(DateTime dateTime)
        {
            List<Appointment> futureAppointments = new List<Appointment>();

            foreach(Appointment appointment in appointmentRepository.showAppointments())
            {
                if(appointment.dateTime > dateTime)
                {
                    futureAppointments.Add(appointment);
                }
            }
            return futureAppointments;
        }
        public List<Appointment> getPastAppointments(DateTime dateTime)
        {
            List<Appointment> futureAppointments = new List<Appointment>();

            foreach (Appointment appointment in appointmentRepository.showAppointments())
            {
                if (appointment.dateTime < dateTime)
                {
                    futureAppointments.Add(appointment);
                }
            }
            return futureAppointments;
        }

        public List<Appointment> getAppointmentsByLks(String lks)
        {
            List<Appointment> appointments = new List<Appointment>();

            foreach(Appointment appointment in appointmentRepository.showAppointments())
            {
                if(appointment.lks == lks)
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public List<Appointment> getAvailableAppointments(Doctor doctor, Patient patient, DateTime start, DateTime end)
        {
            List<Appointment> availableAppointments = new List<Appointment>();
            List<Appointment> appointments = getAppointmentsByLks(doctor.lks);

            string[] workTime = {"08:00:00", "08:45:00", "09:30:00", "10:15:00", "11:00:00", "11:45:00", "12:30:00",
            "13:15:00", "14:00:00", "14:45:00", "15:30:00"};

            for(int i = 0; i<(end - start).TotalDays; i=i+1)
            {
                for (int j = 0; j < workTime.Length; j=j+1)
                {
                    if (DateTime.Compare(DateTime.Parse(start.ToShortDateString() + " " + workTime[j]), DateTime.Parse(start.ToString())) > 0 && DateTime.Compare(DateTime.Parse(end.ToShortDateString() + " " + workTime[j]), DateTime.Parse(end.ToString())) < 0)
                    {
                        Appointment newAvailableAppointment = new Appointment(availableAppointments.Count, doctor.lks, DateTime.Parse((start.AddDays(i)).ToShortDateString()+" "+workTime[j]), patient.Lbo, " ");

                        int indicator = 0;
                        foreach (Appointment appointment in appointments)
                        {
                            if(!appointment.isDeleted)
                            {
                                if (newAvailableAppointment.lks.Equals(appointment.lks) && newAvailableAppointment.dateTime == appointment.dateTime)
                                {
                                    indicator = indicator + 1;
                                }
                            }   
                        }
                        if(indicator == 0)
                        {
                            availableAppointments.Add(newAvailableAppointment);
                        }
                        
                    }
                }
            }


            return availableAppointments;
        }

        public List<Appointment> getAllAvailableAppointments(Patient patient, DateTime start, DateTime end)
        {
            List<Appointment> allAvailableAppointments = new List<Appointment>();

            foreach(Doctor doctor in doctorService.getAll())
            {
                foreach(Appointment appointment in getAvailableAppointments(doctor, patient, start, end))
                {
                    allAvailableAppointments.Add(appointment);
                }
            }
            return allAvailableAppointments;
        }
        

    }


}

