using AutoMapper;
using FluentAssertions;
using Hqv.Dominoes.WebApplication.Events;
using Hqv.Dominoes.WebApplication.Setup;
using Hqv.Dominoes.WebApplication.Test.Generator;
using Xunit;

namespace Hqv.Dominoes.WebApplication.Test
{
    public class MappingTest
    {
        private readonly TestDataCreator _testDataCreator;

        public MappingTest()
        {
            _testDataCreator = new TestDataCreator();
        }

        [Fact]
        public void ShouldMapToCreateGameEvent()
        {
            // Given a Create Game Model
            var inputCreateGameModel = _testDataCreator.GenerateCreateGameModel();

            // Given a mapper
            var mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfile>())
                .CreateMapper();
            
            // When mapper is used
            var actualCreateGameEvent = mapper.Map<CreateGameEvent>(inputCreateGameModel);
            
            // Then a Create Game Event is created
            var inputPlayer = inputCreateGameModel.Player;
            var actualPlayer = actualCreateGameEvent.Player;
            //actualPlayer.Id.Should().BeSameAs(inputPlayer?.Id);
        }
    }
}