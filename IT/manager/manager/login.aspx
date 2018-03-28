<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="manager.login" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <link href="resource/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <title>后台管理</title>
</head>
<body>
    <%--页面依赖 Ext.Net. ResourceManager 控件初始化其资源，将 CSS 和脚本的引用和内容加入到页面--%>
    <ext:ResourceManager ID="resourceManager1" runat="server" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Region="Center">
                <Content>
                    <form role="form" action="" method="post">
                    <div class="form-group">
                        <label class="sr-only" for="form-username">
                            用户名</label>
                        <input type="text" name="form-username" placeholder="用户名" class="form-control" id="form-username">
                    </div>
                    <div class="form-group">
                        <label class="sr-only" for="form-password">
                            密码</label>
                        <input type="password" name="form-password" placeholder="密码" class="form-control"
                            id="form-password">
                    </div>
                    <button type="button" class="btn col-md-12 btn-primary" id="btnLogin" onclick="loginClick()">
                            登录</button>
                    </form>
                </Content>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</body>
<script src="resource/scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
</html>
