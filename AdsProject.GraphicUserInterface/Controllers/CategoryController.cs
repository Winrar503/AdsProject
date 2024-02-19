using AdsProject.BussinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdsProject.BusinessEntities;

namespace AdsProject.GraphicUserInterface.Controllers
{
    public class CategoryController : Controller
    {
        CategoryBL categoryBL = new CategoryBL();

        // GET: CategoryController
        public async Task<IActionResult> Index(Category category = null)
        {
            if (category == null)
                category = new Category();
            if (category.Top_Aux == 0)
                category.Top_Aux = 10; 
            else if (category.Top_Aux == -1)
                category.Top_Aux = 0;

            var categories = await categoryBL.SearchAsync(category);
            ViewBag.Top = category.Top_Aux;

            return View(categories);
        }

        // GET: CategoryController/Details/5
        public async Task<IActionResult>Details(int id)
        {
            var category = await categoryBL.GetByIdAsync(new Category { Id = id });
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                int result = await categoryBL.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var category = await categoryBL.GetByIdAsync(new Category { Id = id });
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Category category)
        {
            try
            {
                int result = await categoryBL.UpdateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(category);
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var category = await categoryBL.GetByIdAsync(new Category { Id = id });
            return View(category);
        } 

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Category category)
        {
            try
            {
                int result = await categoryBL.DeleteAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.error = ex.Message;
                return View(category);
            }
        }
    }
}
