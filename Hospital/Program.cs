// See https://aka.ms/new-console-template for more information
using Hospital.Contoller;
using Hospital.Service;
using Hospital.Repository;
using Hospital.Model;

RoomRepository roomRepository = new RoomRepository();
RoomService roomService = new RoomService(roomRepository);
RoomController roomController = new RoomController(roomService);

foreach(Room room in roomController.ShowRooms()){
    Console.WriteLine($"Name:{ room.Name} Room Type: {room.Type} Is deleted: {room.IsDeleted}");
}
    
//showAppointment

AppointmentRepository appointmentRepository = new AppointmentRepository();
AppointmentService appointmentService = new AppointmentService(appointmentRepository);
AppointmentController appointmentController = new AppointmentController(appointmentService);

foreach(Appointment appointment in appointmentController.ShowAppointments())
{
    Console.WriteLine($"Id: { appointment.Id} Lks: {appointment.Lks} DateTime: {appointment.DateTime} Lbo: {appointment.Lbo}");
}

//Console.WriteLine("DateTime: " + System.DateTime.Now);