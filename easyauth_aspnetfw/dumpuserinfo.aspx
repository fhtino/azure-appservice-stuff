<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dumpuserinfo.aspx.cs" Inherits="web472.dumpuserinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Current user information</h2>
    <br />
    <br />
    <asp:Label ID="LabelInfo" runat="server" Text="Label"></asp:Label>
    <br />
    <br />

    <div>
        X-MS-CLIENT-PRINCIPAL-ID: <%=this.xmsClientPrincialID %>
    </div>

    <div>
        X-MS-CLIENT-PRINCIPAL-IDP: <%=this.xmsClientPrincialIDP %>
    </div>

    <br />
    <br />

    <div>
        X-MS-CLIENT-PRINCIPAL (json):<br />
        <pre><%=this.easyAuthJson2 %></pre>
    </div>

    <div style="overflow-wrap: break-word;">
        X-MS-CLIENT-PRINCIPAL:<br />
        <div style="font-size: smaller;">
            <%=this.xmsClientPrincial %>
        </div>
    </div>

    <br />

</asp:Content>
