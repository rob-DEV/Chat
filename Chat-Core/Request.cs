﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Chat_Core
{
    public class Request
    {
        private static bool s_Initialized = false;

        private static void Initialize()
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertificatesCallback);
        }

        public static string Send(Dictionary<string, string> data)
        {
            if (!s_Initialized)
                Initialize();

            string json_request = JsonConvert.SerializeObject(data);
            string json_response = string.Empty;

          
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Config.HOST);

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

                    json_response = response.ToString();

                }
            }

            return json_response;

        }

        public static bool AcceptAllCertificatesCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }


    }
}