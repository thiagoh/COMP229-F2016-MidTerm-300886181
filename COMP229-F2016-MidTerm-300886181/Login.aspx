﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="COMP229_F2016_MidTerm_300886181.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!--
    Login.aspx
    Mid Term test
    Thiago de Andrade Souza 300886181
    Created on 2016-10-19
    Summary: This is used to login the user
-->
    <div class="container">

        <div class="row">

            <div class="col-md-offset-2 col-md-8">

                <div class="alert alert-danger" role="alert" id="errorBox" runat="server"></div>

                <h1>Login</h1>

                <div class="form-group">
                    <asp:Label Text="Username" AssociatedControlID="UserName" runat="server" />
                    <asp:TextBox
                        ID="UserName"
                        CssClass="form-control"
                        runat="server"
                        required="true"
                        placeholder="Username" />
                </div>
                <div class="form-group">
                    <asp:Label Text="Password" AssociatedControlID="Password" runat="server" />
                    <asp:TextBox
                        ID="Password"
                        TextMode="Password"
                        CssClass="form-control"
                        runat="server"
                        required="true"
                        placeholder="Password" />
                </div>
                <div class="text-right">
                    <asp:Button
                        ID="LoginButton"
                        runat="server"
                        CssClass="btn btn-lg btn-primary"
                        Text="Login"
                        OnClick="LoginButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
