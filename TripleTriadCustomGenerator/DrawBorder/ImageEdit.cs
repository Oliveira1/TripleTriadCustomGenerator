using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace TripleTriadCustomGenerator.DrawBorder
{
    public static class ImageEdit
    {
        public static void DrawBorder(Rarity borderType, int[] stats, string imgPath, string destFilename)
        {
            var width = 300;
            var height = 500;
            Console.WriteLine(imgPath);
            using var img = Image.FromFile(imgPath);
            using var bmp = ResizeImage(img, width, height);

            var color = borderType switch
            {
                Rarity.Legendary => Color.Goldenrod,
                Rarity.Rare => Color.DarkCyan,
                Rarity.Commmon => Color.DarkSlateGray,
                _ => Color.DarkSlateGray
            };
            using (var g = Graphics.FromImage(bmp))
            {
                var thickGoldPen = new Pen(color, 20);

                g.DrawRectangle(thickGoldPen, new Rectangle(0, 0, width, height));

                var xMiddle = width / 2;
                var yMiddle = height / 2;
                var verticalRulerA = xMiddle - xMiddle / 3;
                var verticalRulerB = xMiddle + xMiddle / 3;
                var horizontalRulerA = yMiddle - yMiddle / 3;
                var horizontalRulerB = yMiddle + yMiddle / 3;
                const int verticalIncline = 20;
                const int horizontalIncline = 40;
                //Top Polygon
                g.FillPolygon(new SolidBrush(color),
                    new Point[]
                    {
                        new Point(verticalRulerA, 10), new Point(verticalRulerB, 10),
                        new Point(verticalRulerB - verticalIncline, 30), new Point(verticalRulerA + verticalIncline, 30)
                    });
                //Right Polygon
                g.FillPolygon(new SolidBrush(color),
                    new Point[]
                    {
                        new Point(290, horizontalRulerA), new Point(290, horizontalRulerB),
                        new Point(270, horizontalRulerB - horizontalIncline),
                        new Point(270, horizontalRulerA + horizontalIncline)
                    });
                //Bottom Polygon
                g.FillPolygon(new SolidBrush(color),
                    new Point[]
                    {
                        new Point(verticalRulerA, 490), new Point(verticalRulerB, 490),
                        new Point(verticalRulerB - 20, 470), new Point(verticalRulerA + 20, 470)
                    });
                //Left Polygon
                g.FillPolygon(new SolidBrush(color),
                    new Point[]
                    {
                        new Point(10, horizontalRulerA), new Point(10, horizontalRulerB),
                        new Point(30, horizontalRulerB - horizontalIncline),
                        new Point(30, horizontalRulerA + horizontalIncline)
                    });


                var sf = new StringFormat {Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center};

                var topRect = new Rectangle(new Point(xMiddle - 10, 5), new Size(20, 20));
                var bottomRect = new Rectangle(new Point(xMiddle - 10, 475), new Size(20, 20));
                var rightRect = new Rectangle(new Point(275, yMiddle), new Size(20, 20));
                var leftRect = new Rectangle(new Point(5, yMiddle), new Size(20, 20));
                DrawValue(g, topRect, sf, Convert.ToString(stats[0]));
                DrawValue(g, bottomRect, sf, Convert.ToString(stats[1]));
                DrawValue(g, rightRect, sf, Convert.ToString(stats[2]));
                DrawValue(g, leftRect, sf, Convert.ToString(stats[3]));
            }

            bmp.Save(
                $@"C:\Users\bruno.paixao.FARFETCH\Documents\repositories\shenannigans\TripleTriadCustomGenerator\TripleTriadCustomGenerator\Output\{destFilename}.bmp");
        }

        private static void DrawValue(Graphics g, Rectangle rect, StringFormat format, string value)
        {
            g.DrawString(value, new System.Drawing.Font("Tahoma", 16, FontStyle.Bold), Brushes.White, rect,
                format);
        }


        public static Image CreateNonIndexedImage(string path)
        {
            using var sourceImage = Image.FromFile(path);
            var targetImage = new Bitmap(sourceImage.Width, sourceImage.Height,
                PixelFormat.Format32bppArgb);
            using var canvas = Graphics.FromImage(targetImage);
            canvas.DrawImageUnscaled(sourceImage, 0, 0);
            return targetImage;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}