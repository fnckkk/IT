﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Model;
using WCF.Common;
using System.Data;

namespace WCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        public DataTable GetUserInfo()
        {
            return DbManage.GetDataTable();
        }

    }
}
