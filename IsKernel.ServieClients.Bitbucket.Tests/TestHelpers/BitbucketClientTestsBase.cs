using System;
using System.IO;
using System.Linq;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Clients.Concrete;

namespace IsKernel.ServieClients.Bitbucket.Tests.TestHelpers
{
	public class BitbucketClientTestsBase
	{
		protected IBitbucketClient _mainClient;
		
		public virtual void Setup()
		{
			var keys = File.ReadAllText("ApiKeys.txt")
					   .Split(Environment.NewLine.ToCharArray())
					   .Where(line => string.IsNullOrWhiteSpace(line) == false)
					   .ToArray();
			var apiKey = keys[0];
			var apiSecretKey = keys[1];
			var token = keys[2];
			var tokenSecret = keys[3];
			
			var authClient = new BitbucketAuthenticationClient(apiKey, apiSecretKey);		
			_mainClient = authClient.AuthentificateWithAccessToken(token, tokenSecret);
		}
		
	}
}
