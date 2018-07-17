using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace OpenDoorAPI
{
    public static class ImageConvert
    {

        public static byte[] ImageToByteArray(System.Drawing.Image image)
        {
            if (image == null)
                return null;
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
            //MemoryStream ms = new MemoryStream();
            //imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            //return ms.ToArray();
        }
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null)
                return null;
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] StringToByteArray(string hex)
        {
            if (hex.Length % 2 != 0)
                hex = "0" + hex;

            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static Image Base64ToImage(string base64String)
        {
            if (base64String == string.Empty)
                return null;
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
        public static string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            if (image == null)
                return string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to base 64 string
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public static string ByteArrayToBase64(byte[] byteArrayIn)
        {
            var img = ByteArrayToImage(byteArrayIn);
            return ImageToBase64(img, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public static byte[] Base64ToByteArray(string Base64)
        {
            return Convert.FromBase64String(Base64);
            //var aa = ImageConvert.ByteArrayToImage(imgbyte);
            //aa.Save("d:\\12321.jpg");
        }
    }
}