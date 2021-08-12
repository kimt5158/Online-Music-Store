<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportGUI.aspx.cs" Inherits="Lab4_template.GUI.ReportGUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 290px;
        }
        .auto-style3 {
            width: 365px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">Order date:<asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" SelectionMode="DayWeekMonth"></asp:Calendar>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="From:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtFrom" runat="server" Width="217px" Height="16px" Enabled="False" ReadOnly="True"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="To:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtTo" runat="server" Width="217px" Enabled="False" ReadOnly="True"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="FirstName:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtFirstName" runat="server" Width="218px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Country:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtCountry" runat="server" Width="217px"></asp:TextBox>
                </td>
                <td>
                    <br />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFrom" ErrorMessage="Time Required"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTo" ErrorMessage="Time Required"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="Button1_Click" Height="23px" Width="173px"/>
                </td>
            </tr>
        </table>
        The number of orders:
        <asp:Label ID="lblNoOrders" runat="server" Text="0"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" EnableModelValidation="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowSorting="True" AllowPaging="True" BorderColor="#3366CC" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetDataTable" TypeName="Lab3_Template.DAL.OrderDAO"></asp:ObjectDataSource>
    </p>
    <p>
        The number of order details:
        <asp:Label ID="lblNoOrderDetails" runat="server" Text="0"></asp:Label>
    </p>
    <asp:GridView ID="GridView2" runat="server" DataSourceID="ObjectDataSource2" EnableModelValidation="True" AllowPaging="True" BorderColor="#3366CC" BackColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="4" Visible="False">
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetDataTable" TypeName="Lab3_Template.DAL.OrderDetailDAO"></asp:ObjectDataSource>
    <br />
</asp:Content>
