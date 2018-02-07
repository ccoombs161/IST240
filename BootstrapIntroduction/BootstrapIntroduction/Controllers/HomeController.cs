using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapIntroduction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult CalcApp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalcApp(string ValA, String ValB, String Op)
        {
            int a = Convert.ToInt32(ValA);
            int b = Convert.ToInt32(ValB);
            int ans = 0;

            switch(Op)
            {
                case "Add":
                    ans = a + b;
                    break;
                case "Sub":
                    ans = a - b;
                    break;
                case "Multi":
                    ans = a * b;
                    break;
                case "Div":
                    ans = a / b;
                    break;
            }

            string model = Convert.ToString(ans);

            return View("CalcApp", (object)model);
        }
    }
}