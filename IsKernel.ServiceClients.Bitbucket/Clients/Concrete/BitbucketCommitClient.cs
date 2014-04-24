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
		
		public Task<PaginatedResponse<Commit>> GetCommitsForRepositoryAsync(string owner, string repoSlug, 
																		    PaginatedRequest paginatedRequest,
																			CommitGetOptionalParameters optional)
		{
			var segmentList = CreateOwnerRepoSegments(owner,repoSlug);
			var parameterList = paginatedRequest.ToTuples();
			var resourceUrl = string.Empty;
			if(optional.BranchOrTag != null)
			{
				resourceUrl = COMMITS_DEFAULT_RESOURCE;
				segmentList.Add(new Tuple<string, string>(optional.BranchOrTag.Name, optional.BranchOrTag.Value));
			}
			else
			{
				resourceUrl = COMMITS_DEFAULT_RESOURCE;
			}
			
			var ownerAndRepoList = CreateOwnerRepoSegments(owner, repoSlug);
			var task = MakeAsyncRequest<PaginatedResponse<Commit>>(resourceUrl, Method.GET, segmentList, 
																   parameterList, "Could not retrieve commits");
			return task;
		}
		
		public Task<Commit> GetCommitAsync(string owner, string repoSlug, string revision)
		{
			var segmentList = CreateOwnerRepoSegments(owner,repoSlug);
			segmentList.Add(new Tuple<string, string>(REVISION_SEGMENT, revision));
			var task = MakeAsyncRequest<Commit>(SPECIFIED_COMMIT_RESOURCE, Method.GET, 
												segmentList, null, 
												"Could not read commit.");
			return task;
		}
		
		public Task<PaginatedResponse<Comment>> GetCommitCommentsAsync(string owner, string repoSlug, string revision,
																	   PaginatedRequest request)
		{
			var parameterlist = request.ToTuples();
			var segmentList = CreateOwnerRepoSegments(owner,repoSlug);
			segmentList.Add(new Tuple<string, string>(REVISION_SEGMENT, revision));
			var task = MakeAsyncRequest<PaginatedResponse<Comment>>(SPECIFIED_COMMIT_COMMENTS_RESOURCE, Method.GET, 
																	segmentList, parameterlist, 
																	"Could not read commit comments.");
			return task;			
		}
		
		public Task<Comment> GetCommitSpecificCommentAsync(string owner, string repoSlug, string revision, long commentId)
		{
			var segmentList = CreateOwnerRepoSegments(owner,repoSlug);
			segmentList.Add(new Tuple<string, string>(REVISION_SEGMENT, revision));
			segmentList.Add(new Tuple<string, string>(COMMENT_ID_SEGMENT, commentId.ToString()));
			var task = MakeAsyncRequest<Comment>(SPECIFIED_COMMIT_SPECIFIC_COMMENT_RESOURCE, Method.GET, 
												 segmentList, null, 
												 "Could not read commit comment.");
			return task;
		}
		
		public Task<ApprovalStatus> ApproveCommitAsync(string owner, string repoSlug, string revision)
		{
			var segmentList = CreateOwnerRepoSegments(owner,repoSlug);
			segmentList.Add(new Tuple<string, string>(REVISION_SEGMENT, revision));
			var task = MakeAsyncRequest<ApprovalStatus>(APPROVE_COMMENT_RESOURCE, Method.POST, 
												 		segmentList, null, 
												 		"Could not read commit comment.");
			return task;
		}
		
		
		public Task<string> DisapproveCommitAsync(string owner, string repoSlug, string revision)
		{
			var segmentList = CreateOwnerRepoSegments(owner,repoSlug);
			segmentList.Add(new Tuple<string, string>(REVISION_SEGMENT, revision));
			var task = MakeAsyncRequest<string>(APPROVE_COMMENT_RESOURCE, Method.DELETE, 
										 		segmentList, null, 
										 		"Could not read commit comment.");
			return task;
		}
	}
}
