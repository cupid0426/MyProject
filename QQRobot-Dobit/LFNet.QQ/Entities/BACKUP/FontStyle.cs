﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace LFNet.QQ.Entities
{
    /// <summary>
    /// 字体
    /// </summary>
    public class FontStyle
    {
        /** 字体属性 */
        private const byte NONE = 0x00;
        private const byte BOLD = 0x20;
        private const byte ITALIC = 0x40;
        private const byte UNDERLINE = (byte)0x80;

        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public string FontName { get; set; }
        private bool bold;
        public bool Bold
        {
            get { return this.bold; }
            set
            {
                this.bold = value;
                fontFlag &= 0xDF;
                fontFlag |= bold ? BOLD : NONE;
            }
        }
        private bool italic;
        public bool Italic
        {
            get
            { return this.italic; }
            set
            {
                this.italic = value;
                fontFlag &= 0xBF;
                fontFlag |= italic ? ITALIC : NONE;
            }
        }
        private bool underline;
        public bool Underline
        {
            get
            {
                return this.underline;
            }
            set
            {
                this.underline = value;
                fontFlag &= 0x7F;
                fontFlag |= underline ? UNDERLINE : NONE;
            }
        }
        public int FontSize { get; set; }
        private ushort fontFlag; // 用来表示bold, italic, underline, fontSize的组合结果
        public string Encoding { get; set; }
        public Charset EncodingCode { get; set; }

        public FontStyle()
        {
            EncodingCode = Charset.GB;
            Encoding = "GBK";
            FontName = "宋体";
            Red = Green = Blue = 0;
            bold = italic = underline = false;
            FontSize = 0x9;
            fontFlag = 0x9;
        }
        /// <summary>
        /// </summary>
        /// <param name="buf">The buf.</param>
        public void Write(ByteBuffer buf)
        {
            buf.PutUShort(fontFlag);
            // 字体颜色红绿篮
            buf.Put((byte)Red);
            buf.Put((byte)Green);
            buf.Put((byte)Blue);
            // 一个未知字节
            buf.Put((byte)0);
            // 消息编码
            buf.PutUShort((ushort)EncodingCode);
            // 字体
            byte[] fontBytes = Utils.Util.GetBytes(FontName);
            buf.Put(fontBytes);
            // 字体属性长度（包括本字节）
            buf.Put((byte)(fontBytes.Length + 9));
        }

        /// <summary>
        /// </summary>
        /// <param name="buf">The buf.</param>
        public void Read(ByteBuffer buf)
        {
            fontFlag = buf.GetChar();
            // 分析字体属性到具体的变量
            // 字体大小
            FontSize = fontFlag & 0x1F;
            // 组体，斜体，下画线
            bold = (fontFlag & 0x20) != 0;
            italic = (fontFlag & 0x40) != 0;
            underline = (fontFlag & 0x80) != 0;
            // 字体颜色rgb
            Red = (int)buf.Get();
            Green = (int)buf.Get();
            Blue = (int)buf.Get();
            // 1个未知字节
            buf.Get();
            // 消息编码，这个据Gaim QQ的注释，这个字段用处不大，说是如果在一个英文windows
            // 里面输入了中文，那么编码是英文的，按照这个encoding来解码就不行了
            // 不过我们还是得到这个字段吧，后面我们采用先缺省GBK解码，不行就这个encoding
            // 解码，再不行就ISO-8859-1的方式
            EncodingCode = (Charset)buf.GetChar();
            Encoding = Utils.Util.GetEncodingString(EncodingCode);
            // 字体名称，字体名称也有中文的也有英文的，所以。。先来试试缺省的
            FontName = Utils.Util.GetString(buf.GetByteArray(buf.Length - buf.Position - 1));
        }
        /// <summary>
        /// </summary>
        /// <param name="buf">The buf.</param>
        public void Read09(ByteBuffer buf)
        {
            fontFlag = buf.GetChar();
            // 分析字体属性到具体的变量
            // 字体大小
            FontSize = fontFlag & 0x1F;
            // 组体，斜体，下画线
            bold = (fontFlag & 0x20) != 0;
            italic = (fontFlag & 0x40) != 0;
            underline = (fontFlag & 0x80) != 0;
            // 字体颜色rgb
            Red = (int)buf.Get();
            Green = (int)buf.Get();
            Blue = (int)buf.Get();
            // 1个未知字节
            buf.Get();
            // 消息编码，这个据Gaim QQ的注释，这个字段用处不大，说是如果在一个英文windows
            // 里面输入了中文，那么编码是英文的，按照这个encoding来解码就不行了
            // 不过我们还是得到这个字段吧，后面我们采用先缺省GBK解码，不行就这个encoding
            // 解码，再不行就ISO-8859-1的方式
            EncodingCode = (Charset)buf.GetChar();
            Encoding = Utils.Util.GetEncodingString(EncodingCode);
            // 字体名称，字体名称也有中文的也有英文的，所以。。先来试试缺省的
            FontName = Utils.Util.GetString(buf.GetByteArray(buf.Length - buf.Position - 1));
        }
        /// <summary>字体颜色
        /// </summary>
        /// <value></value>
        public Color FontColor
        {
            get { return Color.FromArgb(Red, Green, Blue); }
            set
            {
                Red = value.R;
                Green = value.G;
                Blue = value.B;
            }
        }

    }
}
