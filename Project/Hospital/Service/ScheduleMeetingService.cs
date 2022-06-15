using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Service
{
    public class ScheduleMeetingService
    {
        private DoctorService doctorService;
        private AppointmentService appointmentService;
        private MeetingService meetingService;

        public ScheduleMeetingService(DoctorService doctorService, AppointmentService appointmentService, MeetingService meetingService)
        {
            this.doctorService = doctorService;
            this.appointmentService = appointmentService;
            this.meetingService = meetingService;
        }
        public Boolean isRoomFreeInSelectedTime(String roomName, DateTime dateAndTime)
        {
            foreach (Meeting meeting in meetingService.GetAllByRoom(roomName))
            {
                if (meeting.MaintenanceTime.Date == dateAndTime.Date)
                {
                    if (!isFreeAnHourBeforeAndAnHourAfter(dateAndTime, meeting.MaintenanceTime))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public Boolean areParticipantsFree(Meeting meeting)
        {
            foreach (String patricipant in meeting.Participants)
            {
                if (isParticipantOnAnotherMeeting(patricipant, meeting.MaintenanceTime))
                {
                    return false;
                }

                if (doctorService.GetOne(patricipant) != null)
                {
                    if (!isDoctorFree(patricipant, meeting.MaintenanceTime))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public Boolean isDoctorFree(String lks, DateTime dateAndTime)
        {
            foreach(Appointment appointment in appointmentService.GetAllByLks(lks))
            {
                if(appointment.dateTime.Date == dateAndTime.Date)
                {
                    if (!isFreeAnHourBeforeAndAnHourAfter(dateAndTime, appointment.dateTime))
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
                    if (!isFreeAnHourBeforeAndAnHourAfter(dateAndTime, meeting.MaintenanceTime))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Boolean isFreeAnHourBeforeAndAnHourAfter(DateTime newMeeting, DateTime eventTime)
        {
            return eventTime <= newMeeting.Add(new TimeSpan(-1, 0, 0)) || newMeeting.Add(new TimeSpan(1, 0, 0)) <= eventTime;
        }
    }
}
