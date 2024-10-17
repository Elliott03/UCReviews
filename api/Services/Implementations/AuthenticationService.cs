namespace api.Services.Implementations;

using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;

public class AuthenticationService : IAuthenticationService
{
    IUserService _userService;
    IMailService _mailService;
    IConfiguration _configuration;
    ILogger<AuthenticationService> _logger;
    public AuthenticationService(IUserService userService, IMailService mailService, IConfiguration configuration, ILogger<AuthenticationService> logger)
    {
        _userService = userService;
        _mailService = mailService;
        _configuration = configuration;
        _logger = logger;
    }
    public async Task RegisterUser(string email)
    {
        // Generate random 6 character numeric password
        Random random = new Random();
        string unHashedPassword = "";
        for (int i = 0; i < 6; i++)
        {
            unHashedPassword += random.Next(10).ToString();
        }
        _mailService.SendMail(email, unHashedPassword);
        // Hash and salt the password
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
        string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: unHashedPassword!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8
        ));
        await _userService.AddUser(email, hashedPassword, salt);
    }
    public async Task<User> GetAuthenticatedUser(string email, string password)
    {
        var user = await _userService.GetUserByEmail(email);
        if (user != null)
        {
            if (user.PasswordExpiration < DateTime.Now)
                return null;
            byte[] storedSalt = user.Salt;
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: storedSalt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8
            ));
            if (user.Password.Equals(hashedPassword))
                return user;
        }

        return null;
    }

    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", user.Id.ToString()));
        claimsForToken.Add(new Claim("email", user.Email));

        var jwtSecurityToken = new JwtSecurityToken(
            _configuration["Authentication:Issuer"],
            _configuration["Authentication:Audience"],
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            signingCredentials
        );

        var tokenToReturn = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToken);
        return tokenToReturn;
    }


    public bool IsJwtValid(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]);
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidIssuer = _configuration["Authentication:Issuer"],
            ValidateAudience = true,
            ValidAudience = _configuration["Authentication:Audience"],
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero // Set to zero to validate the token against the expiration time exactly
        };

        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out _);
            return true;
        }
        catch (SecurityTokenException)
        {
            return false;
        }
    }

}