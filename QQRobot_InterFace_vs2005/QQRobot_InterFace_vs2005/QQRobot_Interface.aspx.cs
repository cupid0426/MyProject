using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;
using NetRobotApi;
using QQRobot_Module;
using System.Web;

namespace QQRobot_InterFace_vs2005
{
    public partial class _Default : System.Web.UI.Page
    {
        static string Copyright = "Cupid";//密匙信息验证，应与机器人配置相同
        static string fenge = "@"; //分隔符
        static string AdminQQ = "182536608,278614660";//管理员QQ号码，多个管理员用“ ，”隔开最后一个也要加上
        static string QQ = "1349836289,1667100016";//QQ机器人号码，多个机器人用“ ，”隔开最后一个也要加上
        static string Filtration = "";//需要过滤群消息的QQ号码，多个QQ用“ ，”隔开最后一个也要加上
        static string RobotName = "【Robot】40"; //机器人名字
        static string RobotIP = "127.0.0.1";//机器人IP
        static string RobotPort = "8848";//Api端口
        public static Queue que = Queue.Synchronized(new Queue());
        static string getcode;
        static string strResult = null;

        ServerCheck sc = new ServerCheck();
        ServerMonitor sm = new ServerMonitor();
        SearchInfo si = new SearchInfo();
        QQRobot_Plugins Plugins = new QQRobot_Plugins();

        static public String YZadmin(string Sender)
        {
            Match Yadmin = Regex.Match(AdminQQ, Sender + ",", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (Yadmin.Success)
            {
                string QQback = "T";
                return QQback;
            }
            else
            {
                string QQback = "F";
                return QQback;
            }
        }
        /// <summary>
        /// APi操作类
        /// </summary>
        /// <param name="SendType">发送类型</param>
        /// <param name="ID">QQ号码或群内部ID</param>
        /// <param name="Message">消息内容</param>
        static public void SendApi(string SendType, string ID, string Message)
        {
            string Api = "http://" + RobotIP + ":" + RobotPort + "/Api?Key=" + Copyright + "&SendType=" + SendType + "&utf=1&ID=" + ID + "&Message=" + HttpUtility.UrlEncode(Message);
            RobotApi.get(Api, "utf-8");
        }

        static public void SendMessage(string Event, string Sender, string Qunnid, string Message)
        {
            //string font = "[字体=宋体,9," + new Random().Next(0, 0xffffff).ToString() + ",0,0,0]";
            //string font = "[字体=宋体,9,4915330,0,0,0]";
            string font = "";
            if (Event == "ReceiveClusterIM")
            {
                SendApi("SendClusterMessage", Qunnid, font + Message);
            }
            else if (Event == "ReceiveNormalIM")
            {
                SendApi("SendMessage", Sender, font + Message);
            }
            else if (Event == "ReceiveAddFriends")
            {
                SendApi("SendMessage", Sender, font + Message);
            }
            else if (Event == "ReceiveVibration")
            {
                SendApi("SendMessage", Sender, font + Message);
            }
            else if (Event == "ReceiveSignatureChanged")
            {
                SendApi("SendMessage", Sender, font + Message);
            }
            else if (Event == "ReceiveFriendChangeStatus")
            {
                SendApi("SendMessage", Sender, font + Message);
            }
            else if (Event == "LoginSucceed")
            {
                SendApi("SendMessage", Sender, font + Message);
            }
        }

        protected void com(string Event, string Qunid, string Qunnid, string Sender, string Nick, string Message, string AdminQQ)
        {
            string[] sArray1 = System.Text.RegularExpressions.Regex.Split(Message, " ");
            string command = sArray1[0];
            int msgsArray1 = 1;
            int adminmsgzu = 2;
            string msg = "";
            string adminmsg = "";
            if (sArray1.Length > 1)
            {
                while (msgsArray1 < sArray1.Length)
                {
                    msg += sArray1[msgsArray1];
                    msg += " ";
                    msgsArray1++;
                }
                if (sArray1.Length > 2)
                {
                    while (adminmsgzu < sArray1.Length)
                    {
                        adminmsg += sArray1[adminmsgzu];
                        adminmsg += " ";
                        adminmsgzu++;
                    }
                }
            }


            switch (command.ToLower())
            {
                //功能参数区-----------------------------
                case "@":
                    if (YZadmin(Sender) == "T")
                    {
                        SendMessage(Event, Sender, Qunnid, string.Format("你好，我是" + RobotName + "！\r======您可以使用如下命令======\r{0}聊天  与小i机器人进行对话\r{0}tq    天气查询（老）\r{0}weather    天气查询（新）\r{0}ip    查询IP归属地\r{0}md5   查询MD5加密数值\r{0}qun   查询本群信息资料\r{0}qq    查询QQ状态\r{0}bm    查询 base64 加密\r{0}jm    查询 base64 解密\r{0}by    查询异或后 base64 加密\r{0}jy    查询异或后 base64 解密\r{0}cfs   查询 Cfs加密 单项不可逆\r{0}al    查询全球 Alexa 排名\r{0}ips   查询同服务器下站点数量\r{0}dns   查询本域名下的DNS服务器\r{0}sfz   查询身份证信息\r{0}t18   15位身份证升级为18为身份证\r{0}m     查询手机归属地\r{0}who   *域名或IP地址的 WHOIS 记录查询\r直接输入命令将回复使用方法！\r更多功能正在添加中！\r======您是管理员，可以使用下面的功能！======\r1.to QQ号码 消息内容->发送QQ消息\r2.q 群号 内容->发送群消息\r3.tc QQ号码->给好友发送震动\r4.{0}reset->重新启动机器人\r5.{0}update->更新机器人\r======您是超级管理员，可以使用下面的功能！======\r1、{0}turn    游戏赛季更新检测  例：{0}turn BB\r2、{0}status    游戏夜间更新检测  例：{0}status BB\r3、{0}season    查询赛季更新详情  例：{0}season XBA\r4、{0}check    查询夜间更新是否执行  例：{0}check BB\r5、{0}ping    PING命令  例：{0}ping www.baidu.com", fenge));
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, string.Format("你好，我是" + RobotName + "！\r======您可以使用如下命令======\r{0}聊天  与小i机器人进行对话\r{0}tq    天气查询（老）\r{0}weather    天气查询（新）\r{0}ip    查询IP归属地\r{0}md5   查询MD5加密数值\r{0}qun   查询本群信息资料\r{0}qq    查询QQ状态\r{0}bm    查询 base64 加密\r{0}jm    查询 base64 解密\r{0}by    查询异或后 base64 加密\r{0}jy    查询异或后 base64 解密\r{0}cfs   查询 Cfs加密 单项不可逆\r{0}al    查询全球 Alexa 排名\r{0}ips   查询同服务器下站点数量\r{0}dns   查询本域名下的DNS服务器\r{0}sfz   查询身份证信息\r{0}t18   15位身份证升级为18为身份证\r{0}m     查询手机归属地\r{0}who   *域名或IP地址的 WHOIS 记录查询\r直接输入命令将回复使用方法！\r更多功能正在添加中！", fenge));
                    }
                    break;
                case "@聊天":
                    if (sArray1.Length != 1)
                    {
                        RobotApi r = new RobotApi();
                        r.Xiaoi();
                        getcode = r.chatXiaoi(msg, RobotName);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "你想对我说什么？干嘛那么墨迹...");
                    }
                    break;
                case "@ip":
                    if (sArray1.Length == 2)
                    {
                        getcode = Nick + "，您查询的信息如下：\r" + NetRobotApi.RobotApi.chaip(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。请返回检查！谢谢合作！");
                    }
                    break;
                case "@weather":
                    if (sArray1.Length == 2)
                    {
                        RobotApi api = new RobotApi();
                        getcode = Nick + "，" + api.GetWeather(sArray1[1], "3");
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else if (sArray1.Length == 3)
                    {
                        RobotApi api = new RobotApi();
                        getcode = Nick + "，" + api.GetWeather(sArray1[1], sArray1[2]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r天气查询（新）使用方法：@weather 城市名 或（区号，拼音（支持模糊），邮编）\r例：\r@weather 北京（城市名）\r@weather 0597（区号）\r@weather beijin（拼音）\r@weather 364000（邮编）");
                    }
                    break;
                case "@md5"://查询MD5加密数值
                    if (sArray1.Length == 2)
                    {
                        getcode = Nick + "，" + NetRobotApi.RobotApi.Md5(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\rMD5加密查询使用方法：@md5 明文\r例：@md5 Vckers");
                    }
                    break;
                case "@qq"://查询QQ状态
                    if (sArray1.Length == 2)
                    {
                        getcode = Nick + "，" + NetRobotApi.RobotApi.QQonline(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r查询QQ状态使用方法：@qq QQ号码\r例：@qq 582257138");
                    }
                    break;
                case "@bm"://查询 base64 加密
                    if (sArray1.Length == 2)
                    {
                        getcode = Nick + "，" + NetRobotApi.RobotApi.enbase64(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r查询 base64 加密使用方法：@bm 明文\r例：@bm Vckers");
                    }
                    break;
                case "@jm"://查询 base64 解密
                    if (sArray1.Length == 2)
                    {
                        getcode = Nick + "，" + NetRobotApi.RobotApi.debase64(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r查询 base64 解密使用方法：@jm 密文\r例：@jm VmNrZXJz");
                    }
                    break;
                case "@by"://查询异或后 base64 加密
                    if (sArray1.Length == 3)
                    {
                        getcode = Nick + "，" + NetRobotApi.RobotApi.encode(sArray1[1], sArray1[2]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r查询异或后 base64 加密使用方法：@by 明文 异或参数\r例：@by 123456 Vckers");
                    }
                    break;
                case "@jy"://查询异或后 base64 解密
                    if (sArray1.Length == 3)
                    {
                        getcode = Nick + "，" + NetRobotApi.RobotApi.decode(sArray1[1], sArray1[2]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r查询异或后 base64 解密使用方法：@jy 密文 异或参数\r例：@jy UllWRkZg Vckers");
                    }
                    break;
                case "@cfs"://查询 Cfs加密 单项不可逆
                    if (sArray1.Length == 2)
                    {
                        getcode = Nick + "，" + NetRobotApi.RobotApi.cfs(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r查询 Cfs加密使用方法：@cfs 明文 （注意：该操作不可逆）\r例：@cfs Vckers");
                    break;
                case "@hb"://货币换算查询
                    if (sArray1.Length == 2)
                    {
                        getcode = Nick + "，" + NetRobotApi.RobotApi.chaip(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。请返回检查！谢谢合作！");
                    }
                    break;
                case "@al"://查询全球 Alexa 排名
                    if (sArray1.Length == 2)
                    {
                        getcode = Nick + "，" + NetRobotApi.RobotApi.Alexa(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r查询全球 Alexa 排名使用方法：@al 域名 （注意：不需要带http头）\r例：@al Vckers.com");
                    }
                    break;
                case "@ips"://查询同服务器下站点数量
                    if (sArray1.Length == 2)
                    {

                        getcode = Nick + "，" + NetRobotApi.RobotApi.chaip(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。请返回检查！谢谢合作！");
                    }
                    break;
                case "@dns"://查询本域名下的DNS服务器
                    if (sArray1.Length == 2)
                    {
                        getcode = Nick + "，" + NetRobotApi.RobotApi.dns(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                        return;
                    }
                    SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r查询本域名下的DNS服务器使用方法：@dns 域名 （注意：不需要带http头）\r例：@dns Vckers.com");
                    break;
                case "@who"://域名或 IP 地址的 WHOIS 记录查询：
                    if (sArray1.Length == 2)
                    {
                        Match m1 = Regex.Match(sArray1[1], @"([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                        if (m1.Success)
                        {
                            getcode = Nick + "，" + NetRobotApi.RobotApi.whois("domain", sArray1[1]);
                            SendMessage(Event, Sender, Qunnid, getcode);
                            return;
                        }
                        Match m2 = Regex.Match(sArray1[1], "[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                        if (m2.Success)
                        {
                            getcode = Nick + "，" + NetRobotApi.RobotApi.whois("ip", sArray1[1]);
                            SendMessage(Event, Sender, Qunnid, getcode);
                            return;
                        }
                        else
                        {
                            SendMessage(Event, Sender, Qunnid, Nick + "，" + "该域名不是标准域名或IP格式！");
                        }
                    }
                    SendMessage(Event, Sender, Qunnid, Nick + "，" + "*本功能尚未完善*\r参数错误。\r域名或IP地址的 WHOIS 记录查询使用方法：@dns 域名 或 IP （注意：域名不需要带http头）\r例：\r@who Vckers.com（域名）\r@who 202.108.33.32（IP地址）");
                    break;
                case "@sfz"://身份证信息查询
                    if (sArray1.Length == 2)
                    {
                        getcode = Nick + "，" + NetRobotApi.RobotApi.sfz(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                        return;
                    }
                    break;
                case "@t18"://15位身份证升级为18为身份证
                    if (sArray1.Length == 2)
                    {

                        getcode = Nick + "，" + NetRobotApi.RobotApi.upto18(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, getcode);
                        return;
                    }
                    SendMessage(Event, Sender, Qunnid, Nick + "，" + "*本功能尚未完善*\r参数错误。\r域名或IP地址的 WHOIS 记录查询使用方法：@dns 域名 或 IP （注意：域名不需要带http头）\r例：\r@who Vckers.com（域名）\r@who 202.108.33.32（IP地址）");
                    break;
                case "@m"://查询手机号码归属地
                    if (sArray1.Length == 2)
                    {
                        if (sArray1[1].Length == 11)
                        {
                            getcode = Nick + "，" + NetRobotApi.RobotApi.shouji(sArray1[1]);
                            SendMessage(Event, Sender, Qunnid, getcode);
                        }
                        else
                        {
                            SendMessage(Event, Sender, Qunnid, Nick + "，" + "恩，我记得手机号码应该是11位的吧..你输入的好像不是11位哦？");
                        }
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r手机归属地查询使用方法：@m 手机号码\r例：@m 13459777850");
                    }
                    break;
                //========================= Cupid 自定义内容 =========================
                case "@turn"://赛季更新查询
                    if (sArray1.Length == 2)
                    {
                        strResult = sc.GetGameTurn(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, strResult);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r赛季更新检测的使用方法：@turn 项目名称(BB,FB)\r例：@turn BB");
                    }
                    break;
                case "@status"://夜间更新查询
                    if (sArray1.Length == 2)
                    {
                        strResult = sc.GetGameStatus(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, strResult);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r夜间更新检测的使用方法：@status 项目名称(BB,FB)\r例：@status BB");
                    }
                    break;
                case "@mail"://发送邮件
                    if (sArray1.Length == 4)
                    {
                        strResult = sm.SendMail(sArray1[1], sArray1[2], sArray1[3]);
                        SendMessage(Event, Sender, Qunnid, strResult);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r夜间更新检测的使用方法：@mail 收件邮件 邮件主题 邮件内容\r例：@mail toMail@xxx.com 开会 三点开会");
                    }
                    break;
                case "@season"://赛季更新时间查询
                    if (sArray1.Length == 2)
                    {
                        strResult = sc.GetGameSeason(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, strResult);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r赛季更新检测的使用方法：@season 关键字名称(XBA,DW,TOM)\r例：@season XBA");
                    }
                    break;
                case "@check"://查询夜间更新是否执行
                    if (sArray1.Length == 2)
                    {
                        strResult = sc.GetGameCheck(sArray1[1]);
                        SendMessage(Event, Sender, Qunnid, strResult);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r查询夜间更新是否执行的使用方法：@check 项目名称(BB,FB)\r例：@check BB");
                    }
                    break;
                case "@userinfo"://查询用户信息
                    if (sArray1.Length == 3)
                    {
                        strResult = si.UserInfo(sArray1[1].ToString(), sArray1[2]);
                        SendMessage(Event, Sender, Qunnid, strResult);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\r查询用户信息的使用方法：\r@userinfo 用户名类型(0为经理名|1为用户名) 经理名\r例：@userinfo 0 风中脱手");
                    }
                    break;
                case "@ping"://PING命令
                    if (sArray1.Length == 3 || sArray1.Length == 2)
                    {
                        int intSendCount = 0;
                        if (sArray1.Length == 2)
                        {
                            intSendCount = 4;
                        }
                        else
                        {
                            intSendCount = Convert.ToInt32(sArray1[2]);
                        }                        
                        strResult = sm.Pings(sArray1[1].ToString(), intSendCount);
                        SendMessage(Event, Sender, Qunnid, strResult);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "参数错误。\rPING命令的使用方法：@ping 地址/IP 发包数（选填项不填默认为4个包）\r例：@ping www.baidu.com");
                    }
                    break;
                //====================================================================
                case "to":
                    if (sArray1.Length > 2)
                    {
                        if (YZadmin(Sender) == "T")
                        {
                            SendApi("SendMessage", sArray1[1], adminmsg);
                        }
                        else
                        {
                            SendMessage(Event, Sender, Qunnid, Nick + "，" + "您好，您不是管理员不能使用该功能！");
                        }
                    }
                    break;
                case "@reset":
                    if (YZadmin(Sender) == "T")
                    {
                        SendApi("Reset", Qunnid, adminmsg);
                        SendMessage(Event, Sender, Qunnid, string.Format(Nick + "，" + "机器人重启命令发送成功！"));
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "您好，您不是管理员不能使用该功能！");
                    }
                    break;
                case "@update":
                    if (YZadmin(Sender) == "T")
                    {
                        //SendApi("Reset", Qunnid, adminmsg);
                        SendMessage(Event, Sender, Qunnid, string.Format(Nick + "，" + "机器人更新命令发送成功！"));
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "您好，您不是管理员不能使用该功能！");
                    }
                    break;
                case "@exit":
                    if (YZadmin(Sender) == "T")
                    {
                        SendApi("Exit", "", "");
                        SendMessage(Event, Sender, Qunnid, string.Format(Nick + "，" + "机器人退出命令发送成功！"));
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "您好，您不是管理员不能使用该功能！");
                    }
                    break;
                case "@login":
                    if (YZadmin(Sender) == "T")
                    {
                        SendApi("Login", "", "");
                        SendMessage(Event, Sender, Qunnid, string.Format(Nick + "，" + "机器人登陆命令发送成功！"));
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "您好，您不是管理员不能使用该功能！");
                    }
                    break;
                case "@change":
                    if (YZadmin(Sender) == "T")
                    {
                        if (sArray1.Length == 3)
                        {
                            que.Enqueue(string.Format("Change\r{0}\r{1}", sArray1[1], sArray1[2]));
                            SendMessage(Event, Sender, Qunnid, string.Format(Nick + "，" + "更换机器人号码成功！更换后的号码为：" + sArray1[1]));
                        }
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "您好，您不是管理员不能使用该功能！");
                    }
                    break;
                case "q":
                    if (YZadmin(Sender) == "T")
                    {
                        SendApi("SendClusterMessage", sArray1[1], adminmsg);
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "您好，您不是管理员不能使用该功能！");
                    }
                    break;
                case "tc":
                    if (YZadmin(Sender) == "T")
                    {
                        SendApi("SendVibration", sArray1[1], adminmsg);
                        SendMessage(Event, Sender, Qunnid, string.Format(Nick + "，" + "操作成功！成功把参数传给机器人！请等待机器人回应！"));
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, Nick + "，" + "您好，您不是管理员不能使用该功能！");
                    }
                    break;

                //------------------------------------


                //休眠命令-----------------------------
                case "小璇，咱睡觉去":
                    if (YZadmin(Sender) == "T")
                    {
                        que.Enqueue(string.Format("qunoff\r1\r1"));
                        SendMessage(Event, Sender, Qunnid, "好啊！累死我了，睡觉去咯.....");
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, "咳咳，我和你很熟吗？你就这么命令我？");
                    }
                    break;
                case "小璇，洗白白去咯":
                    if (YZadmin(Sender) == "T")
                    {
                        que.Enqueue(string.Format("qunoff\r1\r1"));
                        SendMessage(Event, Sender, Qunnid, "洗白白..洗白白...拜拜咯~ (*^__^*) ");
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, "你个色狼，想看人家洗澡...呜呜...");
                    }
                    break;
                case "小璇，屏蔽所有信息，等我命令":
                    if (YZadmin(Sender) == "T")
                    {
                        que.Enqueue(string.Format("qunoff\r1\r1"));
                        SendMessage(Event, Sender, Qunnid, "收到命令！执行……，嘿嘿屏蔽成功！就等你说话呢！");
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, "你谁啊..又不是我的主人..凭什么命令我？");
                    }
                    break;
                case "小璇，撤除屏蔽":
                    if (YZadmin(Sender) == "T")
                    {
                        que.Enqueue(string.Format("qunon\r1\r1"));
                        SendMessage(Event, Sender, Qunnid, "好了，已经撤除屏蔽");
                        return;
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, "恩？你教我撤就撤。那我的面子往哪放？");
                    }
                    break;
                case "小璇，睡觉去吧":
                    if (YZadmin(Sender) == "T")
                    {
                        que.Enqueue(string.Format("qunoff\r1\r1"));
                        SendMessage(Event, Sender, Qunnid, "恩，好的，柏拉再见哦");
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, "不行，我在等柏拉呢");
                    }
                    break;
                case "小璇，起床了":
                    if (YZadmin(Sender) == "T")
                    {
                        que.Enqueue(string.Format("qunon\r1\r1"));
                        SendMessage(Event, Sender, Qunnid, "起床啦....我又回来了");
                        return;
                    }
                    break;
                case "小璇，给我回来":
                    if (YZadmin(Sender) == "T")
                    {
                        que.Enqueue(string.Format("qunon\r1\r1"));
                        SendMessage(Event, Sender, Qunnid, "我又回来了 - -！");
                        return;
                    }
                    SendMessage(Event, Sender, Qunnid, "去..给爷滚开，我又没出去！");
                    break;

                //------------------------------------


                //自动回复-----------------------------

                case "小璇，求代码":
                    SendMessage(Event, Sender, Qunnid, "哈哈，你要我的代码？我现在还没开源哦...");
                    break;
                case "小璇，求程序":
                    if (Qunid == "93068095")
                    {
                        SendMessage(Event, Sender, Qunnid, "恭喜您，您已经加入了QQ机器人俱乐部。\r现在请打开群共享，选择最新版本下载！");
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, "恩，程序啊...请加群93068095获得。");
                    }
                    break;
                case "小璇，程序打不开":
                    if (Qunid == "93068095")
                    {
                        SendMessage(Event, Sender, Qunnid, "请您打开群共享，下载机器人教程观看！如果无法解决请联系管理员！");
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, "打不开？出错了？请加群93068095解决！");
                    }
                    break;
                case "q群":
                case "qq群":
                case "小璇，qq群是多少？":
                case "小璇，交流群号码多少？":
                    SendMessage(Event, Sender, Qunnid, "QQ机器人俱乐部：93068095\r该群提供机器人程序，机器人接口，支持刷屏，测试QQ机器人等");
                    break;
                case "小璇，喊大爷":
                    if (YZadmin(Sender) == "T")
                    {
                        SendMessage(Event, Sender, Qunnid, "柏拉大爷好！");
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, "喊你个XXOO的");
                    }
                    break;
                case "小璇，清屏":
                    if (YZadmin(Sender) == "T")
                    {
                        SendMessage(Event, Sender, Qunnid, "\r\r\r\r\r\r\r\r\r\r\r\r\r\r\r\r\r\r\r\r\r清理完毕！");
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, "人家只认柏拉");
                    }
                    break;
                case "小璇":
                    if (YZadmin(Sender) == "T")
                    {
                        SendMessage(Event, Sender, Qunnid, "柏拉大爷，我在呢，找小的干嘛？");
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, "爷在呢，找我干嘛？");
                    }
                    break;
                case "小璇，骂他们":
                    if (YZadmin(Sender) == "T")
                    {
                        SendMessage(Event, Sender, Qunnid, "我XX你个OO的...你们再欺负我就画个圈圈诅咒你们！！");
                    }
                    else
                    {
                        SendMessage(Event, Sender, Qunnid, "你叫我骂就骂啊，那我岂不是很没面子 - -！");
                    }
                    break;
                case "接口版本":
                    {
                        SendMessage(Event, Sender, Qunnid, "该接口为官方接口\r更新日期 2010年12月19日 19:24:08 \r开发者：柏拉");
                        break;
                    }
                default:
                    if (Event == "ReceiveNormalIM")
                    {
                        RobotApi r = new RobotApi();
                        r.Xiaoi();
                        getcode = r.chatXiaoi(msg, RobotName);
                        SendMessage(Event, Sender, Qunnid, getcode);
                    }
                    else { };
                    break;

                //------------------------------------

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RequestType.Equals("post", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {
                    if (Request.Form["Copyright"].Trim() == Copyright)
                    {
                        goto Loding;
                    }
                    else
                    {
                        Response.Write("密匙验证错误！您没有权限使用该接口！");
                        return;
                    }
                }
                catch
                {
                    Response.Write("密匙验证错误！您没有权限使用该接口！");
                    return;
                }

                ///***************************************

            Loding:
                string Event = Request.Form["Event"].Trim();
                string Qunid = Request.Form["ClusterNum"].Trim();
                string Qunnid = Request.Form["ClusterName"].Trim();
                //Qunnid = Qunid;
                string Sender = Request.Form["Sender"].Trim();
                string Nick = Request.Form["Nick"].Trim();
                string Message = Request.Form["Message"].Trim();
                string SendTime = Request.Form["SendTime"].Trim();
                string Version = Request.Form["Version"].Trim();
                try
                {
                    string RobotQQ = Request.Form["RobotQQ"].Trim();
                    if (NetRobotApi.RobotApi.YZrobot(RobotQQ, QQ) == "T")
                    {
                    }
                    else
                    {
                        //SendMessage(Event, Sender, Qunid,"您的QQ不能使用该接口！");
                        //return;
                    }
                }
                catch
                {
                    SendMessage(Event, Sender, Qunid, "您目前的版本不支持该接口！");
                    return;
                }

                if (Event == "ReceiveNormalIM")
                {//qq消息

                    if (Message.Length > 500)
                    {
                        SendMessage(Event, Sender, Qunid, "我操，搞个飞机啊。。这么长！");
                        return;
                    }
                    string font = "[字体=宋体,9," + new Random().Next(0, 0xffffff).ToString() + ",0,0,0]";
                    if (Sender != "582257138")
                    {
                        SendApi("SendMessage", "582257138", font + Sender + " [" + Nick + "]对机器人说：" + Message);
                    }
                    com(Event, Qunid, Qunid, Sender, Nick, Message, YZadmin(Sender));

                }
                else if (Event == "ReceiveAddFriends")
                {//加好友消息
                    //SendMessage(Event, Sender, Qunnid, string.Format("接口演示\r\r收到加好友的请求：{0}的消息：{1}", Sender, Message));
                }
                else if (Event == "ReceiveSignatureChanged")
                {//好友签名改变
                    //SendMessage(Event, Sender, Qunnid, string.Format("接口演示\r\r收到好友签名改变：QQ：{0} 昵称：{1}\r签名信息：{2}", Sender, Nick, Message));
                }
                else if (Event == "ReceiveFriendChangeStatus")
                {//好友状态改变
                    //SendMessage(Event, Sender, Qunnid, string.Format("接口演示\r\r收到好友状态改变：QQ：{0} 昵称：{1}\r状态：{2}", Sender, Nick, Message));
                }
                else if (Event == "LoginSucceed")
                {//机器人登陆成功
                    //SendMessage(Event, Sender, Qunnid, string.Format("接口演示\r\r机器人登陆成功 ：{0}", Message));
                }
                else if (Event == "ReceiveVibration")
                {//收到弹窗
                    //SendMessage(Event, Sender, Qunnid, string.Format("接口演示\r\r收到你的弹窗！", Sender, Message));
                }
                else if (Event == "ReceiveClusterIM")
                {//群消息处理  
                    if (NetRobotApi.RobotApi.YZQQ(Sender, Filtration) == "T") { return; }
                    else if (Message.Length > 500)//消息太长
                    {
                        SendMessage(Event, Sender, Qunid, "我操，搞个飞机啊。。这么长！");
                        return;
                    }
                    else
                    {
                        com(Event, Qunid, Qunid, Sender, Nick, Message, YZadmin(Sender));
                    }

                }
                else if (Event == "Reset")
                {//紧急重启
                    que.Enqueue(string.Format("3\r1\r1"));
                }
                else if (Event == "Update")
                {//更新机器人
                    que.Enqueue(string.Format("4\r1\r1"));
                }
            }
            else if (Request.RequestType.Equals("get", StringComparison.InvariantCultureIgnoreCase))
            {
                //string  a = RobotApi.get("http://127.0.0.1:2010/Api?Key=QQrobot&SendType=SendVibration&QQnumber=582257138", "utf-8");
                //SendMessage(Event, Sender, Qunnid,a);
                //string RobotQQ1 = Request.QueryString["RobotQQ"].Trim();
                try
                {
                    string Copyright1 = Request.QueryString["Copyright"].Trim();
                    if (Copyright1 == Copyright)
                    {
                        string RobotQQ2 = Request.QueryString["RobotQQ"].Trim();
                        /*if (NetRobotApi.RobotApi.YZrobot(RobotQQ2, QQ) == "T")
                        {*/
                        if (que.Count > 0)
                        {
                            Response.Write(que.Dequeue() as string);
                        }

                        /* }*/
                        return;

                    }
                    else
                    {
                        Response.Write("密匙验证错误！您没有权限使用该接口！");
                        return;
                    }
                }
                catch
                {
                }

                try
                {
                    string config = Request.QueryString["config"].Trim();
                    if (config == "Qr")
                    {
                        Response.Write("Copyright © Vckers.com 2010-2012");
                        return;
                    }
                }
                catch
                {

                }
            }
        }
    }
}
