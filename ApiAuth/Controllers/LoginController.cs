using ApiAuth.Models;
using ApiAuth.Repository;
using ApiAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers;

[ApiController]
[Route("v1")]
public class LoginController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody]User model)
    {
        var user = UserRepository.Get(model.UserName,model.Password);

        if (user == null)
            return NotFound(new { message = "Usuário ou senha inválido!"});

        var token = TokenService.GenerateToken(user);

        user.Password = string.Empty;

        return new { user = user, token = token};
    }

    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anônimo";

    [HttpGet]
    [Route("authenticated")]
    [Authorize]
    public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "employee,manager")]
    public string Employee() => "Funcionário";

    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = "manager")]
    public string Manager() => "Gerente";
}
