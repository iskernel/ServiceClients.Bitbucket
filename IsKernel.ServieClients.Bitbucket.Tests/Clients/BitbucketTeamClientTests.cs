using System;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Teams;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;
using NUnit.Framework;
using IsKernel.ServieClients.Bitbucket.Tests.TestHelpers;

namespace IsKernel.ServieClients.Bitbucket.Tests.Clients
{
	[TestFixture]
	public class BitbucketTeamClientTests : BitbucketClientTestsBase
	{
		private IBitbucketTeamClient _client;
		
		[SetUp]
		public override void Setup()
		{
			base.Setup();
			_client = _mainClient.TeamClient;
		}
		
		[TearDown]
		public void Teardown()
		{
			
		}
		
		[Test]
		public void GetProfileAsync_GetProfile_ProfileIsRetrieved()
		{
			var profile = _client.GetProfileAsync(_defaultTeam).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<Team>(profile);
		}
		
		[Test]
		public void GetMembersAsync_GetMembers_MembersAreRetrieved()
		{
			var results = _client.GetMembersAsync(_defaultTeam, new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<User>>(results);
		}
		
		[Test]
		public void GetFollowersAsync_GetFollowers_FollowersAreRetrieved()
		{
			var results = _client.GetFollowersAsync(_defaultTeam, new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<User>>(results);
		}
		
		[Test]
		public void GetFollowingAsync_GetFollowing_FollowingAreRetrieved()
		{
			var results = _client.GetFollowingAsync(_defaultTeam, new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<User>>(results);
		}
		
		[Test]
		public void GetRepositoriesAsync_GetRepositories_RepositoriesAreRetrieved()
		{
			var results = _client.GetRepositoriesAsync(_defaultTeam, new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<Repository>>(results);
		}		
	}
}
