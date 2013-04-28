<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Session["Username"]!=null) {
%>
        Добро пожаловать, <strong><%: Session["Username"] %></strong>!
        [ <%: Html.ActionLink("Выход", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("Вход", "LogOn", "Account") %> ]
        [ <%: Html.ActionLink("Регистрация", "Register", "Account") %> ]
<%
    }
%>
