<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="DsodAsgmnt5.Registration" %>
<%@ Register TagPrefix="dateTimeUserControl" TagName="DateTimeUserControl" Src="~/DateTimeUserControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <dateTimeUserControl:DateTimeUserControl ID="DateTime" runat="server" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" href="http://webstrar13.fulton.asu.edu/page0/Home.aspx">Home</asp:LinkButton>
    <div>
    <table>
    <tr>
        <td>
        <p>
          Username
        </p>
        </td>

        <td>
        <p>
          
            <asp:TextBox ID="Username" runat="server"></asp:TextBox>
          
        </p>
        </td>

    </tr>
    
    <tr>
        <td>
        Password
        </td>

        <td>
        <p>
            

            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            

        </p>
        </td>

    </tr>

    <tr>
        <td>
        Confirm Password
        </td>

        <td>
        <p>
            

            <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            

        </p>
        </td>

    </tr>

    <tr>
        <td>
        <p>
            Email&nbsp;&nbsp;

        </p>
        </td>

        <td>

            <asp:TextBox ID="Email" runat="server"></asp:TextBox>

        </td>

    </tr>

    <tr>
        <td class="auto-style1">
        <p>
        Zip code&nbsp;&nbsp;&nbsp; 

        </p>
        </td>

        <td class="auto-style1">

            <asp:TextBox ID="ZipCode" runat="server"></asp:TextBox>

        </td>

    </tr>
    
    <tr>
        <td class="auto-style1">
        <p>
        Cell number&nbsp;&nbsp;&nbsp; 

        </p>
        </td>

        <td class="auto-style1">

            <asp:TextBox ID="CellNumber" runat="server"></asp:TextBox>

        </td>

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
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </td>
        <td>
            <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" href="Login.aspx">click here</asp:LinkButton>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    </table>
    </div>
</asp:Content>
