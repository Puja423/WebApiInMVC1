using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        public ActionResult Index()
        {
            IEnumerable<mvcInformationModel> empList;
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Information").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcInformationModel>>().Result;
            return View(empList);
            
        }
        public ActionResult AddOrEdit(int id =0)
        {
            if (id == 0)
            {
                return View(new mvcInformationModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Information/"+ id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcInformationModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcInformationModel emp)
        {
            if (emp.ID == 0)
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Information", emp).Result;
                TempData["SuccessMessage"] = "Saved Sucessfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Information/"+ emp.ID, emp).Result;
                TempData["SuccessMessage"] = "Updated Sucessfully";
            }
            return RedirectToAction("Index");

          
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("Information/" +id.ToString()).Result;
            TempData["SuccessMessage"] = "Saved Sucessfully";
            return RedirectToAction("Index");
        }
    }
}