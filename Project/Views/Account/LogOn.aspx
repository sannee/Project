<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Domain.Models.LogOnModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    LogOn
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Вход в учетную запись</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Авторизация</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.UserName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.UserName) %>
            <%: Html.ValidationMessageFor(model => model.UserName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Password) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Password) %>
            <%: Html.ValidationMessageFor(model => model.Password) %>
        </div>
        <p>
            <input type="submit" value="Вход" />
        </p>
    </fieldset>
<% } %>
</asp:Content>
