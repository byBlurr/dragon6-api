﻿// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using DragonFruit.Common.Data.Helpers;
using DragonFruit.Six.API.Data.Containers;
using DragonFruit.Six.API.Data.Strings;
using DragonFruit.Six.API.Helpers;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class AccountInfoDeserializer
    {
        public static IEnumerable<AccountInfo> DeserializeAccountInfo(this JObject jObject)
        {
            var json = JArray.FromObject(jObject[Misc.Profile]);

            foreach (var jToken in json)
            {
                var item = (JObject)jToken;
                yield return new AccountInfo
                {
                    PlayerName = item.GetString(Accounts.Name),
                    Platform = PlatformParser.PlatformEnumFor(item.GetString(Accounts.Platform)),
                    Identifiers = new UserIdentifierContainer
                    {
                        Profile = item.GetString(Accounts.ProfileIdentifier),
                        Platform = item.GetString(Accounts.PlatformIdentifier),
                        Ubisoft = item.GetString(Accounts.UserIdentifier)
                    }
                };
            }
        }
    }
}
