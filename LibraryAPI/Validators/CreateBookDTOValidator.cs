using FluentValidation;
using LibraryAPI.Entities.DTOs.Book;

namespace LibraryAPI.Validators
{
    public class CreateBookDTOValidator : AbstractValidator<CreateBookDTO>
    {
        public CreateBookDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Author).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ISBN).NotEmpty().MaximumLength(20);
            RuleFor(x => x.StatuId).NotEmpty();
        }
    }
}