﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data;

namespace DragonFruit.Six.Developer.Requests
{
    public class PublicTokenRequest : ApiRequest
    {
        public override string Path => "https://dragon6.dragonfruit.network/api/token";

        public override bool RequireAuth => false;
    }
}
