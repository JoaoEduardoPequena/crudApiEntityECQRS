using FluentValidation.Results;

namespace Application.App_Shared.Exceptions
{
    public class ValidationExceptions: Exception
    {
        public List<string> Errors { get; }
        public ValidationExceptions() 
        {
            Errors = new List<string>();
        }
        public ValidationExceptions(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

    }
}
