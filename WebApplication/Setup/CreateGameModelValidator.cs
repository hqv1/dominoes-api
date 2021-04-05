using FluentValidation;
using Hqv.Dominoes.WebApplication.Models;

namespace Hqv.Dominoes.WebApplication.Setup
{
    public class CreateGameModelValidator : AbstractValidator<CreateGameModel>
    {
        public CreateGameModelValidator()
        {
            RuleFor(x => x.Player).NotNull();
        }    
    }
}