namespace MappingValidation.Models.Commands
{
    public record SignInRequestCommand
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
