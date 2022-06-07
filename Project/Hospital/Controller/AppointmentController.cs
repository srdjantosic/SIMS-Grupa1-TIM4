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

        public Appointment CreateAppointment(DateTime dateTime, string lks, string lbo, string roomName)
        {
            Appointment appointment = appointmentService.CreateAppointment(dateTime, lks, lbo, roomName);
            if (appointment != null)
                return appointment;
            return null;
        }


        public Boolean UpdateAppointment(DateTime dateTime, int id)
        {
            return appointmentService.UpdateAppointment(dateTime, id);
        }

        //TODO
        public Appointment UpdateDateTimeAndRoomName(int id, DateTime dateTime, string roomName)
        {
            return appointmentService.UpdateDateTimeAndRoomName(id, dateTime, roomName);
        }

        public List<Appointment> ShowAppointments()
        {
            return appointmentService.ShowAppointments();
        }

        public List<Appointment> ShowAppointmentsByDoctorLks(string lks)
        {
            return appointmentService.ShowAppointmentsByDoctorLks(lks);
        }
        public Boolean DeleteAppointment(int id)
        {
            return appointmentService.DeleteAppointment(id);
        }

        public Appointment GetAppintment(int id)
        {
            return appointmentService.GetAppointment(id);
        }

        public List<Appointment> GetFutureAppointments(DateTime dateTime, string lks)
        {
            return appointmentService.GetFutureAppointments(dateTime, lks);
        }

        public List<Appointment> GetPastAppointments(DateTime dateTime, string lks)
        {
            return appointmentService.GetPastAppointments(dateTime, lks);
        }

        public List<Appointment> GetAppointmentsByLks(String lks)
        {
            return appointmentService.GetAppointmentsByLks(lks);
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

