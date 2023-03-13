using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace WebCurrencyApp
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()

        {
            return "Hello World";
        }

        [WebMethod]
        public XmlDocument GetCurrency (string currency_name)
        {
            string result = @"<root>{result}</root>";

            XmlDocument Xmldoc = new XmlDocument();

            string date = DateTime.Now.ToString("dd.MM.yyyy");

            Xmldoc.Load("https://cbar.az/currencies/" + date + ".xml");

            XmlNodeList Xmllist = Xmldoc.GetElementsByTagName("Valute");

            foreach (XmlNode item in Xmllist) 
            { 
                if (item.Attributes[0].Value == currency_name)
                {
                    result = result.Replace("{result}", item.InnerXml);
                }
            }

            XmlDocument Myxml = new XmlDocument();
            Myxml.LoadXml(result);
            return Myxml;   
        }









































        // Currency - Mezenne
    //    [WebMethod]

    //    public XmlDocument GetCurrency (string currencyname)
    //    {
    //        string result = @"<root>{result}</root>"; // response model 


    //     XmlDocument xmldoc = new XmlDocument();


    //        string date = DateTime.Now.ToString("dd.MM.yyyy");


    //        xmldoc.Load("https://cbar.az/currencies/" + date + ".xml");


    //        XmlNodeList xmlist = xmldoc.GetElementsByTagName("Valute");

    //        foreach (XmlNode item in xmlist)
    //        {
    //            if (item.Attributes[0].Value== currencyname)
    //            {
    //                result = result.Replace("{result}", item.InnerXml);
    //            }
    //        }

    //        XmlDocument myxml = new XmlDocument();
    //        myxml.LoadXml(result);
    //        return myxml;   
    //}

}
}
