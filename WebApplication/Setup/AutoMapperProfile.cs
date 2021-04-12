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
            CreateMap<CreateGameBag, CreateGameEvent>()
                .ForCtorParam("isTest", opt=> opt.MapFrom(src=>src.CreateGameModel.IsTest))
                .ForCtorParam("isDebug", opt=> opt.MapFrom(src=>src.CreateGameModel.IsDebug))
                .ForCtorParam("player", opt=> opt.MapFrom(src=>src.CreateGameModel.Player))
                ;
        }
    }
}