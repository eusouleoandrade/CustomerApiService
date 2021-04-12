using CustomerApiWithService.Application.DTOs.Common;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CustomerApiWithService.App.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected Response GetModelStateErrorsResponse()
        {
            return new Response(ModelState.IsValid, ModelState.Values.SelectMany(sm => sm.Errors).Select(s => s.ErrorMessage).ToList());
        }
    }
}
