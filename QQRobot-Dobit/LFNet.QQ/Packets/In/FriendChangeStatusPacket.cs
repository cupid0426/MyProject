﻿
#region 版权声明
//=========================================================== 
// 版权声明：LFNet.QQ是基于QQ2009版本的QQ协议开发而成的，协议
// 分析主要参考自小虾的MyQQ(C++)源代码，代码开发主要基于阿布
// 的LumaQQ.NET的C#.NET代码修改而成，故继续遵照使用LumaQQ的开
// 源协议。
//
// 本人没有对LumaQQ.NET的C#.NET代码的框架做过多的改动，主
// 要工作为将MyQQ的C++协议代码部分翻译成符合LumaQQ.Net框架
// 的C#代码，故请尊重LumaQQ作者Luma的著作权和版权声明。
// 
// 代码开源主要用于解决大家在学习和研究协议过程中遇到由于缺乏代码所带来的制约性问题。
// 本代码仅供学习交流使用，大家在使用此开发包前请自行协调好多方面关系，
// 不得用于任何商业用途和非法用途，本人不享受和承担由此产生的任何权利以及任何法律责任。
// 
// 本源代码可通过以下网址获取:
// http://QQCode.lynfo.com, http://www.lynfo.com, http://bbs.lynfo.com, http://hi.baidu.com/dobit.
//
// Copyright @ 2009-2010  Lynfo.com.  All Rights Reserved.   
// Framework: 2.0
// Author: Luma(java版) → Abu(C# QQ2005协议版) → Dobit(C# QQ2009协议版本)
// Email: dobit@msn.cn   
// Created: 2009-3-1~ 2009-11-28
// Last Modified:2009-11-28    
//   
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details. 
//===========================================================   
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace LFNet.QQ.Packets.In
{
    /// <summary>
    /// 无需在事件中更改用户状态了
    ///  * 好友状态改变包，这个是从服务器发来的包，格式为
    /// * 1. 头部
    /// * 2. 好友QQ号，4字节
    /// * 3. 未知的4字节
    /// * 4. 未知的4字节
    /// * 5. 好友改变到的状态，1字节
    /// * 6. 好友的客户端版本，2字节。这个版本号不是包头中的source，是内部表示，比如2004是0x04D1
    /// * 7. 未知用途的密钥，16字节
    /// * 8. 用户属性标志，4字节
    /// * 9. 我自己的QQ号，4字节
    /// * 10. 未知的2字节
    /// * 11. 未知的1字节
    /// * 12. 尾部
    /// </summary>
    public class FriendChangeStatusPacket : BasicInPacket
    {
        public uint FriendQQ { get; set; }
        public uint MyQQ { get; set; }
        public QQStatus Status { get; set; }
        public uint UserFlag { get; set; }
        public byte[] UnknownKey { get; set; }
        public char ClientVersion { get; set; }
        public FriendChangeStatusPacket(ByteBuffer buf, int length, QQClient client) : base(buf, length, client) { }
        public override string GetPacketName()
        {
            return "Friend Change Status Packet";
        }
        protected override void ParseBody(ByteBuffer buf)
        {
#if DEBUG
            Client.LogManager.Log(ToString() + " " + Utils.Util.ToHex(buf.ToByteArray()));
#endif
            FriendQQ = buf.GetUInt();
            buf.GetUInt();
            buf.GetUInt();
            Status = (QQStatus)buf.Get();
            Client.QQUser.Friends.SetFriendStatus((int)FriendQQ, Status);
            ClientVersion = buf.GetChar();
            UnknownKey = buf.GetByteArray(QQGlobal.QQ_LENGTH_KEY);
            UserFlag = buf.GetUInt();
            MyQQ = buf.GetUInt();
            buf.GetChar();
            buf.Get();
            
        }
    }
}
