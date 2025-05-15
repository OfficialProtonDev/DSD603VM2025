using System.ComponentModel.DataAnnotations;

namespace DSD603VM2025.Models
{
    public class Visitors
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Business { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public Guid StaffNameId { get; set; }
        public StaffNames? StaffName { get; set; }
    }
}
