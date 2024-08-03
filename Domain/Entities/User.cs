using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser<long>
    {
        public required string FullName { get; set; }
        public DateOnly? BirthDate { get; set; }
    }
}
