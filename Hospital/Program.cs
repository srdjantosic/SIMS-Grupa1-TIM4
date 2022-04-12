
using Hospital.Contoller;
using Hospital.Service;
using Hospital.Repository;
using Hospital.Model;

RoomRepository roomRepository = new RoomRepository();
RoomService roomService = new RoomService(roomRepository);
RoomController roomController = new RoomController(roomService);


//Prikaz svih soba
foreach(Room room in roomController.ShowRooms()){
    Console.WriteLine($"Name:{ room.Name} Room Type: {room.Type} Is deleted: {room.IsDeleted}");
}
    
