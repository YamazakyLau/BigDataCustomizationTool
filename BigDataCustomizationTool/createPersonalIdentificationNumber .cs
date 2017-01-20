using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BigDataCustomizationTool
{
    class createPINCodes
    {
        //示例银行卡号（邮政绿卡头[6] + 年月日时分[8+4]）

        public static string createEighteenSFZNumber()
        {
            string cardInfo = "";

            DateTime dt = DateTime.Now;
            cardInfo = string.Format("{0:yyyyMMddHHmmss}", dt); ;//20051105140328;
            //生成身份证号码为（青海西宁市市辖区[5] + 秒[1] + 年月日时分秒[4+2+2+2+2+1]），如630101 20160708 
            cardInfo = "630" + cardInfo.Substring(11) + cardInfo.Substring(0, 11);

            return calculateEightneenthNumeber(cardInfo);
        }

        /// <summary>
        /// 计算第18位的字符，并返回可用的测试身份证号
        /// </summary>
        /// <param name="usefull">有效的数字串，尽量17位，不能小于、可以大于</param>
        /// <returns></returns>
        public static string calculateEightneenthNumeber(string usefull)
        {
            int sum = 0;
            string per = "", yushu = "";

            Regex reg = new Regex("\\d{17}");
            Match match = reg.Match(usefull);

            if (usefull.Length == 17 && match.Success)
            {

                for (int i = 0; i < 17; i++)
                {
                    per = usefull.Substring(i, 1);
                    switch (i)
                    {
                        case 0: sum += Convert.ToInt32(per) * 7; break;
                        case 1: sum += Convert.ToInt32(per) * 9; break;
                        case 2: sum += Convert.ToInt32(per) * 10; break;
                        case 3: sum += Convert.ToInt32(per) * 5; break;
                        case 4: sum += Convert.ToInt32(per) * 8; break;
                        case 5: sum += Convert.ToInt32(per) * 4; break;
                        case 6: sum += Convert.ToInt32(per) * 2; break;
                        case 7: sum += Convert.ToInt32(per) * 1; break;
                        case 8: sum += Convert.ToInt32(per) * 6; break;
                        case 9: sum += Convert.ToInt32(per) * 3; break;
                        case 10: sum += Convert.ToInt32(per) * 7; break;
                        case 11: sum += Convert.ToInt32(per) * 9; break;
                        case 12: sum += Convert.ToInt32(per) * 10; break;
                        case 13: sum += Convert.ToInt32(per) * 5; break;
                        case 14: sum += Convert.ToInt32(per) * 8; break;
                        case 15: sum += Convert.ToInt32(per) * 4; break;
                        case 16: sum += Convert.ToInt32(per) * 2; break;
                        default: break;
                    }
                }

                sum = sum % 11;
                //真正有用的不是和值，而是余数
                switch (sum)
                {
                    case 0: yushu = "1"; break;
                    case 1: yushu = "0"; break;
                    case 2: yushu = "X"; break;
                    case 3: yushu = "9"; break;
                    case 4: yushu = "8"; break;
                    case 5: yushu = "7"; break;
                    case 6: yushu = "6"; break;
                    case 7: yushu = "5"; break;
                    case 8: yushu = "4"; break;
                    case 9: yushu = "3"; break;
                    case 10: yushu = "2"; break;
                    default: break;
                }

                return usefull.Substring(0, 17) + yushu;
            }
            else
            {
                return "538327193608121812";//不能没有结果啊，36年的大爷应该不会撞号
            }
        }


        /// <summary>
        /// 输入一长度18位字符串，并输入当前排序号maxNumb即可按顺序输出身份证号
        /// comboBoxCreateTotal已经限制10位，所以最大maxNumb也不会超过10位？
        /// </summary>
        /// <param name="maxNumb">当前排序号</param>
        /// <returns></returns>
        public static string myMethodCreatePINNumber(int maxNumb)
        {
            //440117198309016440
            //21____19__021____?
            StringBuilder myNumb = new StringBuilder(maxNumb.ToString().PadLeft(10, '0'));

            myNumb.Insert(0, "21");
            myNumb.Insert(6, "19");
            myNumb.Insert(10, "021");

            return calculateEightneenthNumeber(myNumb.ToString());
        }
    }
}
