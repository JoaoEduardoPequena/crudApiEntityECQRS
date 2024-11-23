using Net.Codecrete.QrCodeGenerator;
using System.Drawing;

namespace WebAPI.QrCodeExtension
{
    public static class QrCodeExtensions
    {
        public static Bitmap ToBitmap(this QrCode qrCode, int scale, int border)
        {
            int size = qrCode.Size + border * 2;
            var bitmap = new Bitmap(size * scale, size * scale);
            using var graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            for (int y = 0; y < qrCode.Size; y++)
            {
                for (int x = 0; x < qrCode.Size; x++)
                {
                    if (qrCode.GetModule(x, y))
                    {
                        graphics.FillRectangle(Brushes.Black, (x + border) * scale, (y + border) * scale, scale, scale);
                    }
                }
            }


            return bitmap;
        }
    }
}
