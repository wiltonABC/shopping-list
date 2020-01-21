using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryList.Models;
using GroceryList.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryList.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {

            this.categoryRepository = categoryRepository;

        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            TempData["modalTitle"] = "Confirmation";
            TempData["modalText"] = "Are you sure you want to remove the Category?";
            return View(await categoryRepository.GetCategories());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Category category)
        {

            if (ModelState.IsValid)
            {
                await categoryRepository.AddCategory(category);
                TempData["alertMessage"] = "Category succesfully added!";

                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category)
        {
            if (ModelState.IsValid)
            {
                await categoryRepository.UpdateCategory(category);
                TempData["alertMessage"] = "Category succesfully updated!";

                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit", new { Id = category.Id });
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            await categoryRepository.RemoveCategory(id);

            return NoContent();
        }

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var category = await categoryRepository.GetCategory(id);

            return View("Edit", category);
        }
    }
}
