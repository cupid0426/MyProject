﻿#region 版权声明
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

namespace LFNet.QQ.Packets.Out
{
    public class LoginGetListPacket : BasicOutPacket
    {
        //public static Dictionary<int, ushort> RequestCount = new Dictionary<int, ushort>();
        /// <summary>
        /// 分片次数
        /// </summary>
        public ushort Pos
        {
            // get { return RequestCount[this.Client.QQUser.QQ]; }
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public LoginGetListPacket(QQClient client)
            : base(QQCommand.LoginGetList, true, client)
        {
            //this.Pos = 0;
            //if (!RequestCount.ContainsKey(client.QQUser.QQ))
            //{
            //    RequestCount.Add(client.QQUser.QQ, 0);
            //}
            //else
            //    RequestCount[this.Client.QQUser.QQ]++;
        }
        public LoginGetListPacket(ByteBuffer buf, int length, QQClient client) : base(buf, length, client) { }

        public override string GetPacketName()
        {
            return "LoginGetList Packet";
        }

        protected override void PutBody(ByteBuffer buf)
        {
            
            buf.PutChar((char)Client.QQUser.QQKey.LoginInfo_Magic_Token.Length);
            buf.Put(user.QQKey.LoginInfo_Magic_Token);
            ByteBuffer DecodedBuf = new ByteBuffer();
            DecodedBuf.PutChar((char)0x011A);
            DecodedBuf.PutChar((char)0x0001);
            DecodedBuf.Put(VersionData.QQ09_LOCALE);
            DecodedBuf.Put(VersionData.QQ09_VERSION_SPEC);
            DecodedBuf.Put((byte)0x00);
            DecodedBuf.Put((byte)Client.QQUser.QQKey.Answer_Token.Length);
            DecodedBuf.Put(Client.QQUser.QQKey.Answer_Token);
            DecodedBuf.Put(Client.QQUser.QQKey.LoginInfo_UnknowData2);
            DecodedBuf.Put(Client.ServerTime);
            DecodedBuf.Put(Client.ClientIP);
            DecodedBuf.Position += 4;//00 00 00 00
            DecodedBuf.PutChar((char)Client.QQUser.QQKey.LoginInfo_Large_Token.Length);
            DecodedBuf.Put(Client.QQUser.QQKey.LoginInfo_Large_Token);
            DecodedBuf.PutUShort(this.Pos);
            DecodedBuf.Position += 2;// 00 00
            DecodedBuf.PutChar((char)0x0071);
            DecodedBuf.Position += 0x0070;//0x0071 zeros
            DecodedBuf.Put(0x00);

            byte[] EncodedBuf = crypter.Encrypt(DecodedBuf.ToByteArray(), user.QQKey.LoginInfo_Key1);
#if DEBUG
            Client.LogManager.Log(ToString() + " QQKey.LoginInfo_Key1:" + Utils.Util.ToHex(user.QQKey.LoginInfo_Key1));
            Client.LogManager.Log(ToString() + " pos:"+this.Pos+" UnBody:" + Utils.Util.ToHex(DecodedBuf.ToByteArray()));
#endif
            buf.Put(EncodedBuf);
#if DEBUG
            Client.LogManager.Log(ToString() + " EnBody:" + Utils.Util.ToHex(buf.ToByteArray()));
#endif
        }
    }
}
