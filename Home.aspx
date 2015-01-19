<%@ Page Title="AGV Travels application" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="DsodAsgmnt5._Default" %>
<%@ Register TagPrefix="dateTimeUserControl" TagName="DateTimeUserControl" Src="~/DateTimeUserControl.ascx" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <!-- <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Holiday Destination-Travel Package Booking System</h1>
            </hgroup>
        </div>
    </section> -->
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <dateTimeUserControl:DateTimeUserControl ID="DateTime" runat="server" /> 
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="Button1" runat="server" Height="40px" Text="Login" Width="90px" OnClick="Button1_Click" />
    &nbsp;<asp:Button ID="Button2" runat="server" Height="40px" Text="Register" Width="111px" OnClick="Button2_Click" />
    &nbsp;<asp:Button ID="Button3" runat="server" Height="40px" Text="Service Directory" Width="201px" OnClick="Button3_Click" />
    &nbsp;<asp:Button ID="Button6" runat="server" Height="40px" Text="Logout" Width="90px" OnClick="Button6_Click" />
    </p>
    <p class="auto-style4">
    <p class="auto-style4">
        Hello
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        ,</p>
    <p class="auto-style1">
        <span class="auto-style2" style="line-height: 107%; font-family: &quot;Times New Roman&quot;,serif; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Our system will provide some available information such as </span><span style="font-size:14.0pt;line-height:107%;
font-family:&quot;Times New Roman&quot;,serif;mso-fareast-font-family:Calibri;mso-fareast-theme-font:
minor-latin;mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:
AR-SA"><span class="auto-style2" style="line-height: 107%; font-family: &quot;Times New Roman&quot;,serif; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">latest news, </span></span><span class="auto-style2" style="line-height: 107%; font-family: &quot;Times New Roman&quot;,serif; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">weather forecast, solar and wind intensity and natural hazard index for a given place when &quot;Get info about this place&quot; is clicked. User can decide the holiday destination based on this information of different places and after the user decides the destination, he/she can search for travel options by clicking on the &quot;Travel here&quot; button which will take them to the catalog page where various packages are avaialable for selection and they can also select few add-on services like rent-a-car. Before placing the order, the user must register if they are visiting for the first time, or login as member if they are an existing 
        customer. After they login, they can place the order using their debit/credit card. </span>
    </p>
    <p class="auto-style4">
        Staff can login using the staff login page and are previleged to see the list of orders and registered users in the system. They can view the orders placed by the customers for processing.</p>
    <p class="auto-style4">
        Manager can login using the manager login page. He can view the list of staff and their details. He monitors the staff through his portal. Manager can also login as staff.</p>
    <p class="auto-style4">
        Admin can login through the admin login page and he has the permissions to add/delete the user. staff and manager account. Manager and staff accounts are created by the admin only, they cant self subscribe (register).
    </p>
    <p class="auto-style1">
        <strong>Which Place do you want to Travel?</strong></p>
    <p class="auto-style1">
        &nbsp;<asp:Panel ID ="Panel1" runat="server" DefaultButton="Button5">
                <asp:TextBox ID="TextBox1" runat="server" Width="454px"></asp:TextBox>
&nbsp;
                <asp:Button ID="Button4" runat="server" Height="39px" Text="Travel here" Width="152px" OnClick="Button4_Click" />        
                &nbsp;<asp:Button ID="Button5" runat="server" Height="39px" Text="Get Info about this place" Width="271px" OnClick="Button5_Click" />
            </asp:Panel>

    </p>
    <p class="auto-style5">
        <strong>
        <asp:Label ID="Label5" runat="server" CssClass="auto-style2" Text=""></asp:Label>
        </strong>
    </p>
    <p class="auto-style5">
        &nbsp;<asp:ListBox ID="ListBox2" runat="server" Height="100px" Width="450px" Visible="False"></asp:ListBox>
&nbsp;
        </p>
    <p class="auto-style5">
        <strong>
        <asp:Label ID="Label6" runat="server" CssClass="auto-style2" Text=""></asp:Label>
        </strong>
    </p>
    <p class="auto-style5">
        <asp:ListBox ID="ListBox1" runat="server" Height="218px" Width="800px" Visible="False"></asp:ListBox>
    </p>
    <p class="auto-style5">
        <strong>
        <asp:Label ID="Label7" runat="server" CssClass="auto-style2" Text=""></asp:Label>
&nbsp;</strong><asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </p>
    <p class="auto-style5">
        <strong>
        <asp:Label ID="Label8" runat="server" CssClass="auto-style2" Text=""></asp:Label>
&nbsp;</strong><asp:Label ID="Label3" runat="server" Text=""></asp:Label>
        &nbsp;<asp:Label ID="Label9" runat="server" Text=""></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        &nbsp;<asp:Label ID="Label10" runat="server" Text=""></asp:Label>
    </p>
        <p class="auto-style5">
            <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            text-align: justify;
            font-size: large;
        }
        .auto-style2 {
            font-size: large;
        }
        .auto-style4 {
            text-align: justify;
            font-size: large;
            font-family: "Times New Roman", serif;
        }
        .auto-style5 {
            text-align: justify;
            font-size: medium;
        }
    </style>
</asp:Content>

