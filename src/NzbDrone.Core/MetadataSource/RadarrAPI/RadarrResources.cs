using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
namespace NzbDrone.Core.MetadataSource.RadarrAPI
{
    public class Error
    {
        [JsonProperty("id")]
        public string RayId { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }

    public class RadarrError
    {
        [JsonProperty("errors")]
        public IList<Error> Errors { get; set; }
    }

    public class RadarrAPIException : Exception
    {
        public RadarrError APIErrors;

        public RadarrAPIException(RadarrError apiError) : base(HumanReadable(apiError))
        {
            APIErrors = apiError;
        }

        private static string HumanReadable(RadarrError apiErrors)
        {
            var firstError = apiErrors.Errors.First();
            var details = string.Join("\n", apiErrors.Errors.Select(error =>
            {
                return $"{error.Title} ({error.Status}, RayId: {error.RayId}), Details: {error.Detail}";
            }));
           return $"Error while calling api: {firstError.Title}\nFull error(s): {details}";
        }
    }

    public class TitleInfo
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("aka_title")]
        public string AkaTitle { get; set; }

        [JsonProperty("aka_clean_title")]
        public string AkaCleanTitle { get; set; }
    }

    public class YearInfo
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("aka_year")]
        public int AkaYear { get; set; }
    }

    public class Title
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tmdbid")]
        public int Tmdbid { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("info_type")]
        public string InfoType { get; set; }

        [JsonProperty("info_id")]
        public int InfoId { get; set; }

        [JsonProperty("info")]
        public TitleInfo Info { get; set; }
    }

    public class Year
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("tmdbid")]
        public int Tmdbid { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("info_type")]
        public string InfoType { get; set; }

        [JsonProperty("info_id")]
        public int InfoId { get; set; }

        [JsonProperty("info")]
        public YearInfo Info { get; set; }
    }

    public class Mappings
    {

        [JsonProperty("titles")]
        public IList<Title> Titles { get; set; }

        [JsonProperty("years")]
        public IList<Year> Years { get; set; }
    }

    public class Mapping
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("mappings")]
        public Mappings Mappings { get; set; }
    }

    public class AddTitleMapping
    {

        [JsonProperty("tmdbid")]
        public string Tmdbid { get; set; }

        [JsonProperty("info_type")]
        public string InfoType { get; set; }

        [JsonProperty("info_id")]
        public int InfoId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("info")]
        public TitleInfo Info { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }
    }

    public class AddYearMapping
    {

        [JsonProperty("tmdbid")]
        public string Tmdbid { get; set; }

        [JsonProperty("info_type")]
        public string InfoType { get; set; }

        [JsonProperty("info_id")]
        public int InfoId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("info")]
        public YearInfo Info { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }
    }

    // V3 API

    public class Cast
    {
        public int id { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public string profile_path { get; set; }
        public object department { get; set; }
        public object job { get; set; }
        public int order { get; set; }
        public string character { get; set; }
    }

    public class Crew
    {
        public int id { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public string profile_path { get; set; }
        public string department { get; set; }
        public string job { get; set; }
        public object order { get; set; }
        public object character { get; set; }
    }

    public class Credits
    {
        public IList<Cast> cast { get; set; }
        public IList<Crew> crew { get; set; }
    }

    public class Trailer
    {
        public int id { get; set; }
        public string iso_639_1 { get; set; }
        public string iso_3166_1 { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string site { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public int movie_id { get; set; }
    }

    public class Movie
    {
        public int id { get; set; }
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int budget { get; set; }
        public int? collection_id { get; set; }
        public string homepage { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public string updated_at { get; set; }
        public Credits credits { get; set; }
        public IList<Genre> genres { get; set; }
        public Collection collection { get; set; }
        public IList<Keyword> keywords { get; set; }
        public Trailer trailer { get; set; }
        public IList<Rating> ratings { get; set; }
        public IList<ReleaseDate> release_dates { get; set; }
        public IList<AlternativeTitle> alternative_titles { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Keyword
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Rating
    {
        public int movie_id { get; set; }
        public double voting_average { get; set; }
        public int voting_count { get; set; }
        public string origin { get; set; }
    }

    public class ReleaseDate
    {
        public int movie_id { get; set; }
        public int type { get; set; }
        public string certification { get; set; }
        public string date { get; set; }
        public string note { get; set; }
        public string iso_3166_1 { get; set; }
        public string iso_639_1 { get; set; }
    }

    public class AlternativeTitle
    {
        public int movie_id { get; set; }
        public string title { get; set; }
        public string iso_3166_1 { get; set; }
    }

    public class Collection
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<Movie> movies { get; set; }
    }

    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public string profile_path { get; set; }
        public string department { get; set; }
        public string job { get; set; }
        public string character { get; set; }
        public int order { get; set; }
        public IList<Movie> movies { get; set; }
    }

    public class MultiSearchResult
    {
        public IList<Movie> movies { get; set; }
        public IList<Collection> collections { get; set; }
        public IList<Person> persons { get; set; }
    }

}
