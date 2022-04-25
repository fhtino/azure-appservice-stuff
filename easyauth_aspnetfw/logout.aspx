<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="logout.aspx.cs" Inherits="web472.logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Logout</h2>
    <br />    
    <asp:Button ID="ButtonLogout" runat="server" Text="'Light' Logout" OnClick="ButtonLogout_Click" Font-Size="Larger" />
    <br />
    <br />
    <br />
    <a href="/.auth/logout">'Strong' EasyAuth logout</a><br />
    <br />
    <br />
</asp:Content>
