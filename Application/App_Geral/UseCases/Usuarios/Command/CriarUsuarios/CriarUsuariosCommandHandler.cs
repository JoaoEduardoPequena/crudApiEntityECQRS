using Domain.Interfaces;
using MediatR;
using Domain.Entities;
using Mapster;
using FluentValidation;
using FluentValidation.TestHelper;

namespace Application.App_Geral.UseCases.Usuarios.Command.CriarUsuarios
{
    public class CriarUsuariosCommandHandler : IRequestHandler<CriarUsuariosCommand, bool>
    {
        private readonly IUsuarios _Iusuarios;
        private readonly IValidator<CriarUsuariosCommand> _validator;
        public CriarUsuariosCommandHandler(IUsuarios Iusuarios, IValidator<CriarUsuariosCommand> validator)
        {
            _Iusuarios = Iusuarios;
            _validator = validator;
        }
        public async Task<bool> Handle(CriarUsuariosCommand request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationUser();
            dto.Email = request.Email;
            dto.UserName = request.Usuario;
            //dto.PasswordHash = request.Password;
            dto.IsActivo = true;
            dto.EmailConfirmed = true;
            dto.FirstName= request.FirstName;
            dto.LastName = request.LastName;
            var result1 = await _validator.ValidateAsync(request);
            var result=await _Iusuarios.CriarUsuario(dto,request.Password);
            return result;
        }
    }
}
