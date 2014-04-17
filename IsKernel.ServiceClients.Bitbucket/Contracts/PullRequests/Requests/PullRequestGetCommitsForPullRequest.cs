using System;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Models.Users;
using IsKernel.ServiceClients.Bitbucket.Contracts.Common.Requests.PullRequests;

namespace IsKernel.ServiceClients.Bitbucket.Contracts.PullRequests.Requests
{
	public class PullRequestGetCommitsForPullRequest : PullRequestSpecificRequestBase
	{	
		public PullRequestGetCommitsForPullRequest(string owner, string repoSlug, string pullRequestId)
			:base(owner, repoSlug, pullRequestId)
		{
		}
	}
}
