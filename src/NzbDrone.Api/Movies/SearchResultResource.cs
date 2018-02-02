using System.Collections.Generic;
using System.Data.SQLite;
using NzbDrone.Api.Movie;
using NzbDrone.Api.REST;
using NzbDrone.Common.Extensions;
using NzbDrone.Core.Movies;


namespace NzbDrone.Api.Movies
{
    public class SearchResultResource : RestResource
    {
        public IList<MovieResource> Movies { get; set; }
        public IList<CollectionSearchResource> Collections { get; set; }
        public IList<PersonSearchResource> Persons { get; set; }
    }

    public static class SearchResultResourceMapper
    {
        public static SearchResultResource ToResource(this SearchResult searchResult)
        {
            return new SearchResultResource
            {
                Movies = searchResult.Movies.ToResource(),
                Collections = searchResult.Collections.SelectList(CollectionResourceMapper.ToResource),
                Persons = searchResult.Persons.SelectList(PersonResourceMapper.ToResource)
            };
        }
    }
}
