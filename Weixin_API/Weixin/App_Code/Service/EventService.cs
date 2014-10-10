﻿using System;
using System.Diagnostics;
using System.Web;
using Senparc.Weixin.MP.Entities;

namespace Senparc.Weixin.MP.Sample.CommonService
{
    /// <summary>
    /// 事件处理程序，此代码的简化MessageHandler方法已由/CustomerMessageHandler/CustomerMessageHandler_Event.cs完成，
    /// 此文件不再更新。
    /// </summary>
    public class EventService
    {
        public ResponseMessageBase GetResponseMessage(RequestMessageEventBase requestMessage)
        {
            ResponseMessageBase responseMessage = null;
            switch (requestMessage.Event)
            {
                case Event.ENTER:
                    {
                        var strongResponseMessage = ResponseMessageBase.CreateFromRequestMessage(requestMessage, ResponseMsgType.Text) as ResponseMessageText;
                        strongResponseMessage.Content = "您刚才发送了ENTER事件请求。";
                        responseMessage = strongResponseMessage;
                        break;
                    }
                case Event.LOCATION:
                    throw new Exception("暂不可用");
                    break;
                case Event.subscribe://订阅
                    {
                        var strongResponseMessage = ResponseMessageBase.CreateFromRequestMessage(requestMessage, ResponseMsgType.Text) as ResponseMessageText;

                        //获取Senparc.Weixin.MP.dll版本信息
                        var fileVersionInfo = FileVersionInfo.GetVersionInfo(HttpContext.Current.Server.MapPath("~/bin/Senparc.Weixin.MP.dll"));
                        var version = fileVersionInfo.FileVersion;
                        strongResponseMessage.Content = string.Format("欢迎关注【美天网络统一帐号管理系统】，当前运行版本：v{0}。\r\n官方地址：http://www.xba.com.cn", version);
                        responseMessage = strongResponseMessage;
                        break;
                    }
                case Event.unsubscribe://退订
                    {
                        //实际上用户无法收到非订阅账号的消息，所以这里可以随便写。
                        //unsubscribe事件的意义在于及时删除网站应用中已经记录的OpenID绑定，消除冗余数据。
                        var strongResponseMessage = ResponseMessageBase.CreateFromRequestMessage(requestMessage,
                                                                                       ResponseMsgType.Text) as ResponseMessageText;
                        strongResponseMessage.Content = "有空再来";
                        responseMessage = strongResponseMessage;
                        break;
                    }
                case Event.CLICK://菜单点击事件，根据自己需要修改
                    throw new Exception("Demo中还没有加入CLICK的测试！");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return responseMessage;         
        }
    }
}