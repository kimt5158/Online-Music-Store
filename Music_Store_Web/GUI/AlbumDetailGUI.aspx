<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumDetailGUI.aspx.cs" Inherits="SE1438_Group2_Lab4.GUI.AlbumDetailGUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 101px;
        }
        .auto-style2 {
            width: 233px;
        }
        .auto-style3 {
            width: 417px;
        }
        .auto-style4 {
            font-family: "Segoe UI";
            font-weight: bold;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" CssClass="auto-style4" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:Image ID="Image2" runat="server" />
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">Artist:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtArtist" runat="server" ReadOnly="True" Width="230px"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="lblAlbumID" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Genre:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtGenre" runat="server" ReadOnly="True" Width="231px"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Price:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtPrice" runat="server" ReadOnly="True" Width="232px"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="btnAdd" runat="server" Text="Add To Cart" Width="126px" OnClick="btnAdd_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" Width="150px" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
        </table>
    </p>
    <br />
</asp:Content>
