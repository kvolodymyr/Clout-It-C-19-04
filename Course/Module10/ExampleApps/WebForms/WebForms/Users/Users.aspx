<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="WebForms.Users.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="studentsGrid" runat="server" 
        ItemType="WebForms.Model.Student" DataKeyNames="StudentID" 
        SelectMethod="studentsGrid_GetData"
        AutoGenerateColumns="false">
        <Columns>
            <asp:DynamicField DataField="StudentID" />
            <asp:DynamicField DataField="LastName" />
            <asp:DynamicField DataField="FirstName" />
            <asp:DynamicField DataField="Year" />          
            <asp:TemplateField HeaderText="Total Credits">
                <ItemTemplate>
                <asp:Label Text="<%# Item.Enrollments.Sum(en => en.Course.Credits) %>" 
                    runat="server" />
                </ItemTemplate>
            </asp:TemplateField>        
        </Columns>
    </asp:GridView>
</asp:Content>


<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="WebForms.Users.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="studentsGrid" runat="server" 
                ItemType="WebForms.Model.Student" DataKeyNames="StudentID" 
                SelectMethod="studentsGrid_GetData"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:DynamicField DataField="StudentID" />
                    <asp:DynamicField DataField="LastName" />
                    <asp:DynamicField DataField="FirstName" />
                    <asp:DynamicField DataField="Year" />          
                    <asp:TemplateField HeaderText="Total Credits">
                      <ItemTemplate>
                        <asp:Label Text="<%# Item.Enrollments.Sum(en => en.Course.Credits) %>" 
                            runat="server" />
                      </ItemTemplate>
                    </asp:TemplateField>        
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>--%>
