<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="COMP229_F2016_MidTerm_300886181.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-offset-4 col-md-4">
                <div class="alert alert-danger" role="alert" id="errorBox" runat="server"></div>

                <h1>User Register</h1>

                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h1 class="panel-title"><i class="fa fa-user-plus fa-lg"></i>Register</h1>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="control-label" for="Username">Username:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="Username" placeholder="Username" required="true" TabIndex="0"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label class="control-label" for="Email">Email:</label>
                            <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" ID="Email" placeholder="Email" required="true" TabIndex="0"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label class="control-label" for="Password">Password:</label>
                            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="Password" placeholder="Password" required="true" TabIndex="0"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label class="control-label" for="PasswordConfirmation">Confirm:</label>
                            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="PasswordConfirmation" placeholder="Confirm Password" required="true" TabIndex="0"></asp:TextBox>
                            <asp:CompareValidator ErrorMessage="Your Passwords Must Match" Type="String" Operator="Equal" ControlToValidate="PasswordConfirmation" runat="server"
                                ControlToCompare="Password" CssClass="label label-danger" />
                        </div>

                        <div class="text-right">
                            <asp:Button Text="Cancel"
                                ID="CancelButton" runat="server"
                                CssClass="btn btn-warning" OnClick="CancelButton_Click"
                                UseSubmitBehavior="false" CausesValidation="false" TabIndex="0" />
                            <asp:Button Text="Register"
                                ID="RegisterButton" runat="server"
                                CssClass="btn btn-primary" OnClick="RegisterButton_Click"
                                TabIndex="0" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
