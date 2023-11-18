using FluentValidation;
using FluentValidationMVC.Models;
using FluentValidationMVC.Validators;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductValidator _productValidator;

        public ProductController(IProductValidator productValidator)
        {
            _productValidator = productValidator;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {

                var result = _productValidator.Validate(product);

                var errors = result.Errors;

                errors.ForEach(error =>
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                });


                return View("Index", product);

            }
            return RedirectToAction("Index");

        }

    }
}
