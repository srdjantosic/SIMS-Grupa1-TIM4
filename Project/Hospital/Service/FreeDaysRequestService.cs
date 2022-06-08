using Hospital.Service;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Service
{
    public class FreeDaysRequestService
    {
        private Repository.FreeDaysRequestRepository requestForFreeDaysRepository;
        private DoctorService doctorService;
        private AppointmentService appointmentService;
        private const string NOT_FOUND_ERROR = "Request with {0}:{1} can not be found!";

        public FreeDaysRequestService(Repository.FreeDaysRequestRepository requestForFreeDaysRepository, DoctorService doctorService, AppointmentService appointmentService)
        {
            this.requestForFreeDaysRepository = requestForFreeDaysRepository;
            this.doctorService = doctorService;
            this.appointmentService = appointmentService;
        }

        public FreeDaysRequestService(Repository.FreeDaysRequestRepository requestForFreeDaysRepository)
        {
            this.requestForFreeDaysRepository = requestForFreeDaysRepository;
        }

        public List<Model.FreeDaysRequest> GetAll()
        {
            return requestForFreeDaysRepository.GetAll();
        }

        //TODO
        public List<FreeDaysRequest> GetAllByLks(string lks)
        {
            List<FreeDaysRequest> doctorsRequests = new List<FreeDaysRequest>();

            foreach (Model.FreeDaysRequest request in GetAll())
            {
                if (request.Lks.Equals(lks))
                {
                    doctorsRequests.Add(request);
                }
            }
            return doctorsRequests;
        }

        public FreeDaysRequest CreateRequest(FreeDaysRequest newRequestForFreeDays)
        {
            if(newRequestForFreeDays.isEmergency == true)
            {
                return requestForFreeDaysRepository.CreateRequest(newRequestForFreeDays);
            }

            if (CountDoctorsInSameMedicineArea(doctorService.GetOne(newRequestForFreeDays.Lks).medicineArea) > 1 || isDoctorBusyInRequestPeriod(newRequestForFreeDays))
            {
                return null;
            }

            return requestForFreeDaysRepository.CreateRequest(newRequestForFreeDays);
        }

        public Boolean isDoctorBusyInRequestPeriod(FreeDaysRequest requestForFreeDays)
        {
            foreach(Appointment appointment in appointmentService.GetAllByLks(requestForFreeDays.Lks))
            {
                if(DateTime.Compare(appointment.dateTime.Date, requestForFreeDays.Start.Date) >= 0 && DateTime.Compare(appointment.dateTime.Date, requestForFreeDays.End.Date) <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int CountDoctorsInSameMedicineArea(string medicineArea)
        {
            int numberOfDoctors = 0;

            foreach (Model.FreeDaysRequest requestForFreeDays in GetAll())
            {
                if (isMedicineAreasEquals(medicineArea, doctorService.GetOne(requestForFreeDays.Lks).medicineArea) && isRequestAcceptedOrOnHold(requestForFreeDays))
                    numberOfDoctors++;
            }
            return numberOfDoctors;
        }

        public Boolean isMedicineAreasEquals(string medicineArea1, string medicineArea2)
        {
            if (medicineArea1.Equals(medicineArea2))
            {
                return true;
            }
            return false;
        }

        public Boolean isRequestAcceptedOrOnHold(Model.FreeDaysRequest requestForFreeDays)
        {
            if(requestForFreeDays.isActive == AcceptanceStatus.Status.Accept || requestForFreeDays.isActive == AcceptanceStatus.Status.OnHold)
            {
                return true;
            }
            return false;
        }

        public List<Model.FreeDaysRequest> GetRequestsOnHold()
        {
            List<Model.FreeDaysRequest> requestsOnHold = new List<Model.FreeDaysRequest>();
            foreach(Model.FreeDaysRequest request in GetAll())
            {
                if(request.isActive == AcceptanceStatus.Status.OnHold)
                {
                    requestsOnHold.Add(request);
                }
            }
            return requestsOnHold;
        }
        public Boolean UpdateRequest(Model.FreeDaysRequest requestForChange, AcceptanceStatus.Status status, String declineReason = "/")
        {
            return requestForFreeDaysRepository.UpdateRequest(requestForChange, status, declineReason);
        }
        public Boolean AcceptRequest(Model.FreeDaysRequest requestForChange)
        {
            return UpdateRequest(requestForChange, AcceptanceStatus.Status.Accept);
        }
        public Boolean DeclineRequest(Model.FreeDaysRequest requestForChange, String explanation)
        {
            return UpdateRequest(requestForChange, AcceptanceStatus.Status.Decline, explanation);
        }
    }
}
