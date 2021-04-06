using AutoMapper;
using Hqv.Dominoes.WebApplication.Events;
using Hqv.Dominoes.WebApplication.Models;

namespace Hqv.Dominoes.WebApplication.Setup
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PlayerModel, Player>();
            CreateMap<CreateGameModel, CreateGameEvent>();
        }
    }
}