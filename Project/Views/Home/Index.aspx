<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Домашняя страница
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewBag.Message %></h2>
    <% if (Session["Username"] != null)
       { %>
    <%: Html.ActionLink("Пользователи", "Index", "Admin") %>
    <br>    
    <%: Html.ActionLink("Роли", "Roles", "Admin") %>
    <% } %>
    <%
       else
       { %>
    <p>
       Авторизируйтесь или зарегистрируйтесь
    </p>
    <% } %>
</asp:Content>
