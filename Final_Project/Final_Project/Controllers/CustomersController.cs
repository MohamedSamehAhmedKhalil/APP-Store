using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult GetIndexView()
        {
            return View("Index", _context.Customers.ToList());
        }

        public IActionResult GetCreate()
        {
            return View("Create");
        }
        public IActionResult GetDetails(int id)
        {
            Customer employee = _context.Customers.FirstOrDefault(e => e.Id == id);
            return View("Details", employee);
        }

        [HttpPost]
        public IActionResult AddNew(Customer cus)
        {

            if (ModelState.IsValid)
            {
                _context.Customers.Add(cus);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                return View("Create");
            }
        }

        [HttpGet]
        public IActionResult GetDeleteView(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", customer);
            }

        }

        [HttpPost]
        public IActionResult DeleteCurrent(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }

        }

        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return View("Edit", customer);
            }

        }
        [HttpPost]
        public IActionResult EditCurrent(Customer cus)
        {

            if (ModelState.IsValid == true)
            {
                _context.Customers.Update(cus);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                return View("Edit");
            }
        }

    }
}
