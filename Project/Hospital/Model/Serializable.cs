namespace Project.Hospital.Model
{
    public interface Serializable
    {
        public string[] toCSV();
        public void fromCSV(string[] values);
    }
}