using System;
using System.IO;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Clients.Concrete;
using NUnit.Framework;

namespace IsKernel.ServieClients.Bitbucket.Tests
{
	[TestFixture]
	public class BitbucketRepositoryClientTests
	{
		private IBitbucketClient _client;
		
		[SetUp]
		public void Setup()
		{
			var keys = File.ReadAllText("ApiKeys.txt").Split(Environment.NewLine.ToCharArray());
			var apiKey = keys[0];
			var apiSecretKey = keys[1];
			var authorizationClient = new BitbucketAuthentificationClient(apiKey, apiSecretKey);			
			_client = authorizationClient.BitbucketClient;
		}
		
		[SetUp]
		public void GetRepositoryAsync_ReadARepository_RepositoryIsRetrieved()
		{
			
		}
		
	}
}
