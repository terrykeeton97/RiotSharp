using Newtonsoft.Json;
using RiotSharp.Enums;
using System.Diagnostics;
using System.Net;
using System.Security.Authentication;
using System.Text.RegularExpressions;

namespace RiotSharp.Utilities
{
    public class HttpClientFactory
    {
        private readonly HttpClient _httpClient;
        private bool _isConnected;
        private Tuple<Process, string, string>? _processInfo;
        internal event Action OnConnected;
        private static readonly Regex AuthTokenRegex = new Regex("\"--remoting-auth-token=(.+?)\"");
        private static readonly Regex PortRegex = new Regex("\"--app-port=(\\d+?)\"");

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

        internal async Task<string> MakeApiRequest(RequestMethod requestMethod, string url, object? body = null)
        {
            if (!_isConnected)
                throw new InvalidOperationException("Not connected to the LCU Api");

            string method = requestMethod.ToString().ToUpper();

            if (url[0] != '/')
            {
                url = "/" + url;
            }

            var response = await _httpClient.SendAsync(new HttpRequestMessage(new HttpMethod(method), "https://127.0.0.1:" + _processInfo.Item3 + url)
            {
                Content = body == null ? null : new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json")
            });

            return await response.Content.ReadAsStringAsync();
        }

        private void TryConnect()
        {
            if (_isConnected)
                return;

            var status = GetLeagueStatus();
            if (status == null)
                return;

            _processInfo = status;
            var byteArray = System.Text.Encoding.ASCII.GetBytes("riot:" + status.Item2);
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            _isConnected = true;
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

    internal class OnWebSocketEventArgs : EventArgs
    {
        internal string Path { get; set; }
        internal string Type { get; set; }
        internal dynamic Data { get; set; }
    }
}
