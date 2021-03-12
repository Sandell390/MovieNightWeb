<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ActorViewer.aspx.cs" Inherits="MovieNightWeb.ActorViewer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-4">
                <asp:Label CssClass="text-white" Text="" ID="ActorInfo" runat="server" />

            </div>


        </div>

        <div class="row">
            <div>
                <p class="fw-bold text-white mb-4 col-10">Movies: </p>
            </div>
            <asp:Literal ID="ActorMovies" runat="server" />
        </div>

    </div>


</asp:Content>
