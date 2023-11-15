using AuthenticationService.Models;
using AuthenticationService.Models.Db;
using AutoMapper;

namespace AuthenticationService
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ConstructUsing(v => new UserViewModel(v));
        }
    }
}
