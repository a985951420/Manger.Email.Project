using ComponentFactory.Krypton.Toolkit;
using EamilCrawlerUploadWeb.DB;

namespace Email.Windows
{
    public class BaseForm : KryptonForm
    {
        public BaseForm()
        {
            Db = new SQLiteHelper();
        }

        public SQLiteHelper Db { get; }
    }
}
