using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using DoAnChuyenNganh_AiLaTrieuPhu.Models;
using Newtonsoft.Json;

namespace DoAnChuyenNganh_AiLaTrieuPhu.Service
{
    public class XmlDataReader
    {
        private List<QuestionModel> Questions { get; set; }
        public List<QuestionModel> GetQuestion(int level)
        {
            Questions = new List<QuestionModel>();
            //Get question from file xml
            var filepath = AppDomain.CurrentDomain.BaseDirectory;
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
    }
}