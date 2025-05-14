using System.ComponentModel.DataAnnotations;

namespace DSD603VM2025.Models
{
    public class Visitors
    {
        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        public string? Business { get; set; }

        [Display(Name = "Visitor Date In")]
        public DateTime DateIn { get; set; }

        [Display(Name = "Visitor Date Out")]
        public DateTime? DateOut { get; set; }

        [Display(Name = "Staff Member Visited")]
        public Guid StaffNameId { get; set; }

        [Display(Name = "Staff Member Visited")]
        public StaffNames? StaffName { get; set; }
    }
}
