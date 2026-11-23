
<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CRUD.Pages.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #121212;
            color: white;
        }

        .navbar {
            background-color: #212529 !important;
        }

        .navbar-brand {
            color: white !important;
        }

        .navbar .form-control {
            background-color: #343a40;
            color: white;
            border-color: #6c757d;
        }

        .navbar .form-control::placeholder {
            color: #adb5bd;
        }

        .table th, .table td {
            vertical-align: middle;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">

        <div class="container py-4">

            <h2 class="text-center mb-4">Listado de registros</h2>

            <div class="d-flex justify-content-end mb-3">
                <asp:Button runat="server"
                    ID="BtnCreate"
                    CssClass="btn btn-success btn-sm"
                    Text="Create"
                    OnClick="BtnCreate_Click" />
            </div>

            <div class="table-responsive">

                <asp:GridView runat="server"
                    ID="gvusuarios"
                    CssClass="table table-dark table-bordered table-hover text-center"
                    AutoGenerateColumns="true"
                    DataKeyNames="Id_Usuario">

                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del administrador">
                            <ItemTemplate>

                                <asp:Button runat="server"
                                    Text="Read"
                                    CssClass="btn btn-info btn-sm"
                                    ID="BtnRead"
                                    OnClick="BtnRead_Click" />

                                <asp:Button runat="server"
                                    Text="Update"
                                    CssClass="btn btn-warning btn-sm"
                                    ID="BtnUpdate"
                                    OnClick="BtnUpdate_Click" />

                                <asp:Button runat="server"
                                    Text="Delete"
                                    CssClass="btn btn-danger btn-sm"
                                    ID="BtnDelete"
                                    OnClick="BtnDelete_Click" />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>

            </div>
        </div>

    </form>
</asp:Content>


