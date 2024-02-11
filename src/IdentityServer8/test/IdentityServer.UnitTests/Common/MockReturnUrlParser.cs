/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 

 Copyright (c) 2018, Brock Allen & Dominick Baier. All rights reserved.

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Linq;
using System.Threading.Tasks;
using IdentityServer8.Models;
using IdentityServer8.Services;

namespace IdentityServer.UnitTests.Common
{
    public class MockReturnUrlParser : ReturnUrlParser
    {
        public AuthorizationRequest AuthorizationRequestResult { get; set; }
        public bool IsValidReturnUrlResult { get; set; }

        public MockReturnUrlParser() : base(Enumerable.Empty<IReturnUrlParser>())
        {
        }

        public override Task<AuthorizationRequest> ParseAsync(string returnUrl)
        {
            return Task.FromResult(AuthorizationRequestResult);
        }

        public override bool IsValidReturnUrl(string returnUrl)
        {
            return IsValidReturnUrlResult;
        }
    }
}