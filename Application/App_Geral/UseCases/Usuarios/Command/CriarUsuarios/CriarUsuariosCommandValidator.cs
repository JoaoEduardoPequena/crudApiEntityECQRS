using FluentValidation;

namespace Application.App_Geral.UseCases.Usuarios.Command.CriarUsuarios
{
    public class CriarUsuariosCommandValidator : AbstractValidator<CriarUsuariosCommand>
    {
        public CriarUsuariosCommandValidator()
        {
            RuleFor(command => command.Email)
           .NotEmpty()
           .NotNull()
           .WithMessage("Obrigatório preencher o campo email.");

            RuleFor(command => command.Usuario)
            .NotEmpty()
            .NotNull()
            .WithMessage("Obrigatório preencher o campo usuário.");

            RuleFor(command => command.FirstName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Obrigatório preencher o campo FirstName.");

            RuleFor(command => command.LastName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Obrigatório preencher o campo LastName.");
            
        }
    }
}
