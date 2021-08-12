<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingGUI.aspx.cs" Inherits="SE1438_Group2_Lab4.GUI.ShoppingGUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 287px;
        }
        .auto-style2 {
            width: 729px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style1" style="font-weight: bold">
                    <asp:Label ID="Label1" runat="server" Text="List of genres:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetDataTable" TypeName="Lab3_Template.DAL.GenreDAO"></asp:ObjectDataSource>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSource1" EnableModelValidation="True" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    </asp:GridView>
                </td>
                <td class="auto-style2">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/home-showcase.png" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1" style="font-style: normal; font-weight: bold; font-size: 30px">
                    <asp:Label ID="Label2" runat="server" Text="Albums "></asp:Label>
                    <asp:Label ID="lblGenreName" runat="server" Text="Rock"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" FilterExpression="GenreID = {0}" SelectMethod="GetDataTable" TypeName="Lab3_Template.DAL.AlbumDAO">
                        <FilterParameters>
                            <asp:ControlParameter ControlID="lblGenreID" Name="newparameter" PropertyName="Text" />
                        </FilterParameters>
                    </asp:ObjectDataSource>
                    <asp:Label ID="lblGenreID" runat="server" Text="1" Visible="False"></asp:Label>
                    <br />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView2" runat="server" DataKeyNames="AlbumID" DataSourceID="ObjectDataSource2" EnableModelValidation="True" Width="901px" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound">
                        <Columns>
                            <asp:ButtonField CommandName="Detail" Text="Detail" />
                        </Columns>
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
</asp:Content>
