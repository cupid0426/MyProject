﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Data;
using System.Web;

namespace Show_Web
{
    /// <summary>
    /// 名称：  StringItem
    /// 功能：  对字符进行处理的相关方法。
    /// </summary>
    public class StringItem
    {
        public string strIn, strOut;

        public StringItem(string strIn)
        {
            this.strIn = strIn;
        }

        public string GetString()
        {
            this.strOut = this.strIn;
            return this.strOut;
        }

        #region GetImgSrc 得到图片地址
        public static string GetImgSrc(string strImgSrc)
        {
            return "http://basketballimages.vip.xba.com.cn/" + strImgSrc;
        }
        #endregion

        #region GetButton 得到按键

        public static string GetButtonF( string strName)
        {
            string strButton;
            strButton = "" + strName + "";

            return strButton;
        }
        public static string GetButton(string strID, string strName, string strOnClick)
        {
            string strButton;
            strButton = "<a  id=\"" + strID + "\" href=\"javascript:;\" onclick=\"" + strOnClick + "\"> [" + strName + "]</a>";

            return strButton;
        }

        #region GetDivButton 黑按键
        public static string GetDivButton(string strID, string strName, string strOnClick)
        {
            string strButton;
            strButton = "<input type=\"button\"  onclick=\"" + strOnClick + "\"  id=\"" + strID + "\" value=\"" + strName + "\" class=\"button50\" />";

            return strButton;
        }
        public static string GetDivButton(string strID, string strName, string strOnClick,int intWidth)
        {
            string strButton;
            strButton = "<input type=\"button\"  onclick=\"" + strOnClick + "\"  id=\"" + strID + "\" value=\"" + strName + "\" class=\"button" + intWidth + "\" />";

            return strButton;
        }
        public static string GetDivButton(string strID, string strName, string strOnClick, int intWidth, string strStyle)
        {
            string strButton;
            strButton = "<input type=\"button\" style=\"" + strStyle + "\"  onclick=\"" + strOnClick + "\"  id=\"" + strID + "\" value=\"" + strName + "\" class=\"button" + intWidth + "\" />";

            return strButton;
        }
        public static string GetDivButtonF(string strName)
        {
            string strButton;
            strButton = "<input type=\"button\" disabled=\"disabled\"  value=\"" + strName + "\" class=\"button50\" />";

            return strButton;
        }
        public static string GetDivButtonF(string strName, int intWidth)
        {
            string strButton;
            strButton = "<input type=\"button\"　  disabled=\"disabled\"  value=\"" + strName + "\" class=\"button" + intWidth + "\" />";

            return strButton;
        }
        #endregion

        #region GetUpDown 得到上一页下一页按钮
        public static string GetUpDown(string strID, string strName, string strOnClick, int intCategory)
        {
            if (intCategory == 0)
                return "<img src=\"http://basketballimages.vip.xba.com.cn/Css/Default/Images/prev.gif\" onclick=\"" + strOnClick + "\"   id=\"" + strID + "\" alt=\"" + strName + "\" border=\"0\" width=\"42\" height=\"23\" />";
            else
                return "<img src=\"http://basketballimages.vip.xba.com.cn/Css/Default/Images/next.gif\" onclick=\"" + strOnClick + "\"   id=\"" + strID + "\" alt=\"" + strName + "\" border=\"0\" width=\"42\" height=\"23\" />";
        }
        #endregion

        #region GetDivButtonW 白按键
        public static string GetDivButtonW(string strID, string strName, string strOnClick)
        {
            string strButton;
            strButton = "<input type=\"button\"  onclick=\"" + strOnClick + "\"   id=\"" + strID + "\" value=\"" + strName + "\" class=\"button50w\" />";

            return strButton;
        }
        public static string GetDivButtonW(string strID, string strName, string strOnClick, int intWidth)
        {
            string strButton;
            strButton = "<input type=\"button\"  onclick=\"" + strOnClick + "\"   id=\"" + strID + "\" value=\"" + strName + "\" class=\"button" + intWidth + "w\" />";

            return strButton;
        }
        public static string GetDivButtonW(string strID, string strName, string strOnClick, int intWidth, string strStyle)
        {
            string strButton;
            strButton = "<input type=\"button\" style=\"" + strStyle + "\"  onclick=\"" + strOnClick + "\"  id=\"" + strID + "\" value=\"" + strName + "\" class=\"button" + intWidth + "w\" />";

            return strButton;
        }
        public static string GetDivButtonFW(string strName)
        {
            string strButton;
            strButton = "<input type=\"button\" disabled=\"disabled\"  value=\"" + strName + "\" class=\"button50w\" />";

            return strButton;
        }
        public static string GetDivButtonFW(string strName, int intWidth)
        {
            string strButton;
            strButton = "<input type=\"button\"  disabled=\"disabled\"  value=\"" + strName + "\" class=\"button" + intWidth + "w\" />";

            return strButton;
        }
        #endregion

        #endregion

        #region Encrypt 3Des对称算法加密
        /// <summary>
        /// 3Des对称算法加密
        /// </summary>
        public static string Encrypt(string sourceValue)
        {
            string enValue = "";
            try
            {
                // Init variables.
                byte[] IV = null;
                byte[] key = null;
                // 试图加密
                // 创建 Encryptor
                // 使用 3Des 算法
                Encryptor enc = new Encryptor(EncryptionAlgorithm.TripleDes);
                //byte[] plainText = Encoding.ASCII.GetBytes(sourceValue);
                byte[] plainText = Encoding.Default.GetBytes(sourceValue);
                try
                {
                    key = Encoding.ASCII.GetBytes("Love17ClubCN2005");
                }
                catch
                {
                    key = Encoding.ASCII.GetBytes("Love17ClubCN2005");
                }
                IV = Encoding.ASCII.GetBytes("17Club");
                enc.IV = IV;
                // Perform the encryption.
                enValue = Convert.ToBase64String(enc.Encrypt(plainText, key));
            }
            catch
            {
            }

            return enValue;
        }
        #endregion

        #region GetZero 为输入的数字添加0作为补充位
        /// <summary>
        /// 方法：  GetZero
        /// 功能：  为输入的数字添加0作为补充位，补充到两位。
        /// 作者：  齐玮
        /// 修改：  
        /// 时间：  2007-2-5 14:13
        /// </summary>
        /// <param name="intIn">输入的数字</param>
        /// <returns>2位的字符串</returns>
        public static string GetZero(int intIn)
        {
            return ((intIn < 10) ? "0" : "") + intIn;
        }
        public static string GetZero3(int intIn)
        {
            if (intIn < 10)
                return "00" + intIn;
            else if (intIn < 100)
                return "0" + intIn;
            else
                return "" + intIn;
        }
        #endregion

        #region FormatDate 根据输入的格式，格式化时间
        /// <summary>
        /// 方法：  FormatDate
        /// 功能：  根据输入的格式，格式化时间
        /// 作者：  齐玮
        /// 修改：  
        /// 时间：  2007-2-5 14:13
        /// </summary>
        /// <param name="datIn">需要格式化的时间</param>
        /// <param name="strFormat">格式化的样式</param>
        /// <returns>格式化后的时间（字符串）</returns>
        public static string FormatDate(DateTime datIn, string strFormat)
        {
            string strOut;

            try
            {
                string strLongYear = GetZero(datIn.Year);
                string strShortYear = GetZero(Convert.ToInt32(datIn.Year.ToString().Substring(2,2)));
                string strYear = (strFormat.IndexOf("yyyy") == -1) ? strShortYear : strLongYear;
                string strMonth = GetZero(datIn.Month);
                string strDay = GetZero(datIn.Day);
                string strHour = GetZero(datIn.Hour);
                string strMinute = GetZero(datIn.Minute);
                string strSecond = GetZero(datIn.Second);
                string strMillisecond = GetZero3(datIn.Millisecond);
                strOut = Regex.Replace(strFormat, "dd", strDay);
                strOut = Regex.Replace(strOut, "MM", strMonth);
                strOut = Regex.Replace(strOut, "y{1,4}", strYear);
                strOut = Regex.Replace(strOut, "hh", strHour);
                strOut = Regex.Replace(strOut, "mm", strMinute);
                strOut = Regex.Replace(strOut, "ss", strSecond);
                strOut = Regex.Replace(strOut, "ii", strMillisecond);
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                strOut = "";
                //strOut = FormatDate(datIn,strFormat);
            }
            return strOut;
        }
        #endregion

        #region IsValidNumber 判断输入的字符串是否是数字
        /// <summary>
        /// 方法：  IsValidNumber
        /// 功能：  判断输入的字符串是否是数字
        /// 作者：  齐玮
        /// 修改：  王智勇
        /// 时间：  2006-12-21 15:48
        /// </summary>
        /// <param name="strIn">输入的字符串</param>
        /// <returns>是数字：true；不是数字：false；</returns>
        public static bool IsValidNumber(string strIn)
        {
            return (bool)Regex.IsMatch(strIn, @"^[0-9]{1,}$");
        }
        #endregion
        #region IsPhone 判断输入是否是固定电话
        /// <summary>
        /// 方法：  IsPhone
        /// 功能：  判断输入是否是固定电话
        /// 作者：  齐玮
        /// 修改：  于敏
        /// 时间：  2009-12-01 15:48
        /// </summary>
        /// <param name="strIn">输入的字符串</param>
        /// <returns>是数字：true；不是数字：false；</returns>
        public static bool IsPhone(string strIn)
        {
            //(\d{3,4}\)|\d{3,4}-|\s)?\d{8}
            return (bool)Regex.IsMatch(strIn, @"0\d{2,3}-?\d{7,8}");
        }
        #endregion
        #region IsPhone 判断输入是否是手机号码
        /// <summary>
        /// 方法：  IsPhone
        /// 功能：  判断输入是否是固定电话
        /// 作者：  齐玮
        /// 修改：  于敏
        /// 时间：  2009-12-01 15:48
        /// </summary>
        /// <param name="strIn">输入的字符串</param>
        /// <returns>是数字：true；不是数字：false；</returns>
        public static bool IsMobile(string strIn)
        {
            //(\d{3,4}\)|\d{3,4}-|\s)?\d{8}
            return (bool)Regex.IsMatch(strIn, @"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$|(^(13[0-9]|15[0|1|2|3|5|6|7|8|9]|18[6|7|8|9])\d{8}$)");
        }
          #endregion
        #region IsHandPhone 判断输入是否是手机号码
        /// <summary>
        /// 方法：  IsPhone
        /// 功能：  判断输入是否是固定电话
        /// 作者：  齐玮
        /// 修改：  于敏
        /// 时间：  2010-09-28 15:48
        /// </summary>
        /// <param name="strIn">输入的字符串</param>
        /// <returns>是数字：true；不是数字：false；</returns>
        public static bool IsHandPhone(string strIn)
        {
            //(\d{3,4}\)|\d{3,4}-|\s)?\d{8}
            return (bool)Regex.IsMatch(strIn, @"^(13[0-9]|15[0|1|2|3|5|6|7|8|9]|18[6|7|8|9])\d{8}$");
        }
         #endregion
        #region IsValidLogin 判断输入的字符串是否符合注册用户名的标准：仅允许阿拉伯数字、26个英文字符大小写、下划线
        /// <summary>
        /// 方法：  IsValidLogin
        /// 功能：  判断输入的字符串是否符合注册用户名的标准：仅允许阿拉伯数字、26个英文字符大小写、下划线。
        /// 作者：  齐玮
        /// 修改：  王智勇
        /// 时间：  2006-12-21 15:55
        /// </summary>
        /// <param name="strIn">输入的字符串</param>
        /// <returns>符合标准：true；不符合标准：false；</returns>
        public static bool IsValidLogin(string strIn)
        {
            return Regex.IsMatch(strIn,"^[a-zA-Z0-9_]*$");
        }
        #endregion

        #region MD5Encrypt 对输入的字符串进行MD5加密
        /// <summary>
        /// 方法：  MD5Encrypt
        /// 功能：  对输入的字符串进行MD5加密
        /// 作者：  齐玮
        /// 修改：  
        /// 时间：  2007-1-3 17:36
        /// </summary>
        /// <param name="pToEncrypt">输入的字符串</param>
        /// <param name="sKey">加密所需密钥（密钥长度规定为6位）</param>
        /// <returns>返回使用密钥加密之后的字符串</returns>
        public static string MD5Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            ret.ToString();
            return ret.ToString();
        }
        #endregion

        #region MD5Decrypt 对输入的字符串进行MD5解密
        /// <summary>
        /// 对输入的字符串进行MD5解密
        /// </summary>
        /// <param name="pToDecrypt">输入的字符串（此字符串必须是以前经过MD5Encrypt方法加密过的）</param>
        /// <param name="sKey">加密时实用的密钥（密钥长度规定为6位）</param>
        /// <returns>返回加密之前的原字符串</returns>
        public static string MD5Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            StringBuilder ret = new StringBuilder();

            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }
        #endregion

        #region HasValueInIntArrays 判断一个数值是否存在于一个数值数组中
        /// <summary> 
        /// 方法：  HasValueInIntArrays
        /// 功能：  判断一个数值是否存在于一个数值数组中
        /// 作者：  孔翔天
        /// 修改：  
        /// 时间：  2007-1-18 0:00
        /// </summary>
        /// <param name="intArrays">数组</param>
        /// <param name="intValue">要查找的值</param>
        /// <returns>true:存在; false:不存在</returns>
        public static bool HasValueInIntArrays(int[] intArrays, int intValue)
        {
            foreach (int intArray in intArrays)
            {
                if (intArray == intValue) return true;
            }
            return false;
        }
        #endregion

        #region HasValueInStrArrays 判断一个值是否存在于一个字符串数组中
        /// <summary> 
        /// 方法：  HasValueInStrArrays
        /// 功能：  判断一个值是否存在于一个字符串数组中
        /// 作者：  孔翔天
        /// 修改：  
        /// 时间：  2007-1-18 0:00
        /// </summary>
        /// <param name="strArrays">数组</param>
        /// <param name="strValue">要查找的值</param>
        /// <returns>true:存在; false:不存在</returns>
        public static bool HasValueInStrArrays(string[] strArrays, string strValue)
        {
            foreach (string strArray in strArrays)
            {
                if (strArray == strValue) return true;
            }
            return false;
        }
        #endregion

        #region GetNDecimal 小数精度控制
        public static double GetNDecimal(double dblIn, int intLen)
        {
            return Math.Round(dblIn, intLen);
        }

        /// <summary> 
        /// 方法：  GetNDecimal
        /// 功能：  输入两个浮点数和精度，返回精度为i的i位小数
        /// 作者：  qikai
        /// 修改：  
        /// 时间：  2007-1-30 16:00
        /// </summary>
        /// <param name="d1">数1</param>
        /// <param name="d2">数2</param>
        /// <param name="i">精度</param>
        public static double GetNDecimal(double d1, double d2, int i)
        {
            if (d2 != 0)
            {
                double d = Convert.ToDouble(Math.Round((d1 / d2), i));
                return d;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region UrlEncode2 URLEncode2格式的字符串
        public static string UrlEncode2(string urlToEncode)
        {
            if (IsNullorEmpty(urlToEncode))
                return urlToEncode;

            return System.Web.HttpUtility.UrlEncode(urlToEncode);
        }
        #endregion

        #region IsNullorEmpty 判断输入字符串是否为空
        public static bool IsNullorEmpty(string text)
        {
            return text == null || text.Trim() == string.Empty;
        }
        #endregion

        #region HasInvalidWord 判断一个字符串里有没有被屏蔽字
        /// <summary>
        /// 方法：  HasInvalidWord
        /// 功能：  判断一个字符串里有没有被屏蔽字
        /// 作者：  孔翔天
        /// 修改：  
        /// 时间：  2007-1-22 16:12 
        /// </summary>
        /// <param name="strIn">要检测的字符串</param>
        /// <param name="sdr">被屏蔽字眼的行信息</param>
        /// <returns>true 存在被屏蔽字眼，false 不存在</returns>
        public static bool HasInvalidWord(string strIn)
        {
            bool blReturn = false;

            #region 关键字
            string strValiad = "毛泽东,周恩来,刘少奇,朱德,彭德怀,林彪,刘伯承,陈毅,贺龙,聂荣臻,徐向前,罗荣桓,叶剑英,李大钊,陈独秀,孙中山,孙文,孙逸仙,邓小平,陈云,江泽民,李鹏,朱镕基,李瑞环,尉健行,李岚清,"+
                "胡锦涛,罗干,温家宝,吴邦国,曾庆红,贾庆林,黄菊,吴官正,李长春,吴仪,回良玉,曾培炎,周永康,曹刚川,唐家璇,华建敏,陈至立,陈良宇,张德江,张立昌,俞正声,王乐泉,刘云山,王刚,王兆国,刘淇,贺国强,郭伯雄,"+
                "胡耀邦,王乐泉,王兆国,周永康,李登辉,连战,陈水扁,宋楚瑜,吕秀莲,郁慕明,蒋介石,蒋中正,蒋经国,马英九,习近平,李克强,吴帮国,无帮国,无邦国,无帮过,瘟家宝,假庆林,甲庆林,假青林,离长春,习远平,袭近平,"+
                "李磕墙,贺过墙,和锅枪,粥永康,轴永康,肘永康,周健康,粥健康,周小康,布什,布莱尔,小泉,纯一郎,萨马兰奇,安南,阿拉法特,普京,默克尔,克林顿,里根,尼克松,林肯,杜鲁门,赫鲁晓夫,列宁,斯大林,马克思,恩格斯,"+
                "金正日,金日成,萨达姆,胡志明,西哈努克,希拉克,撒切尔,阿罗约,曼德拉,卡斯特罗,富兰克林,华盛顿,艾森豪威尔,拿破仑,亚历山大,路易,拉姆斯菲尔德,劳拉,鲍威尔,奥巴马,本拉登,奥马尔,柴玲,达赖喇嘛,江青,"+
                "张春桥,姚文元,王洪文,东条英机,希特勒,墨索里尼,冈村秀树,冈村宁次,高丽朴,赵紫阳,王丹,沃尔开西,李洪志,李大师,赖昌星,马加爵,班禅,额尔德尼,山本五十六,阿扁,阿扁万岁,热那亚,热比娅,六四,六四运动,"+
                "美国之音,密宗,民国,民进党,民运,民主,民主潮,摩门教,纳粹,南华早报,南蛮,明慧网,起义,亲民党,瘸腿帮,人民报,法轮功,法轮大法,打倒共产党,台独万岁,圣战,示威,台独,台独分子,台联,台湾民国,台湾岛国,"+
                "台湾国,台湾独立,太子党,天安门事件,屠杀,小泉,新党,新疆独立,新疆分裂,新疆国,疆独,西藏独立,西藏分裂,西藏国,藏独,藏青会,藏妇会,学潮,学运,一党专政,一中一台,两个中国,一贯道,游行,造反,真善忍,"+
                "镇压,政变,政治,政治反对派,政治犯,中共,共产党,反党,反共,政府,民主党,中国之春,转法轮,自焚,共党,共匪,苏家屯,基地组织,塔利班,东亚病夫,支那,高治联,高自联,专政,专制,世界维吾尔大会,核工业基地,"+
                "核武器,铀,原子弹,氢弹,导弹,核潜艇,大参考,小参考,国内动态清样,多维,河殇,摩门教,穆罕默德,圣战,耶和华,耶稣,伊斯兰,真主安拉,白莲教,天主教,基督教,东正教,大法,法轮,法轮功,瘸腿帮,真理教,真善忍,"+
                "转法轮,自焚,走向圆满,黄大仙,跳大神,神汉,神婆,真理教,大卫教,阎王,黑白无常,牛头马面,藏独,高丽棒子,疆独,蒙古鞑子,台独,台独分子,台联,台湾民国,西藏独立,新疆独立,南蛮,老毛子,回民吃猪肉,谋杀,"+
                "杀人,吸毒,贩毒,赌博,拐卖,走私,卖淫,造反,强奸,轮奸,抢劫,先奸后杀,下注,抽头,坐庄,赌马,赌球,筹码,老虎机,轮盘赌,安非他命,大麻,可卡因,海洛因,冰毒,摇头丸,杜冷丁,鸦片,罂粟,迷幻药,白粉,嗑药,吸毒,"+
                "AIDS,aids,Aids,DICK,dick,Dick,penis,sex,SM,屙,爱滋,淋病,梅毒,爱液,屄,逼,臭机八,臭鸡巴,吹喇叭,吹箫,催情药,屌,肛交,肛门,龟头,黄色,机八,机巴,鸡八,鸡巴,机掰,机巴,鸡叭,鸡鸡,鸡掰,鸡奸,妓女,奸,茎,"+
                "精液,精子,尻,口交,滥交,乱交,轮奸,卖淫,屁眼,嫖娼,强奸,强奸犯,情色,肉棒,乳房,乳峰,乳交,乳头,乳晕,三陪,色情,射精,手淫,威而钢,威而柔,伟哥,性高潮,性交,性虐,性欲,穴,颜射,阳物,一夜情,阴部,阴唇,"+
                "阴道,阴蒂,阴核,阴户,阴茎,阴门,淫,淫秽,淫乱,淫水,淫娃,淫液,淫汁,淫穴,淫洞,援交妹,做爱,梦遗,阳痿,早泄,奸淫,性欲,性交,Bitch,bt,cao,FUCK,Fuck,fuck,kao,NMD,NND,sb,shit,SHIT,SUCK,Suck,tmd,TMD,"+
                "tnnd,K他命,白痴,笨蛋,屄,变态,婊子,操她妈,操妳妈,操你,操你妈,操他妈,草你,肏,册那,侧那,测拿,插,蠢猪,荡妇,发骚,废物,干她妈,干妳,干妳娘,干你,干你妈,干你妈B,干你妈b,干你妈逼,干你娘,干他妈,"+
                "狗娘养的,滚,鸡奸,贱货,贱人,烂人,老母,老土,妈比,妈的,马的,妳老母的,妳娘的,你妈逼,破鞋,仆街,去她妈,去妳的,去妳妈,去你的,去你妈,去死,去他妈,日,日你,赛她娘,赛妳娘,赛你娘,赛他娘,骚货,傻B,"+
                "傻比,傻子,上妳,上你,神经病,屎,屎妳娘,屎你娘,他妈的,王八蛋,我操,我日,乡巴佬,猪猡,屙,干,尿,掯,屌,操,骑你,湿了,操你,操他,操她,骑你,骑他,骑她,欠骑,欠人骑,来爽我,来插我,干你,干他,干她,干死,"+
                "干爆,干机,FUCK,机叭,臭鸡,臭机,烂鸟,览叫,阳具,肉棒,肉壶,奶子,摸咪咪,SUCK,PENIS,BITCH,TMD,BLOW,JOB,KISS,MY,ASS,SHIT,干鸡,干入,小穴,强奸,插你,插你,爽你,爽你,干干,干X,我操,他干,干它,干牠,"+
                "干您,干汝,干林,操林,干尼,操尼,我咧干,干勒,干我,干到,干啦,干爽,欠干,狗干,我干,来干,轮干,轮流干,干一干,援交,骑你,我操,轮奸,鸡奸,奸暴,再奸,我奸,奸你,奸你,奸他,奸她,奸一奸,淫水,淫湿,鸡歪,"+
                "仆街,臭西,尻,遗精,烂逼,大血比,叼你妈,靠你妈,草你,干你,日你,插你,奸你,戳你,逼你老母,挨球,我日你,草拟妈,卖逼,狗操卖逼,奸淫,日死,奶子,阴茎,奶娘,他娘,她娘,骚B,你妈了妹,逼毛,插你妈,叼你,"+
                "渣波波,嫩b,weelaa,缔顺,帝顺,蒂顺,系统消息,午夜,看下,草泥马,法克鱿,雅蠛蝶,潜烈蟹,菊花蚕,尾申鲸,吉跋猫,搞栗棒,吟稻雁,达菲鸡,SM,ML,3P,群P,马勒戈壁,双飞,ㄅ,ㄆ,ㄇ,ㄈ,ㄉ,ㄊ,ㄋ,ㄌ,ㄍ,ㄎ,ㄏ,ㄐ,"+
                "ㄑ,ㄒ,ㄓ,ㄔ,ㄕ,ㄖ,ㄗ,ㄘ,ㄙ,ㄚ,ㄛ,ㄜ,ㄝ,ㄞ,ㄟ,ㄠ,ㄡ,ㄢ,ㄣ,ㄤ,ㄥ,ㄦ,ㄧ,ㄨ,ㄩ,鞴,鐾,瘭,镳,黪,瘥,觇,孱,廛,蒇,冁,羼,螭,傺,瘛,舂,艟,瘳,雠,搋,嘬,辏,殂,汆,爨,榱,毳,皴,蹉,鹾,纛,髑屙民,莪,苊,鲕,"+
                "鲼,瀵,酆,幞,黻,呒,黼,阝,阝月,彀,觏,毂 ,汩, 罟,嘏,鲴,宄,庋,刿,虢,馘,撖,夯,薅,曷,翮,曷,翮, ,觳,冱,怙,戽,祜,瓠,鹱 , 溷,耠,锪,劐, ,蠖,丌,乩,赍,殛,蕺,掎,彐,芰,跽,鲚,葭,恝,湔,搛,鲣,鞯,囝,趼,醮,"+
                "疖,苣,屦,醵,蠲,桊,鄄,谲,爝,麇,贶,悝,喟,仂,泐,鳓,诔,酹,嫠,黧,蠡,醴,鳢,轹,詈,跞,奁,臁,蚍,埤,罴,鼙,庀,仳,圮綦,屺,綮,汔,碛,葜,佥,岍,愆,搴,钤,掮,凵,肷,椠,戕,锖,檠,苘,謦,庆红,跫,銎,邛,筇,蛩鼽,"+
                "诎,麴,黢,劬,朐,璩,蘧,衢,蠼毵,糁,dishun , Dishun , DISHUN , DiShun , 16大 , 18摸 , 21世纪中国基金会 , 6-4tianwang , 89-64cdjp , ADMIN , AIDS , Aiort墓地 , ai滋 , Arqus会议场 , asshole , "+
                "Atan的移动石 , A片 , Baichi , Baopi , Bao皮 , bastard , Bc , biaozi , Biao子 , bignews , bitch , Bi样 , BLOWJOB , boxun , B样 , caoB , caobi , cao你 , cao你妈 ,  cao你大爷 , cha你 , "+
                "chinaliberal , chinamz , chinesenewsnet , Clockgemstone , cnd , creaders , Crestbone , dafa , dajiyuan , damn , dfdz , DICK , dpp , EVENT , falu , falun , falundafa , fa轮 , Feelmistone ,"+
                " Fku , FLG , flg , freechina , freedom , freenet , Fuck , fuck , GAMEMASTER , gan你 , GCD , gcd , GM , Gruepin , HACKING , hongzhi , hrichina , http , huanet , hypermart.net , incest , "+
                "item , J8 , JB , jiangdongriji , jian你 , jiaochuang , jiaochun , jiba , jinv , Ji女 , Kao , KISSMYASS , lihongzhi , Mai骚 , making , minghui , minghuinews , nacb , naive , Neckromancer ,"+
                " nmis , paper64 , peacehall , PENIS , playboy , pussy , qiangjian , Rape , renminbao , renmingbao , rfa , safeweb , saobi , sb , SEX , sex , sf , SHIT , shit , simple , SUCK , sucker , "+
                "svdc , System , taip , TEST , The9 , The9City , tibetalk , TMD , TNND , triangle , triangleboy , Tringel , UltraSurf , unixbox , ustibet , voa , voachinese , wangce , WEBZEN , WG , wstaiji ,"+
                " xinsheng , yuming , zhengjian , zhengjianwang , zhenshanren , zhuanfalunADMIN,AIDS,AIORT墓地,AI滋,ARQUS会议场,ASSHOLE,ATAN的移动石,A片,BAICHI,BAOPI,BAO皮,BASTARD,BC,BIAOZI,BIAO子,BIGNEWS,"+
                "BITCH,BI样,BLOWJOB,BOXUN,B样,CAOB,CAOBI,CAO你,CC小雪,CHA你,CHINALIBERAL,CHINAMZ,CHINESENEWSNET,CLOCKGEMSTONE,CND,CREADERS,CRESTBONE,DAFA,DAJIYUAN,DAMN,DFDZ,DICK,DPP,EVENT,FALU,FALUN,"+
                "FALUNDAFA,FA轮,FEELMISTONE,FKU,FLG,FREECHINA,FREEDOM,FREENET,FUCK,GAMEMASTER,GAN你,GCD,GM,GRUEPIN,HACKING,HONGZHI,HRICHINA,HTTP,HUANET,HYPERMART.NET,INCEST,ITEM,J8,JB,JIANGDONGRIJI,"+
                "JIAN你,JIAOCHUANG,JIAOCHUN,JIBA,JINV,JI女,KAO,KISSMYASS,㎏,LIHONGZHI,MAI骚,MAKING,MINGHUI,MINGHUINEWS,㎎,㎜,NACB,NAIVE,NECKROMANCER,NMIS,PAPER64,PEACEHALL,PENIS,PLAYBOY,PUSSY,QIANGJIAN,"+
                "RAPE,RENMINBAO,RENMINGBAO,RFA,SAFEWEB,SAOBI,SB,SEX,SF,SHIT,SIMPLE,SUCK,SUCKER,SVDC,SYSTEM,TAIP,TEST,THE9,THE9CITY,TIBETALK,TMD,TNND,TRIANGLE,TRIANGLEBOY,TRINGEL,ULTRASURF,UNIXBOX,USTIBET,"+
                "VOA,VOACHINESE,WANGCE,WEBZEN,WG,WSTAIJI,WWW,WWW.,XINSHENG,YUMING,ZHENGJIAN,ZHENGJIANWANG,ZHENSHANREN,ZHUANFALUN,周恩來,碡 ,籀,朱駿 ,朱狨基,朱容基,朱溶剂,朱熔基,朱镕基,邾,猪操,猪聋畸,猪毛,"+
                "猪毛1,舳,瘃,躅,翥,專政,颛,丬,隹,窀,卓伯源,倬,斫,诼,髭,鲻,子宫,秭,訾,自焚,自民党,自慰,自已的故事,自由民主论坛,总理,偬,诹,陬,鄹,鲰,躜,缵,作爱,作秀,阼,祚,做爱,阿扁萬歲,阿萊娜,啊無卵,埃裏克蘇特勤,"+
                "埃斯萬,艾麗絲,愛滋,愛滋病,垵,暗黑法師,嶴,奧克拉,奧拉德,奧利弗,奧魯奇,奧倫,奧特蘭,㈧,巴倫侍從,巴倫坦,白立樸,白夢,白皮書,班禪,寶石商人,保釣,鮑戈,鮑彤,鮑伊,暴風亡靈,暴亂,暴熱的戰士,"+
                "暴躁的城塔野獸,暴躁的警衛兵靈魂,暴躁的馬杜克,北大三角地論壇,北韓,北京當局,北美自由論壇,貝尤爾,韝,逼樣,比樣,蹕,颮,鑣,婊子養的 ,賓周,冰後,博訊,不滅帝王, ,不爽不要錢,布萊爾,布雷爾,蔡崇國,蔡啓芳,"+
                "黲,操鶏,操那嗎B,操那嗎逼,操那嗎比,操你媽,操你爺爺,曹長青,曹剛川,草,草你媽,草擬媽,册那娘餓比,插那嗎B,插那嗎逼,插那嗎比,插你媽,插你爺爺,覘,蕆,囅,閶,長官沙塔特,常勁,朝鮮,車侖,車侖女幹,沉睡圖騰,"+
                "陳炳基,陳博志,陳定南,陳建銘,陳景俊,陳菊,陳軍,陳良宇,陳蒙,陳破空,陳水扁,陳唐山,陳希同,陳小同,陳宣良,陳學聖,陳一諮,陳總統,諶,齔,櫬,讖,程凱,程鐵軍,鴟,痴鳩,痴拈,遲鈍的圖騰,持不同政見 ,赤色騎士,"+
                "赤色戰士,處女膜,傳染性病,吹簫,春夏自由論壇,戳那嗎B,戳那嗎逼,戳那嗎比,輳,鹺,錯B,錯逼,錯比,錯那嗎B,錯那嗎逼,錯那嗎比,達夫警衛兵,達夫侍從,達癩,打飛機,大參考,大東亞,大東亞共榮,大鶏巴,大紀元,"+
                "大紀元新聞網,大紀園,大家論壇,大奶媽,大史記,大史紀,大衛教,大中國論壇,大中華論壇,大衆真人真事,紿,戴維教,戴相龍,彈劾,氹,蕩婦,導師,盜竊犯,德維爾,登輝,鄧笑貧,糴,迪裏夏提,覿,地下教會,帝國主義,"+
                "電視流氓,叼你媽,釣魚島,丁關根,東北獨立,東部地下水路,東方紅時空,東方時空,東南西北論談,東社,東升,東條,東條英機,東突暴動,東突獨立,東土耳其斯坦,東西南北論壇,東亞,東院看守,動亂,鬥士哈夫拉蘇,"+
                "鬥士霍克,獨裁,獨裁政治,獨夫,獨立臺灣會,俄國 ,鮞,㈡,發楞,發掄,發掄功,發倫,發倫功,發輪,發論,發論公,發論功,發騷,發正念,法~倫,法~淪,法~綸,法~輪,法~論,法爾卡,法掄,法掄功,法侖,法淪,法綸,法輪大法,"+
                "法輪功,法十輪十功,法謫,法謫功,反封鎖,反封鎖技術,反腐敗論壇,反人類,反社會,方勵之,防衛指揮官,放蕩,飛揚論壇,廢墟守護者,費鴻泰,費良勇,分隊長施蒂文,粉飾太平,糞便,鱝,豐饒的果實,風雨神州,"+
                "風雨神州論壇,封從德,封殺,封印的靈魂騎士,馮東海,馮素英,紱,襆,嘸 ,傅作義,幹bi,幹逼,幹比,幹的你,幹幹幹,幹她,幹你,幹你老比,幹你老母,幹你娘,幹全家,幹死,幹死你,幹他,幹一家,趕你娘,岡巒,剛比,剛比樣子,"+
                "崗哨士兵,肛門,高麗棒子,高文謙,高薪養廉,高自聯,膏藥旗,戈瑞爾德,戈揚,鴿派,歌功頌德,格雷(關卡排名管理者),格魯,格魯(城鎮移動),鯁,工自聯,弓雖,共産,共産黨,共産主義,共黨,共軍,共榮圈,緱,狗誠,狗狼養的,"+
                "狗娘養的,狗養,狗雜種,覯,轂,古龍祭壇,骨獅,鯝,鴰,詿,關卓中,貫通兩極法,廣聞,嬀,龜兒子,龜公,龜孫子,龜頭,龜投,劌,緄,滾那嗎,滾那嗎B,滾那嗎錯比,滾那嗎老比,滾那嗎瘟比,鯀,咼,郭俊銘,郭羅基,郭岩華,"+
                "國家安全,國家機密,國軍,國賊,哈爾羅尼,頇,韓東方,韓聯潮,韓正,漢奸,顥,灝,河殤,賀國强,賀龍,黑社會,黑手黨,紅燈區,紅色恐怖,紅炎猛獸,洪傳,洪興,洪哲勝,黌,鱟,胡緊掏,胡錦滔,胡錦淘,胡景濤,胡喬木,胡總書記,"+
                "湖岸護衛兵,湖岸警衛兵,湖岸哨兵隊長,護法,鸌,華建敏,華通時事論壇,華夏文摘,華語世界論壇,華岳時事論壇,懷特,鍰,皇軍,黃伯源,黃慈萍,黃禍,黃劍輝,黃金幼龍,黃菊,黃片,黃翔,黃義交,黃仲生,回民暴動,噦,繢,"+
                "毀滅步兵,毀滅騎士,毀滅射手,昏迷圖騰,混亂的圖騰,鍃,活動 ,擊倒圖騰,擊傷的圖騰,鶏8,鶏八,鶏巴,鶏吧,鶏鶏,鶏奸,鶏毛信文匯,鶏女,鶏院,姬勝德,積克館,賫,鱭,賈廷安,賈育台,戔,監視塔,監視塔哨兵,"+
                "監視塔哨兵隊長,鰹,韉,簡肇棟,建國黨,賤B,賤bi,賤逼,賤比,賤貨,賤人,賤種,江八點,江羅,江綿恒,江戲子,江則民,江澤慧,江賊,江賊民,薑春雲,將則民,僵賊,僵賊民,講法,蔣介石,蔣中正,降低命中的圖騰,醬猪媳,撟,"+
                "狡猾的達夫,矯健的馬努爾,嶠,教養院,癤,揭批書,訐,她媽,届中央政治局委員,金槍不倒 ,金堯如,金澤辰,巹,錦濤,經文,經血,莖候佳陰,荊棘護衛兵 ,靖國神社,㈨,舊斗篷哨兵,齟,巨槌騎兵,巨鐵角哈克,"+
                "鋸齒通道被遺弃的骷髏,鋸齒通道骷髏,屨,棬,絕望之地,譎,軍妓,開苞,開放雜志,凱奧勒尼什,凱爾本,凱爾雷斯,凱特切爾,砍翻一條街,看中國,闞,靠你媽,柯賜海,柯建銘,科萊爾,克萊恩,克萊特,克勞森,客戶服務,緙,"+
                "空氣精靈,空虛的伊坤,空虛之地,恐怖主義,瞘,嚳,鄺錦文,貺,昆圖,拉姆斯菲爾德,拉皮條,萊特,賴士葆,蘭迪,爛B,爛逼,爛比,爛袋,爛貨,濫B,濫逼,濫比,濫貨,濫交,勞動教養所,勞改,勞教,鰳,雷尼亞,誄,李紅痔,李洪寬,"+
                "李繼耐,李蘭菊,李老師,李錄,李祿,李慶安,李慶華,李淑嫻,李鐵映,李旺陽,李小鵬,李月月鳥,李志綏,李總理,李總統,裏菲斯,鱧,轢,躒,奩,連方瑀,連惠心,連勝德,連勝文,連戰,聯總,廉政大論壇,煉功,兩岸關係,"+
                "兩岸三地論壇,兩個中國,兩會,兩會報道,兩會新聞,廖錫龍 ,林保華,林長盛,林佳龍,林信義,林正勝,林重謨,躪,淩鋒,劉賓深,劉賓雁,劉剛,劉國凱,劉華清,劉俊國,劉凱中,劉千石,劉青,劉山青,劉士賢,劉文勝,劉文雄,"+
                "劉曉波,劉曉竹,劉永川,㈥,鷚,龍虎豹,龍火之心,盧卡,盧西德,陸委會,輅,呂京花,呂秀蓮,亂交,亂倫,亂輪,鋝,掄功,倫功,輪大,輪功,輪奸,論壇管理員,羅福助,羅幹,羅禮詩,羅文嘉,羅志明,腡,濼,洛克菲爾特,媽B,媽比,"+
                "媽的,媽批,馬大維,馬克思,馬良駿,馬三家,馬時敏,馬特斯,馬英九,馬永成,瑪麗亞,瑪雅,嗎的,嗎啡,勱,麥克斯,賣逼,賣比,賣國,賣騷,賣淫,瞞報,毛厠洞,毛賊,毛賊東,美國,美國參考,美國佬,美國之音,蒙獨,蒙古達子,"+
                "蒙古獨,蒙古獨立,禰,羋,綿恒,黽,民國,民進黨,民聯,民意論壇,民陣,民主墻,緡,湣,鰵,摸你鶏巴, ,莫偉强,木子論壇,內褲,內衣,那嗎B,那嗎逼,那嗎錯比,那嗎老比,那嗎瘟比,那娘錯比,納粹,奶頭,南大自由論壇,南蠻子,"+
                "鬧事,能樣,尼奧夫,倪育賢,鯢,你媽,你媽逼,你媽比,你媽的,你媽了妹,你說我說論壇,你爺 ,娘餓比,捏你鶏巴,儂著岡巒,儂著卵拋,奴隸魔族士兵,女幹,女主人羅姬馬莉,儺,諾姆,潘國平,蹣 ,龐建國,泡沫經濟,轡,噴你,"+
                "皮條客,羆,諞,潑婦 ,齊墨,齊諾,騎你,磧,僉,鈐,錢達,錢國梁,錢其琛,膁,槧,錆,繰,喬石,喬伊,橋侵襲兵,譙,鞽,篋,親美,親民黨,親日,欽本立,禽獸,唚,輕舟快訊,情婦,情獸,檾,慶紅,丘垂貞,詘,去你媽的,闃,全國兩會,"+
                "全國人大,犬,綣,瘸腿幫,愨,讓你操,熱比婭,熱站政論網,人民報,人民大會堂,人民內情真相,人民真實,人民之聲論壇,人權,日本帝國,日軍,日內瓦金融,日你媽,日你爺爺,日朱駿,顬,乳頭,乳暈,瑞士金融大學,薩達姆,三K黨,"+
                "三個代表,三級片,三去車侖工力,㈢,毿,糝,騷B,騷棒,騷包,騷逼,騷棍,騷貨,騷鶏,騷卵 ,殺你全家,殺你一家,殺人犯,傻鳥,煞筆,山口組,善惡有報,上訪,上海幫,上海孤兒院,厙,社會主義,射了還說要,灄,詵,神經病,諗,"+
                "生孩子沒屁眼,生命分流的圖騰,澠,聖射手,聖戰,盛華仁,濕了還說不要,濕了還說要,釃,鯴,㈩,石化圖騰,石拳戰鬥兵,時代論壇,時事論壇,鰣,史萊姆,史萊姆王,士兵管理員瓦爾臣,世界經濟導報,事實獨立,侍從貝赫爾特,"+
                "侍從倫斯韋,貰,攄,數據中國,雙十節,氵去車侖工力,氵去車侖工力?,稅力,司馬晋,司馬璐,司徒華,私?服,私處,思科羅,斯諾,斯皮爾德,四川獨,四川獨立,四人幫,㈣,宋書元,藪,蘇菲爾,蘇拉,蘇南成,蘇紹智,蘇特勒守護兵,"+
                "蘇特勤,蘇特勤護衛兵,蘇特勤魔法師,蘇曉康,蘇盈貴,蘇貞昌,誶,碎片製造商人馬克,碎片製造商人蘇克,孫大千,孫中山,他媽,他媽的,他嗎的,他母親,塔內,塔烏,鰨,闥,臺盟,臺灣帝國,臺灣獨立,臺灣獨,臺灣共産黨,臺灣狗,"+
                "臺灣建國運動組織,臺灣民國,臺灣青年獨立聯盟,臺灣政論區,臺灣自由聯盟,鮐,太監,泰奴橋警衛兵,泰奴橋掠奪者,湯光中,唐柏橋,鞀,謄,天安門,天安門錄影帶,天安門事件,天安門屠殺,天安門一代,天閹,田紀雲,齠,鰷,銚,"+
                "庭院警衛兵,統獨,統獨論壇,統戰,頭領奧馬,頭領墳墓管理員,圖書管理員卡特,屠殺,團長戈登,團員馬爾汀,摶,鼉,籜,膃,外交論壇,外交與方略,晚年周恩來,綰,萬里,萬潤南,萬維讀者論壇,萬曉東,王寶森,王超華,王輔臣,"+
                "王剛,王涵萬,王滬寧,王軍濤,王樂泉,王潤生,王世堅,王世勛,王秀麗,王兆國,網禪,網特,猥褻,鮪,溫B,溫逼,溫比,溫家寶,溫元凱,閿,無界瀏覽器,吳百益,吳敦義,吳方城,吳弘達,吳宏達,吳仁華,吳淑珍,吳學燦,吳學璨,"+
                "吳育升,吳志芳,西藏獨,吸收的圖騰,吸血獸,覡,洗腦,系統,系統公告,餼,郤,下賤,下體,薟,躚,鮮族,獫,蜆,峴,現金,現金交易,獻祭的圖騰,鯗,項懷誠,項小吉,嘵,小B樣,小比樣,小參考,小鶏鶏,小靈通,小泉純一郎,謝長廷,"+
                "謝深山,謝選駿,謝中之,辛灝年,新觀察論壇,新華舉報,新華內情,新華通論壇,新疆獨,新生網,新手訓練營,新聞出版總署,新聞封鎖,新義安,新語絲,信用危機,邢錚,性愛,性無能,修煉,頊,虛弱圖騰,虛無的飽食者,徐國舅,"+
                "許財利,許家屯,許信良,諼,薛偉,學潮,學聯,學運,學自聯,澩,閹狗,訁,嚴家其,嚴家祺,閻明複,顔清標,顔慶章,顔射,讞,央視內部晚會,陽具,陽痿,陽物,楊懷安,楊建利,楊巍,楊月清,楊周,姚羅,姚月謙,軺,搖頭丸,"+
                "藥材商人蘇耐得,藥水,耶穌,野鶏,葉菊蘭,夜話紫禁城,一陀糞,㈠,伊莎貝爾,伊斯蘭,伊斯蘭亞格林尼斯,遺精,議長阿茵斯塔,議員斯格文德,异見人士,异型叛軍,异議人士,易丹軒,意志不堅的圖騰,瘞,陰部,陰唇,陰道,陰蒂,"+
                "陰戶,陰莖,陰精,陰毛,陰門,陰囊,陰水,淫蕩,淫穢,淫貨,淫賤,尹慶民,引導,隱者之路,鷹眼派氏族,硬直圖騰,憂鬱的艾拉,尤比亞,由喜貴,游蕩的僵尸,游蕩的士兵,游蕩爪牙,游錫坤,游戲管理員,友好的魯德,幼齒,幼龍,"+
                "于幼軍,余英時,漁夫菲斯曼,輿論,輿論反制,傴,宇明網,齬,飫,鵒,元老蘭提(沃德）,圓滿,緣圈圈,遠志明,月經,韞,雜種,鏨,造愛,則民,擇民,澤夫,澤民,賾,賊民,譖,扎卡維是英雄,驏,張伯笠,張博雅,張鋼,張健,張林,"+
                "張清芳,張偉國,張溫鷹,張昭富,張志清,章孝嚴,帳號,賬號,招鶏,趙海青,趙建銘,趙南,趙品潞,趙曉微,趙紫陽,貞操,鎮壓,爭鳴論壇,正見網,正義黨論壇,㊣,鄭寶清,鄭麗文,鄭義,鄭餘鎮,鄭源,鄭運鵬,政權,政治反對派,"+
                "縶,躑,指點江山論壇,騭,觶,躓,中毒的圖騰,中毒圖騰,中俄邊界,中國復興論壇,中國共産黨,中國孤兒院,中國和平,中國論壇,中國社會進步黨,中國社會論壇,中國威脅論,中國問題論壇,中國移動通信,中國真實內容,"+
                "中國之春,中國猪,中華大地,中華大衆,中華講清,中華民國,中華人民實話實說,中華人民正邪,中華時事,中華養生益智功,中華真實報道,中央電視臺,鐘山風雨論壇, ,周鋒鎖,周守訓 ,朱鳳芝,朱立倫,朱溶劑,㈱,猪聾畸,"+
                "主攻指揮官,主義,助手威爾特,專制,顓,轉化,諑,資本主義,鯔,子宮,自民黨,自由民主論壇,總理,諏,鯫 ,躦,纘,作愛,做愛,bcd.s.59764.com,kkk.xaoh.cn,www.xaoh.cn,zzz.xaoh.cn,aa.yazhousetu.hi.9705.net.cn,"+
                "eee.xaoh.cn,lll.xaoh.cn,jj.pangfangwuyuetian.hi.9705.net.cn,rrr.xaoh.cn,ooo.xaoh.cn,www.zy528.com,aaad.s.59764.com,www.dy6789.cn,aaac.s.51524.com,208.43.198.56,166578.cn,www.wang567.com,"+
                "www.bin5.cn,www.sanjidianying.com.cn,www.anule.cn,%77%77%77%2E%39%37%38%38%30%38%2E%63%6F%6D,www.976543.com,www.50spcombaidu1828adyou97sace.co.cc,chengrenmanhua.1242.net.cn,"+
                "qingsewuyuetian.1174.net.cn,lunlidianyingxiazai.1174.net.cn,siwameitui.1274.net.cn,niuniujidi.1174.net.cn,xiao77.1243.net.cn,woyinwose.1243.net.cn,dingxiang.1249.net,cnaicheng.1174.net.cn,"+
                "1234chengren.1249.net.cn,sewuyuetian.1174.net.cn,huangsexiaoshuo.1242.net.cn,lunlidianying.1274.net.cn,xingqingzhongren.1174.net.cn,chengrenwangzhi.1242.net.cn,xiao77luntan.1249.net.cn,"+
                "dingxiang.1243.net.cn,11xp.1243.net.cn,baijie.1249.net.cn,sewuyuetian.1274.net.cn,meiguiqingren.1274.net.cn,tb.hi.4024.net.cn,www.91wangyou.com,www.wow366.cn,www.yxnpc.com,www.365jw.com,"+
                "58.253.67.74,www.978808.com,www.sexwyt.com,7GG,www.567yx.com,131.com,bbs.7gg.cn,www.99game.net,ppt.cc,www.zsyxhd.cn,www.foyeye.com,www.23nice.com.cn,www.maituan.com,www.ylteam.cn,"+
                "www.yhzt.org,vip886.com,www.neicehao.cn,bbs.butcn.com,www.gamelifeclub.cn,consignment5173,www.70yx.com,www.legu.com,ko180,bbs.pkmmo,whoyo.com,www.2q5q.com,www.zxkaku.cn,www.gw17173.cn,"+
                "www.315ts.net,qgqm.org,17173dl.net,i9game.com,365gn,158le.com,1100y.com,bulaoge.com,17youle.com,reddidi.com.cn,icpcn.com,ul86.com,showka8.com,szlmgh.cn,bbs.766.com,www.766.com,91bysd.cn,"+
                "jiayyou.cn,gigabyte.cn,duowan,wgxiaowu.com,youxiji888.cn,yz55.cn,Carrefour,51jiafen.cn,597ft.com,itnongzhuang.com2y7v.cnhwxvote.cn,92klgh.cn,xiaoqinzaixian.cn,661661.com,haosilu.com,dl.com,"+
                "xl517.com,sjlike.com,tont.cn,xq-wl.cn,feitengdl.com,bz176.com,dadati.com,asgardcn.com,dolbbs.com,okaygood.cn,1t1t.com,jinpaopao.com,blacksee.com.cn,1qmsj.com,202333.com,luoxialu.cn,37447.cn,"+
                "567567aa.cn,09city.com,71ka.com,fy371.com,365tttyx.com,host800.com,lybbs.info,ys168.com,88mysf.com,5d6d.com,id666.uqc.cn,stlmbbs.cn,pcikchina.com,lxsm888.com,wangyoudl.com,chinavfx.net,"+
                "zxsj188.com,wg7766.cn,e7sw.cn,jooplay.com,gssmtt.com,likeko.com,tlyx-game.cn,wy33.com,zy666.net,newsmth.net,l2jsom.cn,13888wg.com,qtoy.com,1000scarf.com,digitallongking.com,zaixu.net,ncyh.cn,"+
                "888895.com,ising99.com,pcikcatv.2om,parke888.com,01gh.com,gogo.net,uu1001.com,wy724.com,prettyirene.net,yaokong7.com,zzmysf.com,52sxhy.cn,92wydl.com,g365.net,pkmmo.com,52ppsa.cn,bl62.com,"+
                "canyaa.com,lordren.com,xya3.cn,5m5m5m.com,www.gardcn.com,www.sf766.com.cn,ent365.com,18900.com,7mmo.com,cdream.com,wy3868.com,nbfib.cn,17173yxdl.cn,luosisa.cn,haouse.cn,54hero.com,ieboy.cn,"+
                "geocities.com,xiuau.cn,cvceo.com,fxjsqc.com,thec.cn,c5c8.cn,a33.com,qqsg.org,my3q.com,51juezhan.com,kartt.cn,hexun.com,15wy.com,13ml.net,homexf.cn,xyxgh.com,jdyou.com,langyou.info,duowan.com,"+
                "8188mu.com,tianlong4f.cn,yeswm.com,wgbobo.cn,haog8.cn,47513.cn,92ey.com,hao1788.co,mgjzybj.com,xdns.eu,shenycs.co,mpceggs.cn,kod920.cn,njgamecollege.org,51hdw.com,025game.cn,bibidu.com,"+
                "bwowd.com,3kwow.com,zx002.com,bazhuwg.cn,991game.com,zuanshi1000.cn,10mb.cn,Huihuangtx.com,chongxianmu.cn,any2000.com,99sa.com,zhidian8.com,t9wg.cn,bobaoping,qixingnet.com,88kx.com,00sm.cn,"+
                "moyi520.cn,id666.com,fisonet.com,0571qq.com,173at.com,pk200.com,2feiche.cn,jjdlw.com,xyq2sf.com,69nb.com,txwsWind,jiayyou.com,fuck,共产党,urban,我操,cao,他妈的,TMD,鸡巴,煞笔,傻B,法轮功,江泽民,"+
                "胡锦涛,温家宝,urban-rivals,rivals,我日,UR,ur,性交,口交,婊子,妓女,他妈,她妈,牛逼,牛B，牛比,煞笔,傻逼,傻B,八仙,八 仙,八 仙,eight仙,混沌诀,混沌,你妈,操你妈,装逼,装B,日你妈,不玩了,删号,卖号,垃圾游戏,"+
                "烂游戏,删 号,妈的,妈逼,草你妈,T.M.D,JB,jb,淘宝,出售账号,出售此号,卖号,U/R,U-R,j8,吗的,8仙,狗日,出售神符,色情,黄色,h站,龙虎,虎门,龙 虎 门,WEB牌戰,WEB战牌,战牌,8 仙,街头对抗,藏独,台独,法轮大法,"+
                "混 沌决,ur,UR,urban,鸡巴,毛泽东,NPC,*法*轮*功*,*李*洪*志*,@sshole,a$$hole,a$shole,Admin,as$hole,ASS,asshole,bastard,bbscity,beijingspring,bignews,bitch,Bitch,bjzc,boxun,bt,butthead,butthole,cctv,"+
                "CCTV,cdjp,chengmingmag,chinesenewsweek,cunt,dajiyuan,damm,damn,dick,Dick,DICK,epochtimes,F.L.G,falun,fawanghuihui,fgmtv,flg,FLG,fofg,fosaon,fu(,fuc,Fuck,fuck,FUCK,FUCKYOU,fuckyou,fuk,fv(,fvc,"+
                "gamemaster,GAMEMASTER,gameMASTER,GAMEmaster,ＧＡＭＥ　ｍａｓｔｅｒ,ｇａｍｅ　ＭＡＳＴＥＲ,ＧＡＭＥ　ＭＡＳＴＥＲ,ｇａｍｅ　ｍａｓｔｅｒ,GameMaste,GameMaster,GAMEMASTER,gc365,globalrescue,Gm,gM,"+
                "gm,minghui,mingpaonews,minhui,NMD,NND,nnd,on9,ON9,orgasmus,peacehall,penis,phuc,piss,PUSSY,pussy,renminbao,ri,SB,sb,screw,secretchina,sega,sex,sf,sh!t,shengda,SHIT,shit,shyt,SM,snatch,soundofhope,"+
                "SUCK,suck,Suck,TMD,tmd,TNND,tnnd,WG,wg,WG,Wg,wG,wg,xinguangming,xinsheng,yuanming,zhengjian,zhengqing,zhengwunet,zhongguohun,阿扁,阿扁万岁,阿拉,阿拉法特,挨球,安南,安全局,澳洲光明网,八九,八九风波,"+
                "办理文凭,办理证件,包皮,保钓,保监会,保密局,鸨,鲍岳桥,暴动,暴乱,暴徒,北京之春,贝肉,本?拉登,本?拉登,苯比,笨屄,笨逼,屄,屄毛,逼毛,逼你老母,逼样,比毛,婊,婊子,宾周,冰毒,波霸,博讯,薄一波,布莱尔,布雷尔,"+
                "布什,布什,财政部,参事室,藏独,藏独,藏独,操,操GM,操Gm,操gM,操gm,操XX,操逼,操比,操蛋,操你,操你八辈祖宗,操你妈,操你妈屄,操他,曹刚川,草的你妈,草妈,草你妈,草拟妈,肏,测绘局,插GM,插Gm,插gM,插gm,插妳,"+
                "插你,插你妈,插深些,产权局,朝鲜,车臣,车仑,陈功,陈良宇,陈水扁,陈希同,陈晓宁,陈毅,陈至立,成人电影,成人片,吃大便,吃屎,迟浩田,赤匪,抽插,抽你丫的,臭化西,出售假币,出售枪支,出售手枪,吹喇叭,吹箫,春药,"+
                "蠢猪,戳你,粗制吗啡,催情药,达赖,达赖喇嘛,打炮,大*FA弟*子,大B,大逼,大便,大波波,大东亚共荣,大法,大法弟子,大花B,大会堂,大纪元,大麻,大麻树脂,大麻油,大师,戴维教,大学骚乱,大血B,大血比,呆卵,代表大会,"+
                "戴海静,戴红,戴晶,戴维教,党主席,荡妇,档案局,盗窃犯,盗窃犯,道教,邓小平,地震局,弟大物勃,帝国主义,帝国主义,电监会,叼你,叼你妈,屌,屌7,屌鸠,屌毛,屌妳,屌七,屌西,钓鱼台,调理劳务系,丁关根,丁子霖,东北独立,"+
                "东升,东条英机,东突,东突暴动和独立,东突组织,东亚病夫,董建华,董贱华,董文华,懂文华,独立,独立台湾会,短信群发器,对日强硬,多维社,多维网,多维新闻,多维周刊,恶搞晚会,恩格斯,二B,二屄,二逼,二乙基酰胺,发改委,"+
                "发奖使者,发抡,发抡功,发伦,发伦功,发轮,发论,发论公,发论功,发骚,发展研究中心,发正念,法(轮)功,法*轮*功,法功,法愣,法仑,法轮,法轮大法,法轮功,法西斯,法制办,反动,反封锁技术,反革命,反共,反华,反恐委员会,"+
                "反日,反政府,分裂祖国,佛教,佛展千手法,佛祖,斧头镰刀,阝月,傅鹏,傅作义,干GM,干Gm,干gM,干gm,干拎娘,干妳,干妳老母,干妳妈,干妳娘,干你,干你妈,干你妈b,干你妈逼,干你娘,干七八,干死你,肛,肛交,肛门,港澳办,"+
                "高俊,高丽棒子,高校暴乱,高校群体事件,高校骚乱,睾,睾丸,膏药旗,工力,工商局,工作人员,弓虽女干,公安,公安部,公安局,共产党,共产主义,共匪,共狗,共青团员,狗b,狗操,狗卵,狗娘,狗屁,狗日,狗日的,狗屎,狗养,"+
                "古方迷香,观世音,官逼民反,官商勾结,管理人员,管理员,光明日报,广电局,龟儿子,龟公,龟孙子,龟头,鬼村,滚,郭伯雄,国安局,国防部,国防科工委,国管局,国际法院,国家民委,国家主席,国家主要部委,国民党,国民党万岁,"+
                "国土资源部,国务院,国研室,国资委,哈批,海关总署,海洛因,海洋局,何候华,贺国强,贺龙,黑社会,黑手党,黑手党,黑手党,红卫兵,洪兴,洪志,后庭,胡XX,胡紧涛,胡紧掏,胡紧套,胡锦涛,胡锦淘,胡乔木,胡耀邦,胡主席,花柳,"+
                "华国锋,华建敏,欢城,欢城互动,环保总局,换妻,黄　菊,黄菊,黄色电影,黄色小电影,回回,回教,回良玉,回民暴动,回族人吃猪肉,昏药,火棒,机八,机巴,鸡八,鸡巴,鸡叭,鸡芭,鸡掰,鸡鸡,鸡奸,基地组织,基督,基督教,"+
                "激情电影,激情小电影,鸡,几届中央政治局委员,计牌软件,计生委,妓,妓女,妓院,佳静安定片,贾庆林,奸,奸夫淫妇,奸你,奸淫,监察部,监管局,监听王,检察院,建设部,贱,贱逼,贱货,贱人,江Core,江八,江八点,江独裁,"+
                "江核心,江青,江戏子,江择民,江泽民,江贼民,江折民,江猪,江猪媳,江主席,僵贼民,疆独,蒋介石,蒋经国,蒋中正,酱猪媳,交通部,姣西,叫床,叫鸡,叫小姐,教育部,她妈的,届中央政治局委员,金日成,金正日,禁书,"+
                "经济社会理事会,经社理事会,精液,精子,警匪一家,敬国神社,靖国神社,静坐,纠察员,鸠,鸠屎,军长发威,军国主义,军妓,军事委员会,军委,看牌器,看牌软件,看棋器,看棋软件,抗日,尻,靠,靠你妈,靠腰,可待因,可卡叶,"+
                "可卡因,克林顿,客服,客户服务人员,恐怖份子,恐怖主义,口交,寇晓伟,狂操,狂操你全家,拉登,拉姆斯菲尔德,懒教,烂B,烂屄,烂逼,烂比,烂屌,烂货,劳+教+所,劳动保障部,老逼,老毛子,老母,黎阳评,李长春,李登辉,李弘旨,"+
                "李红志,李宏旨,李宏志,李洪志,李岚清,李鹏,李鹏*,李瑞环,李山,李铁映,李先念,连战,联大,联合国,联合国大会,联易,联易互动,粮食局,两腿之间,列宁,林彪,林业局,刘　淇,刘军,刘淇,刘少奇,刘云山,流氓,六.四,六。四,"+
                "六?四,六合彩,六四,六-四,六四事件,六四真相,龙新民,吕秀莲,旅游局,卵,轮功,轮奸,罗　干,罗干,骡干,妈逼,妈比,妈卖妈屁,妈批,妈祖,妈B,妈的,麻醉钢枪,麻醉枪,麻醉药,麻醉乙醚,马克思,马卖马屁,马英九,吗啡,"+
                "吗啡碱,吗啡片,买财富,买卖枪支,麦角酸,卖.国,卖B,卖ID,卖QQ,卖逼,卖比,卖财富,卖党求荣,卖国,卖国求荣,卖号,卖卡,卖软件,卖淫,毛XX,毛厕洞,毛一鲜,毛泽东,毛贼东,毛主席,梅花网,美国,美国佬,美国之音,美利坚,"+
                "蒙尘药,蒙独,蒙古达子,蒙古独立,迷魂药,迷奸药,迷歼药,迷药,密洞,密宗,民航局,民进党,民运,民政部,明慧网,摩门教,莫索里尼,穆罕默德,穆斯林,乳头,奶子,妳老母的,妳妈的,妳马的,妳娘的,南联盟,南蛮子,南蛮子,嫩B,"+
                "嫩b,伱妈,你爸,你大爷,你二大爷,你老母,你老味,你姥,你姥姥的,你妈,你妈逼,你妈的,你娘,你爷爷的,鸟GM,鸟Gm,鸟gM,鸟gm,鸟你,牛逼,牛比,农业部,虐待,拍肩神药,喷你,彭真,皮条,屁眼,嫖客,苹果日报,破坏,破鞋,仆街,"+
                "普京,气象局,钱其琛,枪决女犯,枪决现场,枪支弹药,强奸,强奸犯,强卫,强效失意药,强硬发言,抢劫,乔石,侨办,切七,窃听器,窃听器材,亲民党,青天白日,情色,去你妈的,去死,全国人大,瘸腿帮,人大,人大代表,人代会,人弹,"+
                "人民,人民大会堂,人民广场,人民日报,人民银行,人体炸弹,日GM,日Gm,日gM,日gm,日X妈,日本RING,日本鬼子,日你,日你妈,日你娘,日他娘,肉棒,肉壁,肉洞,肉缝,肉棍,肉棍子,肉穴,乳,乳波臀浪,乳房,乳交,乳头,撒尿,"+
                "萨达姆,塞白,塞你爸,塞你公,塞你老母,塞你老师,塞你母,塞你娘,三个呆婊,三个代婊,三级片,三民主义,三陪,三陪女,三去车仑,三唑仑,骚,骚B,骚逼,骚货,骚,色情,色情电影,色情服务,色情小电影,杀人犯,傻B,傻屄,傻逼,"+
                "傻比,傻吊,傻卵,傻子,煞逼,商务部,上妳,上你,社.会.正.义.力.量,社保基金会,社会主义,社科院,射精,身份生成器,神经病,神通加持法,审计署,升达毕业证,生春袋,生孩子没屁眼,生鸦片,圣女峰,湿透的内裤,十八摸,"+
                "十年动乱,十五周年,石进,食捻屎,食屎,驶你爸,驶你公,驶你老母,驶你老师,驶你母,驶你娘,世界日报,是鸡,手机复制,手淫,受虐狂,售ID,售号,售软件,双峰微颤,氵去,水利部,水去车仑,税务总局,司法部,私服,私/服,"+
                "私\\服,私服,私-服,私—服,斯大林,死gd,死GD,死gm,死GM,死全家,四川独立,四人帮,宋楚瑜,宋祖英,孙文,孙逸仙,孙中山,他爹,他妈,他妈的,他马的,他母亲,他祖宗,台办,台独,台联,台湾党,台湾帝国,台湾独立,"+
                "台湾共产党,台湾共和国,台湾狗,台湾国,台湾民国,太监,太子党,唐家璇,特别公告,特码,体育总局,天安门,天安门档案,天安门录像带,天安门事件,天安门屠杀,天安门一代,天鹅之旅,天皇,天皇陛下,田纪云,舔西,铁道部,"+
                "统计局,投毒杀人,透视软件,透视眼镜,推油,退党,托管理事会,外　挂,外挂,外/挂,外\\挂,外_挂,外挂,外-挂,外—挂,外汇局,外交部,外专局,晚年周恩来,万税,王八蛋,王宝森,王刚,王昊,王乐泉,王岐山,王太华,王兆国,"+
                "王震,网管,威而钢,威而柔,卫生部,尉健行,温加宝,温家宝,温家保,温馨,温总理,文化部,文物局,倭国,倭寇,我操,我操你,我干,我妳老爸,我日,我日你,无界浏览器,吴　仪,吴邦国,吴官正,吴仪,五星红旗,西藏独立,"+
                "西藏天葬,希拉克,希特勒,希望之声,洗脑班,系统,系统公告,系统讯息,鲜族,乡巴佬,想上你,小鸡鸡,小泉,小泉纯一郎,小日本,小肉粒,小乳头,小穴,邪教,新党,新光明,新华内情,新华社,新疆独立,新生网,新手指导员,"+
                "新唐人,新闻办,新闻出版,新闻出版署,新闻出版总署,新闻管制,新义安,信访局,信息产业部,兴奋剂,性爱,性交,性虐待,性无能,性欲,徐光春,学潮,血逼,血腥图片,巡查员,丫的,丫头养的,鸦片,鸦片液,鸦片渣,烟草局,"+
                "严方军,燕玲论坛,阳精,阳具,摇头丸,摇头玩,耶和华,耶苏,耶稣,叶剑英,夜情,一党专制,一贯道,一国两制,一夜情,一中一台,伊拉克,伊朗,伊斯兰,以茎至洞,抑制剂,阴部,阴唇,阴道,阴蒂,阴核,阴户,阴茎,阴毛,阴水,"+
                "阴小撕大,淫,淫荡,淫秽,淫货,淫贱,淫叫,淫毛,淫靡,淫水,淫娃,淫语连连,淫欲,英雄纪念碑,硬挺,邮政局,游戏发奖员,游戏宫理员,游戏管理员,游行,俞正声,舆论钳制,玉杵,欲火焚身,原子能机构,援交,远程偷拍,曰GM,"+
                "曰Gm,曰gM,曰gm,曰你,月经,月经不调,月经,扎卡维是英雄,杂种,造反,曾培炎,曾庆红,扎卡维,扎卡维是英雄,张朝阳,张潮阳,张德江,张磊,张立昌,张小平,赵紫阳,侦探设备,真理教,真善忍,镇压,正见网,正清网,正悟网,"+
                "证监会,政变,政协,值勤,值勤账号,指导员,质检局,致幻剂,中共,中共中央,中国,中国共产党,中国恐怖组织,中华民国,中华人民共和国,中科院,中南海,中宣部,中央,中央电视台,中央政治局,中医药局,周恩来,周永康,"+
                "周总理,朱德,朱容鸡,朱容基,朱熔基,朱镕基,朱总理,猪操,猪容基,主席,转法轮,转法轮,装屄,装逼,追查国际,子女任职名单,自焚,自杀手册,自杀指南,自由亚洲电台,自由之门,自制手枪,自治机关,宗教,总局,总理,作爱,"+
                "坐台的,做爱,共产党,江泽民,胡锦涛,温家宝,严方军,信息,礼品,领取,admin靠,UR靠,fuck靠,共产党靠,urban靠,我操靠,cao靠,他妈的靠,TMD靠,鸡巴靠,煞笔靠,傻B靠,法轮功靠,江泽民靠,胡锦涛靠,温家宝靠,"+
                "urban-rivals靠,rivals靠,u r靠,ur靠,我日靠,U  R靠,u  r靠,性交靠,口交靠,U R靠,taobao靠,webgame.com.cn靠,婊子靠,妓女靠,他妈靠,她妈靠,牛逼靠,牛比靠,牛B靠,煞笔靠,傻逼靠,傻B靠,八仙靠,八 仙靠,八 仙靠,"+
                "eight仙靠,∪R靠,混沌诀靠,混沌靠,你妈靠,操你妈靠,装逼靠,装B靠,日你妈靠,不玩了靠,删号靠,卖号靠,垃圾游戏靠,烂游戏靠,删 号靠,妈的靠,妈逼靠,草你妈靠,T.M.D靠,JB靠,jb靠,淘宝靠,出售账号靠,出售此号靠,"+
                "卖号靠,U/R靠,U-R靠,c a o靠,j8靠,吗的靠,8仙靠,狗日靠,出售神符靠,色情靠,黄色靠,h站靠,龙虎靠,虎门靠,龙 虎 门靠,WEB牌戰靠,WEB战牌靠,战牌靠,8 仙靠,ＵＲ靠,u   r靠,U   R靠,街头对抗靠,藏独靠,台独靠,"+
                "法轮大法靠,混 沌决靠,ur靠,UR靠,urban靠,鸡巴靠,毛泽东靠,NPC靠,*法*轮*功*靠,*李*洪*志*靠,@sshole靠,13点靠,2逼靠,6?4靠,610办公室靠,8?9靠,a$$hole,屄毛,操逼毛,操逼你老母,操逼样,操比毛,操婊,操婊子,"+
                "操宾周,操冰毒,操波霸,操博讯,操薄一波,操布莱尔,操布雷尔,操布什,操布什,操财政部,操参事室,操藏独,操藏独,操藏独,操操,操操GM,操操Gm,操操gM,操操gm,操操XX,操操逼,操操比,操操蛋,操操你,操操你八辈祖宗,"+
                "操操你妈,操操你妈屄,操操他,操曹刚川,操草的你妈,操草妈,操草你妈,操草拟妈,操肏,操测绘局,操插GM,操插Gm,操插gM,操插gm,操插妳,操插你,操插你妈,操插深些,操产权局,操朝鲜,操车臣,操车仑,操陈功,操陈良宇,"+
                "操陈水扁,操陈希同,操陈晓宁,操陈毅,操陈至立,操成人电影,操成人片,操吃大便,操吃屎,操迟浩田,操赤匪,操抽插,操抽你丫的,操臭化西,操出售假币,操出售枪支,操出售手枪,操吹喇叭,操吹箫,操春药,操蠢猪,操戳你,"+
                "操粗制吗啡,操催情药,操达赖,操达赖喇嘛,操打炮,操大*FA弟*子,操大B,操大逼,操大便,操大波波,操大东亚共荣,操大法,东突,毛东突暴动和独立,毛东突组织,毛东亚病夫,毛董建华,毛董贱华,毛董文华,毛懂文华,毛独立,"+
                "毛独立台湾会,毛短信群发器,毛对日强硬,毛多维社,毛多维网,毛多维新闻,毛多维周刊,毛恶搞晚会,毛恩格斯,毛二B,毛二屄,毛二逼,毛二乙基酰胺,毛发改委,毛发奖使者,毛发抡,毛发抡功,毛发伦,毛发伦功,毛发轮,毛发论,"+
                "毛发论公,毛发论功,毛发骚,毛发展研究中心,毛发正念,毛法(轮)功,毛法*轮*功,毛法功,毛法愣,毛法仑,毛法轮,毛法轮大法,毛法轮功,毛法西斯,毛法制办,毛反动,毛反封锁技术,毛反革命,毛反共,毛反华,毛反恐委员会,"+
                "毛反日,毛反政府,毛分裂祖国,毛佛教,毛佛展千手法,毛佛祖,毛斧头镰刀,毛阝月,毛傅鹏,毛傅作义,毛干GM,毛干Gm,毛干gM,毛干gm,毛干拎娘,毛干妳,毛干妳老母,毛干妳妈,毛干妳娘,毛干你,毛干你妈,毛干你妈b,"+
                "毛干你妈逼,毛干你娘,毛干七八,毛干死你,毛肛,毛肛交,毛肛门,毛港澳办,毛高俊,毛高丽棒子,毛高校暴乱,毛高校群体事件,毛高校骚乱,毛睾,毛睾丸,毛膏药旗,毛工力,毛工商局,毛工作人员,毛弓虽女干,毛公安,"+
                "毛公安部,毛公安局,毛共产党,毛共产主义,毛共匪,毛共狗,毛共青团员,毛狗b,毛狗操,毛狗卵,毛狗娘,毛狗屁,毛狗日,毛狗日的,毛狗屎,毛狗养,毛古方迷香,毛观世音,毛官逼民反,毛官商勾结,毛管理人员,毛管理员,"+
                "毛光明日报,毛广电局,毛龟儿子,毛龟公,毛龟孙子,毛龟头,毛鬼村,毛滚,毛郭伯雄,毛国安局,毛国防部,毛国防科工委,毛国管局,毛国际法院,毛国家民委,毛国家主席,毛国家主要部委,毛国民党,毛国民党万岁,毛国土资源部,"+
                "毛国务院,毛国研室,毛国资委,毛哈批,毛海关总署,毛海洛因,毛海洋局,毛何候华,毛贺国强,毛贺龙,毛黑社会,毛黑手党,毛黑手党,毛黑手党,毛红卫兵,毛洪兴,毛洪志,毛后庭,毛胡XX,毛胡紧涛,毛胡紧掏,毛胡紧套,"+
                "毛胡锦涛,毛胡锦淘,毛胡乔木,毛胡耀邦,毛胡主席,毛花柳,毛华国锋,毛华建敏,毛欢城,毛欢城互动,毛环保总局,毛换妻,毛黄　菊,毛黄菊,毛黄色电影,毛黄色小电影,毛回回,毛回教,毛回良玉,毛回民暴动,毛回族人吃猪肉,"+
                "毛昏药,毛火棒,毛机八,毛机巴,毛鸡八,毛鸡巴,毛鸡叭,毛鸡芭,毛鸡掰,毛鸡鸡,毛鸡奸,毛基地组织,毛基督,毛基督教,毛激情电影,毛激情小电影,毛鸡,毛几届中央政治局委员,毛计牌软件,毛计生委,毛妓,毛妓女,毛妓院,"+
                "毛佳静安定片,毛贾庆林,毛奸,毛奸夫淫妇,毛奸你,毛奸淫,毛监察部,毛监管局,毛监听王,毛检察院,毛建设部,毛贱,毛贱逼,毛贱货,毛贱人,毛江Core,毛江八,毛江八点,毛江独裁,毛江核心,毛江青,毛江戏子,毛江择民,"+
                "毛江泽民,毛江贼民,毛江折民,毛江猪,毛江猪媳,毛江主席,毛僵贼民,毛疆独,毛蒋介石,毛蒋经国,毛蒋中正,毛酱猪媳,毛交通部,毛姣西,毛叫床,毛叫鸡,毛叫小姐,毛教育部,毛她妈的,毛届中央政治局委员,毛金日成,"+
                "毛金正日,毛禁书,毛经济社会理事会,毛经社理事会,毛精液,毛精子,毛警匪一家,毛敬国神社,毛靖国神社,毛静坐,毛纠察员,毛鸠,毛鸠屎,毛军长发威,毛军国主义,毛军妓,毛军事委员会,毛军委,毛看牌器,毛看牌软件,"+
                "毛看棋器,毛看棋软件,毛抗日,毛尻,毛靠,毛靠你妈,毛靠腰,毛可待因,毛可卡叶,毛可卡因,毛克林顿,毛客服,毛客户服务人员,毛恐怖份子,毛恐怖主义,毛口交,毛寇晓伟,毛狂操,毛狂操你全家,毛拉登,毛拉姆斯菲尔德,"+
                "毛懒教,毛烂B,毛烂屄,毛烂逼,毛烂比,毛烂屌,毛烂货,毛劳+教+所,毛劳动保障部,毛老逼,毛老毛子,毛老母,毛黎阳评,毛李长春,毛李登辉,毛李弘旨,毛李红志,毛李宏旨,毛李宏志,毛李洪志,毛李岚清,毛李鹏,毛李鹏*,"+
                "毛李瑞环,毛李山,毛李铁映,毛李先念,毛连战,毛联大,毛联合国,毛联合国大会,毛联易,毛联易互动,毛粮食局,毛两腿之间,毛列宁,毛林彪,毛林业局,毛刘　淇,毛刘军,毛刘淇,毛刘少奇,毛刘云山,毛流氓,毛六.四,毛六。四,"+
                "毛六?四,毛六合彩,毛六四,毛六-四,毛六四事件,毛六四真相,毛龙新民,毛吕秀莲,毛旅游局,毛卵,毛轮功,毛轮奸,毛罗　干,毛罗干,毛骡干,毛妈逼,毛妈比,毛妈卖妈屁,毛妈批,毛妈祖,毛妈B,毛妈的,毛麻醉钢枪,毛麻醉枪,"+
                "毛麻醉药,毛麻醉乙醚,毛马克思,毛马卖马屁,毛马英九,毛吗啡,毛吗啡碱,毛吗啡片,毛买财富,毛买卖枪支,毛麦角酸,毛卖.国,毛卖B,毛卖ID,毛卖QQ,毛卖逼,毛卖比,毛卖财富,毛卖党求荣,毛卖国,毛卖国求荣,毛卖号,"+
                "毛卖卡,毛卖软件,毛卖淫,毛毛XX,毛毛厕洞,毛毛一鲜,毛毛泽东,毛毛贼东,毛毛主席,毛梅花网,毛美国,毛美国佬,毛美国之音,毛美利坚,毛蒙尘药,毛蒙独,毛蒙古达子,毛蒙古独立,毛迷魂药,毛迷奸药,毛迷歼药,毛迷药,"+
                "毛密洞,毛密宗,毛民航局,毛民进党,毛民运,毛民政部,毛明慧网,毛摩门教,毛莫索里尼,毛穆罕默德,毛穆斯林,毛乳头,毛奶子,毛妳老母的,毛妳妈的,毛妳马的,毛妳娘的,毛南联盟,毛南蛮子,毛南蛮子,毛嫩B,毛嫩b,毛伱妈,"+
                "毛你爸,毛你大爷,毛你二大爷,毛你老母,毛你老味,毛你姥,毛你姥姥的,毛你妈,毛你妈逼,毛你妈的,毛你娘,毛你爷爷的,毛鸟GM,毛鸟Gm,毛鸟gM,毛鸟gm,毛鸟你,毛牛逼,毛牛比,毛农业部,毛虐待,毛拍肩神药,毛喷你,毛彭真,"+
                "毛皮条,毛屁眼,毛嫖客,毛苹果日报,毛破坏,毛破鞋,毛仆街,毛普京,毛气象局,毛钱其琛,毛枪决女犯,毛枪决现场,毛枪支弹药,毛强奸,毛强奸犯,毛强卫,毛强效失意药,毛强硬发言,毛抢劫,毛乔石,毛侨办,毛切七,毛窃听器,"+
                "毛窃听器材,毛亲民党,毛青天白日,毛情色,毛去你妈的,毛去死,毛全国人大,毛瘸腿帮,毛人大,毛人大代表,毛人代会,毛人弹,毛人民,毛人民大会堂,毛人民广场,毛人民日报,毛人民银行,毛人体炸弹,毛日GM,毛日Gm,毛日gM,"+
                "毛日gm,毛日X妈,毛日本RING,毛日本鬼子,毛日你,毛日你妈,毛日你娘,毛日他娘,毛肉棒,毛肉壁,毛肉洞,毛肉缝,毛肉棍,毛肉棍子,毛肉穴,毛乳,毛乳波臀浪,毛乳房,毛乳交,毛乳头,毛撒尿,毛萨达姆,毛塞白,毛塞你爸,"+
                "毛塞你公,毛塞你老母,毛塞你老师,毛塞你母,毛塞你娘,毛三个呆婊,毛三个代婊,毛三级片,毛三民主义,毛三陪,毛三陪女,毛三去车仑,毛三唑仑,毛骚,毛骚B,毛骚逼,毛骚货,毛骚,毛色情,毛色情电影,毛色情服务,"+
                "毛色情小电影,毛杀人犯,毛傻B,毛傻屄,毛傻逼,毛傻比,毛傻吊,毛傻卵,毛傻子,毛煞逼,毛商务部,毛上妳,毛上你,毛社.会.正.义.力.量,毛社保基金会,毛社会主义,毛社科院,毛射精,毛身份生成器,毛神经病,毛神通加持法,"+
                "毛审计署,毛升达毕业证,毛生春袋,毛生孩子没屁眼,毛生鸦片,毛圣女峰,毛湿透的内裤,毛十八摸,毛十年动乱,毛十五周年,毛石进,毛食捻屎,毛食屎,毛驶你爸,毛驶你公,毛驶你老母,毛驶你老师,毛驶你母,毛驶你娘,"+
                "毛世界日报,毛是鸡,毛手机复制,毛手淫,毛受虐狂,毛售ID,毛售号,毛售软件,毛双峰微颤,毛氵去,毛水利部,毛水去车仑,毛税务总局,毛司法部,毛私服,毛私/服,毛私\\服,毛私服,毛私-服,毛私—服,毛斯大林,毛死gd,"+
                "毛死GD,毛死gm,毛死GM,毛死全家,毛四川独立,毛四人帮,毛宋楚瑜,毛宋祖英,毛孙文,毛孙逸仙,毛孙中山,毛他爹,毛他妈,毛他妈的,毛他马的,毛他母亲,毛他祖宗,毛台办,毛台独,毛台联,毛台湾党,毛台湾帝国,毛台湾独立,"+
                "毛台湾共产党,毛台湾共和国,毛台湾狗,毛台湾国,毛台湾民国,毛太监,毛太子党,毛唐家璇,毛特别公告,毛特码,毛体育总局,毛天安门,毛天安门档案,毛天安门录像带,毛天安门事件,毛天安门屠杀,毛天安门一代,毛天鹅之旅,"+
                "毛天皇,毛天皇陛下,毛田纪云,毛舔西,毛铁道部,毛统计局,毛投毒杀人,毛透视软件,毛透视眼镜,毛推油,毛退党,毛托管理事会,毛外　挂,毛外挂,毛外/挂,毛外\\挂,毛外_挂,毛外挂,毛外-挂,毛外—挂,毛外汇局,毛外交部,"+
                "毛外专局,毛晚年周恩来,毛万税,毛王八蛋,毛王宝森,毛王刚,毛王昊,毛王乐泉,毛王岐山,毛王太华,毛王兆国,毛王震,毛网管,毛威而钢,毛威而柔,毛卫生部,毛尉健行,毛温加宝,毛温家宝,毛温家保,毛温馨,毛温总理,"+
                "毛文化部,毛文物局,毛倭国,毛倭寇,毛我操,毛我操你,毛我干,毛我妳老爸,毛我日,毛我日你,毛无界浏览器,毛吴　仪,毛吴邦国,毛吴官正,毛吴仪,毛五星红旗,毛西藏独立,毛西藏天葬,毛希拉克,毛希特勒,毛希望之声,"+
                "毛洗脑班,毛系统,毛系统公告,毛系统讯息,毛鲜族,毛乡巴佬,毛想上你,毛小鸡鸡,毛小泉,毛小泉纯一郎,毛小日本,毛小肉粒,毛小乳头,毛小穴,毛邪教,毛新党,毛新光明,毛新华内情,毛新华社,毛新疆独立,毛新生网,"+
                "毛新手指导员,毛新唐人,毛新闻办,毛新闻出版,毛新闻出版署,毛新闻出版总署,毛新闻管制,毛新义安,毛信访局,毛信息产业部,毛兴奋剂,毛性爱,毛性交,毛性虐待,毛性无能,毛性欲,毛徐光春,毛学潮,毛血逼,毛血腥图片,"+
                "毛巡查员,毛丫的,毛丫头养的,毛鸦片,毛鸦片液,毛鸦片渣,毛烟草局,毛严方军,毛燕玲论坛,毛阳精,毛阳具,毛摇头丸,毛摇头玩,毛耶和华,毛耶苏,毛耶稣,毛叶剑英,毛夜情,毛一党专制,毛一贯道,毛一国两制,毛一夜情,"+
                "毛一中一台,毛伊拉克,毛伊朗,毛伊斯兰,毛以茎至洞,毛抑制剂,毛阴部,毛阴唇,毛阴道,毛阴蒂,毛阴核,毛阴户,毛阴茎,毛阴毛,毛阴水,毛阴小撕大,毛淫,毛淫荡,毛淫秽,毛淫货,毛淫贱,毛淫叫,毛淫毛,毛淫靡,毛淫水,"+
                "毛淫娃,毛淫语连连,毛淫欲,毛英雄纪念碑,毛硬挺,毛邮政局,毛游戏发奖员,毛游戏宫理员,毛游戏管理员,毛游行,毛俞正声,毛舆论钳制,毛玉杵,毛欲火焚身,毛原子能机构,骚货,fuck骚,fuck色情,fuck色情电影,"+
                "fuck色情服务,fuck色情小电影,fuck杀人犯,fuck傻B,fuck傻屄,fuck傻逼,fuck傻比,fuck傻吊,fuck傻卵,fuck傻子,fuck煞逼,fuck商务部,fuck上妳,fuck上你,fuck社.会.正.义.力.量,fuck社保基金会,fuck社会主义,"+
                "fuck社科院,fuck射精,fuck身份生成器,fuck神经病,fuck神通加持法,fuck审计署,fuck升达毕业证,fuck生春袋,fuck生孩子没屁眼,fuck生鸦片,fuck圣女峰,fuck湿透的内裤,fuck十八摸,fuck十年动乱,fuck十五周年,"+
                "fuck石进,fuck食捻屎,fuck食屎,fuck驶你爸,fuck驶你公,fuck驶你老母,fuck驶你老师,fuck驶你母,fuck驶你娘,fuck世界日报,fuck是鸡,fuck手机复制,fuck手淫,fuck受虐狂,fuck售ID,fuck售号,fuck售软件,"+
                "fuck双峰微颤,fuck氵去,fuck水利部,fuck水去车仑,fuck税务总局,fuck司法部,fuck私服,fuck私/服,fuck私\\服,fuck私服,fuck私-服,fuck私—服,fuck斯大林,fuck死gd,fuck死GD,fuck死gm,fuck死GM,fuck死全家,"+
                "fuck四川独立,fuck四人帮,fuck宋楚瑜,fuck宋祖英,fuck孙文,fuck孙逸仙,fuck孙中山,fuck他爹,fuck他妈,fuck他妈的,fuck他马的,fuck他母亲,fuck他祖宗,fuck台办,fuck台独,fuck台联,fuck台湾党,fuck台湾帝国,"+
                "fuck台湾独立,fuck台湾共产党,fuck台湾共和国,fuck台湾狗,fuck台湾国,fuck台湾民国,fuck太监,fuck太子党,fuck唐家璇,fuck特别公告,fuck特码,fuck体育总局,fuck天安门,fuck天安门档案,fuck天安门录像带,"+
                "fuck天安门事件,fuck天安门屠杀,fuck天安门一代,fuck天鹅之旅,fuck天皇,fuck天皇陛下,fuck田纪云,fuck舔西,fuck铁道部,fuck统计局,fuck投毒杀人,fuck透视软件,fuck透视眼镜,fuck推油,fuck退党,fuck托管理事会,"+
                "fuck外　挂,fuck外挂,fuck外/挂,fuck外\\挂,fuck外_挂,fuck外挂,fuck外-挂,fuck外—挂,fuck外汇局,fuck外交部,fuck外专局,fuck晚年周恩来,fuck万税,fuck王八蛋,fuck王宝森,fuck王刚,fuck王昊,fuck王乐泉,"+
                "fuck王岐山,fuck王太华,fuck王兆国,fuck王震,fuck网管,fuck威而钢,fuck威而柔,fuck卫生部,fuck尉健行,fuck温加宝,fuck温家宝,fuck温家保,fuck温馨,fuck温总理,fuck文化部,fuck文物局,fuck倭国,fuck倭寇,"+
                "fuck我操,fuck我操你,fuck我干,fuck我妳老爸,fuck我日,fuck我日你,fuck无界浏览器,fuck吴　仪,fuck吴邦国,fuck吴官正,fuck吴仪,fuck五星红旗,fuck西藏独立,fuck西藏天葬,fuck希拉克,fuck希特勒,fuck希望之声,"+
                "fuck洗脑班,fuck系统,fuck系统公告,fuck系统讯息,fuck鲜族,fuck乡巴佬,fuck想上你,fuck小鸡鸡,fuck小泉,fuck小泉纯一郎,fuck小日本,fuck小肉粒,fuck小乳头,fuck小穴,fuck邪教,fuck新党,fuck新光明,fuck新华内情,"+
                "fuck新华社,fuck新疆独立,fuck新生网,fuck新手指导员,fuck新唐人,fuck新闻办,fuck新闻出版,fuck新闻出版署,fuck新闻出版总署,fuck新闻管制,fuck新义安,fuck信访局,fuck信息产业部,fuck兴奋剂,fuck性爱,fuck性交,"+
                "法轮功,江泽民,胡锦涛,温家宝,urban-rivals,rivals,u r,ur,我日,UR,ur,性交,口交,U R,taobao,webgame.com.cn,婊子,妓女,他妈,她妈,牛逼,牛比,牛B,煞笔,傻逼,傻B,八仙,八 仙,八 仙,eight仙,∪R,混沌诀,混沌,你妈,"+
                "操你妈,装逼,装B,日你妈,不玩了,删号,卖号,垃圾游戏,烂游戏,删 号,妈的,妈逼,草你妈,T.M.D,JB,jb,淘宝,出售账号,出售此号,卖号,U/R,U-R,c a o,j8,吗的,8仙,狗日,出售神符,色情,黄色,h站,龙虎,虎门,龙 虎 门,"+
                "WEB牌戰,WEB战牌,战牌,8 仙,ＵＲ,ur,UR,街头对抗,藏独,台独,法轮大法,混 沌决,ur,UR,urban,鸡巴,毛泽东,NPC,a$$hole,a$shole,Admin,as$hole,ASS,asshole,bastard,bbscity,beijingspring,bignews,bitch,Bitch,"+
                "bjzc,boxun,bt,butthead,cctv,CCTV,cdjp,chengmingmag,chinesenewsweek,cunt,dajiyuan,damm,damn,dick,Dick,DICK,epochtimes,F.L.G,falun,fawanghuihui,fgmtv,flg,FLG,fofg,做爱,坐台的,作爱,总理,总局,宗教,"+
                "自治机关,自制手枪,自由之门,自由亚洲电台,自杀指南,自杀手册,自焚,子女任职名单,追查国际,装逼,装逼,装屄,装B,转法轮,转法轮,主席,猪容基,猪操,朱总理,朱镕基,朱熔基,朱容基,朱容鸡,朱德,周总理,周永康,"+
                "周恩来,中医药局,中央政治局,中央电视台,中央,中宣部,中南海,中科院,中华人民共和国,中华民国,中国恐怖组织,中国共产党,中国,中共中央,中共,致幻剂,质检局,指导员,值勤账号,值勤,政协,政变,证监会,正悟网,"+
                "正清网,正见网,镇压,真善忍,真理教,侦探设备,赵紫阳,张小平,张立昌,张磊,张德江,张潮阳,张朝阳,战牌,扎卡维是英雄,扎卡维是英雄,扎卡维,曾庆红,曾培炎,造反,杂种,月经不调,月经,月经,曰你,曰GM,曰Gm,曰gM,"+
                "曰gm,远程偷拍,援交,原子能机构,欲火焚身,玉杵,舆论钳制,俞正声,游行,游戏管理员,游戏宫理员,游戏发奖员,邮政局,硬挺,英雄纪念碑,淫欲,淫语连连,淫娃,淫水,淫靡,淫毛,淫叫,淫贱,淫货,淫秽,淫荡,淫,阴小撕大"+
                ",阴水,阴毛,阴茎,阴户,阴核,阴蒂,阴道,阴唇,阴部,抑制剂,以茎至洞,伊斯兰,伊朗,伊拉克,一中一台,一夜情,一国两制,一贯道,一党专制,夜情,叶剑英,耶稣,耶苏,耶和华,摇头玩,摇头丸,阳具,阳精,燕玲论坛,严方军,"+
                "严方军,烟草局,鸦片渣,鸦片液,鸦片,丫头养的,丫的,巡查员,血腥图片,血逼,学潮,徐光春,性欲,性无能,性虐待,性交,性交,性爱,兴奋剂,信息产业部,信息,信访局,新义安,新闻管制,新闻出版总署,新闻出版署,新闻出版,"+
                "新闻办,新唐人,新手指导员,新生网,新疆独立,新华社,新华内情,新光明,新党,邪教,小穴,小乳头,小肉粒,小日本,小泉纯一郎,小泉,小鸡鸡,想上你,乡巴佬,鲜族,系统讯息,系统公告,系统,洗脑班,希望之声,希特勒,希拉克,"+
                "西藏天葬,西藏独立,五星红旗,吴仪,吴官正,吴邦国,吴　仪,无界浏览器,我日你,我日,我日,我妳老爸,我干,我操你,我操,我操,倭寇,倭国,文物局,文化部,温总理,温馨,温家保,温家宝,温家宝,温家宝,温加宝,尉健行,卫生部,"+
                "威而柔,威而钢,网管,王震,王兆国,王太华,王岐山,王乐泉,王昊,王刚,王宝森,王八蛋,万税,晚年周恩来,外专局,外交部,外汇局,外—挂,外-挂,外挂,外挂,外_挂,外\\挂,外/挂,外　挂,托管理事会,退党,推油,透视眼镜,"+
                "透视软件,投毒杀人,统计局,铁道部,舔西,田纪云,天皇陛下,天皇,天鹅之旅,天安门一代,天安门屠杀,天安门事件,天安门录像带,天安门档案,天安门,体育总局,特码,特别公告,淘宝,唐家璇,太子党,太监,台湾民国,台湾国,"+
                "台湾狗,台湾共和国,台湾共产党,台湾独立,台湾帝国,台湾党,台联,台独,台独,台办,他祖宗,他母亲,他马的,他妈的,他妈的,他妈,他妈,他爹,孙中山,孙逸仙,孙文,宋祖英,宋楚瑜,四人帮,四川独立,死全家,死gm,死GM,死gd,"+
                "死GD,斯大林,私—服,私-服,私服,私服,私\\服,私/服,司法部,税务总局,水去车仑,水利部,氵去,双峰微颤,售软件,售号,售ID,受虐狂,手淫,手机复制,是鸡,世界日报,驶你娘,驶你母,驶你老师,驶你老母,驶你公,驶你爸,"+
                "食屎,食捻屎,石进,十五周年,十年动乱,十八摸,湿透的内裤,圣女峰,生鸦片,生孩子没屁眼,生春袋,升达毕业证,审计署,神通加持法,神经病,身份生成器,射精,社科院,社会主义,社保基金会,社.会.正.义.力.量,上你,上妳,"+
                "商务部,删号,删 号,煞笔,煞笔,煞逼,傻子,傻卵,傻吊,傻比,傻逼,傻逼,傻屄,傻B,傻B,傻B,杀人犯,色情小电影,色情服务,色情电影,色情,色情,骚货,骚逼,骚B,骚,骚,三唑仑,三去车仑,三陪女,三陪,三民主义,三级片,"+
                "三个代婊,三个呆婊,塞你娘,塞你母,塞你老师,塞你老母,塞你公,塞你爸,塞白,萨达姆,撒尿,乳头,乳头,乳交,乳房,乳波臀浪,乳,肉穴,肉棍子,肉棍,肉缝,肉洞,肉壁,肉棒,日他娘,日你娘,日你妈,日你妈,日你,日本鬼子,"+
                "日本RING,日X妈,日GM,日Gm,日gM,日gm,人体炸弹,人民银行,人民日报,人民广场,人民大会堂,人民,人弹,人代会,人大代表,人大,瘸腿帮,全国人大,去死,去你妈的,情色,青天白日,亲民党,窃听器材,窃听器,切七,侨办,"+
                "乔石,抢劫,强硬发言,强效失意药,强卫,强奸犯,强奸,枪支弹药,枪决现场,枪决女犯,钱其琛,气象局,普京,仆街,破鞋,破坏,苹果日报,嫖客,屁眼,皮条,彭真,喷你,拍肩神药,虐待,农业部,牛比,牛比,牛逼,牛逼,牛B,鸟你,"+
                "鸟GM,鸟Gm,鸟gM,鸟gm,你爷爷的,你娘,你妈的,你妈逼,你妈,你妈,你姥姥的,你姥,你老味,你老母,你二大爷,你大爷,你爸,伱妈,嫩B,嫩b,南蛮子,南蛮子,南联盟,妳娘的,妳马的,妳妈的,妳老母的,奶子,穆斯林,穆罕默德,"+
                "莫索里尼,摩门教,明慧网,民政部,民运,民进党,民航局,密宗,密洞,迷药,迷歼药,迷奸药,迷魂药,蒙古独立,蒙古达子,蒙独,蒙尘药,美利坚,美国之音,美国佬,美国,梅花网,毛主席,毛贼东,毛泽东,毛泽东,毛一鲜,毛厕洞,"+
                "毛XX,卖淫,卖软件,卖卡,卖号,卖号,卖号,卖国求荣,卖国,卖党求荣,卖财富,卖比,卖逼,卖QQ,卖ID,卖B,卖.国,麦角酸,买卖枪支,买财富,吗啡片,吗啡碱,吗啡,吗的,马英九,马卖马屁,马克思,麻醉乙醚,麻醉药,麻醉枪,"+
                "麻醉钢枪,妈祖,妈批,妈卖妈屁,妈的,妈的,妈比,妈逼,妈逼,妈B,骡干,罗干,罗　干,轮奸,轮功,卵,旅游局,吕秀莲,龙新民,龙虎,龙 虎 门,六四真相,六四事件,六-四,六四,六合彩,六?四,六。四,六.四,流氓,刘云山,"+
                "刘少奇,刘淇,刘军,刘　淇,领取,林业局,林彪,列宁,两腿之间,粮食局,联易互动,联易,联合国大会,联合国,联大,连战,李先念,李铁映,李山,李瑞环,李鹏*,李鹏,李岚清,李洪志,李宏志,李宏旨,李红志,李弘旨,李登辉,"+
                "李长春,礼品,黎阳评,老母,老毛子,老逼,劳动保障部,劳+教+所,烂游戏,烂货,烂屌,烂比,烂逼,烂屄,烂B,懒教,拉姆斯菲尔德,拉登,垃圾游戏,狂操你全家,狂操,寇晓伟,口交,口交,恐怖主义,恐怖份子,客户服务人员,"+
                "客服,克林顿,可卡因,可卡叶,可待因,靠腰,靠你妈,靠,尻,抗日,看棋软件,看棋器,看牌软件,看牌器,军委,军事委员会,军妓,军国主义,军长发威,鸠屎,鸠,纠察员,静坐,靖国神社,敬国神社,警匪一家,精子,精液,"+
                "经社理事会,经济社会理事会,禁书,金正日,金日成,届中央政治局委员,她妈的,她妈,街头对抗,教育部,叫小姐,叫鸡,叫床,姣西,交通部,酱猪媳,蒋中正,蒋经国,蒋介石,疆独,僵贼民,江主席,江猪媳,江猪,江折民,"+
                "江贼民,江泽民,江泽民,江泽民,江择民,江戏子,江青,江核心,江独裁,江八点,江八,江Core,贱人,贱货,贱逼,贱,建设部,检察院,监听王,监管局,监察部,奸淫,奸你,奸夫淫妇,奸,贾庆林,佳静安定片,妓院,妓女,妓女,"+
                "妓,计生委,计牌软件,几届中央政治局委员,激情小电影,激情电影,基督教,基督,基地组织,鸡奸,鸡鸡,鸡掰,鸡芭,鸡叭,鸡巴,鸡巴,鸡巴,鸡八,鸡,机巴,机八,火棒,混沌诀,混沌,混 沌决,昏药,回族人吃猪肉,回民暴动,"+
                "回良玉,回教,回回,黄色小电影,黄色电影,黄色,黄菊,黄　菊,换妻,环保总局,欢城互动,欢城,华建敏,华国锋,花柳,虎门,胡主席,胡耀邦,胡乔木,胡锦淘,胡锦涛,胡锦涛,胡锦涛,胡紧套,胡紧掏,胡紧涛,胡XX,后庭,洪志,"+
                "洪兴,红卫兵,黑手党,黑手党,黑手党,黑社会,贺龙,贺国强,何候华,海洋局,海洛因,海关总署,哈批,国资委,国研室,国务院,国土资源部,国民党万岁,国民党,国家主要部委,国家主席,国家民委,国际法院,国管局,"+
                "国防科工委,国防部,国安局,郭伯雄,滚,鬼村,龟头,龟孙子,龟公,龟儿子,广电局,光明日报,管理员,管理员,管理人员,官商勾结,官逼民反,观世音,古方迷香,狗养,狗屎,狗日的,狗日,狗日,狗屁,狗娘,狗卵,狗操,狗b,"+
                "共青团员,共狗,共匪,共产主义,共产党,共产党,共产党,公安局,公安部,公安,弓虽女干,工作人员,工商局,工力,膏药旗,睾丸,睾,高校骚乱,高校群体事件,高校暴乱,高丽棒子,高俊,港澳办,肛门,肛交,肛,干死你,干七八,"+
                "干你娘,干你妈逼,干你妈b,干你妈,干你,干妳娘,干妳妈,干妳老母,干妳,干拎娘,干GM,干Gm,干gM,干gm,傅作义,傅鹏,阝月,斧头镰刀,佛祖,佛展千手法,佛教,分裂祖国,反政府,反日,反恐委员会,反华,反共,反革命,"+
                "反封锁技术,反动,法制办,法西斯,法轮功,法轮功,法轮大法,法轮大法,法轮,法仑,法愣,法功,法*轮*功,法(轮)功,发正念,发展研究中心,发骚,发论功,发论公,发论,发轮,发伦功,发伦,发抡功,发抡,发奖使者,发改委,"+
                "二乙基酰胺,二逼,二屄,二B,恩格斯,恶搞晚会,多维周刊,多维新闻,多维网,多维社,对日强硬,短信群发器,独立台湾会,独立,懂文华,董文华,董贱华,董建华,东亚病夫,东突组织,东突暴动和独立,东突,东条英机,东升,"+
                "东北独立,丁子霖,丁关根,调理劳务系,钓鱼台,屌西,屌七,屌妳,屌毛,屌鸠,屌7,屌,叼你妈,叼你,电监会,帝国主义,帝国主义,弟大物勃,地震局,邓小平,道教,盗窃犯,盗窃犯,档案局,荡妇,党主席,戴维教,戴维教,戴晶,"+
                "戴红,戴海静,代表大会,呆卵,大血比,大血B,大学骚乱,大师,大麻油,大麻树脂,大麻,大纪元,大会堂,大花B,大法弟子,大法,大东亚共荣,大波波,大便,大逼,大B,大*FA弟*子,打炮,达赖喇嘛,达赖,催情药,粗制吗啡,戳你,"+
                "蠢猪,春药,吹箫,吹喇叭,出售账号,出售手枪,出售神符,出售枪支,出售假币,出售此号,臭化西,抽你丫的,抽插,赤匪,迟浩田,吃屎,吃大便,成人片,成人电影,陈至立,陈毅,陈晓宁,陈希同,陈水扁,陈良宇,陈功,车仑,车臣,"+
                "朝鲜,产权局,插深些,插你妈,插你,插妳,插GM,插Gm,插gM,插gm,测绘局,肏,草拟妈,草你妈,草你妈,草妈,草的你妈,曹刚川,操他,操你妈屄,操你妈,操你妈,操你八辈祖宗,操你,操蛋,操比,操逼,操XX,操GM,操Gm,操gM,"+
                "操gm,操,藏独,藏独,藏独,藏独,参事室,财政部,布什,布什,布雷尔,布莱尔,不玩了,薄一波,博讯,波霸,冰毒,宾周,婊子,婊子,婊,比毛,逼样,逼你老母,逼毛,屄毛,屄,笨逼,笨屄,苯比,本?拉登,本?拉登,贝肉,北京之春,"+
                "暴徒,暴乱,暴动,鲍岳桥,鸨,保密局,保监会,保钓,包皮,办理证件,办理文凭,八仙,八九风波,八九,八 仙,八 仙,澳洲光明网,安全局,安南,zhongguohun,zhengwunet,zhengqing,zhengjian,yuanmingxinsheng,xinguangming,"+
                "WG,wg,WG,Wg,wG,wg,urTNND,tnnd,TMD,TMD,tmd,taobao,T.M.D,SUCK,suck,Suck,soundofhope,snatch,SM,shyt,SHIT,shit,shengda,sh!t,sf,sex,sega,secretchina,screw,SB,sb,rivals,ri,renminbao,PUSSY,pussy,piss,"+
                "phuc,penis,peacehall,orgasmus,on9,ON9,NPC,NND,nnd,NMD,minhui,mingpaonews,K粉,kao,JB,jb,JB,jb,j8,h站,Gm,gM,gm,GM,globalrescue,gc365,gamemaster,GAMEMASTER,gameMASTER,GAMEmaster,GameMaster,"+
                "GAMEMASTER,GameMaste,fvc,fv(,fuk,FUCKYOU,fuckyou,fuck,Fuck,fuck,FUCK,fuc,fu(,fosaon,fofg,flg,FLG,fgmtv,fawanghuihui,falun,F.L.G,epochtime,dick,Dick,DICK,damn,damm,dajiyuan,cunt,chinesenewsweek,"+
                "chengmingmag,cdjp,cctv,CCTV,cao,cao,butthole,butthead,bt,boxun,bjzc,bitch,Bitch,bignews,beijingspring,bbscity,bastard,asshole,刘少奇,彭德怀,刘伯承,聂荣臻,徐向前,罗荣桓,叶剑英,李大钊,陈独秀,孙文,"+
                "美国之音,密宗,民国,藏独,高丽棒子,蒙古鞑子,鞑子,茎,戆比,韩忠信,温宗仁,李有慰,马志鹏,戆卵,何光,文学城,李玉赋,马子龙,高潮,何勇,闻世震,李源潮,卖淫,高俊良,贺邦靖,我就日,李运之,瞒报,高祀仁,贺国强,我日,"+
                "李,兆焯,高中兴,黑龙会,我太阳你,李肇星,毛主席,乌云其木格,刘淇,蒙进喜,葛振峰,洪虎,吴爱英,刘石泉,孟建柱,弓虽女干,胡彪,吴邦国,刘书田,孟学农,胡家燕,吴定富,刘锡荣,公投,胡锦涛,吴官正,刘晓江,民运,共产党,"+
                "胡瘟,吴广才,淫,闵维方,共产党,胡永柱,吴基传,尹凤岐,牟新生,共党,胡主席,吴启迪,隐瞒疫情,奶,共匪,华建敏,吴铨叙,由喜贵,南振中,狗娘,吴双战,俞正声,倪益瑾,狗屁,吴新雄,虞云耀,你她妈,狗日的,黄丹华,吴仪,"+
                "你她吗,管国忠,黄华华,吴玉良,你妈,黄洁夫,吴玉谦,你妈的,黄菊,吴毓萍,你他吗,郭伯雄,黄丽满,武汉女大学生,刘志军,你它吗,郭东坡,黄晴宜,希特勒,六四,娘,郭庚茂,黄淑和,奚国华,龙新民,嬲,郭金龙,黄树贤,息中朝,"+
                "楼继伟,聂成根,郭声琨,刘冬冬,卢展工,聂卫国,郭树清,刘丰富,习近平,陆浩,聂振邦,韩长赋,刘峰岩,马晓天,钮茂生,韩正,夏赞忠,夏宝龙,马右加文,欧广源,刘华秋,现鼠疫,小平,马之庚,欧泽高,刘积斌,向巴平措,"+
                "小平邪恶的迫害,小鸡鸡,潘云鹤,刘家义,项怀诚,小泉纯一郎,俞正声,逄先知,刘江,杨正午,杨永茂,虞云耀,李至伦,刘延东,摇头丸,杨元元,杨永茂,李志坚,刘永治,王胜俊,杨元元,栗战书,刘玉浦,叶小文,王寿亭,杨正午,"+
                "梁保华,刘粤军,疫情,王曙光,梁光烈,刘云耕,阴,王太华,王侠,刘云山,殷一璀,王同琢,叶小文,王显政,刘泽民,淫,王唯众,王旭东,刘振华,尹凤岐,王忠禹,阴,王云坤,刘镇武,隐瞒疫情,王众孚,殷一璀,王云龙,刘志峰,"+
                "由喜贵,王兆国,常万全,梁绮萍,王振川,常委,廖晖,王正福,常小兵,廖锡龙,陈冀平,王正伟,车仑女干,列确,韦建桦,陈建国,王志刚,陈邦柱,林明月,猥琐,陈奎元,刘德旺,陈炳德,林树森,猥亵,陈良宇,王明方,陈传阔,"+
                "林文肯,陈培忠,王明权,阳安江,陈福今,林左鸣,陈绍基,王岐山,杨传堂,北京流行鼠疫,领奖,陈水扁,王谦,杨德清,贝戈戈,令计划,陈希,王三运,杨多良,本拉登,阿不来提?阿不都热西提,陈希明,单霁翔,艾斯海提?克里木拜,"+
                "陈训秋,邓昌友,婊子,安立敏,储波,陈元,邓朴方,博讯,巴特尔,戳B,陈云林,邓小平,薄熙来,戳比,陈章立,帝国,布穷,崔会烈,陈至立,叼,蔡长松,白春礼,大东亚,诚聘,屌,操,白恩培,大法,迟浩田,吊,曹伯纯,白景富,"+
                "大法弟子,迟万春,调试,曹刚川,白克明,大纪元,出卖,爹,曹洪兴,白立忱,大世纪,出售,丁一平,曹建明,白玛,大统,法＊轮,东条英机,曹康泰,白志健,大爷,法*轮*功,东突厥,草,冯健身,大一统,法＊轮功,东亚病夫,"+
                "冯永生,代练,法＋轮＋功,董雷,柴松岳,服务,代炼,法?轮?功,董万才,樊守志,符桂花,带练,法X功,董宜胜,范长龙,符廷贵,带炼,法轮,独裁,范新德,傅克诚,戴秉国,法轮大法,独立,非典,傅志寰,戴相龙,法轮功,杜德印,"+
                "疯狗,干以胜,贱种,法论,杜青林,监察,戆B,江泽民,法论大法,杜世成,监督,黄献中,江主席,法论功,杜学芳,监管,黄兴国,姜大明,杜宇新,黄选平,姜福堂,老表,多吉才让,黄瑶,李传卿,老江,多维,秦光荣,黄远志,李春城,"+
                "雷鸣球,扼杀权利,秦绍德,黄镇东,李德洙,李安东,请愿,黄智权,李登辉,李长春,邱学强,回良玉,李东生,李长江,发送员,邱衍汉,鸡巴,李栋恒,李长印,法＊＊轮,全家,鸡吧,李贵鲜,李成玉,法**轮**功,全哲洙,鸡奸,"+
                "李宏志,李崇禧,法＊＊轮功,确认密码,吉炳轩,李洪志,日,温家宝,热地,妓,李鸿忠,日B,温熙森,妓女,李纪恒,日比,王刚,仁青加,季允石,李继耐,日你,日你妈,任泽民,贾春旺,李继松,杨永良,王鸿举,路甬祥,贾庆林,"+
                "李建国,乳,王沪宁,吕福源,贾文先,李金华,卫留成,王华元,吕秀莲,贾治邦,魏家福,王家瑞,王洛林,吕祖善,价格绝对优惠,魏建国,王建民,王梦奎,卵子,孙忠同,中华民国,魏礼群,张毅,罗保铭,他妈,中华人民共和国,"+
                "石云生,张玉台,罗干,台独,中央政治局,石宗源,张钰钟,罗清泉,台湾独立,周恩来,史莲喜,张云川,罗世谦,太子党,周强,舒晓琴,张中伟,罗正富,太子党替罪羊,周生贤, 鼠疫,张左己,妈的,唐家璇,周声涛,谁出卖了中国,"+
                "赵春兰,妈妈,唐天标,周同战,司马义?艾买提,赵洪祝,麻痹,陶方桂,周小川,司马义?铁力瓦尔地,赵可铭,麻屁,陶建幸,周永康,私服,赵乐际,马富才,滕久明,周遇奇,宋爱荣,赵荣,马凯,滕文生,周占顺,宋德福,赵紫阳,"+
                "马启智,冤假错案,朱成友,宋法棠,郑坤生,马铁山,圆满,朱德,宋照肃,郑立中,曾培炎,袁纯清,朱发忠,宋祖英,郑斯林,曾庆红,袁守芳,朱启,苏荣,郑万通,翟虎渠,袁伟民,朱容基,苏树林,郑筱萸,翟小衡,岳福洪,朱熔基,"+
                "苏新添,政治斗争,张宝顺,岳喜翠,朱镕基,隋明太,政治局,张春贤,岳宣义,朱维群,孙宝树,支那,张德江,杂碎,朱文泉,孙春兰,支那人,张德邻,杂种,朱之鑫,孙淦,支树平,张定发,再现良知,朱祖良,孙家正,中共,"+
                "最便宜的空间,自焚,竺延风,孙淑义,孙志强,做爱,走向共和,祝春林,孙文盛,装备发放员,祖宗,祝光耀,孙英,孙载夫,裴怀亮,李清林,锦涛,沈跃跃,乔清晨,彭小枫,李荣融,靖志远,十八代,小样,彭祖意,李盛霖,"+
                "看中国报道,十六大,肖扬,屁,李铁林,康日新,石大华,邪恶的迫害,嫖娼,替罪羊,尻,石广生,谢企华,蒲海清,王建宙,靠,石秀诗,谢旭人,七三一,王金山,乔宗淮,石玉珍,谢作炎,钱国梁,王景川,秦大河,刘玠,新疆独立,"+
                "钱其琛,王君,李金明,刘京,信仰危机,钱树根,王乐泉,李景田,刘立清,邢元敏,钱运录,王莉莉,李克,刘明康,性爱,强暴,尚福林,李克强,刘鹏,性交,强奸,佘靖,李岚清,刘奇葆,熊光楷,强力推出JSP空间,沈滨义,李鹏,李铁映,"+
                "徐才厚,强卫,沈德咏,李乾元,李文华,徐承栋,乔传秀,沈淑济,薛延忠,李雪莹,徐冠华,徐匡迪,中关村大厦,穴,李毅中,徐光春,徐荣凯,中国政府信仰危机,学&*员#@,中共中央,徐敬业,徐守盛,许志功,阎海旺,许其亮,宣扬,"+
                "徐有芳,宣传,徐志坚,许永跃,薛利,杨光洪,张恩照,张平,焦焕成,张文岳,杨怀庆,张凤楼,张庆黎,叫床,张孝忠,杨洁篪,张福森,张庆伟,解厚铨,张行湘,杨晶,张高丽,张瑞敏,解振华,张轩,杨利民,张华祝,张树田,金道铭,"+
                "张学忠,姜建清,张惠新,张维庆,金人庆,姜异康,张俊九,张文康,金银焕,蒋文兰,疆独,张黎,张文台,张立昌,三级片,田成平,散襄军,田聪明,骚,田凤山,天安门事件,沙比,田淑兰,汪啸风,你它妈,三个代表,傻B,铁凝,汪恕诚,"+
                "汪洋,宋秀岩,傻逼,突厥,赵启正,王八,煞笔,傻比,推荐主机,王德顺,王晨,上访,傻鄙,外挂,王成铭,上海瘪三,汪光焘,万学远,操行,你丫,日日日,色情,情色,嫖娼,卖淫,淫秽,援交,援助交际,网爱,你妈,你娘,他妈,她妈,"+
                "他娘,她娘,妈的,奶娘,犬神,太神,你全家,我日,我操,我奸,日你,干你,操你,射你,强奸,奸你,插你,戳你,婊子,妓,傻B,傻比,傻逼,臭傻,骚逼,骚B,妈B,妈逼,逼样,妈比,骚货,祖宗,狗日,屁股,屁眼,鸡巴,鸡8,鸡奸,阴茎,"+
                "阴毛,阴唇,阳具,性交,交配,淫荡,淫水,贱货,卖B,卖比,浪叫,奶子,乳头,姘头,TMD,J8,妈,性,屄,肏,奸,屌,干,贱,烂,仆,仆街,白痴,老二,笨蛋,蠢猪,苯比,射精,爹娘,鸡巴,王八蛋,王八,他爹,他祖宗,你是鸡,你是鸭,"+
                "叼你,叼你妈,靠你妈,奶奶,奶妈,吹牛逼,生春袋,尻,多维,狗卵,烂货,烂逼,阴道,吃屎,阳萎,妓院,骚,奸,扒光,干你妈,老味臭化西,淫,做爱,外阴,妈妈的,我靠,fuck,bitch,他妈的,性爱,falundafa,逼,snk.ni8.net,"+
                "操你妈,三级片,nnd,干你娘,做爱,性交,阴道,乳房,cao,操,靠,鸡吧,鸡巴,鸡八,吃屎,外挂,YOUXIKA,他奶奶,傻b,傻B,13点,骚货,狗娘养的,日你妈,精神病,大血比,龟儿子,龟孙子,贱货,淫货,傻吊,性交,做爱,阴茎,婊,"+
                "TMD,tmd,DAMN,damn,明慧,Bastard,STUPID,Stupid,SUCKER,sucker,去死,毛贼,杂种,贱种,贱逼,煞笔,狗操,狗养,下三烂,下贱,口肯,你妈逼,他奶奶的,他奶娘的,他马的,他妈ㄉ王八蛋,白烂,她奶奶的,她马的,她妈的,"+
                "老母,老味,你他马的,你他妈的,你它马的,你它妈的,你她马的,你娘卡好,你娘咧,你马的,你妈的,妳她妈的,妳老母的,逼你老母,调理劳务系,臭化西,挨球,我日你,妳娘,妳妈,妳娘的,妳马的,妳妈的,狗屁,狗娘养的,"+
                "屎忽鬼,柒西,柒头,神经病,肥西,能样,臭化,臭西,臭街,性奴,(神),<神>,屄,肏,姣西,奸,强奸你,淫,淫西,淫妇,笨七,笨柒,几八,几巴,几叭,几芭,插死你,塞你公,塞你母,塞你老母,塞你老师,塞你爸,塞你娘,妈的,妈的B,"+
                "妈个B,妈B,干x娘,干七八,干死GM,干死客服,干死CS,干死你,干干干,干你老母,干你良,干你妈,干妳老母,干妳娘,干妳马,干妳妈,干您娘,干机掰,干您娘,你妈了妹,生孩子没屁眼,垃圾,逼毛,贱B,贱人,靠北,靠母,靠爸,"+
                "靠背,靠腰,七头,七碌,二百五,驶你公,驶你母,驶你老母,驶你老师,驶你爸,驶你娘,操78,操你全家,操你老母,操你老妈,操你娘,操你祖宗,操你妈,操你娘,操妳,操妳全家,操妳娘,操妳祖宗,操妳妈,操妳娘,操机掰,机八,"+
                "机巴,机机歪歪,懆您妈,懆您娘,ㄙㄞ你老母,ㄙㄞ你娘,ㄙㄞ你爸,ㄙㄞ你母,ㄙㄞ你公,ㄙㄞ你老师,懒叫,懒教,操你祖宗,操妳祖宗,干七八,妳娘的,靠腰,操妳,操你,妳老母的,阴茎,鸡掰,赛你老母,赛妳阿母,婊子养的,"+
                "插你妈,鸡八,鸡巴,鸡叭,鸡芭,呆卵,傻卵,懒8,懒八,懒叫,懒教,赣您娘,灨你娘,gan,他ㄇㄉ,他ㄇ的,死GM,干妳娘,干拎娘,你妈的,你马的,你妈的,妳妈的,妳马的,妳马的,他马的,她马的,她妈的,瓜娃子,草拟妈,操妳娘,"+
                "操你娘,操你娘,操妳娘,操妳妈,操你妈,干你妈,干妳妈,卖逼,ㄐ掰,ㄐ巴,ㄐ八,机巴,鸡巴,鸡八,机八,鸡叭,鸡芭,奸淫,干你老母,干妳老母,操你老妈,操你老母,塞你老母,传染性病,塞你娘,塞你爸,塞你母,塞你公,塞你老师,"+
                "驶你老母,驶你娘,驶你爸,驶你母,驶你公,驶你老师,ㄙㄞ你老母,ㄙㄞ你娘,ㄙㄞ你爸,ㄙㄞ你母,ㄙㄞ你公,ㄙㄞ你老师,懒叫,懒教,性欲,操你祖宗,操妳祖宗,干七八,喵的,包皮,柯赐海,猪头,连战,李登辉,宋楚瑜,阿扁,"+
                "陈水扁,陈随便,身寸,米青,口合,口圭,豖者,豆页,木奉,口交,胡锦涛,邓小平,毛泽东,江泽民,李洪志,法轮功,法轮大法,法轮,日你妈,操你妈,草你妈,日你娘,操你娘,草你娘,干你妈,你老母,你老味,妖你,共产党,胡锦涛,"+
                "江泽民,温家宝,毛泽东,周恩来,李洪志,法轮功,三去车仑工力,小日本,他爸爸,你大爷,我操,我草,我日,我干,鸡巴,傻比,傻逼,傻B,二逼,二B,Q币,打炮,打飞机,打手枪,淫乱,淫荡,颜射,口交,肛交,乳交,江择民,性交,群交,"+
                "射屏,潮吹,自慰,手淫,后庭,鸡奸,强奸,诱奸,轮奸,迷奸,群P,激情,少妇,熟女,人妻,阴茎,阴道,阴蒂,阴毛,阴户,陷家,渣波波,射精,遗精,激情视频,裸聊,阉狗,鸡歪,痴鸠,痴捻,死全家,全家死光光,狗娘养的,嫩B,嫩b,暴乱,"+
                "睾丸,调理劳务挨球,猪倌,朱镕基,胡锦涛,温家宝,吴邦国,李岚清,荣毅仁,罗干,贾庆林,黄菊,吴官正,李长春,贺国强,毛主席,周总理,钱其琛,朱熔基,朱德,国家主席,国家总理,国务院,中南海,共产党,国民党,政治局,主席,"+
                "总理,人大代表,人大代表大会,孙中山,蒋介石,金正日,本拉登,外挂,作弊,回族,回民,曾庆红,王刚,吴仪,万里,田纪云,乔石,李鹏,李铁映,李瑞环,赵紫阳,胡耀邦,薄一波,胡乔木,李岚清,陈希同,尉健行,王震,李先念,林彪,"+
                "陈毅,贺龙,傅作义,陈水扁,吕秀莲,李登辉,布什,布希,拉姆斯菲尔德,克林顿,小泉纯一郎,普京,布雷尔,布莱尔,戴维教,大衛教,希拉克,金日成,金正日,萨达姆,阿拉法特,穆斯林,回回,基督,耶苏,真理教,伊斯兰,阿拉,"+
                "高丽棒子,蒙古达子,鲜族,南蛮子,本?拉登,拉登,希特勒,东条英机,天皇,法西斯,帝国主义,社会主义,共产主义,东亚病夫,日本鬼子,小日本,膏药旗,美国佬,老毛子,黑手党,亲民党,圣战,达赖,中南海,中共中央,中国共产党,"+
                "中央电视台,新闻出版总署,中宣部,届中央政治局委员,东突,东突独立,新疆独立,西藏独立,杀手,杀人犯,强奸犯,盗窃犯,东突暴动,紮卡维是英雄,扎卡维是英雄,阿扁万岁,回族人吃猪肉,瘸腿帮,阿扁,人民大会堂,政协,警察,"+
                "民进党,中共,全国人大,天神,大神,中华人民共和国,中华民国,李洪志,法轮,海边的卡夫卡,秋天的童话,新义安,洪兴,东升,黑社会,共匪,台独,台湾国,台湾共和国,台湾党,台湾帝国,台湾民国,台湾共产党,天安门,自焚,大法,"+
                "FLG,八九,六四,切七,民运,真善忍,动乱,梅花网,台湾民国,台湾独立,台湾党,宾周,纠察员,巡查员,GameMaster,GY,Gy,on9,ON9,外挂,值勤账号,家产,家铲,特别公告,账号,札卡维,扎卡维,3P,sb,SB,QB,gcd,Fuck,FUCK,"+
                "Fuckyou,shit,cao,caonima,ri,rinima,kao,sex,porn,diu,DIU,7.31,run,breast,bubby,ryl,BT,℃,SARS,prick,cao,SB,TMD,chairman,serve,udder,cock,service,unionnet,#NAME?,services,vagina,#@江%$泽&*民#@,"+
                "serving,conservator,#NAME?,servings,controller,$#fa%$lun*&gong$#,sex,cunt,$#fa%$lun*&gong$#学员,SF,f_l_g,$#Zhuan$%Fa&*Lun$#》,SHIT,fa_lun_gong,$#修&*炼%$,juyou,falun,%$da&*fa#@,KJ,falundafa,"+
                "%$罗%$干&*,K药,FLG,16大,mamma,fuck,∞,manage,fucker,admin,MD,gamemaster,administer,membrum,QJ,gamemasters,ministry,ri,GM,ML,SJ,nake,sm,http,NND,supervise,id,NNGX,test,penis,NTT,testing,phallus,"+
                "NTT公司,password,sex,shit,F_U_C_K,F U C K,f_u_c_k,admin,bitch,gamemaster,ｓｅｘ,ｓｈｉｔ,ｆｕｃｋ,ｂｉｔｃｈ,ａｄｍｉｎ,ｍａｓｔｅｒ,ｇａｍｅｍａｓｔｅｒ,ＧａｍｅＭａｓｔｅｒ,ＧＡＭＥＭＡＳＴＥＲ,"+
                " gm,GM,GAME_,Ｇｍ,刘少奇,彭德怀,刘伯承,聂荣臻,徐向前,罗荣恒,李大钊,叶剑英,陈独秀,孙中山,孙文,美国之音,密宗,民国,藏独,高丽棒子,蒙古鞑子,叭";
            #endregion 关键字

            string[] strValiads = strValiad.Split(',');
            foreach (string strV in strValiads)
            {
                if (strIn == strV)
                {
                    blReturn = true;
                    break;
                }                
            }
            return blReturn;
        }
        #endregion

        #region GetValidWords 将一个字符串中的被屏蔽字替换为**
        /// <summary>
        /// 方法：  GetValidWords
        /// 功能：  将一个字符串中的被屏蔽字替换为**
        /// 作者：  孔翔天
        /// 修改：  
        /// 时间：  2007-1-22 16:12 
        /// </summary>
        /// <param name="strIn">要替换的字符串</param>
        /// <param name="sdr">被屏蔽字的行信息</param>
        /// <returns>替换后的字符串</returns>
        public static string GetValidWords(string strIn,DataRow dr)
        {
            string strInvalidWords = dr["ProhibitWord"].ToString().Trim();
            
            Cuter cuter = new Cuter(strInvalidWords);
            for (int i = 0; i < cuter.GetSize(); i++)
            {
                strIn = strIn.Replace(cuter.GetCuter(i), "**");
            }
            return strIn;
        }
        #endregion

        #region GetIPByDomain 通过域名得到该域名的IP地址
        /// <summary>
        /// 方法：  GetIPByDomain
        /// 功能：  通过域名得到该域名的IP地址
        /// 作者：  齐玮
        /// 修改：  
        /// 时间：  2007-2-8 9:20
        /// </summary>
        /// <param name="strDomain">域名</param>
        /// <returns>得到IP地址</returns>
        public static string GetIPByDomain(string strDomain)
        {
            return Dns.GetHostEntry(strDomain).AddressList[0].ToString();
        }
        #endregion

        #region GetHttpString 从目标URL得到一个返回的字符串
        /// <summary>
        /// 方法：  GetHttpString
        /// 功能：  从目标URL得到一个返回的字符串
        /// 作者：  齐玮
        /// 修改：  
        /// 时间：  2007-2-1 13:58 
        /// </summary>
        /// <param name="strRequestURL">目标URL</param>
        /// <returns>从目标URL得到的字符串</returns>
        public static string GetHttpString(string strRequestURL)
        {
            HttpWebRequest httpWebRequest = null;	    // Http请求
            HttpWebResponse httpWebResponse = null;	    // Http响应
            Stream stream = null;						// 提供字节序列
            Encoding encode = null;					    // 语言的编码设置
            StreamReader readerStream = null;			// 读取响应的网络流
            Char[] read = null;							// 定义的Char数组
            int count = 0;								// 循环变量
            String strReturn = null;					// 接收到的字符串
            string sHttpWebRequestUrl = null;			// 请求的url

            sHttpWebRequestUrl = strRequestURL;
            // 请求URI
            httpWebRequest = (HttpWebRequest)WebRequest.Create(sHttpWebRequestUrl);
            // 返回响应的资源数据
            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            // 获取响应的网络流
            stream = httpWebResponse.GetResponseStream();
            // 编码方式
            encode = System.Text.Encoding.GetEncoding("GB2312");
            // 从响应流中获取字节序列
            readerStream = new StreamReader(stream, encode);
            // 读取256个字符存入buffer
            read = new Char[256];
            count = readerStream.Read(read, 0, 256);
            //
            while (count > 0)
            {
                strReturn = new String(read, 0, count);

                count = readerStream.Read(read, 0, 256);
            }

            httpWebResponse.Close();
            readerStream.Close();

            Cuter cuter = new Cuter(strReturn, ",");

            return cuter.GetCuter(0);
        }
        #endregion

        #region IsValidSign JNet的MD5是否匹配
        public static bool IsValidSign(string strCode, string strSign, string sKey)
        {
            strCode = strCode + sKey;
            if (System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strCode, "md5").ToLower() == strSign)
                return true;
            else
                return false;
        }
        #endregion

        #region GetShortString 截取前X个字符
        /// <summary>
        /// 截取前X个字符
        /// </summary>
        /// <param name="strIn">要截取的字符串</param>
        /// <param name="intLength">截取的长度，全角字符算两个</param>
        /// <returns>截取后的字符串</returns>
        public static string GetShortString(string strIn, int intLength)
        {
            string strItem = strIn;
            int intIdx = 0;
            int i = 0;
            bool blnLong = false;
            for (i = 0; i < strItem.Length; i++)
            {
                if (intIdx > intLength)
                {
                    blnLong = true;
                    break;
                }
                if (((int)strItem[i]) > 128) intIdx = intIdx + 2;
                else intIdx++;
            }
            try
            {
                strItem = strItem.Substring(0, i);
                if (blnLong) strItem += "";
            }
            catch
            {
                strItem = strIn;
            }
            return strItem;
        }
        #endregion

        #region IsVaildLength 判断字符串的长度是否在范围内
        /// <summary>
        /// 方法：  IsVaildLength
        /// 功能：  判断字符串的长度是否在范围内
        /// 作者：  WZY
        /// 修改：  
        /// 时间：  2007-2-25 13:58  
        /// </summary>
        /// <param name="strIn"></param>
        /// <param name="intMin"></param>
        /// <param name="intMax"></param>
        /// <returns>返回字符串中的字符个数，汉字算一个</returns>
        public static bool IsVaildLength(string strIn, int intMin, int intMax)
        { 
            string re=@"^\S{"+intMin.ToString()+","+intMax.ToString()+"}$";
            return (bool)Regex.IsMatch(strIn,re);
        }
        #endregion

        #region GetXMLTrueBody 将一个字符串转换成为适合XML存储的字符
        /// <summary>
        /// 方法：  GetXMLTrueBody
        /// 功能：  将一个字符串转换成为适合XML存储的字符
        /// 作者：  齐玮
        /// 修改：  
        /// 时间：  2007-2-25 13:58  
        /// </summary>
        /// <param name="strIn">输入的字符串</param>
        /// <returns>适合XML存储的字符串</returns>
        public static string GetXMLTrueBody(string strIn)
        {
            return strIn.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;").Replace("'", "&apos;").Replace("\"", "&quot;");
        }
        #endregion

        #region GetServerName 得到服务器名字
        /// <summary>
        /// 方法：  GetServerName
        /// 功能：  得到服务器名字
        /// 作者：  KXT
        /// 修改：  
        /// 时间：  2007-3-2 16:14   
        /// </summary>
        /// <param name="intServerCategory">服务器编号</param>
        /// <returns>服务器中文名</returns>
        public static string GetAdminServerName(int intServerCategory)
        {
            string strServerName;

            switch (intServerCategory)
            { 
                case 0:
                    strServerName = "主站管理";
                    break;
                case 1:
                    strServerName = "北一管理";
                    break;
                case 2:
                    strServerName = "南一管理";
                    break;
                case 3:
                    strServerName = "南二管理";
                    break;
                case 4:
                    strServerName = "精学社管理";
                    break;
                case 5:
                    strServerName = "新游戏管理";
                    break;
                default:
                    strServerName = "超出……";
                    break;
            }
            return strServerName;
        }
        #endregion

        #region IsValidWord 是否有非法字符
        /// <summary>
        /// 方法：  IsValidWord
        /// 功能：  检测是否含有非法字符，并且检测是否包含BadWord
        /// 作者：  QiWei
        /// 修改：  
        /// 时间：  2007-8-15 16:14   
        /// </summary>
        /// <param name="strIn">被检测字符串</param>
        /// <returns>是否有非法字符</returns>
        public static bool IsValidWord(string strIn)
        {
            if (IsSafeWord(strIn))
                return !HasInvalidWord(strIn);
            else
                return false;
        }

        /// <summary>
        /// 检测是否包含有非法字符，恶意用户将利用非法字符进行注入
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsSafeWord(string strIn)
        {
            strIn = strIn.ToLower();
            if (strIn.IndexOf(",") != -1 || strIn.IndexOf("\"") != -1 ||  strIn.IndexOf("'") != -1 || strIn.IndexOf("\\") != -1
               || strIn.IndexOf("|") != -1 || strIn.IndexOf(";") != -1 || strIn.IndexOf("#") != -1
               || strIn.IndexOf("&") != -1)
            {
                return false;
            }
            else
            {
                if (strIn.IndexOf("select ") != -1 ||
                    strIn.IndexOf("insert ") != -1 ||
                    strIn.IndexOf("delete from") != -1 ||
                    strIn.IndexOf("count(") != -1 ||
                    strIn.IndexOf("drop table") != -1 ||
                    strIn.IndexOf("update ") != -1 ||
                    strIn.IndexOf("truncate ") != -1 ||
                    strIn.IndexOf("asc(") != -1 ||
                    strIn.IndexOf("mid(") != -1 ||
                    strIn.IndexOf("char(") != -1 ||
                    strIn.IndexOf("xp_cmdshell") != -1 ||
                    strIn.IndexOf("exec master") != -1 ||
                    strIn.IndexOf("net localgroup administrators") != -1 ||
                    strIn.IndexOf(" and ") != -1 ||
                    strIn.IndexOf("net user") != -1 ||
                    strIn.IndexOf(" or ") != -1)
                    return false;
                else
                    return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsSafeWordPara(string strIn)
        {
            strIn = strIn.ToLower();
            if ( strIn.IndexOf("\"") != -1 || strIn.IndexOf("'") != -1 || strIn.IndexOf("\\") != -1
               || strIn.IndexOf(";") != -1 || strIn.IndexOf("#") != -1)
            {
                return false;
            }
            else
            {
                if (strIn.IndexOf("select ") != -1 ||
                    strIn.IndexOf("insert ") != -1 ||
                    strIn.IndexOf("delete from") != -1 ||
                    strIn.IndexOf("count(") != -1 ||
                    strIn.IndexOf("drop table") != -1 ||
                    strIn.IndexOf("update ") != -1 ||
                    strIn.IndexOf("truncate ") != -1 ||
                    strIn.IndexOf("asc(") != -1 ||
                    strIn.IndexOf("mid(") != -1 ||
                    strIn.IndexOf("char(") != -1 ||
                    strIn.IndexOf("xp_cmdshell") != -1 ||
                    strIn.IndexOf("exec master") != -1 ||
                    strIn.IndexOf("net localgroup administrators") != -1 ||
                    strIn.IndexOf(" and ") != -1 ||
                    strIn.IndexOf("net user") != -1 ||
                    strIn.IndexOf(" or ") != -1)
                    return false;
                else
                    return true;
            }
        }
        #endregion

        #region GetPercent 得到百分比
        /// <summary>
        /// 得到A/B的百分比
        /// </summary>
        /// <param name="intA">被除数</param>
        /// <param name="intB">除数</param>
        /// <param name="intNum">保留位数</param>
        /// <returns>12.33%样式的字符串</returns>
        public static string GetPercent(int intA, int intB, int intNum)
        {
            if (intB == 0)
            {
                return "--";
            }
            else
            {
                float fltResult = (float)intA / intB * 100;
                return fltResult.ToString("F" + intNum) + "%";
            }
        }
        #endregion

        #region IsValidEmail 是否有效的Email地址格式
        /// <summary>
        /// 方法：  IsValidEmail
        /// 功能：  是否有效的Email地址格式
        /// 作者：  KXT
        /// 修改：  
        /// 时间：  2007-3-13 16:14   
        /// </summary>
        /// <param name="strEmail">邮箱地址</param>
        /// <returns></returns>
        public static bool IsValidEmail(string strEmail)
        {
            string re = @"^[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)*@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$";
            return (bool)Regex.IsMatch(strEmail, re);
        }
        #endregion

        #region IsValidLoginLength 判断输入的字符串是否符合注册用户名的标准：仅允许阿拉伯数字、26个英文字符大小写、下划线
        /// <summary>
        /// 方法：  IsValidLoginLength
        /// 功能：  判断输入的字符串是否符合注册用户名的标准：仅允许阿拉伯数字、26个英文字符大小写、下划线。
        /// 作者：  KXT
        /// 修改：  王智勇
        /// 时间：  2007-3-14 15:55
        /// </summary>
        /// <param name="strIn">输入的字符串</param>
        /// <param name="intMin">最小长度</param>
        /// <param name="intMax">最大长度</param>
        /// <returns>符合标准：true；不符合标准：false；</returns>
        public static bool IsValidLoginLength(string strIn, int intMin, int intMax)
        {
            return Regex.IsMatch(strIn, "^[a-zA-Z0-9_]{" + intMin + "," + intMax + "}$");
        }
        #endregion

        #region IsValidName 判断输入可带有全角字符的名称是否合法
        /// <summary>
        /// 判断输入可带有全角字符的名称是否合法
        /// </summary>
        /// <param name="strIn">需要检测的字符串</param>
        /// /// <param name="intMin">最少的字符数（包括）</param>
        /// /// <param name="intMax">最大的字符数（包括）</param>
        /// <returns></returns>
        public static bool IsValidName(string strIn, int intMin, int intMax)
        {

            int intStrLength = GetStrLength(strIn);
            //int intStrLength = strIn.Length;
            if (strIn.IndexOf("<") >= 0 || strIn.IndexOf(">") >= 0 || strIn.IndexOf("!") >= 0 || strIn.IndexOf("~") >= 0 || strIn.IndexOf("#") >= 0 || strIn.IndexOf("$") >= 0 || strIn.IndexOf("%") >= 0 || strIn.IndexOf("^") >= 0 || strIn.IndexOf("&") >= 0
                || strIn.IndexOf("*") >= 0 || strIn.IndexOf("(") >= 0 || strIn.IndexOf(")") >= 0 || strIn.IndexOf("_") >= 0 || strIn.IndexOf("-") >= 0 || strIn.IndexOf("+") >= 0 || strIn.IndexOf("=") >= 0 || strIn.IndexOf("[") >= 0 || strIn.IndexOf("]") >= 0
                || strIn.IndexOf("{") >= 0 || strIn.IndexOf("}") >= 0 || strIn.IndexOf(";") >= 0 || strIn.IndexOf(":") >= 0 || strIn.IndexOf("|") >= 0 || strIn.IndexOf("?") >= 0)
                return false;
            if (intStrLength >= intMin && intStrLength <= intMax)
            {
                //需要检测是否存在非法的XML字符
                Encoding ascii = Encoding.ASCII;
                byte[] bs = ascii.GetBytes(strIn);
                foreach (byte b in bs)
                {
                    if (b < 32)
                        return false;
                }
                if (IsValidWord(strIn))
                {
                    if (GetHtmlEncode(strIn) != strIn)
                        return false;
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public static bool IsValidNameExe(string strIn, int intMin, int intMax)
        {
                //需要检测是否存在非法的XML字符
                Encoding ascii = Encoding.ASCII;
                byte[] bs = ascii.GetBytes(strIn);
                foreach (byte b in bs)
                {
                    if (b < 32)
                        return false;
                }
                return true;
        }
        #endregion

        #region GetStrLength 检测输入的字符串长度
        /// <summary>
        /// 检测输入的字符串长度
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static int GetStrLength(string strIn)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] b = ascii.GetBytes(strIn);
            int l = 0;  // l 为字符串之实际长度
            for (int i = 0; i <= b.Length - 1; i++)
            {
                if (b[i] == 63)  //判断是否为汉字或全脚符号
                {
                    l++;
                }
                l++;
            }
            return l;
        }
        #endregion

        #region GetHtmlEncode 将提交的字符转换为HtmlEncode
        /// <summary>
        /// 将字符转换为HtmlEncode
        /// 例如将尖括号转换为&lt;
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static string GetHtmlEncode(string strIn)
        {
            HttpContext hc = HttpContext.Current;
            StringWriter sw = new StringWriter();
            hc.Server.HtmlEncode(strIn, sw);
            return sw.ToString();
        }
        #endregion

        #region GetSafeOutput 在输出时, 将字符转换为安全的 HtmlEncode 格式
        /// <summary>
        /// 在输出时, 将字符转换为安全的 HtmlEncode 格式, 安全的为<br />
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static string GetSafeOutput(string strIn)
        {
            strIn = strIn.Replace("\n","<br />");
            strIn=GetHtmlEncode(strIn).Replace("&lt;br /&gt;", "<br />");
            return strIn;
        }
        #endregion

        #region IsNumber 判断是否为数字
        public static bool IsNumber(object obj)
        {
            try
            {
                obj = Convert.ToInt64(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 判断是否为数字(不允许为负数)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="intType">数字类型0-byte;1-int;2-long;3-double</param>
        /// <returns></returns>
        public static bool IsNumber(object obj,int intType)
        {
            string strObj = obj.ToString();
            if (strObj.IndexOf("-") >= 0 )
                return false;
            if (intType == 1)
            {
                try
                {
                    obj = Convert.ToInt32(obj);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else if (intType == 2)
            {
                try
                {
                    obj = Convert.ToInt64(obj);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else if (intType == 3)
            {
                try
                {
                    obj = Convert.ToDouble(obj);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else if (intType == 0)
            {
                try
                {
                    obj = Convert.ToInt16(obj);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    obj = Convert.ToInt32(obj);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        #endregion

        #region GetFloat 取小数位后N位
        public static double GetFloat(double dblNumber, int intLength)
        {
            double i = Math.Pow(10, (double)intLength);
            int intNumber = (int)(dblNumber * i);
            dblNumber = Convert.ToDouble(intNumber / i);
            return dblNumber;

        }
        #endregion

        #region IsValidContent 判断输入可带有全角字符的内容是否在指定字数内
        /// <summary>
        /// 判断输入可带有全角字符的内容是否在指定字数内
        /// </summary>
        /// <param name="strIn">需要检测的字符串</param>
        /// /// <param name="intMin">最少的字符数（包括）</param>
        /// /// <param name="intMax">最大的字符数（包括）</param>
        /// <returns></returns>
        public static bool IsValidContent(string strIn, int intMin, int intMax)
        {
            int intStrLength = GetStrLength(strIn);

            if (intStrLength >= intMin && intStrLength <= intMax)
            {
                return IsValidWord(strIn);
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region GetChsNum 根据输入的数字得到中文数字
        public static string GetChsNum(int i)
        {
            string strOut;

            switch (i)
            { 
                case 0:
                    strOut = "零";
                    break;
                case 1:
                    strOut = "一";
                    break;
                case 2:
                    strOut = "二";
                    break;
                case 3:
                    strOut = "三";
                    break;
                case 4:
                    strOut = "四";
                    break;
                case 5:
                    strOut = "五";
                    break;
                case 6:
                    strOut = "六";
                    break;
                case 7:
                    strOut = "七";
                    break;
                case 8:
                    strOut = "八";
                    break;
                case 9:
                    strOut = "九";
                    break;
                case 10:
                    strOut = "十";
                    break;
                default:
                    strOut = "无";
                    break;
            }

            return strOut;
        }
        #endregion

        #region StringTruncat 将指定字符串按指定长度进行剪切,超出部分以"..."代替
        /// <summary>
        /// 将指定字符串按指定长度进行剪切,超出部分以"..."代替
        /// </summary>
        /// <parm name = "oldStr">需要截断的字符串</parm>
        /// <parm name = "maxLength">字符串的最大长度</parm>
        /// <parm name = "endWith">超过长度的后缀</parm>
        /// <return>如果超过长度,返回截断后的新字符串加上后缀,否则,返回原字符串</returns>
        public static string StringTruncat(string oldStr, int maxLength, string endWith)
        {
            if (string.IsNullOrEmpty(oldStr))
                // throw new NullReferenceException("原字符串不能为空");
                return oldStr + endWith;
            if (maxLength < 1)
                throw new Exception("返回的字符串长度必须大于[0]");
            //if (oldStr.Length > maxLength)
            //{
            //    string strTmp = oldStr.Substring(0, maxLength);
            //    if (string.IsNullOrEmpty(endWith))
            //        return strTmp;
            //    else
            //        return strTmp + endWith;
            //}

            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(oldStr);

            int i = 0;
            int n = 0;//表示当前的字节数
            int truncateNum = 0;//要截取的字节数

            for (; i < bytes.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    n++;
                }
                else
                {
                    if (bytes[i] > 0)
                    {
                        n++;
                    }
                }

                if (n < maxLength)
                    truncateNum = i;
            }



            if (n > maxLength)
            {
                if (truncateNum % 2 == 1)
                {
                    //　该UCS2字符是汉字时，去掉这个截一半的汉字
                    if (bytes[truncateNum] > 0)
                        truncateNum = truncateNum - 1;
                    //　该UCS2字符是字母或数字，则保留该字符
                    else
                    {
                        truncateNum = truncateNum + 1;
                    }
                }

                //else if (truncateNum % 2 == 1)
                //{
                //    //　该UCS2字符是汉字时，去掉这个截一半的汉字
                //    if (bytes[truncateNum + 1] > 0)
                //        truncateNum = truncateNum - 1;
                //    //　该UCS2字符是字母或数字，则保留该字符
                //    else
                //        truncateNum = truncateNum + 1;
                //}

                return System.Text.Encoding.Unicode.GetString(bytes, 0, truncateNum) + endWith;
            }
            else
            {
                truncateNum = bytes.GetLength(0);
                return System.Text.Encoding.Unicode.GetString(bytes, 0, truncateNum);
            }

            //return System.Text.Encoding.Unicode.GetString(bytes, 0, i);
        }
        #endregion StringTruncat 将指定字符串按指定长度进行剪切,超出部分以"..."代替
    }
}
