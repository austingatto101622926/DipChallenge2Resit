using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DipChallengeResit_DataAccess
{
    public class ControllerHandler<T>
    {
        HttpClient Client;
        string ControlPath;

        public ControllerHandler(string baseAddress, string controllerPath)
        {
            Client = new HttpClient() { BaseAddress = new Uri(baseAddress) };
            ControlPath = controllerPath;
        }

        public async Task<List<T>> GET()
        {
            List<T> result = null;
            HttpResponseMessage response = await Client.GetAsync($"/api/{ControlPath}/");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<T>>();
            }
            return result;
        }

        public async Task<T> GET(int id)
        {
            T result = default(T);
            HttpResponseMessage response = await Client.GetAsync($"/api/{ControlPath}/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("Not Found");
            }
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            return result;
        }

        public async void PUT(int id, T item)
        {
            HttpResponseMessage response = await Client.PutAsJsonAsync<T>($"/api/{ControlPath}/{id}", item);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception("Bad Request");
            }
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("Not Found");
            }
            if (response.IsSuccessStatusCode)
            {
                return;
            }
        }

        public async Task<T> POST(T item)
        {
            T result = default(T);
            HttpResponseMessage response = await Client.PostAsJsonAsync<T>($"/api/{ControlPath}/", item);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new Exception("Bad Request");
            }
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            return result;
        }

        public async Task<T> DELETE(int id)
        {
            T result = default(T);
            HttpResponseMessage response = await Client.DeleteAsync($"/api/{ControlPath}/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                string message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Bad Request: {message}");
            }
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            return result;
        }
    }
}
