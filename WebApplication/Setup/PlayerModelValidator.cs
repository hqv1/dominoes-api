using FluentValidation;
using Hqv.Dominoes.WebApplication.Models;

namespace Hqv.Dominoes.WebApplication.Setup
{
    public class PlayerModelValidator : AbstractValidator<PlayerModel>
    {
        public PlayerModelValidator()
        {
            RuleFor(x => x.EmailAddress).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}