using System;
using System.IO;
using System.Net;


namespace Chat_Core
{
    public class Request
    {
        private static bool s_Initialized = false;

        private static void Initialize()
        {
            //ssl backdoor
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertificatesCallback);
        }

        public static JsonPacket Send(JsonPacket packet)
        {
            if (!s_Initialized)
                Initialize();

            string json_request = packet.Serialize();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.HOST);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = json_request.Length;

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json_request);
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)request.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string response = streamReader.ReadToEnd();
                    return JsonPacket.Deserialize(response.ToString());

                }
            }

        }

        private static bool AcceptAllCertificatesCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }


    }
}
