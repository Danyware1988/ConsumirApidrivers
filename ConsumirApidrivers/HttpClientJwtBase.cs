using Newtonsoft.Json;
//inicio el namespace
using AM.Integration.Clients.Core.RestClient.JwtService;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

//nombre del namespace
namespace AM.Integration.Clients.Core.RestClient
{

    //clase base de otras clases
    public abstract class HttpClientJwtBase<t, TResult>
    {
        //TResult operacion que retorna un valor
        public TResult token;

        // variable de solo lectura
        private readonly TokenJwtBase<t> tokenData;

        public HttpClientJwtBase(TokenJwtBase<t> tokenData, TResult tokenResult)
        {
            this.tokenData = tokenData;
            this.token = tokenResult;

        }
        public async void JsonPost<TResult>(Uri uri, String token, dynamic @params, Action<TResult, Exception> callback)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(JsonConvert.SerializeObject(@params), UTF8Encoding.Default, "application/json");

                await client.PostAsync(uri, content).ContinueWith((task) =>
                {
                    gethttpResponse(task: task, callback: callback);
                });
            }
        }

        public async void JsonPut<TResult>(Uri uri, String token, dynamic @params, Action<TResult, Exception> callback)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(JsonConvert.SerializeObject(@params), UTF8Encoding.Default, "application/json");

                await client.PostAsync(uri, content).ContinueWith((task) =>
                {
                    gethttpResponse(task: task, callback: callback);
                });
            }
        }
        public async void JsonGet<TResult>(Uri uri, String token, Action<TResult, Exception> callback)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var content = new StringContent(String.Empty);

                content.Headers.Clear();

                var req = new HttpRequestMessage(HttpMethod.Get, uri) { Content = content };

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

                await client.GetAsync(uri).ContinueWith((task) =>
                {
                    gethttpResponse(task: task, callback: callback);
                });
            }
        }

        public async void getToken(Action<String, Exception> callback)
        {
            using (var client = new HttpClient())
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                var content = new StringContent(JsonConvert.SerializeObject(tokenData.TokenBody), UTF8Encoding.Default, "application/json");

                content.Headers.Clear();

                content.Headers.Add("Content-Type", "application/json");

                await client.PostAsync(tokenData.EndPoint, content).ContinueWith((task) =>
                {
                    gethttpResponse(task: task, callback: callback);
                });
            }
        }

        private void gethttpResponse<TResult>(Task<HttpResponseMessage> task, Action<TResult, Exception> callback)
        {
            if (task.IsFaulted)
                callback(arg1: default(TResult), arg2: task.Exception.InnerException);

            if (!task.Result.IsSuccessStatusCode)
            {
                var resultTask = task.Result.Content.ReadAsStringAsync();

                if (task.Result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    callback(arg1: default(TResult), arg2: new Exception(resultTask.Result));
                }

                callback(arg1: default(TResult), arg2: new Exception(resultTask.Result));
            }
            else
            {
                if (task.IsCompleted && !task.IsFaulted)
                {
                    var resultTask = task.Result.Content.ReadAsStringAsync();
                    resultTask.Wait();

                    var result = JsonConvert.DeserializeObject<TResult>(resultTask.Result);
                    callback(arg1: result, arg2: null);
                }
            }
        }
    }
}
