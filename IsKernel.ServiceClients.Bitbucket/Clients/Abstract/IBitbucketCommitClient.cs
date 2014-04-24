using System;
using System.Threading.Tasks;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits;
using IsKernel.ServiceClients.Bitbucket.Contracts.Commits.Parameters;
using IsKernel.ServiceClients.Bitbucket.Contracts.Other;
using IsKernel.ServiceClients.Bitbucket.Contracts.Requests;
using IsKernel.ServiceClients.Bitbucket.Contracts.Responses;

namespace IsKernel.ServiceClients.Bitbucket.Clients.Abstract
{
	public interface IBitbucketCommitClient
	{
		Task<PaginatedResponse<Commit>> GetCommitsForRepositoryAsync(string owner, string repoSlug, 
																     PaginatedRequest paginatedRequest,
																	 CommitGetOptionalParameters optional);
		Task<Commit> GetCommitAsync(string owner, string repoSlug, string revision);
		Task<PaginatedResponse<Comment>> GetCommitCommentsAsync(string owner, string repoSlug, string revision,
															    PaginatedRequest request);
		Task<Comment> GetCommitSpecificCommentAsync(string owner, string repoSlug, string revision, long commentId);
		Task<ApprovalStatus> ApproveCommitAsync(string owner, string repoSlug, string revision);
		Task<string> DisapproveCommitAsync(string owner, string repoSlug, string revision);
	}
}
