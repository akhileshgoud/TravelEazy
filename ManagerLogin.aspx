<%@ Page Title="Manager Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagerLogin.aspx.cs" Inherits="DsodAsgmnt5.ManagerLogin" %>
<%@ Register TagPrefix="dateTimeUserControl" TagName="DateTimeUserControl" Src="~/DateTimeUserControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <dateTimeUserControl:DateTimeUserControl ID="DateTime" runat="server" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" href="http://webstrar13.fulton.asu.edu/page0/Home.aspx">Home</asp:LinkButton>
    <p>
        <strong><span class="auto-style1">Manager Login</span></strong>
    </p>
    <div>
    <table>
    <tr>
        <td>
        <p>
          Username:
        </p>
        </td>

        <td>
        <p>
          
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
          
        </p>
        </td>
        <td></td>
        <td>Sample Username: </td>
        <td>Manager1</td>
    </tr>
    
    <tr>
        <td>
        Password:
        </td>

        <td>
        <p>            
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        </td>
        <td></td>
        <td>Sample Password: </td>
        <td>password</td>
    </tr>
    <tr>
        <td>
            <asp:Image ID="Image1" runat="server" visible="False"/>
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Show me another Captcha" OnClick="Button1_Click" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
        </td>
    </tr>
    <tr> <td> </td> <td> </td> </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    </table>
    </div>
</asp:Content>
