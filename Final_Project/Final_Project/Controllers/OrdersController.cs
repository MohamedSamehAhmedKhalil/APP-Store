using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    public class OrdersController : Controller
    {
        ApplicationDbContext _context ;
        public OrdersController(ApplicationDbContext context)
        {
            _context = context;

        }
        public IActionResult GetIndexView()
        {
            return View("Index", _context.Orders.ToList());
        }

        public IActionResult GetCreate()
        {
            ViewBag.CustomerSelect = new SelectList(_context.Customers.ToList(), "Id", "Name");
            ViewBag.ProductSelect = new SelectList(_context.Products.ToList(), "Id", "Name");
            return View("Create");
        }
        public IActionResult GetDetails(int id)
        {
            Order order = _context.Orders.Include(e => e.Product).FirstOrDefault(e => e.Id == id);
            Order order2 = _context.Orders.Include(e => e.Customer).FirstOrDefault(e => e.Id == id);
            return View("Details", order);
        }
        [HttpPost]
        public IActionResult AddNew(Order order)
        {

            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.CustomerSelect = new SelectList(_context.Customers.ToList(), "Id", "Name");
                ViewBag.ProductSelect = new SelectList(_context.Products.ToList(), "Id", "Name");
                return View("Create");
            }
        }

        [HttpGet]
        public IActionResult GetDeleteView(int id)
        {
            Order order = _context.Orders.Include(e => e.Product).FirstOrDefault(e => e.Id == id);
            Order order2 = _context.Orders.Include(e => e.Customer).FirstOrDefault(e => e.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", order);
            }

        }

        [HttpPost]
        public IActionResult DeleteCurrent(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }

        }

        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.CustomerSelect = new SelectList(_context.Customers.ToList(), "Id", "Name");
                ViewBag.ProductSelect = new SelectList(_context.Products.ToList(), "Id", "Name");
                return View("Edit", order);
            }

        }
        [HttpPost]
        public IActionResult EditCurrent(Order order)
        {

            if (ModelState.IsValid == true)
            {
                _context.Orders.Update(order);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }
            else
            {
                ViewBag.CustomerSelect = new SelectList(_context.Customers.ToList(), "Id", "Name");
                ViewBag.ProductSelect = new SelectList(_context.Products.ToList(), "Id", "Name");
                return View("Edit");
            }
        }
    }
}
