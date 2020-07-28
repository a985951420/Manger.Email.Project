using ComponentFactory.Krypton.Toolkit;

namespace Email.Windows.Tools
{
    public class AsyncTextBoxControl : KryptonTextBox
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
    }
}
