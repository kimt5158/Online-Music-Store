<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumAddGUI.aspx.cs" Inherits="SE1438_Group2_Lab4.GUI.AlbumAddGUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 413px;
            margin-left: 40px;
        }
        .auto-style2 {
            width: 413px;
        }
        .auto-style3 {
            width: 80px;
            margin-left: 40px;
        }
        .auto-style4 {
            width: 80px;
        }
        .auto-style5 {
            font-family: "Segoe UI";
            font-weight: bold;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="Label1" runat="server" Text="Add a new album:" CssClass="auto-style5"></asp:Label>
        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="[lblError]" Visible="False"></asp:Label>
        <br />
        <table style="width:100%;">
            <tr>
                <td align="center" class="auto-style3">
                    <asp:Label ID="Label3" runat="server" Text="Title:"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;<asp:TextBox ID="txtTitle" runat="server" Width="230px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="Title required"></asp:RequiredFieldValidator>
                </td>
                <td rowspan="4">
                    <asp:Image ID="Image2" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center" class="auto-style4">
                    <asp:Label ID="Label4" runat="server" Text="Genre:"></asp:Label>
                </td>
                <td class="auto-style2">&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" Width="239px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" class="auto-style3">
                    <asp:Label ID="Label5" runat="server" Text="Artist:"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="239px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" class="auto-style3">
                    <asp:Label ID="Label6" runat="server" Text="Price:"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtPrice" runat="server" Width="230px"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price not less than 0" MaximumValue="999999999999999999999999" MinimumValue="0"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label7" runat="server" Text="AlbumURL:"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtAlbumUrl" runat="server" ReadOnly="True" Width="232px"></asp:TextBox>
                    <asp:Button ID="btnSaveFile" runat="server" OnClick="btnSaveFile_Click" Text="Save image file" />
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" ValidationGroup="1" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
</asp:Content>
