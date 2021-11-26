using FluentValidation;
using ProjectAlefVinal.Models;

namespace ProjectAlefVinal.Validators
{
    public class CodeModelValidator: AbstractValidator<CodeModel>
    {
        public CodeModelValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Value).NotEmpty().MinimumLength(3).MaximumLength(3);
        }
    }
}
