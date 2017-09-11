using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Qlik.Sense.ServiceClusterManager.Model;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (HttpClient client = new HttpClient())
            {  
                client.BaseAddress = new Uri("http://localhost:5000");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/servicecluster/getall").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var myDeserializedObjList = (List<ServiceCluster>)JsonConvert.DeserializeObject(stringData, typeof(List<ServiceCluster>));
                ViewData["Mes"] = myDeserializedObjList;
                return View(myDeserializedObjList);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
