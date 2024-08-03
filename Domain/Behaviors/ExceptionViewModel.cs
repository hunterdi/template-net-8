using Microsoft.AspNetCore.Mvc;

namespace Domain.Behaviors
{
    public class ExceptionViewModel : ProblemDetails
    {
        public IReadOnlyList<string>? Errors { get; set; }
        public override string ToString()
        {
            return $"STATUS:{Status},TITLE:{Title},ERRORS:{Errors?.ToString()},DETAIL:{Detail},INSTANCE:{Instance},TYPE:{Type}";
        }
    }
}
