using System;
using System.Threading.Tasks;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.PullRequests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Responses;
using IsKernel.ServiceClients.Bitbucket.Models.Common;
using IsKernel.ServiceClients.Bitbucket.Models.PullRequests;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketPullRequestClient
	{
		Task<PaginatedResponse<PullRequest>> GetPullRequestsAsync(string owner, string reposlug, 
												     			  MultiValueRequestParameter<PullRequestState> states,
															      PaginatedRequest paginatedRequest);
		Task<string> CreatePullRequestAsync(string owner, string reposlug, PullRequest pullRequest);
		Task<string> EditPullRequestAsync(string owner, string reposlug, long id, PullRequest pullRequest);
		Task<PullRequest> GetPullRequestAsync(string owner, string reposlug, long id);
		Task<PaginatedResponse<Commit>> GetCommitsForPullRequestAsync(string owner, string reposlug, long id,
																	  PaginatedRequest paginatedRequest);
		Task<string> ApprovePullRequestAsync(string owner, string reposlug, long id);
		Task<string> DisapprovePullRequestAsync(string owner, string reposlug, long id);
		Task<string> GetDiffForPullRequestAsync(string owner, string reposlug, long id, long numberOfContextLines);
		Task<PaginatedResponse<Activity>> GetAllPullRequestActivityForRepositoryAsync(string owner, string reposlug,
																					  PaginatedRequest paginatedRequest);
		Task<PaginatedResponse<Activity>> GetPullRequestActivity(string owner, string reposlug, long pullRequestId,
																 PaginatedRequest paginatedRequest);
		Task<PullRequest> AcceptAndMergePullRequestAsync(string owner, string reposlug, long pullRequestId,
														 string message = "", bool closeSourceBranch = false);
		Task<PullRequest> DeclineAndMergePullRequestAsync(string owner, string reposlug, long pullRequestId,
														  string message = "");
		Task<PaginatedResponse<Comment>> GetAllCommentsForPullRequest(string owner, string reposlug, long pullRequestId,
																	  PaginatedRequest paginatedRequest);
		Task<Comment> GetCommentForPullRequest(string owner, string reposlug, long pullRequestId, long commentId);
	}
}
