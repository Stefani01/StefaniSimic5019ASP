using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Project.DataAccess;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Project.Api.Core
{
    public class JwtManager
    {
        private readonly ProjectDbContext _context;
        //private readonly JwtSettings _jwtSettings;

        public JwtManager(ProjectDbContext context/*, JwtSettings jwtSettings*/)
        {
            _context = context;
           // _jwtSettings = jwtSettings;
        }

        public string MakeToken(string username, string password)
        {
            var user = _context.Users.Include(x => x.UseCases).FirstOrDefault(x => x.Username == username);

            if(user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var validPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (!validPassword)
            {
                throw new UnauthorizedAccessException();
            }

            var actor = new JwtUser
            {
                ID = user.Id,
                UseCaseIDs = user.UseCases.Where(x=>x.IsActive).Select(x=>x.UseCaseID).ToList(),
                Identity = user.Username,
                Email = user.Email
            };

            var _jwtIssuer = "AlbumProject";
            var _secretKey = "123asdhnjckfna0123";
            var _minutes = 30;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _jwtIssuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _jwtIssuer),
                new Claim("UserID", actor.ID.ToString(), ClaimValueTypes.String,_jwtIssuer),
               new Claim("UseCases", JsonConvert.SerializeObject(actor.UseCaseIDs)),
                new Claim("Email", user.Email),
                 new Claim("Identity", user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _jwtIssuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_minutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
