using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochileitor3DView
{
    class MetodosParaDesenho
    {
        public static void bresenham2(Bitmap imgOrigem, int xi, int xf, int yi, int yf)
        {
            int declive;
            int dx, dy, incE, incNE, d, x, y;
            int auxX, auxY;
            dx = xf - xi;
            dy = yf - yi;

           // BitmapData bitmapDataSrc = imgOrigem.LockBits(new Rectangle(0, 0, imgOrigem.Width, imgOrigem.Height),
            // ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

           // int padding = bitmapDataSrc.Stride - (imgOrigem.Width * 3);

            unsafe
            {
                byte* src;
                try
                {
                    if (Math.Abs(dx) > Math.Abs(dy))
                    {
                        if (xf < xi)
                        {
                            auxX = xf;
                            auxY = yf;

                            xf = xi;
                            xi = auxX;

                            yf = yi;
                            yi = auxY;

                            dx = xf - xi;
                            dy = yf - yi;
                            //bresenham2(imgOrigem, xf, xi, yf, yi);
                            //return;
                        }

                        declive = dy < 0 ? -1 : 1;
                        dy = dy < 0 ? -dy : dy;
                        incE = 2 * dy;
                        incNE = 2 * dy - 2 * dx;
                        d = 2 * dy - dx;
                        y = yi;

                        for (x = xi; x <= xf; x++)
                        {
                            /*
                            src = (byte*)bitmapDataSrc.Scan0.ToPointer() + (3 * imgOrigem.Width + padding) * (y) + ((x) * 3);
                            *(src++) = (byte)255;
                            *(src++) = (byte)255;
                            *(src++) = (byte)255;
                           
                            */
                            imgOrigem.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                            if (d <= 0)
                            {
                                d += incE;
                            }
                            else
                            {
                                d += incNE;
                                y += declive;
                            }
                        }
                    }
                    else
                    {
                        if (yf < yi)
                        {
                            auxX = xf;
                            auxY = yf;

                            xf = xi;
                            xi = auxX;

                            yf = yi;
                            yi = auxY;

                            dx = xf - xi;
                            dy = yf - yi;
                            //bresenham2(imgOrigem, xf, xi, yf, yi);
                            //return;
                        }

                        declive = dx < 0 ? -1 : 1;
                        dx = dx < 0 ? -dx : dx;
                        incE = 2 * dx;
                        incNE = 2 * dx - 2 * dy;
                        d = 2 * dx - dy;
                        x = xi;

                        for (y = yi; y <= yf; y++)
                        {
                            /*
                            src = (byte*)bitmapDataSrc.Scan0.ToPointer() + (3 * imgOrigem.Width + padding) * y + (x * 3);
                            

                            *(src++) = (byte)255;
                            *(src++) = (byte)255;
                            *(src++) = (byte)255;*/

                            imgOrigem.SetPixel(x, y, Color.FromArgb(255, 255, 255));

                            if (d <= 0)
                            {
                                d += incE;
                            }
                            else
                            {
                                d += incNE;
                                x += declive;
                            }
                        }
                    }
                }
                catch (Exception e) { }


            }

            //imgOrigem.UnlockBits(bitmapDataSrc);

        }
    }
}
