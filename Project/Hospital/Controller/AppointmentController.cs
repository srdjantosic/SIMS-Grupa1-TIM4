using Hospital.Service;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;

namespace Project.Hospital.Controller
{
    public class AppointmentController
    {
        private AppointmentService appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public Appointment Create(Appointment newAppointment)
        {
            return appointmentService.Create(newAppointment);
        }


        public Boolean UpdateTime(DateTime dateTime, int id)
        {
            return appointmentService.UpdateTime(dateTime, id);
        }

        public Appointment UpdateTimeAndRoom(int id, DateTime dateTime, string roomName)
        {
            return appointmentService.UpdateTimeAndRoom(id, dateTime, roomName);
        }

        public List<Appointment> GetAll()
        {
            return appointmentService.GetAll();
        }

        public List<Appointment> GetAllByLks(string lks)
        {
            return appointmentService.GetAllByLks(lks);
        }
        public Boolean Delete(int id)
        {
            return appointmentService.Delete(id);
        }

        public Appointment GetById(int id)
        {
            return appointmentService.GetById(id);
        }

        public List<Appointment> GetAllFutureByLks(DateTime dateTime, string lks)
        {
            return appointmentService.GetAllFutureByLks(dateTime, lks);
        }

        public List<Appointment> GetAllPastByLks(DateTime dateTime, string lks)
        {
            return appointmentService.GetAllPastByLks(dateTime, lks);
        }

        public List<Appointment> GetAvailableAppointments(Doctor doctor, Patient patient, DateTime start, DateTime end)
        {
            return appointmentService.GetAvailableAppointments(doctor, patient, start, end);
        }

        public List<Appointment> GetAvailableAppointmentsForAllDoctors(Patient patient, DateTime start, DateTime end)
        {
            return appointmentService.GetAvailableAppointmentsForAllDoctors(patient, start, end);
        }

        public bool IsNewDateTimeAvailable(Appointment appointment, DateTime newDateTime)
        {
            return appointmentService.IsNewDateTimeAvailable(appointment, newDateTime);
        }
        public Appointment ScheduleEmergencyAppointment(Patient patient, String area, DateTime receptionTime)
        {
            return appointmentService.ScheduleEmergencyAppointment(patient, area, receptionTime);
        }
        public List<Tuple<int, Appointment, Appointment>> GetTakenAppointments(String area, DateTime receptionTime)
        {
            return appointmentService.GetTakenAppointments(area, receptionTime);
        }
    }
}

