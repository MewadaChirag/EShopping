using ECommerceApplication.Data;
using ECommerceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }

        //Create Get Action Method

        public ActionResult Create()
        {
            return View();
        }

        //Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if(ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();
                TempData["save"] = "Product type has been saved successfully";
                return RedirectToAction("Index");
            }
             return View(productTypes);

        }

        //Edit Get Action Method

        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var ProductType = _db.ProductTypes.Find(id);
            if(ProductType==null)
            {
                return NotFound();
            }
            return View(ProductType);
        }

        //Edit Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                TempData["update"] = "Product type updated successfully";
                return RedirectToAction("Index");
            }
            return View(productTypes);

        }

        //Details Get Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ProductType = _db.ProductTypes.Find(id);
            if (ProductType == null)
            {
                return NotFound();
            }
            return View(ProductType);
        }

        //Details Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ProductTypes productTypes)
        {
             return RedirectToAction("Index");
            
        }

        //Delete Get Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ProductType = _db.ProductTypes.Find(id);
            if (ProductType == null)
            {
                return NotFound();
            }
            return View(ProductType);
        }

        //Edit Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id,ProductTypes productTypes)
        {
            if(id==null)
            {
                return NotFound();
            }
            if(id!= productTypes.Id)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if(productType == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                TempData["remove"] = "Product type removed successfully";
                return RedirectToAction("Index");
            }
            return View(productTypes);

        }

    }
}
