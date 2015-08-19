using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;

namespace System.Drawing
{
    public static class BitmapExtensions
    {
        public static BitmapSource ToBitmapSource(this Bitmap bitmap, ImageFormat format, BitmapCreateOptions creationOptions = BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption cacheOptions = BitmapCacheOption.OnLoad)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");

            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {

                    // You need to specify the image format to fill the stream. 
                    // I'm assuming it is PNG
                    bitmap.Save(memoryStream, format);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    BitmapDecoder bitmapDecoder = BitmapDecoder.Create(
                        memoryStream,
                        creationOptions,
                        cacheOptions);

                    // This will disconnect the stream from the image completely...
                    WriteableBitmap writable =
            new WriteableBitmap(bitmapDecoder.Frames.Single());
                    writable.Freeze();

                    return writable;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static Bitmap ToNegative(this Bitmap source)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(source.Width, source.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            // create the negative color matrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
   {
      new float[] {-1, 0, 0, 0, 0},
      new float[] {0, -1, 0, 0, 0},
      new float[] {0, 0, -1, 0, 0},
      new float[] {0, 0, 0, 1, 0},
      new float[] {1, 1, 1, 0, 1}
   });

            // create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height),
                        0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();

            return newBitmap;
        }
    }
}
