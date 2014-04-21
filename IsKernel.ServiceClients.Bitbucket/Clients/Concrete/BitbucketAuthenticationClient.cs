using System;
using System.Security;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Contrib;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Exceptions;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketAuthenticationClient : IBitbucketAuthenticationClient
	{
		private const string AUTHENTIFICATION_URL = "https://bitbucket.org/api/1.0/";
	
		private readonly string _key;
		private readonly string _secretKey;
		private string _oauthToken;
		private string _oauthTokenSecret; 
		private string _oauthTokenForAccess;
		private string _oauthTokenSecretForAccess;
		
		public BitbucketAuthenticationClient(string apiKey, string secretApiKey)
		{
			_key = apiKey;
			_secretKey = secretApiKey;
		}
		
		public Task<Uri> RequestTokenAsync(string callbackUrl = "oob")
		{
			var taskCompletionSource = new TaskCompletionSource<Uri>();			
			var client = new RestClient(AUTHENTIFICATION_URL);			
			client.Authenticator = OAuth1Authenticator.ForRequestToken(_key, _secretKey, callbackUrl);			
			var request = new RestRequest("oauth/request_token", Method.POST);
			request.UseDefaultCredentials = true;			
			client.ExecuteAsync(request, response => 
				{
					if(response.StatusCode != System.Net.HttpStatusCode.OK)
					{
						var exception = new BitbucketException("OAuth step failed.");
						taskCompletionSource.SetException(exception);
					}
					var queryString = HttpUtility.ParseQueryString(response.Content);
					_oauthToken = queryString["oauth_token"];
					_oauthTokenSecret = queryString["oauth_token_secret"];
					
					if( (string.IsNullOrWhiteSpace(_oauthToken) == true) 
						|| (string.IsNullOrWhiteSpace(_oauthTokenSecret) == true) )
					{
						var exception = new BitbucketException("OAuth tokens not received.");
						taskCompletionSource.SetException(exception);
					}					
					request = new RestRequest("oauth/authenticate", Method.GET);
		            request.AddParameter("oauth_token", _oauthToken);
					var uri = client.BuildUri(request);
					taskCompletionSource.SetResult(uri);
				}
			);
            return taskCompletionSource.Task;		
		}
		
		public Task<IBitbucketClient> AuthentificateAsync(string verifier)
		{
			if(_oauthToken == null)
			{
				throw new BitbucketException("No token request was made. Call RequestTokenAsync first.");
			}
			var taskCompletionSource = new TaskCompletionSource<IBitbucketClient>();	
			var client = new RestClient(AUTHENTIFICATION_URL);		
			client.Authenticator = OAuth1Authenticator.ForAccessToken(
				_key, _secretKey, _oauthToken, _oauthTokenSecret, verifier
			);
			var request = new RestRequest("oauth/access_token", Method.POST);		
			client.ExecuteAsync(request, response =>
			{
				 var queryString = HttpUtility.ParseQueryString(response.Content);
            	 _oauthTokenForAccess = queryString["oauth_token"];
            	 _oauthTokenSecretForAccess = queryString["oauth_token_secret"];
				if( (string.IsNullOrWhiteSpace(_oauthTokenForAccess) == true) 
					|| (string.IsNullOrWhiteSpace(_oauthTokenSecretForAccess) == true) )
				{
					var exception = new BitbucketException("Access tokens were not received");
					taskCompletionSource.SetException(exception);
				}
				var authentificator = OAuth1Authenticator.ForProtectedResource(
										 				  _key, _secretKey, 
										 				  _oauthTokenForAccess, _oauthTokenSecretForAccess);
				System.Diagnostics.Debug.WriteLine(_oauthTokenForAccess + "\n" + _oauthTokenSecretForAccess);
				var bitbucketClient = new BitbucketClient(authentificator);
				taskCompletionSource.SetResult(bitbucketClient);
			});
			return taskCompletionSource.Task;
			
		}
		
		public IBitbucketClient AuthentificateWithAccessToken(string token, string secretToken)
		{
			var authentificator = OAuth1Authenticator.ForProtectedResource(
										 				  _key, _secretKey, 
										 				  _oauthTokenForAccess, _oauthTokenSecretForAccess);
			var bitbucketClient = new BitbucketClient(authentificator);
			return bitbucketClient;
		}
		
		public IBitbucketClient AuthentificateWithLogin(string username, string password)
		{
			var authentificator = new HttpBasicAuthenticator(username, password);
			var bitbucketClient = new BitbucketClient(authentificator);
			return bitbucketClient;
		}		
	}
}
