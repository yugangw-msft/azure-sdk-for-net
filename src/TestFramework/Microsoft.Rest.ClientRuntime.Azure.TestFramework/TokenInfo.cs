﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http.Headers;

namespace Microsoft.Rest.ClientRuntime.Azure.TestFramework
{
    public class TokenInfo: ITestCredentials
    {
        public TokenInfo(string accessToken)
        {
            AccessToken = accessToken;
            AccessTokenType = "Bearer";
        }

        public TokenInfo(AuthenticationResult result)
        {
            AccessToken = result.AccessToken;
            AccessTokenType = result.AccessTokenType;
        }

        public string AccessToken { get; private set; }
        public string AccessTokenType { get; private set; }

        public void ApplyCredentials(HttpRequestMessage request)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue(AccessTokenType, 
                AccessToken);
        }
    }
}
