using Newtonsoft.Json;
using ProductUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProductUserInterface.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult GetAllActivities()
        {
            List<Activity> jsonObject;
            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Activities";
                var json = client.DownloadString(uri);
                jsonObject = JsonConvert.DeserializeObject<List<Activity>>(json);
            }
            return View(jsonObject);
        }
        public ActionResult PostDataToApi()
        {
            List<Activity> jsonObject;
            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Activities";
                var json = client.DownloadString(uri);
                jsonObject = JsonConvert.DeserializeObject<List<Activity>>(json);
            }
            return View(jsonObject);
        }

        public ActionResult AddData()
        {
            string activityName = Request.Params["activityname"];
            string activityPrice = Request.Params["price"];
            string activityCategory = Request.Params["category"];
            var values = new NameValueCollection();
            values["ActivityName"] = activityName;
            values["ActivityPrice"] = activityPrice;
            values["ActivityCategory"] = activityCategory;
            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Activities";
                var response = client.UploadValues(uri, values);
                var responseString = Encoding.Default.GetString(response);
                TempData["response"] = responseString;
            }
            return RedirectToAction("GetAllActivities");
        }
        public ActionResult UpdateSave()
        {
            string activityId = Request.Params["save"];
            
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49811/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var uri = "http://localhost:49811/api/Activities/" + activityId;
                var response = client.PutAsJsonAsync(uri, "save");
            return RedirectToAction("GetAllActivities");
        }
        public ActionResult UpdateBook()
        {
            string activityId = Request.Params["book"];
            var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49811/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var uri = "http://localhost:49811/api/Activities/" + activityId;
                var response = client.PutAsJsonAsync(uri, "book");
            return RedirectToAction("GetAllActivities");
        }

    }
}