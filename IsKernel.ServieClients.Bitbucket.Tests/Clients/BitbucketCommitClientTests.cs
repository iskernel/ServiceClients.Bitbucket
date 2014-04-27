using System;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Clients.Concrete;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using NUnit.Framework;
using IsKernel.ServieClients.Bitbucket.Tests.TestHelpers;

namespace IsKernel.ServieClients.Bitbucket.Tests.Clients
{
	[TestFixture]
	public class BitbucketCommitClientTests : BitbucketClientTestsBase
	{
		private IBitbucketCommitClient _client;
		
		[SetUp]
		public override void Setup()
		{
			base.Setup();
			_client = _mainClient.CommitClient;
		}
		
		[TearDown]
		public void Teardown()
		{
			
		}
		
		[Test]
		public void GetAllAsync_GetAll_CommitsAreRetrieved()
		{
			var optional = new CommitGetOptionalParameters("master", null, null);
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, new PaginatedRequest(), optional).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault(result);
		}
		
		[Test]
		public void GetAsync_GetCommit_CommitsIsRetrieved()
		{
			var result = _client.GetAsync(_defaultUser, _defaultRepository, "1bf1868").Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault(result);
		}
		
		[Test]
		public void GetCommentsAsync_GetComments_CommentsIsRetrieved()
		{
			var result = _client.GetCommentsAsync(_defaultUser, _defaultRepository, "1bf1868", new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault(result);
		}
		
		[Test]
		public void GetCommentAsync_GetComment_CommentIsRetrieved()
		{
			var result = _client.GetCommentAsync(_defaultUser, _defaultRepository, "1bf1868", "908279").Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault(result);
		}
		
	}
}
