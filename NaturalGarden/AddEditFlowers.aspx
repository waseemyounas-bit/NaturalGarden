<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditFlowers.aspx.cs" MasterPageFile="~/FrontEnd.Master"
    EnableEventValidation="false" Inherits="NaturalGarden.AddEditFlowers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Add Flowers</h1>
    <div>
              <table style="width: 100%;align-content:center">
                <caption class="style1">
                    <strong>Rose Form</strong>
                </caption>
                <tr>
                    <td>Name:</td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqFvName" runat="server"
                            ControlToValidate="txtname" ErrorMessage="Please Enter  Name"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                   <tr>
                    <td>Quantity:</td>
                    <td>
                        <asp:TextBox ID="txtQuantity" runat="server"  TextMode="Number" placeholder="Quantity"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="ReqFvQuantity" runat="server"
                            ControlToValidate="txtQuantity" ErrorMessage="Please Enter  Quantity"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                   <tr>
                    <td>Price:</td>
                    <td>
                        <asp:TextBox ID="txtbxPrice" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrice"  runat="server" placeholder="Price"
                            ControlToValidate="txtQuantity" ErrorMessage="Please Enter  Price"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                     <%--   <asp:RangeValidator runat="server" ID="RangeValidatorPrice"   ControlToValidate="txtbxPrice" ErrorMessage="Please Enter  Price"
                            ForeColor="Red" MinimumValue="1"></asp:RangeValidator>--%>
                    </td>
                </tr>
                 <tr>
                    <td>Colour:</td>
                    <td>
                        <asp:TextBox ID="txtColour" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorColour"  runat="server" placeholder="Colour"
                            ControlToValidate="txtColour" ErrorMessage="Please Enter  Colour"
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                    </td>
                </tr>
                  <tr>
                    <td>Suplier:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSupplier" DataSourceID="SdsSupplier" DataTextField="name" DataValueField="Id">
                            <asp:ListItem Value="0">Please Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource runat="server" ID="SdsSupplier" ConnectionString='<%$ ConnectionStrings:NaturalGardenConnectionString %>' SelectCommand="SELECT Id as Id,concat(FirstName,' ',LastName)name FROM Suppliers where Id=@Id">
                            <SelectParameters>
                                <asp:SessionParameter SessionField="SupplierId" Name="Id"></asp:SessionParameter>
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btn_Save" runat="server" Text="Save"  OnClick="btn_Save_Click1" />
                    </td>
                    <td>
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>  
       
          </div>
     </asp:Content>