using System;
using System.IO;
using System.Linq;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Clients.Concrete;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Requests;
using IsKernel.ServiceClients.Bitbucket.Models.Repositories;
using NUnit.Framework;

namespace IsKernel.ServieClients.Bitbucket.Tests
{
	[TestFixture]
	public class BitbucketRepositoryClientTests
	{
		private enum LastRunnedTest
		{
			CreateRepositoryAsync_CreateARepository_RepositoryIsCreated
		};
		
		private IBitbucketClient _client;
		private string _token;
		private string _tokenSecret;
		private string _defaultUser;
		private string _defaultRepository;
		private LastRunnedTest _lastTest;
		
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
			
			var authClient = new BitbucketAuthenticationClient(apiKey, apiSecretKey);		
			_client = authClient.AuthentificateWithAccessToken(_token, _tokenSecret);
			_defaultUser = "btaranu";
			_defaultRepository = "testrepository";
		}
		
		[TearDown]
		public void Teardown()
		{
			if(_lastTest == LastRunnedTest.CreateRepositoryAsync_CreateARepository_RepositoryIsCreated)
			{
				var result = _client.RepositoryClient.DeleteRepositoryAsync(_defaultUser, _defaultRepository).Result;
			}
		}
		
		[Test]
		public void GetRepositoryAsync_ReadARepository_RepositoryIsRetrieved()
		{
			var repository = _client.RepositoryClient.GetRepositoryAsync("btaranu", "ttftopng").Result;
			Assert.IsNotNull(repository);
		}
		
		[Test]
		public void CreateRepositoryAsync_CreateARepository_RepositoryIsCreated()
		{
			var parameters = new RepositoryAddOptionalParametersModel(Scm.Hg, ForkingPolicy.NoForks, true)
			{
				HasIssues = true,
				HasWiki = true,
				Language = "c"
			};			
			var result = _client.RepositoryClient.CreateRepositoryAsync(_defaultUser, _defaultRepository, parameters).Result;
			var repository = _client.RepositoryClient.GetRepositoryAsync(_defaultUser, _defaultRepository).Result;
			_lastTest = LastRunnedTest.CreateRepositoryAsync_CreateARepository_RepositoryIsCreated;
			bool condition = (result == true) && (repository != null);
			Assert.IsNotNull(repository);
		}
		
		[Test]
		public void DeleteRepositoryAsync_DeleteARepository_RepositoryIsDeleted()
		{
			var parameters = new RepositoryAddOptionalParametersModel(Scm.Hg, ForkingPolicy.NoForks, true)
			{
				HasIssues = true,
				HasWiki = true,
				Language = "c"
			};			
			var createResult = _client.RepositoryClient.CreateRepositoryAsync(_defaultUser, _defaultRepository, parameters).Result;
			var repository = _client.RepositoryClient.GetRepositoryAsync(_defaultUser, _defaultRepository).Result;
			var deleteResult = _client.RepositoryClient.DeleteRepositoryAsync(_defaultUser, _defaultRepository).Result;
			Assert.IsTrue(deleteResult);
		}
	}
}
