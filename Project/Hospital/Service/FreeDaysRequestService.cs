using Hospital.Service;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Service
{
    public class FreeDaysRequestService
    {
        private IFreeDaysRequestRepository iFreeDaysRequestRepo;
        private DoctorService doctorService;
        private AppointmentService appointmentService;
        private const string NOT_FOUND_ERROR = "Request with {0}:{1} can not be found!";

        public FreeDaysRequestService(IFreeDaysRequestRepository iFreeDaysRequestRepo, DoctorService doctorService, AppointmentService appointmentService)
        {
            this.iFreeDaysRequestRepo = iFreeDaysRequestRepo;
            this.doctorService = doctorService;
            this.appointmentService = appointmentService;
        }

        public FreeDaysRequestService(IFreeDaysRequestRepository iFreeDaysRequestRepo)
        {
            this.iFreeDaysRequestRepo = iFreeDaysRequestRepo;
        }

        public List<FreeDaysRequest> GetAll()
        {
            return iFreeDaysRequestRepo.GetAll();
        }

        public List<FreeDaysRequest> GetAllByLks(string lks)
        {
            List<FreeDaysRequest> doctorsRequests = new List<FreeDaysRequest>();

            foreach (FreeDaysRequest request in GetAll())
            {
                if (request.Lks.Equals(lks))
                {
                    doctorsRequests.Add(request);
                }
            }
            return doctorsRequests;
        }
        public FreeDaysRequest Create(FreeDaysRequest request)
        {
            if(request.isEmergency)
            {
                return iFreeDaysRequestRepo.Create(request);
            }

            if (CountDoctorsInSameMedicineArea(doctorService.GetOne(request.Lks).medicineArea) > 1 || isDoctorBusyInRequestedPeriod(request))
            {
                return null;
            }

            return iFreeDaysRequestRepo.Create(request);
        }

        public Boolean isDoctorBusyInRequestedPeriod(FreeDaysRequest request)
        {
            foreach(Appointment appointment in appointmentService.GetAllByLks(request.Lks))
            {
                if(DateTime.Compare(appointment.dateTime.Date, request.Start.Date) >= 0 && DateTime.Compare(appointment.dateTime.Date, request.End.Date) <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int CountDoctorsInSameMedicineArea(string medicineArea)
        {
            int numberOfDoctors = 0;

            foreach (FreeDaysRequest requestForFreeDays in GetAll())
            {
                if (areMedicineAreasEqual(medicineArea, doctorService.GetOne(requestForFreeDays.Lks).medicineArea) && isRequestAcceptedOrOnHold(requestForFreeDays))
                    numberOfDoctors++;
            }
            return numberOfDoctors;
        }

        public Boolean areMedicineAreasEqual(string medicineArea1, string medicineArea2)
        {
            if (medicineArea1.Equals(medicineArea2))
            {
                return true;
            }
            return false;
        }

        public Boolean isRequestAcceptedOrOnHold(FreeDaysRequest request)
        {
            if(request.isActive == AcceptanceStatus.Status.Accept || request.isActive == AcceptanceStatus.Status.OnHold)
            {
                return true;
            }
            return false;
        }

        public List<FreeDaysRequest> GetAllOnHold()
        {
            List<FreeDaysRequest> requestsOnHold = new List<FreeDaysRequest>();
            foreach(FreeDaysRequest request in GetAll())
            {
                if(request.isActive == AcceptanceStatus.Status.OnHold)
                {
                    requestsOnHold.Add(request);
                }
            }
            return requestsOnHold;
        }
        public Boolean Update(FreeDaysRequest requestForChange, AcceptanceStatus.Status status, String declineReason = "/")
        {
            List<FreeDaysRequest> requests = GetAll();
            foreach (FreeDaysRequest request in requests)
            {
                if (request.Lks == requestForChange.Lks && request.Start == requestForChange.Start && request.End == requestForChange.End)
                {
                    request.isActive = status;
                    request.DeclineReason = declineReason;
                    iFreeDaysRequestRepo.Save(requests);
                    return true;
                }
            }
            return false;
        }

        public Boolean Accept(FreeDaysRequest requestForChange)
        {
            return Update(requestForChange, AcceptanceStatus.Status.Accept);
        }
        public Boolean Decline(FreeDaysRequest requestForChange, String explanation)
        {
            return Update(requestForChange, AcceptanceStatus.Status.Decline, explanation);
        }
    }
}
