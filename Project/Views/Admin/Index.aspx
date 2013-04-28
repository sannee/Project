<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Domain.Models.User>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Cписок пользователей</h2>

<p>
   <% if ((bool) Session["CreateEntities"]) %>
    <%
      { %>
     <%: Html.ActionLink("Создать нового пользователя", "CreateUser") %>
    <% } %>
</p>
<table>
    <tr>
        <th>
            Логин
        </th>
        <th>
            Почта
        </th>
        <th>
            Роль
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Login) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Email) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Role.RoleName) %>
        </td>
        <td>
       <% if ((bool) Session["EditEntities"]) %><%
          { %> <%: Html.ActionLink("Редактировать", "UserEdit", new {id = item.UserId}) %> <% } %>|
       <% if ((bool) Session["DeleteEntities"]) %><%
          { %><%: Html.ActionLink("Удалить", "DeleteUser", new {id = item.UserId}) %> <% } %>
        </td>
    </tr>
<% } %>

</table>
    <%: Html.ActionLink("На главную", "Index", "Home")%>
</asp:Content>
