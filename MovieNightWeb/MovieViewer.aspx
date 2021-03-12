<%@ Page Async="true" Title="MovieViewer" MasterPageFile="~/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="MovieViewer.aspx.cs" Inherits="MovieNightWeb.MovieViewer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row float-start">
            <div class="col-4 col-md-4 ">
                <asp:Literal Text="" ID="thumbNail" runat="server" />
            </div>
        </div>




        <div class="row">
            <div class="col-9 text-white mb-5 ms-2">
                <asp:Label Text="" ID="movieTitle" runat="server" />

            </div>

            <div class="col-2 float-end">
                <span class="text-white">Edit Title: </span>
                <asp:TextBox runat="server" ID="editTitle" />
            </div>

            <div class="col-9 text-white mb-5 ms-2">
                <asp:Label Text="" ID="movieYear" runat="server" />
            </div>

            <div class="col-2 float-end">
                <span class="text-white">Edit Year: </span>
                <asp:TextBox TextMode="Number" runat="server" ID="editYear" />
            </div>

            <div class="col-9 ms-2">
                
            </div>
            <asp:Button CssClass="btn btn-secondary col-2 float-end" Text="Send Edit" OnClick="OnClickEdit" ID="editSubmit" runat="server" />

            <div class="col-9 text-white mb-5 ms-2">
                <asp:Label Text="" ID="movieGenre" runat="server" />
            </div>
        </div>

    </div>



    <div class="container-fluid float-start">
        <div class="container">
            <div class="row">
                <div class="col-8 mb-3">
                    <p class="text-capitalize fw-bold text-white">Actors: </p>
                </div>
                <asp:Literal Text="" ID="movieActors" runat="server" />

            </div>
        </div>
    </div>




</asp:Content>
