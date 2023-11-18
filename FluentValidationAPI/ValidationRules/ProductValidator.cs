using FluentValidation;
using FluentValidationAPI.Model;

namespace FluentValidationAPI.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Price alanı boş olamaz")
                .GreaterThan(0)
                .WithMessage("Price 0 dan büyük olmalıdır");

            RuleFor(x => x.Quantity)
                .NotNull()
                .NotEmpty()
                .WithMessage("Quantity boş olamaz");

            RuleFor(x => x.ProductName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Product Name  boş olamaz")
                .MinimumLength(3)
                .WithMessage("Product Name en az 3 karakterden oluşmalıdır")
                .MaximumLength(20)
                .WithMessage("Product Name en fazla 20 karakterden oluşmalıdır");



        }
    }
}
