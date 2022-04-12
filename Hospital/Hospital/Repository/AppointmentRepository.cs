/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/

using Hospital.Model;
using System;

namespace Hospital.Repository
{
   public class AppointmentRepository
   {

        public AppointmentRepository() { }
        /* public Boolean CreateAppointment(System.DateTime dateTime, int lks, int lbo)
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

        /*
         public Boolean DeleteAppointment(int id)
         {
            // TODO: implement
            return null;
         }

         public Appointment GetAppointment(int id)
         {
            // TODO: implement
            return null;
         }*/

    }
}