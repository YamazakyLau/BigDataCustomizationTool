using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;

namespace BigDataCustomizationTool
{
    public partial class FormMain : Form
    {
    #region
        /// <summary>
        /// 总共要生成多少条数据，不计算内循环翻倍；comboBoxCreateTotal
        /// </summary>
        public static int GENERATE_TOTAL_NUMBER = 0;
        /// <summary>
        /// 基本生成语法；textBoxCreatingMethods
        /// </summary>
        public static string GENERATE_CREATING_STR = "";
        /// <summary>
        /// 是否需要初始数值位数相等？（或者说长度相等，不足前补0，例如"001"和"100"）
        /// </summary>
        public static string GENERATE_EQUAL_LENGTH = "no";
        /// <summary>
        /// 初始号码A、B、C、D、E
        /// </summary>
        public static int ORIGINAL_NUMBER_AAAAA = 0;
        public static int ORIGINAL_NUMBER_BBBBB = 0;
        public static int ORIGINAL_NUMBER_CCCCC = 0;
        public static int ORIGINAL_NUMBER_DDDDD = 0;
        public static int ORIGINAL_NUMBER_EEEEE = 0;
        public static int INCREASE_NUMBER_AA = 0;
        public static int INCREASE_NUMBER_BB = 0;
        public static int INCREASE_NUMBER_CC = 0;
        public static int INCREASE_NUMBER_DD = 0;
        public static int INCREASE_NUMBER_EE = 0;
        /// <summary>
        /// 初始时间A、B、C、D
        /// </summary>
        public static string ORIGINAL_DATETIME_AAAAA = "";
        public static string ORIGINAL_DATETIME_BBBBB = "";
        public static string ORIGINAL_DATETIME_CCCCC = "";
        public static string ORIGINAL_DATETIME_DDDDD = "";
        public static int INCREASE_DATETIME_AA = 0;
        public static int INCREASE_DATETIME_BB = 0;
        public static int INCREASE_DATETIME_CC = 0;
        public static int INCREASE_DATETIME_DD = 0;
        /// <summary>
        /// 随机中文姓名
        /// </summary>
        public static string RANDOM_CHINESE_NAME = "";
        /// <summary>
        /// 生成身份证号码18位
        /// </summary>
        public static string CREATE_PIN_CODENUMB = "";
        /// <summary>
        /// 生成银行卡号码19位
        /// </summary>
        public static string CREATE_BIN_CODENUMB = "";
        /// <summary>
        /// 定制化手机号码
        /// </summary>
        public static string CUSTOMIZED_MOB_NUMB = "";
    #endregion
    
    #region
        /// <summary>
        /// 全局不可变字段，存在于输入语法规则中，用于正则、查找和替换。
        /// 自增数字
        /// </summary>
        public readonly static string REGEX_ORINUM_AAAAA = "{NumbA}";
        public readonly static string REGEX_ORINUM_BBBBB = "{NumbB}";
        public readonly static string REGEX_ORINUM_CCCCC = "{NumbC}";
        public readonly static string REGEX_ORINUM_DDDDD = "{NumbD}";
        public readonly static string REGEX_ORINUM_EEEEE = "{NumbE}";
        /// <summary>
        /// 全局不可变字段，存在于输入语法规则中，用于正则、查找和替换。
        /// 自增时间
        /// </summary>
        public readonly static string REGEX_DATETM_AAAAA = "{TimeA}";
        public readonly static string REGEX_DATETM_BBBBB = "{TimeB}";
        public readonly static string REGEX_DATETM_CCCCC = "{TimeC}";
        public readonly static string REGEX_DATETM_DDDDD = "{TimeD}";
        /// <summary>
        /// 全局不可变字段，存在于输入语法规则中，用于正则、查找和替换
        /// </summary>
        public readonly static string REGEX_CHN_NAME = "{FullN}";
        public readonly static string REGEX_MOB_NUMB = "{MobiN}";
        public readonly static string REGEX_PIN_NUMB = "{PINcN}";
        public readonly static string REGEX_BIN_NUMB = "{BINnb}";
    #endregion

    #region
        public static bool IS_ORI_NUMB_00AA = false;
        public static bool IS_ORI_NUMB_00BB = false;
        public static bool IS_ORI_NUMB_00CC = false;
        public static bool IS_ORI_NUMB_00DD = false;
        public static bool IS_ORI_NUMB_00EE = false;

        public static bool IS_ORI_TIME_00AA = false;
        public static bool IS_ORI_TIME_00BB = false;
        public static bool IS_ORI_TIME_00CC = false;
        public static bool IS_ORI_TIME_00DD = false;

        public static bool IS_RANDOM_CNNAME = false;
        public static bool IS_CREATE_PINNUM = false;
        public static bool IS_CREATE_BINNUM = false;
        public static bool IS_CUST_MOB_NUMB = false;

    #endregion

    #region
        /// <summary>
        /// 增量值，记录总共生成了多少条数据，与【0，GENERATE_TOTAL_NUMBER）区间对应。
        /// </summary>
        public static int INCREASE_TOTAL_NUMBER = 0;
        /// <summary>
        /// 内存常量，用于写入时直接从内存读取！
        /// </summary>
        public static StringBuilder myWriteStrBd;

        //public AutoResetEvent are = new AutoResetEvent(false);
        public static bool isIncreaseThreadRun = false;
    #endregion


        public FormMain()
        {
            InitializeComponent();
        }


        private void buttonCreateDataTest_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBoxCreatingMethods.Text == "")
                {//一切为了演示效果！
                    this.textBoxCreatingMethods.Text = "INSERT INTO `credit`.`user` VALUES ('{NumbA}', '{NumbB}', '{NumbC}', "
                    + "'{NumbD}', '{NumbE}', '{TimeA}', '{TimeB}', '{TimeC}', '{TimeD}', '{FullN}', '{MobiN}', '{PINcN}', '{BINnb}');";
                }

                initLocalVariables();
                replaceAllParamsNow();

                MessageBox.Show("陛下，请您圣裁？", "完成提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch (Exception)
            {
                MessageBox.Show("抱歉，程序执行过程中出现异常，原因不明，建议您与设计该软件的程序猿童鞋联系！", "特殊异常",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonCreateDataNow_Click(object sender, EventArgs e)
        {
            if (isIncreaseThreadRun)
            {
                MessageBox.Show("抱歉，程序仍有任务在后台执行，请稍后尝试！\n本次执行指令将无效！", "程序需要等待",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//防止异步执行未结束，再次操作！
            }

            isIncreaseThreadRun = true;

            try
            {
                string fileName = "";
                if (this.textBoxCreateFileName.Text != "" && this.textBoxCreateFileName.Text.Length > 0)
                { fileName = this.textBoxCreateFileName.Text + ".txt"; }
                else
                { fileName = "BigDataPrint.txt"; }

                FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate);
                aFile.Close();//因为后面都是Append的方式操作，先试试有木有文件！

                initLocalVariables();

                Thread thread = new Thread(xunHuanJiSuanIng);
                thread.Priority = ThreadPriority.AboveNormal;
                thread.IsBackground = true;
                thread.Start();

                /*
                //进度条相关动作
                Thread thrdPro = new Thread(updateProcessBar);
                thrdPro.Priority = ThreadPriority.AboveNormal;
                thrdPro.IsBackground = true;
                thrdPro.Start();
                */
            }
            catch (Exception)
            {
                MessageBox.Show("抱歉，程序执行过程中出现异常，原因不明，建议您与设计该软件的程序猿童鞋联系！", "特殊异常",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                isIncreaseThreadRun = false;
            }
        }


        private void textBoxCreatingMethods_DoubleClicked(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //new一个方法

            //"(*.et;*.xls;*.xlsx)|*.et;*.xls;*.xlsx|all|*.*"---------------如果要多种选择
            ofd.Filter = "(*.xml|*.xml";//删选、设定文件显示类型
            ofd.ShowDialog(); //显示打开文件的窗口
            this.textBoxCreatingMethods.Text = ofd.FileName;//在输入框中显示xml文档路径信息
        }


        private void initLocalVariables()
        {
            try
            {
                myWriteStrBd = new StringBuilder(this.textBoxCreatingMethods.Text);
                GENERATE_CREATING_STR = this.textBoxCreatingMethods.Text;
                if (this.checkBoxEqualLength.Checked == false)
                { GENERATE_EQUAL_LENGTH = "no"; }
                else
                { GENERATE_EQUAL_LENGTH = "yes"; }
                GENERATE_TOTAL_NUMBER = Convert.ToInt32(this.comboBoxCreateTotal.Text);

                ORIGINAL_NUMBER_AAAAA = Convert.ToInt32(this.textBoxBasedNumbA.Text);
                ORIGINAL_NUMBER_BBBBB = Convert.ToInt32(this.textBoxBasedNumbB.Text);
                ORIGINAL_NUMBER_CCCCC = Convert.ToInt32(this.textBoxBasedNumbC.Text);
                ORIGINAL_NUMBER_DDDDD = Convert.ToInt32(this.textBoxBasedNumbD.Text);
                ORIGINAL_NUMBER_EEEEE = Convert.ToInt32(this.textBoxBasedNumbE.Text);
                INCREASE_NUMBER_AA = Convert.ToInt32(this.comboBoxIncreaseNumbA.Text);
                INCREASE_NUMBER_BB = Convert.ToInt32(this.comboBoxIncreaseNumbB.Text);
                INCREASE_NUMBER_CC = Convert.ToInt32(this.comboBoxIncreaseNumbC.Text);
                INCREASE_NUMBER_DD = Convert.ToInt32(this.comboBoxIncreaseNumbD.Text);
                INCREASE_NUMBER_EE = Convert.ToInt32(this.comboBoxIncreaseNumbE.Text);

                ORIGINAL_DATETIME_AAAAA = this.dateTimePickerBasedTimeA.Text;
                ORIGINAL_DATETIME_BBBBB = this.dateTimePickerBasedTimeB.Text;
                ORIGINAL_DATETIME_CCCCC = this.dateTimePickerBasedTimeC.Text;
                ORIGINAL_DATETIME_DDDDD = this.dateTimePickerBasedTimeD.Text;
                INCREASE_DATETIME_AA = Convert.ToInt32(this.textBoxIncreaseTimeA.Text);
                INCREASE_DATETIME_BB = Convert.ToInt32(this.textBoxIncreaseTimeB.Text);
                INCREASE_DATETIME_CC = Convert.ToInt32(this.textBoxIncreaseTimeC.Text);
                INCREASE_DATETIME_DD = Convert.ToInt32(this.textBoxIncreaseTimeD.Text);

                //其它
                INCREASE_TOTAL_NUMBER = 0;//防止用户不退出软件重复使用过程中，该变更未归零引起异常！
                RANDOM_CHINESE_NAME = this.comboBoxOtSurname.Items[0].ToString() + this.comboBoxOtSurname.Items[0].ToString();
                CREATE_PIN_CODENUMB = createPINCodes.myMethodCreatePINNumber(INCREASE_TOTAL_NUMBER);
                CREATE_BIN_CODENUMB = createBINCodes.myMethodCreateBINNumber(INCREASE_TOTAL_NUMBER);
                StringBuilder myNumb = new StringBuilder(INCREASE_TOTAL_NUMBER.ToString().PadLeft(9, '0'));//10
                //如果生成数据达到10位，可能会重复！
                myNumb.Insert(0, "13");
                CUSTOMIZED_MOB_NUMB = myNumb.ToString();

                isContainCurrentVariables();
            }
            catch (Exception)
            {
                MessageBox.Show("抱歉，你设置的初始参数有误，或初始化过程中出现异常错误，建议您检查设置数值后重试一次！\n", "出错提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void isContainCurrentVariables()
        {
            string myMethodsStr = this.textBoxCreatingMethods.Text;

            if (myMethodsStr.Contains(REGEX_ORINUM_AAAAA)) { IS_ORI_NUMB_00AA = true; }
            if (myMethodsStr.Contains(REGEX_ORINUM_BBBBB)) { IS_ORI_NUMB_00BB = true; }
            if (myMethodsStr.Contains(REGEX_ORINUM_CCCCC)) { IS_ORI_NUMB_00CC = true; }
            if (myMethodsStr.Contains(REGEX_ORINUM_DDDDD)) { IS_ORI_NUMB_00DD = true; }
            if (myMethodsStr.Contains(REGEX_ORINUM_EEEEE)) { IS_ORI_NUMB_00EE = true; }
            if (myMethodsStr.Contains(REGEX_DATETM_AAAAA)) { IS_ORI_TIME_00AA = true; }
            if (myMethodsStr.Contains(REGEX_DATETM_BBBBB)) { IS_ORI_TIME_00BB = true; }
            if (myMethodsStr.Contains(REGEX_DATETM_CCCCC)) { IS_ORI_TIME_00CC = true; }
            if (myMethodsStr.Contains(REGEX_DATETM_DDDDD)) { IS_ORI_TIME_00DD = true; }
            if (myMethodsStr.Contains(REGEX_CHN_NAME)) { IS_RANDOM_CNNAME = true; }
            if (myMethodsStr.Contains(REGEX_MOB_NUMB)) { IS_CUST_MOB_NUMB = true; }
            if (myMethodsStr.Contains(REGEX_PIN_NUMB)) { IS_CREATE_PINNUM = true; }
            if (myMethodsStr.Contains(REGEX_MOB_NUMB)) { IS_CREATE_BINNUM = true; }
        }


        private void replaceAllParamsNow()
        {
            myWriteStrBd.Replace(REGEX_ORINUM_AAAAA, ORIGINAL_NUMBER_AAAAA.ToString());
            myWriteStrBd.Replace(REGEX_ORINUM_BBBBB, ORIGINAL_NUMBER_BBBBB.ToString());
            myWriteStrBd.Replace(REGEX_ORINUM_CCCCC, ORIGINAL_NUMBER_CCCCC.ToString());
            myWriteStrBd.Replace(REGEX_ORINUM_DDDDD, ORIGINAL_NUMBER_DDDDD.ToString());
            myWriteStrBd.Replace(REGEX_ORINUM_EEEEE, ORIGINAL_NUMBER_EEEEE.ToString());

            myWriteStrBd.Replace(REGEX_DATETM_AAAAA, ORIGINAL_DATETIME_AAAAA);
            myWriteStrBd.Replace(REGEX_DATETM_BBBBB, ORIGINAL_DATETIME_BBBBB);
            myWriteStrBd.Replace(REGEX_DATETM_CCCCC, ORIGINAL_DATETIME_CCCCC);
            myWriteStrBd.Replace(REGEX_DATETM_DDDDD, ORIGINAL_DATETIME_DDDDD);

            myWriteStrBd.Replace(REGEX_CHN_NAME, RANDOM_CHINESE_NAME);
            myWriteStrBd.Replace(REGEX_MOB_NUMB, CUSTOMIZED_MOB_NUMB);
            myWriteStrBd.Replace(REGEX_PIN_NUMB, CREATE_PIN_CODENUMB);
            myWriteStrBd.Replace(REGEX_BIN_NUMB, CREATE_BIN_CODENUMB);

            //Thread write = new Thread(new ThreadStart(fileStreamWriteData));
            //write.IsBackground = true;

            fileStreamWriteData(myWriteStrBd);//执行写入操作！
            myWriteStrBd = new StringBuilder(this.textBoxCreatingMethods.Text);//要恢复成旧的，不然生成一堆一样的
        }


        private void autoIncreaseParamsCalculate()
        {
            DateTime dt = new DateTime();
            int xunHuan = INCREASE_TOTAL_NUMBER % 40000;
            int xing = xunHuan / 200;
            int ming = xunHuan % 200;
            //整型
            if (IS_ORI_NUMB_00AA)
            {
                ORIGINAL_NUMBER_AAAAA += INCREASE_NUMBER_AA;
            }
            if (IS_ORI_NUMB_00BB)
            {
                ORIGINAL_NUMBER_BBBBB += INCREASE_NUMBER_BB;
            }
            if (IS_ORI_NUMB_00CC)
            {
                ORIGINAL_NUMBER_CCCCC += INCREASE_NUMBER_CC;
            }
            if (IS_ORI_NUMB_00DD)
            {
                ORIGINAL_NUMBER_DDDDD += INCREASE_NUMBER_DD;
            }
            if (IS_ORI_NUMB_00EE)
            {
                ORIGINAL_NUMBER_EEEEE += INCREASE_NUMBER_EE;
            }
            //时间
            if (IS_ORI_TIME_00AA)
            {
                dt = Convert.ToDateTime(ORIGINAL_DATETIME_AAAAA);
                dt = dt.AddSeconds(INCREASE_DATETIME_AA);
                ORIGINAL_DATETIME_AAAAA = dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (IS_ORI_TIME_00BB)
            {
                dt = Convert.ToDateTime(ORIGINAL_DATETIME_BBBBB);
                dt = dt.AddSeconds(INCREASE_DATETIME_BB);
                ORIGINAL_DATETIME_BBBBB = dt.ToString("yyyy-MM-dd HH:mm:ss");
            } 
            if (IS_ORI_TIME_00CC)
            {
                dt = Convert.ToDateTime(ORIGINAL_DATETIME_CCCCC);
                dt = dt.AddSeconds(INCREASE_DATETIME_CC);
                ORIGINAL_DATETIME_CCCCC = dt.ToString("yyyy-MM-dd HH:mm:ss");
            } 
            if (IS_ORI_TIME_00DD)
            {
                dt = Convert.ToDateTime(ORIGINAL_DATETIME_DDDDD);
                dt = dt.AddSeconds(INCREASE_DATETIME_DD);
                ORIGINAL_DATETIME_DDDDD = dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            //其它
            if (IS_RANDOM_CNNAME)
            {
                RANDOM_CHINESE_NAME = this.comboBoxOtSurname.Items[xing].ToString() + this.comboBoxOtName.Items[ming + 1].ToString();
            }
            if (IS_CREATE_PINNUM)
            {
                CREATE_PIN_CODENUMB = createPINCodes.myMethodCreatePINNumber(INCREASE_TOTAL_NUMBER + 1);
            }
            if (IS_CREATE_BINNUM)
            {
                CREATE_BIN_CODENUMB = createBINCodes.myMethodCreateBINNumber(INCREASE_TOTAL_NUMBER + 1);
            }
            if (IS_CUST_MOB_NUMB)
            {
                StringBuilder myNumb = new StringBuilder((INCREASE_TOTAL_NUMBER + 1).ToString().PadLeft(9, '0'));//10
                //如果生成数据达到10位，可能会重复！
                myNumb.Insert(0, "13");

                CUSTOMIZED_MOB_NUMB = myNumb.ToString();
            }
        }


        private void buttonOtHelpCircleItems_Click(object sender, EventArgs e)
        {
            MessageBox.Show("使用帮助正在完善中！", "使用帮助",
                    MessageBoxButtons.OK, MessageBoxIcon.Question);
        }


        private void fileStreamWriteData(StringBuilder data)
        {
            string fileName = "";
            if (this.textBoxCreateFileName.Text != "" && this.textBoxCreateFileName.Text.Length > 0)
            {fileName = this.textBoxCreateFileName.Text + ".txt";}
            else
            {fileName = "BigDataPrint.txt";}

            FileStream aFile = new FileStream(fileName, FileMode.Append);
            StreamWriter sw = new StreamWriter(aFile);
            // Write data to file.
            sw.WriteLine(data.ToString());
            
            //结束写入
            sw.Close();
            aFile.Close();
        }


        private void xunHuanJiSuanIng()
        {
            DateTime beforDT = System.DateTime.Now;//开始计时，并记录时间

            for (int i = 0; i < GENERATE_TOTAL_NUMBER; i++)
            {
                INCREASE_TOTAL_NUMBER = i;

                replaceAllParamsNow();
                autoIncreaseParamsCalculate();

                /*
                //设想，每个线程已经结果则进入下一轮！
                Thread thReplace = new Thread(new ThreadStart(replaceAllParamsNow));
                Thread thAutoInc = new Thread(new ThreadStart(autoIncreaseParamsCalculate));
                thReplace.Priority = ThreadPriority.AboveNormal;
                thAutoInc.Priority = ThreadPriority.AboveNormal;
                thAutoInc.IsBackground = true;
                thReplace.IsBackground = true;
                    
                thReplace.Start();//替换并写入文档！

                thAutoInc.Start();//更新变量，准备下一次替换！
                 * 

                //进度条相关动作
                this.progressBarCreateStatus.PerformStep();
                process = i / length;
                show = (int)process * 100;*/
            }

            DateTime afterDT = System.DateTime.Now;//结束计时，并再次记录时间
            TimeSpan ts = afterDT.Subtract(beforDT);//计算时间间隔！
            //this.progressBarCreateStatus.Visible = false;//进度条隐藏
            
            showEndMessage(ts);
        }


        private void showEndMessage(TimeSpan ts)
        {
            MessageBox.Show("陛下，小的已经搞定了，可以收工了不？\n总计耗时为：" + ts.TotalSeconds + "秒！", "执行完毕",
                MessageBoxButtons.OK, MessageBoxIcon.Question);

            isIncreaseThreadRun = false;
        }


        private void updateProcessBar()
        {
            //进度条相关动作
            int length = INCREASE_TOTAL_NUMBER;
            this.progressBarCreateStatus.Visible = true;//显示进度条
            this.progressBarCreateStatus.Minimum = 0;
            this.progressBarCreateStatus.Maximum = length;
            double process = 0;
            int show = 0;

            this.progressBarCreateStatus.PerformStep();
            process = INCREASE_TOTAL_NUMBER / length;
            show = (int)process * 100;
            if (INCREASE_TOTAL_NUMBER == GENERATE_TOTAL_NUMBER)
            {
                //this.progressBarCreateStatus.Visible = false;
            }

        }


        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            initLocalVariables();//有可能用户过程中变更过设定值，因此再次初始化。

            XmlDocumentLoadOrWriter.myMethodsXmlFilesWriter();

            MessageBox.Show("保存完毕！", "温馨提示",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void buttonLoadFromXML_Click(object sender, EventArgs e)
        {
            //初步判断路径是否合法：
            string filePath = this.textBoxCreatingMethods.Text;
            if (filePath != "")
            {
                filePath = filePath.Replace("\\", "\\\\");//路径显示与String表达不一样，需要加两个“\\”
            }
            else//filePath
            {
                //路径为空就不需要执行后续步骤了！
                MessageBox.Show("文档路径不正确或无法读取！请双击【语法规则】输入框后重新选择文件！", "提醒",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Regex reg = new Regex(filePath);
            //Regex reg = new Regex("F:\\\\C#Projects\\\\BigDataCustomizationTool\\\\BigDataCustomizationTool\\\\bin\\Debug\\\\BigData.xml");
            Match matchStr = reg.Match("[a-z]|[A-Z]{1}(:\\).*?(.xml)");//基本符合文件路径+基本符合XML文档格式
            if (matchStr.Groups.Count != 1)
            {
                //需要判断是否文档路径，因为输入框是支持手动
                MessageBox.Show("文档路径不正确或无法读取！请双击【语法规则】输入框后重新选择文件！", "提醒",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                XmlDocumentLoadOrWriter.myMethodsXmlFilesReader(filePath); //获得选择的文件路径

                InitializeValuesFromVariable();
            }
        }


        private void InitializeValuesFromVariable()
        {
            this.textBoxCreatingMethods.Text = GENERATE_CREATING_STR + "";

            if (GENERATE_EQUAL_LENGTH.Equals("no") == true)
            { this.checkBoxEqualLength.Checked = false; }
            else
            { this.checkBoxEqualLength.Checked = true; }

            this.comboBoxCreateTotal.Text = GENERATE_TOTAL_NUMBER + "";
            this.textBoxBasedNumbA.Text = ORIGINAL_NUMBER_AAAAA + "";
            this.textBoxBasedNumbB.Text = ORIGINAL_NUMBER_BBBBB + "";
            this.textBoxBasedNumbC.Text = ORIGINAL_NUMBER_CCCCC + "";
            this.textBoxBasedNumbD.Text = ORIGINAL_NUMBER_DDDDD + "";
            this.textBoxBasedNumbE.Text = ORIGINAL_NUMBER_EEEEE + "";
            this.comboBoxIncreaseNumbA.Text = INCREASE_NUMBER_AA + "";
            this.comboBoxIncreaseNumbB.Text = INCREASE_NUMBER_BB + "";
            this.comboBoxIncreaseNumbC.Text = INCREASE_NUMBER_CC + "";
            this.comboBoxIncreaseNumbD.Text = INCREASE_NUMBER_DD + "";
            this.comboBoxIncreaseNumbE.Text = INCREASE_NUMBER_EE + "";
            this.dateTimePickerBasedTimeA.Text = ORIGINAL_DATETIME_AAAAA + "";
            this.dateTimePickerBasedTimeB.Text = ORIGINAL_DATETIME_BBBBB + "";
            this.dateTimePickerBasedTimeC.Text = ORIGINAL_DATETIME_CCCCC + "";
            this.dateTimePickerBasedTimeD.Text = ORIGINAL_DATETIME_DDDDD + "";
            this.textBoxIncreaseTimeA.Text = INCREASE_DATETIME_AA + "";
            this.textBoxIncreaseTimeB.Text = INCREASE_DATETIME_BB + "";
            this.textBoxIncreaseTimeC.Text = INCREASE_DATETIME_CC + "";
            this.textBoxIncreaseTimeD.Text = INCREASE_DATETIME_DD + "";

            MessageBox.Show("从文件加载已经完成，并且相应变量值已经更新完毕！\n如果发现加载异常请检查XML文档语法及格式！", "温馨提示",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
