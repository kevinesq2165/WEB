
<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="CRUD.Pages.CRUD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    CRUD de usuarios
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

        .form-control {
            background-color: #343a40;
            color: white;
            border-color: #6c757d;
        }

        .form-control:focus {
            background-color: #343a40;
            color: white;
            border-color: #86b7fe;
        }

        .form-control[readonly] {
            background-color: #252525;
            color: #adb5bd;
            cursor: not-allowed;
        }

        input[type="date"] {
            color-scheme: dark;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <form runat="server">

        <div class="container py-4">

            <div class="mx-auto" style="max-width:600px">

                <asp:Label runat="server"
                    CssClass="h2 d-block text-center mb-4"
                    ID="lbltitulo">
                </asp:Label>

                <div class="bg-dark border border-secondary rounded p-4">

                    <div class="mb-3">
                        <label class="form-label">Nombre</label>
                        <asp:TextBox runat="server"
                            CssClass="form-control"
                            ID="tbnombre">
                        </asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Edad</label>
                        <asp:TextBox runat="server"
                            CssClass="form-control"
                            ID="tbedad">
                        </asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Email</label>
                        <asp:TextBox runat="server"
                            CssClass="form-control"
                            TextMode="Email"
                            ID="tbemail">
                        </asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Fecha de nacimiento</label>
                        <asp:TextBox runat="server"
                            TextMode="Date"
                            CssClass="form-control"
                            ID="tbdate">
                        </asp:TextBox>
                    </div>

                    <div class="d-flex gap-2 justify-content-end mt-4">

                        <asp:Button runat="server"
                            CssClass="btn btn-primary btn-sm"
                            ID="BtnCreate"
                            Text="Create"
                            Visible="false"
                            OnClick="BtnCreate_Click" />

                        <asp:Button runat="server"
                            CssClass="btn btn-warning btn-sm"
                            ID="BtnUpdate"
                            Text="Update"
                            Visible="false"
                            OnClick="BtnUpdate_Click" />

                        <asp:Button runat="server"
                            CssClass="btn btn-danger btn-sm"
                            ID="BtnDelete"
                            Text="Delete"
                            Visible="false"
                            OnClick="BtnDelete_Click"
                            OnClientClick="return confirm('¿Estás seguro de eliminar este usuario?');" />

                        <asp:Button runat="server"
                            CssClass="btn btn-secondary btn-sm"
                            ID="BtnVolver"
                            Text="Volver"
                            Visible="true"
                            CausesValidation="false"
                            OnClick="BtnVolver_Click" />

                    </div>

                </div>

            </div>

        </div>

    </form>

</asp:Content>

