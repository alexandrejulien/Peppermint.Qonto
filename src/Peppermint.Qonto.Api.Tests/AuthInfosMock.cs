using Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Peppermint.Qonto.Api.Tests
{
    public static class AuthInfosMock
    {
        public static void Configure()
            => AuthInfos.Configure(
                "LOGIN",
                "Secret key");
    }
}
