
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
<<<<<<< HEAD

=======
>>>>>>> dd9f4fac733eb55b01dde56b96ce1c428b909399

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
        Console.WriteLine("\t6 - Back");
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
                else
                {
                    Console.WriteLine("Patient with lbo " + lbo + " can not be found!");

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
                string stringGender=Console.ReadLine();
                gender = (stringGender.Length == 0) ? Gender.Genders.No_Gender : (Gender.Genders)Enum.Parse(typeof(Gender.Genders), stringGender);
                Console.Write("EMAIL: ");
                email = Console.ReadLine();
                Console.Write("PHONE NUMBER: ");
                phone = Console.ReadLine();
                Console.Write("JMBG* : ");
                jmbg = Console.ReadLine();
                Console.Write("LBO* : ");
                lbo2 = Console.ReadLine();
                Console.Write("BIRTHDAY (DD/MM/YYYY) : ");
                string stringBirthday = Console.ReadLine();
                birthday=(stringBirthday.Length==0) ?  DateTime.Parse("11/11/1111") :  DateTime.Parse(stringBirthday);
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
<<<<<<< HEAD
            case "4":
                Console.WriteLine("### UPDATE PATIENT ###");

                Console.WriteLine("LBO* : ");
                String lbo3 = Console.ReadLine();
                Console.WriteLine("New data: ");
                Console.Write("FIRST NAME : ");
                firstName = Console.ReadLine();
                Console.Write("LAST NAME : ");
                lastName = Console.ReadLine();
                Console.Write("GENDER: ");
                string stringGender2 = Console.ReadLine();
                gender = (stringGender2.Length == 0) ? Gender.Genders.No_Gender : (Gender.Genders)Enum.Parse(typeof(Gender.Genders), stringGender2);
                Console.Write("BIRTHDAY (DD/MM/YYYY) : ");
                string stringBirthday2 = Console.ReadLine();
                birthday = (stringBirthday2.Length == 0) ? DateTime.Parse("11/11/1111") : DateTime.Parse(stringBirthday2);
                Console.Write("EMAIL: ");
                email = Console.ReadLine();
                Console.Write("PHONE NUMBER: ");
                phone = Console.ReadLine();
                Console.Write("COUNTRY: ");
                country = Console.ReadLine();
                Console.Write("CITY: ");
                city = Console.ReadLine();
                Console.Write("ADRESS: ");
                adress = Console.ReadLine();

                if(patientController.UpdatePatient(lbo3, firstName, lastName, gender, birthday, email, phone, country, city, adress))
                {
                    Console.WriteLine("Patient successfully updated!");
                }

                break;
            case "5":
                Console.WriteLine("### DELETE PATIENT ###");
                Console.WriteLine("LBO* : ");
                String lbo4 = Console.ReadLine();
                if (patientController.DeletePatient(lbo4))
                {
                    Console.WriteLine("Patient successfully deleted!");
                }
                break;
            case "6":
                Manu();
                break;
=======

>>>>>>> dd9f4fac733eb55b01dde56b96ce1c428b909399

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
                Console.WriteLine("### Enter your LKS:  ###");
                string doctorLks = Console.ReadLine();

                Console.WriteLine("### Appointments ###");
                foreach (Appointment appointment in appointmentController.ShowAppointments())
                {
                    if(appointment.IsDeleted == false && appointment.Lks.Equals(doctorLks))
                    {
                        string appointmentsToShow = "Id: " + appointment.Id + ", " + "Lks: " + appointment.Lks + ", " + "DateTime: " + appointment._DateTime +
                            ", " + "Lbo: " + appointment.Lbo + ", " + "idDeleted: " + appointment.IsDeleted + "\n";
                        Console.WriteLine(appointmentsToShow);
                    }
                }
                break;
            case "2":
                Console.WriteLine("### Enter your LKS:  ###");
                doctorLks = Console.ReadLine();

                Console.WriteLine("Enter id of appointment");
                int appointmentId = int.Parse(Console.ReadLine());
                Appointment appointment2 = appointmentController.GetAppintment(appointmentId);

                if (appointment2 != null && appointment2.IsDeleted == false && appointment2.Lks.Equals(doctorLks))
                {
                    Console.WriteLine("### Appointment ###");
                    string appointmentToShow = "Id: " + appointment2.Id + ", " + "Lks: " + appointment2.Lks + ", " + "DateTime: " + appointment2._DateTime +
                         ", " + "Lbo: " + appointment2.Lbo + ", " + "idDeleted: " + appointment2.IsDeleted + "\n";
                    Console.WriteLine(appointmentToShow);
                }else 
                    Console.WriteLine("Appointment doesn't exist");

                break;
            case "3":
                Console.WriteLine("### CREATE NEW Appointment ###");
                Console.Write("LBO* : ");
                String newlbo = Console.ReadLine();
                Console.Write("LKS* : ");
                String newlks = Console.ReadLine();
                Console.Write("DateTime* (MM/DD/YYYY HH:MM:SS) : ");
                
                String input = Console.ReadLine();
                if (input.Equals(""))
                {
                    Console.Write("Please enter DateTime\n");
                    Doctor();

                }

                DateTime newDateTime = DateTime.Parse(input);
                    
                if (appointmentController.CreateAppointment(newDateTime, newlks, newlbo) != null) 
                    Console.WriteLine("Appointment: " + newDateTime + " " + newlks + " " + newlbo + " successfully created");
                else 
                    Console.WriteLine("Appointment already exists");

                break;
            case "4":
                Console.WriteLine("### UPDATE Appointment ###");

                Console.WriteLine("### Enter your LKS:  ###");
                doctorLks = Console.ReadLine();

                Console.Write("Id: ");
                
                input = Console.ReadLine();
                if (input.Equals(""))
                {
                    Console.Write("Please enter id\n");
                    Doctor();
                }

                int idAppointmentToUpdate = int.Parse(input);

                if(!appointmentService.GetAppointment(idAppointmentToUpdate).Lks.Equals(doctorLks))
                {
                    Console.WriteLine("### You only call update your appointment ###");
                    Doctor();
                }

                Console.Write("DateTime (DD/MM/YYYY) : ");
                input = Console.ReadLine();
                if (input.Equals(""))
                {
                    Console.Write("Please enter DateTime\n");
                    Doctor();
                }
                DateTime dateTimeToUpdate = DateTime.Parse(input);

                if(appointmentController.UpdateAppointment(dateTimeToUpdate, idAppointmentToUpdate))
                    Console.Write("Appointment is successfully updated\n");
                else
                    Console.Write("ERROR - ID doesn't exist!!!\n");

                break;
            case "5":
                Console.WriteLine("Enter id of appointment");
                input = Console.ReadLine();
                if (input.Equals(""))
                {
                    Console.Write("Please enter id\n");
                    Doctor();
                }

                appointmentId = int.Parse(input);

                Console.WriteLine("### Enter your LKS:  ###");
                doctorLks = Console.ReadLine();

                if (!appointmentService.GetAppointment(appointmentId).Lks.Equals(doctorLks))
                {
                    Console.WriteLine("### You only call delete your appointment ###");
                    Doctor();
                }

                Boolean deleted = appointmentController.DeleteAppointment(appointmentId);
                if (deleted) Console.WriteLine("### Appointment is success deleted ###"); else Console.WriteLine("### ERROR - Appointment doesn't exist!!! ###");
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
        Console.WriteLine("\t6 - Back");

        Console.Write("Your option? ");


        switch (Console.ReadLine())
        {
            case "1":
                Console.WriteLine("### Rooms###");
                foreach (Room room in roomController.ShowRooms())
                {
                    Console.WriteLine($"Name:{ room.Name} Room Type: {room.Type} ");
                }
                break;
            case "2":
                Console.WriteLine(" Room ");
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
                Console.WriteLine("Create new room");
                Console.Write("Enter name : ");
                nam = Console.ReadLine();
                if (nam.Equals(""))
                {
                    Console.Write("Try again, you must input name!\n");
                    Manager();
                }
                Console.Write("Enter type: ");
                typ = (RoomType.RoomTypes)Enum.Parse(typeof(RoomType.RoomTypes), Console.ReadLine());
                if (roomController.CreateRoom(nam, typ) != null)
                {
                    Console.WriteLine("Room: " + nam + " Type:" + typ + " successfully created");
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
                if (v.Equals(""))
                {
                    Console.Write("Try again, you must input new name!\n");
                   Manager();
                }
                Console.WriteLine("Enter new type");
                string w = Console.ReadLine();
                if (w.Equals(""))
                {
                    Console.Write("Try again, you must input new type!\n");
                    Manager();
                }
                RoomType.RoomTypes cast = (RoomType.RoomTypes)Enum.Parse(typeof(RoomType.RoomTypes), w);
               Boolean updated= roomController.UpdateRoom(n, v, cast);
                if (updated) Console.WriteLine(" Room is successfully updated!");
                else Console.WriteLine(" Room with that name does not exists! ");
                break;
            case "5":
                Console.WriteLine("Enter id of room");
                string roomid = Console.ReadLine();
                Boolean deleted = roomController.DeleteRoom(roomid);
                if (deleted) Console.WriteLine(" Room is successfully deleted!");
                else Console.WriteLine(" Room with that name does not exists! ");
                break;
            case "6":
                Manu();
                break;

        }
    }

}


