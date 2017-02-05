using KingTravels_Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace API_Hotel
{
    public class APIHotel
    {
        private static readonly APIHotel _instance;

        static APIHotel()
        {
            _instance = new APIHotel();
        }

        public static APIHotel Instance()
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
                //HttpWebResponse WebResponse = (HttpWebResponse)request.GetResponse();
                //Stream responseStream = WebResponse.GetResponseStream();
                
                //WebResponse.Close();
                //responseStream.Close();
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
