using System.Net;

namespace APIWrapper
{
    public static class HTTPHelper
    {
        public static HttpWebRequest CreateHTTPRequest(string URL, string verbose)
        {
            var httpReq = (HttpWebRequest)WebRequest.CreateHttp(URL);
            httpReq.ContentType = "application/json";
            httpReq.Method = verbose;
            return httpReq;
        }
    }
}
