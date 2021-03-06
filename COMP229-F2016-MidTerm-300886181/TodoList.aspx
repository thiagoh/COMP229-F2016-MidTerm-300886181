﻿<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP229_F2016_MidTerm_300886181.TodoList" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<!--
    TodoList.aspx
    Mid Term test
    Thiago de Andrade Souza 300886181
    Created on 2016-10-19
    Summary: This page lists the todos
-->

    <div class="container">

        <div class="row">

            <div class="col-xs-12 col-md-offset-2 col-md-8">

                <h1>Todo List</h1>

                <br />

                <div class="row">
                    <div class="col-md-8">

                        <a href="TodoDetails.aspx" class="btn btn-success btn-sm">
                            <i class="fa fa-plus"></i>Add Todo
                        </a>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-6 col-md-4">
                        <label for="PageSizeDropDownList">Records per Page:</label>
                        <asp:DropDownList ID="PageSizeDropDownList" runat="server"
                            AutoPostBack="true"
                            CssClass="btn btn-default btn-sm dropdown-toggle"
                            OnSelectedIndexChanged="PageSizeDropDownList_SelectedIndexChanged">
                            <asp:ListItem Text="3" Value="3" />
                            <asp:ListItem Text="5" Value="5" />
                            <asp:ListItem Text="10" Value="10" />
                            <asp:ListItem Text="All" Value="10000" />
                        </asp:DropDownList>

                    </div>
                    <div class="col-xs-6 col-md-4">
                        <div class="text-right">
                            You Have
                    <asp:Label runat="server" ID="TodoCount" Text=""></asp:Label>
                            Todos
                        </div>
                    </div>
                </div>
                <br />
                <asp:GridView ID="TodosGridView" runat="server"
                    AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped table-hover"
                    DataKeyNames="TodoID"
                    AllowPaging="true" PageSize="3" AllowSorting="true"
                    OnRowDeleting="TodosGridView_RowDeleting"
                    OnPageIndexChanging="TodosGridView_PageIndexChanging"
                    OnSorting="TodosGridView_Sorting"
                    OnRowDataBound="TodosGridView_RowDataBound"
                    PagerStyle-CssClass="pagination-ys">
                    <Columns>
                        <asp:BoundField DataField="TodoID" Visible="false" SortExpression="TodoID" />
                        <asp:BoundField DataField="TodoDescription" HeaderText="Todo" Visible="true" SortExpression="TodoDescription" />
                        <asp:BoundField DataField="TodoNotes" HeaderText="Notes" Visible="true" SortExpression="TodoNotes" />

                        <asp:CheckBoxField DataField="Completed"
                            HeaderText="Completed" Visible="true" SortExpression="Completed" />

                        <asp:HyperLinkField runat="server"
                            HeaderText="Edit"
                            Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit"
                            NavigateUrl="~/TodoDetails.aspx.cs"
                            ControlStyle-CssClass="btn btn-primary btn-sm"
                            DataNavigateUrlFields="TodoID"
                            DataNavigateUrlFormatString="TodoDetails.aspx?todoId={0}" />

                        <asp:CommandField runat="server"
                            HeaderText="Delete"
                            DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true"
                            ButtonType="Link"
                            ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>



            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="Scripts" runat="server">
    <script src="/Scripts/todo-list.js"></script>
</asp:Content>
