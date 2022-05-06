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

        public Appointment createAppointment(DateTime dateTime, string lks, string lbo, string roomName)
        {
            Appointment appointment = appointmentService.createAppointment(dateTime, lks, lbo, roomName);
            if (appointment != null)
                return appointment;
            return null;
        }


        public Boolean updateAppointment(DateTime dateTime, int id)
        {
            return appointmentService.updateAppointment(dateTime, id);
        }

        public List<Appointment> showAppointments()
        {
            return appointmentService.showAppointments();
        }

        public List<Appointment> showAppointmentsByDoctorLks(string lks)
        {
            return appointmentService.showAppointmentsByDoctorLks(lks);
        }
        public Boolean deleteAppointment(int id)
        {
            return appointmentService.deleteAppointment(id);
        }

        public Appointment getAppintment(int id)
        {
            return appointmentService.getAppointment(id);
        }

        public List<Appointment> getFutureAppointments(DateTime dateTime, string lks)
        {
            return appointmentService.getFutureAppointments(dateTime, lks);
        }

        public List<Appointment> getPastAppointments(DateTime dateTime, string lks)
        {
            return appointmentService.getPastAppointments(dateTime, lks);
        }

        public List<Appointment> getAppointmentsByLks(String lks)
        {
            return appointmentService.getAppointmentsByLks(lks);
        }

        public List<Appointment> getAvailableAppointments(Doctor doctor, Patient patient, DateTime start, DateTime end)
        {
            return appointmentService.getAvailableAppointments(doctor, patient, start, end);
        }

        public List<Appointment> getAllAvailableAppointments(Patient patient, DateTime start, DateTime end)
        {
            return appointmentService.getAllAvailableAppointments(patient, start, end);
        }

    }
}

