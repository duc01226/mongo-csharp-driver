﻿/* Copyright 2020-present MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using MongoDB.Driver.Core.Misc;

namespace MongoDB.Driver.Core.Authentication
{
    /// <summary>
    /// Represents an authenticator factory.
    /// </summary>
    [Obsolete("This class will be made internal in a later release.")]
    public class AuthenticatorFactory : IAuthenticatorFactory
    {
        private readonly Func<IAuthenticator> _authenticatorFactoryFunc;

        /// <summary>
        /// Create an authenticatorFactory.
        /// </summary>
        /// <param name="authenticatorFactoryFunc">The authenticatorFactoryFunc.</param>
        public AuthenticatorFactory(Func<IAuthenticator> authenticatorFactoryFunc)
        {
            _authenticatorFactoryFunc = Ensure.IsNotNull(authenticatorFactoryFunc, nameof(authenticatorFactoryFunc));
        }

        /// <inheritdoc/>
        public IAuthenticator Create()
        {
            return _authenticatorFactoryFunc();
        }
    }
}
