/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 

 Copyright (c) 2018, Brock Allen & Dominick Baier. All rights reserved.

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using IdentityServer8.Models;
using System.Collections.Generic;

namespace IdentityServer8.Validation
{
    /// <summary>
    /// Models the request to validate scopes and resource indicators for a client.
    /// </summary>
    public class ResourceValidationRequest
    {
        /// <summary>
        /// The client.
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// The requested scope values.
        /// </summary>
        public IEnumerable<string> Scopes { get; set; }

        // /// <summary>
        // /// The requested resource indicators.
        // /// </summary>
        //  todo: add back when we support resource indicators
        // public IEnumerable<string> ResourceIndicators { get; set; }
    }
}