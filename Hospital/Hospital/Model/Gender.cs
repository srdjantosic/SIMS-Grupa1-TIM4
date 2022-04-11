/***********************************************************************
 * Module:  Gender.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Model.Gender
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class Gender
   {
        enum Genders{
            Male,
            Female
        }
        internal static Gender Parse(string v)
        {
            throw new NotImplementedException();
        }

    }
}