using Newtonsoft.Json;
using RevolutAPI.Models.JWT;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RevolutAPI.Helpers
{
    public class JWTSigner
    {
        public static string SignData(JWTPayload payload,byte[] privateKey,string certificatePassword)
        {
            X509Certificate2 x509Certificate2 = new X509Certificate2(privateKey,certificatePassword);


            JWTHeader header = new JWTHeader();
            string jsonHeader = JsonConvert.SerializeObject(header);
            string jsonPayload = JsonConvert.SerializeObject(payload);
            byte[] bytesHeader = Encoding.UTF8.GetBytes(jsonHeader);
            byte[] bytesPaylod = Encoding.UTF8.GetBytes(jsonPayload); 
            List<string> segments = new List<string>();
            segments.Add(Base64UrlEncode(bytesHeader));
            segments.Add(Base64UrlEncode(bytesPaylod));
            byte[] bytesToSign = Encoding.UTF8.GetBytes(string.Join(".", segments.ToArray()));

            using (RSA rsa = x509Certificate2.GetRSAPrivateKey())
            {
                byte[] signedData = rsa.SignData(bytesToSign, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                segments.Add(Base64UrlEncode(signedData));
                return string.Join(".", segments.ToArray());
            }
        }

        // from JWT spec
        private static string Base64UrlEncode(byte[] input)
        {
            var output = Convert.ToBase64String(input);
            output = output.Split('=')[0]; // Remove any trailing '='s
            output = output.Replace('+', '-'); // 62nd char of encoding
            output = output.Replace('/', '_'); // 63rd char of encoding
            return output;
        }
    }
}
