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
    public class UserController : Controller
    {

        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }




        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {

            if (ModelState.IsValid)
            {

                var dbuser = _context.Users.FirstOrDefault(m => m.UserName.Equals(user.UserName) && m.PassWord.Equals(user.PassWord));

                if (dbuser != null)
                {
                    return Json(dbuser);
                }


            }
            return View(user);


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
            // [HttpGet]
            // public async Task<ActionResult<IEnumerable<User>>> GetUsers()
            // {
            //     return await _context.Users.ToListAsync();
            // }

            // // GET: api/User/5
            // [HttpGet("{id}")]
            // public async Task<ActionResult<User>> GetUser(int id)
            // {
            //     var user = await _context.Users.FindAsync(id);
            //     string fileUrl = Path.GetFileName(user.Image);
            //     var path = Directory.GetCurrentDirectory();
            //     path = path.Replace("\\", "/");
            //     FileStream fs = new FileStream(path + @"\wwwroot\Image\" + fileUrl, FileMode.Open, FileAccess.Read);
            //     byte[] buffer = new byte[fs.Length];
            //     fs.Read(buffer, 0, (int)fs.Length);
            //     if (user == null)
            //     {
            //         return NotFound();
            //     }

            //     return user;
            // }

            // PUT: api/User/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            // [HttpPut("{id}")]
            // public async Task<IActionResult> PutUser(int id, User user)
            // {
            //     if (id != user.Id)
            //     {
            //         return BadRequest();
            //     }

            //     _context.Entry(user).State = EntityState.Modified;

            //     try
            //     {
            //         await _context.SaveChangesAsync();
            //     }
            //     catch (DbUpdateConcurrencyException)
            //     {
            //         if (!UserExists(id))
            //         {
            //             return NotFound();
            //         }
            //         else
            //         {
            //             throw;
            //         }
            //     }

            //     return NoContent();
            // }

            // POST: api/User
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754





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
        //  [HttpPost]
        // public async Task<ActionResult<User>> PostRegister(Register register)
        // {

        //     RegisterResult i=new RegisterResult();
        //     User user = new User();
        //     user.UserName = register.UserName;
        //     user.PassWord = register.PassWord;
        //     user.CpassWord = register.CpassWord;
        //     if (user != null)
        //     {

        //         _context.Users.Add(user);
        //         await _context.SaveChangesAsync();
        //        return View();
        //     }

        //     return View(user);

        // }

        // // DELETE: api/User/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteUser(int id)
        // {
        //     var user = await _context.Users.FindAsync(id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Users.Remove(user);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool UserExists(int id)
        // {
        //     return _context.Users.Any(e => e.Id == id);
        // }
    }
}
