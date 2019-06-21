﻿// ------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

using System.Collections.Generic;
using Microsoft.OData.Edm.Vocabularies;
using Microsoft.OpenApi.OData.Common;
using Microsoft.OpenApi.OData.Core;
using Microsoft.OpenApi.OData.Edm;

namespace Microsoft.OpenApi.OData.Capabilities
{
    /// <summary>
    /// Complex type: Org.OData.Capabilities.V1.CustomParameter
    /// </summary>
    internal class CustomParameter
    {
        /// <summary>
        /// Gets/sets the name of the custom parameter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets/sets the description of the custom parameter.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets/sets the documentationURL of the custom parameter.
        /// </summary>
        public string DocumentationURL { get; set; }

        /// <summary>
        /// Gets/sets the reuired of the custom parameter. true: parameter is required, false or not specified: parameter is optional.
        /// </summary>
        public bool? Required { get; set; }

        /// <summary>
        /// Gets the list of scopes that can provide access to the resource.
        /// </summary>s
        public IList<PrimitiveExampleValue> ExampleValues { get; set; }

        /// <summary>
        /// Init the <see cref="CustomParameter"/>.
        /// </summary>
        /// <param name="record">The input record.</param>
        public void Init(IEdmRecordExpression record)
        {
            Utils.CheckArgumentNull(record, nameof(record));

            // Name
            Name = record.GetString("Name");

            // Description
            Description = record.GetString("Description");

            // DocumentationURL
            DocumentationURL = record.GetString("DocumentationURL");

            // Required
            Required = record.GetBoolean("Required");

            // ExampleValues
            ExampleValues = record.GetCollection<PrimitiveExampleValue>("ExampleValues", (r, s) => r.Init(s));
        }
    }
}
