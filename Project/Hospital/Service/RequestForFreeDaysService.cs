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
    public class RequestForFreeDaysService
    {
        private RequestForFreeDaysRepository requestForFreeDaysRepository;
        private DoctorService doctorService;
        private AppointmentService appointmentService;
        private const string NOT_FOUND_ERROR = "Request with {0}:{1} can not be found!";

        public RequestForFreeDaysService(RequestForFreeDaysRepository requestForFreeDaysRepository, DoctorService doctorService, AppointmentService appointmentService)
        {
            this.requestForFreeDaysRepository = requestForFreeDaysRepository;
            this.doctorService = doctorService;
            this.appointmentService = appointmentService;
        }

        public RequestForFreeDaysService(RequestForFreeDaysRepository requestForFreeDaysRepository)
        {
            this.requestForFreeDaysRepository = requestForFreeDaysRepository;
        }

        public List<RequestForFreeDays> GetAll()
        {
            return requestForFreeDaysRepository.GetAll();
        }

        //TODO
        public List<RequestForFreeDays> GetAllByLks(string lks)
        {
            List<RequestForFreeDays> doctorsRequests = new List<RequestForFreeDays>();

            foreach (RequestForFreeDays request in GetAll())
            {
                if (request.Lks.Equals(lks))
                {
                    doctorsRequests.Add(request);
                }
            }
            return doctorsRequests;
        }

        public RequestForFreeDays CreateRequest(RequestForFreeDays newRequestForFreeDays)
        {
            if(newRequestForFreeDays.isEmergency == true)
            {
                return requestForFreeDaysRepository.CreateRequest(newRequestForFreeDays);
            }

            if (CountDoctorsInSameMedicineArea(doctorService.GetDoctorByLks(newRequestForFreeDays.Lks).medicineArea) > 1 || isDoctorBusyInRequestPeriod(newRequestForFreeDays))
            {
                return null;
            }

            return requestForFreeDaysRepository.CreateRequest(newRequestForFreeDays);
        }

        public Boolean isDoctorBusyInRequestPeriod(RequestForFreeDays requestForFreeDays)
        {
            foreach(Appointment appointment in appointmentService.GetAppointmentsByLks(requestForFreeDays.Lks))
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

            foreach (RequestForFreeDays requestForFreeDays in GetAll())
            {
                if (isMedicineAreasEquals(medicineArea, doctorService.GetDoctorByLks(requestForFreeDays.Lks).medicineArea) && isRequestAcceptedOrOnHold(requestForFreeDays))
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

        public Boolean isRequestAcceptedOrOnHold(RequestForFreeDays requestForFreeDays)
        {
            if(requestForFreeDays.isActive == RequestForFreeDaysType.RequestForFreeDaysTypes.Accept || requestForFreeDays.isActive == RequestForFreeDaysType.RequestForFreeDaysTypes.OnHold)
            {
                return true;
            }
            return false;
        }

        public List<RequestForFreeDays> GetRequestsOnHold()
        {
            List<RequestForFreeDays> requestsOnHold = new List<RequestForFreeDays>();
            foreach(RequestForFreeDays request in GetAll())
            {
                if(request.isActive == RequestForFreeDaysType.RequestForFreeDaysTypes.OnHold)
                {
                    requestsOnHold.Add(request);
                }
            }
            return requestsOnHold;
        }

        public Boolean ChangeStatus(RequestForFreeDays requestForChange, RequestForFreeDaysType.RequestForFreeDaysTypes status)
        {
            return requestForFreeDaysRepository.UpdateRequest(requestForChange, status);
        }

    }
}
