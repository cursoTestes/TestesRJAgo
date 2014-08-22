<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DojoInterfaceApplication.Models.RelatorioVendaModel>" %>

<asp:Content ID="relatorioMensalTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Relatorio mensal de vendas
</asp:Content>

<asp:Content ID="relatorioMensalContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Relatorio Mensal</h2>
     
    <% using (Html.BeginForm()) { %>
    <h2><%: ViewData["Message"] %></h2>
        <div>
            <fieldset>
                <legend>Digite o Mes / ano da venda</legend>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ano) %>
                </div>
                <div id="vendedor" class="editor-field">
                    <%: Html.TextBoxFor(m => m.ano) %>
                    <%: Html.ValidationMessageFor(m => m.ano)%>
                </div>
                
                <div class="editor-label" >
                    <%: Html.LabelFor(m => m.mes) %>
                </div>
                <div class="editor-field" id="dataDaVenda">
                    <%: Html.TextBoxFor(m => m.mes)%>
                    <%: Html.ValidationMessageFor(m => m.mes)%>
                </div>
                
                 
                
                <p>
                    <input type="submit" value="RelatorioMensal" />
                </p>
            </fieldset>

       
      </div>
    <% } %>



</asp:Content>
