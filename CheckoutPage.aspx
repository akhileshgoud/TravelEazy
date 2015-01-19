<%@ Page Title="Checkout Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutPage.aspx.cs" Inherits="DsodAsgmnt5.CheckoutPage" %>
<%@ Register TagPrefix="dateTimeUserControl" TagName="DateTimeUserControl" Src="~/DateTimeUserControl.ascx" %>
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
        <strong><span class="auto-style1">Checkout Page</span></strong>
    </p>
    <p>
        <span class="auto-style1">
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </span>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </p>
    <p>
        &nbsp;<asp:Label ID="Label4" runat="server" Text="Enter your name: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;<asp:Label ID="Label5" runat="server" Text="Enter your email id: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
    <p>
        &nbsp;<asp:Label ID="Label6" runat="server" Text="Enter your phone number: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>
    <p style="font-weight: 700">
        <asp:Label ID="Label11" runat="server" Text="Payment details:"></asp:Label></p>
    <p>
        &nbsp;<asp:Label ID="Label7" runat="server" Text="Select a card type: "></asp:Label>
&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Visa</asp:ListItem>
            <asp:ListItem>MasterCard</asp:ListItem>
            <asp:ListItem>Discover</asp:ListItem>
            <asp:ListItem>AMEX/DinersClub/JCB</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;<asp:Label ID="Label8" runat="server" Text="Enter card number: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox4" runat="server" Width="365px"></asp:TextBox>
    </p>
    <p>
        &nbsp;<asp:Label ID="Label9" runat="server" Text="Enter CVV number: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox5" runat="server" Width="132px"></asp:TextBox>
    </p>
    <p>
        &nbsp;<asp:Label ID="Label10" runat="server" Text="Enter the expiry date: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" Text="Place Order" OnClick="Button2_Click" />
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
