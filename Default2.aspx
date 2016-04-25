<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="2" cellspacing="2">
            <tr>
                <td align="left" style="width: 200px; border-right: solid 2px #000000; border-bottom: solid 2px #000000;">
                    <table border="0" cellpadding="2" cellspacing="2">
                        <tr>
                            <td align="left">
                                Start Date :<br />
                                <asp:Calendar runat="server" ID="clndStart" OnSelectionChanged="clndStart_SelectionChanged">
                                </asp:Calendar>
                                <br />
                                <asp:TextBox runat="server" ID="txtStartDate" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                End Date :<br />
                                <asp:Calendar runat="server" ID="clndEnd" OnSelectionChanged="clndEnd_SelectionChanged">
                                </asp:Calendar>
                                <br />
                                <asp:TextBox runat="server" ID="txtEndDate" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Recurrence :<br />
                                <asp:RadioButton ID="rbtnRepeated" runat="server" GroupName="repeat" Checked="true"
                                    Text="Repeated" /><br />
                                <asp:DropDownList runat="server" ID="ddlRepeatedFirst">
                                    <asp:ListItem Selected="True" Text="Every" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Every Other" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Every Third" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Every Fourth" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList runat="server" ID="ddlRepeatedSecond">
                                    <asp:ListItem Selected="True" Text="Day" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Week" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="Month" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Year" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:RadioButton ID="rbtnRepeatedOn" runat="server" GroupName="repeat" Text="Repeated On" /><br />
                                <asp:DropDownList runat="server" ID="ddlRepeatedOnFirst">
                                    <asp:ListItem Selected="True" Text="First" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Second" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Third" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Fourth" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList runat="server" ID="ddlRepeatedOnSecond">
                                    <asp:ListItem Text="Sunday" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Monday" Selected="True" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Tuesday" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Wednesday" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Thursday" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Friday" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Saturday" Value="6"></asp:ListItem>
                                </asp:DropDownList>
                                Of the
                                <asp:DropDownList runat="server" ID="ddlRepeatedOnThird">
                                    <asp:ListItem Text="Month" Selected="True" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="3 Month" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4 Month" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="6 Month" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="Year" Value="12"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="left" style="width: 800px; border-bottom: solid 2px #000000;">
                    <asp:DataList runat="server" ID="DLResult" RepeatColumns="6" RepeatDirection="Horizontal">
                        <ItemTemplate>
                            <table border="0">
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="lblMonth" Text='<%# Eval("Month") %>'>
                                        </asp:Label>
                                        <asp:Calendar runat="server" ID="cldnData"></asp:Calendar>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
