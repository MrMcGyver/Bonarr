using System.Collections.Generic;
using NzbDrone.Core.MetadataSource.SkyHook.Resource;
using NzbDrone.Core.Tv;

namespace NzbDrone.Core.Movies
{
    public class Collection
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Movie> Movies { get; set; }
    }
}
