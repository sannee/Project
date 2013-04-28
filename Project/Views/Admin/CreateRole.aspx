<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
 Новая роль
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Редактирование роли</h2>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Создание Роли</legend>
        <div class="editor-field">
             <%: Html.Label("Имя роли:")%>
             <%: Html.Editor("RoleName")%>
            <input type="submit"value="Создать">
        </div>
     </fieldset>
<% }%>
    
</asp:Content>
