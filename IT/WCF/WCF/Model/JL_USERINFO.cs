using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF.Model
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [DataContract]
    public class JL_USERINFO
    {
        #region field
        private string _UserCode;//用户名
        private string _Password;//密码
        #endregion
        
        #region properity
        [DataMember]
        public string UserCode
        {
            get { return _UserCode; }
            set { _UserCode = value; }
        }
        [DataMember]
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        #endregion
        
    }
}