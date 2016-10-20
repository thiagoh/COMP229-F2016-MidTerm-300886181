<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP229_F2016_MidTerm_300886181.TodoDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<!--
    TodoDetails.aspx
    Mid Term test
    Thiago de Andrade Souza 300886181
    Created on 2016-10-19
    Summary: This is the CRUD of todo details
-->

    <div class="container">

        <div class="row">

            <div class="col-md-offset-2 col-md-8">

                <h1>Todo Details</h1>

                <div class="form-group">
                    <asp:Label Text="Todo Name" AssociatedControlID="TodoName" runat="server" />
                    <asp:TextBox 
                        ID="TodoName" 
                        CssClass="form-control" 
                        runat="server" 
                        required="true"
                        placeholder="Todo" />
                </div>
                <div class="form-group">
                    <asp:Label Text="Todo Notes" AssociatedControlID="TodoNotes" runat="server" />
                    <asp:TextBox 
                        ID="TodoNotes" 
                        CssClass="form-control" 
                        runat="server" 
                        placeholder="Notes" />
                </div>
                <div class="checkbox">
                    <label>
                        <asp:CheckBox ID="TodoCompleted" runat="server" Text="Completed" />
                    </label>
                </div>
                <div class="text-right">
                    <asp:Button 
                        ID="CancelButton" 
                        runat="server" 
                        CssClass="btn btn-lg btn-warning" 
                        Text="Cancel" 
                        UseSubmitBehavior="false" 
                        CausesValidation="false"
                        OnClick="CancelButton_Click" />
                    <asp:Button 
                        ID="SaveButton" 
                        runat="server" 
                        CssClass="btn btn-lg btn-primary" 
                        Text="Save" 
                        OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Scripts" runat="server">
    <script src="/Scripts/todo-details.js"></script>
</asp:Content>
