﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Net.Http;
using System.Text;
using DragonFruit.Common.Data;
using DragonFruit.Six.API.Data.Requests.Base;

namespace DragonFruit.Six.API.Data.Requests
{
    internal sealed class TokenRequest : UbiApiRequest
    {
        public override string Path => Endpoints.IdServer + "/sessions";
        protected override Methods Method => Methods.Post;
        protected override DataTypes DataType => DataTypes.Custom;
        public override bool RequireAuth => true;

        //tokens need an empty request body in UTF8, with app/json type...
        public override HttpContent BodyContent => new StringContent(string.Empty, Encoding.UTF8, "application/json");

        /// <summary>
        /// Initialises a new <see cref="TokenRequest"/> with a pre-encoded b64 login
        /// </summary>
        public TokenRequest(string b64Login)
        {
            Headers.Value.Add("Authorization", $"Basic {b64Login}");
        }
    }
}
