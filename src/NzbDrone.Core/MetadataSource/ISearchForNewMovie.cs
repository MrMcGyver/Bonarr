using System.Collections.Generic;
using NzbDrone.Core.Movies;
using NzbDrone.Core.Tv;

namespace NzbDrone.Core.MetadataSource
{
    public interface ISearchForNewMovie
    {
        SearchResult SearchForNewMovie(string title);

        Movie MapMovieToTmdbMovie(Movie movie);

        Movie MapMovie(SkyHook.Resource.MovieResult result);
    }
}
