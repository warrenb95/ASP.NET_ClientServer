using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP.NET_ClientServer.Models;
using System.Net.Http;
using TodoDataLibrary;

namespace ASP.NET_ClientServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            ApiHelper.InitializeClient();
        }

        public IActionResult Index()
        {
            var task = TodoProcessor.LoadAllTodos();
            return View(task.Result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Todo(String? id)
        {
            if (id == null)
            {
                Index();
            }

            var task = TodoProcessor.LoadTodo(id);
            
            return View(task.Result);
        }

        public IActionResult NewTodo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewTodo(Models.TodoModel todoModel)
        {
            if (ModelState.IsValid)
            {
                var todo = new TodoDataLibrary.PostTodo();
                todo.title = todoModel.Title;
                todo.desc = todoModel.Desc;
                todo.estimate = todoModel.Estimate;
                TodoProcessor.PostTodo(todo);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateTodo(String id)
        {
            var task = TodoProcessor.LoadTodo(id).Result;
            var todo = new Models.TodoModel();
            todo.ID = task._id;
            todo.Title = task.title;
            todo.Desc = task.desc;
            todo.Estimate = task.estimate;
            return View(todo);
        }

        public IActionResult DeleteTodo(String id)
        {
            TodoProcessor.DeleteTodo(id);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult UpdateTodo(Models.TodoModel todoModel)
        {
            if (ModelState.IsValid)
            {
                var todo = new TodoDataLibrary.TodoModel();
                todo._id = todoModel.ID;
                todo.title = todoModel.Title;
                todo.desc = todoModel.Desc;
                todo.estimate = todoModel.Estimate;
                TodoProcessor.UpdateTodo(todo);
                return RedirectToAction("Todo", "Home", new { id = todo._id });
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
