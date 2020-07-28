namespace Email.Windows.Tools
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class MarqueeLabel : Label
    {
        Timer timer;
        public MarqueeLabel()
        {
            DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// 设置值
        /// </summary>
        public override string Text
        {
            get => base.Text;
            set
            {
                this.CallAsync(() =>
                {
                    base.Text = value;
                });
            }
        }

        int? top;
        int textHeight = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            top -= 3;
            if (top < -textHeight)
                top = Height;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            var s = TextRenderer.MeasureText(Text, Font, new Size(Width, 0),
                TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);
            textHeight = s.Height;
            if (!top.HasValue) top = Height;
            TextRenderer.DrawText(e.Graphics, Text, Font,
                new Rectangle(0, top.Value, Width, textHeight),
                ForeColor, BackColor, TextFormatFlags.TextBoxControl |
                TextFormatFlags.WordBreak);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                timer.Dispose();
            base.Dispose(disposing);
        }

        public new void Show()
        {
            this.CallAsync(() =>
            {
                base.Show();
            });
        }

        public new void Hide()
        {
            this.CallAsync(() =>
            {
                base.Hide();
            });
        }
    }
}
