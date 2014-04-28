using System;
using System.Collections.Generic;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Branches;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;
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
			var states = new List<PullRequestState>() {
				PullRequestState.Open
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, states, new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<PullRequest>>(result);
		}
		
		[Test]
		public void CreateAsync_CreatePullRequest_PullRequestIsCreated()
		{
			var pullRequest = new PullRequest() {
				Title = "pull request title",
				Source = new CommitLocation() {
					Branch = new Branch() {
						Name = "default"
					},
					Repository = new Repository() {
						FullName = _defaultUser + "/" + _defaultRepository
					}
				},
				Destination = new CommitLocation() {
					Branch = new Branch() {
						Name = "default"
					},
					Commit = new Commit() {
						Hash = _defaultCommit
					}
				},
				Reviewers = new User[1] {
					new User() {
						Username = _defaultUser
					}
				},
				CloseSourceBranch = false
			};
			var result = _client.CreateAsync(_defaultUser, _defaultRepository, pullRequest).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PullRequest>(result);			
		}
	
		[Test]
		public void EditAsync_EditPullRequest_PullRequestIsEdited()
		{
			var states = new List<PullRequestState>() {
				PullRequestState.Open
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, states, new PaginatedRequest()).Result;
			var selectedRequest = result.Values[0];
			selectedRequest.Title = "Hey!";
			var editedPullRequest 
			= _client.EditAsync(_defaultUser, _defaultRepository, selectedRequest.Id.Value, selectedRequest).Result;
			bool condition = (editedPullRequest.Title == "Hey!");
			Assert.IsTrue(condition);
		}
		
		[Test]
		public void GetAsync_GetPullRequest_PullRequestIsRead()
		{
			var states = new List<PullRequestState>() {
				PullRequestState.Open
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, states, new PaginatedRequest()).Result;
			var pullRequest = _client.GetAsync(_defaultUser, _defaultRepository, result.Values[0].Id.Value).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PullRequest>(pullRequest);
		}
		
		[Test]
		public void GetCommitsAsync_GetPullRequestCommits_PullRequestCommitsAreRead()
		{
			var states = new List<PullRequestState>() {
				PullRequestState.Open
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, states, new PaginatedRequest()).Result;
			var list = _client.GetCommitsAsync(_defaultUser, _defaultRepository, result.Values[0].Id.Value, new PaginatedRequest())
				.Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<Commit>>(list);
		}
		
		[Test]
		public void ApproveAsync_ApprovePullRequest_PullRequestIsApproved()
		{
			var states = new List<PullRequestState>() {
				PullRequestState.Open,
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, states, new PaginatedRequest()).Result;
			var pullRequest = _client.ApproveAsync(_defaultUser, _defaultRepository, result.Values[0].Id.Value).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PullRequest>(pullRequest);
		}
		
		[Test]
		public void DisapproveAsync_DisapprovePullRequest_PullRequestIsDisapproved()
		{
			var states = new List<PullRequestState>() {
				PullRequestState.Open
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, states, new PaginatedRequest()).Result;
			var pullRequest = _client.DeclineAsync(_defaultUser, _defaultRepository, result.Values[0].Id.Value).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PullRequest>(pullRequest);
		}
		
		[Test]
		public void GetDiffAsync_GetDiffForPullRequest_DiffIsRetrieved()
		{
			var states = new List<PullRequestState>() {
				PullRequestState.Open,
				PullRequestState.Merged,
				PullRequestState.Declined
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, states, new PaginatedRequest()).Result;
			var diff = _client.GetDiffAsync(_defaultUser, _defaultRepository, result.Values[0].Id.Value).Result;
			Assert.IsNotNullOrEmpty(diff);
		}
		
		[Test]
		public void GetAllActivitiesAsync_GetActivitiesForRepository_ActivitiesRetrieved()
		{
			var result = _client.GetAllActivityAsync(_defaultUser, _defaultRepository, new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<Activity>>(result);
		}
		
		[Test]
		public void GetActivityAsync_GetActivityForPullRequest_ActivityRetrieved()
		{
			var states = new List<PullRequestState>() {
				PullRequestState.Open
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, states, new PaginatedRequest()).Result;
			var activity = _client.GetActivityAsync(_defaultUser, _defaultRepository, result.Values[0].Id.Value, 
				               new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<Activity>>(activity);
		}
		
		[Test]
		public void AcceptAsync_AcceptPullRequest_PullRequestAccepted()
		{
			var states = new List<PullRequestState>() {
				PullRequestState.Open
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, states, new PaginatedRequest()).Result;
			var pullRequest = _client.AcceptAsync(_defaultUser, _defaultRepository, result.Values[0].Id.Value).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PullRequest>(pullRequest);
		}
		
		[Test]
		public void DeclineAsync_DeclinePullRequest_PullRequestDeclined()
		{
			var states = new List<PullRequestState>() {
				PullRequestState.Open
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, states, new PaginatedRequest()).Result;
			var pullRequest = _client.DeclineAsync(_defaultUser, _defaultRepository, result.Values[0].Id.Value).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PullRequest>(pullRequest);
		}
		
		[Test]
		public void GetCommentsAsync_GetCommentsForPullRequest_CommentsRetrieved()
		{
			var states = new List<PullRequestState>() {
				PullRequestState.Open
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, 
				             states, new PaginatedRequest()).Result;
			var list = _client.GetCommentsAsync(_defaultUser, _defaultRepository,
				           result.Values[0].Id.Value, 
				           new PaginatedRequest()).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<PaginatedResponse<Comment>>(list);
		}
		
		[Test]
		public void GetCommentAsync_GetCommentForPullRequest_CommentIsRetrieved()
		{
			var states = new List<PullRequestState>() {
				PullRequestState.Open,
				PullRequestState.Merged,
				PullRequestState.Declined
			};
			var result = _client.GetAllAsync(_defaultUser, _defaultRepository, 
											 states, new PaginatedRequest()).Result;
			var list = _client.GetCommentsAsync(_defaultUser, _defaultRepository,
				          				 		result.Values[0].Id.Value, 
				           						new PaginatedRequest()).Result;
			var comment = _client.GetCommentAsync(_defaultUser, _defaultRepository, 
												  result.Values[0].Id.Value, 
												  list.Values[0].Id.Value).Result;
			AssertHelper.AtLeastOnePropertyIsNotDefault<Comment>(comment);
		}
		
	}
}
