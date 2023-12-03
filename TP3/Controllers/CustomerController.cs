using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TP3.Models;

namespace TP3.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _db;

        public CustomerController( AppDbContext db)
        { this._db = db; }

        // GET: CustomerController
        public ActionResult Index()
        {
          
                List<Customer> customers = _db.Customers.ToList();
                return View(customers);
            
          
        }
        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Create()
        {
            var members = _db.Membershiptypes.ToList();
            ViewBag.member = members.Select(members => new SelectListItem()
            {
                Text = members.Id.ToString(),
                Value = members.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer c)
        {
            if (!ModelState.IsValid)
            {
                var members = _db.Membershiptypes.ToList();
                ViewBag.member = members.Select(members => new SelectListItem()
                {
                    Text = members.Id.ToString(),

                    Value = members.Id.ToString()

                });
                return View();
            }
            ViewBag.Errors = ModelState.Values
                .SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            c.Id = new Guid();
            _db.Customers.Add(c);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
