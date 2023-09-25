<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFlowers.aspx.cs"MasterPageFile="~/FrontEnd.Master"
    Inherits="NaturalGarden.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>View Flowers</h1>
    <div>
         <asp:GridView ID="grdv" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" OnSorting="OnSorting" OnPageIndexChanging="OnPageIndexChanging" PageSize="5">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="150px" HeaderText="Customer ID" SortExpression="Name">
                        <ItemTemplate>
                               <asp:LinkButton runat="server" ID="lnkbtnDetail" OnClick="lnkbtnDetail_Click" ToolTip='<%# Bind("Id") %>' Text='<%# Bind("Name") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
                    <asp:BoundField DataField="Color" HeaderText="Color" SortExpression="Color"></asp:BoundField>
                     <asp:TemplateField ItemStyle-Width="150px">
                        <ItemTemplate>
                       <asp:LinkButton runat="server" ID="lnkbtndelete" OnClick="lnkbtndelete_Click" ToolTip='<%# Bind("Id") %>'>Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
          </div>
     </asp:Content>