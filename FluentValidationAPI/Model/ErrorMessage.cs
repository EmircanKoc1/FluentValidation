using System.Collections.Generic;

namespace FluentValidationAPI.Model
{
    public class ErrorMessage
    {
        public string PropertyName { get; set; }
        public List<string> ErrorMessages { get; set; }

    }
}
