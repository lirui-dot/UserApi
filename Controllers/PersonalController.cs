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

        public async void doGet()
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
                string i = await response.Content.ReadAsStringAsync();
                string pp="测试上传的项目是否成功";
                // string o=i.Replace("\"","\'");
                // string p=o.Replace("'status':0,'msg':'ok','result':[{","");
                // string a=p.Replace("]}","");
                // string json = @"{'id':1,'name':'北京','parentid':0,'parentname':'','areacode':'010','zipcode':'100000','depth':1},{'id':2,'name':'安徽','parentid':0,'parentname':'','areacode':null,'zipcode':'','depth':1}";
                // string qq=@"{'id':1,'name':'北京','parentid':0,'parentname':'','areacode':'010','zipcode':'100000','depth':1},{'id':2,'name':'安徽','parentid':0,'parentname':'','areacode':null,'zipcode':'','depth':1},{'id':3,'name':'福建','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':4,'name':'甘肃','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':5,'name':'广东','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':6,'name':'广西','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':7,'name':'贵州','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':8,'name':'海南','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':9,'name':'河北','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':10,'name':'河南','parentid':0,'parentname':'','areacode':'','zipcode':null,'depth':1},{'id':11,'name':'黑龙江','parentid':0,'parentname':'','areacode':'','zipcode':null,'depth':1},{'id':12,'name':'湖北','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':13,'name':'湖南','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':14,'name':'吉林','parentid':0,'parentname':'','areacode':'','zipcode':null,'depth':1},{'id':15,'name':'江苏','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':16,'name':'江西','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':17,'name':'辽宁','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':18,'name':'内蒙古','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':19,'name':'宁夏','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':20,'name':'青海','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':21,'name':'山东','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':22,'name':'山西','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':23,'name':'陕西','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':24,'name':'上海','parentid':0,'parentname':'','areacode':'021','zipcode':'200000','depth':1},{'id':25,'name':'四川','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':26,'name':'天津','parentid':0,'parentname':'','areacode':'022','zipcode':'300000','depth':1},{'id':27,'name':'西藏','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':28,'name':'新疆','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':29,'name':'云南','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':30,'name':'浙江','parentid':0,'parentname':'','areacode':null,'zipcode':null,'depth':1},{'id':31,'name':'重庆','parentid':0,'parentname':'','areacode':'023','zipcode':'404100','depth':1},{'id':32,'name':'香港','parentid':0,'parentname':'','areacode':'00852','zipcode':'999077','depth':1},{'id':33,'name':'澳门','parentid':0,'parentname':'','areacode':'00853','zipcode':'999078','depth':1},{'id':34,'name':'台湾','parentid':0,'parentname':'','areacode':'00886','zipcode':null,'depth':1},{'id':51,'name':'国外','parentid':0,'parentname':'','areacode':'','zipcode':null,'depth':1}";
                Provinces descJsonStu =JsonConvert.DeserializeObject<Provinces>(i);//反序列化
                // Console.WriteLine(string.Format("反序列化： id={0},name={1},parentid={2},parentname={3},areacode={4},zipcode={5},depth={6}"
                // , descJsonStu.id, descJsonStu.name, descJsonStu.parentid, descJsonStu.parentname,descJsonStu.areacode,descJsonStu.zipcode,descJsonStu.depth));
                
            }


        }


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

