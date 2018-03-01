using EmployeeVendorsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EmployeeVendorsMVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<EmployeeMVC> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<EmployeeMVC>>().Result;
            return View(empList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if(id == 0)
            return View(new EmployeeMVC());

            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employees/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<EmployeeMVC>().Result);
            }
        }


        [HttpPost]
        public ActionResult AddOrEdit(EmployeeMVC emp)
        {
            if(emp.Id == 0){ 
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employees",emp).Result;
            TempData["SuccessMessage"] = "Successfully Added";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employees/"+emp.Id, emp).Result;
                TempData["SuccessMessage"] = "Successfully Updated";
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employees/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Successfully Deleted";
            return RedirectToAction("Index");
        }
    }
}