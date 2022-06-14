using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Service
{
    public class ParticipantsService
    {
        private DoctorService doctorService;
        private AppointmentService appointmentService;
        private MeetingService meetingService;

        public ParticipantsService(DoctorService doctorService, AppointmentService appointmentService, MeetingService meetingService)
        {
            this.doctorService = doctorService;
            this.appointmentService = appointmentService;
            this.meetingService = meetingService;
        }
        public Boolean isParticipantsFree(Meeting meeting)
        {
            foreach (String patricipant in meeting.Participants)
            {
                if (doctorService.GetOne(patricipant) != null)
                {
                    return (isDoctorFree(patricipant, meeting.MaintenanceTime) && isParticipantOnAnotherMeeting(patricipant, meeting.MaintenanceTime));
                }
                return isParticipantOnAnotherMeeting(patricipant, meeting.MaintenanceTime);
            }
            return false;
        }
        public Boolean isDoctorFree(String lks, DateTime dateAndTime)
        {
            foreach(Appointment appointment in appointmentService.GetAllByLks(lks))
            {
                if(appointment.dateTime.Date == dateAndTime.Date)
                {
                    if(appointment.dateTime > dateAndTime.Add(new TimeSpan(-1, 0, 0)) || dateAndTime.Add(new TimeSpan(1, 0, 0)) > appointment.dateTime)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Boolean isParticipantOnAnotherMeeting(String designation, DateTime dateAndTime)
        {
            foreach(Meeting meeting in meetingService.GetAllByParticipant(designation))
            {
                if (meeting.MaintenanceTime.Date == dateAndTime.Date)
                {
                    if (meeting.MaintenanceTime > dateAndTime.Add(new TimeSpan(-1, 0, 0)) || dateAndTime.Add(new TimeSpan(1, 0, 0)) > meeting.MaintenanceTime)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
