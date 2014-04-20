using System;
using System.IO;
using System.Linq;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Clients.Concrete;
using NUnit.Framework;

namespace IsKernel.ServieClients.Bitbucket.Tests
{
	[TestFixture]
	public class BitbucketRepositoryClientTests
	{
		private IBitbucketClient _client;
		private string _token;
		private string _tokenSecret;
		
		[SetUp]
		public void Setup()
		{
			var keys = File.ReadAllText("ApiKeys.txt")
					   .Split(Environment.NewLine.ToCharArray())
					   .Where(line => string.IsNullOrWhiteSpace(line) == false)
					   .ToArray();
			var apiKey = keys[0];
			var apiSecretKey = keys[1];
			_token = keys[2];
			_tokenSecret = keys[3];
			var authClient = new BitbucketAuthentificationClient(apiKey, apiSecretKey);		
			_client = authClient.AuthentificateWithAccessToken(_token, _tokenSecret);
		}
		
		[Test]
		public void GetRepositoryAsync_ReadARepository_RepositoryIsRetrieved()
		{
			var repository = _client.RepositoryClient.GetRepositoryAsync("btaranu", "ttftopng").Result;
			Assert.IsNotNull(repository);
		}
		
	}
}
