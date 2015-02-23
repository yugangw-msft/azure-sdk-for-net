// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hyak.Common;
using Microsoft.WindowsAzure.Management.Network;
using Microsoft.WindowsAzure.Management.Network.Models;

namespace Microsoft.WindowsAzure.Management.Network
{
    /// <summary>
    /// The Network Management API includes operations for managing the static
    /// IPs for your subscription.
    /// </summary>
    internal partial class StaticIPOperations : IServiceOperations<NetworkManagementClient>, IStaticIPOperations
    {
        /// <summary>
        /// Initializes a new instance of the StaticIPOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal StaticIPOperations(NetworkManagementClient client)
        {
            this._client = client;
        }
        
        private NetworkManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.WindowsAzure.Management.Network.NetworkManagementClient.
        /// </summary>
        public NetworkManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// The Check Static IP operation retrieves the details for the
        /// availability of static IP addresses for the given virtual network.
        /// </summary>
        /// <param name='networkName'>
        /// Required. The name of the virtual network.
        /// </param>
        /// <param name='ipAddress'>
        /// Required. The address of the static IP.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A response that indicates the availability of a static IP address,
        /// and if not, provides a list of suggestions.
        /// </returns>
        public async Task<NetworkStaticIPAvailabilityResponse> CheckAsync(string networkName, string ipAddress, CancellationToken cancellationToken)
        {
            // Validate
            if (networkName == null)
            {
                throw new ArgumentNullException("networkName");
            }
            if (ipAddress == null)
            {
                throw new ArgumentNullException("ipAddress");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("networkName", networkName);
                tracingParameters.Add("ipAddress", ipAddress);
                TracingAdapter.Enter(invocationId, this, "CheckAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/services/networking/";
            url = url + Uri.EscapeDataString(networkName);
            List<string> queryParameters = new List<string>();
            queryParameters.Add("op=checkavailability");
            queryParameters.Add("address=" + Uri.EscapeDataString(ipAddress));
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2014-10-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    NetworkStaticIPAvailabilityResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new NetworkStaticIPAvailabilityResponse();
                        XDocument responseDoc = XDocument.Parse(responseContent);
                        
                        XElement addressAvailabilityResponseElement = responseDoc.Element(XName.Get("AddressAvailabilityResponse", "http://schemas.microsoft.com/windowsazure"));
                        if (addressAvailabilityResponseElement != null)
                        {
                            XElement isAvailableElement = addressAvailabilityResponseElement.Element(XName.Get("IsAvailable", "http://schemas.microsoft.com/windowsazure"));
                            if (isAvailableElement != null)
                            {
                                bool isAvailableInstance = bool.Parse(isAvailableElement.Value);
                                result.IsAvailable = isAvailableInstance;
                            }
                            
                            XElement availableAddressesSequenceElement = addressAvailabilityResponseElement.Element(XName.Get("AvailableAddresses", "http://schemas.microsoft.com/windowsazure"));
                            if (availableAddressesSequenceElement != null)
                            {
                                foreach (XElement availableAddressesElement in availableAddressesSequenceElement.Elements(XName.Get("AvailableAddress", "http://schemas.microsoft.com/windowsazure")))
                                {
                                    result.AvailableAddresses.Add(availableAddressesElement.Value);
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
