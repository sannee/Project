<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Domain.Models.RoleViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Редактирование роли
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Редактирование роли</h2>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Роль</legend>
        <div class="editor-field">
           <%: Html.EditorFor(model => model.PermissionBrowse) %>
            <%: Html.LabelFor(model => model.PermissionBrowse) %>
            <%: Html.ValidationMessageFor(model => model.PermissionBrowse) %>
        </div>

        <div class="editor-field">
            <%: Html.EditorFor(model => model.PermissionEdit) %>
            <%: Html.LabelFor(model => model.PermissionEdit) %>
            <%: Html.ValidationMessageFor(model => model.PermissionEdit) %>
        </div>

        <div class="editor-field">
            <%: Html.EditorFor(model => model.PermissionDelete) %>
            <%: Html.LabelFor(model => model.PermissionDelete) %>
            <%: Html.ValidationMessageFor(model => model.PermissionDelete) %>
        </div>

   <div class="editor-field">
      <div class="editor-label">
           Доступ запрещен к:
        </div>

<table>
 <tr>
        <th>
        Action
        </th>
        <th>
        Controller
        </th>
        <th></th>
</tr>
  <%if (Model.PermissionPaths.Count==0) 
    {%>
    <tr>
        <td>
            Пусто
      </td>

        <td>
       Пусто
        </td>    
    <%}%> 
<% foreach (var item in Model.PermissionPaths) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Action) %>
        </td>

        <td>
            <%: Html.DisplayFor(modelItem => item.Controller) %>
        </td>

        <td>
            <%: Html.ActionLink("Удалить", "PathDelete", new { id=item.Id, RoleId=Model.RoleId }) %>

        </td>
    </tr>
<% } %>    
</table>
        </div>
 <input type="hidden" name="RoleId" value="<%:Model.RoleId %>" />
        <p>
            <input type="submit" value="Сохранить" />
        </p>
    </fieldset>
<% } %>
    <form method="POST" action="/Admin/PathAdd">
<fieldset>
<legend>Запретить доступ к странице</legend>
<table>
     <tr>
        <th>
        Action
        </th>
        <th>
        Controller
        </th>
        <th></th>
</tr>

    <tr>
        <td>
      <input type="text" name="Action" value="" />
        </td>
       <td>
      <input type="text" name="Controller" value="" />
        </td>
        <td>
      <input type="submit" value="Добавить" />
      <input type="hidden" name="RoleId" value="<%:Model.RoleId %>" />
        </td>
    </tr>
    </table>
            </fieldset>
</form>
</asp:Content>
