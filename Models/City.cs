using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace UserApi.Models
{
    public class City
    {
        
        public int id { get; set; }

        public string name { get; set; }

        public int parentid { get; set; }

        public string parentname { get; set; }

        public string areacode { get; set; }

        public string zipcode { get; set; }

        public string depth { get; set; }

    }
    [NotMapped]
    public class CityDetails{
        public int status{get;set;}
        public string msg{get;set;}
        public List<City> result{get;set;}
    }

}