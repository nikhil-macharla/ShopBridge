using AutoMapper;
using ShopBridge.Contracts.Request;
using ShopBridge.Services.Core.Models;

namespace ShopBridge.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginDto, UserLogin>();
        }
    }
}
