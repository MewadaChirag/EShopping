using ECommerceApplication.Data;
using ECommerceApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApplication.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class UserController : Controller
    {
        UserManager<IdentityUser> _userManager;
        ApplicationDbContext _db;

        public UserController(UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {   
            _userManager=userManager;
            _db=db;
        }

        public IActionResult Index()
        {
            return View(_db.ApplicationUsers.ToList());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {

                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    TempData["save"] = "User has been created successfully.";
                    return RedirectToAction(nameof(Index));

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                
            }
            return View();
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(c => c.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser user)
        {
            var userInfo = _db.ApplicationUsers.FirstOrDefault(c => c.Id == user.Id);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.FirstName = user.FirstName;
            userInfo.LastName = user.LastName;
            var result = await _userManager.UpdateAsync(userInfo);
            if (result.Succeeded)
            {
                TempData["save"] = "User has been updated successfully.";
                return RedirectToAction(nameof(Index));

            }
            return View(userInfo);

        }

        public async Task<IActionResult> Details(string id)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(c => c.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public async Task<IActionResult> Lockout(string id)
        {
           if(id == null)
            {
                return NotFound();
            }
           var user = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }
            return View(user);

        }

        [HttpPost]
        public async Task<IActionResult> Lockout(ApplicationUser user)
        {
            var userInfo = _db.ApplicationUsers.FirstOrDefault(c => c.Id == user.Id);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.LockoutEnd = DateTime.Now.AddYears(100);
            int rowAffected = _db.SaveChanges();
            if (rowAffected > 0)
            {
                TempData["save"] = "User has been locout successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(userInfo);

        }

        public async Task<IActionResult> Active(string id)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(c => c.Id==id);
            if(user == null )
            {
                return NotFound();
            }
            return View(user);  
        }
        }
    }
