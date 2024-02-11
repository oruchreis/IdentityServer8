/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 
 

 Copyright (c) 2018, Brock Allen & Dominick Baier. All rights reserved.

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using IdentityServer8.Extensions;
using IdentityServer8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer8.Stores
{
    /// <summary>
    /// In-memory resource store
    /// </summary>
    public class InMemoryResourcesStore : IResourceStore
    {
        private readonly IEnumerable<IdentityResource> _identityResources;
        private readonly IEnumerable<ApiResource> _apiResources;
        private readonly IEnumerable<ApiScope> _apiScopes;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryResourcesStore" /> class.
        /// </summary>
        public InMemoryResourcesStore(
            IEnumerable<IdentityResource> identityResources = null, 
            IEnumerable<ApiResource> apiResources = null, 
            IEnumerable<ApiScope> apiScopes = null)
        {
            if (identityResources?.HasDuplicates(m => m.Name) == true)
            {
                throw new ArgumentException("Identity resources must not contain duplicate names");
            }

            if (apiResources?.HasDuplicates(m => m.Name) == true)
            {
                throw new ArgumentException("Api resources must not contain duplicate names");
            }
            
            if (apiScopes?.HasDuplicates(m => m.Name) == true)
            {
                throw new ArgumentException("Scopes must not contain duplicate names");
            }

            _identityResources = identityResources ?? Enumerable.Empty<IdentityResource>();
            _apiResources = apiResources ?? Enumerable.Empty<ApiResource>();
            _apiScopes = apiScopes ?? Enumerable.Empty<ApiScope>();
        }

        /// <inheritdoc/>
        public Task<Resources> GetAllResourcesAsync()
        {
            var result = new Resources(_identityResources, _apiResources, _apiScopes);
            return Task.FromResult(result);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            if (apiResourceNames == null) throw new ArgumentNullException(nameof(apiResourceNames));

            var query = from a in _apiResources
                        where apiResourceNames.Contains(a.Name)
                        select a;
            return Task.FromResult(query);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

            var identity = from i in _identityResources
                           where scopeNames.Contains(i.Name)
                           select i;

            return Task.FromResult(identity);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

            var query = from a in _apiResources
                        where a.Scopes.Any(x => scopeNames.Contains(x))
                        select a;

            return Task.FromResult(query);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

            var query =
                from x in _apiScopes
                where scopeNames.Contains(x.Name)
                select x;
            
            return Task.FromResult(query);
        }
    }
}