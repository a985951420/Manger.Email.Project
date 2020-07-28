using System.Windows.Forms;

namespace Email.Windows.Tools
{
    public class AsyncProgressBarControl : ProgressBar
    {
        /// <summary>
        /// 赋值Value
        /// </summary>
        public new int Value
        {
            get => base.Value; set
            {
                this.CallAsync(() =>
                {
                    base.Value = value;
                });
            }
        }

        /// <summary>
        /// 设置最大值
        /// </summary>
        public new int Maximum
        {
            get => base.Maximum; set
            {
                this.CallAsync(() =>
                {
                    base.Maximum = value;
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
