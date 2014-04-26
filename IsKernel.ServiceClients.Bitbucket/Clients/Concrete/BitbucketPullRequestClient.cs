using System;
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
		
		private const string PULL_REQUEST_BASE_URL_1 = "https://bitbucket.org/api/1.0/repositories";
		private const string PULL_REQUEST_BASE_URL_2 = "https://api.bitbucket.org/2.0/repositories";
		
		private const string DEFAULT_PULL_REQUEST_RESOURCE = @"/{owner}/{repo_slug}";
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
											     			    MultiValueRequestParameter<PullRequestState> states,
														        PaginatedRequest paginatedRequest)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_1;
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			parameters.Add(states.Name, states.ParameterValue);
			var request = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<PullRequest>>(DEFAULT_PULL_REQUEST_RESOURCE, request);
			return task;
		}
	
		public Task<string> CreateAsync(string owner, string reposlug, PullRequest pullRequest)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var taskCompletionSource = new TaskCompletionSource<string>();
			var request = new RestRequest(DEFAULT_PULL_REQUEST_RESOURCE, Method.POST);
			
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.RequestFormat = DataFormat.Json;
			request.AddBody(pullRequest);
			
			_client.ExecuteAsync(request, response => {
				try {
					taskCompletionSource.SetResult(response.Content);
				} catch (Exception exception) {
					var bitbucketException = new BitbucketException("Could not post pull request", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;			
		}
	
		public Task<string> EditAsync(string owner, string reposlug, long id, PullRequest pullRequest)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var taskCompletionSource = new TaskCompletionSource<string>();
			var request = new RestRequest(DEFAULT_PULL_REQUEST_RESOURCE, Method.PUT);
			
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.AddUrlSegment(ID_SEGMENT, id.ToString());
			request.RequestFormat = DataFormat.Json;
			request.AddBody(pullRequest);
			
			_client.ExecuteAsync(request, response => {
				try {
					taskCompletionSource.SetResult(response.Content);
				} catch (Exception exception) {
					var bitbucketException = new BitbucketException("Could not edit pull request", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;	
		}
		
		public Task<PullRequest> GetAsync(string owner, string reposlug, long id)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var taskCompletionSource = new TaskCompletionSource<PullRequest>();
			var request = new RestRequest(DEFAULT_PULL_REQUEST_RESOURCE, Method.GET);
			
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.AddUrlSegment(ID_SEGMENT, id.ToString());
			
			request.Method = Method.GET;
			_client.ExecuteAsync(request, response => 
			{
				try 
				{
					var result = JsonConvert.DeserializeObject<PullRequest>(response.Content);
					taskCompletionSource.SetResult(result);
				} 
				catch (Exception exception) 
				{
					var bitbucketException = new BitbucketException("Could not read repository pull request.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;	
		}
	
		public Task<PaginatedResponse<Commit>> GetCommitsAsync(string owner, string reposlug, long id,
															   PaginatedRequest paginatedRequest)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(ID_SEGMENT, id.ToString());
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var request = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<Commit>>(COMMITS_SPECIFIED_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
	
		public Task<string> ApproveAsync(string owner, string reposlug, long id)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var taskCompletionSource = new TaskCompletionSource<string>();
			var request = new RestRequest(APPROVE_PULL_REQUEST_RESOURCE, Method.POST);
			
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.AddUrlSegment(ID_SEGMENT, id.ToString());
			
			_client.ExecuteAsync(request, response => {
				try {
					taskCompletionSource.SetResult(response.Content);
				} catch (Exception exception) {
					var bitbucketException = new BitbucketException("Could approve pull request.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;	
		}
		
		public Task<string> DisapproveAsync(string owner, string reposlug, long id)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var taskCompletionSource = new TaskCompletionSource<string>();
			var request = new RestRequest(APPROVE_PULL_REQUEST_RESOURCE, Method.DELETE);
			
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.AddUrlSegment(ID_SEGMENT, id.ToString());
			
			_client.ExecuteAsync(request, response => 
			{
				try 
				{
					taskCompletionSource.SetResult(response.Content);
				} 
				catch (Exception exception) 
				{
					var bitbucketException = new BitbucketException("Could approve pull request.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;	
		}
		
		public Task<string> GetDiffAsync(string owner, string reposlug, long id, long numberOfContextLines)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var taskCompletionSource = new TaskCompletionSource<string>();
			var request = new RestRequest(DIFF_SPECIFIED_PULL_REQUEST_RESOURCE, Method.GET);
			
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.AddUrlSegment(ID_SEGMENT, id.ToString());
			request.AddParameter("context", numberOfContextLines);
			
			_client.ExecuteAsync(request, response => 
			{
				try 
				{
					taskCompletionSource.SetResult(response.Content);
				} 
				catch (Exception exception) 
				{
					var bitbucketException = new BitbucketException("Could get diff for pull request.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}

			});			
			return taskCompletionSource.Task;	
		}

		public Task<PaginatedResponse<Activity>> GetAllActivityAsync(string owner, string reposlug,
																	 PaginatedRequest paginatedRequest)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var request = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<Activity>>(COMMITS_SPECIFIED_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
	
		public Task<Activity> GetActivityAsync(string owner, string reposlug, long pullRequestId, 
											   PaginatedRequest paginatedRequest)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var request = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<Activity>(ACTIVITY_SPECIFIC_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
	
		public Task<PullRequest> AcceptAsync(string owner, string reposlug, long pullRequestId,
										     string message = "", bool closeSourceBranch = false)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var taskCompletionSource = new TaskCompletionSource<PullRequest>();
			var request = new RestRequest(MERGE_PULL_REQUEST_RESOURCE, Method.POST);
			
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.AddUrlSegment(PULL_REQUEST_ID_SEGMENT, pullRequestId.ToString());
			if(message != string.Empty)
			{
				request.AddParameter("message", message);
			}
			if(closeSourceBranch == true)
			{
				request.AddParameter("close_source_branch", closeSourceBranch);
			}
			_client.ExecuteAsync(request, response => 
			{
				try 
				{
					var result = JsonConvert.DeserializeObject<PullRequest>(response.Content);
					taskCompletionSource.SetResult(result);
				} 
				catch (Exception exception) 
				{
					var bitbucketException = new BitbucketException("Could not do merge.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}
			});			
			return taskCompletionSource.Task;	
		}
		
		public Task<PullRequest> DeclineAsync(string owner, string reposlug, long pullRequestId, string message = "")
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var taskCompletionSource = new TaskCompletionSource<PullRequest>();
			var request = new RestRequest(DECLINE_PULL_REQUEST_RESOURCE, Method.POST);
			
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.AddUrlSegment(PULL_REQUEST_ID_SEGMENT, pullRequestId.ToString());
			if(message != string.Empty)
			{
				request.AddParameter("message", message);
			}
			_client.ExecuteAsync(request, response => 
			{
				try 
				{
					var result = JsonConvert.DeserializeObject<PullRequest>(response.Content);
					taskCompletionSource.SetResult(result);
				} 
				catch (Exception exception) 
				{
					var bitbucketException = new BitbucketException("Could not do decline.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}
			});			
			return taskCompletionSource.Task;	
		}
		
		public Task<PaginatedResponse<Comment>> GetCommentsAsync(string owner, string reposlug, long pullRequestId,
																 PaginatedRequest paginatedRequest)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var segments = CreateDefaultSegmentsDictionary(owner, reposlug);
			segments.Add(PULL_REQUEST_ID_SEGMENT, pullRequestId.ToString());
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var request = new RestComplexRequest(Method.GET, segments, parameters);
			var task = MakeAsyncRequest<PaginatedResponse<Comment>>(COMMENTS_PULL_REQUEST_RESOURCE, request);
			return task;	
		}
		
		public Task<Comment> GetCommentAsync(string owner, string reposlug, long pullRequestId, long commentId)
		{
			_client.BaseUrl = PULL_REQUEST_BASE_URL_2;
			var taskCompletionSource = new TaskCompletionSource<Comment>();
			var request = new RestRequest(COMMENTS_PULL_REQUEST_RESOURCE, Method.GET);
			
			request.AddUrlSegment(OWNER_SEGMENT, owner);
			request.AddUrlSegment(REPO_SLUG_SEGMENT, reposlug);
			request.AddUrlSegment(PULL_REQUEST_ID_SEGMENT, pullRequestId.ToString());
			request.AddUrlSegment(COMMENT_ID_SEGMENT, commentId.ToString());

			_client.ExecuteAsync(request, response => 
			{
				try 
				{
					var result = JsonConvert.DeserializeObject<Comment>(response.Content);
					taskCompletionSource.SetResult(result);
				} 
				catch (Exception exception) 
				{
					var bitbucketException = new BitbucketException("Could not retrieve comment for pull request.", exception);
					taskCompletionSource.SetException(bitbucketException);
				}
			});			
			return taskCompletionSource.Task;	
		}
	}

}