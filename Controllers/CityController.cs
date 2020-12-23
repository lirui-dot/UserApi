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
    public class CityController : Controller
    {

        private readonly UserContext _context;

        public CityController(UserContext context)
        {
            _context = context;
        }
        
        public async Task<ActionResult> PostProvince(int? parentid)
        {
                var dbProvince=await _context.Provinces.Where(b=>b.parentid==parentid).ToListAsync();

                if (dbProvince != null)
                {
                    return Json(dbProvince);
                }

                return Json(dbProvince);
            }
        }

    }

