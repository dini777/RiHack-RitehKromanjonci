using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RiHack_RitehKromanjonci.Data;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;

namespace RiHack_RitehKromanjonci.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;


        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        [EmailAddress(ErrorMessage = "Neispravan email.")]
        [Required(ErrorMessage = "Potrebno je upisati email.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Potrebno je upisati lozinku.")]
        public string Password { get; set; }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var loggedUser = _context.Users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();

            if (loggedUser is null)
            {
                return Page();
            }

            //cookies
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Email),
            };

            claims.Add(new Claim(ClaimTypes.Role, "User"));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true // Remember user across sessions
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            await _context.SaveChangesAsync();


            // redirectati korisnika na drugi page gdje moze upisati taj access code
            return Redirect("./");
        }
    }
}
