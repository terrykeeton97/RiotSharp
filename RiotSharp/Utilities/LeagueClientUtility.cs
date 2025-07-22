using System.Diagnostics;

namespace RiotSharp.Utilities
{
    internal static class LeagueClientUtility
    {
        private static readonly Logger _logger = Logger.Instance.Value;

        /// <summary>
        /// Gets the League of Legends client process information including authentication token and port
        /// </summary>
        /// <returns>Tuple containing Process, Auth Token, and Port</returns>
        /// <exception cref="InvalidOperationException">Thrown when unable to connect to League client</exception>
        public static Tuple<Process, string, string>? GetLeagueClientInfo()
        {
            _logger.LogDebug("Attempting to get League client information");

            foreach (var process in Process.GetProcessesByName("LeagueClientUx"))
            {
                try
                {
                    if (process.MainModule == null)
                    {
                        _logger.LogWarning("LeagueClientUx process doesn't have any main module");
                        throw new Exception("The LeagueClientUx process doesn't have any main module.");
                    }

                    var processDirectory = Path.GetDirectoryName(process.MainModule.FileName);

                    if (processDirectory == null)
                    {
                        _logger.LogWarning("Unable to get directory name for LeagueClientUx process");
                        throw new Exception("Unable to get the directory name for the LeagueClientUx process.");
                    }

                    string lockfilePath = Path.Combine(processDirectory, "lockfile");
                    _logger.LogDebug($"Reading lockfile from: {lockfilePath}");

                    string lockfile;
                    using (var stream = File.Open(lockfilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var reader = new StreamReader(stream))
                    {
                        lockfile = reader.ReadToEnd();
                    }

                    var splitContent = lockfile.Split(':');
                    var clientInfo = new Tuple<Process, string, string>(
                        process,
                        splitContent[3], // Auth token
                        splitContent[2]  // Port
                    );

                    _logger.LogInfo($"Successfully connected to League client on port {splitContent[2]}");
                    return clientInfo;
                }
                catch (Exception exception)
                {
                    _logger.LogError($"Error while trying to get the status for LeagueClientUx", exception);
                    throw new InvalidOperationException($"Error while trying to get the status for LeagueClientUx: {exception}");
                }
            }

            _logger.LogWarning("No LeagueClientUx process found");
            return null;
        }

        /// <summary>
        /// Creates a base64 encoded authentication header for the League client
        /// </summary>
        /// <param name="authToken">The authentication token from the lockfile</param>
        /// <returns>Base64 encoded authentication string</returns>
        public static string CreateAuthHeader(string authToken)
        {
            var byteArray = System.Text.Encoding.ASCII.GetBytes("riot:" + authToken);
            return Convert.ToBase64String(byteArray);
        }

        /// <summary>
        /// Ensures the URL starts with a forward slash
        /// </summary>
        /// <param name="url">The URL to normalize</param>
        /// <returns>Normalized URL starting with /</returns>
        public static string NormalizeUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return "/";

            return url[0] != '/' ? "/" + url : url;
        }

        /// <summary>
        /// Builds the full API URL for the League client
        /// </summary>
        /// <param name="port">The port number</param>
        /// <param name="endpoint">The API endpoint</param>
        /// <returns>Complete API URL</returns>
        public static string BuildApiUrl(string port, string endpoint)
        {
            var normalizedEndpoint = NormalizeUrl(endpoint);
            return $"https://127.0.0.1:{port}{normalizedEndpoint}";
        }
    }
}
