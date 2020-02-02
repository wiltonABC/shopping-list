using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroceryList.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using GroceryList.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryList.Controllers
{
    public class SupermarketsController : Controller
    {

        private ISupermarketRepository supermarketRepository;
        private ICategoryRepository categoryRepository;
        private ISupermarketCategoriesRepository supermarketCategoriesRepository;

        public SupermarketsController(ISupermarketRepository supermarketRepository,
            ICategoryRepository categoryRepository, ISupermarketCategoriesRepository supermarketCategoriesRepository)
        {
            this.supermarketRepository = supermarketRepository;
            this.categoryRepository = categoryRepository;
            this.supermarketCategoriesRepository = supermarketCategoriesRepository;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            TempData["modalTitle"] = "Confirmation";
            TempData["modalText"] = "Are you sure you want to remove the Supermarket?";
            return View(await supermarketRepository.GetSupermarkets());
        }

        public async Task<IActionResult> Create()
        {
            var supermarket = await supermarketRepository.AddSupermarket();

            ViewBag.Categories = new SelectList(await categoryRepository.GetCategories(), "Id", "Description", null);

            TempData["modalTitle"] = "Confirmation";
            TempData["modalText"] = "Are you sure you want to remove the Supermarket Category?";
            return View(supermarket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(SupermarketCategories supermarketCategories) {

            if (ModelState.IsValid)
            {
                var addedSupermarketCategory = await supermarketCategoriesRepository
                    .Add(supermarketCategories);
                var supermarketCategory = await supermarketCategoriesRepository
                    .GetSupermarketCategories(addedSupermarketCategory.Id);

                return PartialView("Tables/_SupermarketCategoriesTableRowPartial",
                    supermarketCategory);

            }

            return new BadRequestResult();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            await supermarketCategoriesRepository.RemoveSupermarketCategory(id);

            return NoContent();
        }

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var supermarket = await supermarketRepository.GetSupermarketWithCategories(id);

            ViewBag.Categories = new SelectList(await categoryRepository.GetCategories(), "Id", "Description", null);

            TempData["modalTitle"] = "Confirmation";
            TempData["modalText"] = "Are you sure you want to remove the Supermarket Category?";
            return View(supermarket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Supermarket supermarket)
        {
            if (ModelState.IsValid)
            {
                await supermarketRepository.UpdateSupermarket(supermarket);
                TempData["alertMessage"] = "Supermarket succesfully update!";

                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Supermarket supermarket)
        {
            if (ModelState.IsValid)
            {
                await supermarketRepository.UpdateSupermarket(supermarket);
                TempData["alertMessage"] = "Supermarket succesfully updated!";

                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit", new { Id = supermarket.Id });
        }
    }
}
