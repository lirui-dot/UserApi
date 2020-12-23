using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                    // string o=i.Replace("\"","\'");
                    // string p=o.Replace("'name':'','areacode':'010','zipcode':'100000','depth':1},{'id':2,'name':'安徽','parentid':0,'parentname':'','areacode':null,'zipcode':'','depth':1}";status':0,'msg':'ok','result':[{","");
                    // string a=p.Replace("]}","");
                    // string json = @"{'id':1,'name':'北京','parentid':0,'parent

                    // ProvinceDetails pr = JsonConvert.DeserializeObject<ProvinceDetails>(json);//反序列化

                    // CityDetails city = JsonConvert.DeserializeObject<CityDetails>(json);//反序列化
                    ProvinceDetails province = JsonConvert.DeserializeObject<ProvinceDetails>(json);//反序列化
                                                                                                    // Console.WriteLine(string.Format("反序列化： id={0},name={1},parentid={2},parentname={3},areacode={4},zipcode={5},depth={6}"
                                                                                                    // , descJsonStu.id, descJsonStu.name, descJsonStu.parentid, descJsonStu.parentname,descJsonStu.areacode,descJsonStu.zipcode,descJsonStu.depth));

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

            var c = await _context.Provinces.FindAsync(499);
            if (c.id.ToString() == null)
            {
                for (int w = 1; w < 10; w++)
                {
                    string url = "https://api.jisuapi.com/area/city?parentid=" + w + "&appkey=1b5f267715e671b2";

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

                    }
                }
            }
            if (ModelState.IsValid)
            {

                var dbuser = _context.Users.FirstOrDefault(m => m.UserName.Equals(user.UserName) && m.PassWord.Equals(user.PassWord));

                if (dbuser != null)
                {
                    return Json(dbuser);
                }


            }
            return View(user);
        }
    }
}
