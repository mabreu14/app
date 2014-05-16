<%@ MasterType VirtualPath="App.master" %>
<%@ Page Language="C#" AutoEventWireup="true" 
Inherits="app.web.ui.views.DepartmentBrowser"
CodeFile="DepartmentBrowser.aspx.cs"
 MasterPageFile="App.master" %>
<%@ Import Namespace="app.web.application.store_browsing" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>            
              <%-- for each department --%>
              <% foreach (var category in this.report)
                 { %>
              <tr class="ListItem">
               <td><a href="#"><%= category.name %></a></td>
           	  </tr>        
              <% } %>
      	    </table>            
</asp:Content>
