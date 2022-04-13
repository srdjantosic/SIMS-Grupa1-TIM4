// See https://aka.ms/new-console-template for more information
using Hospital.Contoller;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;

Manu();

static void Manu()
{
    bool endApp = false;
    while (!endApp)
    {
        Console.WriteLine("Choose role from the following list:");
        Console.WriteLine("\t1 - Manager");
        Console.WriteLine("\t2 - Doctor");
        Console.WriteLine("\t3 - Secretary");
        Console.Write("Your option? ");

        switch (Console.ReadLine())
        {
            case "1":
                Manager();
                break;
            case "2":
                Doctor();
                break;
            case "3":
                Secretary();
                break;
        }

        Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
        if (Console.ReadLine() == "n")
        {
            endApp = true;
        }
        Console.WriteLine("\n");
    }
}

static void Secretary()
{
    PatientRepository patientRepository = new PatientRepository();
    PatientService patientService = new PatientService(patientRepository);
    PatientController patientController = new PatientController(patientService);

    bool endApp = false;
    while (!endApp)
    {
        Console.WriteLine("Choose function from the following list:");
        Console.WriteLine("\t1 - Get All");
        Console.WriteLine("\t2 - Get One");
        Console.WriteLine("\t3 - Create");
        Console.WriteLine("\t4 - Update");
        Console.WriteLine("\t5 - Delete");
        Console.Write("Your option? ");


        switch (Console.ReadLine())
        {
            case "1":
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
                break;
            case "2":
                Console.WriteLine("### PATIENT ###");
                Console.Write("LBO* : ");
                String lbo = Console.ReadLine();

                Patient patient2 = patientController.GetPatient(lbo);

                if (patient2 != null)
                {

                    string text = "FIRST NAME: " + patient2.FirstName + ", \n";
                    text += "LAST NAME: " + patient2.LastName + ", \n";
                    text += "GENDER: " + patient2._Gender + ", \n";
                    text += "EMAIL: " + patient2.Email + ", \n";
                    text += "PHONE NUMBER: " + patient2.PhoneNumber + ", \n";
                    text += "JMBG: " + patient2.Jmbg + ", \n";
                    text += "LBO: " + patient2.Lbo + ", \n";
                    text += "BIRTHDAY: " + patient2.Birthday.ToShortDateString() + ", \n";
                    text += "COUNTRY: " + patient2.Country + ", \n";
                    text += "CITY: " + patient2.City + ", \n";
                    text += "ADRESS: " + patient2.Adress + ". \n";

                    Console.WriteLine(text);
                }
                break;
            case "3":
                String firstName;
                String lastName;
                Gender.Genders gender;
                String email;
                String phone;
                String jmbg;
                String lbo2;
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
                gender = (Gender.Genders)Enum.Parse(typeof(Gender.Genders), Console.ReadLine());
                Console.Write("EMAIL: ");
                email = Console.ReadLine();
                Console.Write("PHONE NUMBER: ");
                phone = Console.ReadLine();
                Console.Write("JMBG* : ");
                jmbg = Console.ReadLine();
                Console.Write("LBO* : ");
                lbo2 = Console.ReadLine();
                Console.Write("BIRTHDAY (DD/MM/YYYY) : ");
                birthday = DateTime.Parse(Console.ReadLine());
                Console.Write("COUNTRY: ");
                country = Console.ReadLine();
                Console.Write("CITY: ");
                city = Console.ReadLine();
                Console.Write("ADRESS: ");
                adress = Console.ReadLine();

                if (patientController.CreatePatient(firstName, lastName, gender, email, phone, jmbg, lbo2, birthday, country, city, adress) != null)
                {
                    Console.WriteLine("Patient " + firstName + " " + lastName + " successfully created");
                }
                else
                {
                    Console.WriteLine("Patient already exists");
                }
                break;


        }
    }
}

static void Doctor()
{
    AppointmentRepository appointmentRepository = new AppointmentRepository();
    AppointmentService appointmentService = new AppointmentService(appointmentRepository);
    AppointmentController appointmentController = new AppointmentController(appointmentService);

    bool endApp = false;
    while (!endApp)
    {
        Console.WriteLine("Choose function from the following list:");
        Console.WriteLine("\t1 - Get All");
        Console.WriteLine("\t2 - Get One");
        Console.WriteLine("\t3 - Create");
        Console.WriteLine("\t4 - Update");
        Console.WriteLine("\t5 - Delete");
        Console.WriteLine("\t6 - Back");
        Console.Write("Your option? ");

        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("### Appointments ###");
                foreach (Appointment appointment in appointmentController.ShowAppointments())
                {
                    if(appointment.IsDeleted == false)
                    {
                        string appointmentsToShow = "Id: " + appointment.Id + ", " + "Lks: " + appointment.Lks + ", " + "DateTime: " + appointment._DateTime +
                            ", " + "Lbo: " + appointment.Lbo + ", " + "idDeleted: " + appointment.IsDeleted + "\n";
                        Console.WriteLine(appointmentsToShow);
                    }
                }
                break;
            case "2":
                Console.WriteLine("Enter id of appointment");
                int appointmentId = int.Parse(Console.ReadLine());
                Console.WriteLine("### Appointment ###");
                Appointment appointment2 = appointmentController.GetAppintment(appointmentId);
                if (appointment2.IsDeleted == false)
                {
                    string appointmentToShow = "Id: " + appointment2.Id + ", " + "Lks: " + appointment2.Lks + ", " + "DateTime: " + appointment2._DateTime +
                         ", " + "Lbo: " + appointment2.Lbo + ", " + "idDeleted: " + appointment2.IsDeleted + "\n";
                    Console.WriteLine(appointmentToShow);
                }
                break;
            case "3":
                String lbo;
                String lks;
                DateTime dateTime;

                Console.WriteLine("### CREATE NEW Appointment ###");
                Console.Write("LBO* : ");
                lbo = Console.ReadLine();
                Console.Write("LKS* : ");
                lks = Console.ReadLine();
                Console.Write("DateTime* (DD/MM/YYYY) : ");
                dateTime = DateTime.Parse(Console.ReadLine());

                if (appointmentController.CreateAppointment(dateTime, lks, lbo) != null)
                {
                    Console.WriteLine("Appointment: " + dateTime + " " + lks + " " + lbo + " successfully created");
                }
                else
                {
                    Console.WriteLine("Appointment already exists");
                }
                break;
            case "4":
                break;
            case "5":
                Console.WriteLine("Enter id of appointment");
                appointmentId = int.Parse(Console.ReadLine());
                Boolean deleted = appointmentController.DeleteAppointment(appointmentId);
                if (deleted) Console.WriteLine("### Appointment is success deleted ###"); else Console.WriteLine("### Appointment IS NOT DELETED ###");
                break;
            case "6":
                Manu();
                break;
        }
    }
}
static void Manager()
{
    RoomRepository roomRepository = new RoomRepository();
    RoomService roomService = new RoomService(roomRepository);
    RoomController roomController = new RoomController(roomService);

    bool endApp = false;
    while (!endApp)
    {
        Console.WriteLine("Choose function from the following list:");
        Console.WriteLine("\t1 - Get All");
        Console.WriteLine("\t2 - Get One");
        Console.WriteLine("\t3 - Create");
        Console.WriteLine("\t4 - Update");
        Console.WriteLine("\t5 - Delete");
        Console.Write("Your option? ");


        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("### Rooms###");
                foreach (Room room in roomController.ShowRooms())
                {
                    Console.WriteLine($"Name:{ room.Name} Room Type: {room.Type} Is deleted: {room.IsDeleted}");
                }
                break;
            case "2":
                Console.WriteLine("### Room ###");
                Console.Write("Name  : ");
                String name = Console.ReadLine();

                Room room2 = roomController.GetRoom(name);

                if (room2 != null)
                {
                 Console.WriteLine($"Name:{ room2.Name} Room Type: {room2.Type} Is deleted: {room2.IsDeleted}");

                }
                break;
            case "3":
                String nam;
                RoomType.RoomTypes typ;
                Console.WriteLine("### CREATE NEW ROOM ###");
                Console.Write(" Name* : ");
                nam = Console.ReadLine();
                Console.Write("Type: ");
                typ = (RoomType.RoomTypes)Enum.Parse(typeof(RoomType.RoomTypes), Console.ReadLine());
                if (roomController.CreateRoom(nam, typ) != null)
                {
                    Console.WriteLine("Room " + nam + " " + typ + " successfully created");
                }
                else
                {
                    Console.WriteLine("Room already exists");
                }
                break;
            case "4":
                Console.WriteLine("Enter room for update");
                string n = Console.ReadLine();
                Console.WriteLine("Enter new name");
                string v = Console.ReadLine();
                Console.WriteLine("Enter new type");
                string w = Console.ReadLine();
                RoomType.RoomTypes cast = (RoomType.RoomTypes)Enum.Parse(typeof(RoomType.RoomTypes), w);
                roomController.UpdateRoom(n, v, cast);



                break;

        }
    }

}


