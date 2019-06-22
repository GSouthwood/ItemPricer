using ItemPricer.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemPricer.Controllers
{
    public class HomeController : Controller
    {
        private ItemService _itemService;

        public ActionResult Index()
        {
            _itemService = new ItemService();
            return View(_itemService.GetHighestPricedItems());
        }

        [HttpGet]
        public string GetPrice(string itemName)
        {
            //Creating Web Service reference object  
            PricerWebService.PricerWebService objPayRef = new PricerWebService.PricerWebService();

            //calling and storing web service output into the variable  
            var result = objPayRef.GetMaxPriceOfItem(itemName);

            return result >= 0 ? result.ToString("C2") : "No matching item was found.";

        }
    }
}