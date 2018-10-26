using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using DoAnChuyenNganh_AiLaTrieuPhu.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace DoAnChuyenNganh_AiLaTrieuPhu.Service
{
    public class XmlDataService
    {
        private List<QuestionModel> Questions { get; set; }
        private string filepath = AppDomain.CurrentDomain.BaseDirectory;
        public List<QuestionModel> GetQuestion(int level)
        {
            Questions = new List<QuestionModel>();
            //Get question from file xml
            //var filepath = AppDomain.CurrentDomain.BaseDirectory;
            XDocument doc = XDocument.Load(filepath + @"/Data/XML_QuestionData.xml");
            var question = doc.Descendants("Question");

            foreach (var item in question)
            {
                QuestionModel Question = new QuestionModel();
                Question.Question = item.LastAttribute.Value;
                var lev = item.FirstAttribute.Value;

                foreach (var i in item.Descendants("Ans"))
                {
                    if (i.Attribute("correct").Value == "true")
                    {
                        Question.CorrectAnswer = i.Value;
                    }
                    Question.Answer.Add(i.Value);
                }
                Questions.Add(Question);
            }
            return Questions;
        }

        public void AddQuestion(QuestionModel question, int level)
        {
            DateTime st = new DateTime(2018,10, 26, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan t = (DateTime.Now.ToUniversalTime() - st);
            double s = t.TotalMilliseconds;

            XDocument doc = XDocument.Load(filepath + @"/Data/XML_QuestionData.xml");
            XElement root = new XElement("Question");
            root.Add(new XAttribute("id", s));
            root.Add(new XAttribute("level", level.ToString()));
            root.Add(new XAttribute("value", question.Question));
            foreach (var item in question.Answer)
            {
                XElement ans = new XElement("Ans",item);
                if (item == question.CorrectAnswer)
                {
                    ans.Add(new XAttribute("correct", "true"));
                }
                else
                {
                    ans.Add(new XAttribute("correct", "false"));
                }
                root.Add(ans);
            }
            doc.Element("Questions").Add(root);
            doc.Save(filepath + @"/Data/XML_QuestionData.xml");
        }
    }
}