using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;
using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.View.Secretary.Commands;
using System.Windows.Navigation;
using Project.Hospital.View.Secretary;
using System.Windows;

namespace Project.Hospital.ViewModels.Secretary
{
    public class ZakazivanjePregledaViewModel : ViewModel
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;
        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;
        private readonly DelegateCommand<string> confirm;
        private readonly DelegateCommand<string> quit;
        private readonly DelegateCommand<string> check;
        public ZakazivanjePregledaViewModel()
        {
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);
            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);
            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);

            quit = new DelegateCommand<string>(
                (s) => { var page = new RasporedPage(); },
                (s) => { return true; }
                );
            check = new DelegateCommand<string>(
                (s) => { MessageBox.Show("cekiraj"); }
                );
        }
        private String lbo;
        public String Lbo
        {
            get { return lbo; }
            set
            {
                lbo = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        private String patientFirstName;
        public String PatientFirstName
        {
            get { return patientFirstName; }
            set
            {
                patientFirstName = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        private String patientLastName;
        public String PatientLastName
        {
            get { return patientLastName; }
            set
            {
                patientLastName = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        private String doctorFirstName;
        public String DoctorFirstName
        {
            get { return doctorFirstName; }
            set
            {
                doctorFirstName = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        private String doctorLastName;
        public String DoctorLastName
        {
            get { return doctorLastName; }
            set
            {
                doctorLastName = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        private String startDate;
        public String StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        private String startTime;
        public String StartTime
        {
            get { return startTime; }
            set
            {
                startTime = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        private String endDate;
        public String EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        private String endTime;
        public String EndTime
        {
            get { return endTime; }
            set
            {
                endTime = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand<string> Confirm
        {
            get { return confirm; }
        }
        public DelegateCommand<string> Quit
        {
            get { return quit; }
        }
        public DelegateCommand<String> Check
        {
            get { return check; }
        }
    }
}
