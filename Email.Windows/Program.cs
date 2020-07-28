using EamilCrawlerUploadWeb.DB;
using System;
using System.Windows.Forms;

namespace Email.Windows
{
    static class Program
    {
        public static string baseFile = Environment.CurrentDirectory.Replace("\\bin\\Debug", string.Empty);
        public static string dbFile = baseFile + "\\db\\email_db.db";
        public static string attachmentPath = baseFile + "\\attachment\\";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            SQLiteHelper.SetConnectionString(dbFile);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
