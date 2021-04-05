using FluentValidation;

namespace Hqv.Dominoes.WebApplication.Setup
{
    public class KafkaProducerOptions
    {
        public const string ConfigurationName = "KafkaProducer";
        
        public string? BootstrapServers { get; set; }
        public string? ClientId { get; set; }
        public string? TopicName { get; set; }
        
        public void Validate()
        {
            new KafkaProducerOptionValidator().Validate(this);
        }
        
        private class KafkaProducerOptionValidator : AbstractValidator<KafkaProducerOptions>
        {
            public KafkaProducerOptionValidator()
            {
                RuleFor(x => x.BootstrapServers).NotEmpty();
                RuleFor(x => x.ClientId).NotEmpty();
                RuleFor(x => x.TopicName).NotEmpty();
            }
        }
    }
}