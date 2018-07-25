using FluentValidation;
using FluentValidation.Validators;
using Library.Domain.DTO.Book;
using System.Text.RegularExpressions;

namespace Library.Bll.Validators.DTO.Book
{
    public class BookRequestDTOValidator : AbstractValidator<BookRequestDTO>
    {
        public BookRequestDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name of book is required!")
                .MinimumLength(5).WithMessage("Book's name must have at least 5 letters!")
                .MaximumLength(60).WithMessage("Book's name can't have more than 60 letters!");

            RuleFor(x => x.Categories).NotEmpty().WithMessage("Book must have at least one category!");

            RuleFor(x => x.Authors).NotEmpty().WithMessage("Book must have at least one author!");

            RuleFor(x => x.Code).Custom(CodeValidation);
        }

        private void CodeValidation(string code, CustomContext context)
        {
            if (string.IsNullOrWhiteSpace(code))
                return;

            var regex = new Regex(@"^[a-zA-Z]{3}\-\d{6}$");

            if (!regex.IsMatch(code))
                context.AddFailure(context.PropertyName, "Book's code must follow pattern: AAA-999999");
        }
    }
}
