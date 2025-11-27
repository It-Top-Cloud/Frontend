using System.Net.Http.Json;
using System.Text.Json;

namespace drive.Services.BaseAPI {
    internal class ApiService : BaseApiService, IApiService {
        public HttpClient client { get; set; }

        public ApiService(HttpClient client) {
            this.client = client;
            this.BaseUri = "https://cloud.rotatick.ru/";
        }

        public async Task<TResponse> HttpAsync<TRequest, TResponse>(HttpMethod method, string uri, TRequest? request) {
            string endPoint = $"{BaseUri.TrimEnd('/')}/{uri.TrimStart('/')}";

            var requestMessage = new HttpRequestMessage {
                RequestUri = new Uri(endPoint),
                Method = method
            };

            if (request != null) {
                requestMessage.Headers.Add("Content-Type", "application/json");
                requestMessage.Content = JsonContent.Create(request);
            }

            var response = await client.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode) {
                string errorMessgae = "Что-то пошло не так, повторите попытку позже";
                var error = JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync())!;
                if (error.ContainsKey("Error")) {
                    errorMessgae = error["Error"];
                }
                throw new HttpRequestException(errorMessgae);
            }

            TResponse? result = await response.Content.ReadFromJsonAsync<TResponse>();
            return result!;
        }
    }
}

