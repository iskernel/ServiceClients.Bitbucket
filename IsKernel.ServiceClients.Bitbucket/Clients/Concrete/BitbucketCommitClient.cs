using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using IsKernel.ServiceClients.Bitbucket.Clients.Abstract;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;
using IsKernel.ServiceClients.Bitbucket.Exceptions;
using IsKernel.ServiceClients.Bitbucket.Infrastructure.Rest;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Concrete
{
	public class BitbucketCommitClient : BitbucketRepositoryClientBase, IBitbucketCommitClient
	{
		private const string BRANCH_OR_TAG_SEGMENT = "branchOrTag";
		private const string REVISION_SEGMENT = "revision";
		private const string COMMENT_ID_SEGMENT = "comment_id";
		
		private const string COMMITS_BASE_URL = "https://api.bitbucket.org/2.0/repositories";
		private const string COMMITS_DEFAULT_RESOURCE =  @"/{owner}/{repo_slug}/commits";
		private const string COMMITS_BRANCH_RESOURCE =  @"/{owner}/{repo_slug}/commits/{branchOrTag}";
		
		private const string SPECIFIED_COMMIT_RESOURCE =  @"/{owner}/{repo_slug}/commit/{revision}";
		private const string SPECIFIED_COMMIT_COMMENTS_RESOURCE =  @"/{owner}/{repo_slug}/commit/{revision}/comments";
		private const string SPECIFIED_COMMIT_SPECIFIC_COMMENT_RESOURCE 
							 =  @"/{owner}/{repo_slug}/commit/{revision}/comments/{comment_id}";
		private const string APPROVE_COMMENT_RESOURCE = @"/{owner}/{repo_slug}/commit/{revision}/approve";
		
		public BitbucketCommitClient(IAuthenticator authentificator) : base(authentificator, COMMITS_BASE_URL)
		{
			
		}
		
		public Task<PaginatedResponse<Commit>> GetAllAsync(string owner, string repoSlug, 
													       PaginatedRequest paginatedRequest,
														   CommitGetOptionalParameters optional)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, repoSlug);
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var resourceUrl = string.Empty;
			if(optional.BranchOrTag != null)
			{
				resourceUrl = COMMITS_DEFAULT_RESOURCE;
				segments.Add(optional.BranchOrTag.Name, optional.BranchOrTag.Value);
			}
			else
			{
				resourceUrl = COMMITS_DEFAULT_RESOURCE;
			}
			var restRequest = new RestComplexRequest(Method.GET, segments, parameters, null);	
			var task = MakeAsyncRequest<PaginatedResponse<Commit>>(resourceUrl, restRequest);
			return task;
		}
		
		public Task<Commit> GetAsync(string owner, string repoSlug, string revision)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, repoSlug);
			segments.Add(REVISION_SEGMENT, revision);
			var restRequest = new RestComplexRequest(Method.GET, segments, null, null);	
			var task = MakeAsyncRequest<Commit>(SPECIFIED_COMMIT_RESOURCE, restRequest);
			return task;
		}
		
		public Task<PaginatedResponse<Comment>> GetCommentsAsync(string owner, string repoSlug, string revision,
															     PaginatedRequest paginatedRequest)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, repoSlug);
			segments.Add(REVISION_SEGMENT, revision);
			var parameters = CreateDefaultPaginationParameters(paginatedRequest);
			var restRequest = new RestComplexRequest(Method.GET, segments, parameters, null);
			var task = MakeAsyncRequest<PaginatedResponse<Comment>>(SPECIFIED_COMMIT_COMMENTS_RESOURCE, restRequest);
			return task;			
		}
		
		public Task<Comment> GetCommentAsync(string owner, string repoSlug, string revision, string commentId)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, repoSlug);
			segments.Add(REVISION_SEGMENT, revision);
			segments.Add(COMMENT_ID_SEGMENT, commentId);
			var restRequest = new RestComplexRequest(Method.GET, segments, null, null);	
			var task = MakeAsyncRequest<Comment>(SPECIFIED_COMMIT_SPECIFIC_COMMENT_RESOURCE, restRequest);
			return task;
		}
		
		public Task<ApprovalStatus> ApproveAsync(string owner, string repoSlug, string revision)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, repoSlug);
			segments.Add(REVISION_SEGMENT, revision);
			var restRequest = new RestComplexRequest(Method.POST, segments, null, null);	
			var task = MakeAsyncRequest<ApprovalStatus>(APPROVE_COMMENT_RESOURCE, restRequest);
			return task;
		}
		
		
		public Task<string> DisapproveAsync(string owner, string repoSlug, string revision)
		{
			var segments = CreateDefaultSegmentsDictionary(owner, repoSlug);
			segments.Add(REVISION_SEGMENT, revision);
			var restRequest = new RestComplexRequest(Method.DELETE, segments, null, null);	
			var task = MakeAsyncRequest<string>(APPROVE_COMMENT_RESOURCE, restRequest);
			return task;
		}
	}
}
