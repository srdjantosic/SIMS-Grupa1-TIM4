/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;
using System;

namespace Hospital.Contoller
{
   public class RoomController
   {
        private RoomService roomService;

       

        public RoomController (RoomService roomService)
        {
            this.roomService = roomService;
        }
     /* public Boolean CreateRoom(String name, RoomType type)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean UpdateRoom(String name, String newName, RoomType newType)
      {
         // TODO: implement
         return null;
      }*/
      
      public List<Room> ShowRooms()
      {
         return roomService.ShowRooms();
      }
      
     /* public Boolean DeleteRoom(String name)
      {
         // TODO: implement
         return null;
      }
      
      public Room GetRoom(String name)
      {
         // TODO: implement
         return null;
      }*/
   
   }
}