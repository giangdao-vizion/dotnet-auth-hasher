using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AuthApi.Dtos;
using AuthApi.Models;
// using AuthApi.Services;

namespace AuthApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    // private readonly AuthService _authService;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthController(
        ILogger<AuthController> logger,
        // AuthService authService,
        IPasswordHasher<User> passwordHasher
    )
    {
        _logger = logger;
        // _authService = authService;
        _passwordHasher = passwordHasher;
    }

    private bool IsPasswordValid(string password, string hashPassword)
    {
        var result = _passwordHasher.VerifyHashedPassword(null, hashPassword, password);

        _logger.LogInformation(result.ToString());

        return result != PasswordVerificationResult.Failed;
    }

    [HttpPost(Name = "AuthUser")]
    public bool Post(AuthDto req)
    {
        try
        {
            if (req == null) return false;
            if (string.IsNullOrEmpty(req.Password) || string.IsNullOrEmpty(req.HashPassword)) return false;

            _logger.LogInformation(req.Password);
            _logger.LogInformation(req.HashPassword);

            // _authService.Connect(req.IsProd);

            // var user = await _authService.GetByEmailAsync(req.Email);

            // // not found
            // if (user == null) return false;

            var result = IsPasswordValid(req.Password, req.HashPassword);
            _logger.LogInformation(result.ToString());

            return result;
        }
        catch (System.Exception ex)
        {
            _logger.LogWarning(ex.Message, ex);

            return false;
        }
    }
}
