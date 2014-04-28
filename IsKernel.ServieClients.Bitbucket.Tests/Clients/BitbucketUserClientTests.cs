using System;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;
using NUnit.Framework;
using IsKernel.ServieClients.Bitbucket.Tests.TestHelpers;

namespace IsKernel.ServieClients.Bitbucket.Tests.Clients
{
	[TestFixture]
	public class BitbucketUserClientTests : BitbucketClientTestsBase
	{
		private IBitbucketUserClient _client;
		
		[SetUp]
		public override void Setup()
		{
			base.Setup();
			_client = _mainClient.UserClient;
		}
		
		[TearDown]
		public void Teardown()
		{
			
		}
		
		[Test]
		public void GetProfileAsync_GetProfile_ProfileIsRetrieved()
		{
			var profile = _client.GetProfileAsync(_defaultUser).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<User>(profile);
		}
		
		[Test]
		public void GetFollowersAsync_GetFollowers_FollowersAreRetrieved()
		{
			var results = _client.GetFollowersAsync(_defaultUser, new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<User>>(results);
		}
		
		[Test]
		public void GetFollowingAsync_GetFollowing_FollowingAreRetrieved()
		{
			var results = _client.GetFollowingAsync(_defaultUser, new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<User>>(results);
		}
		
	}
}
