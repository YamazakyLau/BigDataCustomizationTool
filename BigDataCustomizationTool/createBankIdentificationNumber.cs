using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BigDataCustomizationTool
{
    class createBINCodes
    {
        //示例银行卡号（邮政绿卡头[6] + 年月日时分[8+4]）
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string createNineteenAccountNumber()
        {
            string bankInfor = "";
            
            DateTime dt = DateTime.Now;
            bankInfor = string.Format("{0:yyyyMMddHHmmss}", dt); ;//200511051403;
            //生成银行卡号为（邮政绿卡头[4] + 秒[2] + 年月日时分[8+4]），如622199 20160708 1401
            bankInfor = "6221" + bankInfor.Substring(12) + bankInfor.Substring(0, 12);

            return calculateNineteenthCharacter(bankInfor);
        }


        /// <summary>
        /// 计算第19位的数字，并返回可用的测试银行卡号
        /// comboBoxCreateTotal已经限制10位，所以最大maxNumb也不会超过10位？
        /// </summary>
        /// <param name="eighteen">前18位数字</param>
        /// <returns>完整的长度为19位号码串</returns>
        public static string calculateNineteenthCharacter(string eighteen)
	    {
		    int[] calN = new int[18] {1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2};
		    int numI = 0, sum = 0;

            Regex reg = new Regex("\\d{18}");
            Match match = reg.Match(eighteen);

            if (eighteen.Length == 18 && match.Success)
		    {
			    for(int i=0; i<18; i++)
			    {
                    numI = Convert.ToInt32(eighteen.Substring(i, 1));
				    numI = numI * calN[i];
				    sum += numI/10 + numI%10;
			    }
    			
			    sum = 10 - sum%10;
			    if(sum == 10)
			    {
				    sum = 0;
			    }
		    }
		    else
		    {
                return "6228481698729890079";//不能没有结果啊,网上一搜就出来的
		    }
		    return eighteen + sum;
	    }



        /// <summary>
        /// 输入一长度18位字符串，并输入当前排序号maxNumb即可按顺序输出身份证号
        /// </summary>
        /// <param name="maxNumb">当前排序号</param>
        /// <returns></returns>
        public static string myMethodCreateBINNumber(int maxNumb)
        {
            //6228481698729890079
            //21____19__021____?
            StringBuilder myNumb = new StringBuilder(maxNumb.ToString().PadLeft(10, '0'));
            myNumb.Insert(0, "62257720");

            return calculateNineteenthCharacter(myNumb.ToString());
        }
    }
}
