using Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peppermint.Qonto.Api.Tests
{
    /// <summary>
    /// Authentification informations.
    /// </summary>
    public static class AuthInfos
    {
        /// <summary>
        /// Configure client with ApiKey.
        /// </summary>
        /// <param name="login">Qonto login credentials.</param>
        /// <param name="secretKey">Qonto secretKey credentials.</param>
        public static void Configure(string login, string secretKey)
        {
            var apiKey = new Dictionary<string, string> 
            { 
                { "Authorization", String.Format("{0}:{1}", login, secretKey) }
            };
            // Configure ApiKey in client with configuration parameters.
            Configuration.ApiKey = apiKey;
        }
    }
}
