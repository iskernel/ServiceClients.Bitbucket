using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests;
using IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Infrastructure;
using IsKernel.ServiceClients.Bitbucket.Infrastructure.Rest;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketPullRequestClient : BitbucketRepositoryClientBase, IBitbucketPullRequestClient
	{
		private const string ID_SEGMENT = "id";
		private const string PULL_REQUEST_ID_SEGMENT = "pull_request_id";
		private const string COMMENT_ID_SEGMENT = "comment_id";		
		
		private const string NUMBER_OF_CONTEXT_LINES_PARAMETER = "num_lines";
		private const string MESSAGE_PARAMETER = "message";
		private const string CLOSE_SOURCE_BRANCH_PARAMETER = "close_source_branch";
		
		private const string PULL_REQUEST_BASE_URL_1 = "https://bitbucket.org/api/1.0/repositories";
		private const string PULL_REQUEST_BASE_URL_2 = "https://api.bitbucket.org/2.0/repositories";
		
		private const string DEFAULT_PULL_REQUEST_RESOURCE = @"/{owner}/{repo_slug}/pullrequests";
		private const string ACTIVITY_PULL_REQUEST_RESOURCE = @"/{owner}/{repo_slug}/pullrequests/activity";
		private const string ACTIVITY_SPECIFIC_PULL_REQUEST_RESOURCE 
							 = @"/{owner}/{repo_slug}/pullrequests/{pull_request_id}/activities";	
		private const string MERGE_PULL_REQUEST_RESOURCE 
							 = @"/{owner}/{repo_slug}pullrequests/{pull_request_id}/merge";
		private const string DECLINE_PULL_REQUEST_RESOURCE 
							 = @"/{owner}/{repo_slug}/pullrequests/{pull_request_id}/decline";
		private const string COMMENTS_PULL_REQUEST_RESOURCE 
							 = @"/{owner}/{repo_slug}/pullrequests/{pull_request_id}/comments";
		private const string SPECIFIC_COMMENT_PULL_REQUEST_RESOURCE 
							 = @"/{owner}/{repo_slug}/pullrequests/{pull_request_id}/comments/{comment_id}";
		private const string SPECIFIED_PULL_REQUEST_RESOURCE = @"/{owner}/{repo_slug}/{id}";
		private const string APPROVE_PULL_REQUEST_RESOURCE = @"/{owner}/{repo_slug}/{id}/approve";
		private const string COMMITS_SPECIFIED_PULL_REQUEST_RESOURCE = @"/{owner}/{repo_slug}/{id}/commits";
		private const string DIFF_SPECIFIED_PULL_REQUEST_RESOURCE = @"/{owner}/{repo_slug}/{id}/commits";
		
		public BitbucketPullRequestClient(IAuthenticator authentificator) : base(authentificator, PULL_REQUEST_BASE_URL_2)
		{
			
		}
		
		public Task<PaginatedResponse<PullRequest>> GetAllAsync(string owner, string reposlug, 
											     			    IEnumerable<PullRequestState> statesValues,
														        PaginatedRequest paginatedRequest)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var states = new MultiValueRequestParameter<PullRequestState>("state", statesValues);
			parameters.Add(states.Name, states.ParameterValue);
			var request = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<PullRequest>>(DEFAULT_PULL_REQUEST_RESOURCE, request);
			return task;
		}
	
		public Task<PullRequest> CreateAsync(string owner, string reposlug, PullRequest pullRequest)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var request = new RestComplexDataRequest(Method.POST, segments, null, null, pullRequest, 
													 RestDataContentType.Json);
			System.Diagnostics.Debug.WriteLine(pullRequest.Serialize());
			var task = MakeAsyncRequest<PullRequest>(DEFAULT_PULL_REQUEST_RESOURCE, request);
			return task;		
		}
	
		public Task<PullRequest> EditAsync(string owner, string reposlug, long id, PullRequest pullRequest)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(ID_SEGMENT, id.ToString());
			var request = new RestComplexDataRequest(Method.PUT, segments, null, null, pullRequest, 
													 RestDataContentType.Json);
			var task = MakeAsyncRequest<PullRequest>(DEFAULT_PULL_REQUEST_RESOURCE, request);
			return task;
		}
		
		public Task<PullRequest> GetAsync(string owner, string reposlug, long id)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(ID_SEGMENT, id.ToString());
			var request = new RestComplexRequest(Method.GET, segments, null, null);
			var task = MakeAsyncRequest<PullRequest>(DEFAULT_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
	
		public Task<PaginatedResponse<Commit>> GetCommitsAsync(string owner, string reposlug, long id,
															   PaginatedRequest paginatedRequest)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(ID_SEGMENT, id.ToString());
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var request = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<Commit>>(COMMITS_SPECIFIED_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
	
		public Task<string> ApproveAsync(string owner, string reposlug, long id)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(ID_SEGMENT, id.ToString());
			var request = new RestComplexRequest(Method.POST, segments, null, null);
			var task = MakeAsyncRequest<string>(APPROVE_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
		
		public Task<string> DisapproveAsync(string owner, string reposlug, long id)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(ID_SEGMENT, id.ToString());
			var request = new RestComplexRequest(Method.DELETE, segments, null, null);
			var task = MakeAsyncRequest<string>(APPROVE_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
		
		public Task<string> GetDiffAsync(string owner, string reposlug, long id, long numberOfContextLines = 3L)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(ID_SEGMENT, id.ToString());
			Dictionary<string,string> parameters = null;
			if(numberOfContextLines != 3L)
			{
				parameters = new Dictionary<string,string>();
				parameters.Add(NUMBER_OF_CONTEXT_LINES_PARAMETER, numberOfContextLines.ToString());
			}
			var request = new RestComplexRequest(Method.GET, segments, parameters, null);
			var task = MakeAsyncRequest<string>(DIFF_SPECIFIED_PULL_REQUEST_RESOURCE, request);
			return task;	
		}

		public Task<PaginatedResponse<Activity>> GetAllActivityAsync(string owner, string reposlug,
																	 PaginatedRequest paginatedRequest)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var request = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<Activity>>(COMMITS_SPECIFIED_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
	
		public Task<Activity> GetActivityAsync(string owner, string reposlug, long pullRequestId, 
											   PaginatedRequest paginatedRequest)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var request = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<Activity>(ACTIVITY_SPECIFIC_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
	
		public Task<PullRequest> AcceptAsync(string owner, string reposlug, long pullRequestId,
										     string message = "", bool closeSourceBranch = false)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);			
			segments.Add(PULL_REQUEST_ID_SEGMENT, pullRequestId.ToString());
			var parameters = new Dictionary<string,string>();
			parameters.Add(MESSAGE_PARAMETER, message);
			parameters.Add(CLOSE_SOURCE_BRANCH_PARAMETER, closeSourceBranch.ToString());
			var request = new RestComplexRequest(Method.POST, segments, parameters, null);
			var task = MakeAsyncRequest<PullRequest>(MERGE_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
		
		public Task<PullRequest> DeclineAsync(string owner, string reposlug, long pullRequestId, string message = "")
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);			
			segments.Add(PULL_REQUEST_ID_SEGMENT, pullRequestId.ToString());
			var parameters = new Dictionary<string,string>();
			parameters.Add(MESSAGE_PARAMETER, message);
			var request = new RestComplexRequest(Method.POST, segments, parameters, null);
			var task = MakeAsyncRequest<PullRequest>(DECLINE_PULL_REQUEST_RESOURCE, request);
			return task;
		}
		
		public Task<PaginatedResponse<Comment>> GetCommentsAsync(string owner, string reposlug, long pullRequestId,
																 PaginatedRequest paginatedRequest)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(PULL_REQUEST_ID_SEGMENT, pullRequestId.ToString());
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var request = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<Comment>>(COMMENTS_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
		
		public Task<Comment> GetCommentAsync(string owner, string reposlug, long pullRequestId, long commentId)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(PULL_REQUEST_ID_SEGMENT, pullRequestId.ToString());
			segments.Add(COMMENT_ID_SEGMENT, commentId.ToString());
			var request = new RestComplexRequest(Method.GET, segments, null, null);
			var task = MakeAsyncRequest<Comment>(COMMENTS_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
	}

}