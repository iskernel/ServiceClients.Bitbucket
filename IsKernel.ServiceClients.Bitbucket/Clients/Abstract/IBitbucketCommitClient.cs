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
		Task<PaginatedResponse<Commit>> GetAllAsync(string owner, string repoSlug, PaginatedRequest paginatedRequest,
											   CommitGetOptionalParameters optional);
		Task<Commit> GetAsync(string owner, string repoSlug, string revision);
		Task<PaginatedResponse<Comment>> GetCommentsAsync(string owner, string repoSlug, string revision,
														  PaginatedRequest request);
		Task<Comment> GetCommentAsync(string owner, string repoSlug, string revision, string commentId);
		Task<ApprovalStatus> ApproveAsync(string owner, string repoSlug, string revision);
		Task<string> DisapproveAsync(string owner, string repoSlug, string revision);
	}
}
