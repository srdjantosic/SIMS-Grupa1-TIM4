// See https://aka.ms/new-console-template for more information
using Hospital.Contoller;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;

RoomRepository roomRepository = new RoomRepository();
RoomService roomService = new RoomService(roomRepository);
RoomController roomController = new RoomController(roomService);

foreach (Room room in roomController.ShowRooms())
{
    Console.WriteLine($"Name:{ room.Name} Room Type: {room.Type} Is deleted: {room.IsDeleted}");
}

Console.WriteLine("Unesite sobu za azuriranje");
string n = Console.ReadLine();
Console.WriteLine("Unesite novu oznaku");
string v = Console.ReadLine();
Console.WriteLine("Unesite namenu prostorije");
string w = Console.ReadLine();
RoomType.RoomTypes cast = (RoomType.RoomTypes)Enum.Parse(typeof(RoomType.RoomTypes), w);
roomController.UpdateRoom(n,v,cast);


    




//showAppointment
/*
AppointmentRepository appointmentRepository = new AppointmentRepository();
AppointmentService appointmentService = new AppointmentService(appointmentRepository);
AppointmentController appointmentController = new AppointmentController(appointmentService);

foreach (Appointment appointment in appointmentController.ShowAppointments())
{
    Console.WriteLine($"Id: { appointment.Id} Lks: {appointment.Lks} DateTime: {appointment.DateTime} Lbo: {appointment.Lbo}");
}
*/
//SECRETARY

PatientRepository patientRepository = new PatientRepository();
PatientService patientService = new PatientService(patientRepository);
PatientController patientController = new PatientController(patientService);


    Console.WriteLine("### Patients ###");
    foreach (Patient patient in patientController.ShowPatients())
    {
        string text = "FIRST NAME: " + patient.FirstName + ", \n";
        text += "LAST NAME: " + patient.LastName + ", \n";
        text += "GENDER: " + patient._Gender + ", \n";
        text += "EMAIL: " + patient.Email + ", \n";
        text += "PHONE NUMBER: " + patient.PhoneNumber + ", \n";
        text += "JMBG: " + patient.Jmbg + ", \n";
        text += "LBO: " + patient.Lbo + ", \n";
        text += "COUNTRY: " + patient.Country + ", \n";
        text += "CITY: " + patient.City + ", \n";
        text += "ADRESS: " + patient.Adress + ". \n";
        
        Console.WriteLine(text);
    }


