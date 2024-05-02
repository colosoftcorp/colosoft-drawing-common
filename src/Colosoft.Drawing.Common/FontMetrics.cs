using System;
using System.Drawing;

namespace Colosoft.Drawing.Common
{
    internal class FontMetrics : IFontMetrics
    {
        private static readonly Graphics InnerGraphics = Graphics.FromImage(new Bitmap(1, 1));
        private readonly System.Drawing.Font font;

        public FontMetrics(System.Drawing.Font font)
        {
            this.font = font;
        }

        public double Height => this.font.GetHeight(InnerGraphics);

        public double InternalLeading => 0;

        public double Baseline => this.Height - this.Ascent;

        public double LineSpacing =>
            this.font.Size * this.font.FontFamily.GetLineSpacing(this.font.Style) / this.font.FontFamily.GetEmHeight(this.font.Style);

        public double Ascent =>
            this.font.Size * this.font.FontFamily.GetCellAscent(this.font.Style) / this.font.FontFamily.GetEmHeight(this.font.Style);

        public double Descent =>
            this.font.Size * this.font.FontFamily.GetCellDescent(this.font.Style) / this.font.FontFamily.GetEmHeight(this.font.Style);

        public double StringWidth(string s, int startIndex, int length)
        {
            if (s is null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            var text = s.Substring(startIndex, length);
            var size = InnerGraphics.MeasureString(text, this.font);

            return size.Width;
        }
    }
}
