using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository.IRepository
{
    public interface IAppointmentRepository
    {
        public Appointment Create(Appointment newAppointment);
        public Boolean Save(List<Appointment> appointments);
        public List<Appointment> GetAll();
        public Appointment GetOne(int id);
    }
}
