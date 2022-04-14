namespace Hospital.Model
{

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

        public void oneToCSV(string fileName, T obj)
        {
            string line = string.Join(DELIMITER, obj.toCSV());
<<<<<<< HEAD
            File.AppendAllText(fileName, line+Environment.NewLine);

=======
         
            File.AppendAllText(fileName, line+Environment.NewLine);
>>>>>>> dd9f4fac733eb55b01dde56b96ce1c428b909399
        }
    }
}