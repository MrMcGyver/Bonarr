using System.Collections.Generic;
using NzbDrone.Core.MetadataSource.SkyHook.Resource;
using NzbDrone.Core.Tv;

namespace NzbDrone.Core.Movies
{
    public class SearchResult
    {
        public SearchResult()
        {
            Movies = new List<Movie>();
            Collections = new List<Collection>();
            Persons = new List<Person>();
        }

        public IList<Movie> Movies { get; set; }
        public IList<Collection> Collections { get; set; }
        public IList<Person> Persons { get; set; }
    }
}
