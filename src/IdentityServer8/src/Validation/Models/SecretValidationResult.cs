/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 

 Copyright (c) 2018, Brock Allen & Dominick Baier. All rights reserved.

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.Validation
{
    /// <summary>
    /// Validation result for secrets
    /// </summary>
    public class SecretValidationResult : ValidationResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether the secret validation was successful.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the value of the confirmation method (will become the cnf claim). Must be a JSON object.
        /// </summary>
        /// <value>
        /// The confirmation.
        /// </value>
        public string Confirmation { get; set; }
    }
}