using System.Collections.Generic;
using NzbDrone.Core.Tv;

namespace NzbDrone.Core.Movies
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public List<MediaCover.MediaCover> Images { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
        public IList<Movie> Movies { get; set; }
    }
}
