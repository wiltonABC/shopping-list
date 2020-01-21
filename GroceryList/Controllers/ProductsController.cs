using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryList.Models;
using GroceryList.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryList.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            TempData["modalTitle"] = "Confirmation";
            TempData["modalText"] = "Are you sure you want to remove the Product?";
            return View(await productRepository.GetProducts());
        }

        public async Task<IActionResult> Create()
        {

            ViewBag.Categories = new SelectList(await categoryRepository.GetCategories(), "Id", "Description", null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Product product)
        {

            if (ModelState.IsValid)
            {
                await productRepository.AddProduct(product);
                TempData["alertMessage"] = "Product succesfully added!";

                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await productRepository.RemoveProduct(id);

            return NoContent();
        }

        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var product = await productRepository.GetProduct(id);

            ViewBag.Categories = new SelectList(await categoryRepository.GetCategories(), "Id", "Description", product.CategoryId);

            return View(product);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product)
        {
            if (ModelState.IsValid)
            {
                await productRepository.UpdateProduct(product);
                TempData["alertMessage"] = "Product succesfully updated!";

                return RedirectToAction("Index");
            }

            return RedirectToAction("Edit", new { Id = product.Id });
        }
    }
}
