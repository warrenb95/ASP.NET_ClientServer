using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TodoDataLibrary
{
    public class TodoProcessor
    {
        public static async Task<List<TodoModel>> LoadAllTodos()
        {
            using (HttpResponseMessage response = await ApiHelper.client.GetAsync("todo"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var rawJsonString = await response.Content.ReadAsStringAsync();
                    List<TodoModel> todoList = JsonConvert.DeserializeObject<List<TodoModel>>(rawJsonString);

                    return todoList;
                } 
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<TodoModel> LoadTodo(string id)
        {
            using (HttpResponseMessage response = await ApiHelper.client.GetAsync("todo/" + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var rawJsonString = await response.Content.ReadAsStringAsync();
                    TodoModel todo = JsonConvert.DeserializeObject<TodoModel>(rawJsonString);

                    return todo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async void PostTodo(PostTodo todoModel)
        {
            var json = JsonConvert.SerializeObject(todoModel);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var respones = await ApiHelper.client.PostAsync("todo", content);
                respones.EnsureSuccessStatusCode();
            }
        }

        public static async void UpdateTodo(TodoDataLibrary.TodoModel todoModel)
        {
            var json = JsonConvert.SerializeObject(todoModel);

            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                var respones = await ApiHelper.client.PutAsync("todo/" + todoModel._id, content);
                respones.EnsureSuccessStatusCode();
            }
        }

    }
}
