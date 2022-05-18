using FizzBuzzMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace FizzBuzzMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var number = new Number();           
            return View("Index", number);           //return View("Index", model);   // returns a View Model
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result(Number number, int? page)
        {

            if (number.NumberEntered >= 1 && number.NumberEntered <= 1000)
            {
                TempData["Message"] = "You have entered a valid number";  // Is this useful??
                var myrange = Enumerable.Range(1, number.NumberEntered);
                foreach (var value in myrange)
                {
                    number.AddNewNumberToMyListOfNumbers(value);
                }
                var result = GenerateGameResult(number);
                int pageSize = 20;
                int pageNumber = (page ?? 1); // if this page parameter has a value of null, use a val of 1, otherwise, whatever val is present
                var mymodel = from item in result select item;
                //return View("Result", mymodel.ToPagedList(pageNumber, pageSize));
                return View("Result", result);

                //return View("Result", result.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                //ModelState.AddModelError(nameof(number.NumberEntered), "You have not entered a valid number, please, try again");
                //RedirectToAction("Index", number);

                TempData["Message"] = "You have not entered a valid number, please, try again";
                return View("InvalidInput", number); // RedirectToAction("Index", number); //
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult FinalResult(Number number, int? page)
        //{

        //    if (number.NumberEntered >= 1 && number.NumberEntered <= 1000)
        //    {
        //        TempData["Message"] = "You have entered a valid number";  // Is this useful??
        //        var myrange = Enumerable.Range(1, number.NumberEntered);
        //        foreach (var value in myrange)
        //        {
        //            number.AddNewNumberToMyListOfNumbers(value);
        //        }
        //        //var result = new GameResult();
        //        var result = GenerateGameResult(number);
        //        int pageSize = 20;
        //        int pageNumber = (page ?? 1); // if this page parameter has a value of null, use a val of 1, otherwise, whatever val is present
        //        return View("FinalResult", result.ToPagedList(pageNumber, pageSize));
        //    }
        //    else
        //    {
        //        //ModelState.AddModelError(nameof(number.NumberEntered), "You have not entered a valid number, please, try again");
        //        //RedirectToAction("Index", number);

        //        //TempData["Message"] = "You have not entered a valid number, please, try again";
        //        return View("InvalidInput", number); // RedirectToAction("Index", number); //
        //    }
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<string> GenerateGameResult(Number number)
        {
            var storedresult = new List<string>();

            if (number.DayToday == DayOfWeek.Wednesday)
            {
                foreach (var value in number.MyListOfNumbers)
                {
                    if ((value % 3) == 0 && (value % 5) == 0)
                    {
                        storedresult.Add("wizz wuzz");
                    }
                    else if (value % 3 == 0)
                    {
                        storedresult.Add("wizz");
                    }
                    else if (value % 5 == 0)
                    {
                        storedresult.Add("wuzz");
                    }
                    else
                    {
                        storedresult.Add(value.ToString());
                    }
                }
            }
            else
            {
                foreach (var value in number.MyListOfNumbers)
                {
                    if ((value % 3) == 0 && (value % 5) == 0)
                    {
                        storedresult.Add("fizz buzz");
                    }
                    else if ((value % 3 == 0))
                    {
                        storedresult.Add("fizz");
                    }
                    else if ((value % 5 == 0))
                    {
                        storedresult.Add("buzz");
                    }
                    else
                    {
                        storedresult.Add(value.ToString());
                    }
                }
            }

            return storedresult;
        }
    }
}

// It is the responsability of controllers to determine how to respond to an specific HTTP request from the browser (for example, by presenting a view)
// Controllers build Models containing all the information that a View is going to present.

//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Result(Number number)
//{

//    if (number.NumberEntered >= 1 && number.NumberEntered <= 1000)
//    {
//        TempData["Message"] = "You have entered a valid number";  // Is this useful??
//        var myrange = Enumerable.Range(1, number.NumberEntered);
//        foreach (var value in myrange)
//        {
//            number.AddNewNumberToMyListOfNumbers(value);
//        }
//        var result = new GameResult();
//        result.GenerateGameResult(number);
//        return View("Result", result);  // same as = return View(number);
//    }
//    else
//    {
//        //ModelState.AddModelError(nameof(number.NumberEntered), "You have not entered a valid number, please, try again");
//        //RedirectToAction("Index", number);

//        TempData["Message"] = "You have not entered a valid number, please, try again";
//        return View("InvalidInput", number); // RedirectToAction("Index", number); //
//    }
//}

//v2

//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Result(Number number)
//{

//    if (number.NumberEntered >= 1 && number.NumberEntered <= 1000)
//    {
//        TempData["Message"] = "You have entered a valid number";  // Is this useful??
//        var myrange = Enumerable.Range(1, number.NumberEntered);
//        foreach (var value in myrange)
//        {
//            number.AddNewNumberToMyListOfNumbers(value);
//        }
//        var result = GenerateGameResult(number);
//        return View("Result", result);
//    }
//    else
//    {
//        //ModelState.AddModelError(nameof(number.NumberEntered), "You have not entered a valid number, please, try again");
//        //RedirectToAction("Index", number);

//        TempData["Message"] = "You have not entered a valid number, please, try again";
//        return View("InvalidInput", number); // RedirectToAction("Index", number); //
//    }
//}