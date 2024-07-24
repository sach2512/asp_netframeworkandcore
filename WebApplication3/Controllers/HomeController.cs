using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        //ViewData
        public ViewResult Index(int? id, string name, decimal? price)
        {
            ViewData["id"] = id;
            ViewData["name"] = name;
            ViewData["price"] = price;

            return View();
        }
        public ViewResult color()
        {
            int[] a = new int[4] { 1, 2, 34, 4 };
            ViewData["color"] = a;
            return View();
        }


        //viewbag
        public ViewResult test3(int?id ,string name,string price)
        {
            ViewBag.id = id;
            ViewBag.name = name;
            ViewBag.price = price;
            return View();
        }
        
        public ViewResult test4()
        {
            int[] a = new int[4] { 1, 2, 34, 4 };
            ViewBag.Color = a;
            return View();
        }

       //tempdata 
       public RedirectToRouteResult test5(int? id, string name, string price)
        {
            ViewData["id"] = id;
            ViewBag.name = name;
            TempData["price"] = price;
            return RedirectToAction("index4");
        } 
        public ViewResult index4()
        {
            return View();
            //here we get output of only price we dnt get name and id because of two request w request test5 there values are captured  then 
            // now control goes to index 4 and here view bag and view adata values are elianated becaus eit  cokes only for one request
        }

        public ViewResult test6(int ?id ,string name,string price)
        {
            TempData["id"] = id;
            TempData["name"] = name;
            TempData["price"] = price;
            return View();


        }
        public ViewResult display(int? id, string name, string price)
        {
            TempData["id"] = id;
            TempData["name"] = name;
            TempData["price"] = price;
            return View();


        }
        /// <summary>
        /// cokkies 
        /// </summary>
        public ViewResult displaycookie(int id, string name, string price)
        {
            HttpCookie logincookie = new HttpCookie("logincookie");

            logincookie["id"] = id.ToString();
            logincookie["name"] = name;
            logincookie["price"] = price;

            Response.Cookies.Add(logincookie);
            return View();
        }

        // these cookies are accesible thought the pages for test create another action controller 
        public ViewResult displaycookie2(int id, string name, string price)
        {
            
            return View();
        }

        //applicationway

        public ViewResult applicationview(int?id,string name,string price)
        {
            System.Web.HttpContext.Current.Application.Lock();
            //this application stat emmangement is a gobla scop so multuple users can  request to acess  the data at a time 
            // so at a time a request can come for update of data and another for manipilation 
            // so because of that if a request come we will lock it and untill all its work is done we unlock it so that othwersw
            // //will wait untill its unlock
            System.Web.HttpContext.Current.Application["id"] = id;
            System.Web.HttpContext.Current.Application["name"] = name;
            System.Web.HttpContext.Current.Application["price"] = price;
            System.Web.HttpContext.Current.Application.UnLock();
            return View();
        }


        ////
        //System.Web is the namespace containing classes for web applications.
        //HttpContext is a class within System.Web that provides context for the current HTTP request.
        //Current is a static property of HttpContext that retrieves the context of the current request.
        //Application is a property of HttpContext.Current that gives access to the application-wide state storage.
        //    //
        public ViewResult applicationview2(int? id, string name, string price)
        {
            return View();
        }

        // anonomous types

        public ViewResult anoymousresult(int?id,string name,string price)
        {
            var product = new { id = id, Name = name, price = price };
            // we can dirctly creta einstance without creating orginal 
            return View(product);
        }
            
    }

}