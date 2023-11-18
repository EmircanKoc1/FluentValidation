using FluentValidation;
using FluentValidationMVC.Models;

namespace FluentValidationMVC.Validators
{
    public class ProductValidator : AbstractValidator<Product>, IProductValidator
    {
        public ProductValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email Boş olamaz");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Lütfen geçerli bir mail adresi girin");


            RuleFor(x => x.ProductName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Lütfen ürün adı girin");

            RuleFor(x => x.ProductName)
                .MaximumLength(100)
                .WithMessage("Lütfen 100 karakterden az giriniz");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .NotNull()
                .WithMessage("Miktarı girin");

        }


    }
}
