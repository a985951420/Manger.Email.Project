using System;

namespace Email.Windows.Tools
{
    public static class Ensure
    {
        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="value">对象</param>
        public static void IsNull(object value)
        {
            if (value == null)
                throw new ArgumentNullException("值不能为空！");
        }
    }
}
