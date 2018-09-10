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
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult GetAllHotels()
        {
            List<Hotel> jsonObject;
            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Hotel";
                var json = client.DownloadString(uri);
                jsonObject = JsonConvert.DeserializeObject<List<Hotel>>(json);
            }
            return View(jsonObject);
        }
        public ActionResult PostDataToApi()
        {
            List<Hotel> jsonObject;
            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Hotel";
                var json = client.DownloadString(uri);
                jsonObject = JsonConvert.DeserializeObject<List<Hotel>>(json);
            }
            return View(jsonObject);
        }
        public ActionResult AddData()
        {
            string hotelName = Request.Params["hotelname"];
            string city = Request.Params["city"];
            string availableRooms = Request.Params["rooms"];
            string price = Request.Params["price"];
            var values = new NameValueCollection();
            values["HotelName"] = hotelName;
            values["City"] = city;
            values["AvailableRooms"] = availableRooms;
            values["Price"] = price;
            
            using (var client = new WebClient())
            {
                string uri = "http://localhost:49811/api/Hotel";
                var response = client.UploadValues(uri, values);
                var responseString = Encoding.Default.GetString(response);
                TempData["response"] = responseString;
            }
            return RedirectToAction("GetAllHotels");
        }
        public ActionResult UpdateSave()
        {
            string hotelId = Request.Params["save"];
            var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49811/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var uri = "http://localhost:49811/api/Hotel/" + hotelId;
                var response = client.PutAsJsonAsync(uri, "save");
                TempData["response"] = response;
            return RedirectToAction("GetAllHotels");
        }
        public ActionResult UpdateBook()
        {
            string hotelId = Request.Params["book"];
            var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:49811/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var uri = "http://localhost:49811/api/Hotel/" + hotelId;
                var response = client.PutAsJsonAsync(uri, "book");
                TempData["response"] = response;
            return RedirectToAction("GetAllHotels");
        }
    }
}