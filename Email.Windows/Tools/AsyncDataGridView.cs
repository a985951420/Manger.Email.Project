using System.Windows.Forms;

namespace Email.Windows.Tools
{
    public class AsyncDataGridView : DataGridView
    {
        public AsyncDataGridView()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
        public new DataGridViewRowCollection Rows
        {
            get
            {
                return base.Rows;
            }
        }

        /// <summary>
        /// 清除选中
        /// </summary>
        public new void ClearSelection()
        {
            this.CallAsync(() =>
            {
                base.ClearSelection();
            });
        }
    }
}
