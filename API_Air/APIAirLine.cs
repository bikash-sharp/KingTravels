using KingTravels_Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;

namespace API_Air
{
    public enum JourneyType
    {
        OneWay=1,
        Return=2,
        MultiStop=3,
        AdvanceSearch=4,
        SpecialReturn=5
    }
    public enum CabinClass
    {
        All=1,
        Economy=2,
        PremiumEconomy=3,
        Business=4,
        PremiumBusiness=5,
        First=6
    }
    public class APIAirLine
    {
        private static readonly APIAirLine _instance;

        static APIAirLine()
        {
            _instance = new APIAirLine();
        }

        public static APIAirLine Instance()
        {
            return _instance;
        }

        public string GetResponse(string url, Verbs verb, string requestData)
        {
            string responseXml = string.Empty;
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(requestData);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = verb.ToString();
                request.ContentType = "application/json";
                request.ContentLength = 4294967295;
                request.SendChunked = true;
                request.AutomaticDecompression = DecompressionMethods.GZip;
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip");
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(data, 0, data.Length);
                dataStream.Close();
                dataStream.Dispose();
                using (var webResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (var responseStream = webResponse.GetResponseStream())
                    {
                        var currentStream = responseStream;
                        if (currentStream != null)
                        {
                            if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
                                currentStream = new GZipStream(responseStream, CompressionMode.Decompress);
                            else if (webResponse.ContentEncoding.ToLower().Contains("deflate"))
                                currentStream = new DeflateStream(responseStream, CompressionMode.Decompress);

                            using (var reader = new StreamReader(currentStream, Encoding.Default))
                            {
                                responseXml = reader.ReadToEnd();
                            }
                        }
                    }
                }
                return responseXml;
            }
            catch (WebException webEx)
            {
                //get the response stream
                var response = webEx.Response;
                var stream = response?.GetResponseStream();
                if (stream != null) responseXml = new StreamReader(stream).ReadToEnd();
            }
            return responseXml;
        }


    }

}
