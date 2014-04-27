using System;
using System.Collections.Generic;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Branches;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests;
using IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Repositories;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Contracts.Users;
using NUnit.Framework;
using IsKernel.ServieClients.Bitbucket.Tests.TestHelpers;

namespace IsKernel.ServieClients.Bitbucket.Tests.Clients
{
	[TestFixture]
	public class BitbucketPullRequestClientTests : BitbucketClientTestsBase
	{
		private IBitbucketPullRequestClient _client;
		
		[SetUp]
		public override void Setup()
		{
			base.Setup();
			_client = _mainClient.PullRequestClient;
		}
		
		[TearDown]
		public void TearDown()
		{
			
		}
		
		[Test]
		public void GetAllAsync_ReadPullRequests_PullRequestsAreRetrieved()
		{
			var states = new List<PullRequestState>()
			{
				PullRequestState.Open
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, states, new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<PullRequest>>(result);
		}
		
		[Test]
		public void CreateAsync_CreatePullRequest_PullRequestIsCreated()
		{
			var pullRequest = new PullRequest()
			{
				Title = "pull request title",
				Source = new CommitLocation()
				{
					Branch = new Branch()
					{
						Name = "default"
					},
					Repository = new Repository()
					{
						FullName = _defaultUser+"/"+_defaultRepository
					}
				},
				Destination = new CommitLocation()
				{
					Branch = new Branch()
					{
						Name = "default"
					},
					Commit = new Commit()
					{
						Hash = _defaultCommit
					}
				},
				Reviewers = new User[1]
				{
					new User()
					{
						Username = _defaultUser
					}
				},
				CloseSourceBranch = false
			};
			var result = _client.CreateAsync(_defaultUser, _defaultRepository, pullRequest).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PullRequest>(result);			
		}
	}
}
