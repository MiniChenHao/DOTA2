using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace DOTA2.WebUI.AJAX
{
    /// <summary>
    /// BarCode 的摘要说明
    /// </summary>
    public class BarCode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            System.Drawing.Image Image = GenerateBarCodeBitmap("US-A-180717-032U0001");
            Graphics g = Graphics.FromImage(Image);
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddMilliseconds(0.0);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            context.Response.AppendHeader("Pragma", "No-Cache");
            MemoryStream ms = new MemoryStream();
            try
            {
                Image.Save(ms, ImageFormat.Png);
                context.Response.ClearContent();
                context.Response.ContentType = "image/Png";
                context.Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                Image.Dispose();
                g.Dispose();
            }
        }

        /// <summary>
        /// 生成条形码
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static Image GenerateBarCodeBitmap(string content)
        {
            Barcode barcode = new Barcode();
            barcode.IncludeLabel = true;
            barcode.Alignment = AlignmentPositions.CENTER;
            barcode.Width = 500;
            barcode.Height = 150;
            barcode.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
            barcode.BackColor = Color.White;
            barcode.ForeColor = Color.Black;
            return barcode.Encode(TYPE.CODE128B, content);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}