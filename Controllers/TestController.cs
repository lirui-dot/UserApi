using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserApi.Models;

namespace UserApi.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {

        private readonly UserContext _context;

        public TestController(UserContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> doGet()
        {
            var p = await _context.Provinces.FindAsync(1);
            if (p.id.ToString() == null)
            {

                string url = "https://api.jisuapi.com/area/province?appkey=1b5f267715e671b2";
                var handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip
                };
                using (var http = new HttpClient(handler))
                {
                    var response = await http.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                    string json = await response.Content.ReadAsStringAsync();
                    ProvinceDetails province = JsonConvert.DeserializeObject<ProvinceDetails>(json);
                    Province prs = new Province();
                    for (int i = 0; i < province.result.Count; i++)
                    {
                        prs.id = province.result[i].id;
                        prs.name = province.result[i].name;
                        prs.parentid = province.result[i].parentid;
                        prs.parentname = province.result[i].parentname;
                        prs.areacode = province.result[i].areacode;
                        prs.zipcode = province.result[i].zipcode;
                        prs.depth = province.result[i].depth;

                        if (prs != null)
                        {
                            _context.Provinces.Add(prs);
                            await _context.SaveChangesAsync();
                        }
                    }
                    return Json(prs);
                }

            }

            return View();

        }
    }
}

