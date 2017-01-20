# BigDataCustomizationTool
数据定制生成工具；可以良好的支持生成大量的数据库脚本！

#####1.支持
 * 工具本身使用语言为C#，支持VS2008环境下直接导入。
 * 可编译成Windows系统下的安装程序。

#####2.简单说明：
1.	软件设置：软件设置主要分为参数设置和语法规则设置。
2.	语法规则设置本身很简单，写出你任何想写的语句，语句中包含想要替换的参数标识（如截图二中递增数字参数一用{NumbA}表示，允许同标识参数多次出现），生成过程中就会根据参数标识替换成真实数据，并且递增循环直到结束。生成结果每条语句占一行！
3.	参数设置包括整型数据、时间数据、和特殊数据三类。
4.	整型数据需要设置初始值和递增值。如初始值A=0，递增值每次为1。那么表示如果需要生成100条数据，生成结果中A的值会从0一直递增到99结束。
5.	时间数据与整型数据类似，但是每次增加的时间，默认为秒。
6.	特殊数据-->中文姓名，默认201条‘姓’和200条‘名’选项，生成过程中会相互组合，超过200*200后会重新组合。
7.	特殊数据-->手机号码，支持手机号码13000000000~13999999999。
8.	特殊数据-->银行卡号支持62257720【0000000000】【?】~62257720【9999999999】【?】。其中中括号内10位数字可以变更，【?】由于必须符合格式，需要计算后得出。
9.	特殊数据-->身份证号支持21【0000】19【00】021【0000】【?】~21【9999】19【99】021【9999】【?】，其中中括号内10位数字可以变更，【?】由于必须符合格式，需要计算后得出。

#####3.其它说明：
下载地址：[BigDataCustomizationTool.zip](https://github.com/YamazakyLau/BigDataCustomizationTool/blob/master/BigDataCustomizationTool.zip "下载安装档")
工具界面预览：[工具界面预览](https://github.com/YamazakyLau/BigDataCustomizationTool/blob/master/%E8%BD%AF%E4%BB%B6%E6%88%AA%E5%9B%BE.png "查看")
