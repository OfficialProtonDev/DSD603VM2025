using System.ComponentModel.DataAnnotations;

namespace DSD603VM2025.ViewModels
{
    public class StaffNamesVM
    {
        public Guid Id { get; set; }

        [Display(Name = "Staff Name")]
        public string? Name { get; set; }
        public string? Department { get; set; }

        [Display(Name = "Count of Visitors")]
        public int VisitorCount { get; set; }
    }
}
