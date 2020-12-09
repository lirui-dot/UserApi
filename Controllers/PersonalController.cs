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
    public class PersonalController : Controller
    {

        private readonly UserContext _context;

        public PersonalController(UserContext context)
        {
            _context = context;
        }
        // GET: api/User
        public async Task<IActionResult> Edit(int? id)
        {
            UserPageModel usermodel = new UserPageModel();
            if (id == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            usermodel.Id = user.Id;
            usermodel.UserName = user.UserName;
            usermodel.PassWord = user.PassWord;
            usermodel.Gender = user.Gender;
            usermodel.Age = user.Age;
            usermodel.Provinces = user.Provinces;
            usermodel.City = user.City;
            string fileUrl = Path.GetFileName(user.Image);
            var path = Directory.GetCurrentDirectory();
            if (user.Image != null)
            {
                FileStream fs = new FileStream(path + @"\wwwroot\Image\" + fileUrl, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);

                usermodel.FileUrl = "data:image/png;base64," + Convert.ToBase64String(buffer);
            }

            usermodel.Url = user.Url;
            if (user == null)
            {
                return NotFound();
            }

            return Json(usermodel);
        }

        //POST: api/User
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult> PostPersonal(int id,UserPageModel usermodel)
        // {

        //       return View();
        // }
    }
}

