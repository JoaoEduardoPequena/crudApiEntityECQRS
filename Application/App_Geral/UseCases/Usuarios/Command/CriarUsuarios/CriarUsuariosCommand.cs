using MediatR;

namespace Application.App_Geral.UseCases.Usuarios.Command.CriarUsuarios
{
    public record CriarUsuariosCommand() : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActivo { get; set; }=true;
    }
}
