<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartGUI.aspx.cs" Inherits="SE1438_Group2_Lab4.GUI.CartGUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-family: "Segoe UI";
            font-weight: bold;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Checkout &gt;&gt;" OnClick="Button1_Click" />
    </p>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style1">TOTAL:<b><asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
        </b></span>
    </p>
    <p>
        <asp:ListView ID="ListView1" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged" >
           <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:HyperLink ID="TitleLink" runat="server" Text='Detail' NavigateUrl = '<%# "~/GUI/AlbumDetailGUI.aspx?albumID=" + Eval("AlbumID")%>'/>
                    </td>
                    <td>
                        <asp:Label ID="AlbumIDLabel" runat="server" Text='<%# Eval("albumID") %>' /> 
                    </td>
                    <td>
                        <asp:Label ID="CountLabel" runat="server" Text='<%# Eval("Count") %>' />
                    </td>
                    <td>
                        <asp:Label ID="DateCreatedLabel" runat="server" Text='<%# Eval("DateCreated") %>' />
                    </td>
                    <td>
                        <asp:LinkButton ID="RemoveLink" runat="server" Text="Remove from cart" OnCommand="RemoveLink_Click" CommandArgument='<%# Eval("AlbumID", "{0}") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="1" style="">
                                <tr runat="server" style="">
                                    <th id="Th1" runat="server">
                                        Detail</th>
                                    <th runat="server">
                                        AlbumID</th>
                                    <th runat="server">
                                        Count</th>
                                    <th id="Th3" runat="server">
                                        Date</th>
                                    <th id="Th2" runat="server">
                                        Remove</th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr> 
                            </table>
                        </td>
                    </tr>
                </table>
             </LayoutTemplate>
        </asp:ListView>

        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>
