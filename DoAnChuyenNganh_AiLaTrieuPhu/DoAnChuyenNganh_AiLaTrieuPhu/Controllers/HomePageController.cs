using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnChuyenNganh_AiLaTrieuPhu.Service;

namespace DoAnChuyenNganh_AiLaTrieuPhu.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            XmlDataReader doc = new XmlDataReader();
            doc.GetQuestion(1);
            return View();
        }
    }
}