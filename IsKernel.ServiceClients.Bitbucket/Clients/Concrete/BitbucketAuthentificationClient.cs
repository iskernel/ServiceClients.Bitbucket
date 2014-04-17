using System;
using System.Security;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Infrastructure;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketAuthentificationClient : IBitbucketAuthentificationClient
	{
		private const string AUTHENTIFICATION_URL = "https://api.bitbucket.org/1.0/";
		private const string API_KEY_NAME = "oauth_token";
		private const string API_KEY_SECRET = "oauth_token_secret";
		
		private readonly IAuthenticator _authentificator;
		private readonly SecureString _key;
		private readonly SecureString _secretKey;
		
		public BitbucketAuthentificationClient(string apiKey, string secretApiKey)
		{
			_key = apiKey.ToSecureString();
			_secretKey = secretApiKey.ToSecureString();
			_authentificator = new SimpleAuthenticator(API_KEY_NAME, _key.ConvertToUnsecureString(),
													   API_KEY_SECRET, _secretKey.ConvertToUnsecureString());
			BitbucketClient = new BitbucketClient(_authentificator);
		}
				
		public IBitbucketClient BitbucketClient {get;set;}
	}
}
