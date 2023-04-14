using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektDziennik.Models
{
    public class Mark
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public int Value { get; set; }
        public string? StudentId { get; set; }
        public User Student { get; set; }
        public string? TeacherId { get; set; }
        public User Teacher { get; set; }
    }
}