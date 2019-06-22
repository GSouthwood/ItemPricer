using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace FileAccess
{
    public class ItemReader
    {
        public GetItems()
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
        }
    }
}
