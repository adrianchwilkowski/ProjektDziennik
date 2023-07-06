namespace ProjektDziennik.Models
{
    public class Subject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Mark> Marks { get; set; }
    }
}
