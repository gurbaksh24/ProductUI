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
    public class AirController : Controller
    {
        // GET: Air
        public ActionResult GetAllAirs()
        {
            List<Air> jsonObject;
            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Air";
                var json = client.DownloadString(uri);
                jsonObject = JsonConvert.DeserializeObject<List<Air>>(json);
            }
            return View(jsonObject);
        }
        public ActionResult PostDataToApi()
        {
            List<Air> jsonObject;
            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Air";
                var json = client.DownloadString(uri);
                jsonObject = JsonConvert.DeserializeObject<List<Air>>(json);
            }
            return View(jsonObject);
        }

        public ActionResult AddData()
        {
            string airName = Request.Params["airname"];
            string source = Request.Params["source"];
            string destination = Request.Params["destination"];
            string airClass = Request.Params["class"];
            string airPrice = Request.Params["price"];
            var values = new NameValueCollection();
            values["AirName"] = airName;
            values["Source"] = source;
            values["Destination"] = destination;
            values["Class"] = airClass;
            values["AirPrice"] = airPrice;
            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Air";
                var response = client.UploadValues(uri, values);
                var responseString = Encoding.Default.GetString(response);
                TempData["response"] = responseString;
            }
            return RedirectToAction("GetAllAirs");
        }
        public ActionResult UpdateSave()
        {
            string airId = Request.Params["save"];
            var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49811/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var uri = "http://localhost:49811/api/Air/" + airId;
                var response = client.PutAsJsonAsync(uri, "save");
                TempData["response"] = response;
            return RedirectToAction("GetAllAirs");
        }
        public ActionResult UpdateBook()
        {
            string airId = Request.Params["book"];
            var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49811/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var uri = "http://localhost:49811/api/Air/" + airId;
                var response = client.PutAsJsonAsync(uri, "book");
                TempData["response"] = response;
            return RedirectToAction("GetAllAirs");
        }
    }
}