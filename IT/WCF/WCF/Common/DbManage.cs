using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WCF.Common
{
    /// <summary>
    /// 实现单表的增删改查
    /// </summary>
    public class DbManage
    {
        public static DataTable GetDataTable(string sqlstring="", List<dsParams> l_dp = null, DataTable dt = null, CommandType cmdtype = CommandType.Text)
        {
            using (DBUtil du = new DBUtil())
            {
                sqlstring = "select * from JL_USERINFO";
                dt = du.GetTable(sqlstring, l_dp, dt, cmdtype);
            }
            dt.TableName = "userinfo";
            return dt;
        }
    }
    
}