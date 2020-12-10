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
            //获取全部省份
            // string url = "https://api.jisuapi.com/area/province?appkey=1b5f267715e671b2";

            //根据省份id获取城市id=1
            // string url = "https://api.jisuapi.com/area/city?parentid=1&appkey=1b5f267715e671b2";

            //根据城市id获取区县
            string url = "https://api.jisuapi.com/area/city?parentid=32&appkey=1b5f267715e671b2";
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
    }
}

