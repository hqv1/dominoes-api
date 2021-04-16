using System.Threading.Tasks;
using Confluent.Kafka;
using Hqv.Dominoes.Shared.Events.Game;
using Hqv.Dominoes.WebApplication.Setup;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Hqv.Dominoes.WebApplication.Components
{
    /**
     * Kafka Producer. We are not using Schema Registry because there isn't support for ARM64. Therefore, we're not
     * using the JSON Serializer that comes with Schema Registry. This also means we're serializing the event to
     * a string ourself. Not very efficient but it'll work for now.
     *
     * For information at https://docs.confluent.io/clients-confluent-kafka-dotnet/current/overview.html
     */
    public class KafkaPublisher : IPublisher
    {
        private readonly ILogger<KafkaPublisher> _logger;
        private readonly KafkaProducerOptions _kafkaProducerOptions;
        private readonly ProducerBuilder<string, string> _producerBuilder;

        public KafkaPublisher(IOptions<KafkaProducerOptions> options, ILogger<KafkaPublisher> logger)
        {
            _logger = logger;
            _kafkaProducerOptions = options.Value;
            _kafkaProducerOptions.Validate();
            
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = _kafkaProducerOptions.BootstrapServers,
                ClientId = _kafkaProducerOptions.ClientId
            };
            
            _producerBuilder = new ProducerBuilder<string, string>(producerConfig);
        }
        
        public async Task Publish(CreateGameEvent createGameEvent)
        {
            using var producer = _producerBuilder.Build();

            // Not the best way to implement this but good enough for now. See the confluent link for the reason why.
            var result = await producer.ProduceAsync(_kafkaProducerOptions.TopicName, new Message<string, string>()
            {
                Key = createGameEvent.CorrelationId,
                Value = JsonConvert.SerializeObject(createGameEvent)
            });
            
            _logger.LogInformation("CreateGame Event published to {partition}:{offset}", 
                result.Partition.Value, result.Offset.Value);
        }
    }
}