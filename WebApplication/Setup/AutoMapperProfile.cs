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
            CreateMap<PlayerModel, Player>();
            CreateMap<CreateGameBag, CreateGameEvent>()
                .ForCtorParam("isTest", opt=> opt.MapFrom(src=>src.CreateGameModel.IsTest))
                .ForCtorParam("isDebug", opt=> opt.MapFrom(src=>src.CreateGameModel.IsDebug))
                .ForCtorParam("player", opt=> opt.MapFrom(src=>src.CreateGameModel.Player))
                ;
        }
    }
}