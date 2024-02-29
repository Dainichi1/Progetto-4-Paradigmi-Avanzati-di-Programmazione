using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Unicam.Progetto4.Application.Models.Responses;

namespace Unicam.Progetto4.Web.Results
{
    public class BadRequestResultFactory : BadRequestObjectResult
    {
        public BadRequestResultFactory(ActionContext context) : base(new BadResponse())
        {
           List<String> retErrors = new List<string>();
            foreach (var key in context.ModelState)
            {
                var errors = key.Value.Errors;
                for(var i = 0; i < errors.Count; i++)
                {
                    retErrors.Add(errors[0].ErrorMessage);
                }
            }

            var response = (BadResponse)Value;
            response.Errors=retErrors;
            
        }

    }
}
