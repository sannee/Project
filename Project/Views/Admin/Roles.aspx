<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Domain.Models.Role>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Список ролей
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
<h2>Список ролей</h2>
<%: Html.ValidationSummary() %>
<p>
    <% if ((bool) Session["CreateEntities"]) %>
    <%
      { %>
    <%: Html.ActionLink("Создать новую роль", "CreateRole") %>
   <% } %>
</p>
<table>
    <tr>
        <th>
            Имя Роли
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.RoleName) %>
        </td>
        <td>
               <% if ((bool) Session["EditEntities"]) %><%
                  { %> <%: Html.ActionLink("Редактировать", "RoleEdit", new {id = item.RoleId}) %><% } %> |

              <% if ((bool) Session["DeleteEntities"]) %> <%
                 { %> <%: Html.ActionLink("Удалить", "RoleDelete", new {id = item.RoleId}) %><% } %>
        </td>
    </tr>
<% } %>
</table>
    <%: Html.ActionLink("На главную", "Index", "Home")%>
</asp:Content>
