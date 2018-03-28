using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace WCF.Common
{
    /// <summary>
    /// 帮助类，封装一些实用的方法 
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// 把带问号的sql的问号依次替换为@p1 @p2...
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static string ReplaceWithStoreParams(string sqlString)
        {
            StringBuilder sb = new StringBuilder();
            string[] strArray = sqlString.Split('?');
            for (int count = 0; count < strArray.Length - 1; count++)
            {
                sb.Append(strArray[count]);
                sb.Append("@p");
                sb.Append(count);
            }
            //把最后一部分填入
            sb.Append(strArray[strArray.Length - 1]);
            return sb.ToString();
        }
    }
}