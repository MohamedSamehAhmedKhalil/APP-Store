using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class ProductsController : Controller
    {
        ApplicationDbContext _context ;
        IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;

        }
        public IActionResult GetIndexView()
        {
            return View("Index", _context.Products.ToList());
        }

        public IActionResult GetCreate()
        {
            return View("Create");
        }
        public IActionResult GetDetails(int id)
        {
            Product product = _context.Products.FirstOrDefault(e => e.Id == id);
            return View("Details", product);
        }
        [HttpPost]
        public IActionResult AddNew(Product pro, IFormFile? imageFormFile)
        {
            if (imageFormFile != null)
            {
                string imgExtension = Path.GetExtension(imageFormFile.FileName); // .png
                Guid imgGuid = Guid.NewGuid(); // xm789-f07li-624yn-uvx98
                string imgName = imgGuid + imgExtension; // xm789-f07li-624yn-uvx98.png
                string imgUrl = "\\images\\" + imgName; //  \images\xm789-f07li-624yn-uvx98.png
                pro.ImageUrl = imgUrl;

                string imgPath = _webHostEnvironment.WebRootPath + imgUrl;

                // FileStream 
                FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                imageFormFile.CopyTo(imgStream);
                imgStream.Dispose();
            }
            else
            {
                pro.ImageUrl = "\\images\\No_Image.png";
            }

            if (ModelState.IsValid)
            {
                _context.Products.Add(pro);
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
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", product);
            }

        }

        [HttpPost]
        public IActionResult DeleteCurrent(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                if (product.ImageUrl != "\\images\\No_Image.png")
                {
                    string imgPath = _webHostEnvironment.WebRootPath + product.ImageUrl;

                    if (System.IO.File.Exists(imgPath))
                    {
                        System.IO.File.Delete(imgPath);
                    }
                }

                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("GetIndexView");
            }

        }

        [HttpGet]
        public IActionResult GetEditView(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return View("Edit", product);
            }

        }
        [HttpPost]
        public IActionResult EditCurrent(Product pro, IFormFile? imageFormFile)
        {

            if (imageFormFile != null)
            {
                if (pro.ImageUrl != "\\images\\No_Image.png")
                {
                    string oldImgPath = _webHostEnvironment.WebRootPath + pro.ImageUrl;

                    if (System.IO.File.Exists(oldImgPath) == true)
                    {
                        System.IO.File.Delete(oldImgPath);
                    }
                }


                string imgExtension = Path.GetExtension(imageFormFile.FileName); // .png
                Guid imgGuid = Guid.NewGuid(); // xm789-f07li-624yn-uvx98
                string imgName = imgGuid + imgExtension; // xm789-f07li-624yn-uvx98.png
                string imgUrl = "\\images\\" + imgName; //  \images\xm789-f07li-624yn-uvx98.png
                pro.ImageUrl = imgUrl;

                string imgPath = _webHostEnvironment.WebRootPath + imgUrl;

                // FileStream 
                FileStream imgStream = new FileStream(imgPath, FileMode.Create);
                imageFormFile.CopyTo(imgStream);
                imgStream.Dispose();
            }

            if (ModelState.IsValid == true)
            {
                _context.Products.Update(pro);
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
