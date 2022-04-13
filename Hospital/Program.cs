// See https://aka.ms/new-console-template for more information
using Hospital.Contoller;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;

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
            break;
        case "2":
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
            case "4":
                break;
            case "5":
                Console.WriteLine("### DELETE PATIENT ###");
                Console.WriteLine("LBO* : ");
                String lbo3 = Console.ReadLine();
                if (patientController.DeletePatient(lbo3))
                {
                    Console.WriteLine("Patient successfully deleted!");
                }

                break;


        }
    }
}


