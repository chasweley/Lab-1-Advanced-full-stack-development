using Labb_1___Avancerad_fullstackutveckling.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Labb_1___Avancerad_fullstackutveckling.Helpers
{
    public class Helper
    {
        public static DateTime DateTimeCleanUp(DateTime dateTime)
        {
            return dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
        }
    }
}
