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
    public class CarController : Controller
    {
        // GET: Car
        public ActionResult GetAllCars()
        {
            List<Car> jsonObject;
            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Car";
                var json = client.DownloadString(uri);
                jsonObject = JsonConvert.DeserializeObject<List<Car>>(json);
            }
            return View(jsonObject);
        }
        public ActionResult PostDataToApi()
        {
            List<Car> jsonObject;
            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Car";
                var json = client.DownloadString(uri);
                jsonObject = JsonConvert.DeserializeObject<List<Car>>(json);
            }
            return View(jsonObject);
        }
        public ActionResult AddData()
        {
            string carName = Request.Params["carname"];
            string carModel = Request.Params["carmodel"];
            string carBrand = Request.Params["carbrand"];
            string carColor = Request.Params["carcolor"];
            string carPrice = Request.Params["price"];
            var values = new NameValueCollection();
            values["CarName"] = carName;
            values["CarModel"] = carModel;
            values["CarBrand"] = carBrand;
            values["CarColor"] = carColor;
            values["CarPrice"] = carPrice;

            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Car";
                var response = client.UploadValues(uri, values);
                var responseString = Encoding.Default.GetString(response);
                TempData["response"] = responseString;
            }
            return RedirectToAction("GetAllCars");
        }
        public ActionResult UpdateSave()
        {
            string carId = Request.Params["save"];
            var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49811/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var uri = "http://localhost:49811/api/Car/" + carId;
                var response = client.PutAsJsonAsync(uri, "save");
                TempData["response"] = response;
            return RedirectToAction("GetAllCars");
        }
        public ActionResult UpdateBook()
        {
            string carId = Request.Params["book"];
            var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49811/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var uri = "http://localhost:49811/api/Car/" + carId;
                var response = client.PutAsJsonAsync(uri, "book");
                TempData["response"] = response;
            return RedirectToAction("GetAllCars");
        }
    }
}