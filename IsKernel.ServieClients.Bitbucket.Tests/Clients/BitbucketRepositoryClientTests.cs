using System;
using System.IO;
using System.Linq;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Clients.Concrete;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using NUnit.Framework;

namespace IsKernel.ServieClients.Bitbucket.Tests.Clients
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
		private string _defaultRepositoryForGet;
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
			_defaultRepositoryForGet = "ttftopng";
		}
		
		[TearDown]
		public void Teardown()
		{
			if(_lastTest == LastRunnedTest.CreateRepositoryAsync_CreateARepository_RepositoryIsCreated)
			{
				var result = _client.RepositoryClient.DeleteAsync(_defaultUser, _defaultRepository).Result;
			}
		}
		
		[Test]
		public void GetRepositoryAsync_ReadARepository_RepositoryIsRetrieved()
		{
			var repository = _client.RepositoryClient.GetAsync(_defaultUser, _defaultRepositoryForGet).Result;
			Assert.IsNotNull(repository);
		}
		
		[Test]
		public void CreateRepositoryAsync_CreateARepository_RepositoryIsCreated()
		{
			var parameters = new RepositoryCreateOptionalParameters(Scm.Hg, ForkingPolicy.NoForks, true)
			{
				HasIssues = true,
				HasWiki = true,
				Language = "c"
			};			
			var result = _client.RepositoryClient.CreateAsync(_defaultUser, _defaultRepository, parameters).Result;
			var repository = _client.RepositoryClient.GetAsync(_defaultUser, _defaultRepository).Result;
			_lastTest = LastRunnedTest.CreateRepositoryAsync_CreateARepository_RepositoryIsCreated;
			bool condition = (result == true) && (repository != null);
			Assert.IsNotNull(repository);
		}
		
		[Test]
		public void DeleteRepositoryAsync_DeleteARepository_RepositoryIsDeleted()
		{
			var parameters = new RepositoryCreateOptionalParameters(Scm.Hg, ForkingPolicy.NoForks, true)
			{
				HasIssues = true,
				HasWiki = true,
				Language = "c"
			};			
			var createResult = _client.RepositoryClient.CreateAsync(_defaultUser, _defaultRepository, parameters).Result;
			var deleteResult = _client.RepositoryClient.DeleteAsync(_defaultUser, _defaultRepository).Result;
			Assert.IsTrue(deleteResult);
		}
		
		[Test]
		public void GetRepositoryWatchersAsync_ReadWatchers_WatchersAreRetrieved()
		{
			var paginatedRequest = new PaginatedRequest(10, 1);
			var users = _client.RepositoryClient.GetWatchersAsync("tutorials", "tutorials.bitbucket.org", 
																   paginatedRequest).Result;
			Assert.IsNotNull(users);
		}
		
		[Test]
		public void GetAllRepositoryForkForAsync_GetForks_ForksAreRetrieved()
		{
			var paginatedRequest = new PaginatedRequest(10, 1);
			var forks = _client.RepositoryClient.GetForksAsync("tutorials", "tutorials.bitbucket.org", 
																paginatedRequest).Result;
			Assert.IsNotNull(forks);
		}
		
		[Test]
		public void GetAllRepositoriesForUserAsync_GetRepositories_RepositoriesAreRetrieved()
		{
			var paginatedRequest = new PaginatedRequest(10, 1);
			var repositories = _client.RepositoryClient.GetAllAsync("tutorials", paginatedRequest).Result;
			Assert.IsNotNull(repositories);
		}
		
		[Test]
		public void GetAllPublicRepositoriesAsync_GetRepositories_RepositoriesAreRetrieved()
		{
			var paginatedRequest = new PaginatedRequest(10, 1);
			var repositories = _client.RepositoryClient.GetAllPublicAsync(paginatedRequest).Result;
			Assert.IsNotNull(repositories);
		}
	}
}
