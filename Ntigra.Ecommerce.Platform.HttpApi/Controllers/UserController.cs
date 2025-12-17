using Microsoft.AspNetCore.Mvc;
using Ntigra.Ecommerce.Platform.Application.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.HttpApi.Controllers;

[ApiController]
[Route("v1/api/users")]
public sealed class UserController(IUserServiceAppService userServiceAppService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequestDto request)
    {
        var (response, statusCode) = await userServiceAppService.CreateUserAsync(request);
        return StatusCode((int)statusCode, response);
    }
}
