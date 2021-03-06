﻿using System;
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

/*
    TodoDetails.aspx.cs
    Mid Term test
    Thiago de Andrade Souza 300886181
    Created on 2016-10-19
    Summary: This is the CRUD of todo details
 */

namespace COMP229_F2016_MidTerm_300886181 {
    public partial class TodoDetails : System.Web.UI.Page {

        public Todo todo { get; set; }

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {

                if (Request.QueryString.Count > 0) {
                    setTodo();
                }
            }
        }

        private void setTodo() {
            int todoId = Convert.ToInt32(Request.QueryString["todoId"]);

            using (TodoContext db = new TodoContext()) {

                var todo = (from _todo in db.Todos
                            where _todo.TodoID == todoId
                            select _todo).FirstOrDefault();

                if (todo != null) {

                    TodoName.Text= todo.TodoDescription;
                    TodoNotes.Text= todo.TodoNotes;
                    TodoCompleted.Checked = todo.Completed;
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e) {

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.FindById(HttpContext.Current.User.Identity.GetUserId());

            using (TodoContext db = new TodoContext()) {

                int todoId = Convert.ToInt32(Request.QueryString["todoId"]);

                Todo todo = null;

                if (todoId == 0) {
                    todo = new Todo();
                    db.Todos.Add(todo);

                } else {
                    todo = (from _todo in db.Todos where _todo.TodoID == todoId select _todo).FirstOrDefault();
                }

                if (todo != null) {

                    todo.TodoNotes = TodoNotes.Text;
                    todo.TodoDescription = TodoName.Text;
                    todo.Completed = TodoCompleted.Checked;
                }

                todo.TodoUserEmail = user.Email;

                // save the todo
                db.SaveChanges();

                Response.Redirect("~/TodoList.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e) {
            Response.Redirect("~/TodoList.aspx");
        }
    }
}