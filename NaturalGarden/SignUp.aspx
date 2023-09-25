<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="NaturalGarden.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div >  
            <table style="width: 100%;align-content:center">
                <caption class="style1">
                    <strong>Signup Form</strong>
                </caption>
                <tr>
                    <td class="style2"></td>
                    <td></td>
                    <td></td>
                </tr>
                  <tr>
                    <td class="style2">First Name:</td>
                    <td>
                        <asp:TextBox ID="txtbxFirstName" runat="server" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtbxFirstName" ErrorMessage="Please Enter Your First name"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">Last Name:</td>
                    <td>
                        <asp:TextBox ID="txtbxLastName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="txtbxLastName" ErrorMessage="Please Enter Your Last name"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="style2">Email:</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtEmail" ErrorMessage="Please Enter Your Email"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">Password:</td>
                    <td>
                        <asp:TextBox ID="txtPassword"  TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtPassword" ErrorMessage="Please Enter Your  Password"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                    <tr>
                    <td class="style2">Confirm Password:</td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword"  TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ControlToValidate="txtConfirmPassword" ErrorMessage="Please Enter Your Confirm Password"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2"></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="style2"></td>
                    <td>
                        <asp:Button ID="btn_SignUp" runat="server" Text="Sign up" OnClick="btn_SignUp_Click" />
                    </td>
                    <td>
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>  
            <a href="SignUp.aspx">Signup</a>
        </div>  
         </form>
</body>
</html>