using System.Collections.Generic;
using NzbDrone.Api.Movie;
using NzbDrone.Api.REST;
using NzbDrone.Core.Movies;

namespace NzbDrone.Api.Movies
{
    public class CollectionSearchResource : RestResource
    {
        public CollectionSearchResource()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<MovieResource> Movies { get; set; }
    }

    public static class CollectionResourceMapper
    {
        public static CollectionSearchResource ToResource(this Collection searchResult)
        {
            return new CollectionSearchResource
            {
                Movies = searchResult.Movies.ToResource(),
                Id = searchResult.Id,
                Name = searchResult.Name
            };
        }
    }
}
