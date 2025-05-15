namespace DSD603VM2025.MappingProfile
{
    using AutoMapper;
    using DSD603VM2025.Models;
    using DSD603VM2025.ViewModels;

    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Visitors, VisitorsVM>().ReverseMap();
            CreateMap<StaffNames, StaffNamesVM>().ReverseMap();
        }
    }
}
