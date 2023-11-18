using FluentValidation.Results;
using FluentValidationAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FluentValidationAPI.Extensions
{
    public static class CustomErrorResponse
    {
        public static IEnumerable<ErrorMessage> ResponseError(this List<ValidationFailure> parameter)
        {
            var errorMessages = new List<Error>();
            parameter.ForEach(x =>
            {
                errorMessages.Add(new Error
                {
                    PropertyName = x.PropertyName,
                    ErrorName = x.ErrorMessage
                });

            });

            var response = errorMessages.GroupBy(x => x.PropertyName).Select(group => new ErrorMessage
            {
                PropertyName = group.Key,
                ErrorMessages = group.Select(error => error.ErrorName).ToList()
            });

            return response;
        }

    }
}
