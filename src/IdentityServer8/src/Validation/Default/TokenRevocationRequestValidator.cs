/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 

 Copyright (c) 2018, Brock Allen & Dominick Baier. All rights reserved.

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using IdentityModel;
using IdentityServer8.Extensions;
using IdentityServer8.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace IdentityServer8.Validation
{
    /// <summary>
    /// The token revocation request validator
    /// </summary>
    /// <seealso cref="IdentityServer8.Validation.ITokenRevocationRequestValidator" />
    internal class TokenRevocationRequestValidator : ITokenRevocationRequestValidator
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRevocationRequestValidator"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public TokenRevocationRequestValidator(ILogger<TokenRevocationRequestValidator> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// parameters
        /// or
        /// client
        /// </exception>
        public Task<TokenRevocationRequestValidationResult> ValidateRequestAsync(NameValueCollection parameters, Client client)
        {
            _logger.LogTrace("ValidateRequestAsync called");

            if (parameters == null)
            {
                _logger.LogError("no parameters passed");
                throw new ArgumentNullException(nameof(parameters));
            }

            if (client == null)
            {
                _logger.LogError("no client passed");
                throw new ArgumentNullException(nameof(client));
            }

            ////////////////////////////
            // make sure token is present
            ///////////////////////////
            var token = parameters.Get("token");
            if (token.IsMissing())
            {
                _logger.LogError("No token found in request");
                return Task.FromResult(new TokenRevocationRequestValidationResult
                {
                    IsError = true,
                    Error = OidcConstants.TokenErrors.InvalidRequest
                });
            }

            var result = new TokenRevocationRequestValidationResult
            {
                IsError = false,
                Token = token,
                Client = client
            };

            ////////////////////////////
            // check token type hint
            ///////////////////////////
            var hint = parameters.Get("token_type_hint");
            if (hint.IsPresent())
            {
                if (Constants.SupportedTokenTypeHints.Contains(hint))
                {
                    _logger.LogDebug("Token type hint found in request: {tokenTypeHint}", hint);
                    result.TokenTypeHint = hint;
                }
                else
                {
                    _logger.LogError("Invalid token type hint: {tokenTypeHint}", hint);
                    result.IsError = true;
                    result.Error = Constants.RevocationErrors.UnsupportedTokenType;
                }
            }

            _logger.LogDebug("ValidateRequestAsync result: {validateRequestResult}", result);

            return Task.FromResult(result);
        }
    }
}