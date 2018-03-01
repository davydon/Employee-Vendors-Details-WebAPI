using EmployeeVendorsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EmployeeVendorsMVC.Controllers
{
    public class VendorsController : Controller
    {
        // GET: Vendors
        public ActionResult Index()
        {
            IEnumerable<VendorMVC> venList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Vendors").Result;
            venList = response.Content.ReadAsAsync<IEnumerable<VendorMVC>>().Result;
            return View(venList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
            return View(new VendorMVC());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Vendors/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<VendorMVC>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(VendorMVC ven)
        {
            if(ven.Id == 0)
            { 
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Vendors", ven).Result;
            TempData["SuccessMessage"] = "Successfully Added";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Vendors/"+ven.Id, ven).Result;
                TempData["SuccessMessage"] = "Successfully Updated";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Vendors/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Successfully Deleted";
            return RedirectToAction("Index");
        }
    }
}