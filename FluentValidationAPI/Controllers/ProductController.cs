using FluentValidation;
using FluentValidationAPI.Extensions;
using FluentValidationAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FluentValidationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IValidator<Product> _validator;

        public ProductController(IValidator<Product> validator)
        {
            _validator = validator;
        }
        [HttpPost("[action]")]
        public IActionResult AddProduct(Product product)
        {
            var result = _validator.Validate(product);

            return Ok(result.Errors.ResponseError());
        }
        [HttpPost("[action]")]
        public IActionResult AddProduct2(Product product)
        {
            var result = _validator.Validate(product);
            result.Errors.ForEach(x =>
            {
                ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
            });
            return Ok(ModelState);
        }
        [HttpPost("[action]")]
        public IActionResult AddProduct3(Product product)
        {
            var result = _validator.Validate(product);

            result.Errors.ForEach(x =>
            {
                ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
            });


            return Ok(ModelState.Select(x => new ErrorMessage
            {
                PropertyName = x.Key,
                ErrorMessages = x.Value.Errors.Select(x => x.ErrorMessage).ToList()
            }));
        }


    }
}
