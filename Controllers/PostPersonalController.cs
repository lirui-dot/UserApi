using System;
using System.IO;
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
    public class PostPersonalController : Controller
    {

        private readonly UserContext _context;

        public PostPersonalController(UserContext context)
        {
            _context = context;
        }
        [HttpPost]
        
        public async Task<ActionResult> Edit(User user,int id)
        {
            var user1=_context.Users.Find(id);
            user1.UserName=user.UserName;
            user1.PassWord=user.PassWord;
            user1.Gender=user.Gender;
            user1.Age=user.Age;
            user1.Province=user.Province;
            user1.City=user.City;
            user1.Image=user.Image;
            user1.Url=user.Url;

            string phones = user.Image.Replace("data:image/png;base64,", "");
            byte[] bytes = Convert.FromBase64String(phones);
            var path = Directory.GetCurrentDirectory();
            string fileUrl = Guid.NewGuid().ToString() + ".png";
            string url = path + @"\wwwroot\Image\" + fileUrl;

            System.IO.File.WriteAllBytes(url, bytes);
            string urlPath = url.Replace(path, "");  //转换成相对路径

            user1.Image = urlPath;

            if (ModelState.IsValid)
            {
                _context.Update(user1);
                await _context.SaveChangesAsync();
                return Json(user1);
            }
            return Json(user);
        }
    }
}



