using System.Collections.Generic;
using NzbDrone.Api.Movie;
using NzbDrone.Api.REST;
using NzbDrone.Core.MediaCover;
using NzbDrone.Core.MetadataSource.RadarrAPI;

namespace NzbDrone.Api.Movies
{
    public class PersonSearchResource : RestResource
    {
        public PersonSearchResource()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public List<MediaCover> Images { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
        public IList<MovieResource> Movies { get; set; }
    }

    public static class PersonResourceMapper
    {
        public static PersonSearchResource ToResource(this Core.Movies.Person searchResult)
        {
            return new PersonSearchResource
            {
                Movies = searchResult.Movies.ToResource(),
                Id = searchResult.Id,
                Name = searchResult.Name,
                Images = searchResult.Images
            };
        }
    }
}
