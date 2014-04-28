using System;
using System.IO;
using System.Linq;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Clients.Concrete;

namespace IsKernel.ServieClients.Bitbucket.Tests.TestHelpers
{
	public class BitbucketClientTestsBase
	{
		private const string TEST_FILE_PATH = "ApiKeys.txt";
		
		protected IBitbucketClient _mainClient;
		
		protected string _defaultUser;
		protected string _defaultRepository;
		protected string _defaultCommit;
		
		public virtual void Setup()
		{
			var bitbucketData = File.ReadAllText(TEST_FILE_PATH)
							    .Split(Environment.NewLine.ToCharArray())
							    .Where(line => string.IsNullOrWhiteSpace(line) == false)
							    .ToArray();
			var apiKey = bitbucketData[0];
			var apiSecretKey = bitbucketData[1];
			var token = bitbucketData[2];
			var tokenSecret = bitbucketData[3];
			_defaultUser = bitbucketData[4];
			_defaultRepository = bitbucketData[5];
			_defaultCommit = bitbucketData[6];
			
			var authClient = new BitbucketAuthenticationClient(apiKey, apiSecretKey);		
			_mainClient = authClient.AuthentificateWithAccessToken(token, tokenSecret);
		}
		
	}
}
