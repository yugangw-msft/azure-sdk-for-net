// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Quantum.Jobs.Models
{
    /// <summary> Providers status. </summary>
    public partial class ProviderStatusList
    {
        /// <summary> Initializes a new instance of ProviderStatusList. </summary>
        internal ProviderStatusList()
        {
            Values = new ChangeTrackingList<ProviderStatus>();
        }

        /// <summary> Initializes a new instance of ProviderStatusList. </summary>
        /// <param name="values"> . </param>
        /// <param name="nextLink"> Link to the next page of results. </param>
        internal ProviderStatusList(IReadOnlyList<ProviderStatus> values, string nextLink)
        {
            Values = values;
            NextLink = nextLink;
        }
        /// <summary> Link to the next page of results. </summary>
        public string NextLink { get; }
    }
}
