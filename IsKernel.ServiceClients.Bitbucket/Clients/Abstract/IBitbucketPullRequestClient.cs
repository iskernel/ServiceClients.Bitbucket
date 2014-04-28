using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests;
using IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketPullRequestClient
	{
		Task<PaginatedResponse<PullRequest>> GetAllAsync(string owner, string reposlug, 
				     				    				 IEnumerable<PullRequestState> states,
						        	    				 PaginatedRequest paginatedRequest);
		
		Task<PullRequest> CreateAsync(string owner, string reposlug, PullRequest pullRequest);
		
		Task<PullRequest> EditAsync(string owner, string reposlug, long id, PullRequest pullRequest);
		
		Task<PullRequest> GetAsync(string owner, string reposlug, long id);
		
		Task<PaginatedResponse<Commit>> GetCommitsAsync(string owner, string reposlug, long id, PaginatedRequest paginatedRequest);
		
		Task<PullRequest> ApproveAsync(string owner, string reposlug, long id);
		
		Task<PullRequest> DisapproveAsync(string owner, string reposlug, long id);
		
		Task<string> GetDiffAsync(string owner, string reposlug, long id, long numberOfContextLines = 3);
		
		Task<PaginatedResponse<Activity>> GetAllActivityAsync(string owner, string reposlug, PaginatedRequest paginatedRequest);
		
		Task<PaginatedResponse<Activity>> GetActivityAsync(string owner, string reposlug, long pullRequestId, 
														   PaginatedRequest paginatedRequest);
		
		Task<PullRequest> AcceptAsync(string owner, string reposlug, long pullRequestId, string message = "", 
									  bool closeSourceBranch = false);
		
		Task<PullRequest> DeclineAsync(string owner, string reposlug, long pullRequestId, string message = "");
		
		Task<PaginatedResponse<Comment>> GetCommentsAsync(string owner, string reposlug, long pullRequestId, 
														  PaginatedRequest paginatedRequest);
		
		Task<Comment> GetCommentAsync(string owner, string reposlug, long pullRequestId, long commentId);
	}
}
