﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

using Org.Mentalis.Network.ProxySocket;
namespace LFNet.QQ.Net.Sockets
{
    public class ProxyTCPConnection : SocketConnection
    {
        Proxy proxy;
        public ProxyTCPConnection(ConnectionPolicy policy, EndPoint server, Proxy proxy)
            : base(policy,server)
        {
            this.proxy = proxy;
        }
        protected override ProxySocket GetSocket()
        {
            if (socket == null)
            {
                socket = new ProxySocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.ProxyType = (ProxyTypes)(int)proxy.ProxyType;
                socket.ProxyEndPoint = QQPort.GetEndPoint(this.proxy.ProxyHost, this.proxy.ProxyPort);
                //socket.SetSocketOption(SocketOptionLevel.Udp, SocketOptionName.SendTimeout, 3000);
            }
            return socket;
        }

        protected override void FillHeader(ByteBuffer buf)
        {

        }
    }
}
