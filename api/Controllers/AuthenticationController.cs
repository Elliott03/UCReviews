using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api.Controllers;

#nullable enable

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    IAuthenticationService _service;
    ILogger<AuthenticationController> _logger;
    public AuthenticationController(IAuthenticationService service, ILogger<AuthenticationController> logger)
    {
        _service = service;
        _logger = logger;
    }
    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterRequestBody registerBodyRequest)
    {
        await _service.RegisterUser(registerBodyRequest.Email);
        return Ok();
    }
    [HttpPost("authenticate")]
    public async Task<ActionResult<AuthenticationResponse>> Authenticate(AuthenticationRequestBody authenticationRequestBody)
    {
        var user = await _service.GetAuthenticatedUser(authenticationRequestBody.Email, authenticationRequestBody.Password);

        if (user == null)
            return Unauthorized();

        string jwt = _service.GenerateToken(user);
        var response = new AuthenticationResponse();
        response.jwt = jwt;
        return Ok(response);
    }

    public class AuthenticationRequestBody
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
    public class RegisterRequestBody
    {
        public string? Email { get; set; }
    }
    public class AuthenticationResponse
    {
        public string jwt { get; set; } = "{}";
    }
}
