using System;

namespace Colosoft.Drawing.Common
{
    public class FontMetricsProvider : IFontMetricsProvider
    {
        public IFontMetrics GetMetrics(Font font)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }

            var font2 = new System.Drawing.Font(font.FontFamily, (float)font.Size, this.GetFontStyle(font), System.Drawing.GraphicsUnit.Pixel);

            return new FontMetrics(font2);
        }

        private System.Drawing.FontStyle GetFontStyle(Font font)
        {
            System.Drawing.FontStyle style;

            switch (font.Style)
            {
                case FontStyle.Italic:
                    style = System.Drawing.FontStyle.Italic;
                    break;
                case FontStyle.Oblique:
                    style = System.Drawing.FontStyle.Regular;
                    break;
                default:
                    style = System.Drawing.FontStyle.Regular;
                    break;
            }

            if (font.IsBold)
            {
                style |= System.Drawing.FontStyle.Bold;
            }

            return style;
        }
    }
}
