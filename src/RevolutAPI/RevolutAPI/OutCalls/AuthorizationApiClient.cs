using RevolutAPI.Helpers;
using RevolutAPI.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RevolutAPI.OutCalls
{
    public class AuthorizationApiClient
    {

        private readonly IRevolutApiClient _apiClient;

        public AuthorizationApiClient(IRevolutApiClient client)
        {
            _apiClient = client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="privateCert">base64 encoded pfx</param>
        /// <param name="certificatePassword">password for pfx</param>
        /// <param name="issuer">issuer (redirect website without http)</param>
        /// <param name="clientId">client id</param>
        /// <param name="authCode">redirected authorization code</param>
        /// <returns></returns>
        public async Task<Result<AuthorizationCodeResp>> Authorize(string privateCert,string certificatePassword, string issuer, string clientId,string authCode)
        {
            byte[] data = System.Convert.FromBase64String(privateCert);
            string dataOutput = JWTSigner.SignData(new Models.JWT.JWTPayload
            {
                iss = issuer,
                sub = clientId
            }, data, certificatePassword);
       
            Result<AuthorizationCodeResp> auth = await _apiClient.PostFormData<AuthorizationCodeResp>("/auth/token", new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>( "grant_type", "authorization_code" ),
                new KeyValuePair<string, string>( "code", authCode ),
                new KeyValuePair<string, string>( "client_id", clientId),
                new KeyValuePair<string, string>( "client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer" ),
                new KeyValuePair<string, string>( "client_assertion", dataOutput),
            });
            return auth;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="privateCert">base64 encoded pfx</param>
        /// <param name="certificatePassword">password for pfx</param>
        /// <param name="issuer">issuer (redirect website without http)</param>
        /// <param name="clientId">client id</param>
        /// <param name="refreshToken">token which was returned as refresh token</param>
        /// <returns></returns>
        public async Task<Result<RefreshAccessTokenResp>> RefreshAccessToken(string privateCert, string certificatePassword, string issuer, string clientId, string refreshToken)
        {
            byte[] data = System.Convert.FromBase64String(privateCert);
            string dataoutput = JWTSigner.SignData(new Models.JWT.JWTPayload
            {
                iss = issuer,
                sub = clientId
            }, data, certificatePassword);

            Result<RefreshAccessTokenResp> auth = await _apiClient.PostFormData<RefreshAccessTokenResp>("/auth/token", new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>( "grant_type", "refresh_token" ),
                new KeyValuePair<string, string>( "refresh_token", refreshToken ),
                new KeyValuePair<string, string>( "client_id", clientId),
                new KeyValuePair<string, string>( "client_assertion_type", "urn:ietf:params:oauth:client-assertion-type:jwt-bearer" ),
                new KeyValuePair<string, string>( "client_assertion", dataoutput),
            });
            return auth;

        }
    }
}
