/***********************************************************************
 * Module:  TipProstorije.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class TipProstorije
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class RoomType
   {
        public RoomTypes Type { get; set; }


        public RoomType(RoomTypes types)
        {
            Type = types;
        }
        public enum RoomTypes
        {
            OperationRoom,
            ExaminationRoom,
            MeetingRoom
        }

        internal static RoomType Parse(string v)
        {
            if (v.Equals("MeetingRoom"))
            {
                return new RoomType(RoomTypes.MeetingRoom);
            }else if (v.Equals("ExaminatingRoom"))
            {
                return new RoomType(RoomTypes.ExaminationRoom);
            }
          
          return new RoomType(RoomTypes.OperationRoom);
          
        }
    }
}