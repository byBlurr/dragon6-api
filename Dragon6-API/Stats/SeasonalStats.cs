﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Dragon6.API.Stats
{
    public class Season
    {
        public int SeasonID { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Abandons { get; set; }
        public int Max_Rank { get; set; }
        public int Rank { get; set; }
        public int MMR { get; set; }

        /// <summary>
        /// Get Stats for a specific season (-1 is current)
        /// </summary>
        /// <param name="Player"></param>
        /// <param name="SeasonNumber"></param>
        /// <param name="Region"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<Season> GetSeason(AccountInfo Player, string Region,string token, int SeasonNumber = -1)
        {
            var content = await Http.Preset.GetClient(token).GetAsync($"{Http.Endpoints.RankedStats[Player.Platform]}?board_id=pvp_ranked&profile_ids={Player.GUID}&region_id={Region.ToLower()}&season_id={SeasonNumber}");

            if (content.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exceptions.TokenInvalidException("The Token Provided is invalid or has expired");

            var response = await content.Content.ReadAsStringAsync();

            return await Alignments.AlignSeason(response, Player.GUID);
        }

    }
}
