using System.Collections.Generic;

namespace SampleRESTAPIService.SampleData
{
    public class DataAccessor
    {
        private static DataAccessor instance = null;
        private static readonly object padlock = new object();
        public static List<Movie> MoviesLst;

        DataAccessor()
        {
            MoviesLst = new MovieData().LoadDefaultData();
        }

        public static DataAccessor Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DataAccessor();
                    }
                    return instance;
                }
            }
        }

        public List<Movie> GetMovies()
        {
            return MoviesLst;
        }
    }
}
