// File:    Serializable.cs
// Author:  Windows 10
// Created: Friday, April 1, 2022 6:01:03 PM
// Purpose: Definition of Interface Serializable

namespace Project.Hospital.Model
{
    public interface Serializable
    {
        public string[] toCSV();
        public void fromCSV(string[] values);
    }
}