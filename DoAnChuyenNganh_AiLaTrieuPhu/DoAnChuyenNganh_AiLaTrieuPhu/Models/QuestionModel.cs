using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_AiLaTrieuPhu.Models
{
    public class QuestionModel
    {
        public string Question { get; set; }
        public List<string> Answer { get; set; } = new List<string>();
        public string CorrectAnswer { get; set; }
    }
}