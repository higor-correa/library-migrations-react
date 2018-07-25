using FluentValidation;
using FluentValidation.Validators;
using Library.Domain.DTO.Author;
using System.Text.RegularExpressions;

namespace Library.Bll.Validators.DTO.Author
{
    public class AuthorRequestDTOValidator : AbstractValidator<AuthorRequestDTO>
    {
        public AuthorRequestDTOValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Author's first name is required!")
                .MinimumLength(3).WithMessage("Author's first name must have at least 3 letters!")
                .MaximumLength(60).WithMessage("Author's first name can't have more than 60 letters!");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Author's last name is required!")
                .MinimumLength(3).WithMessage("Author's last name must have at least 3 letters!")
                .MaximumLength(60).WithMessage("Author's last name can't have more than 60 letters!");

            RuleFor(x => x.Code).NotEmpty().WithMessage("Code of author is required!")
                .Custom(CodeValidation);
        }

        private void CodeValidation(string code, CustomContext context)
        {
            var regex = new Regex(@"^[a-zA-Z]{3}\-\d{6}$");

            if (!regex.IsMatch(code))
                context.AddFailure(context.PropertyName, "Author's code must follow pattern: AAA-999999");
        }
    }
}
