namespace api.Controllers;

using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using AutoMapper;
using api.Dto;
using Microsoft.Extensions.Options;
using api.Settings;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;
    private readonly PaginationSettings _paginationSettings;

    public UserController(IUserService service, ILogger<UserController> logger, IMapper mapper, IOptions<PaginationSettings> paginationSettings)
    {
        _service = service;
        _logger = logger;
        _mapper = mapper;
        _paginationSettings = paginationSettings.Value;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers([FromQuery] int prev = 0, [FromQuery] int? perPage = null)
    {
        perPage ??= _paginationSettings.DefaultPerPage;
        var result = await _service.GetUsers(prev, (int)perPage);
        var users = _mapper.Map<IEnumerable<UserDto>>(result);

        return users.Count() > 0 ? Ok(users) : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var result = await _service.GetUserById(id);
        var user = _mapper.Map<UserDto>(result);
        return user != null ? Ok(user) : NotFound();
    }
    [HttpDelete]
    public async Task<ActionResult> DeleteUserById(int id)
    {
        var userToDelete = await _service.GetUserById(id);
        if (userToDelete == null)
        {
            return NotFound();
        }
        await _service.DeleteUserById(id);
        return Ok();

    }
}