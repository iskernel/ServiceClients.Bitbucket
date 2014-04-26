using System;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Branches;
using IsKernel.ServiceClients.Bitbucket.Contracts.Branches.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;
using NUnit.Framework;
using IsKernel.ServieClients.Bitbucket.Tests.TestHelpers;

namespace IsKernel.ServieClients.Bitbucket.Tests.Clients
{
	[TestFixture]
	public class BitbucketBranchRestrictionClientTests : BitbucketClientTestBase
	{
		private string _defaultUser;
		private string _defaultRepository;
		private IBitbucketBranchRestrictionClient _client;
		
		[SetUp]
		public override void Setup()
		{
			base.Setup();
			_client = _mainClient.BranchRestrictionClient;
			_defaultUser = "btaranu";
			_defaultRepository = "apitest";
		}
		
		[TearDown]
		public void TearDown()
		{
			
		}
		
		[Test]
		public void GetAllAsync_GetAllBranchRestrictions_MultipleBranchRestrictionsAreRetrieved()
		{
			var paginatedRequest = new PaginatedRequest();
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository,paginatedRequest).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<BranchRestriction>>(result);
		}
		
		[Test]
		public void AddAsync_AddBranchRestriction_BranchIsRetrieved()
		{
			//TODO See why branch restriction post information is not ok
			var branchRestriction = new BranchRestriction()
			{
				Kind = BranchRestrictionType.Delete.Value,
				Pattern = ".*",
			};
			var result = _client.AddAsync(_defaultUser, _defaultRepository, branchRestriction).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<BranchRestriction>(result);
		}
		
		[Test]
		public void DeleteAsync_DeleteBranchRestriction_BranchIsRetrieved()
		{
			//TODO See why branch restriction post information is not ok
			var branchRestriction = new BranchRestriction()
			{
				Kind = BranchRestrictionType.Delete.Value,
			};
			var paginatedRequest = new PaginatedRequest();
			var addResult = _client.AddAsync(_defaultUser, _defaultRepository, branchRestriction).Result;
			var restrictions = _client.GetAllAsync(_defaultUser, _defaultRepository, paginatedRequest).Result;
			var deleteResult = _client.DeleteAsync(_defaultUser, _defaultRepository, restrictions.Values[0].Id.ToString()).Result;
			bool condition = (string.IsNullOrWhiteSpace(deleteResult) == false);
			Assert.IsTrue(condition);
		}
	}
}
