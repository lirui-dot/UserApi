using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MvcUser.Models;
using UserApi.Models;

namespace UserApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {

        private readonly UserContext _context;

        public RegisterController(UserContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<Register>> PostRegister(Register register)
        {
            User user = new User();
            var yhm = _context.Users.SingleOrDefault(m => m.UserName == register.UserName);
            if (yhm == null)
            {
                user.UserName = register.UserName;
                user.PassWord = register.PassWord;
                user.CpassWord = register.CpassWord;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Json(user);
            }

            return Json(user);

        }
    }
}
