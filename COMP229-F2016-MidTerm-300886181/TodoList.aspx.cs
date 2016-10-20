using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Diagnostics;
using COMP229_F2016_MidTerm_300886181.Models;
using System.Collections;
using System.Linq.Dynamic;

/*
    TodoList.aspx.cs
    Mid Term test
    Thiago de Andrade Souza 300886181
    Created on 2016-10-19
    Summary: This page lists the todos
 */

namespace COMP229_F2016_MidTerm_300886181 {
    public partial class TodoList : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {

                Session["SortColumn"] = "TodoID";
                Session["SortDirection"] = "DESC";

                TodosGridView.PageSize = getPageSize();

                fillTodos(getSortColumn(), getSortDirection());
            }
        }

        private int getPageSize() {

            int pageSize = 0;

            if (Session["PageSize"] == null || Session["PageSize"].ToString().Trim() == "") {
                pageSize = 3;
            }else {
                pageSize = Convert.ToInt32(Session["PageSize"]);
            }

            pageSize = Math.Min(3, pageSize);

            return pageSize;
        }

        private void fillTodos(string col, string ascDesc) {

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.FindById(HttpContext.Current.User.Identity.GetUserId());

            using (TodoContext db = new TodoContext()) {

                string SortString = col + " " + ascDesc;

                var todos = (from _todos in db.Todos where _todos.TodoUserEmail == user.Email select _todos);

                TodoCount.Text = Convert.ToString(todos.AsQueryable().Count());

                TodosGridView.DataSource = todos.AsQueryable().OrderBy(SortString).ToList();
                TodosGridView.DataBind();
            }
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e) {

            // pagination (page size, how many rows per page)
            TodosGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);
            Session["PageSize"] = PageSizeDropDownList.SelectedValue;

            // refresh 
            fillTodos(getSortColumn(), getSortDirection());
        }

        protected void TodosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e) {

            // pagination (page index)
            TodosGridView.PageIndex = e.NewPageIndex;

            // refresh 
            fillTodos(getSortColumn(), getSortDirection());
        }

        private string getSortColumn() {
            return Convert.ToString(Session["SortColumn"] + "");
        }
        private string getSortDirection() {
            return Convert.ToString(Session["SortDirection"] + "");
        }

        protected void TodosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e) {

            int todoId = Convert.ToInt32(TodosGridView.DataKeys[e.RowIndex].Values["TodoID"]);

            using (TodoContext db = new TodoContext()) {

                Todo todoToBeDeleted = (from _todos in db.Todos where _todos.TodoID == todoId select _todos).FirstOrDefault();

                if (todoToBeDeleted == null) {
                    throw new Exception("TODO not found!");
                }

                // remove the Todo
                db.Todos.Remove(todoToBeDeleted);

                // save changes
                db.SaveChanges();

                // refresh
                fillTodos(Convert.ToString(Session["SortColumn"]), getSortDirection());
            }
        }

        protected void TodosGridView_Sorting(object sender, GridViewSortEventArgs e) {

            // get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            // refresh 
            fillTodos(Convert.ToString(Session["SortColumn"]), getSortDirection());

            // ascending or descending
            Session["SortDirection"] = getSortDirection() == "ASC" ? "DESC" : "ASC";
        }

        protected void TodosGridView_RowDataBound(object sender, GridViewRowEventArgs e) {

            if (!IsPostBack) {
                return;
            }

            if (e.Row.RowType == DataControlRowType.Header) {

                LinkButton linkbutton = new LinkButton();

                for (int index = 0; index < TodosGridView.Columns.Count - 1; index++) {

                    if (TodosGridView.Columns[index].SortExpression == Session["SortColumn"].ToString()) {

                        linkbutton.Text = " <i class='fa fa-caret-" + (Session["SortDirection"].ToString() == "ASC" ? "up" : "down") + " fa-lg'></i>";
                        e.Row.Cells[index].Controls.Add(linkbutton);
                    }
                }
            }
        }
    }
}