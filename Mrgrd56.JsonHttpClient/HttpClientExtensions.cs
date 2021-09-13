using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mrgrd56.JsonHttpClient.Exceptions;
using Newtonsoft.Json;

namespace Mrgrd56.JsonHttpClient
{
    public static class HttpClientExtensions
    {
        private static HttpContent CreateHttpContent(object source)
        {
            var json = JsonConvert.SerializeObject(source);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Sends an HTTP request as an asynchronous operation and parses the response as JSON.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="method">The HTTP method used by the request message.</param>
        /// <param name="body">The HTTP request content sent to the server as JSON.</param>
        /// <typeparam name="TResponse">The response body object type.</typeparam>
        /// <returns>The object created from the JSON returned by the servers</returns>
        /// <exception cref="HttpException">Thrown if the response status code is not successful.</exception>
        public static async Task<TResponse> SendAsync<TResponse>(
            this HttpClient httpClient, string requestUri,
            HttpMethod method, object body = null)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(requestUri),
                Method = method,
                Content = body == null ? null : CreateHttpContent(body)
            };
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ParseJsonAsync<TResponse>();
            }

            throw new HttpException(response);
        }

        /// <summary>
        /// Sends an HTTP get request as an asynchronous operation and parses the response as JSON.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="body">The HTTP request content sent to the server as JSON.</param>
        /// <typeparam name="TResponse">The response body object type.</typeparam>
        /// <returns>The object created from the JSON returned by the servers</returns>
        /// <exception cref="HttpException">Thrown if the response status code is not successful.</exception>
        public static async Task<TResponse> GetAsync<TResponse>(this HttpClient httpClient, string requestUri, object body = null) => 
            await httpClient.SendAsync<TResponse>(requestUri, HttpMethod.Get, body);

        /// <summary>
        /// Sends an HTTP post request as an asynchronous operation and parses the response as JSON.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="body">The HTTP request content sent to the server as JSON.</param>
        /// <typeparam name="TResponse">The response body object type.</typeparam>
        /// <returns>The object created from the JSON returned by the servers</returns>
        /// <exception cref="HttpException">Thrown if the response status code is not successful.</exception>
        public static async Task<TResponse> PostAsync<TResponse>(this HttpClient httpClient, string requestUri, object body = null) => 
            await httpClient.SendAsync<TResponse>(requestUri, HttpMethod.Post, body);

        /// <summary>
        /// Sends an HTTP put request as an asynchronous operation and parses the response as JSON.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="body">The HTTP request content sent to the server as JSON.</param>
        /// <typeparam name="TResponse">The response body object type.</typeparam>
        /// <returns>The object created from the JSON returned by the servers</returns>
        /// <exception cref="HttpException">Thrown if the response status code is not successful.</exception>
        public static async Task<TResponse> PutAsync<TResponse>(this HttpClient httpClient, string requestUri, object body = null) => 
            await httpClient.SendAsync<TResponse>(requestUri, HttpMethod.Put, body);

        /// <summary>
        /// Sends an HTTP delete request as an asynchronous operation and parses the response as JSON.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="requestUri">The Uri the request is sent to.</param>
        /// <param name="body">The HTTP request content sent to the server as JSON.</param>
        /// <typeparam name="TResponse">The response body object type.</typeparam>
        /// <returns>The object created from the JSON returned by the servers</returns>
        /// <exception cref="HttpException">Thrown if the response status code is not successful.</exception>
        public static async Task<TResponse> DeleteAsync<TResponse>(this HttpClient httpClient, string requestUri, object body = null) => 
            await httpClient.SendAsync<TResponse>(requestUri, HttpMethod.Delete, body);
    }
}