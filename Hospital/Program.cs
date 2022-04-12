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

//showAppointment

AppointmentRepository appointmentRepository = new AppointmentRepository();
AppointmentService appointmentService = new AppointmentService(appointmentRepository);
AppointmentController appointmentController = new AppointmentController(appointmentService);

foreach (Appointment appointment in appointmentController.ShowAppointments())
{
    Console.WriteLine($"Id: { appointment.Id} Lks: {appointment.Lks} DateTime: {appointment.DateTime} Lbo: {appointment.Lbo}");
}

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
        text += "BIRTHDAY: " + patient.Birthday.ToShortDateString() + ", \n";
        text += "COUNTRY: " + patient.Country + ", \n";
        text += "CITY: " + patient.City + ", \n";
        text += "ADRESS: " + patient.Adress + ". \n";
        
        Console.WriteLine(text);
}

String firstName;
String lastName;
Gender.Genders gender;
String email;
String phone;
String jmbg;
String lbo;
DateTime birthday;
String country;
String city;
String adress;

Console.WriteLine("### CREATE NEW PATIENT ###");
Console.Write("FIRST NAME* : ");
firstName = Console.ReadLine();
Console.Write("LAST NAME* : ");
lastName = Console.ReadLine();
Console.Write("GENDER: ");
gender =(Gender.Genders)Enum.Parse(typeof(Gender.Genders), Console.ReadLine());
Console.Write("EMAIL: ");
email = Console.ReadLine();
Console.Write("PHONE NUMBER: ");
phone = Console.ReadLine();
Console.Write("JMBG* : ");
jmbg = Console.ReadLine();
Console.Write("LBO* : ");
lbo = Console.ReadLine();
Console.Write("BIRTHDAY (DD/MM/YYYY) : ");
birthday = DateTime.Parse(Console.ReadLine());
Console.Write("COUNTRY: ");
country = Console.ReadLine();
Console.Write("CITY: ");
city = Console.ReadLine();
Console.Write("ADRESS: ");
adress = Console.ReadLine();

if (patientController.CreatePatient(firstName, lastName, gender, email, phone, jmbg, lbo, birthday, country, city, adress)!=null)
{
    Console.WriteLine("Patient "+firstName+" "+lastName+" successfully created");
}
else
{
    Console.WriteLine("Patient already exists");
}



