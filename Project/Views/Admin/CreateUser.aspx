<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Domain.Models.UserViewModel>" %>
<asp:Content ID="Content3" ContentPlaceHolderID="TitleContent" runat="server">
    Register
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
<h2>Учетная запись</h2>
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Создание пользователя</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.UserName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.UserName) %>
            <%: Html.ValidationMessageFor(model => model.UserName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Email) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Email) %>
            <%: Html.ValidationMessageFor(model => model.Email) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Password) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Password) %>
            <%: Html.ValidationMessageFor(model => model.Password) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ConfirmPassword) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ConfirmPassword) %>
            <%: Html.ValidationMessageFor(model => model.ConfirmPassword) %>
        </div>
        
        

    <%  using (Html.BeginForm()) { %>
    <%: Html.LabelFor(x=>x.UserRoles)%>
    <%: Html.DropDownListFor(x => x.RoleId, Model.UserRoles)%>
        <p>
            <input type="submit" value="Создать" />
        </p>
    <%}%>    
    </fieldset>
<% } %>
</asp:Content>