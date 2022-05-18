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
        private const string NOT_FOUND_ERROR = "Request with {0}:{1} can not be found!";

        public RequestForFreeDaysService(RequestForFreeDaysRepository requestForFreeDaysRepository, DoctorService doctorService)
        {
            this.requestForFreeDaysRepository = requestForFreeDaysRepository;
            this.doctorService = doctorService;
        }

        public RequestForFreeDays createRequestForFreeDays(RequestForFreeDays newRequestForFreeDays)
        {
            if(newRequestForFreeDays.isEmergency == true)
            {
                return requestForFreeDaysRepository.createRequestForFreeDays(newRequestForFreeDays);
            }

            if (countDoctorsInSameMedicineArea(doctorService.getDoctorByLks(newRequestForFreeDays.Lks).medicineArea) > 1){
                return null;
            }

            return requestForFreeDaysRepository.createRequestForFreeDays(newRequestForFreeDays);
        }

        public List<RequestForFreeDays> showRequestsForFreeDays()
        {
            return requestForFreeDaysRepository.showRequestsForFreeDays();
        }

        public int countDoctorsInSameMedicineArea(string medicineArea)
        {
            int numberOfDoctors = 0;

            foreach (RequestForFreeDays requestForFreeDays in showRequestsForFreeDays())
            {
                if (isMedicineAreasEquals(medicineArea, doctorService.getDoctorByLks(requestForFreeDays.Lks).medicineArea) && isRequestAcceptedOrOnHold(requestForFreeDays))
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

    }
}
