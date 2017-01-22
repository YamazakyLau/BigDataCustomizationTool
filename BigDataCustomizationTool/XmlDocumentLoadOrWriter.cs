using System.Xml;
using System.Text;
using System.Windows.Forms;
using System;
using System.IO;

namespace BigDataCustomizationTool
{
    class XmlDocumentLoadOrWriter
    {
        /// <summary>
        /// BigDataCustomizationTool、TotalNum、IncreaseNumber、IncreaseTime、EqualLength、CreatingMethods
        /// </summary>
        public static void myMethodsXmlFilesWriter()
        {
            XmlTextWriter xmlWriter;
            string strFilename = "BigData.xml";

            xmlWriter = new XmlTextWriter(strFilename, Encoding.UTF8);//创建一个xml文档
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("BigDataCustomizationTool");//
            //--
            xmlWriter.WriteComment(" 设置总共要生成多少条数据 ");
            xmlWriter.WriteStartElement("TotalNum");//#,
            xmlWriter.WriteString(FormMain.GENERATE_TOTAL_NUMBER + "");
            xmlWriter.WriteEndElement();//!~--#,//TotalNum


       #region
            xmlWriter.WriteComment(" 递增整型变量设置，初始值Base(通常大于等于0,整数型)，递增值Incr(大于0,整数型) ");
            xmlWriter.WriteStartElement("IncreaseNumber");//#,
            //--//--
            xmlWriter.WriteStartElement("NumbA");//#,#,
            xmlWriter.WriteStartElement("BaseNumbA");//#,#,#,
            xmlWriter.WriteString(FormMain.ORIGINAL_NUMBER_AAAAA + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Base
            xmlWriter.WriteStartElement("IncrNumbA");//#,#,#,
            xmlWriter.WriteString(FormMain.INCREASE_NUMBER_AA + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Incr
            xmlWriter.WriteEndElement();//!~--#,#,//NumbA
            //--//--
            xmlWriter.WriteStartElement("NumbB");//#,#,
            xmlWriter.WriteStartElement("BaseNumbB");//#,#,#,
            xmlWriter.WriteString(FormMain.ORIGINAL_NUMBER_BBBBB + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Base
            xmlWriter.WriteStartElement("IncrNumbB");//#,#,#,
            xmlWriter.WriteString(FormMain.INCREASE_NUMBER_BB + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Incr
            xmlWriter.WriteEndElement();//!~--#,#,//NumbB
            //--//--
            xmlWriter.WriteStartElement("NumbC");//#,#,
            xmlWriter.WriteStartElement("BaseNumbC");//#,#,#,
            xmlWriter.WriteString(FormMain.ORIGINAL_NUMBER_CCCCC + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Base
            xmlWriter.WriteStartElement("IncrNumbC");//#,#,#,
            xmlWriter.WriteString(FormMain.INCREASE_NUMBER_CC + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Incr
            xmlWriter.WriteEndElement();//!~--#,#,//NumbC
            //--//--
            xmlWriter.WriteStartElement("NumbD");//#,#,
            xmlWriter.WriteStartElement("BaseNumbD");//#,#,#,
            xmlWriter.WriteString(FormMain.ORIGINAL_NUMBER_DDDDD + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Base
            xmlWriter.WriteStartElement("IncrNumbD");//#,#,#,
            xmlWriter.WriteString(FormMain.INCREASE_NUMBER_DD + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Incr
            xmlWriter.WriteEndElement();//!~--#,#,//NumbD
            //--//--
            xmlWriter.WriteStartElement("NumbE");//#,#,
            xmlWriter.WriteStartElement("BaseNumbE");//#,#,#,
            xmlWriter.WriteString(FormMain.ORIGINAL_NUMBER_EEEEE + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Base
            xmlWriter.WriteStartElement("IncrNumbE");//#,#,#,
            xmlWriter.WriteString(FormMain.INCREASE_NUMBER_EE + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Incr
            xmlWriter.WriteEndElement();//!~--#,#,//NumbE
            //--\\--\\
            xmlWriter.WriteEndElement();//!~--#,//IncreaseNumber
        #endregion


       #region
            xmlWriter.WriteComment(" 递增日期时间设置，初始值Base(字符串且符合\"yyyy-MM-dd HH:mm:ss\")，递增值Incr(大于0,整数型) ");
            xmlWriter.WriteStartElement("IncreaseTime");//#,
            //--//--
            xmlWriter.WriteStartElement("TimeA");//#,#,
            xmlWriter.WriteStartElement("BaseTimeA");//#,#,#,
            xmlWriter.WriteString(FormMain.ORIGINAL_DATETIME_AAAAA + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Base
            xmlWriter.WriteStartElement("IncrTimeA");//#,#,#,
            xmlWriter.WriteString(FormMain.INCREASE_DATETIME_AA + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Incr
            xmlWriter.WriteEndElement();//!~--#,#,//TimeA
            //--//--
            xmlWriter.WriteStartElement("TimeB");//#,#,
            xmlWriter.WriteStartElement("BaseTimeB");//#,#,#,
            xmlWriter.WriteString(FormMain.ORIGINAL_DATETIME_BBBBB + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Base
            xmlWriter.WriteStartElement("IncrTimeB");//#,#,#,
            xmlWriter.WriteString(FormMain.INCREASE_DATETIME_BB + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Incr
            xmlWriter.WriteEndElement();//!~--#,#,//TimeB
            //--//--
            xmlWriter.WriteStartElement("TimeC");//#,#,
            xmlWriter.WriteStartElement("BaseTimeC");//#,#,#,
            xmlWriter.WriteString(FormMain.ORIGINAL_DATETIME_CCCCC + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Base
            xmlWriter.WriteStartElement("IncrTimeC");//#,#,#,
            xmlWriter.WriteString(FormMain.INCREASE_DATETIME_CC + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Incr
            xmlWriter.WriteEndElement();//!~--#,#,//TimeC
            //--//--
            xmlWriter.WriteStartElement("TimeD");//#,#,
            xmlWriter.WriteStartElement("BaseTimeD");//#,#,#,
            xmlWriter.WriteString(FormMain.ORIGINAL_DATETIME_DDDDD + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Base
            xmlWriter.WriteStartElement("IncrTimeD");//#,#,#,
            xmlWriter.WriteString(FormMain.INCREASE_DATETIME_DD + "");
            xmlWriter.WriteEndElement();//!~--#,#,#,//Incr
            xmlWriter.WriteEndElement();//!~--#,#,//TimeD
            //--\\--\\
            xmlWriter.WriteEndElement();//!~--#,//IncreaseTime
        #endregion


            xmlWriter.WriteComment("是否需要保持参数值位数相等；值必须是\"yes\" 或 \"no\"；\n"
		        + "\t\t yes情形下显示“001”和“100”；no情形下显示1和100；\n"
		        + "\t\t 目前该功能不可用！");
            xmlWriter.WriteStartElement("EqualLength");//#,
            xmlWriter.WriteString("no");
            xmlWriter.WriteEndElement();//!~--#,//EqualLength


            xmlWriter.WriteComment(" 语法规则的具体内容 ");
            xmlWriter.WriteStartElement("CreatingMethods");//#,
            xmlWriter.WriteString(FormMain.GENERATE_CREATING_STR);
            xmlWriter.WriteEndElement();//!~--#,//CreatingMethods
            //--\\
            xmlWriter.WriteEndElement();//BigDataCustomizationTool

            xmlWriter.Close();
        }


        public static void myMethodsXmlFilesReader(string strFilePath)
        {
            //产生读取器,方式为一行一行的读取。
            XmlTextReader read;

            try
            {
                if (File.Exists(strFilePath))
                {
                    read = new XmlTextReader(strFilePath);

                    string keyValues = "";

                    //循环进行读取。
                    while (read.Read())
                    {
                        if (read.Name == "TotalNum")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.GENERATE_TOTAL_NUMBER = Convert.ToInt32(keyValues);
                        }
                    #region Note"初始数值和数值递增长"
                        else if (read.Name == "BaseNumbA")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.ORIGINAL_NUMBER_AAAAA = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "IncrNumbA")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.INCREASE_NUMBER_AA = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "BaseNumbB")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.ORIGINAL_NUMBER_BBBBB = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "IncrNumbB")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.INCREASE_NUMBER_BB = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "BaseNumbC")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.ORIGINAL_NUMBER_CCCCC = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "IncrNumbC")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.INCREASE_NUMBER_CC = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "BaseNumbD")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.ORIGINAL_NUMBER_DDDDD = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "IncrNumbD")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.INCREASE_NUMBER_DD = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "BaseNumbE")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.ORIGINAL_NUMBER_EEEEE = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "IncrNumbE")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.INCREASE_NUMBER_EE = Convert.ToInt32(keyValues);
                        }
                    #endregion
                    #region Note"初始时间和时间递增长"
                        else if (read.Name == "BaseTimeA")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.ORIGINAL_DATETIME_AAAAA = keyValues;
                        }
                        else if (read.Name == "IncrTimeA")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.INCREASE_DATETIME_AA = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "BaseTimeB")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.ORIGINAL_DATETIME_BBBBB = keyValues;
                        }
                        else if (read.Name == "IncrTimeB")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.INCREASE_DATETIME_BB = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "BaseTimeC")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.ORIGINAL_DATETIME_CCCCC = keyValues;
                        }
                        else if (read.Name == "IncrTimeC")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.INCREASE_DATETIME_CC = Convert.ToInt32(keyValues);
                        }
                        else if (read.Name == "BaseTimeD")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.ORIGINAL_DATETIME_DDDDD = keyValues;
                        }
                        else if (read.Name == "IncrTimeD")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.INCREASE_DATETIME_DD = Convert.ToInt32(keyValues);
                        }
                    #endregion
                        else if (read.Name == "EqualLength")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.GENERATE_EQUAL_LENGTH = keyValues;
                        }
                        else if (read.Name == "CreatingMethods")
                        {
                            keyValues = read.ReadElementString().Trim();
                            FormMain.GENERATE_CREATING_STR = keyValues;
                        }
                    }
                    
                    //关闭读取器。
                    read.Close();
                }
            }
            catch (Exception ex)
            {
                //加载过程出错！
                MessageBox.Show("导入过程中出现未知错误！系统报错信息为：\n\"" + ex.Message + "\"", "出错提醒",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}