﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace LFNet.QQ.Packets.Out
{
    /// <summary>
    ///  * 设置成员角色的请求包
    /// * 1. 头部
    /// * 2. 群命令类型，1字节，0x1B
    /// * 3. 群内部ID，4字节
    /// * 4. 要设置角色的QQ号，4字节
    /// * 5. 操作码，0x00为删除管理员，0x01为设置管理员
    /// * 6. 尾部
    /// 	<remark>abu 2008-02-29 </remark>
    /// </summary>
    public class ClusterSetRolePacket : ClusterCommandPacket
    {
        public byte OpCode { get; set; }
        public int QQ { get; set; }
        public ClusterSetRolePacket(QQClient client)
            : base(client)
        {
            SubCommand = ClusterCommand.SET_ROLE;
        }
        public ClusterSetRolePacket(ByteBuffer buf, int length, QQClient client) : base(buf, length, client) { }
        public override string GetPacketName()
        {
            return "Cluster Set Role Packet";
        }
        protected override void PutBody(ByteBuffer buf)
        {
            // 群命令类型
            buf.Put((byte)SubCommand);
            // 群内部ID
            buf.PutInt(ClusterId);
            // 接收者QQ号
            buf.PutInt(QQ);
            // 操作
            buf.Put(OpCode);
        }
    }
}
