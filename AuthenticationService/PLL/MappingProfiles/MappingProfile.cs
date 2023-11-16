using AuthenticationService.BLL.Models;
using AuthenticationService.Models;
using AutoMapper;

namespace AuthenticationService.PLL.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ConstructUsing(v => new UserViewModel(v));
        }
    }
}
