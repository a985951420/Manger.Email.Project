using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Email.Windows.Tools
{
    /// <summary>
    /// 自定义编辑器
    /// </summary>
    [ComVisible(true)]
    public class HTMLEditor : WebBrowser
    {
        public HTMLEditor()
        {
            //初始化读取模版
            this.Url = new Uri(Program.baseFile + "\\editor\\editor.html");
            this.ObjectForScripting = this;//加载js,必须给当前类加ComVisible 属性,确保对com可见
        }

        /// <summary>
        /// 内容
        /// </summary>
        /// <returns></returns>
        public string GetHtml()
        {
            return (string)this.Document.InvokeScript("getContent");
        }

        public void SetContent(string html)
        {
            this.Document.InvokeScript("setContent", new object[] { html });
        }
    }
}
