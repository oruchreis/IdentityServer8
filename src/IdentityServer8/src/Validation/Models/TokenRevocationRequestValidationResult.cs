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

namespace IdentityServer8.Validation
{
    /// <summary>
    /// Models the validation result of access tokens and id tokens.
    /// </summary>
    public class TokenRevocationRequestValidationResult : ValidationResult
    {
        /// <summary>
        /// Gets or sets the token type hint.
        /// </summary>
        /// <value>
        /// The token type hint.
        /// </value>
        public string TokenTypeHint { get; set; }
        
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        public Client Client { get; set; }
    }
}