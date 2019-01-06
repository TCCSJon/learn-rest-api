using APIWrapper.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APITestSuite
{
    [TestClass]
    public class SampleE2EMoviesTests : APITestBase
    {
        MyMovieAPIWrapper moviesAPI = new MyMovieAPIWrapper();

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [TestCategory("Regression")]
        [TestMethod]
        public void GetAllMovies_MoviesController_4DefaultMoviesSuccess()
        {
            // ARRANGE


            // ACT
            var ret = moviesAPI.GetAllMovies();

            // ASSERT
            Assert.AreEqual(4, ret.Count);
        }
    }
}
