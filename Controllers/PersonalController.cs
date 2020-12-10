using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcUser.Models;
using Newtonsoft.Json;
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

        // public async Task<ActionResult> doGet()
        // {
            //获取全部省份
            // string url = "https://api.jisuapi.com/area/province?appkey=1b5f267715e671b2";

            //根据省份id获取城市id=1
            // string url = "https://api.jisuapi.com/area/city?parentid=1&appkey=1b5f267715e671b2";

            //根据城市id获取区县
            // string url = "https://api.jisuapi.com/area/town?parentid=1&appkey=1b5f267715e671b2";
            // var handler = new HttpClientHandler()
            // {
            //     AutomaticDecompression = DecompressionMethods.GZip
            // };
            // using (var http = new HttpClient(handler))
            // {
            //     var response = await http.GetAsync(url);
            //     response.EnsureSuccessStatusCode();
            //     Console.WriteLine(await response.Content.ReadAsStringAsync());
            //     string json = await response.Content.ReadAsStringAsync();
                // string o=i.Replace("\"","\'");
                // string p=o.Replace("'name':'','areacode':'010','zipcode':'100000','depth':1},{'id':2,'name':'安徽','parentid':0,'parentname':'','areacode':null,'zipcode':'','depth':1}";status':0,'msg':'ok','result':[{","");
                // string a=p.Replace("]}","");
                // string json = @"{'id':1,'name':'北京','parentid':0,'parent
                
                // ProvinceDetails pr = JsonConvert.DeserializeObject<ProvinceDetails>(json);//反序列化

                // CityDetails city = JsonConvert.DeserializeObject<CityDetails>(json);//反序列化
                // TownDetails town = JsonConvert.DeserializeObject<TownDetails>(json);//反序列化
                // Console.WriteLine(string.Format("反序列化： id={0},name={1},parentid={2},parentname={3},areacode={4},zipcode={5},depth={6}"
                // , descJsonStu.id, descJsonStu.name, descJsonStu.parentid, descJsonStu.parentname,descJsonStu.areacode,descJsonStu.zipcode,descJsonStu.depth));

        //         Town prs = new Town();
        //         for (int i = 0; i < town.result.Count; i++)
        //         {
        //             prs.id = town.result[i].id;
        //             prs.name = town.result[i].name;
        //             prs.parentid = town.result[i].parentid;
        //             prs.parentname = town.result[i].parentname;
        //             prs.areacode = town.result[i].areacode;
        //             prs.zipcode = town.result[i].zipcode;
        //             prs.depth = town.result[i].depth;
                    
        //             if (prs != null)
        //             {
        //                 _context.Towns.Add(prs);
        //                 await _context.SaveChangesAsync();
        //             }
        //         }
        //         return Json(prs);

        //     }


        // }


        // GET: api/User
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     UserPageModel usermodel = new UserPageModel();
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //     var user = await _context.Users.FindAsync(id);
        //     usermodel.Id = user.Id;
        //     usermodel.UserName = user.UserName;
        //     usermodel.PassWord = user.PassWord;
        //     usermodel.Gender = user.Gender;
        //     usermodel.Age = user.Age;
        //     usermodel.Provinces = user.Provinces;
        //     usermodel.City = user.City;
        //     string fileUrl = Path.GetFileName(user.Image);
        //     var path = Directory.GetCurrentDirectory();
        //     if (user.Image != null)
        //     {
        //         FileStream fs = new FileStream(path + @"\wwwroot\Image\" + fileUrl, FileMode.Open, FileAccess.Read);
        //         byte[] buffer = new byte[fs.Length];
        //         fs.Read(buffer, 0, (int)fs.Length);

        //         usermodel.FileUrl = "data:image/png;base64," + Convert.ToBase64String(buffer);
        //     }

        //     usermodel.Url = user.Url;
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }

        //     return Json(usermodel);
        // }

        //POST: api/User
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult> PostPersonal(int id,UserPageModel usermodel)
        // {

        //       return View();
        // }
    }
}

