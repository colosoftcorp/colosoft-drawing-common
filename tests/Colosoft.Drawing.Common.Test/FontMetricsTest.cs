namespace Colosoft.Drawing.Common.Test
{
    public class FontMetricsTest
    {
        [Fact]
        public void GiveArialFontValidateMetrics()
        {
            var font = new Font("Arial", FontOptions.None, 16, FontStyle.Normal);

            var provider = new FontMetricsProvider();
            var metrics = provider.GetMetrics(font);

            Assert.Equal(14.484375, metrics.Ascent);
            Assert.Equal(3.390625, metrics.Descent);
            Assert.Equal(18.4, Math.Round(metrics.Height, 2));
        }
    }
}