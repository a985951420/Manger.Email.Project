using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Email.Windows.Tools
{
    public static class AsyncTool
    {
        /// <summary>
        /// 异步使用控件
        /// </summary>
        /// <typeparam name="TControl"></typeparam>
        /// <param name="control"></param>
        /// <param name="action"></param>
        public static void CallAsync<TControl>(this TControl control, Action action) where TControl : Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(() => action()));
                return;
            }
            action();
        }
    }
}
