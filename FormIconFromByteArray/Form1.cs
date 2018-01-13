using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormIconFromByteArray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Bitmap bm = new Bitmap(32, 32);
            MemoryStream memStream;
            string filepath = @"C:\Images\favicon.png";


            using (Stream stream = new FileStream(filepath , FileMode.Open, FileAccess.Read))
            {
                memStream = new MemoryStream();
                byte[] buffer = new byte[1024];
                int byteCount;

                do
                {
                    byteCount = stream.Read(buffer, 0, buffer.Length);
                    memStream.Write(buffer, 0, byteCount);
                } while (byteCount > 0);
            }

            bm = new Bitmap(Image.FromStream(memStream));

            Icon ic = Icon.FromHandle(bm.GetHicon());
            this.Icon = ic;
        }
    }
}
