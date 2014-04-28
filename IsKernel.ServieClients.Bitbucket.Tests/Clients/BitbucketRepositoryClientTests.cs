using System;
using System.IO;
using System.Linq;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;
using NUnit.Framework;
using IsKernel.ServieClients.Bitbucket.Tests.TestHelpers;

namespace IsKernel.ServieClients.Bitbucket.Tests.Clients
{
	[TestFixture]
	public class BitbucketRepositoryClientTests : BitbucketClientTestsBase
	{		
		private IBitbucketRepositoryClient _client;
		
		[SetUp]
		public override void Setup()
		{
			base.Setup();
			var testName = TestContext.CurrentContext.Test.Name;
			if( (testName != "GetAllRepositoryForkForAsync_GetForks_ForksAreRetrieved") 
				&& (testName != "GetRepositoryAsync_ReadARepository_RepositoryIsRetrieved")
				&& (testName != "GetRepositoryWatchersAsync_ReadWatchers_WatchersAreRetrieved"))
			{
				_defaultRepository = "testrepository";
			}
			_client = _mainClient.RepositoryClient;
		}
		
		[TearDown]
		public void Teardown()
		{
			if(TestContext.CurrentContext.Test.Name 
				== "CreateRepositoryAsync_CreateARepository_RepositoryIsCreated")
			{
				var result = _client.DeleteAsync(_defaultUser, _defaultRepository).Result;
			}
		}
		
		[Test]
		public void GetRepositoryAsync_ReadARepository_RepositoryIsRetrieved()
		{
			var repository = _client.GetAsync(_defaultUser, _defaultRepository).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<Repository>(repository);
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
			var result = _client.CreateAsync(_defaultUser, _defaultRepository, parameters).Result;
			var repository = _client.GetAsync(_defaultUser, _defaultRepository).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<Repository>(repository);
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
			var createResult = _client.CreateAsync(_defaultUser, _defaultRepository, parameters).Result;
			var deleteResult = _client.DeleteAsync(_defaultUser, _defaultRepository).Result;
			Assert.IsNullOrEmpty(deleteResult);
		}
		
		[Test]
		public void GetRepositoryWatchersAsync_ReadWatchers_WatchersAreRetrieved()
		{
			var paginatedRequest = new PaginatedRequest();
			var users = _client.GetWatchersAsync(_defaultUser, _defaultRepository, 
												 paginatedRequest).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<User>>(users);
		}
		
		[Test]
		public void GetAllRepositoryForkForAsync_GetForks_ForksAreRetrieved()
		{
			var paginatedRequest = new PaginatedRequest();
			var forks = _client.GetForksAsync(_defaultUser, _defaultRepository, 
											  paginatedRequest).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<Repository>>(forks);
		}
		
		[Test]
		public void GetAllRepositoriesForUserAsync_GetRepositories_RepositoriesAreRetrieved()
		{
			var paginatedRequest = new PaginatedRequest();
			var repositories = _client.GetAllAsync(_defaultUser, paginatedRequest).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<Repository>>(repositories);
		}
		
		[Test]
		public void GetAllPublicRepositoriesAsync_GetRepositories_RepositoriesAreRetrieved()
		{
			var paginatedRequest = new PaginatedRequest();
			var repositories = _client.GetAllPublicAsync(paginatedRequest).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<Repository>>(repositories);
		}
	}
}
