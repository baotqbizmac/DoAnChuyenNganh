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

        //Trợ giúp hỏi ý kiến khán giả
        //Truyền vầo đáp án đúng, trả về danh sách tỷ lệ
        //Các đáp án sẽ random tỷ lệ 1-100, riêng đáp án đúng tỷ lệ từ 30-100
        //Tổng tỷ lệ 4 đáp án đúng = 100
        public int[] AskAudience(int correctAnswer)
        {
            int[] ratios = { 0, 0, 0, 0 };
            if (correctAnswer < 1 || correctAnswer > 4)
                return ratios;
            int max = 80;
            Random rd = new Random();
            for (int i = 1; i < 5; i++)
            {
                int random = rd.Next(0, max);
                if (i == correctAnswer)
                    ratios[i] += 20 + random;
                else
                    ratios[i] += random;
                max -= random;
            }
            ratios[correctAnswer] += max;
            return ratios;
        }

        //Trợ giúp gọi điện người thân
        //Truyền vào đáp án đúng, trả về đáp án có tỷ lệ cao nhất
        public int CallToRelatives(int correctAnswer)
        {
            int[] ratios = { 0, 0, 0, 0 };
            if (correctAnswer < 1 || correctAnswer > 4)
                return 0;

            int maxAns = 0; //Tỷ lệ cao nhất
            int maxAnsIndex = 1; //Vị trí đáp án có tỷ lệ cao nhất
            Random rd = new Random();

            for (int i = 1; i < 5; i++)
            {
                if (i == correctAnswer)
                    ratios[i] += 30 + rd.Next(0, 100);
                else
                    ratios[i] += rd.Next(0, 100);

                if (i == 1)
                    maxAns = ratios[i];
                else
                {
                    if (maxAns < ratios[i])
                    {
                        maxAns = ratios[i];
                        maxAnsIndex = i;
                    }
                }
            }
            return maxAnsIndex;
        }
    }
}