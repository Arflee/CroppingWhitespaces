using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CroppingWhitespacesForms
{
    public static class BlueprintsGenerator
    {
        public static async Task<Bitmap> GenerateFile(string filename, int offset)
        {
            Image originalImage = Image.FromFile(filename);
            Bitmap original, image, croppedBitmap;

            using (original = new Bitmap(originalImage))
            {
                image = ImageTrim(original);
            }

            using (croppedBitmap = new Bitmap(image.Width + offset * 2, image.Height + offset * 2))
            {
                CopyRegionIntoImage(ref image, new Rectangle(0, 0, image.Width, image.Height),
                                ref croppedBitmap, new Rectangle(offset, offset, image.Width, image.Height));

                image.Dispose();

                var taskEnded = await Task.FromResult(croppedBitmap);
                var copied = (Bitmap)taskEnded.Clone();

                return copied;
            }
        }

        private static Graphics CopyRegionIntoImage(ref Bitmap srcBitmap, Rectangle srcRegion,
                        ref Bitmap destBitmap, Rectangle destRegion)
        {
            using (Graphics grD = Graphics.FromImage(destBitmap))
            {
                grD.FillRectangle(Brushes.White, 0, 0, srcBitmap.Width, srcBitmap.Height);
                grD.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
                return grD;
            }
        }

        public static void DrawCount(Bitmap bitmap, int counter)
        {
            using (var croppedGraphics = Graphics.FromImage(bitmap))
            {
                croppedGraphics.DrawString(counter.ToString(),
                new Font("Arial", 500f),
                new SolidBrush(Color.FromArgb((int)ArgbToLong(63, 126, 126, 126))),
                new PointF(0, 0));

                croppedGraphics.Save();
            }
        }

        private static Bitmap ImageTrim(Bitmap img)
        {
            //get image data
            BitmapData bd = img.LockBits(new Rectangle(Point.Empty, img.Size),
                            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            int[] rgbValues = new int[img.Height * img.Width];
            Marshal.Copy(bd.Scan0, rgbValues, 0, rgbValues.Length);
            img.UnlockBits(bd);

            #region determine bounds
            int left = bd.Width;
            int top = bd.Height;
            int right = 0;
            int bottom = 0;

            //determine top
            for (int i = 0; i < rgbValues.Length; i++)
            {
                int color = rgbValues[i] & 0xffffff;
                if (color != 0xffffff)
                {
                    int r = i / bd.Width;
                    int c = i % bd.Width;

                    if (left > c)
                    {
                        left = c;
                    }
                    if (right < c)
                    {
                        right = c;
                    }

                    bottom = r;
                    top = r;
                    break;
                }
            }

            //determine bottom
            for (int i = rgbValues.Length - 1; i >= 0; i--)
            {
                int color = rgbValues[i] & 0xffffff;
                if (color != 0xffffff)
                {
                    int r = i / bd.Width;
                    int c = i % bd.Width;

                    if (left > c)
                    {
                        left = c;
                    }
                    if (right < c)
                    {
                        right = c;
                    }

                    bottom = r;
                    break;
                }
            }

            if (bottom > top)
            {
                for (int r = top + 1; r < bottom; r++)
                {
                    //determine left
                    for (int c = 0; c < left; c++)
                    {
                        int color = rgbValues[r * bd.Width + c] & 0xffffff;
                        if (color != 0xffffff)
                        {
                            if (left > c)
                            {
                                left = c;
                                break;
                            }
                        }
                    }

                    //determine right
                    for (int c = bd.Width - 1; c > right; c--)
                    {
                        int color = rgbValues[r * bd.Width + c] & 0xffffff;
                        if (color != 0xffffff)
                        {
                            if (right < c)
                            {
                                right = c;
                                break;
                            }
                        }
                    }
                }
            }

            int width = right - left + 1;
            int height = bottom - top + 1;
            #endregion

            //copy image data
            int[] imgData = new int[width * height];
            for (int r = top; r <= bottom; r++)
            {
                Array.Copy(rgbValues, r * bd.Width + left, imgData, (r - top) * width, width);
            }

            GC.Collect();

            //create new image
            Bitmap newImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            BitmapData nbd = newImage.LockBits(new Rectangle(0, 0, width, height),
                                            ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Marshal.Copy(imgData, 0, nbd.Scan0, imgData.Length);
            newImage.UnlockBits(nbd);

            return newImage;
        }

        private static long ArgbToLong(int a, int r, int g, int b)
        {
            new[] { a, r, g, b }.Select((v, i) => new { Name = "argb"[i].ToString(), Value = v }).ToList()
                            .ForEach(arg =>
                            {
                                if (arg.Value > 255 || arg.Value < 0)
                                    throw new ArgumentOutOfRangeException(arg.Name, arg.Name + " must be between or equal to 0-255");
                            });

            long al = (a << 24) & 0xFF000000;
            long rl = (r << 16) & 0x00FF0000;
            long gl = (g << 8) & 0x0000FF00;
            long bl = b & 0x000000FF;
            return al | rl | gl | bl;
        }
    }
}
