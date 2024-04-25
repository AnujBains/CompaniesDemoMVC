using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompaniesDemoMVC.Models;

namespace CompaniesDemoMVC.Controllers
{
    public class HomeController : Controller
    {
        CompanyRepository companyrepository = new CompanyRepository();

        public ActionResult Index()
        {
            IEnumerable<Company> companies = companyrepository.GetAllEmployee();
            return View(companies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                companyrepository.AddCompany(company);
                return RedirectToAction("Index");

            }
            return View(company);
        }

        public ActionResult Edit(int id)
        {
            Company company = companyrepository.GetAllEmployee().FirstOrDefault(x => x.EmployeeId == id);
            return View(company);
        }

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                companyrepository.UpdateCompany(company);
                return RedirectToAction("Index");
            }
            return View(company);
        }
        public ActionResult Details(int id)
        {
            Company company = companyrepository.GetAllEmployee().FirstOrDefault(x => x.EmployeeId == id);
            return View(company);
        }

        public ActionResult Delete(int id)
        {
            Company company = companyrepository.GetAllEmployee().FirstOrDefault(x => x.EmployeeId == id);
            return View(company);
        }

        [HttpPost]
        public ActionResult Delete(Company company, int id)
        {

                companyrepository.DeleteCompany(id);
                return RedirectToAction("Index");
           
        }
    }
}