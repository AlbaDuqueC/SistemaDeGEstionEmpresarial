<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HolaMundo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        
            <h1 id="aspnetTitle">BOTON QUE SALUDA</h1>
        
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="AAAAAAAAAAAAAAAAAAAAAAAA" OnClick="Button1_Click" />
            
            
        
    </main>

</asp:Content>
