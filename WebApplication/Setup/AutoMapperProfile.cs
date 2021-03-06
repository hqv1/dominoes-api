using AutoMapper;
using Hqv.Dominoes.Shared.Events.Common;
using Hqv.Dominoes.Shared.Events.Game;
using Hqv.Dominoes.WebApplication.Models;

namespace Hqv.Dominoes.WebApplication.Setup
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PlayerModel, GamePlayer>();
            CreateMap<CreateGameBag, CreateGameEvent>()
                .ForCtorParam("isTest", opt=> opt.MapFrom(src=>src.CreateGameModel.IsTest))
                .ForCtorParam("isDebug", opt=> opt.MapFrom(src=>src.CreateGameModel.IsDebug))
                .ForCtorParam("gamePlayer", opt=> opt.MapFrom(src=>src.CreateGameModel.Player))
                ;
        }
    }
}