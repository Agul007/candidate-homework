using _3.BonusChallengeBLL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace _3.BonusChallenge_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetSimpleListAnagrams(List<string> words)
        {
            try
            {
                // Instantiate the AnagramFinder class, can be done using IoC as we do in .NET core. 
                var anagramFinder = new AnagramFinder();

                // Call the FindAnagrams method from the AnagramFinder class
                List<List<string>> result = anagramFinder.FindAnagrams(words);

                return Json(new { success = true, data = new { AnagramLists = result } });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}