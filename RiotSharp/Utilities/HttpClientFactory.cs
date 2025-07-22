using Newtonsoft.Json;
using RiotSharp.Enums;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;

namespace RiotSharp.Utilities
{
    public class HttpClientFactory : IDisposable
    {
        private static readonly Lazy<HttpClientFactory> _instance = new(() => new HttpClientFactory(), LazyThreadSafetyMode.ExecutionAndPublication);
        public static HttpClientFactory Instance => _instance.Value;

        private readonly HttpClient _httpClient;
        private readonly Logger _logger;
        private volatile bool _isConnected;
        private Tuple<Process, string, string>? _processInfo;
        private readonly object _connectionLock = new();
        private bool _disposed;

        private HttpClientFactory()
        {
            _logger = Logger.Instance.Value;
            _logger.LogInfo("Initializing HttpClientFactory");

            _httpClient = CreateHttpClient();
            TryConnect();
        }

        #region HTTP GET Methods

        /// <summary>
        /// Performs an asynchronous GET request to the specified endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> GetAsync(string endpoint, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Making GET request to: {endpoint}");
            return await SendRequestAsync(HttpMethod.Get, endpoint, null, cancellationToken);
        }

        /// <summary>
        /// Performs a synchronous GET request to the specified endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage Get(string endpoint)
        {
            return GetAsync(endpoint).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Performs an asynchronous GET request and deserializes the response to the specified type
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Deserialized object</returns>
        public async Task<T?> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
        {
            using var response = await GetAsync(endpoint, cancellationToken);
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(content) ? default : JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// Performs a synchronous GET request and deserializes the response to the specified type
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <returns>Deserialized object</returns>
        public T? Get<T>(string endpoint)
        {
            return GetAsync<T>(endpoint).GetAwaiter().GetResult();
        }

        #endregion

        #region HTTP POST Methods

        /// <summary>
        /// Performs an asynchronous POST request to the specified endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> PostAsync(string endpoint, object? body = null, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Making POST request to: {endpoint}");
            var content = CreateJsonContent(body);
            return await SendRequestAsync(HttpMethod.Post, endpoint, content, cancellationToken);
        }

        /// <summary>
        /// Performs a synchronous POST request to the specified endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage Post(string endpoint, object? body = null)
        {
            return PostAsync(endpoint, body).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Performs an asynchronous POST request and deserializes the response to the specified type
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Deserialized object</returns>
        public async Task<T?> PostAsync<T>(string endpoint, object? body = null, CancellationToken cancellationToken = default)
        {
            using var response = await PostAsync(endpoint, body, cancellationToken);
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(content) ? default : JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// Performs a synchronous POST request and deserializes the response to the specified type
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <returns>Deserialized object</returns>
        public T? Post<T>(string endpoint, object? body = null)
        {
            return PostAsync<T>(endpoint, body).GetAwaiter().GetResult();
        }

        #endregion

        #region HTTP PUT Methods

        /// <summary>
        /// Performs an asynchronous PUT request to the specified endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> PutAsync(string endpoint, object? body = null, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Making PUT request to: {endpoint}");
            var content = CreateJsonContent(body);
            return await SendRequestAsync(HttpMethod.Put, endpoint, content, cancellationToken);
        }

        /// <summary>
        /// Performs a synchronous PUT request to the specified endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage Put(string endpoint, object? body = null)
        {
            return PutAsync(endpoint, body).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Performs an asynchronous PUT request and deserializes the response to the specified type
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Deserialized object</returns>
        public async Task<T?> PutAsync<T>(string endpoint, object? body = null, CancellationToken cancellationToken = default)
        {
            using var response = await PutAsync(endpoint, body, cancellationToken);
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(content) ? default : JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// Performs a synchronous PUT request and deserializes the response to the specified type
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <returns>Deserialized object</returns>
        public T? Put<T>(string endpoint, object? body = null)
        {
            return PutAsync<T>(endpoint, body).GetAwaiter().GetResult();
        }

        #endregion

        #region HTTP PATCH Methods

        /// <summary>
        /// Performs an asynchronous PATCH request to the specified endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> PatchAsync(string endpoint, object? body = null, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Making PATCH request to: {endpoint}");
            var content = CreateJsonContent(body);
            return await SendRequestAsync(HttpMethod.Patch, endpoint, content, cancellationToken);
        }

        /// <summary>
        /// Performs a synchronous PATCH request to the specified endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage Patch(string endpoint, object? body = null)
        {
            return PatchAsync(endpoint, body).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Performs an asynchronous PATCH request and deserializes the response to the specified type
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Deserialized object</returns>
        public async Task<T?> PatchAsync<T>(string endpoint, object? body = null, CancellationToken cancellationToken = default)
        {
            using var response = await PatchAsync(endpoint, body, cancellationToken);
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(content) ? default : JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// Performs a synchronous PATCH request and deserializes the response to the specified type
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="body">The request body</param>
        /// <returns>Deserialized object</returns>
        public T? Patch<T>(string endpoint, object? body = null)
        {
            return PatchAsync<T>(endpoint, body).GetAwaiter().GetResult();
        }

        #endregion

        #region HTTP DELETE Methods

        /// <summary>
        /// Performs an asynchronous DELETE request to the specified endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>HttpResponseMessage</returns>
        public async Task<HttpResponseMessage> DeleteAsync(string endpoint, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Making DELETE request to: {endpoint}");
            return await SendRequestAsync(HttpMethod.Delete, endpoint, null, cancellationToken);
        }

        /// <summary>
        /// Performs a synchronous DELETE request to the specified endpoint
        /// </summary>
        /// <param name="endpoint">The API endpoint</param>
        /// <returns>HttpResponseMessage</returns>
        public HttpResponseMessage Delete(string endpoint)
        {
            return DeleteAsync(endpoint).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Performs an asynchronous DELETE request and deserializes the response to the specified type
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Deserialized object</returns>
        public async Task<T?> DeleteAsync<T>(string endpoint, CancellationToken cancellationToken = default)
        {
            using var response = await DeleteAsync(endpoint, cancellationToken);
            response.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(content) ? default : JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// Performs a synchronous DELETE request and deserializes the response to the specified type
        /// </summary>
        /// <typeparam name="T">The type to deserialize to</typeparam>
        /// <param name="endpoint">The API endpoint</param>
        /// <returns>Deserialized object</returns>
        public T? Delete<T>(string endpoint)
        {
            return DeleteAsync<T>(endpoint).GetAwaiter().GetResult();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and configures the HttpClient with optimal settings
        /// </summary>
        /// <returns>Configured HttpClient</returns>
        private HttpClient CreateHttpClient()
        {
            try
            {
                var handler = new HttpClientHandler()
                {
                    SslProtocols = SslProtocols.Tls13 | SslProtocols.Tls12,
                    ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
                    UseCookies = false
                };

                var client = new HttpClient(handler)
                {
                    Timeout = TimeSpan.FromSeconds(30)
                };

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Connection.Add("keep-alive");

                _logger.LogDebug("HttpClient initialized with TLS 1.2/1.3 support and optimized settings");
                return client;
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Failed to initialize HttpClient with TLS 1.2/1.3, falling back to legacy protocols: {ex.Message}");
                
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                var handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
                    UseCookies = false
                };

                var client = new HttpClient(handler)
                {
                    Timeout = TimeSpan.FromSeconds(30)
                };

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Connection.Add("keep-alive");

                _logger.LogDebug("HttpClient initialized with legacy TLS support");
                return client;
            }
        }

        /// <summary>
        /// Creates JSON content from an object
        /// </summary>
        /// <param name="body">The object to serialize</param>
        /// <returns>StringContent with JSON</returns>
        private static StringContent? CreateJsonContent(object? body)
        {
            if (body == null) return null;

            var json = body is string stringBody ? stringBody : JsonConvert.SerializeObject(body);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Sends an HTTP request with proper error handling and connection management
        /// </summary>
        /// <param name="method">HTTP method</param>
        /// <param name="endpoint">API endpoint</param>
        /// <param name="content">Request content</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>HttpResponseMessage</returns>
        private async Task<HttpResponseMessage> SendRequestAsync(HttpMethod method, string endpoint, HttpContent? content, CancellationToken cancellationToken)
        {
            EnsureConnected();

            if (_processInfo == null)
            {
                _logger.LogError("Process information is null");
                throw new InvalidOperationException("Process information is null");
            }

            try
            {
                var normalizedUrl = LeagueClientUtility.NormalizeUrl(endpoint);
                var fullUrl = LeagueClientUtility.BuildApiUrl(_processInfo.Item3, normalizedUrl);

                _logger.LogDebug($"Making {method} request to: {fullUrl}");

                using var request = new HttpRequestMessage(method, fullUrl);
                
                if (content != null)
                {
                    request.Content = content;
                    if (content is StringContent stringContent)
                    {
                        var bodyContent = await stringContent.ReadAsStringAsync();
                        _logger.LogDebug($"Request body: {bodyContent}");
                    }
                }

                var response = await _httpClient.SendAsync(request, cancellationToken);
                
                _logger.LogDebug($"Response received with status: {response.StatusCode}");
                return response;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"HTTP request failed for {method} {endpoint}", ex);
                throw;
            }
            catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
            {
                _logger.LogError($"Request timeout for {method} {endpoint}", ex);
                throw new TimeoutException($"Request to {endpoint} timed out", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error during {method} {endpoint}", ex);
                throw;
            }
        }

        /// <summary>
        /// Ensures the client is connected to the League client
        /// </summary>
        private void EnsureConnected()
        {
            if (_isConnected) return;

            lock (_connectionLock)
            {
                if (_isConnected) return;
                TryConnect();
            }
        }

        /// <summary>
        /// Attempts to connect to the League of Legends client
        /// </summary>
        private void TryConnect()
        {
            if (_isConnected)
            {
                _logger.LogDebug("Already connected to LCU API");
                return;
            }

            try
            {
                _logger.LogInfo("Attempting to connect to League client");
                _processInfo = LeagueClientUtility.GetLeagueClientInfo();
                
                if (_processInfo == null)
                {
                    _logger.LogWarning("Failed to get League client information");
                    throw new InvalidOperationException("Unable to connect to League client - client not found or not running");
                }

                var authHeader = LeagueClientUtility.CreateAuthHeader(_processInfo.Item2);
                _httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Basic", authHeader);

                _isConnected = true;
                _logger.LogInfo($"Successfully connected to LCU API on port {_processInfo.Item3}");
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to connect to League client", ex);
                throw new InvalidOperationException("Failed to connect to League client", ex);
            }
        }

        #endregion

        #region Public Properties and Methods

        /// <summary>
        /// Gets the current connection status
        /// </summary>
        public bool IsConnected => _isConnected;

        /// <summary>
        /// Forces a reconnection attempt
        /// </summary>
        public void Reconnect()
        {
            lock (_connectionLock)
            {
                _logger.LogInfo("Forcing reconnection to League client");
                _isConnected = false;
                _processInfo = null;
                _httpClient.DefaultRequestHeaders.Authorization = null;
                TryConnect();
            }
        }

        /// <summary>
        /// Gets the current League client port (if connected)
        /// </summary>
        public string? Port => _processInfo?.Item3;

        /// <summary>
        /// Gets the current League client process (if connected)
        /// </summary>
        public Process? Process => _processInfo?.Item1;

        #endregion

        #region IDisposable Implementation

        /// <summary>
        /// Disposes the HttpClient resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected dispose method
        /// </summary>
        /// <param name="disposing">Whether disposing from Dispose method</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _logger.LogInfo("Disposing HttpClientFactory");
                _httpClient?.Dispose();
                _disposed = true;
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~HttpClientFactory()
        {
            Dispose(false);
        }

        #endregion
    }
}
