using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryList.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryList.Controllers
{
    public class ShoppingListsController : Controller
    {

        private IShoppingListRepository shoppingListRepository;

        public ShoppingListsController(IShoppingListRepository shoppingListRepository)
        {
            this.shoppingListRepository = shoppingListRepository;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            TempData["modalTitle"] = "Confirmation";
            TempData["modalText"] = "Are you sure you want to remove the Shopping List?";
            return View(await shoppingListRepository.GetShoppingLists());
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
