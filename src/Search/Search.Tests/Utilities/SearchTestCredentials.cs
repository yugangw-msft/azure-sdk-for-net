// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Search;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net.Http;
using System.Threading;

namespace Microsoft.Azure.Search.Tests
{
    class SearchTestCredentials : ITestCredentials
    {
        private SearchCredentials _cred;

        public SearchTestCredentials(SearchCredentials cred)
        {
            _cred = cred;
        }

        public string AccessToken
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string AccessTokenType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void ApplyCredentials(HttpRequestMessage request)
        {
            _cred.ProcessHttpRequestAsync(request, default(CancellationToken)).ConfigureAwait(false);
        }
    }
}
