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

namespace COMP229_F2016_MidTerm_300886181 {
    public partial class TodoList : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {

                Session["SortColumn"] = "TodoID";
                Session["SortDirection"] = "DESC";

                fillTodos(Convert.ToString(Session["SortColumn"]), Convert.ToString(Session["SortDirection"]));
            }
        }

        private void fillTodos(string col, string ascDesc) {

            using (TodoContext db = new TodoContext()) {

                string SortString = col + " " + ascDesc;

                var Todos = (from _todos in db.Todos select _todos);

                TodosGridView.DataSource = Todos.AsQueryable().OrderBy(SortString).ToList();
                TodosGridView.DataBind();
            }
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e) {

            // pagination (page size, how many rows per page)
            TodosGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            // refresh 
            fillTodos(Convert.ToString(Session["SortColumn"]), Convert.ToString(Session["SortDirection"]));
        }

        protected void TodosGridView_PageIndexChanging(object sender, GridViewPageEventArgs e) {

            // pagination (page index)
            TodosGridView.PageIndex = e.NewPageIndex;

            // refresh 
            fillTodos(Convert.ToString(Session["SortColumn"]), Convert.ToString(Session["SortDirection"]));
        }

        protected void TodosGridView_RowDeleting(object sender, GridViewDeleteEventArgs e) {

            int todoId = Convert.ToInt32(TodosGridView.DataKeys[e.RowIndex].Values["todoId"]);

            using (TodoContext db = new TodoContext()) {

                Todo todoToBeDeleted = (from _todos in db.Todos where _todos.TodoID == todoId select _todos).FirstOrDefault();

                // remove the Todo
                db.Todos.Remove(todoToBeDeleted);

                // save changes
                db.SaveChanges();

                // refresh
                fillTodos(Convert.ToString(Session["SortColumn"]), Convert.ToString(Session["SortDirection"]));
            }

        }



        protected void TodosGridView_Sorting(object sender, GridViewSortEventArgs e) {

            // get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            // refresh 
            fillTodos(Convert.ToString(Session["SortColumn"]), Convert.ToString(Session["SortDirection"]));

            // ascending or descending
            Session["SortDirection"] = Convert.ToString(Session["SortDirection"]) == "ASC" ? "DESC" : "ASC";
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