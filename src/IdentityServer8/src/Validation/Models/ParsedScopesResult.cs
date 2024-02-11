/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 

 Copyright (c) 2018, Brock Allen & Dominick Baier. All rights reserved.

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Collections.Generic;
using System.Linq;

namespace IdentityServer8.Validation
{
    /// <summary>
    /// Represents the result of scope parsing.
    /// </summary>
    public class ParsedScopesResult
    {
        /// <summary>
        /// The valid parsed scopes.
        /// </summary>
        public ICollection<ParsedScopeValue> ParsedScopes { get; set; } = new HashSet<ParsedScopeValue>();

        /// <summary>
        /// The errors encountered while parsing.
        /// </summary>
        public ICollection<ParsedScopeValidationError> Errors { get; set; } = new HashSet<ParsedScopeValidationError>();

        /// <summary>
        /// Indicates if the result of parsing the scopes was successful.
        /// </summary>
        public bool Succeeded => Errors == null || !Errors.Any();
    }
}