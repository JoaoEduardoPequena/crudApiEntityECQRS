namespace Domain.Models.DTOS.Usuario
{
    public class RegistarDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActivo { get; set; }
    }
}
