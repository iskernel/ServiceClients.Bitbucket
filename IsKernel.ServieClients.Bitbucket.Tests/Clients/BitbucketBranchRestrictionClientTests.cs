using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
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
	public class BitbucketBranchRestrictionClientTests : BitbucketClientTestsBase
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
			var testName = TestContext.CurrentContext.Test.Name;
			if(testName == "AddAsync_AddBranchRestriction_BranchIsRetrieved")
			{
				var paginatedRequest = new PaginatedRequest();
				var restrictions = _client.GetAllAsync(_defaultUser, _defaultRepository, paginatedRequest).Result;
				var deleteResult = _client.DeleteAsync(_defaultUser, _defaultRepository, restrictions.Values[0].Id.ToString()).Result;
			}
			else if(testName == "GetAsync_GetFirstBranchRestriction_FirstBranchRestrictionRetrieved")
			{
				var paginatedRequest = new PaginatedRequest();
				var restrictions = _client.GetAllAsync(_defaultUser, _defaultRepository, paginatedRequest).Result;
				var deleteResult = _client.DeleteAsync(_defaultUser, _defaultRepository, restrictions.Values[0].Id.ToString()).Result;
			}
			else if(testName == "EditAsync_EditBranchRestriction_BranchIsEdited")
			{
				var paginatedRequest = new PaginatedRequest();
				var restrictions = _client.GetAllAsync(_defaultUser, _defaultRepository, paginatedRequest).Result;
				var deleteResult = _client.DeleteAsync(_defaultUser, _defaultRepository, restrictions.Values[0].Id.ToString()).Result;
			}
		}
		
		[Test]
		public void GetAllAsync_GetAllBranchRestrictions_MultipleBranchRestrictionsAreRetrieved()
		{
			var paginatedRequest = new PaginatedRequest();
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository,paginatedRequest).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<BranchRestriction>>(result);
		}
		
		[Test]
		public void GetAsync_GetFirstBranchRestriction_FirstBranchRestrictionRetrieved()
		{
			var branchRestriction = new BranchRestriction()
			{
				Kind = BranchRestrictionType.Delete.Value,
				Pattern = "pattern",
			};			
			var paginatedRequest = new PaginatedRequest();
			var result = _client.AddAsync(_defaultUser, _defaultRepository, branchRestriction).Result;
			var restrictions = _client.GetAllAsync(_defaultUser, _defaultRepository, paginatedRequest).Result;
			var restriction = _client.GetAsync(_defaultUser, _defaultRepository,  restrictions.Values[0].Id.ToString()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<BranchRestriction>(restriction);
		}
		
		[Test]
		public void AddAsync_AddBranchRestriction_BranchIsRetrieved()
		{
			var branchRestriction = new BranchRestriction()
			{
				Kind = BranchRestrictionType.Delete.Value,
				Pattern = "pattern",
			};						
			var result = _client.AddAsync(_defaultUser, _defaultRepository, branchRestriction).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<BranchRestriction>(result);
		}
		
		[Test]
		public void EditAsync_EditBranchRestriction_BranchIsEdited()
		{
			var branchRestriction = new BranchRestriction()
			{
				Kind = BranchRestrictionType.Delete.Value,
				Pattern = "pattern",
			};
			
			var paginatedRequest = new PaginatedRequest();
			var result = _client.AddAsync(_defaultUser, _defaultRepository, branchRestriction).Result;
			var restrictions = _client.GetAllAsync(_defaultUser, _defaultRepository, paginatedRequest).Result;
			var id = restrictions.Values[0].Id.ToString();
			result.Pattern = "newPattern";
			var newResult = _client.EditAsync(_defaultUser, _defaultRepository, id, result).Result;
			bool condition = (newResult.Pattern == "newPattern");
			Assert.IsTrue(condition);
		}
		
		[Test]
		public void DeleteAsync_DeleteBranchRestriction_BranchIsRetrieved()
		{
			var branchRestriction = new BranchRestriction()
			{
				Kind = BranchRestrictionType.Delete.Value,
				Pattern = "pattern",
			};
			var paginatedRequest = new PaginatedRequest();
			var addResult = _client.AddAsync(_defaultUser, _defaultRepository, branchRestriction).Result;
			var restrictions = _client.GetAllAsync(_defaultUser, _defaultRepository, paginatedRequest).Result;
			var deleteResult = _client.DeleteAsync(_defaultUser, _defaultRepository, restrictions.Values[0].Id.ToString()).Result;
			bool condition = (string.IsNullOrWhiteSpace(deleteResult) == true);
			Assert.IsTrue(condition);
		}
	}
}
