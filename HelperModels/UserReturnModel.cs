using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Security.Claims;

namespace keepr.Models
{
    public class UserReturnModel
    {
        [Required]        public int Id { get; set; }
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        internal ClaimsPrincipal SetClaims()
        {
            var claims = new List<Claim> {
                        new Claim(ClaimTypes.Email, Email),
                        new Claim(ClaimTypes.Name, Id.ToString())
                    };
            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            return principal;
        }
    }
}