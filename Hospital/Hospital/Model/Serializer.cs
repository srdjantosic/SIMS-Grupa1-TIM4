// File:    Serializer.cs
// Author:  Windows 10
// Created: Friday, April 1, 2022 5:55:49 PM
// Purpose: Definition of Class Serializer

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hospital.Model
{
  /* public class Serializer
   {
      public void ToCSV(string fileName, List<T:Serializable> objects)
      {
         // TODO: implement
      }
      
      public List<T:Serializable> FromCSV(string filename)
      {
         // TODO: implement
         return null;
      }
   
      private char DELIMITER = '|';
   
   }

    public class List<T1, T2>
    {
    }*/
    class Serializer<T> where T : Serializable, new()
    {
        private static char DELIMITER = '|';
        public void toCSV(string fileName, List<T> objects)
        {
            using StreamWriter streamWriter = new StreamWriter(fileName);

            foreach (Serializable obj in objects)
            {
                string line = string.Join(DELIMITER, obj.toCSV());
                streamWriter.WriteLine(line);
            }
        }

        public List<T> fromCSV(string fileName)
        {
            List<T> objects = new List<T>();

            foreach (string line in File.ReadLines(fileName))
            {
                string[] csvValues = line.Split(DELIMITER);
                T obj = new T();
                obj.fromCSV(csvValues);
                objects.Add(obj);
            }

            return objects;
        }
    }
}