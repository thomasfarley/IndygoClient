using IndygoClient.Interface;
using IndygoClient.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace IndygoClient.Class
{
    internal class NetworkHandler : INetworkHandler
    {
        private readonly Encoding _encoding = Encoding.UTF8;
        private readonly HttpClient _client;

        public JsonSerializerSettings JsonSettings { get; set; }

        internal NetworkHandler()
        {
            _client = new HttpClient();
        }
        #region Download Methods
        public Tuple<ResponseInfo, T> DownloadJson<T>(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, string> response = Download(url, headers);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }
        public Tuple<ResponseInfo, string> Download(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, byte[]> raw = DownloadRaw(url, headers);
            return new Tuple<ResponseInfo, string>(raw.Item1, raw.Item2.Length > 0 ? _encoding.GetString(raw.Item2) : "{}");
        }
        public Tuple<ResponseInfo, byte[]> DownloadRaw(string url, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                AddHeaders(headers);
            }
            using (HttpResponseMessage response = Task.Run(() => _client.GetAsync(url)).Result)
            {
                return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                {
                    StatusCode = response.StatusCode,
                    Headers = ConvertHeaders(response.Headers)
                }, Task.Run(() => response.Content.ReadAsByteArrayAsync()).Result);
            }
        }
        public async Task<Tuple<ResponseInfo, byte[]>> DownloadRawAsync(string url, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                AddHeaders(headers);
            }
            using (HttpResponseMessage response = await _client.GetAsync(url).ConfigureAwait(false))
            {
                return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                {
                    StatusCode = response.StatusCode,
                    Headers = ConvertHeaders(response.Headers)
                }, await response.Content.ReadAsByteArrayAsync());
            }
        }
        public async Task<Tuple<ResponseInfo, string>> DownloadAsync(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, byte[]> raw = await DownloadRawAsync(url, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, string>(raw.Item1, raw.Item2.Length > 0 ? _encoding.GetString(raw.Item2) : "{}");
        }
        public async Task<Tuple<ResponseInfo, T>> DownloadJsonAsync<T>(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, string> response = await DownloadAsync(url, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }
        #endregion

        #region Upload Methods
        public async Task<Tuple<ResponseInfo, byte[]>> UploadRawAsync(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                AddHeaders(headers);
            }

            HttpRequestMessage message = new HttpRequestMessage(new HttpMethod(method), url)
            {
                Content = new StringContent(body, _encoding)
            };
            using (HttpResponseMessage response = await _client.SendAsync(message))
            {
                return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                {
                    StatusCode = response.StatusCode,
                    Headers = ConvertHeaders(response.Headers)
                }, await response.Content.ReadAsByteArrayAsync());
            }
        }
        public async Task<Tuple<ResponseInfo, string>> UploadAsync(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, byte[]> data = await UploadRawAsync(url, body, method, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, string>(data.Item1, data.Item2.Length > 0 ? _encoding.GetString(data.Item2) : "{}");
        }
        public async Task<Tuple<ResponseInfo, T>> UploadJsonAsync<T>(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, string> response = await UploadAsync(url, body, method, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, T>(response.Item1, JsonConvert.DeserializeObject<T>(response.Item2, JsonSettings));
        }
        #endregion
        
        private void AddHeaders(Dictionary<string, string> headers)
        {
            _client.DefaultRequestHeaders.Clear();
            foreach (KeyValuePair<string, string> headerPair in headers)
            {
                _client.DefaultRequestHeaders.TryAddWithoutValidation(headerPair.Key, headerPair.Value);
            }
        }
        private static WebHeaderCollection ConvertHeaders(HttpResponseHeaders headers)
        {
            WebHeaderCollection newHeaders = new WebHeaderCollection();
            foreach (KeyValuePair<string, IEnumerable<string>> headerPair in headers)
            {
                foreach (string headerValue in headerPair.Value)
                {
                    newHeaders.Add(headerPair.Key, headerValue);
                }
            }
            return newHeaders;
        }
        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}