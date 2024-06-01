using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace loginIndian.Classes
{
    internal class Captcha
    {
        private string text;
        private Bitmap image;

        public Captcha(int width, int height, string text = null)
        {
            this.text = text ?? GenerateRandomText();
            this.image = GenerateImage(width, height);
        }

        public string Text => text;
        public Bitmap Image => image;

        private string GenerateRandomText()
        {
            // Generate a random string of letters and numbers (customize as needed)
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private Bitmap GenerateImage(int width, int height)
        {
             image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                graphics.Clear(Color.White);

                using (var font = new Font("Arial", 20, FontStyle.Bold))
                {
                    // Draw the text onto the image (customize colors, position, etc.)
                    graphics.DrawString(text, font, Brushes.Blue, new PointF(10, 5));
                }

                // Add some noise or distortion to the image (optional)
                AddNoise(graphics, width, height);
            }

            return image;
        }

        private void AddNoise(Graphics graphics, int width, int height)
        {
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(width);
                int y = random.Next(height);
                image.SetPixel(x, y, Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
            }
        }

        public void SaveImage(string filePath)
        {
            image.Save(filePath, ImageFormat.Png);
        }

        // You can add more methods for customization (e.g., different fonts, colors, etc.)
}
}
