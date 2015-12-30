// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Net.Http;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public static class SearchServiceFixtureExtensions
    {
        public static SearchServiceClient GetSearchServiceClient(
            this SearchServiceFixture fixture, 
            params DelegatingHandler[] handlers)
        {
            TestEnvironment currentEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            Uri baseUri = currentEnvironment.GetBaseSearchUri(fixture.SearchServiceName);
            currentEnvironment.BaseUri = baseUri;
            SearchCredentials originalCred = new SearchCredentials(fixture.PrimaryApiKey);
            currentEnvironment.Credentials = new SearchTestCredentials(originalCred);
            return fixture.MockContext.GetServiceClientWithCredentials<SearchServiceClient>(currentEnvironment, originalCred, handlers);
        }
    }
}
