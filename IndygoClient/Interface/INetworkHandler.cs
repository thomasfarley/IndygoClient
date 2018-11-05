using IndygoClient.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IndygoClient.Interface
{
    internal interface INetworkHandler : IDisposable
    {
        JsonSerializerSettings JsonSettings { get; set; }

        Tuple<ResponseInfo, string> Download(string url, Dictionary<string, string> headers = null);
        Tuple<ResponseInfo, byte[]> DownloadRaw(string url, Dictionary<string, string> headers = null);
        Tuple<ResponseInfo, T> DownloadJson<T>(string url, Dictionary<string, string> headers = null);
        Task<Tuple<ResponseInfo, byte[]>> DownloadRawAsync(string url, Dictionary<string, string> headers = null);
        Task<Tuple<ResponseInfo, string>> DownloadAsync(string url, Dictionary<string, string> headers = null);
        Task<Tuple<ResponseInfo, T>> DownloadJsonAsync<T>(string url, Dictionary<string, string> headers = null);

        Task<Tuple<ResponseInfo, byte[]>> UploadRawAsync(string url, string body, string method, Dictionary<string, string> headers = null);
        Task<Tuple<ResponseInfo, string>> UploadAsync(string url, string body, string method, Dictionary<string, string> headers = null);
        Task<Tuple<ResponseInfo, T>> UploadJsonAsync<T>(string url, string body, string method, Dictionary<string, string> headers = null);
    }
}