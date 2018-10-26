using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnChuyenNganh_AiLaTrieuPhu.Models;
using DoAnChuyenNganh_AiLaTrieuPhu.Service;

namespace DoAnChuyenNganh_AiLaTrieuPhu.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            XmlDataService doc = new XmlDataService();

            //Lấy ds câu hỏi theo độ khó
            //doc.GetQuestion(1);

            //Thêm câu hỏi
            //QuestionModel question = new QuestionModel();
            //question.Question = "Câu hỏi 3";
            //question.Answer.Add("Đáp án A");
            //question.Answer.Add("Đáp án B");
            //question.Answer.Add("Đáp án C");
            //question.Answer.Add("Đáp án D");
            //question.CorrectAnswer = "Đáp án C";
            //doc.AddQuestion(question, 2); //Thêm câu hỏi theo độ khó
            return View();
        }
    }
}