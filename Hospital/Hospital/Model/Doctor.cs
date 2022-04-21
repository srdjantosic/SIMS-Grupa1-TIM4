namespace Hospital.Model
{
    public class Doctor : Serializable
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public MedicineArea.MedicineAreas _MedicineArea { get; set; }
        public String Lks { get; set; }

        public Doctor () { }

        public Doctor(String FirstName, String LastName, String Email, String PhoneNumber, MedicineArea.MedicineAreas _MedicineArea, String Lks)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this._MedicineArea = _MedicineArea;
            this.Lks = Lks;
        }

        public void fromCSV(string[] values)
        {
            FirstName = values[0];
            LastName = values[1];
            Email = values[2];
            PhoneNumber = values[3];
            _MedicineArea = (MedicineArea.MedicineAreas)Enum.Parse(typeof(MedicineArea.MedicineAreas), values[4]);
            Lks = values[5];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                FirstName,
                LastName,
                Email,
                PhoneNumber,
                _MedicineArea.ToString(),
                Lks
            };
            return csvValues;
        }

    }
}