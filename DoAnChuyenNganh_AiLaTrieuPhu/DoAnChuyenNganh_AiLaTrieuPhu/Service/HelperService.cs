using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnChuyenNganh_AiLaTrieuPhu.Service
{
    public class HelperService
    {
        //Trợ giúp 50/50
        //Truyền vào đáp án đúng, trả về đáp án bị loại bỏ
        //Đáp án đúng nằm trong khoảng 1-4
        public int FiftyHelp(int correctAnswer)
        {
            if (correctAnswer < 1 || correctAnswer > 4)
                return 0;
            Random rd = new Random();
            int answerRemoved = correctAnswer;
            while (answerRemoved == correctAnswer) //Nếu đáp án bị loại bằng đáp án đúng thì random lại
            {
                answerRemoved = rd.Next(1, 4);
            }
            return answerRemoved;
        }

        //Trợ giúp gọi điện thoại cho người thân
        //Truyền vầo đáp án đúng, trả về đáp án người thân chọn
        //Đáp án đúng nằm trong khoảng 1-4
        //Các đáp án sẽ random tỷ lệ 1-100, riêng đáp án đúng tỷ lệ từ 30-100
        //Tổng tỷ lệ 4 đáp án đúng = 100
        public List<int> CallToRelatives(int correctAnswer)
        {
            List<int> ratios = new List<int>(); //Thứ tự tỷ lệ của các đáp án: A-B-C-D
            if (correctAnswer < 1 || correctAnswer > 4)
                return ratios;
            Random rd = new Random();
            int maxRatio = 100; //Tổng tỷ lệ các đáp án = 100
            for (int i = 1; i < 5; i++)
            {
                int ratio;
                if (i == correctAnswer)
                {
                    ratio = rd.Next(30, maxRatio);
                }
                else
                {
                    ratio = rd.Next(0, maxRatio);
                }
                ratios.Add(ratio);
                maxRatio -= ratio;
            }
            return ratios;
        }

    }
}