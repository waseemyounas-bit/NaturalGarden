<%@ Page Language="C#" CodeBehind="Flowers.aspx.cs" MasterPageFile="~/FrontEnd.Master"
    AutoEventWireup="false"  EnableEventValidation="false"
    Inherits="NaturalGarden.Flowers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div >  
            <table style="width: 100%;align-content:center">
                <caption class="style1">
                    <strong>Rose Form</strong>
                </caption>
                <tr>
                    <td class="style2"></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="style2">Name:</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtUserName" ErrorMessage="Please Enter Your Username"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                   <tr>
                    <td class="style2">Quantity:</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtUserName" ErrorMessage="Please Enter Your Username"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                   <tr>
                    <td class="style2">Price:</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="txtUserName" ErrorMessage="Please Enter Your Username"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="style2">Colour:</td>
                    <td>
                        <asp:TextBox ID="txtColour" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                  <tr>
                    <td class="style2">Suplier:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSupplier" DataSourceID="SdsSupplier" DataTextField="name" DataValueField="Id"></asp:DropDownList>
                        <asp:SqlDataSource runat="server" ID="SdsSupplier" ConnectionString='<%$ ConnectionStrings:NaturalGardenConnectionString %>' SelectCommand="SELECT Id as Id,concat(FirstName,' ',LastName)name FROM Suppliers"></asp:SqlDataSource>
                     
                    </td>
                    <td>
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
                        <asp:Button ID="btn_Login" runat="server" Text="Log In"/>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>  
                <asp:GridView ID="grdv" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" OnPageIndexChanging="grdv_PageIndexChanging1" PageSize="10">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="150px" HeaderText="Customer ID" SortExpression="CustomerID">
                        <ItemTemplate>
                            <%# Eval("SupplierId")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
                    <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:NaturalGardenConnectionString %>' SelectCommand="
select Flowers.SupplierId,Name,Flowers.Quantity,Price,Color from Flowers inner join  Suppliers on Suppliers.Id=Flowers.SupplierId"></asp:SqlDataSource>
        </div>  
 </asp:Content>