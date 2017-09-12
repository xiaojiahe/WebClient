using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Qlik.Sense.ServiceClusterManager.Model;
using Newtonsoft.Json;

namespace WebClient.Controllers
{
    
    public class ServiceClusterController : Controller
    {
        public ActionResult getAll()
        {
            using (HttpClient client = new HttpClient())
            {    
                client.BaseAddress = new Uri("http://localhost:5000");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/servicecluster/getall").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var myDeserializedObjList = (List<ServiceCluster>)JsonConvert.DeserializeObject(stringData, typeof(List<ServiceCluster>));
                return View(myDeserializedObjList);
            }
        }

        public ActionResult get(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/servicecluster/get"+ $"/{id}").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var myDeserialized = (ServiceCluster)JsonConvert.DeserializeObject(stringData, typeof(ServiceCluster));
                return View(myDeserialized);
            }
        }

      
        public ActionResult create()
        {
           
                return View();
        }

        [HttpPost]
        public async void gotocreate(ServiceCluster serviceCluster)
        {
             using (HttpClient client = new HttpClient())
             {
                Uri requestUri = new Uri("http://localhost:5000/ServiceCluster/add");
                serviceCluster.SharedFolderSettings.RootFolder = "C://whichever";
                string json = "";
                json = Newtonsoft.Json.JsonConvert.SerializeObject(serviceCluster);
                var objClint = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage respon = await  client.PostAsync(requestUri, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
                string responJsonText = await respon.Content.ReadAsStringAsync();
            }
        }

        public void postdelete(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.DeleteAsync("/servicecluster/delete" + $"/{id}").Result;
            }
        }

        public ActionResult getedit(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/servicecluster/get" + $"/{id}").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                var myDeserialized = (ServiceCluster)JsonConvert.DeserializeObject(stringData, typeof(ServiceCluster));
                return View(myDeserialized);
            }
        }

        
        public async void postedit(ServiceCluster serviceCluster)
        {
            using (HttpClient client = new HttpClient())
            {
                Guid id = serviceCluster.Id;
                Uri requestUri = new Uri("http://localhost:5000/ServiceCluster/Update" + $"/{id}");
                serviceCluster.SharedFolderSettings.RootFolder = "C://whichever";
                string json = "";
                json = Newtonsoft.Json.JsonConvert.SerializeObject(serviceCluster);
                var objClint = new System.Net.Http.HttpClient();
                System.Net.Http.HttpResponseMessage respon = await client.PutAsync(requestUri, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
                string responJsonText = await respon.Content.ReadAsStringAsync();
            }

            RedirectToAction("getall");
        }
    }
}