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
        public async Task<ActionResult> Edit(User user, int id)
        {
            
            string phones = user.Image.Replace("data:image/png;base64,", "");
            byte[] bytes = Convert.FromBase64String(phones);
            var path = Directory.GetCurrentDirectory();
            string fileUrl = Guid.NewGuid().ToString() + ".png";
            string url = path + @"\wwwroot\Image\" + fileUrl;

            System.IO.File.WriteAllBytes(url, bytes);
            string urlPath = url.Replace(path, "");  //转换成相对路径

            user.Image = urlPath;

            if (ModelState.IsValid)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return Json(user);
            }
            return Json(user);
        }
    }
}



