using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using WCF.Common;

/*
创建数据库连接 
*/
public sealed class DBUtil : IDisposable
{
    private SqlConnection Sqlcon;//数据库连接对象
    private string ConnectString;//连接字符串
    //构造函数
    public DBUtil(string _ConnectString = null)
    {
        try
        {
            //读取配置文件中的连接字符串
            ConnectString = _ConnectString == null ? ConfigurationManager.AppSettings["DbConnectionString"] : _ConnectString;
            Sqlcon = new SqlConnection(ConnectString);
            Sqlcon.Open();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    //可带参sql语句查询，存储过程查询
    public DataTable GetTable(string sqlstring, List<dsParams> l_dp = null, DataTable dt = null, CommandType cmdtype = CommandType.Text)
    {
        try
        {
            if (dt == null)
            {
                dt = new DataTable();
            }
            sqlstring = Helper.ReplaceWithStoreParams(sqlstring);
            using (SqlCommand Sqlcmd = new SqlCommand(sqlstring, Sqlcon))
            {
                Sqlcmd.CommandType = cmdtype;
                if (l_dp != null)
                {
                    if (cmdtype == CommandType.StoredProcedure) //为执行存储过程传入参数做更改
                    {
                        for (int count = 0; count < l_dp.Count; count++)
                        {
                            Sqlcmd.Parameters.AddWithValue(l_dp[count].paramsname, l_dp[count].paramsvalue);
                        }
                    }
                    else
                    {
                        for (int count = 0; count < l_dp.Count; count++)
                        {
                            if (l_dp[count].paramsvalue == null)
                                l_dp[count].paramsvalue = System.DBNull.Value;
                            Sqlcmd.Parameters.AddWithValue("@p" + count.ToString(), l_dp[count].paramsvalue);
                        }
                    }
                }
                using (SqlDataAdapter adt = new SqlDataAdapter(Sqlcmd))
                {
                    adt.Fill(dt);
                    return dt;
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception("SQL : " + sqlstring + " | " + ExPrompt(e, sqlstring));
        }
    }
    //翻译返回异常提示
    public string ExPrompt(Exception ex, string sql = null)
    {
        if (sql != null)
        {
            if (sql.Replace(" ", "").IndexOf(",where") > 0)
            {
                return "SQL语句中where前面出现逗号，请检查语法";
            }
        }
        if (ex.Message.IndexOf("XF_VIPGRADE_UK1") > 0)
        {
            return "该顺序号已存在或曾经使用并删除";
        }
        else if (ex.Message.IndexOf("违反唯一约束") > 0)
        {
            return "该编号已存在或曾经使用并删除";
        }
        return ex.Message;
    }

    #region 关闭数据库连接--使用IDisposable接口和析构函数
    public void Dispose()
    {
        DBUtilClose();
    }

    ~DBUtil()
    {
        DBUtilClose();
    }

    public void DBUtilClose()
    {
        if (Sqlcon != null)
        {
            if (Sqlcon.State != ConnectionState.Closed)
            {
                try
                {
                    Sqlcon.Close();
                }
                catch
                {
                    Sqlcon.Dispose();
                }
            }
            Sqlcon.Dispose();
        }
    }
    #endregion
    
}
//查询参数键值对
public class dsParams
{
    public dsParams(string _paramsname, object _paramsvalue)
    {
        paramsname = _paramsname;
        paramsvalue = _paramsvalue;
    }

    public string paramsname = string.Empty;
    public object paramsvalue = null;
}
