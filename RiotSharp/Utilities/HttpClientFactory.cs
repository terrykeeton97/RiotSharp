using Newtonsoft.Json;
using RiotSharp.Enums;
using System.Diagnostics;
using System.Net;
using System.Security.Authentication;

namespace RiotSharp.Utilities
{
    internal class HttpClientFactory
    {
        public static readonly Lazy<HttpClientFactory> Instance = new(() => new HttpClientFactory());

        private readonly HttpClient _httpClient;
        private bool _isConnected;
        private Tuple<Process, string, string>? _processInfo;

        internal HttpClientFactory()
        {
            try
            {
                _httpClient = new HttpClient(new HttpClientHandler()
                {
                    SslProtocols = SslProtocols.Tls13 | SslProtocols.Tls12,
                    ServerCertificateCustomValidationCallback = (a, b, c, d) => true
                });
            }
            catch
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                _httpClient = new HttpClient(new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (a, b, c, d) => true
                });
            }

            TryConnect();
        }

        internal async Task<T?> MakeApiRequest<T>(RequestMethod requestMethod, string url, string? body = null)
        {
            if (!_isConnected)
                throw new InvalidOperationException("Not connected to the LCU API");

            if (url[0] != '/')
            {
                url = "/" + url;
            }

            if (_processInfo != null)
            {
                var response = await _httpClient.SendAsync(new HttpRequestMessage(
                    new HttpMethod(requestMethod.ToString().ToUpper()),
                    "https://127.0.0.1:" + _processInfo.Item3 + url)
                {
                    Content = body == null ? null : new StringContent(body, System.Text.Encoding.UTF8, "application/json")
                });

                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                if (typeof(T) == typeof(string)) // Return the response as a string if Type is string
                {
                    return (T)(object)responseContent;
                }

                return JsonConvert.DeserializeObject<T>(responseContent);
            }

            return default;
        }

        private void TryConnect()
        {
            if (_isConnected)
                return;

            _processInfo = GetLeagueStatus();
            var byteArray = System.Text.Encoding.ASCII.GetBytes("riot:" + _processInfo.Item2);
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            _isConnected = true;
            //OnConnected.Invoke();
        }

        private Tuple<Process, string, string>? GetLeagueStatus()
        {
            foreach (var p in Process.GetProcessesByName("LeagueClientUx"))
            {
                try
                {
                    if (p.MainModule == null)
                        throw new Exception("The LeagueClientUx process doesn't have any main module.");

                    var processDirectory = Path.GetDirectoryName(p.MainModule.FileName);

                    if (processDirectory == null)
                        throw new Exception("Unable to get the directory name for the LeagueClientUx process.");

                    string lockfilePath = Path.Combine(processDirectory, "lockfile");

                    string lockfile;
                    using (var stream = File.Open(lockfilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var reader = new StreamReader(stream))
                    {
                        lockfile = reader.ReadToEnd();
                    }

                    var splitContent = lockfile.Split(':');
                    return new Tuple<Process, string, string>
                    (
                        p,
                        splitContent[3],
                        splitContent[2]
                    );
                }
                catch (Exception exception)
                {
                    throw new InvalidOperationException($"Error while trying to get the status for LeagueClientUx: {exception}");
                }
            }
            return null;
        }
    }
}
