using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DataLibrary.DataAccess
{
    class MongoApiDataAccess
    {
        public static HttpClient client = new HttpClient();

        public static void InitializeClient()
        {
            client.BaseAddress = new Uri("http://localhost:3000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async void GetAllTodos()
        {
            List<Models.TodoModel> todoModels = null;

            HttpResponseMessage responseMessage = await client.GetAsync("/todo");
            if (responseMessage.IsSuccessStatusCode)
            {
                
            }

        }

    }
}
