using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : Controller
    {

        private readonly UserContext _context;

        public ProvinceController(UserContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> PostProvince()
        {

                var dbProvince=await _context.Provinces.Where(b=>b.id<35).ToListAsync();

                if (dbProvince != null)
                {
                    return Json(dbProvince);
                }

                return Json(dbProvince);
            }
        }

    }

