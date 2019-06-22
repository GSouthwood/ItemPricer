using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for PricerWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class PricerWebService : System.Web.Services.WebService
{

    public PricerWebService()
    {
    }

    [WebMethod]
    public decimal GetMaxPriceOfItem(string name)
    {
        var prices = new List<decimal>();
        var path = HttpContext.Current.Server.MapPath(@"~/items.txt");
        try
        {
            using (StreamReader sr = new StreamReader(path, true))
            {
                var line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    var data = line.Split(',');

                    if (data[1].ToLower() == name.ToLower())
                    {
                        prices.Add(decimal.Parse(data[2]));
                    }
                }
            }
        }
        catch (Exception e)
        {
            throw;
        }
        if (prices.Any())
            return prices.Max();
        else
            return -1;
    }

}
