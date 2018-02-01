using System;
using NzbDrone.Common.Http;
using System.Collections.Generic;
using NLog;
using NzbDrone.Common.Extensions;
using NzbDrone.Common.Serializer;
using NzbDrone.Core.MetadataSource.SkyHook.Resource;

namespace NzbDrone.Core.NetImport.Radarr
{
    public class RadarrRequestGenerator : INetImportRequestGenerator
    {
        public RadarrSettings Settings { get; set; }
        public IHttpClient HttpClient { get; set; }
        public Logger Logger { get; set; }

        public int MaxPages { get; set; }

        public RadarrRequestGenerator()
        {
            MaxPages = 3;
        }

        public virtual NetImportPageableRequestChain GetMovies()
        {
            var pageableRequests = new NetImportPageableRequestChain();

            var baseUrl = $"{Settings.APIURL.TrimEnd("/")}";

            var paramsString = "";

            if (!Settings.HideAdult)
            {
                paramsString += "&adult=true";
            }

            if (Settings.YearRange.IsNotNullOrWhiteSpace() && Settings.YearRange.Contains("<>"))
            {
                paramsString += $"&year={Settings.YearRange}";
            }

            if (Settings.PopularityRange.IsNotNullOrWhiteSpace() && Settings.PopularityRange.Contains("<>"))
            {
                paramsString += $"&popularity={Settings.PopularityRange}";
            }

            if (Settings.AdditionalParameters.IsNotNullOrWhiteSpace())
            {
                paramsString += Settings.AdditionalParameters;
            }

            var url = $"{baseUrl}{Settings.Path}";
            if (!url.Contains("?"))
            {
                url += "?";
                paramsString = paramsString.TrimStart('&');
            }
            
            var request = new NetImportRequest($"{url}{paramsString}", HttpAccept.Json);

            request.HttpRequest.SuppressHttpError = true;

            pageableRequests.Add(new List<NetImportRequest> { request });
            return pageableRequests;
        }
    }
}