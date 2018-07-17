using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Drawing;
using System.IO;

namespace ArduinoBoardTest
{
    class OpenDoor_ClientDataVariables
    {
        public string RFCData { get; set; }
        public byte[] _Picture { get; set; }
        public Image Picture
        {
            get
            {
                return byteArrayToImage(this._Picture);
            }
            set
            {
                this._Picture = imageToByteArray(value);
            }
        }
        public string Result { get; set; }






        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }




    }
}
