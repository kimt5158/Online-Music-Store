<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutGUI.aspx.cs" Inherits="SE1438_Group2_Lab4.GUI.CheckoutGUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 123px;
        }
        .auto-style2 {
            width: 212px;
            margin-left: 40px;
            height: 29px;
        }
        .auto-style3 {
            width: 212px;
        }
        .auto-style4 {
            width: 123px;
            height: 29px;
        }
        .auto-style5 {
            height: 29px;
        }
        .auto-style6 {
            width: 212px;
            height: 29px;
        }
        .auto-style7 {
            font-family: "Segoe UI";
            font-weight: bold;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <span class="auto-style7">Shipping information:</span>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style4">Order date:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtDate" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style1">User name:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtUSer" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">First name:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First name Required!" ControlToValidate="txtFName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Last name:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last name Required!" ControlToValidate="txtLName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Address:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">City:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">State:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Country:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Phone:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Email:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email Required!" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Total:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Promocode:</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtPro" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="btnOrder" runat="server" Text="Order" OnClick="btnOrder_Click" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" ValidationGroup="1" OnClick="btnCancel_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
</asp:Content>
