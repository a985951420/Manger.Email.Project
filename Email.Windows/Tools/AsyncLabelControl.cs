using ComponentFactory.Krypton.Toolkit;

namespace Email.Windows.Tools
{
    /// <summary>
    /// 异步处理Text文本
    /// </summary>
    public class AsyncLabelControl : KryptonLabel
    {
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

        /// <summary>
        /// 隐藏显示
        /// </summary>
        public new bool Visible
        {
            get => base.Visible; set
            {
                this.CallAsync(() =>
                {
                    base.Visible = value;
                });
            }
        }
    }
}
