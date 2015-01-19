<%@ Page Title="Add-on Car Rental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarDeals.aspx.cs" Inherits="DsodAsgmnt5.CarDeals" %>
<%@ Register TagPrefix="dateTimeUserControl" TagName="DateTimeUserControl" Src="~/DateTimeUserControl.ascx" %>
<%@ Register TagPrefix = "cart" TagName="ViewCart" src="~/ViewCart.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <dateTimeUserControl:DateTimeUserControl ID="DateTime" runat="server" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" href="http://webstrar13.fulton.asu.edu/page0/Home.aspx">Home</asp:LinkButton>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Logout" Height="40px" Width="112px" OnClick="Button1_Click" />
    <p>
        <span class="auto-style1">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </span>
    </p>
    Deals for provided details:
    <p>
        <asp:Label ID="Label2" runat="server" Text =""></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click1" Text="Go To My Cart" /><cart:viewcart id="viewcart1" runat="server" />
    </p>
    <p>
        <asp:Table ID="Table1" runat="server" style="margin:0 auto" BorderStyle="solid" BorderWidth="5" GridLines="both" Height="21px" Width="408px">
        </asp:Table>
    </p>
</asp:Content>