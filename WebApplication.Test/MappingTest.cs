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
            var inputCreateGameBag = _testDataCreator.GenerateCreateGameBag();

            // Given a mapper
            var mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfile>())
                .CreateMapper();

            // When mapper is used
            var actualCreateGameEvent = mapper.Map<CreateGameEvent>(inputCreateGameBag);
            
            // Then a Create Game Event is created
            // And some values are mapped
            var inputPlayer = inputCreateGameBag.CreateGameModel.Player;
            var actualPlayer = actualCreateGameEvent.Player;
            actualCreateGameEvent.CorrelationId.Should().BeSameAs(inputCreateGameBag.CorrelationId);
            actualCreateGameEvent.IsTest.Should().Be(inputCreateGameBag.CreateGameModel.IsTest);
            actualPlayer.Id.Should().BeSameAs(inputPlayer?.Id);
        }
    }
}