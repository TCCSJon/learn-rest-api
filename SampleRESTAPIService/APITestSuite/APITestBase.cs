using APIWrapper.Wrappers;

namespace APITestSuite
{
    public class APITestBase
    {
        private MyMovieAPIWrapper moviesAPI => new MyMovieAPIWrapper();

        public APITestBase()
        {

        }

        public MyMovieAPIWrapper GetMovieAPI()
        {
            return this.moviesAPI;
        }
    }
}
