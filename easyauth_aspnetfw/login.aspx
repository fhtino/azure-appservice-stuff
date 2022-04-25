<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="web472.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Login</h2>
    <div>
        <h4>Providers</h4>
        <ul>
            <li><a href="/.auth/login/aad?post_login_redirect_url=<%=ReturnURL%>">Microsoft Identity Platform</a></li>
            <li><a href="/.auth/login/google?post_login_redirect_url=<%=ReturnURL%>">Google</a></li>
            <li><a href="login_fake.aspx?post_login_redirect_url=<%=ReturnURL%>">Local-Fake</a></li>
        </ul>
        <br />
        <br />
    </div>
</asp:Content>
