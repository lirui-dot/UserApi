using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        // [HttpPost]

        // public IActionResult Index(User user)
        // {

        //     var dbuser = _context.Users.FirstOrDefault(m => m.UserName.Equals(user.UserName) && m.PassWord.Equals(user.PassWord));

        //     if (dbuser != null)
        //     {
        //         return RedirectToAction("Details", "Personal", new { id = dbuser.Id });
        //     }
        //         return View(user);
        // }



        // GET: api/User

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Register>> PostRegister(Register register)
        {
            
            RegisterResult i=new RegisterResult();
            User user = new User();
            user.UserName = register.UserName;
            user.PassWord = register.PassWord;
            user.CpassWord = register.CpassWord;
            if (user != null)
            {
                 
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
               return View();
            }

            return View(user);

        }
            // byte[] bytes = Convert.FromBase64String(user.Image);
            // var path = Directory.GetCurrentDirectory();
            // string fileUrl = Guid.NewGuid().ToString() + ".png";
            // string url = path + @"\wwwroot\Image\" + fileUrl;

            // System.IO.File.WriteAllBytes(url, bytes);



            // string urlPath = url.Replace(path, "");  //转换成相对路径

            // user.Image = urlPath;

            // if (ModelState.IsValid)
            // {
            //     _context.Update(user);
            //     await _context.SaveChangesAsync();
            //     return user;
            // }



        }
}
