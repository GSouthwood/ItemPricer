using ItemPricer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ItemPricer.Service
{
    public class ItemService
    {

        public List<Item> GetHighestPricedItems()
        {
            var items = GetItems();

            var highestPricedItems =
                items.GroupBy(i => i.Name)
                .Select(x =>
                {
                    var highestPricedItemInGroup = x.OrderByDescending(i => i.Price).First();

                    return new Item
                    {
                        Id = highestPricedItemInGroup.Id,
                        Name = x.Key,
                        Price = highestPricedItemInGroup.Price
                    };
                }).ToList();

            return highestPricedItems;
        }

        public List<Item> GetItems()
        {
            var items = new List<Item>();
            var path = HttpContext.Current.Server.MapPath(@"~/items.txt");
            try
            {
                using (StreamReader sr = new StreamReader(path, true))
                {
                    var line = sr.ReadLine(); //skip first line
                    while ((line = sr.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        items.Add(new Item
                        {
                            Id = int.Parse(data[0]),
                            Name = data[1],
                            Price = decimal.Parse(data[2])
                        });
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return items;
        }
        
    }
}